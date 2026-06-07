using UnityEngine;

namespace VampireSurvivors.Graphics
{
	public class HitVFXData
	{
		public bool HasTintFill;

		public string TintColor;

		public Sprite HitSprite;

		public Sprite ImpactSprite;

		public float Duration;

		public Color? CachedTintColor;

		public HitVFXData(bool hasTintFill, string tintColor, Sprite hitSprite, Sprite impactSprite, float duration)
		{
		}

		public Color GetColor()
		{
			return default(Color);
		}
	}
}
