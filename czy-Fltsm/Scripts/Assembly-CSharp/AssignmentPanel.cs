using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssignmentPanel : Panel
{
	[Header("Assignments")]
	[Tooltip("The transform that is parent to the assignment images.")]
	public Transform AssignmentParent;

	[Tooltip("The transform that is parent to the drifter entries.")]
	public Transform EntryParent;

	[Tooltip("The transform that is the parent of the priority template.")]
	public Transform TemplateParent;

	[HideInInspector]
	public List<AssignmentType> DisplayedAssignments = new List<AssignmentType>();

	private List<AssignmentPanelEntry> _entries = new List<AssignmentPanelEntry>();

	private void Start()
	{
		Community.PlayerCommunity.AgentsUpdatedEvent += UpdatePanels;
		for (int i = 0; i < GameManager.Settings.ProjectSettings.AssignmentSettings.Count; i++)
		{
			AssignmentSetting assignmentSetting = GameManager.Settings.ProjectSettings.AssignmentSettings[i];
			if (assignmentSetting.Type != AssignmentType.None)
			{
				AssignmentIcon assignmentIcon = Object.Instantiate(GameManager.Settings.UISettings.AssignmentPrefab, AssignmentParent);
				assignmentIcon.gameObject.name = "Assignment" + assignmentSetting.Type;
				DisplayedAssignments.Add(assignmentSetting.Type);
				assignmentIcon.Initialize(this, assignmentSetting);
			}
		}
		CreateEntry(null, isTemplate: true);
		UpdatePanels();
	}

	private void OnDestroy()
	{
		Community.PlayerCommunity.AgentsUpdatedEvent -= UpdatePanels;
	}

	private void UpdatePanels()
	{
		IEnumerable<Agent> enumerable = _entries.Select((AssignmentPanelEntry assignmentEntry) => assignmentEntry.Drifter);
		List<Agent> agents = Community.PlayerCommunity.Agents;
		List<Agent> list = enumerable.Except(agents).ToList();
		List<Agent> list2 = agents.Except(enumerable).ToList();
		foreach (Agent item in list)
		{
			RemoveEntry(item);
		}
		foreach (AssignmentPanelEntry entry in _entries)
		{
			entry.UpdateEntry();
		}
		foreach (Agent item2 in list2)
		{
			CreateEntry(item2);
		}
	}

	public void UpdatePriorityForAllEntries(bool increase, AssignmentType type)
	{
		foreach (AssignmentPanelEntry entry in _entries)
		{
			entry.UpdatePriority(increase, type);
		}
	}

	private void CreateEntry(Agent agent, bool isTemplate = false)
	{
		AssignmentPanelEntry assignmentPanelEntry = Object.Instantiate(GameManager.Settings.UISettings.AssignmentPanelEntryPrefab, isTemplate ? TemplateParent : EntryParent);
		assignmentPanelEntry.Initialize(agent, this, isTemplate);
		_entries.Add(assignmentPanelEntry);
		if (isTemplate)
		{
			assignmentPanelEntry.DragImage.gameObject.SetActive(value: false);
		}
	}

	private void RemoveEntry(Agent agent)
	{
		AssignmentPanelEntry assignmentPanelEntry = _entries.FirstOrDefault((AssignmentPanelEntry entry) => entry.Drifter == agent);
		if (!(assignmentPanelEntry == null) && !assignmentPanelEntry.IsTemplate)
		{
			_entries.Remove(assignmentPanelEntry);
			Object.Destroy(assignmentPanelEntry.gameObject);
		}
	}
}
