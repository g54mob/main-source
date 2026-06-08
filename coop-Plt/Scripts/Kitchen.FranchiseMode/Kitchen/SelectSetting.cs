using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SelectSetting : ItemInteractionSystem
	{
		private CSettingSelector Selector;

		private EntityQuery HiddenSelectors;

		private EntityQuery VisibleSelectors;

		private EntityQuery SettingUpgrades;

		private NativeArray<CSettingUpgrade> Upgrades;

		protected override bool AllowActOrGrab => true;

		protected override void Initialise()
		{
			base.Initialise();
			SettingUpgrades = GetEntityQuery(typeof(CSettingUpgrade));
			HiddenSelectors = GetEntityQuery(new QueryHelper().All(typeof(CSettingSelector), typeof(CHideView)));
			VisibleSelectors = GetEntityQuery(new QueryHelper().All(typeof(CSettingSelector)).None(typeof(CHideView)));
		}

		protected override bool BeforeRun()
		{
			Upgrades = SettingUpgrades.ToComponentDataArray<CSettingUpgrade>(Allocator.Temp);
			bool num = Upgrades.Length > 1;
			if (num)
			{
				base.EntityManager.RemoveComponent<CHideView>(HiddenSelectors);
				return num;
			}
			base.EntityManager.AddComponent<CHideView>(VisibleSelectors);
			return num;
		}

		protected override void AfterRun()
		{
			Upgrades.Dispose();
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (TryGetFranchiseSetting(base.EntityManager, out var _))
			{
				return false;
			}
			return Require<CSettingSelector>(data.Target, out Selector);
		}

		protected override void Perform(ref InteractionData data)
		{
			int num = ((data.Attempt.Type == InteractionType.Act) ? 1 : (-1));
			NativeArray<CSettingUpgrade> settings = Upgrades;
			Season season = Seasons.GetSeason();
			List<RestaurantSetting> list = GameData.Main.Get<RestaurantSetting>().Where(delegate(RestaurantSetting s)
			{
				foreach (CSettingUpgrade item in settings)
				{
					if (item.SettingID == s.ID)
					{
						return true;
					}
				}
				return (s.FixedRunSeason != Season.Normal && s.FixedRunSeason == season) ? true : false;
			}).ToList();
			int num2 = -1;
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				if (list[num3].ID == Selector.SettingID)
				{
					num2 = num3;
					break;
				}
			}
			int index = (list.Count + num2 + num) % list.Count;
			Selector.SettingID = list[index].ID;
			SetComponent(data.Target, Selector);
			Set(default(HandleLayoutRequests.SLayoutRequest));
		}

		public static bool TryGetFranchiseSetting(EntityContext ctx, out int setting_id)
		{
			setting_id = 0;
			if (!ctx.Require<SFranchiseSelector>(out var comp))
			{
				return false;
			}
			if (!ctx.Require<CFranchiseItem>(comp.SelectedFranchise, out var comp2))
			{
				return false;
			}
			foreach (int card in comp2.Cards)
			{
				if (GameData.Main.TryGet<Unlock>(card, out var output) && output.ForceFranchiseSetting != null)
				{
					setting_id = output.ForceFranchiseSetting.ID;
					return true;
				}
			}
			return false;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
