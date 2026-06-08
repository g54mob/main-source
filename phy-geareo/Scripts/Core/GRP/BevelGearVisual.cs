using System;
using UnityEngine;

namespace GRP
{
	public class BevelGearVisual : MonoBehaviour
	{
		public GearConfig config;

		public MeshFilter meshFilter;

		public MeshRenderer meshRenderer;

		public BevelGearHoleVisual holeVisual;

		public BevelGearInlayVisual inlayVisual;

		[NonSerialized]
		public GearModule module;

		private MaterialPropertyBlock materialBlock;

		public void Setup()
		{
		}

		public void Build(BevelGearVisualOptions options)
		{
		}

		public static Mesh BuildToothMesh(BevelGearVisualOptions options, GearConfig config)
		{
			return null;
		}

		public Mesh[] BuildColliderMesh(BevelGearVisualOptions options)
		{
			return null;
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}
	}
}
