using System.Collections.Generic;
using UnityEngine;

public class ElementGroupCreator : ScriptableObject
{
	[SerializeField]
	private ElementGroup elementGroupPrefab;

	private Dictionary<GroupType, int> elementGroupCount;

	private int totalElementGroupCount;

	private void OnEnable()
	{
		elementGroupCount = new Dictionary<GroupType, int>();
	}

	public ElementGroup CreateGroup(ElementGroupSegment origin)
	{
		if (!elementGroupCount.ContainsKey(origin.GroupType))
		{
			elementGroupCount.Add(origin.GroupType, 0);
		}
		ElementGroup elementGroup = Object.Instantiate(elementGroupPrefab);
		elementGroup.SetType(origin.GroupType);
		elementGroup.AddSegment(origin);
		elementGroup.name = $"{origin.GroupType.name} {elementGroupCount[origin.GroupType]:##00} ";
		elementGroup.Id = totalElementGroupCount;
		SceneOrganizer.Instance.SortInContainer(elementGroup);
		elementGroupCount[origin.GroupType]++;
		totalElementGroupCount++;
		return elementGroup;
	}
}
