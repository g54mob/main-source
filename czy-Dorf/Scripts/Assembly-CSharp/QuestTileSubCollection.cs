using System;
using System.Collections.Generic;

[Serializable]
public class QuestTileSubCollection : IWeightedRandomizable
{
	public GroupType groupType;

	public string name;

	public List<GroupTypeId> allSegmentTypes;

	public int occupiedEdges;

	public float subCollectionRawProbability = 10f;

	public float subCollectionProbability;

	public float _displayProbability;

	public List<QuestTileOption> questTiles;

	public float Probability => subCollectionRawProbability;
}
