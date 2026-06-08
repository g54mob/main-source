using System;
using UnityEngine;

namespace GRP
{
	public class LinearGearVisual : MonoBehaviour
	{
		public GearConfig config;

		public BoxCollider boxCollider;

		public BoxVisual bodyVisual;

		public MeshFilter meshFilter;

		public MeshRenderer meshRenderer;

		public Transform helperTransform;

		public float uvScale;

		public float colliderPadding;

		[NonSerialized]
		public GearModule module;

		private MaterialPropertyBlock materialBlock;

		public void Setup()
		{
		}

		public void Build(LinearGearVisualOptions options)
		{
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}
	}
}
