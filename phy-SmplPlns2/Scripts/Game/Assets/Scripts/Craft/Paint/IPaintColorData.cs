using UnityEngine;

namespace Assets.Scripts.Craft.Paint
{
	public interface IPaintColorData
	{
		Color Color { get; }

		float? EmissionDay { get; set; }

		float? EmissionNight { get; set; }

		float? Metallic { get; }

		float? Smoothness { get; }

		PaintColorData Clone();

		void CopyTo(PaintColorData other);

		bool IsEqual(IPaintColorData other);
	}
}
