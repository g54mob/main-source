using System;

namespace MyBox
{
	[Serializable]
	public struct MinMaxInt
	{
		public int Min;

		public int Max;

		public MinMaxInt(int min, int max)
		{
			Min = 0;
			Max = 0;
		}
	}
}
