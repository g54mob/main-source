using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Color Target Text", 13)]
	[DefaultExecutionOrder(-100)]
	public class ColorTargetText : ThemeTarget
	{
		public Text Text;

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
