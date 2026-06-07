using System;

namespace Utility
{
	public struct DataPoint4 : IDataPoint
	{
		public float a;

		public float b;

		public float c;

		public float d;

		public float this[int i]
		{
			get
			{
				return i switch
				{
					0 => a, 
					1 => b, 
					2 => c, 
					3 => d, 
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
				case 3:
					d = value;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public int GetLenght()
		{
			return 4;
		}

		public DataPoint4(float A, float B, float C, float D)
		{
			a = A;
			b = B;
			c = C;
			d = D;
		}
	}
}
