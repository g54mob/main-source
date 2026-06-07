using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Font Target Text", 13)]
	[DefaultExecutionOrder(-100)]
	public class FontTargetText : ThemeTarget
	{
		public Text Text;

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
