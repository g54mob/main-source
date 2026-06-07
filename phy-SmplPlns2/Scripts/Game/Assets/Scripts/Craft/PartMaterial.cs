using System.Linq;
using Assets.Scripts.Craft.Paint;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class PartMaterial
	{
		public PaintColorData[] ColorData { get; set; }

		public float EmissionDay { get; set; }

		public float EmissionNight { get; set; }

		public int Id { get; set; }

		public bool IsReserved { get; set; }

		public float Metallic { get; set; }

		public string Name { get; set; }

		public Color PrimaryColor => ColorData[0].Color;

		public float PrimaryColorEmissionDay => ColorData[0].EmissionDay ?? EmissionDay;

		public float PrimaryColorEmissionNight => ColorData[0].EmissionNight ?? EmissionNight;

		public float PrimaryColorMetallic => ColorData[0].Metallic ?? Metallic;

		public float PrimaryColorSmoothness => ColorData[0].Smoothness ?? Smoothness;

		public float Smoothness { get; set; }

		public float SmoothnessModifier { get; set; }

		public PaintStyle Style { get; set; }

		public PaintTextureData Texture { get; set; }

		public float TextureBlend { get; set; }

		public Vector3 TextureOffset { get; set; }

		public string TexturePresetId { get; set; }

		public Vector3 TextureRotation { get; set; }

		public Vector3 TextureScale { get; set; }

		public PaintTextureWrapMode[] TextureWrapMode { get; set; }

		public PartMaterial Clone()
		{
			return new PartMaterial
			{
				Id = Id,
				Style = Style,
				ColorData = PaintColorData.Clone(ColorData),
				Name = Name,
				Metallic = Metallic,
				Smoothness = Smoothness,
				SmoothnessModifier = SmoothnessModifier,
				EmissionDay = EmissionDay,
				EmissionNight = EmissionNight,
				Texture = Texture,
				TexturePresetId = TexturePresetId,
				TextureBlend = TextureBlend,
				TextureOffset = TextureOffset,
				TextureRotation = TextureRotation,
				TextureScale = TextureScale,
				TextureWrapMode = TextureWrapMode.ToArray(),
				IsReserved = IsReserved
			};
		}
	}
}
