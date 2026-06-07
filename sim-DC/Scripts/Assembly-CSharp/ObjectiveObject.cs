using Coffee.UIEffects;
using UnityEngine;

public class ObjectiveObject : MonoBehaviour
{
	public int xPForObjectiveCompletion;

	public int reputationForObjectiveCompletion;

	[SerializeField]
	private UIEffect uIEffect;

	[SerializeField]
	private UIEffectTweener uIEffectTweener;

	private void Start()
	{
	}

	public void GetReward()
	{
	}

	private void PlayUIEffectDisolve()
	{
	}
}
