using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(1)]
	public class AlcoholLevel : CTSBehaviour
	{
		public enum EState
		{
			Sober = 0,
			Tipsy = 1,
			Drunk = 2
		}

		private Agent _agentRef;

		private NumericStatistic _alcoholLevel;

		[SerializeField]
		[Range(0f, 1f)]
		private float _tipsinessThreshold = 0.25f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _drunknessThreshold = 0.5f;

		private Addressable<PrestigeUIStatsSO> _humanBecameDrunkStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/DrunkHumans.asset");

		private Addressable<PrestigeUIStatsSO> _vampireBecameDrunkStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/DrunkVampires.asset");

		public EState CurrentState { get; private set; }

		public event Action BecameDrunk;

		public event Action BecameSober;

		protected override void OnAwake()
		{
			_agentRef = GetComponent<Agent>();
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CurrentState = EState.Sober;
			if (_agentRef.Statistics.TryGetNumericStatistic(EAgentStatistics.Alcohol, out _alcoholLevel))
			{
				_alcoholLevel.ValueChanged += OnNeedChanged;
				UpdateAlcoholNeed(_alcoholLevel.Value);
			}
		}

		private bool SetState(EState state)
		{
			if (CurrentState == state)
			{
				return false;
			}
			switch (state)
			{
			case EState.Sober:
				if (CurrentState != EState.Sober)
				{
					this.BecameSober?.Invoke();
				}
				break;
			case EState.Tipsy:
			case EState.Drunk:
				if (CurrentState == EState.Sober)
				{
					this.BecameDrunk?.Invoke();
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
			}
			CurrentState = state;
			return true;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (_alcoholLevel != null)
			{
				_alcoholLevel.ValueChanged -= OnNeedChanged;
			}
		}

		private void OnNeedChanged(float p_newValue)
		{
			if (UpdateAlcoholNeed(p_newValue) && CurrentState == EState.Drunk && !_agentRef.TryGetComponent<Wanderer>(out var _))
			{
				if (_agentRef.IsHuman)
				{
					_humanBecameDrunkStat.Value.AddToCurrentValue(1);
				}
				else
				{
					_vampireBecameDrunkStat.Value.AddToCurrentValue(1);
				}
			}
		}

		private bool UpdateAlcoholNeed(float p_newValue)
		{
			bool flag = false;
			if (!(_alcoholLevel.UnitInterval >= _drunknessThreshold))
			{
				flag = ((!(_alcoholLevel.UnitInterval >= _tipsinessThreshold)) ? SetState(EState.Sober) : SetState(EState.Tipsy));
			}
			else
			{
				flag = SetState(EState.Drunk);
				if (_alcoholLevel.UnitInterval >= 1f && !_agentRef.ActionPlayer.HasAnyActionOfType<AgentActionPassOut>())
				{
					_agentRef.ActionPlayer.PlayInstantly(new AgentActionPassOut());
				}
			}
			return flag;
		}
	}
}
