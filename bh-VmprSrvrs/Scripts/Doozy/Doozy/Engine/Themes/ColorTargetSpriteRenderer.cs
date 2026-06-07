using UnityEngine;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Color Target SpriteRenderer", 13)]
	[DefaultExecutionOrder(-100)]
	public class ColorTargetSpriteRenderer : ThemeTarget
	{
		public SpriteRenderer SpriteRenderer;

		public bool OverrideAlpha;

		public float Alpha;

		private float m_previousAlphaValue;

		private void Update()
		{
		}

		public override void UpdateTarget(ThemeData theme)
		{
		}

		public void SetAlpha(float value)
		{
		}

		private void Reset()
		{
		}

		private void UpdateReference()
		{
		}
	}
}
