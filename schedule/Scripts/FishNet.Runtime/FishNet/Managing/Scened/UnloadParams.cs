using System;

namespace FishNet.Managing.Scened
{
	public class UnloadParams
	{
		[NonSerialized]
		public object[] ServerParams;

		public byte[] ClientParams;
	}
}
