using System;

namespace Utility
{
	public struct DataPoint3 : IDataPoint
	{
		public float a;

		public float b;

		public float c;

		public float this[int i]
		{
			get
			{
				return i switch
				{
					0 => a, 
					1 => b, 
					2 => c, 
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
				case 2:
					c = value;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public int GetLenght()
		{
			return 3;
		}

		public DataPoint3(float A, float B, float C)
		{
			a = A;
			b = B;
			c = C;
		}
	}
}
