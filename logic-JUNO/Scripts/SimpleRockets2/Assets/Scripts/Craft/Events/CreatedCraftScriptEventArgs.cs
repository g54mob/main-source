using System;
using ModApi.Craft;

namespace Assets.Scripts.Craft.Events
{
	public class CreatedCraftScriptEventArgs : EventArgs
	{
		private static readonly CreatedCraftScriptEventArgs _static = new CreatedCraftScriptEventArgs();

		public CraftData Craft { get; private set; }

		public CraftScript CraftScript { get; private set; }

		public bool CreateBodyScripts { get; private set; }

		private CreatedCraftScriptEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatedCraftScriptEventArgs> eventHandler, CraftData craft, bool createBodyScripts, CraftScript craftScript)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.Craft = craft;
			_static.CreateBodyScripts = createBodyScripts;
			_static.CraftScript = craftScript;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.Craft = null;
				_static.CraftScript = null;
			}
		}
	}
}
