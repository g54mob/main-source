using System;
using UnityEngine;

namespace GRP
{
	public class RingGearVisual : MonoBehaviour
	{
		public GearConfig config;

		public RingVisual bodyVisual;

		public Transform helperTransform;

		public MeshRenderer meshRenderer;

		public MeshFilter meshFilter;

		public float colliderPadding;

		[NonSerialized]
		public GearModule module;

		private MaterialPropertyBlock materialBlock;

		public void Setup()
		{
		}

		public void Build(RingGearVisualOptions options)
		{
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}
	}
}
