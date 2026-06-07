using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class PartMaterial
	{
		public Color Color { get; set; }

		public float DetailStrength { get; set; }

		public float EmissionStrength { get; set; }

		public int Id { get; set; }

		public float Metallic { get; set; }

		public string Name { get; set; }

		public float Smoothness { get; set; }

		public float SmoothnessModifier { get; set; }

		public float TransparencyStrength { get; set; }
	}
}
