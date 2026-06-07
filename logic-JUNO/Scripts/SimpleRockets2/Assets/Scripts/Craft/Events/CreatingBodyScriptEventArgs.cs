using System;
using ModApi.Craft;

namespace Assets.Scripts.Craft.Events
{
	public class CreatingBodyScriptEventArgs : EventArgs
	{
		private static readonly CreatingBodyScriptEventArgs _static = new CreatingBodyScriptEventArgs();

		public BodyData BodyData { get; private set; }

		public CraftScript CraftScript { get; private set; }

		private CreatingBodyScriptEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatingBodyScriptEventArgs> eventHandler, CraftScript craftScript, BodyData bodyData)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.CraftScript = craftScript;
			_static.BodyData = bodyData;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.CraftScript = null;
				_static.BodyData = null;
			}
		}
	}
}
