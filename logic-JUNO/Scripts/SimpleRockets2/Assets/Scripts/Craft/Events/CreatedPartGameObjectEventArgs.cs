using System;
using ModApi.Craft;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Craft.Events
{
	public class CreatedPartGameObjectEventArgs : EventArgs
	{
		private static readonly CreatedPartGameObjectEventArgs _static = new CreatedPartGameObjectEventArgs();

		public ICraftScript CraftScript { get; private set; }

		public PartData PartData { get; private set; }

		public IPartScript PartScript { get; private set; }

		private CreatedPartGameObjectEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatedPartGameObjectEventArgs> eventHandler, PartData partData, ICraftScript craftScript, IPartScript partScript)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartData = partData;
			_static.CraftScript = craftScript;
			_static.PartScript = partScript;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.PartData = null;
				_static.CraftScript = null;
				_static.PartScript = null;
			}
		}
	}
}
