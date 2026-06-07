using System;
using ModApi.Craft;

namespace Assets.Scripts.Craft.Events
{
	public class CreatedBodyScriptEventArgs : EventArgs
	{
		private static readonly CreatedBodyScriptEventArgs _static = new CreatedBodyScriptEventArgs();

		public BodyData BodyData { get; private set; }

		public BodyScript BodyScript { get; private set; }

		public CraftScript CraftScript { get; private set; }

		private CreatedBodyScriptEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatedBodyScriptEventArgs> eventHandler, CraftScript craftScript, BodyData bodyData, BodyScript bodyScript)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.CraftScript = craftScript;
			_static.BodyData = bodyData;
			_static.BodyScript = bodyScript;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.CraftScript = null;
				_static.BodyData = null;
				_static.BodyScript = null;
			}
		}
	}
}
