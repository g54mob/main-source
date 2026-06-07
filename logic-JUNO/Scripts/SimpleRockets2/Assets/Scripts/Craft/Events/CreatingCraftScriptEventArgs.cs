using System;
using ModApi.Craft;

namespace Assets.Scripts.Craft.Events
{
	public class CreatingCraftScriptEventArgs : EventArgs
	{
		private static readonly CreatingCraftScriptEventArgs _static = new CreatingCraftScriptEventArgs();

		public CraftData Craft { get; private set; }

		public bool CreateBodyScripts { get; private set; }

		private CreatingCraftScriptEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatingCraftScriptEventArgs> eventHandler, CraftData craft, bool createBodyScripts)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.Craft = craft;
			_static.CreateBodyScripts = createBodyScripts;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.Craft = null;
			}
		}
	}
}
