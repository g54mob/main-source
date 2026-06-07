using System;

namespace ModApi.Craft.Parts.Events
{
	public class CreatedPartModifierScriptEventArgs : EventArgs
	{
		private static readonly CreatedPartModifierScriptEventArgs _static = new CreatedPartModifierScriptEventArgs();

		public PartModifierData PartModifier { get; private set; }

		public PartModifierScript PartModifierScript { get; private set; }

		private CreatedPartModifierScriptEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatedPartModifierScriptEventArgs> eventHandler, PartModifierData partModifier, PartModifierScript partModifierScript)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartModifier = partModifier;
			_static.PartModifierScript = partModifierScript;
			try
			{
				eventHandler(partModifier, _static);
			}
			finally
			{
				_static.PartModifier = null;
				_static.PartModifierScript = null;
			}
		}
	}
}
