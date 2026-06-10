using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.WorldMap;

namespace NSMedieval.Manager
{
	public class FactionsController : MonoSingleton<FactionsController>, IObserver
	{
		private readonly HashSet<FactionInstance> traderFactionCantLeaveMap = new HashSet<FactionInstance>();

		private readonly HashSet<FactionInstance> prevTraderFactionCantLeaveMap = new HashSet<FactionInstance>();

		private int minutesInHour = 40;

		public event Action<FactionFriendliness, FactionInstance> FriendlinessChangedEvent;

		public event Action<float, FactionInstance> FriendlinessChangedByAmountEvent;

		public void OnFriendlinessChangedByAmount(float amount, FactionInstance factionInstance)
		{
			this.FriendlinessChangedByAmountEvent?.Invoke(amount, factionInstance);
		}

		public void OnFriendlinessChanged(FactionFriendliness friendlinessAfter, FactionInstance factionInstance)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(2, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\FactionsController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(factionInstance);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(friendlinessAfter);
			}
			Log.Debug(messageBuilder);
			this.FriendlinessChangedEvent?.Invoke(friendlinessAfter, factionInstance);
		}

		private void Start()
		{
			minutesInHour = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
			}
			base.OnDestroy();
		}

		private void OnTimeUpdate()
		{
			CheckTraderStuckRetreating();
		}

		private void OnDateUpdate()
		{
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated())
			{
				return;
			}
			foreach (FactionInstance factionInstance in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances)
			{
				factionInstance.TickFriendlinessDegradation();
			}
		}

		private void CheckTraderStuckRetreating()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
			{
				return;
			}
			prevTraderFactionCantLeaveMap.Clear();
			prevTraderFactionCantLeaveMap.UnionWith(traderFactionCantLeaveMap);
			traderFactionCantLeaveMap.Clear();
			foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
			{
				if (nPC?.Faction == null || nPC.HasDisposed || nPC.HasDied || nPC.IsRaider() || nPC.IsPrisoner() || (!nPC.CombatAi.IsStateSet(CombatAiState.EnemyIsRetreating) && !nPC.IsLeaving))
				{
					continue;
				}
				bool flag = nPC.CombatAi.IsStateSet(CombatAiState.StuckWhileRetreating);
				if (!flag)
				{
					foreach (AnimalInstance pet in nPC.Pets)
					{
						if (pet != null && !pet.HasDied && !pet.HasDisposed && pet.CombatAi != null && pet.CombatAi.IsStateSet(CombatAiState.AnimalRetreatingNoPathToTrader))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					traderFactionCantLeaveMap.Add(nPC.Faction);
				}
			}
			bool flag2 = prevTraderFactionCantLeaveMap.Count != traderFactionCantLeaveMap.Count;
			foreach (FactionInstance item in traderFactionCantLeaveMap)
			{
				if (!prevTraderFactionCantLeaveMap.Contains(item))
				{
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("message_trader_is_locked").Replace("<faction_name>", item.NameLocalized);
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
				}
				float valueToAdd = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings.FriendlinessChangePerHourOnLockedTrader / (float)minutesInHour;
				item.AddFriendliness(valueToAdd);
			}
			if (flag2)
			{
				MonoSingleton<GlobalWarningMessagesManager>.Instance.SetTraderCantLeaveMapMessageVisible(traderFactionCantLeaveMap.Count > 0);
			}
		}
	}
}
