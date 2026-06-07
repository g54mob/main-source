using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Texture Target RawImage", 13)]
	[DefaultExecutionOrder(-100)]
	public class TextureTargetRawImage : ThemeTarget
	{
		public RawImage Image;

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
