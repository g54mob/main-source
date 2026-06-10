using System;
using System.Collections.Generic;
using System.Linq;
using Managers;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Utils.TimeHelpers;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("TraderVisitPhase", "")]
	public class TraderVisitPhase : GameEventLinearPhaseBase
	{
		[SerializeField]
		private TimeInterval timeInterval;

		[SerializeField]
		private bool shouldEndNextTick;

		[SerializeField]
		private uint newsMessageId;

		private bool attackedByWorker;

		private Action onStartCallback;

		private bool skipRetreat;

		private const string fvs_timeInterval = "timeInterval";

		private const string fvs_shouldEndNextTick = "shouldEndNextTick";

		private const string fvs_newsMessageId = "newsMessageId";

		private ITraderPhaseDataHolder ExternalDataHolder => base.EventInstance as ITraderPhaseDataHolder;

		private HumanoidInstance Trader => ExternalDataHolder.Trader;

		private List<HumanoidInstance> Guards => ExternalDataHolder.Guards;

		public TraderVisitPhase()
		{
		}

		public TraderVisitPhase(bool skipRetreat)
		{
			this.skipRetreat = skipRetreat;
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
			onStartCallback = null;
		}

		public override bool OnStart()
		{
			onStartCallback?.Invoke();
			onStartCallback = null;
			VerifyEventImplements<ITraderPhaseDataHolder>();
			if (Trader == null || Guards == null)
			{
				GameEventPhaseBase.Logger.Error("Failed to start TraderVisitPhase, this.Trader and this.Guards cannot be null");
				return false;
			}
			int randomDurationMinutes = base.Blueprint.GetRandomDurationMinutes();
			timeInterval = TimeInterval.FromNowMinutes(randomDurationMinutes);
			attackedByWorker = false;
			Subscribe();
			if (!(base.EventInstance is MultiTraderEvent))
			{
				GameEventUtil.PublishNews(base.EventInstance, 0);
			}
			return true;
		}

		public override void OnLoaded(bool fromSave)
		{
			if (Trader == null || Trader.HasDisposed || Trader.HasDied)
			{
				GameEventPhaseBase.Logger.Info("OnLoaded: Trader is null, has been disposed or has died. Ending.");
				shouldEndNextTick = true;
			}
			else if (Trader.IsLeaving && Trader.GetNode() == null)
			{
				GameEventPhaseBase.Logger.Info("OnLoaded: Trader is leaving or Trader.GetNode() == null. Ending.");
				shouldEndNextTick = true;
			}
			else
			{
				Subscribe();
			}
		}

		private void Subscribe()
		{
			MonoSingleton<NPCController>.Instance.OnNPCBecomeAggressive += OnNpcBecomeAggressive;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
			MonoSingleton<CombatController>.Instance.OnAgentKilledEvent += OnAgentKilled;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCBecomeAggressive -= OnNpcBecomeAggressive;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnDamageTaken;
				MonoSingleton<CombatController>.Instance.OnAgentKilledEvent -= OnAgentKilled;
			}
		}

		private void OnNpcBecomeAggressive(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance == Trader && Guards.Contains(humanoidInstance))
			{
				GameEventPhaseBase.Logger.Info("Trader has become aggressive. Ending.");
				shouldEndNextTick = true;
			}
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if ((Trader == take || !Guards.All((HumanoidInstance guard) => guard != take)) && deal is HumanoidInstance { WorkerBehaviour: not null })
			{
				attackedByWorker = true;
				GameEventPhaseBase.Logger.Info("Trader or guard was damaged by a humanoid. Ending.");
				shouldEndNextTick = true;
			}
		}

		private void OnAgentKilled(IDamageDealAgent deal, IDamageTakingAgent take)
		{
			if (take is HumanoidInstance humanoidInstance && (Trader == take || !Guards.All((HumanoidInstance guard) => guard != take)))
			{
				HumanoidInstance obj = deal as HumanoidInstance;
				long num = humanoidInstance.CombatAi.GetState<long>(CombatAiState.LastDamageTakenTime) - GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
				if (obj != null && num < 2)
				{
					attackedByWorker = true;
					GameEventPhaseBase.Logger.Info("Trader or guard was killed by a worker. Ending.");
					shouldEndNextTick = true;
				}
			}
		}

		public override void OnEnd()
		{
			Unsubscribe();
			MonoSingleton<NewsManager>.Instance.Remove(newsMessageId);
			if (Trader.Faction != null && !Trader.Faction.IsHostile())
			{
				RetreatAll();
			}
		}

		private void RetreatAll()
		{
			if (skipRetreat)
			{
				return;
			}
			GameEventPhaseBase.Logger.Info("Retreating trader and guards");
			if (!Trader.HasDied && !Trader.HasDisposed)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("trader_leaving").Replace("<faction_name>", Trader.Faction?.NameLocalized ?? string.Empty);
				if (!string.IsNullOrEmpty(text))
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
				}
				Trader.RetreatFromMap();
			}
			foreach (HumanoidInstance guard in Guards)
			{
				if (!guard.HasDied && !guard.HasDisposed)
				{
					guard.RetreatFromMap();
				}
			}
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.PrisonerBehaviour != null && npc.PrisonerBehaviour.Owner == Trader))
			{
				if (!item.HasDied && !item.HasDisposed)
				{
					item.RetreatFromMap();
				}
			}
		}

		protected override bool TickShouldEnd()
		{
			if (attackedByWorker)
			{
				if (!timeInterval.HasEnded)
				{
					return shouldEndNextTick;
				}
				return true;
			}
			if (Trader.IsAtEvent() || Guards.Any((HumanoidInstance guard) => guard.IsAtEvent()))
			{
				return false;
			}
			if (!timeInterval.HasEnded)
			{
				return shouldEndNextTick;
			}
			return true;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("timeInterval", timeInterval);
			serializer.Write("shouldEndNextTick", shouldEndNextTick);
			serializer.Write("newsMessageId", newsMessageId);
			serializer.Write("skipRetreat", skipRetreat);
		}

		public TraderVisitPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			timeInterval = deserializer.ReadObject<TimeInterval>("timeInterval");
			shouldEndNextTick = deserializer.ReadBool("shouldEndNextTick");
			newsMessageId = deserializer.ReadUInt("newsMessageId");
			skipRetreat = deserializer.ReadBool("skipRetreat");
		}
	}
}
