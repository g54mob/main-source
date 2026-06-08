using System.Collections.Generic;

namespace KitchenData
{
	public class GameDataObjectComparer : IEqualityComparer<GameDataObject>
	{
		public bool Equals(GameDataObject x, GameDataObject y)
		{
			if ((object)x == y)
			{
				return true;
			}
			if ((object)x == null)
			{
				return false;
			}
			if ((object)y == null)
			{
				return false;
			}
			if (x.GetType() != y.GetType())
			{
				return false;
			}
			return x.ID == y.ID;
		}

		public int GetHashCode(GameDataObject obj)
		{
			return obj.ID;
		}
	}
}
