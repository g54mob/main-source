using System;

namespace NSMedieval.Model
{
	[Serializable]
	public class IntIntPair : SerializablePair<int, int>
	{
		public IntIntPair()
		{
		}

		public IntIntPair(int skill, int value)
			: base(skill, value)
		{
		}
	}
}
