using System;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Craft.Events
{
	public class CreatingBodyJointEventArgs : EventArgs
	{
		private static readonly CreatingBodyJointEventArgs _static = new CreatingBodyJointEventArgs();

		public PartConnection PartConnection { get; private set; }

		private CreatingBodyJointEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatingBodyJointEventArgs> eventHandler, PartConnection partConnection)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartConnection = partConnection;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.PartConnection = null;
			}
		}
	}
}
