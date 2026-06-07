using System;

namespace Utility
{
	public struct DataPoint6 : IDataPoint
	{
		public float a;

		public float b;

		public float c;

		public float d;

		public float e;

		public float f;

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
					4 => e, 
					5 => f, 
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
				case 4:
					e = value;
					break;
				case 5:
					f = value;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public int GetLenght()
		{
			return 6;
		}

		public DataPoint6(float A, float B, float C, float D, float E, float F)
		{
			a = A;
			b = B;
			c = C;
			d = D;
			e = E;
			f = F;
		}
	}
}
