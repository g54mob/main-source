using System;
using App.Data;

namespace DeepTraffic
{
	public class CarDatas : BaseKeyData, ICloneable
	{
		public int dummyCar;

		public int emptySpace;

		public int wall;

		public int need;

		public int releaseCoef;

		public int seed;

		public CarDatas(int dummyCar, int emptySpace, int wall, int need, int releaseCoef, int seed)
		{
			this.dummyCar = dummyCar;
			this.emptySpace = emptySpace;
			this.wall = wall;
			this.need = need;
			this.releaseCoef = releaseCoef;
			this.seed = seed;
		}

		public object Clone()
		{
			return new CarDatas(dummyCar, emptySpace, wall, need, releaseCoef, seed)
			{
				KeyName = (string)KeyName.Clone()
			};
		}
	}
}
