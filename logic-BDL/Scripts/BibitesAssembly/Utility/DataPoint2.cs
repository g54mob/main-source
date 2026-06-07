using System;

namespace Utility
{
	public struct DataPoint2 : IDataPoint
	{
		public float a;

		public float b;

		public float this[int i]
		{
			get
			{
				return i switch
				{
					0 => a, 
					1 => b, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			set
			{
				switch (i)
				{
				case 0:
					a = value;
					break;
				case 1:
					b = value;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public int GetLenght()
		{
			return 2;
		}

		public DataPoint2(float A, float B)
		{
			a = A;
			b = B;
		}
	}
}
