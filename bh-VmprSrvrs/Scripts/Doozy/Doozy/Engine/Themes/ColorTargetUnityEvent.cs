using Doozy.Engine.Events;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Color Target UnityEvent", 13)]
	[DefaultExecutionOrder(-100)]
	public class ColorTargetUnityEvent : ThemeTarget
	{
		public ColorEvent Event;

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
