using System;

namespace SaveData
{
	[Serializable]
	public class UseToGetPoint
	{
		public ePointType type;

		public int _remain;

		public int _borderPoint;

		public int _getvalue;

		public bool TryGetPoint(int use, out int point)
		{
			point = default(int);
			return false;
		}

		public UseToGetPoint(ePointType type, int borderPoint, int getvalue)
		{
		}
	}
}
