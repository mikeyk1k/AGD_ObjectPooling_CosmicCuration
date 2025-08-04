using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        [SerializeField] private List<VFXData> particleSystemMap;
        private VFXController controller;
        private ParticleSystem currentPlayingVFX;

        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(VFXType vfxType, Vector2 positionToSet)
        {
            gameObject.SetActive(true);
            transform.position = positionToSet;
            
            foreach (VFXData item in particleSystemMap)
            {
                if (item.type == vfxType)
                {
                    item.particleSystem.gameObject.SetActive(true);
                    currentPlayingVFX = item.particleSystem;
                }
                else item.particleSystem.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if(currentPlayingVFX != null)
            {
                if(currentPlayingVFX.isStopped)
                {
                    currentPlayingVFX.gameObject.SetActive(false);
                    currentPlayingVFX = null;
                    controller.OnParticleEffectCompleted();
                    gameObject.SetActive(false);
                }
            }
        }
    }
}