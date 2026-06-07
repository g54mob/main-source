using System;
using ModApi.Craft;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Craft.Events
{
	public class CreatingPartGameObjectEventArgs : EventArgs
	{
		private static readonly CreatingPartGameObjectEventArgs _static = new CreatingPartGameObjectEventArgs();

		public ICraftScript CraftScript { get; private set; }

		public PartData PartData { get; private set; }

		private CreatingPartGameObjectEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatingPartGameObjectEventArgs> eventHandler, PartData partData, ICraftScript craftScript)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartData = partData;
			_static.CraftScript = craftScript;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.PartData = null;
				_static.CraftScript = null;
			}
		}
	}
}
