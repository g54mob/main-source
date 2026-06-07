using System;

namespace Gh.Tk
{
	public class FireFightingGearStand : Larder_Tile
	{
		public override void PostBuiltInit()
		{
		}

		private void OnInventoryChanged(object sender, EventArgs e)
		{
		}

		public override bool CanBeDamaged()
		{
			return false;
		}
	}
}
