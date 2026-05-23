#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections;
using System.Collections.Generic;
using Data.Variables;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = "RankConfigSO", menuName = "Rank System/Rank Progression")]
public class RankConfigSO : ScriptableObject
{
	[SerializeField]
	private IntVariableSO _currentXP;

	[SerializeField]
	private List<RankConfig> _rankConfigs;

	[SerializeField]
	private List<AbstractRankUpBehavior> _generalRankUpBehaviors;

	[SerializeField]
	private AddXPEvent _addXPEvent;

	[SerializeField]
	private OnUpdatedRankEvent _onUpdatedRankEvent;

	[SerializeField]
	private AudioManagerLocator _audioManagerLocator;

	[SerializeField]
	private int _maxRankDemo = 3;

	[SerializeField]
	private IntegrationManagerLocator _integrationManagerLocator;

	private int _currentRankIndex;

	public int MaxXP
	{
		get
		{
			if (_maxRankDemo >= 0)
			{
				return _rankConfigs[Mathf.Clamp(_maxRankDemo, 0, _rankConfigs.Count - 1)].XPRequired - 1;
			}
			return int.MaxValue;
		}
	}

	public int CurrentXp => _currentXP.Value;

	private int CurrentRankIndex
	{
		get
		{
			if (_currentRankIndex == 0)
			{
				_currentRankIndex = GetRankIndex(_currentXP.Value);
			}
			return _currentRankIndex;
		}
	}

	public event Action<int> OnXPChanged = delegate
	{
	};

	private void OnEnable()
	{
		if (_addXPEvent != null)
		{
			_addXPEvent.RegisterMainThread(HandleAddXP);
		}
	}

	private void OnDisable()
	{
		if (_addXPEvent != null)
		{
			_addXPEvent.UnRegisterMainThread(HandleAddXP);
		}
	}

	private void HandleAddXP(AddXPEvent.Data xpToAdd)
	{
		AddXP(xpToAdd.Amount);
	}

	public int GetRankIndex(int xp)
	{
		for (int num = _rankConfigs.Count - 1; num >= 0; num--)
		{
			if (xp >= _rankConfigs[num].XPRequired)
			{
				return num;
			}
		}
		return 0;
	}

	public RankConfig GetCurrentRankConfig()
	{
		return _rankConfigs[CurrentRankIndex];
	}

	public int GetCurrentRank()
	{
		return _rankConfigs[CurrentRankIndex].Rank;
	}

	public void ResetXP()
	{
		_currentXP.SetValue(_currentXP.DefaultValue);
		_currentRankIndex = GetRankIndex(_currentXP.Value);
		this.OnXPChanged(_currentXP.Value);
		_onUpdatedRankEvent.Fire(_currentRankIndex);
	}

	public void AddXP(int xp)
	{
		if (_currentXP.Value >= MaxXP)
		{
			this.LogError($"Cannot exceed max XP {_currentXP.Value}/{MaxXP}", "AddXP", 95);
			return;
		}
		int num = Mathf.Min(_currentXP.Value + xp, MaxXP);
		this.Log($"Added XP, new value: {num} / {MaxXP}", "AddXP", 100);
		_currentXP.SetValue(num);
		HandleRankProgression();
		this.OnXPChanged(_currentXP.Value);
	}

	public void SetXP(int xp, bool shouldExecuteBehaviors = true)
	{
		_currentXP.SetValue(xp);
		HandleRankProgression(shouldExecuteBehaviors);
		this.OnXPChanged(_currentXP.Value);
	}

	public void SetRank(int rank)
	{
		RankConfig rankConfig = _rankConfigs.Find((RankConfig r) => r.Rank == rank);
		if (rankConfig.Rank == 0 && rank != 0)
		{
			this.LogWarning($"Rank {rank} not found! Setting to closest available rank.", "SetRank", 121);
			List<RankConfig> rankConfigs = _rankConfigs;
			rankConfig = rankConfigs[rankConfigs.Count - 1];
		}
		SetXP(rankConfig.XPRequired);
	}

	private void HandleRankProgression(bool shouldExecuteBehaviors = true)
	{
		int rankIndex = GetRankIndex(_currentXP.Value);
		if (shouldExecuteBehaviors)
		{
			while (_currentRankIndex < rankIndex)
			{
				_currentRankIndex++;
				_audioManagerLocator.AudioManager.StartCoroutine(HandleRankProgressionDelayed(_currentRankIndex));
				UpdateRichPresence();
			}
		}
		_onUpdatedRankEvent.Fire(_currentRankIndex);
	}

	private void UpdateRichPresence()
	{
		_integrationManagerLocator.Integration.UpdateSocialPresenceBasedOnRank(GetCurrentRank());
	}

	private IEnumerator HandleRankProgressionDelayed(int newRankIndex)
	{
		yield return new WaitForSeconds(1f);
		ExecuteRankUpBehaviors(_rankConfigs[newRankIndex]);
		_audioManagerLocator.AudioManager.PlayRankUp(newRankIndex + 1);
	}

	public float GetProgressUntilNextRank(out int currentXPInNextRank, out int nextRankXPDelta)
	{
		if (CurrentRankIndex >= _rankConfigs.Count - 1)
		{
			currentXPInNextRank = 0;
			nextRankXPDelta = 0;
			return 1f;
		}
		int value = _currentXP.Value;
		int xPRequired = _rankConfigs[_currentRankIndex].XPRequired;
		int xPRequired2 = _rankConfigs[_currentRankIndex + 1].XPRequired;
		currentXPInNextRank = value - xPRequired;
		nextRankXPDelta = xPRequired2 - xPRequired;
		if (xPRequired2 == xPRequired)
		{
			return 0f;
		}
		return Mathf.Clamp01((float)currentXPInNextRank / (float)(xPRequired2 - xPRequired));
	}

	public RankConfig GetNextRankConfig()
	{
		if (CurrentRankIndex >= _rankConfigs.Count - 1)
		{
			this.LogWarning("Already at max rank! Returning current rank.", "GetNextRankConfig", 187);
			return _rankConfigs[_currentRankIndex];
		}
		return _rankConfigs[_currentRankIndex + 1];
	}

	public int GetExpansionPermitsRewarded(RankConfig rankConfig)
	{
		foreach (AbstractRankUpBehavior rankUpBehavior in rankConfig.RankUpBehaviors)
		{
			if (rankUpBehavior is GiveCurrencyRankupBehavior)
			{
				return (rankUpBehavior as GiveCurrencyRankupBehavior).Amount;
			}
		}
		return 0;
	}

	private void ExecuteRankUpBehaviors(RankConfig newRankConfig)
	{
		foreach (AbstractRankUpBehavior generalRankUpBehavior in _generalRankUpBehaviors)
		{
			generalRankUpBehavior.Execute();
		}
		foreach (AbstractRankUpBehavior rankUpBehavior in newRankConfig.RankUpBehaviors)
		{
			rankUpBehavior.Execute();
		}
	}

	[Button("Sort XP Thresholds", EButtonEnableMode.Always)]
	public void SortThresholds()
	{
		_rankConfigs.Sort((RankConfig a, RankConfig b) => a.XPRequired.CompareTo(b.XPRequired));
	}

	[Button("Generate XP Thresholds", EButtonEnableMode.Always)]
	public void GenerateXPThresholds()
	{
		if (_rankConfigs.Count == 0)
		{
			this.LogWarning("Rank list is empty!", "GenerateXPThresholds", 227);
			return;
		}
		int num = 100;
		int num2 = 50;
		_rankConfigs[0] = new RankConfig
		{
			Rank = 1,
			XPRequired = 0,
			Icon = _rankConfigs[0].Icon,
			RankUpBehaviors = _rankConfigs[0].RankUpBehaviors
		};
		for (int i = 1; i < _rankConfigs.Count; i++)
		{
			int num3 = num + num2 * (i * i);
			num3 = Mathf.RoundToInt((float)num3 / 50f) * 50;
			_rankConfigs[i] = new RankConfig
			{
				Rank = i + 1,
				XPRequired = num3,
				Icon = _rankConfigs[i].Icon,
				RankUpBehaviors = _rankConfigs[i].RankUpBehaviors
			};
		}
	}
}
