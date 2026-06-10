using FoxyVoxel.Logging;
using Managers;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.TimeHelpers;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("RoleVisitorVisitPhase", "")]
	public class RoleVisitorVisitPhase : GameEventLinearPhaseBase, IVisitorDataHolder
	{
		private TimeInterval timeInterval;

		private bool shouldEndNextTick;

		private uint newsMessageId;

		private bool attackedByWorker;

		private const string fvs_timeInterval = "timeInterval";

		private const string fvs_shouldEndNextTick = "shouldEndNextTick";

		private const string fvs_newsMessageId = "newsMessageId";

		private IVisitorDataHolder ExternalDataHolder => base.EventInstance as IVisitorDataHolder;

		public HumanoidInstance Visitor => ExternalDataHolder.Visitor;

		public RoleVisitorVisitPhase()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
		}

		public override bool OnStart()
		{
			VerifyEventImplements<IVisitorDataHolder>();
			if (Visitor == null)
			{
				Log.Error("Failed to start RoleVisitorVisitPhase, this.Trader and this.Guards cannot be null", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\RoleVisitorVisitPhase.cs");
				return false;
			}
			int randomDurationMinutes = base.Blueprint.GetRandomDurationMinutes();
			timeInterval = TimeInterval.FromNowMinutes(randomDurationMinutes);
			attackedByWorker = false;
			Subscribe();
			GameEventUtil.PublishNews(base.EventInstance, 0);
			return true;
		}

		public override void OnLoaded(bool fromSave)
		{
			if (Visitor == null || Visitor.HasDisposed || Visitor.HasDied)
			{
				Log.Info("OnLoaded: Visitor is null, has been disposed or has died. Ending.", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\RoleVisitorVisitPhase.cs");
				shouldEndNextTick = true;
			}
			else if (Visitor.IsLeaving && Visitor.GetNode() == null)
			{
				Log.Info("OnLoaded: Visitor is leaving or Visitor.GetNode() == null. Ending.", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\RoleVisitorVisitPhase.cs");
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
			Log.Info("Visitor has become aggressive. Ending.", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\RoleVisitorVisitPhase.cs");
			shouldEndNextTick = true;
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (Visitor == take && deal is HumanoidInstance { WorkerBehaviour: not null })
			{
				attackedByWorker = true;
				Log.Info("Visitor was damaged by a worker. Ending.", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\RoleVisitorVisitPhase.cs");
				shouldEndNextTick = true;
			}
		}

		private void OnAgentKilled(IDamageDealAgent deal, IDamageTakingAgent take)
		{
			if (take is HumanoidInstance humanoidInstance && !humanoidInstance.IsEnemy() && Visitor == take)
			{
				HumanoidInstance humanoidInstance2 = deal as HumanoidInstance;
				long num = humanoidInstance.CombatAi.GetState<long>(CombatAiState.LastDamageTakenTime) - GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
				if (humanoidInstance2 != null && humanoidInstance2.WorkerBehaviour != null && num < 2)
				{
					attackedByWorker = true;
					Log.Info("Visitor was killed by a worker. Ending.", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\RoleVisitorVisitPhase.cs");
					shouldEndNextTick = true;
				}
			}
		}

		public override void OnEnd()
		{
			Unsubscribe();
			MonoSingleton<NewsManager>.Instance.Remove(newsMessageId);
			RetreatAll();
		}

		private void RetreatAll()
		{
			Log.Info("Retreating role visitors", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\RoleVisitorVisitPhase.cs");
			if (!Visitor.HasDied && !Visitor.HasDisposed)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("role_visitor_leaving").Replace("<faction_name>", Visitor.Faction?.NameLocalized ?? string.Empty).Replace("<role_name>", HumanoidRoleUtils.GetRoleNameWithIconAndLevel(Visitor.ActiveBehaviour.HumanoidRoleOwner.RoleInstance));
				if (!string.IsNullOrEmpty(text))
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
				}
				Visitor.RetreatFromMap();
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
			if (Visitor.IsAtEvent())
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
		}

		public RoleVisitorVisitPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			timeInterval = deserializer.ReadObject<TimeInterval>("timeInterval");
			shouldEndNextTick = deserializer.ReadBool("shouldEndNextTick");
			newsMessageId = deserializer.ReadUInt("newsMessageId");
		}
	}
}
