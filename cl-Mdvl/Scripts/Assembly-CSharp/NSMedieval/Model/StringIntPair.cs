using System;

namespace NSMedieval.Model
{
	[Serializable]
	public class StringIntPair : SerializablePair<string, int>
	{
		public StringIntPair()
		{
		}

		public StringIntPair(string id, int value)
			: base(id, value)
		{
		}
	}
}
