using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Color Target Image", 13)]
	[DefaultExecutionOrder(-100)]
	public class ColorTargetImage : ThemeTarget
	{
		public Image Image;

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
