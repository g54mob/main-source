using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class QuestPart : MonoBehaviour
{
	public UnityEvent FreshCompletedEffects;

	public UnityEvent CompletedEffects;

	public Action AnnounceComplete;

	public Checkpoint SkipIfMet;

	public virtual void ApplyFreshCompletedEffects()
	{
	}

	public virtual void ApplyCompletedEffects()
	{
	}

	public void Complete()
	{
	}

	public virtual void ActivateQuestPart()
	{
	}
}
