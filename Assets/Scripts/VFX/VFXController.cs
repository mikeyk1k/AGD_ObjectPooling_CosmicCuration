using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXController
    {
        private VFXView vfxView;

        public VFXController(VFXView vfxPrefab)
        {
            vfxView = Object.Instantiate(vfxPrefab);
            vfxView.SetController(this);
        }

        public void Configure(VFXType vfxType, Vector2 spawnPosition) => vfxView.ConfigureAndPlay(vfxType, spawnPosition);

        public void OnParticleEffectCompleted()
        {
            GameService.Instance.GetVFXService().ReturnVFXToPool(this);
        }
    }
}