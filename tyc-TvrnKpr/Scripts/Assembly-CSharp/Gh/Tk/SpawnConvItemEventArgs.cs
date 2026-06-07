using System;

namespace Gh.Tk
{
	public class SpawnConvItemEventArgs : EventArgs
	{
		public string TransformName { get; }

		public bool OnAP { get; }

		public SpawnConvItemEventArgs(string transformName, bool onAP)
		{
		}
	}
}
