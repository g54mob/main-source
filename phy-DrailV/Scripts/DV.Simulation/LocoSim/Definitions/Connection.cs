using System;

namespace LocoSim.Definitions
{
	[Serializable]
	public class Connection
	{
		public string fullPortIdOut;

		public string fullPortIdIn;

		public Connection(string fullPortIdOut, string fullPortIdIn)
		{
			this.fullPortIdOut = fullPortIdOut;
			this.fullPortIdIn = fullPortIdIn;
		}
	}
}
