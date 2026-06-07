using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Me/Progression/Challenge/", order = 1)]
public abstract class ChallengeWinCondition : ScriptableObject
{
	public LocalizedString localizedString;

	public bool completed { get; private set; }

	public abstract void Init(ChallengeData challengeData);

	public abstract void Cleanup();

	public void ChallengeCompleted()
	{
	}

	public string GetDescription()
	{
		return null;
	}
}
