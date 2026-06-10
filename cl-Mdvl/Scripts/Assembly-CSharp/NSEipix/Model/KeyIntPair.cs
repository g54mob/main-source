using System;

namespace NSEipix.Model
{
	[Serializable]
	public class KeyIntPair : Pair<int>
	{
		public KeyIntPair()
		{
		}

		public KeyIntPair(string id, int value)
			: base(id, value)
		{
		}
	}
}
