using System.Collections.Generic;
using UnityEngine;

public class UpgradeCommander : MonoBehaviour
{
	public static UpgradeCommander instance;

	private float cooldown;

	private TagManager tagManager;

	private Transform playerTransform;

	private void OnEnable()
	{
		tagManager = TagManager.instance;
		instance = this;
		CommandUnits.instance.PlaceCommandedUnitsAndCalculateTargetPositions(_smartCommand: false);
		CommandUnits.instance.commanding = false;
		List<TaggedObject> list = new List<TaggedObject>();
		List<PathfindMovementPlayerunit> list2 = new List<PathfindMovementPlayerunit>();
		TagManager.instance.FindAllTaggedObjectsWithTag(list, TagManager.ETag.PlayerUnit);
		foreach (TaggedObject item in list)
		{
			PathfindMovementPlayerunit component = item.GetComponent<PathfindMovementPlayerunit>();
			if (component.HoldPosition)
			{
				list2.Add(component);
				component.HoldPosition = false;
			}
		}
		PlayerUpgradeManager.instance.commander = true;
		foreach (PathfindMovementPlayerunit item2 in list2)
		{
			item2.HoldPosition = true;
		}
		playerTransform = PlayerUpgradeManager.instance.transform;
	}
}
