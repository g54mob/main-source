using System;
using UnityEngine;

namespace GRP
{
	public class SpurGearVisual : MonoBehaviour
	{
		public GearConfig config;

		public MeshFilter meshFilter;

		public MeshRenderer meshRenderer;

		public SpurGearInlayVisual inlayVisual;

		public SpurGearHoleVisual holeVisual;

		[NonSerialized]
		public GearModule module;

		private MaterialPropertyBlock materialBlock;

		public void Setup()
		{
		}

		public void Build(SpurGearVisualOptions options)
		{
		}

		public static Mesh BuildToothMesh(SpurGearVisualOptions options, GearConfig config)
		{
			return null;
		}

		public Mesh[] BuildColliderMesh(SpurGearVisualOptions options)
		{
			return null;
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}
	}
}
