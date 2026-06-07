using System;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class ProjectAssignmentPersistentData
{
	[Serializable]
	public struct ItemToHaulData
	{
		public PersistentReference<Item>.Reference Item;

		public SubInventoryType TargetSubInventory;

		[OptionalField(VersionAdded = 2)]
		public bool IsGeneralItem;
	}

	public PersistentReference<Agent>.Reference Agent;

	public int TaskIndex;

	[OptionalField(VersionAdded = 3)]
	public ProjectAssignmentFlags Flags;

	[OptionalField(VersionAdded = 4)]
	public bool IsIdleProject;

	public ItemToHaulData[] ItemsToHaul;

	[OptionalField(VersionAdded = 3)]
	private readonly PersistentReference<Item>.Reference _reservedItem;

	[OptionalField(VersionAdded = 2)]
	public PersistentReference<Boat>.Reference Boat;

	[OptionalField(VersionAdded = 2)]
	public PersistentReference<MooringPoint>.Reference ReservedDisembarkMooringPoint;

	[OptionalField(VersionAdded = 2)]
	public PersistentReference<LandmarkMooringPoint>.Reference ReservedDisembarkLandmarkMooringPoint;

	public ProjectAssignmentPersistentData(ProjectAssignment assignment)
	{
		Agent = assignment.Agent;
		TaskIndex = assignment.ActiveTaskIndex;
		Flags = assignment.Flags;
		IsIdleProject = assignment.IsIdleProject;
		ItemsToHaul = ReturnItemToHaulPersistentData(assignment);
		_reservedItem = assignment.ReservedItem;
		Boat = assignment.Boat;
		PopulateReservedDisembarkMooringPointPersistentData(assignment.ReservedDisembarkMooringPoint);
	}

	private void PopulateReservedDisembarkMooringPointPersistentData(MooringPointBase mooringPoint)
	{
		ReservedDisembarkMooringPoint = mooringPoint as MooringPoint;
		if (ReservedDisembarkMooringPoint.IsNull())
		{
			ReservedDisembarkLandmarkMooringPoint = mooringPoint as LandmarkMooringPoint;
		}
	}

	public void Restore(Project project)
	{
		Agent agent = Agent;
		if (agent == null)
		{
			Debug.LogException(new Exception($"Unable to restore agent reference for a ProjectAssignement for project '{project.Properties}'"));
			return;
		}
		ProjectAssignment projectAssignment = new ProjectAssignment(project, Agent, TaskIndex, IsIdleProject);
		projectAssignment.SetFlags(Flags);
		Restore(projectAssignment);
		if (project.RestoreAssignment(projectAssignment))
		{
			if (agent.Assignment != null)
			{
				Debug.LogErrorFormat("'{0}' its assignment to project '{1}' is stopped in favor of its assignment to project '{2}'", agent.Name, agent.Assignment.Project.Properties.name, project.Properties.name);
				agent.Assignment.Stop(ProjectFlags.BugFix);
			}
			agent.Assignment = projectAssignment;
			agent.StartCoroutine(RestoreCoroutine(projectAssignment));
		}
	}

	private void Restore(ProjectAssignment assignment)
	{
		if (Boat != null)
		{
			assignment.RestoreBoat(Boat);
			if (!ReservedDisembarkLandmarkMooringPoint.IsNull())
			{
				assignment.ReserveDisembarkMooringPoint((LandmarkMooringPoint)ReservedDisembarkLandmarkMooringPoint);
			}
		}
		RestoreItemsToHaul(assignment);
		if (_reservedItem != null)
		{
			assignment.RestoreReservedItem(_reservedItem);
		}
	}

	private void RestoreItemsToHaul(ProjectAssignment assignment)
	{
		if (ItemsToHaul == null)
		{
			return;
		}
		ItemToHaulData[] itemsToHaul = ItemsToHaul;
		for (int i = 0; i < itemsToHaul.Length; i++)
		{
			ItemToHaulData itemToHaulData = itemsToHaul[i];
			if (itemToHaulData.Item.IsNull())
			{
				Debug.LogErrorFormat("Unable to restore ItemToHaul for '{0}' working on project '{1}' because the items persistent reference is 'null'!", assignment.Agent.Name, assignment.Project.Properties.name);
				continue;
			}
			Item item = itemToHaulData.Item;
			if (item == null || item.Owner == null)
			{
				Debug.LogException(new Exception("Unable to restore ItemToHaul for '" + assignment.Agent.Name + "' working on project '" + assignment.Project.Properties.name + "' because the item could not be restored!"));
			}
			else if (item.Owner.GetComponent<WalkwayPonton>() != null)
			{
				Debug.LogWarningFormat("Unable to restore ItemToHaul for '{0}' working on project '{1}' because the item was being hauled from WalkwayPonton!", assignment.Agent.Name, assignment.Project.Properties.name);
			}
			else
			{
				assignment.RestoreItemToHaul(item, itemToHaulData.TargetSubInventory, itemToHaulData.IsGeneralItem);
			}
		}
	}

	private IEnumerator RestoreCoroutine(ProjectAssignment assignment)
	{
		while (LoadingScreen.IsLoading)
		{
			yield return null;
		}
		assignment.Agent.UpdateActivity(Activity.Working);
		yield return null;
		yield return new WaitForEndOfFrame();
		if (assignment.Agent.Assignment == assignment && !assignment.Start())
		{
			assignment.Stop(ProjectFlags.BugFix);
		}
	}

	public ItemToHaulData[] ReturnItemToHaulPersistentData(ProjectAssignment assignment)
	{
		if (assignment.ItemsToHaul == null || assignment.ItemsToHaul.Count == 0)
		{
			return null;
		}
		ItemToHaulData[] array = new ItemToHaulData[assignment.ItemsToHaul.Count];
		for (int i = 0; i < array.Length; i++)
		{
			ItemToHaul itemToHaul = assignment.ItemsToHaul[i];
			array[i] = new ItemToHaulData
			{
				Item = itemToHaul.Item,
				TargetSubInventory = itemToHaul.TargetSubInventory,
				IsGeneralItem = itemToHaul.IsGeneralListItem
			};
		}
		return array;
	}
}
