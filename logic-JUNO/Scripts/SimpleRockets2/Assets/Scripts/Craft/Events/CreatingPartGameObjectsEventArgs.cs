using System;
using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Craft.Events
{
	public class CreatingPartGameObjectsEventArgs : EventArgs
	{
		private static readonly CreatingPartGameObjectsEventArgs _static = new CreatingPartGameObjectsEventArgs();

		public ICraftScript CraftScript { get; private set; }

		public IEnumerable<PartData> Parts { get; private set; }

		private CreatingPartGameObjectsEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatingPartGameObjectsEventArgs> eventHandler, IEnumerable<PartData> parts, ICraftScript craftScript)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.Parts = parts;
			_static.CraftScript = craftScript;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.Parts = null;
				_static.CraftScript = null;
			}
		}
	}
}
