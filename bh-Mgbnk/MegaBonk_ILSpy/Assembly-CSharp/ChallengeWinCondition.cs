using System;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using UnityEngine;
using UnityEngine.Localization;

public abstract class ChallengeWinCondition : ScriptableObject
{
	public LocalizedString localizedString;

	private bool _003Ccompleted_003Ek__BackingField;

	public bool completed
	{
		get
		{
			return _003Ccompleted_003Ek__BackingField;
		}
		private set
		{
			_003Ccompleted_003Ek__BackingField = value;
		}
	}

	public abstract void Init(ChallengeData challengeData);

	public abstract void Cleanup();

	public void ChallengeCompleted()
	{
		if (!_003Ccompleted_003Ek__BackingField)
		{
			_003Ccompleted_003Ek__BackingField = true;
			ChallengesTracker.CompleteChallenge();
		}
	}

	public string GetDescription()
	{
		if (localizedString != null)
		{
			return localizedString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}
}
