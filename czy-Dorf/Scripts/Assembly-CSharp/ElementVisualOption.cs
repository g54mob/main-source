using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ElementVisualOption : IWeightedRandomizable
{
	public GameObject visual;

	public float probability = 1f;

	public List<ColorSet> colorSets;

	public SessionQuestReward unlockReward;

	public float Probability => probability;
}
