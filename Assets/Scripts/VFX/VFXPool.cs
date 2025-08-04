using System.Collections;
using UnityEngine;
using CosmicCuration.Utilities;
using System.Collections.Generic;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView prefabToSpawn;

        public VFXController GetVFX(VFXView vfxView)
        {
            this.prefabToSpawn = vfxView;
            return GetItem<VFXController>();
        }
        protected override VFXController CreateItem<T>()
        {

            if (typeof(T) == typeof(VFXController))
            {
                VFXController vfxToPlay = new VFXController(prefabToSpawn);
                return vfxToPlay;
            }
            throw new System.Exception($"VFX Type not supported");
        }
    }
}