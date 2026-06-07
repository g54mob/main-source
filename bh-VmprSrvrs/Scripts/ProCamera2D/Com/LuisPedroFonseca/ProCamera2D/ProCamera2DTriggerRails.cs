using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/trigger-rails/")]
	public class ProCamera2DTriggerRails : BaseTrigger
	{
		public static string TriggerName;

		[HideInInspector]
		public ProCamera2DRails ProCamera2DRails;

		public TriggerRailsMode Mode;

		public float TransitionDuration;

		private void Start()
		{
		}

		protected override void EnteredTrigger()
		{
		}
	}
}
