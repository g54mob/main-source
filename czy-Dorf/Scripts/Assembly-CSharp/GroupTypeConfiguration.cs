using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class GroupTypeConfiguration : IWeightedRandomizable
{
	[SerializeField]
	private string name;

	public GroupType groupType;

	[FormerlySerializedAs("probability")]
	public float rawProbability;

	public float probabilityInPercent;

	public float _displayProbability;

	public float Probability => rawProbability;
}
