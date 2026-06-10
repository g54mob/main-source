using System.Collections.Generic;
using System.Linq;
using NSMedieval;
using NSMedieval.CombatAi;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Tutorial;
using UnityEngine;

public class FaceHostileInPerceptionAiReaction : CombatAiReaction
{
	private const int FocusSwitchHysteresisCooldownMinutes = 5;

	private const float MaxFaceAttackerDistance = 30f;

	private IDamageCommonAgent focusingOnEnemy;

	private long lastFocusSwitchMinutes;

	private long CurrentTimeMinutes
	{
		get
		{
			if (!TutorialManager.IsTutorialActive)
			{
				return GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
			}
			return WorldTimeManager.UnityTimeLong;
		}
	}

	public FaceHostileInPerceptionAiReaction(CombatAiAgent agent)
		: base(agent)
	{
	}

	public override void Dispose()
	{
		base.Dispose();
		focusingOnEnemy = null;
	}

	public override void OnEnable()
	{
		focusingOnEnemy = null;
		lastFocusSwitchMinutes = 0L;
	}

	public override void SceneControllerTick()
	{
		if (!base.CombatAgent.HasView)
		{
			return;
		}
		using (ProfilerSampleJanitor.Begin("FaceHostileInPerceptionAiReaction.Tick"))
		{
			IDamageCommonAgent damageCommonAgent = FindEnemyToFocus();
			if (damageCommonAgent == null)
			{
				focusingOnEnemy = null;
				return;
			}
			if (damageCommonAgent != focusingOnEnemy && CurrentTimeMinutes - lastFocusSwitchMinutes > 5)
			{
				focusingOnEnemy = damageCommonAgent;
				lastFocusSwitchMinutes = CurrentTimeMinutes;
			}
			IDamageCommonAgent damageCommonAgent2 = focusingOnEnemy;
			if (damageCommonAgent2 != null && damageCommonAgent2.HasDisposed)
			{
				focusingOnEnemy = null;
			}
			if (focusingOnEnemy == null)
			{
				return;
			}
			Vector3 position = focusingOnEnemy.GetPosition();
			Vector3 position2 = base.CombatAgent.GetPosition();
			position.y = position2.y;
			Vector3 normalized = (position - position2).normalized;
			if (!(normalized == Vector3.zero))
			{
				Quaternion quaternion = Quaternion.LookRotation(normalized);
				if (!(Quaternion.Angle(quaternion, base.CombatAgent.GetTransform().rotation) < 0.1f))
				{
					(base.CombatAgent as CreatureBase).UpdateRotation(quaternion);
				}
			}
		}
	}

	private IDamageCommonAgent FindEnemyToFocus()
	{
		if (base.CombatAgent.GetTarget() != null || base.CombatAgent.HasActivePath)
		{
			return null;
		}
		(IDamageDealAgent lastAggressor, long timeMinutes) lastAggressor = GetLastAggressor();
		IDamageDealAgent item = lastAggressor.lastAggressor;
		long item2 = lastAggressor.timeMinutes;
		IDamageTakingAgent state = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.LastAttackedTarget);
		long state2 = base.CombatAi.GetState<long>(CombatAiState.LastAttackTime);
		IDamageCommonAgent damageCommonAgent = null;
		if (item == null && state != null)
		{
			damageCommonAgent = state;
		}
		if (item != null && state == null)
		{
			damageCommonAgent = item;
		}
		if (item != null && state != null)
		{
			IDamageCommonAgent damageCommonAgent3;
			if (state2 <= item2)
			{
				IDamageCommonAgent damageCommonAgent2 = item;
				damageCommonAgent3 = damageCommonAgent2;
			}
			else
			{
				IDamageCommonAgent damageCommonAgent2 = state;
				damageCommonAgent3 = damageCommonAgent2;
			}
			damageCommonAgent = damageCommonAgent3;
		}
		if (damageCommonAgent == null)
		{
			HashSet<IDamageDealAgent> state3 = base.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles);
			if (state3 != null)
			{
				damageCommonAgent = state3.FirstOrDefault();
			}
		}
		if (damageCommonAgent == null || damageCommonAgent.HasDisposed)
		{
			return null;
		}
		Vector3 position = base.CombatAgent.GetPosition();
		Vector3 position2 = damageCommonAgent.GetPosition();
		float num = Vector3.Distance(position, position2);
		if (num < 0.01f || num > 30f)
		{
			return null;
		}
		return damageCommonAgent;
	}

	private (IDamageDealAgent lastAggressor, long timeMinutes) GetLastAggressor()
	{
		(CombatAiState, CombatAiState)[] array = new(CombatAiState, CombatAiState)[3]
		{
			(CombatAiState.LastDamageTakenFrom, CombatAiState.LastDamageTakenTime),
			(CombatAiState.LastBlockTime, CombatAiState.LastBlockTime),
			(CombatAiState.LastMissTime, CombatAiState.LastMissTime)
		};
		for (int i = 0; i < array.Length; i++)
		{
			(CombatAiState, CombatAiState) tuple = array[i];
			CombatAiState item = tuple.Item1;
			CombatAiState item2 = tuple.Item2;
			IDamageDealAgent state = base.CombatAi.GetState<IDamageDealAgent>(item);
			if (state != null && !state.HasDied && !state.HasDisposed)
			{
				long state2 = base.CombatAi.GetState<long>(item2);
				return (lastAggressor: state, timeMinutes: state2);
			}
		}
		return default((IDamageDealAgent, long));
	}
}
