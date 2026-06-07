using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class WeaponPresetData
	{
		public string UniqueId { get; set; }

		public string Name { get; set; }

		public string AmmunitionId { get; set; }

		public string EmitterId { get; set; }

		public int StackSize { get; set; }

		public List<string> Upgrades { get; set; }

		public int UpgradeSlots { get; set; }
	}
}
