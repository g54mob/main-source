using System;
using UnityEngine;

namespace GRP
{
	public class SpurGearInlayVisual : MonoBehaviour
	{
		public SpurGearVisual visual;

		public MeshCollider meshCollider;

		public GearInlayContainer inlayContainer;

		[NonSerialized]
		public GearModule module;

		private MaterialPropertyBlock materialBlock;

		public void Setup()
		{
		}

		public void Build(SpurGearVisualOptions options, GearConfig config)
		{
		}

		public void Destroy()
		{
		}

		public Mesh BuildColliderMesh(SpurGearVisualOptions options)
		{
			return null;
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}
	}
}
