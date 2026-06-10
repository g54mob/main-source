using System;
using NSMedieval.Model;
using NSMedieval.State;

namespace NSMedieval
{
	[Serializable]
	public class NPCBodyPreview : HumanoidBodyPreview
	{
		private HumanoidInstance Instance => base.HumanoidInstance;

		public override void Setup(CreatureBase npcInstance)
		{
			base.HumanoidInstance = (HumanoidInstance)npcInstance;
			base.AppearanceId = ((HumanoidInstance)npcInstance).CurrentHumanType.AppearanceID;
		}

		public override FactionInstance GetFaction()
		{
			return Instance?.Faction;
		}

		public override CharacterInfoBase GetInfo()
		{
			return Instance.Info;
		}

		protected override InventoryInstance GetInventory()
		{
			return Instance.Inventory;
		}

		protected override void GenerateWeaponObject(Equipment item, FactionInstance factionInstance = null)
		{
			base.GenerateWeaponObject(item, Instance.Faction);
			ShowWeapons();
		}
	}
}
