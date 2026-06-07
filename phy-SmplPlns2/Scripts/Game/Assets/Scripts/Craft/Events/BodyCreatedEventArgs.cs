using System;

namespace Assets.Scripts.Craft.Events
{
	public class BodyCreatedEventArgs : EventArgs
	{
		public BodyScript NewBodyScript { get; private set; }

		public BodyScript SourceBodyScript { get; private set; }

		public BodyCreatedEventArgs(BodyScript sourceBodyScript, BodyScript newBodyScript)
		{
			SourceBodyScript = sourceBodyScript;
			NewBodyScript = newBodyScript;
		}
	}
}
