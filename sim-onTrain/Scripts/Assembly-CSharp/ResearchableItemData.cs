using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TrainSurvival/Researchanle Item Data")]
public class ResearchableItemData : ScriptableObject
{
	public CollectableItemData mainItem;

	public List<CollectableItemData> neededItems;
}
