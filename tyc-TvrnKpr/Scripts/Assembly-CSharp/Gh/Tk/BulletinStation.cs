using UnityEngine;

namespace Gh.Tk
{
	public class BulletinStation : BulletinBoard
	{
		protected override GameObject GetPaperPrefabForPosition(int position)
		{
			return null;
		}

		public override int GetRandomPostPosition()
		{
			return 0;
		}
	}
}
