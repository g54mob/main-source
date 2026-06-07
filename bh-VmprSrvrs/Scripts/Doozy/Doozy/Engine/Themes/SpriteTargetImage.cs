using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Sprite Target Image", 13)]
	[DefaultExecutionOrder(-100)]
	public class SpriteTargetImage : ThemeTarget
	{
		public Image Image;

		public override void UpdateTarget(ThemeData theme)
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
