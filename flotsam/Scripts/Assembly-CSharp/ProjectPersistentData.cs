using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class ProjectPersistentData : PersistentReference<Project>
{
	[Serializable]
	public struct ItemProjectLink
	{
		public int ItemIndex;

		public ProjectLinkType Link;

		public bool Activated;
	}

	[Serializable]
	public enum ProjectLinkType
	{
		None = 0,
		Single = 1,
		Combined = 2
	}

	public int PropertiesIndex;

	public ProjectTargetPersistentData Target;

	public ProjectAssignmentPersistentData[] Assignments;

	public ItemProjectLink[] GeneralItems;

	[OptionalField(VersionAdded = 1)]
	public ItemProjectLink[] ReservedItems;

	[OptionalField(VersionAdded = 1)]
	public ItemProjectLink[] FinishedItems;

	public int AgentLimit;

	public VitalType Vital;

	[OptionalField(VersionAdded = 2)]
	public AssignmentType AdditionlAssignmentTypes;

	public bool Locked;

	public ProjectPersistentData(Project project)
		: base(project)
	{
		PropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(project.Properties);
		Target = new ProjectTargetPersistentData(project.Target, project.Properties.AllowTargetTypeNull);
		GeneralItems = ReturnItemProjectLinks(project, project.GeneralItems);
		AgentLimit = project.AssignmentLimit;
		Vital = project.Vital;
		AdditionlAssignmentTypes = project.Properties.AssignmentType ^ project.AssignmentTypes;
		int count = project.Assignments.Count;
		Assignments = new ProjectAssignmentPersistentData[count];
		for (int i = 0; i < count; i++)
		{
			Assignments[i] = new ProjectAssignmentPersistentData(project.Assignments[i]);
		}
	}

	public void PopulateReferences()
	{
		if (Target.IsNull())
		{
			Target = new ProjectTargetPersistentData(base.Instance.Target, base.Instance.Properties.AllowTargetTypeNull);
		}
	}

	public bool TryRestore(out Project project, bool communityProject)
	{
		project = null;
		if (!GameManager.PersistenceManager.TryReturnPropertiesReference<ProjectProperties>(PropertiesIndex, out var reference))
		{
			Debug.LogError("Unable to find reference to project properties!");
			return false;
		}
		return TryRestore(out project, reference, communityProject);
	}

	public bool TryRestore(out Project project, ProjectProperties properties, bool communityProject)
	{
		base.Restore();
		project = null;
		if (communityProject && properties.AssignmentType == AssignmentType.None && AdditionlAssignmentTypes == AssignmentType.None)
		{
			Debug.LogException(new Exception($"Project '{properties}' with assignment type 'NONE' was persisted as part of the communities project queue, this should no longer be possible post 0.3.1e5!"));
			return false;
		}
		if (!Target.TryRestore(out var target, properties.AllowTargetTypeNull))
		{
			Debug.LogException(new Exception($"Unable to restore target for project '{properties}'!"));
			return false;
		}
		base.Instance = new Project(properties, target, RestoreItemList(GeneralItems));
		base.Instance.SalvageTarget = RestoreSalvageTarget(target);
		base.Instance.AssignmentLimit = AgentLimit;
		base.Instance.AddAssignmentType(AdditionlAssignmentTypes);
		base.Instance.Vital = ((Vital == VitalType.Pollution) ? VitalType.None : Vital);
		RestoreAssignments(base.Instance);
		project = base.Instance;
		return true;
	}

	public void RestoreAssignments(Project project)
	{
		ProjectAssignmentPersistentData[] assignments = Assignments;
		for (int i = 0; i < assignments.Length; i++)
		{
			assignments[i].Restore(project);
		}
	}

	private ItemProjectLink[] ReturnItemProjectLinks(Project project, List<Item> items)
	{
		int count = items.Count;
		ItemProjectLink[] array = new ItemProjectLink[count];
		for (int i = 0; i < count; i++)
		{
			Item item = items[i];
			array[i] = new ItemProjectLink
			{
				ItemIndex = item.PersistentIndex
			};
		}
		return array;
	}

	private List<Item> RestoreItemList(ItemProjectLink[] links)
	{
		int num = links.Length;
		List<Item> list = new List<Item>(num);
		for (int i = 0; i < num; i++)
		{
			if (PersistentReference<Item>.TryReturnReference(links[i].ItemIndex, out var reference))
			{
				list.Add(reference);
			}
		}
		return list;
	}

	private ISalvageTarget RestoreSalvageTarget(GameObject target)
	{
		if ((bool)target)
		{
			ISalvageTarget componentInChildren = target.GetComponentInChildren<ISalvageTarget>();
			if (componentInChildren != null)
			{
				return componentInChildren;
			}
			Landmark componentInChildren2 = target.GetComponentInChildren<Landmark>();
			if ((bool)componentInChildren2 && componentInChildren2.Behaviour is ActionsBehaviour actionsBehaviour && actionsBehaviour.TryReturnAction<LandmarkActionSalvage>(out var action, true))
			{
				return action;
			}
		}
		return null;
	}
}
