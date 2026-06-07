using System;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS
{
	public class UnitHealth : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private AgentStatistics _agentStatistics;

		private NumericStatistic _healthStat;

		private const string _obsoleteMessage = "Due to a change in the game design of the game, Agents won't take damage anymore, and will just die. Please refer to GDDs and use public methods 'ResetHealth' and 'ForceDeath'.";

		public int MaxHealth => (int)GetHealthStat().Max;

		[field: SerializeField]
		[field: Range(0f, 1f)]
		public float InjuredThreshold { get; private set; } = 0.75f;

		[field: SerializeField]
		[field: Range(0f, 1f)]
		public float CriticalThreshold { get; private set; } = 0.15f;

		[field: SerializeField]
		[field: Range(0f, 1f)]
		public float BaseInjurySurvivabilityChance { get; private set; } = 0.6f;

		public EHealthState HealthState { get; private set; }

		public int CurrentHealth
		{
			get
			{
				return GetHealthStat().IntValue;
			}
			private set
			{
				GetHealthStat().Value = value;
			}
		}

		public float GetCurrentHealthRatio => GetHealthStat().UnitInterval;

		public bool IsAlive => HealthState != EHealthState.Dead;

		public bool IsDead => HealthState == EHealthState.Dead;

		public bool IsInjured => HealthState == EHealthState.Injured;

		public int LeftBeforeInjured => Mathf.FloorToInt((float)CurrentHealth - (float)MaxHealth * InjuredThreshold);

		public bool IsCritical => HealthState == EHealthState.Critical;

		public int LeftBeforeCritical => Mathf.FloorToInt((float)CurrentHealth - (float)MaxHealth * CriticalThreshold);

		public event Action<int> HealthpointsChanged;

		public event Action<EHealthState> HealthStateChanged;

		public event Action Died;

		private NumericStatistic GetHealthStat()
		{
			if (_healthStat == null)
			{
				if (!_agentStatistics.TryGetNumericStatistic(EAgentStatistics.Health, out _healthStat))
				{
					return null;
				}
				return _healthStat;
			}
			return _healthStat;
		}

		protected override void OnEnabled()
		{
			if ((bool)_agentStatistics && GetHealthStat() != null)
			{
				ResetHealth();
			}
		}

		public void ResetHealth()
		{
			SetHealthPoints(MaxHealth);
		}

		[Obsolete("Due to a change in the game design of the game, Agents won't take damage anymore, and will just die. Please refer to GDDs and use public methods 'ResetHealth' and 'ForceDeath'.")]
		public void Damage(int p_amount, bool checkRandomDeath = true)
		{
			if (!IsDead)
			{
				if (checkRandomDeath && RandomDeathFromInjury())
				{
					ForceDeath();
					return;
				}
				p_amount = Math.Abs(p_amount);
				ChangeHealthPoints(-p_amount);
			}
		}

		[Obsolete("Due to a change in the game design of the game, Agents won't take damage anymore, and will just die. Please refer to GDDs and use public methods 'ResetHealth' and 'ForceDeath'.")]
		public int CalculateLeftBeforeInjured(int currentHealth)
		{
			return Mathf.FloorToInt((float)currentHealth - (float)MaxHealth * InjuredThreshold);
		}

		[Obsolete("Due to a change in the game design of the game, Agents won't take damage anymore, and will just die. Please refer to GDDs and use public methods 'ResetHealth' and 'ForceDeath'.")]
		public int CalculateLeftBeforeCritical(int currentHealth)
		{
			return Mathf.FloorToInt((float)currentHealth - (float)MaxHealth * CriticalThreshold);
		}

		[Obsolete("Due to a change in the game design of the game, Agents won't take damage anymore, and will just die. Please refer to GDDs and use public methods 'ResetHealth' and 'ForceDeath'.")]
		public bool CouldDamageKill(int amount)
		{
			if (IsDead)
			{
				return true;
			}
			if (RandomDeathFromInjury())
			{
				return true;
			}
			return CurrentHealth - Math.Abs(amount) <= 0;
		}

		[Obsolete("Due to a change in the game design of the game, Agents won't take damage anymore, and will just die. Please refer to GDDs and use public methods 'ResetHealth' and 'ForceDeath'.")]
		public void Heal(int p_amount)
		{
			if (!IsDead)
			{
				p_amount = Math.Abs(p_amount);
				ChangeHealthPoints(p_amount);
			}
		}

		public void ForceDeath()
		{
			SetHealthPoints(0);
		}

		private void ChangeHealthPoints(int p_valueToAdd)
		{
			CurrentHealth += p_valueToAdd;
			CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
			this.HealthpointsChanged?.Invoke(CurrentHealth);
			StateUpdate();
		}

		private void SetHealthPoints(int p_valueToSet)
		{
			CurrentHealth = p_valueToSet;
			CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
			this.HealthpointsChanged?.Invoke(CurrentHealth);
			StateUpdate();
		}

		private bool RandomDeathFromInjury()
		{
			if (HealthState == EHealthState.Critical)
			{
				return true;
			}
			if (HealthState == EHealthState.Injured)
			{
				return UnityEngine.Random.value < BaseInjurySurvivabilityChance - (50f - GetCurrentHealthRatio);
			}
			return false;
		}

		private void StateUpdate(bool callEvents = true)
		{
			if (CurrentHealth <= 0)
			{
				ChangeState(EHealthState.Dead);
				if (callEvents)
				{
					this.Died?.Invoke();
				}
			}
			else if ((float)CurrentHealth < (float)MaxHealth * CriticalThreshold)
			{
				ChangeState(EHealthState.Critical);
			}
			else if ((float)CurrentHealth < (float)MaxHealth * InjuredThreshold)
			{
				ChangeState(EHealthState.Injured);
			}
			else
			{
				ChangeState(EHealthState.Healthy);
			}
		}

		private void ChangeState(EHealthState newState)
		{
			if (HealthState != newState)
			{
				HealthState = newState;
				this.HealthStateChanged?.Invoke(HealthState);
			}
		}
	}
}
