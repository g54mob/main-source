using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TilePresetConfiguration : IWeightedRandomizable
{
	[SerializeField]
	public string name;

	public GameObject tilePreset;

	public float rawProbability = 10f;

	public float tilePresetProbability;

	public float _displayProbability;

	public List<SegmentPresetInfo> segmentProbabilities;

	public int occupiedEdges;

	public float Probability => tilePresetProbability;
}
