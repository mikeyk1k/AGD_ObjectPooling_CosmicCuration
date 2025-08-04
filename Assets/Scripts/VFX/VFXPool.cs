using System.Collections;
using UnityEngine;
using CosmicCuration.Utilities;
using System.Collections.Generic;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView vfxPrefab;

        public VFXPool(VFXView vfxPrefab) => this.vfxPrefab = vfxPrefab;

        public VFXController GetVFX() => GetItem<VFXController>();
        protected override VFXController CreateItem<T>() => new VFXController(vfxPrefab);
    }
}