using System;
using UnityEngine;

namespace Aura2API
{
	[Serializable]
	[CreateAssetMenu(fileName = "New Aura Base Settings", menuName = "Aura 2/Base Settings", order = 0)]
	public class AuraBaseSettings : ScriptableObject
	{
		public bool useDensity = true;

		public float density = 0.25f;

		public bool useScattering = true;

		[Range(0f, 1f)]
		public float scattering = 0.5f;

		public bool useAmbientLighting = true;

		public float ambientLightingStrength = 1f;

		public bool useColor;

		[ColorCircularPicker(false)]
		public Color color = Color.cyan * 0.5f;

		public float colorStrength = 1f;

		public bool useTint;

		[ColorCircularPicker(false)]
		public Color tint = Color.yellow;

		public float tintStrength = 1f;

		public bool useExtinction;

		public float extinction = 0.75f;
	}
}
