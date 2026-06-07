using System;
using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class DeferredDecal : MonoBehaviour
	{
		[NonSerialized]
		internal int DecalID = -1;

		[NonSerialized]
		internal int MaterialID = -1;

		[NonSerialized]
		internal int PerMaterialID = -1;

		[NonSerialized]
		internal Matrix4x4 LocalToWorld = Matrix4x4.identity;

		[NonSerialized]
		internal float SquaredCenterDistance;

		[NonSerialized]
		internal float SquaredBoundingSphere;

		public Material materialClose;

		public Material materialFar;

		private DeferredDecalRenderer myRenderer;

		private void OnEnable()
		{
			myRenderer = SingletonBehaviour<DeferredDecalRenderer>.Instance;
			myRenderer.RegisterDecal(this);
		}

		private void OnDisable()
		{
			if ((bool)myRenderer)
			{
				myRenderer.UnregisterDecal(this);
			}
		}
	}
}
