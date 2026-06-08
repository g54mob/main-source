using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

[Serializable]
public class QuestTileCollection : IWeightedRandomizable
{
	public GroupType groupType;

	[FormerlySerializedAs("probability")]
	public float rawProbability = 1f;

	public float collectionProbability;

	public float _displayProbability;

	public List<Quest> defaultQuestOptions;

	[FormerlySerializedAs("questTileSubCollections")]
	public List<QuestTileSubCollection> subCollections;

	public float Probability => rawProbability;
}
