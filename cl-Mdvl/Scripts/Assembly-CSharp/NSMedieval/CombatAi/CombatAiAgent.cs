using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public abstract class CombatAiAgent : Agent
	{
		private const float CombatBaseTickInterval = 0.05f;

		private const float SensorsRefreshInterval = 0.95f;

		private const float ReactionRefreshInterval = 0.5f;

		private const float TargetSwitchCheckInterval = 0.15f;

		private const float ActiveGoalCheckInterval = 0.6f;

		private readonly string blueprintId;

		private readonly CombatAiAgentBlueprint blueprint;

		private readonly Hashtable state;

		private ulong isStateSet;

		private readonly List<CombatAiSensor> sensors;

		private readonly List<CombatAiReaction> reactions;

		private readonly ConcurrentHashSet<CombatAiReaction> reactionsToRemove;

		private readonly ThreadSequenceExecutor executor;

		private readonly CombatAiTargetSwitcherDefault autoTargetSwitcherDefault;

		private Timer sensorRefreshTimer;

		private Timer reactionRefreshTimer;

		private Timer targetSwitchCheckTimer;

		private Timer goalUpdateTimer;

		private float deltaAccumulator;

		public string BlueprintId => blueprintId;

		protected CombatAiAgentBlueprint Blueprint => blueprint;

		protected ThreadSequenceExecutor Executor => executor;

		protected CombatAiAgent(IGoapAgentOwner owner, string blueprintId)
			: this(owner, blueprintId, new CombatAiTargetSwitcherDefault())
		{
		}

		protected CombatAiAgent(IGoapAgentOwner owner, string blueprintId, CombatAiTargetSwitcherDefault targetSwitcherDefault)
			: base(owner)
		{
			this.blueprintId = blueprintId;
			blueprint = Repository<CombatAiAgentRepository, CombatAiAgentBlueprint>.Instance.GetByID(blueprintId);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Combat ai agent not found. ID: ");
					messageBuilder.AppendFormatted(blueprintId);
				}
				Log.Error(messageBuilder);
				return;
			}
			state = new Hashtable();
			sensors = new List<CombatAiSensor>();
			reactions = new List<CombatAiReaction>();
			executor = new ThreadSequenceExecutor();
			reactionsToRemove = new ConcurrentHashSet<CombatAiReaction>();
			autoTargetSwitcherDefault = targetSwitcherDefault;
			autoTargetSwitcherDefault.SetAgent(this);
			if (blueprint.IsAggressive)
			{
				SetState(CombatAiState.IsAggressive, true);
			}
			LoadBlueprint();
			if (!owner.IsInIncognitoMode())
			{
				Enable();
			}
		}

		public override void Dispose()
		{
			if (base.HasDisposed)
			{
				return;
			}
			foreach (CombatAiSensor sensor in sensors)
			{
				sensor.Dispose();
			}
			foreach (CombatAiReaction reaction in reactions)
			{
				reaction?.Dispose();
			}
			foreach (CombatAiReaction item in reactionsToRemove)
			{
				item?.Dispose();
			}
			AbortTimers();
			reactions.Clear();
			reactionsToRemove.Clear();
			executor.Abort();
			sensors.Clear();
			state.Clear();
			isStateSet = 0uL;
			autoTargetSwitcherDefault.Dispose();
			base.Dispose();
			sensorRefreshTimer?.Dispose();
			sensorRefreshTimer = null;
			reactionRefreshTimer?.Dispose();
			reactionRefreshTimer = null;
			targetSwitchCheckTimer?.Dispose();
			targetSwitchCheckTimer = null;
			goalUpdateTimer?.Dispose();
			goalUpdateTimer = null;
			Unsubscribe();
		}

		public virtual void Enable()
		{
			bool isEnabled;
			if (base.AgentOwner.IsInIncognitoMode())
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(134, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to Enable CombatAiAgent '");
					messageBuilder.AppendFormatted(BlueprintId);
					messageBuilder.AppendLiteral("' for creature that is in incognito mode. Combat AI is not intended to tick while incognito. Creature: ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				if (base.IsTickActive)
				{
					return;
				}
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(27, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Enable '");
					messageBuilder2.AppendFormatted(blueprintId);
					messageBuilder2.AppendLiteral("' for ");
					messageBuilder2.AppendFormatted(base.AgentOwner);
					messageBuilder2.AppendLiteral(", combatAi (");
					messageBuilder2.AppendFormatted(GetHashCode());
					messageBuilder2.AppendLiteral(")");
				}
				Log.Info(messageBuilder2);
				Abort();
				InitTimers();
				Subscribe();
				StartTicker();
				foreach (CombatAiSensor sensor in sensors)
				{
					sensor?.OnEnable();
				}
				foreach (CombatAiReaction reaction in reactions)
				{
					reaction?.OnEnable();
				}
			}
		}

		public virtual void Disable()
		{
			if (!base.IsTickActive)
			{
				return;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(15, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Disable '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("' for ");
				messageBuilder.AppendFormatted(base.AgentOwner);
			}
			Log.Info(messageBuilder);
			StopTicker();
			Abort();
			AbortTimers();
			Unsubscribe();
			ResetSensorState();
			foreach (CombatAiSensor sensor in sensors)
			{
				sensor?.OnDisable();
			}
			foreach (CombatAiReaction reaction in reactions)
			{
				reaction?.OnDisable();
			}
		}

		private void ResetSensorState()
		{
			foreach (CombatAiSensor sensor in sensors)
			{
				if (sensor != null && !sensor.HasDisposed)
				{
					sensor.InitStates();
				}
			}
		}

		public T GetState<T>(CombatAiState stateType)
		{
			if ((isStateSet & (ulong)(1L << (int)stateType)) == 0L)
			{
				return default(T);
			}
			if (!state.ContainsKey(stateType))
			{
				return default(T);
			}
			if (!(state[stateType] is T))
			{
				return default(T);
			}
			return (T)state[stateType];
		}

		internal bool IsStateSet(CombatAiState stateType)
		{
			return (isStateSet & (ulong)(1L << (int)stateType)) != 0;
		}

		public bool TryGetState<T>(CombatAiState stateType, out T value)
		{
			if ((isStateSet & (ulong)(1L << (int)stateType)) == 0L)
			{
				value = default(T);
				return false;
			}
			if (!state.ContainsKey(stateType))
			{
				value = default(T);
				return false;
			}
			value = (T)state[stateType];
			return value != null;
		}

		internal void SetState(CombatAiState stateType, object obj)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("(");
				messageBuilder.AppendFormatted(GetHashCode());
				messageBuilder.AppendLiteral(") SetState ");
				messageBuilder.AppendFormatted(stateType);
				messageBuilder.AppendLiteral(" = '");
				messageBuilder.AppendFormatted(obj);
				messageBuilder.AppendLiteral("', agent '");
				messageBuilder.AppendFormatted(base.AgentOwner);
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			if (obj == null || (obj is bool && !(bool)obj))
			{
				if (state.ContainsKey(stateType))
				{
					isStateSet &= (ulong)(~(1L << (int)stateType));
					object oldObject = state[stateType];
					state.Remove(stateType);
					ExecuteReactionStateChangeCallback(stateType, oldObject, null);
				}
			}
			else
			{
				isStateSet |= (ulong)(1L << (int)stateType);
				object oldObject2 = (state.ContainsKey(stateType) ? state[stateType] : null);
				state[stateType] = obj;
				ExecuteReactionStateChangeCallback(stateType, oldObject2, obj);
			}
		}

		internal override void OnGoalEnded(Goal goal, GoalCondition condition)
		{
			DelayNextTick(0f);
			if (condition != GoalCondition.Succeeded)
			{
				DelayNextTick(0.5f);
			}
			if (GetCurrentGoal() != null)
			{
				MonoSingleton<GoapController>.Instance.OnGoalEnded(this, base.CurrentGoalName, condition);
			}
		}

		internal void RemoveReaction(CombatAiReaction reaction)
		{
			reactionsToRemove.Add(reaction);
		}

		internal void ForceRefreshSensors()
		{
			if (sensorRefreshTimer != null)
			{
				sensorRefreshTimer.RestartTimer();
				SensorRefreshTick();
			}
		}

		internal void ForceRefreshReactions()
		{
			if (reactionRefreshTimer != null)
			{
				reactionRefreshTimer.RestartTimer();
				ReactionRefreshTick();
			}
		}

		protected void AddSensor(CombatAiSensor sensor)
		{
			if (sensors.Any((CombatAiSensor item) => item.GetType() == sensor.GetType()))
			{
				Log.Error("Tried to add same sensor multiple times.", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
				return;
			}
			sensor.InitStates();
			sensors.Add(sensor);
		}

		protected void AddReaction(CombatAiReaction reaction)
		{
			if (reactions.Any((CombatAiReaction item) => item.GetType() == reaction.GetType()))
			{
				Log.Error("Tried to add same reaction multiple times.", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
			}
			else
			{
				reactions.Add(reaction);
			}
		}

		protected virtual void PreferredTargetUpdated(IDamageDealAgent deal, IDamageTakingAgent newTarget, IDamageTakingAgent oldTarget)
		{
			if (deal == base.AgentOwner)
			{
				for (int i = 0; i < sensors.Count; i++)
				{
					sensors[i].PreferredTargetUpdated(deal, newTarget, oldTarget);
				}
				if (newTarget == null)
				{
					(base.AgentOwner as IDamageDealAgent)?.SetTarget(null);
				}
			}
		}

		public override void Tick(float deltaTime)
		{
			if (!base.IsTickActive || base.AgentOwner == null || base.AgentOwner.HasDisposed)
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("CombatAiAgent.Tick"))
			{
				foreach (CombatAiReaction item in reactionsToRemove)
				{
					item?.Dispose();
				}
				bool flag = base.AgentOwner is HumanoidInstance { ActiveBehaviour: EnemyBehaviour activeBehaviour } && activeBehaviour.CurrentOrder != null;
				for (int i = 0; i < reactions.Count; i++)
				{
					CombatAiReaction combatAiReaction = reactions[i];
					if (!flag || combatAiReaction.ShouldWorkWhileEnemyAssignedToCommander)
					{
						combatAiReaction?.SceneControllerTick();
					}
				}
				reactionsToRemove.Clear();
				deltaAccumulator += deltaTime;
				if (deltaAccumulator <= 0.05f)
				{
					return;
				}
				for (int j = 0; j < reactions.Count; j++)
				{
					CombatAiReaction combatAiReaction2 = reactions[j];
					if (!flag || combatAiReaction2.ShouldWorkWhileEnemyAssignedToCommander)
					{
						combatAiReaction2?.CombatTick();
					}
				}
				base.Tick(deltaAccumulator);
				deltaAccumulator = 0f;
			}
		}

		private void Subscribe()
		{
			MonoSingleton<CombatController>.Instance.PreferedTargetUpdateEvent += PreferredTargetUpdated;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
			MonoSingleton<CombatController>.Instance.HitBlockedEvent += OnHitBlocked;
			MonoSingleton<CombatController>.Instance.HitMissedEvent += OnHitMissed;
			MonoSingleton<CombatController>.Instance.DamageAgentRemovedEvent += OnDamageAgentRemoved;
			MonoSingleton<LifeController>.Instance.OnFaintEvent += OnFainted;
			MonoSingleton<LifeController>.Instance.WakeUpEvent += OnWokeUp;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.PreferedTargetUpdateEvent -= PreferredTargetUpdated;
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnDamageTaken;
				MonoSingleton<CombatController>.Instance.HitBlockedEvent -= OnHitBlocked;
				MonoSingleton<CombatController>.Instance.HitMissedEvent -= OnHitMissed;
				MonoSingleton<CombatController>.Instance.DamageAgentRemovedEvent -= OnDamageAgentRemoved;
			}
			if (MonoSingleton<LifeController>.IsInstantiated())
			{
				MonoSingleton<LifeController>.Instance.OnFaintEvent -= OnFainted;
				MonoSingleton<LifeController>.Instance.WakeUpEvent -= OnWokeUp;
			}
		}

		private void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType missType)
		{
			for (int i = 0; i < sensors.Count; i++)
			{
				sensors[i].OnHitMissed(deal, take, missType);
			}
			for (int j = 0; j < reactions.Count; j++)
			{
				reactions[j].OnHitMissed(deal, take, missType);
			}
		}

		private void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			for (int i = 0; i < sensors.Count; i++)
			{
				sensors[i].OnHitBlocked(deal, take, hitInfo);
			}
			for (int j = 0; j < reactions.Count; j++)
			{
				reactions[j].OnHitBlocked(deal, take, hitInfo);
			}
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			for (int i = 0; i < sensors.Count; i++)
			{
				sensors[i].OnDamageTaken(deal, take, hitInfo);
			}
			for (int j = 0; j < reactions.Count; j++)
			{
				reactions[j].OnDamageTaken(deal, take, hitInfo);
			}
		}

		private void OnWokeUp(StatsInstance stats)
		{
			for (int i = 0; i < sensors.Count; i++)
			{
				sensors[i].OnWokeUp(stats);
			}
		}

		private void OnFainted(StatsInstance stats)
		{
			for (int i = 0; i < sensors.Count; i++)
			{
				sensors[i].OnFainted(stats);
			}
		}

		private void OnDamageAgentRemoved(IDamageCommonAgent agent)
		{
			for (int i = 0; i < sensors.Count; i++)
			{
				sensors[i].OnDamageAgentRemoved(agent);
			}
		}

		private void InitTimers()
		{
			AbortTimers();
			sensorRefreshTimer = new Timer(0.95f + Random.value / 2f);
			sensorRefreshTimer.SetRestartOnEnd(value: true);
			sensorRefreshTimer.AddCallback(SensorRefreshTick);
			reactionRefreshTimer = new Timer(0.5f + Random.value / 2f);
			reactionRefreshTimer.SetRestartOnEnd(value: true);
			reactionRefreshTimer.AddCallback(ReactionRefreshTick);
			targetSwitchCheckTimer = new Timer(0.15f);
			targetSwitchCheckTimer.SetRestartOnEnd(value: true);
			targetSwitchCheckTimer.AddCallback(AutoSwitchTargetTick);
			goalUpdateTimer = new Timer(0.6f + Random.value / 2f);
			goalUpdateTimer.SetRestartOnEnd(value: true);
			goalUpdateTimer.AddCallback(ActiveGoalUpdateTick);
		}

		private void AbortTimers()
		{
			reactionRefreshTimer?.Dispose();
			reactionRefreshTimer = null;
			sensorRefreshTimer?.Dispose();
			sensorRefreshTimer = null;
			targetSwitchCheckTimer?.Dispose();
			targetSwitchCheckTimer = null;
			goalUpdateTimer?.Dispose();
			goalUpdateTimer = null;
		}

		private void SensorRefreshTick()
		{
			using (ProfilerSampleJanitor.Begin("SensorRefreshTick"))
			{
				foreach (CombatAiSensor item in sensors.IterateInReverseDynamic())
				{
					item.Refresh();
				}
			}
		}

		private void ReactionRefreshTick()
		{
			using (ProfilerSampleJanitor.Begin("ReactionRefreshTick"))
			{
				bool flag = base.AgentOwner is HumanoidInstance { ActiveBehaviour: EnemyBehaviour activeBehaviour } && activeBehaviour.CurrentOrder != null;
				foreach (CombatAiReaction item in reactions.IterateInReverseDynamic())
				{
					if (!flag || item.ShouldWorkWhileEnemyAssignedToCommander)
					{
						item.Refresh();
					}
				}
			}
		}

		private void AutoSwitchTargetTick()
		{
			using (ProfilerSampleJanitor.Begin("AutoSwitchTargetTick"))
			{
				if (!Executor.IsSequenceExecuting && (IsStateSet(CombatAiState.NextTarget) || IsStateSet(CombatAiState.NextTargetValidated)))
				{
					autoTargetSwitcherDefault.DoProcessing();
				}
			}
		}

		private void ActiveGoalUpdateTick()
		{
			if (GetCurrentGoal() is CombatAiGoal { State: GoalState.Running } combatAiGoal)
			{
				if (!combatAiGoal.CanStart())
				{
					Abort();
				}
				else
				{
					combatAiGoal.Update();
				}
			}
		}

		private void ExecuteReactionStateChangeCallback(CombatAiState state, object oldObject, object newObject)
		{
			foreach (CombatAiReaction reaction in reactions)
			{
				reaction.OnAgentStateChanges(state, oldObject, newObject);
			}
		}

		private void LoadBlueprint()
		{
			bool isEnabled;
			string[] goals;
			if (blueprint.Goals != null)
			{
				goals = blueprint.Goals;
				foreach (string text in goals)
				{
					if (!CombatAiConstructorMap.Goals.ContainsKey(text))
					{
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("AI Goal '");
							messageBuilder.AppendFormatted(text);
							messageBuilder.AppendLiteral("' exists in scheduled data but not found in code!");
						}
						Log.Warning(messageBuilder);
					}
					else
					{
						Goal goal = (Goal)CombatAiConstructorMap.Goals[text].Invoke(new object[1] { this });
						base.GoalScheduler.AddToPool(goal, enableGoal: true);
					}
				}
			}
			if (blueprint.Sensors != null)
			{
				goals = blueprint.Sensors;
				foreach (string text2 in goals)
				{
					if (!CombatAiConstructorMap.Sensors.ContainsKey(text2))
					{
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("AI Sensor '");
							messageBuilder.AppendFormatted(text2);
							messageBuilder.AppendLiteral("' exists in scheduled data but not found in code!");
						}
						Log.Warning(messageBuilder);
					}
					else
					{
						CombatAiSensor sensor = (CombatAiSensor)CombatAiConstructorMap.Sensors[text2].Invoke(new object[1] { this });
						AddSensor(sensor);
					}
				}
			}
			if (blueprint.Reactions == null)
			{
				return;
			}
			goals = blueprint.Reactions;
			foreach (string text3 in goals)
			{
				if (!CombatAiConstructorMap.Reactions.ContainsKey(text3))
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Agent\\CombatAiAgent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("AI Reaction '");
						messageBuilder.AppendFormatted(text3);
						messageBuilder.AppendLiteral("' exists in scheduled data but not found in code!");
					}
					Log.Warning(messageBuilder);
				}
				else
				{
					CombatAiReaction reaction = (CombatAiReaction)CombatAiConstructorMap.Reactions[text3].Invoke(new object[1] { this });
					AddReaction(reaction);
				}
			}
		}
	}
}
