using System;

namespace Utility
{
	public struct DataPoint5 : IDataPoint
	{
		public float a;

		public float b;

		public float c;

		public float d;

		public float e;

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
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public int GetLenght()
		{
			return 5;
		}

		public DataPoint5(float A, float B, float C, float D, float E)
		{
			a = A;
			b = B;
			c = C;
			d = D;
			e = E;
		}
	}
}
