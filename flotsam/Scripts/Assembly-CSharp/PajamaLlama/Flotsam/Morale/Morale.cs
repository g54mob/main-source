using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace PajamaLlama.Flotsam.Morale
{
	public class Morale : SceneBehaviour
	{
		[Serializable]
		public class PersistentData
		{
			public MoraleEffect.BasePersistentData[] MoraleEffects;

			public PersistentData(Morale morale)
			{
				int num = morale.MoraleEffects.Length;
				MoraleEffects = new MoraleEffect.BasePersistentData[num];
				for (int i = 0; i < num; i++)
				{
					MoraleEffects[i] = morale.MoraleEffects[i].ReturnPersistentData();
				}
			}

			public void Restore(Morale morale)
			{
				MoraleEffect[] moraleEffects = morale.MoraleEffects;
				foreach (MoraleEffect moraleEffect in moraleEffects)
				{
					if (TryReturnPersistentData(moraleEffect, out var persistentData))
					{
						moraleEffect.Restore(persistentData);
					}
				}
			}

			private bool TryReturnPersistentData(MoraleEffect effect, out MoraleEffect.BasePersistentData persistentData)
			{
				MoraleEffect.BasePersistentData[] moraleEffects = MoraleEffects;
				foreach (MoraleEffect.BasePersistentData basePersistentData in moraleEffects)
				{
					if (basePersistentData != null && basePersistentData.PropertiesIndex == effect.PropertiesIndex)
					{
						persistentData = basePersistentData;
						return true;
					}
				}
				persistentData = null;
				return false;
			}
		}

		[SerializeField]
		[FormerlySerializedAs("Properties")]
		private MoraleProperties _properties;

		private Agent _agent;

		private TimeManager _timeManager;

		public UnityEvent UpdatedEvent { get; private set; }

		public UnityEvent CategoryUpdatedEvent { get; private set; }

		public MoraleProperties Properties => _properties;

		public MoraleEffect[] MoraleEffects { get; private set; }

		public int CurrentMood { get; private set; }

		public int CurrentMorale { get; private set; }

		public float CurrentMoraleFloat { get; private set; }

		public MoraleCategory CurrentMoraleCategory { get; private set; }

		public int MoraleNeed => Mathf.Min(_agent.Attributes.Level, _properties.MoraleNeedCap);

		public float ExperienceMultiplier { get; private set; }

		public float SpeedMultiplier { get; private set; }

		private void Update()
		{
			CurrentMood = ReturnMoodScore();
			switch (_properties.Style)
			{
			case MoraleStyle.AddMoodToMorale:
			{
				float num2 = (float)CurrentMood / _timeManager.CurrentDay.HourLength * Time.deltaTime;
				CurrentMoraleFloat = Mathf.Clamp(CurrentMoraleFloat + num2, _properties.MoraleRange.Minimum, _properties.MoraleRange.Maximum);
				break;
			}
			case MoraleStyle.MoodIsMoraleTarget:
			{
				float num = Mathf.Clamp(CurrentMood, _properties.MoraleRange.Minimum, _properties.MoraleRange.Maximum);
				float num2 = _properties.MoraleTargetSpeed / _timeManager.CurrentDay.HourLength * Time.deltaTime;
				if (CurrentMoraleFloat < num)
				{
					CurrentMoraleFloat = Mathf.Min(CurrentMoraleFloat + num2, num);
				}
				if (CurrentMoraleFloat > num)
				{
					CurrentMoraleFloat = Mathf.Max(CurrentMoraleFloat - num2, num);
				}
				break;
			}
			case MoraleStyle.MoodIsMorale:
				CurrentMoraleFloat = CurrentMood;
				break;
			default:
				Debug.LogException(new NotImplementedException());
				return;
			}
			int num3 = Mathf.RoundToInt(CurrentMoraleFloat);
			if (num3 != CurrentMorale)
			{
				CurrentMorale = num3;
				UpdateCategory();
				UpdatedEvent.Invoke();
				GameEventDispatcher.Dispatch(GameEventType.AgentMoraleUpdate);
			}
			MoraleEffect[] moraleEffects = MoraleEffects;
			for (int i = 0; i < moraleEffects.Length; i++)
			{
				moraleEffects[i].Update();
			}
		}

		private void OnDestroy()
		{
			_agent.OnDeath.RemoveListener(OnDeath);
			ClearMoraleEffects();
			GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAddedToPlayerCommunity);
		}

		public void Initialize(Agent agent)
		{
			_agent = agent;
			_agent.OnDeath.AddListener(OnDeath);
			_timeManager = GameManager.TimeManager;
			MoraleEffects = new MoraleEffect[_properties.MoralEffectProperties.Length];
			UpdatedEvent = new UnityEvent();
			CategoryUpdatedEvent = new UnityEvent();
			for (int i = 0; i < MoraleEffects.Length; i++)
			{
				MoraleEffect moraleEffect = _properties.MoralEffectProperties[i];
				MoraleEffect moraleEffect2 = UnityEngine.Object.Instantiate(moraleEffect);
				moraleEffect2.Initialize(agent, moraleEffect);
				MoraleEffects[i] = moraleEffect2;
				moraleEffect2.UpdatedEvent.AddListener(OnMoraleEffectUpdated);
			}
			InitializeMoodAndMorale();
			if (_agent.Community != Community.PlayerCommunity)
			{
				GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAddedToPlayerCommunity);
			}
		}

		private void InitializeMoodAndMorale()
		{
			CurrentMood = ReturnMoodScore();
			CurrentMorale = CurrentMood;
			CurrentMoraleFloat = CurrentMood;
			UpdateCategory();
		}

		private void UpdateCategory()
		{
			if (TryReturnCategory(out var category, CurrentMorale))
			{
				if (CurrentMoraleCategory != category)
				{
					CurrentMoraleCategory = category;
					ExperienceMultiplier = category.ExperienceMultiplier;
					SpeedMultiplier = category.SpeedMultiplier;
					CategoryUpdatedEvent.Invoke();
				}
			}
			else if (ExperienceMultiplier != 1f || SpeedMultiplier != 1f)
			{
				ExperienceMultiplier = 1f;
				SpeedMultiplier = 1f;
				Debug.LogException(new NotSupportedException($"Unable to set morale category for morale score {CurrentMorale}"));
				CategoryUpdatedEvent.Invoke();
			}
		}

		private void ClearMoraleEffects()
		{
			for (int i = 0; i < MoraleEffects.Length; i++)
			{
				MoraleEffect obj = MoraleEffects[i];
				obj.UpdatedEvent.RemoveListener(OnMoraleEffectUpdated);
				obj.Destroy();
			}
		}

		private void OnAgentAddedToPlayerCommunity(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				InitializeMoodAndMorale();
				UpdatedEvent.Invoke();
				GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAddedToPlayerCommunity);
			}
		}

		private void OnDeath()
		{
			_agent.OnDeath.RemoveListener(OnDeath);
			ClearMoraleEffects();
		}

		private void OnMoraleEffectUpdated()
		{
			UpdatedEvent.Invoke();
			GameEventDispatcher.Dispatch(GameEventType.AgentMoraleUpdate);
		}

		public bool HasNegativeModifier()
		{
			MoraleEffect[] moraleEffects = MoraleEffects;
			foreach (MoraleEffect moraleEffect in moraleEffects)
			{
				if (moraleEffect.IsActive() && moraleEffect.ReturnModifier() < 0)
				{
					return true;
				}
			}
			return false;
		}

		public int ReturnMoraleModifierSum()
		{
			int num = 0;
			MoraleEffect[] moraleEffects = MoraleEffects;
			foreach (MoraleEffect moraleEffect in moraleEffects)
			{
				if (moraleEffect.IsActive())
				{
					num += moraleEffect.ReturnModifier();
				}
			}
			return num;
		}

		public int ReturnMoodScore()
		{
			if (!_properties.SubtractNeed)
			{
				return ReturnMoraleModifierSum();
			}
			return ReturnMoraleModifierSum() - MoraleNeed;
		}

		public bool TryReturnCurrentCategory(out MoraleCategory category)
		{
			int index;
			return _properties.TryReturnCategory(CurrentMorale, MoraleNeed, _agent.Attributes.MaximumDrifterLevel, out category, out index);
		}

		public bool TryReturnCategory(out MoraleCategory category, int score)
		{
			int index;
			return _properties.TryReturnCategory(score, MoraleNeed, _agent.Attributes.MaximumDrifterLevel, out category, out index);
		}

		public bool TryReturnCurrentCategory(out MoraleCategory category, out int index)
		{
			return _properties.TryReturnCategory(CurrentMorale, MoraleNeed, _agent.Attributes.MaximumDrifterLevel, out category, out index);
		}

		public bool TryReturnMoraleEffectByIndex(int propertiesIndex, out MoraleEffect moraleEffect)
		{
			for (int i = 0; i < MoraleEffects.Length; i++)
			{
				moraleEffect = MoraleEffects[i];
				if (moraleEffect.PropertiesIndex == propertiesIndex)
				{
					return true;
				}
			}
			moraleEffect = null;
			return false;
		}
	}
}
