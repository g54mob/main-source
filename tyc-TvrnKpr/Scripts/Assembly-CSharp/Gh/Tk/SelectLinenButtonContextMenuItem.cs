using UnityEngine;

namespace Gh.Tk
{
	public class SelectLinenButtonContextMenuItem : SelectionButtonContextMenuItem
	{
		private Room _room;

		private GameItemTemplate _linen;

		public SelectLinenButtonContextMenuItem(Room room, GameItemTemplate linen)
			: base(null, null, null, null, null, null, null)
		{
		}

		public override GameObject CreateGameObject(Transform where)
		{
			return null;
		}
	}
}
