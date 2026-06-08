using System;
using UnityEngine;

[Serializable]
public class QuestProbability
{
	public Quest quest;

	public AnimationCurve probabilityCurve = AnimationCurve.Linear(0f, 0.1f, 50f, 1f);

	public float _displayProbability;
}
