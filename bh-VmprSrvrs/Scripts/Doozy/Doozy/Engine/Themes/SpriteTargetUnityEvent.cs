using Doozy.Engine.Events;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Sprite Target UnityEvent", 13)]
	[DefaultExecutionOrder(-100)]
	public class SpriteTargetUnityEvent : ThemeTarget
	{
		public SpriteEvent Event;

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
