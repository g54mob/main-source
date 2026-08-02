using System;
using UnityEngine;

namespace GRP
{
	public class GearVisual : MonoBehaviour
	{
		public GearConfig config;

		public GearInlayContainer inlayContainer;

		public MeshCollider meshCollider;

		public Transform helperTransform;

		public MeshFilter mainRenderer;

		public MeshRenderer rend;

		public float uvScale;

		public float colliderPadding;

		[NonSerialized]
		public float topRadius;

		[NonSerialized]
		public float bottomOffset;

		[NonSerialized]
		public float d3;

		[NonSerialized]
		public float bottomRadius;

		[NonSerialized]
		public bool small;

		[NonSerialized]
		public GearModule module;

		private MaterialPropertyBlock materialBlock;

		public void Setup()
		{
		}

		public void Build(GearVisualOptions options)
		{
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}
	}
}
