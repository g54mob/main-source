using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ThresholdedStates
{
	[Tooltip("Visual states to use.")]
	[SerializeField]
	private List<ThresholdedState> _states = new List<ThresholdedState>();

	private bool _hasThrownWarning;

	private int _currentStateIndex;

	public List<ThresholdedState> States => _states;

	public event UnityAction<ThresholdedState, int, int> StateChangeSFX;

	public void Initialize()
	{
		int count = _states.Count;
		while (0 < count--)
		{
			_states[count].SetActive(count == _currentStateIndex);
		}
	}

	public void UpdateState(float progress)
	{
		UpdateState(progress, GameManager.Settings ? GameManager.Settings.AudioSettings.PrefabChangeAudioSound : null);
	}

	public void UpdateState(float progress, AudioClipProperties changeAudioClipProperties)
	{
		int count = _states.Count;
		int currentStateIndex = _currentStateIndex;
		progress = Mathf.Clamp01(progress);
		_currentStateIndex = -1;
		for (int i = 0; i < count && !(_states[i].Threshold > progress); i++)
		{
			_currentStateIndex = i;
		}
		bool flag = currentStateIndex != _currentStateIndex;
		if (_states.IsValidIndex(_currentStateIndex))
		{
			ThresholdedState thresholdedState = _states[_currentStateIndex];
			thresholdedState.SetActive(value: true);
			if (flag && !LoadingScreen.IsLoading)
			{
				if (this.StateChangeSFX != null)
				{
					this.StateChangeSFX(thresholdedState, _currentStateIndex, _currentStateIndex);
				}
				else if ((bool)GameManager.Settings && (bool)thresholdedState.State)
				{
					AudioManager.Play(GameManager.Settings.AudioSettings.PrefabChangeAudioSound, thresholdedState.State.transform);
				}
			}
		}
		if (flag && _states.IsValidIndex(currentStateIndex))
		{
			_states[currentStateIndex].SetActive(value: false);
		}
	}

	public bool Validate()
	{
		foreach (ThresholdedState state in _states)
		{
			if (state == null || state.State == null)
			{
				return false;
			}
		}
		return true;
	}

	public bool TryReturnActiveState(float progress, GameObject owner, out ThresholdedState activeState)
	{
		if (_states.Count == 0)
		{
			if (!_hasThrownWarning)
			{
				Debugger.Warning("[ThresholdedStates] Please check prefab '" + owner.name + "' for missing states!", owner, onlyShowInEditor: true);
				_hasThrownWarning = true;
			}
			activeState = null;
			return false;
		}
		int count = _states.Count;
		activeState = _states[count - 1];
		if (progress >= 0f)
		{
			for (int i = 0; i < count && !(_states[i].Threshold > progress); i++)
			{
				activeState = _states[i];
			}
		}
		return true;
	}
}
