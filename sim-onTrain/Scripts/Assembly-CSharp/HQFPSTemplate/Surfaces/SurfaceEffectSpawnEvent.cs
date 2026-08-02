using UnityEngine;

namespace HQFPSTemplate.Surfaces
{
	public struct SurfaceEffectSpawnEvent
	{
		public GameObject EffectObj;

		public int SurfaceId;

		public SurfaceEffects EffectType;

		public float AudioVolume;
	}
}
