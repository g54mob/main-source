using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;

namespace NSMedieval.AdditionalMenuItems
{
	public class TradeMenuItem : AdditionalMenuPrioritiseItem
	{
		private const string CannotTradeWithHostileTextKey = "cannot_trade_with_hostile";

		private const string CannotTalkLeavingTextKey = "cannot_negotiate_with_leaving_npc";

		private HumanoidInstance selectedHuman;

		public TradeMenuItem(IAdditionalMenuOwner owner, int invokeCount)
			: base(owner, JobType.None, canDoWhileDrafted: true)
		{
			selectedHuman = GetTraderNpc(owner, invokeCount);
			if (selectedHuman == null)
			{
				base.IsEnabled = false;
				return;
			}
			if (!selectedHuman.IsTrader())
			{
				base.IsEnabled = false;
				return;
			}
			if (selectedHuman.IsAtEvent())
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("general_trade_with").Replace("<trader_name>", selectedHuman.Info.GetFullName());
			if (selectedHuman.IsLeaving)
			{
				base.IsEnabled = false;
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cannot_negotiate_with_leaving_npc");
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null)
			{
				base.IsEnabled = false;
				return;
			}
			base.MenuTitle = selectedWorker.Info.FirstName + " (" + AdditionalMenuItemUtil.GenerateSkillInfo(SkillType.Speechcraft.ToString().ToLower(), selectedWorker.GetSkillLevel(SkillType.Speechcraft)) + ")";
			if (base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance)
			{
				TradingPostComponentInstance tradingPostComponentInstance = baseBuildingInstance?.GetComponentInstance<TradingPostComponentInstance>();
				if (tradingPostComponentInstance == null || tradingPostComponentInstance.HasDisposed)
				{
					base.IsEnabled = false;
					return;
				}
				if (tradingPostComponentInstance.Underwater)
				{
					base.IsEnabled = false;
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("structure_in_water");
					return;
				}
			}
			base.IsEnabled = true;
		}

		public override void Dispose()
		{
			base.Dispose();
			selectedHuman = null;
		}

		protected override void OnClickCallback()
		{
			if (selectedHuman == null || !selectedHuman.IsTrader())
			{
				base.OnClickCallback();
				return;
			}
			if (selectedHuman.IsLeaving)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_negotiate_with_leaving_npc"));
				base.OnClickCallback();
				return;
			}
			if (!selectedHuman.IsFriendlyFaction())
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_trade_with_hostile"));
				base.OnClickCallback();
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null || selectedWorker.HasDisposed)
			{
				base.OnClickCallback();
				return;
			}
			selectedWorker.WorkerBehaviour.ShowPathDestinationLine(selectedHuman.GetPosition());
			ForceGoal("TradeGoal", selectedHuman);
			base.OnClickCallback();
		}

		private HumanoidInstance GetTraderNpc(IAdditionalMenuOwner _, int indexToSelect)
		{
			if (base.Owner.GetAsTarget() is HumanoidInstance humanoidInstance && humanoidInstance.IsTrader())
			{
				return humanoidInstance;
			}
			TradingPostComponentInstance tradingPostComponentInstance = (base.Owner.GetAsTarget() as BaseBuildingInstance)?.GetComponentInstance<TradingPostComponentInstance>();
			if (tradingPostComponentInstance == null)
			{
				return null;
			}
			int num = 0;
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (item.IsTrader() && item.TraderBehaviour != null && item.TraderBehaviour.TradingPostComponentInstance == tradingPostComponentInstance)
				{
					if (num == indexToSelect)
					{
						return item;
					}
					num++;
				}
			}
			return base.Owner.GetAsTarget() as HumanoidInstance;
		}
	}
}
