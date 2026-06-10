using System;
using NSMedieval.Model;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class WorkerBodyPreview : HumanoidBodyPreview
	{
		[SerializeField]
		private Transform basket;

		[SerializeField]
		private Transform caravanBasket;

		[SerializeField]
		private Transform foodPouch;

		[SerializeField]
		private Transform medicinePouch;

		public HumanoidInstance Instance => base.HumanoidInstance;

		public Transform Basket => basket;

		public Transform CaravanBasket => caravanBasket;

		public override void Setup(CreatureBase workerInstance)
		{
			base.HumanoidInstance = (HumanoidInstance)workerInstance;
			base.AppearanceId = ((HumanoidInstance)workerInstance).CurrentHumanType.AppearanceID;
		}

		public override FactionInstance GetFaction()
		{
			return null;
		}

		public override CharacterInfoBase GetInfo()
		{
			return Instance.Info;
		}

		public void SetFoodPouchEnabled(bool enabled)
		{
			if (!(foodPouch == null))
			{
				foodPouch.gameObject.SetActive(enabled);
			}
		}

		public void SetMedicinePouchEnabled(bool enabled)
		{
			if (!(medicinePouch == null))
			{
				medicinePouch.gameObject.SetActive(enabled);
			}
		}

		protected override InventoryInstance GetInventory()
		{
			return Instance.Inventory;
		}

		protected override void GenerateWeaponObject(Equipment item, FactionInstance factionInstance = null)
		{
			base.GenerateWeaponObject(item);
			WorkerBehaviour workerBehaviour = Instance.WorkerBehaviour;
			if (workerBehaviour != null && workerBehaviour.IsDrafting)
			{
				ShowWeapons();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			base.HumanoidInstance = null;
		}
	}
}
