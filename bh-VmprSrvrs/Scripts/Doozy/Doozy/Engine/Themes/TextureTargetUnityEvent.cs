using Doozy.Engine.Events;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Texture Target UnityEvent", 13)]
	[DefaultExecutionOrder(-100)]
	public class TextureTargetUnityEvent : ThemeTarget
	{
		public TextureEvent Event;

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
