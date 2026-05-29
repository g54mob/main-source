using System;

namespace FishNet.Managing.Scened
{
	public class LoadParams
	{
		[NonSerialized]
		public object[] ServerParams;

		public byte[] ClientParams;
	}
}
