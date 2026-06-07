using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class CommunityPersistentData
{
	public string Name;

	public Community.Type Type;

	public List<BuildablePersistentData> Buildables;

	public List<AgentPersistentData> Agents;

	public List<BirdPersistentData> Birds;

	public List<ProjectPersistentData> Projects;

	public List<MarkerPersistentData> Markers;

	public List<int> FoundItemPropertyIndices;

	public Dictionary<AssignmentType, AssignmentPriority> AssignmentPriorityTemplates = new Dictionary<AssignmentType, AssignmentPriority>();

	[OptionalField(VersionAdded = 2)]
	public CommunityResearchPersistentdata ResearchData;

	[OptionalField(VersionAdded = 2)]
	public Dictionary<int, int> StoredBuildables = new Dictionary<int, int>();

	[OptionalField(VersionAdded = 3)]
	public Dictionary<int, int> StoredDecorations = new Dictionary<int, int>();

	[NonSerialized]
	private Community _instance;

	public CommunityPersistentData(Community community)
	{
		Name = community.Name;
		Type = community.CommunityType;
		AssignmentPriorityTemplates = GameManager.AgentManager.AssignmentPriorityTemplates;
		Buildables = new List<BuildablePersistentData>(community.Buildables.Count);
		foreach (Buildable buildable in community.Buildables)
		{
			if ((bool)buildable)
			{
				Buildables.Add(new BuildablePersistentData(buildable));
			}
		}
		foreach (KeyValuePair<BuildableProperties, List<Buildable>> storedBuildable in community.StoredBuildables)
		{
			StoredBuildables.Add(GameManager.PersistenceManager.ReturnPropertiesIndex(storedBuildable.Key), storedBuildable.Value.Count);
		}
		foreach (KeyValuePair<DecorationProperties, List<Decoration>> storedDecoration in community.StoredDecorations)
		{
			StoredDecorations.Add(GameManager.PersistenceManager.ReturnPropertiesIndex(storedDecoration.Key), storedDecoration.Value.Count);
		}
		if (community == Community.PlayerCommunity)
		{
			Agents = new List<AgentPersistentData>();
			foreach (Agent agent in community.Agents)
			{
				Agents.Add(new AgentPersistentData(agent));
			}
			Birds = new List<BirdPersistentData>();
			foreach (Bird bird in community.Birds)
			{
				if (BirdPersistentData.TryPersist(bird, out var birdPersistentData))
				{
					Birds.Add(birdPersistentData);
				}
			}
		}
		Markers = new List<MarkerPersistentData>();
		foreach (Marker marker in community.Markers)
		{
			Markers.Add(new MarkerPersistentData(marker));
		}
		Projects = new List<ProjectPersistentData>();
		foreach (Project project in community.Projects)
		{
			Projects.Add(new ProjectPersistentData(project));
		}
		foreach (BuildablePersistentData buildable2 in Buildables)
		{
			buildable2.PopulateReferences();
		}
		foreach (MarkerPersistentData marker2 in Markers)
		{
			marker2.PopulateReferences();
		}
		FoundItemPropertyIndices = new List<int>();
		foreach (ItemProperties foundItem in community.FoundItems)
		{
			FoundItemPropertyIndices.Add(GameManager.PersistenceManager.ReturnPropertiesIndex(foundItem));
		}
		ResearchData = ((community.Research == null) ? null : new CommunityResearchPersistentdata(community.Research));
	}

	public void PopulateReferences()
	{
		foreach (ProjectPersistentData project in Projects)
		{
			project.PopulateReferences();
		}
	}

	public void Restore()
	{
		_instance = new Community(Name, Type);
		for (int i = 0; i < FoundItemPropertyIndices.Count; i++)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(FoundItemPropertyIndices[i], out var reference))
			{
				_instance.FoundItems.Add(reference);
			}
		}
		for (int j = 0; j < Buildables.Count; j++)
		{
			Buildables[j].Restore();
		}
		if (StoredBuildables != null)
		{
			foreach (KeyValuePair<int, int> storedBuildable in StoredBuildables)
			{
				GameManager.PersistenceManager.TryReturnPropertiesReference<BuildableProperties>(storedBuildable.Key, out var reference2);
				for (int k = 0; k < storedBuildable.Value; k++)
				{
					Community.PlayerCommunity.AddStoredBuildable(reference2, reference2.Prefab);
				}
			}
		}
		if (StoredDecorations != null)
		{
			foreach (KeyValuePair<int, int> storedDecoration in StoredDecorations)
			{
				GameManager.PersistenceManager.TryReturnPropertiesReference<DecorationProperties>(storedDecoration.Key, out var reference3);
				for (int l = 0; l < storedDecoration.Value; l++)
				{
					Community.PlayerCommunity.AddStoredDecoration(reference3, reference3.GetDecorationPrefabWithProperties());
				}
			}
		}
		if (Agents != null)
		{
			foreach (AgentPersistentData agent in Agents)
			{
				agent.Restore(_instance);
			}
		}
		if (Birds != null)
		{
			foreach (BirdPersistentData bird in Birds)
			{
				bird.Restore(_instance);
			}
		}
		if (Markers != null)
		{
			foreach (MarkerPersistentData marker in Markers)
			{
				marker.Restore();
			}
		}
		AssignmentPriority value = AssignmentPriority.Lowest;
		foreach (AssignmentSetting assignmentSetting in GameManager.Settings.ProjectSettings.AssignmentSettings)
		{
			if (!AssignmentPriorityTemplates.TryGetValue(assignmentSetting.Type, out value))
			{
				value = AssignmentPriority.Lowest;
			}
			if (GameManager.AgentManager.AssignmentPriorityTemplates.ContainsKey(assignmentSetting.Type))
			{
				GameManager.AgentManager.AssignmentPriorityTemplates[assignmentSetting.Type] = value;
			}
			else
			{
				GameManager.AgentManager.AssignmentPriorityTemplates.Add(assignmentSetting.Type, value);
			}
		}
		if (ResearchData != null && _instance.Research != null)
		{
			ResearchData.Restore(_instance);
		}
	}

	public void RestoreReferences()
	{
		MooringPointPersistentData.RestoreMooredBoats();
		if (Agents != null)
		{
			foreach (AgentPersistentData agent in Agents)
			{
				agent.RestoreReferences();
			}
		}
		if (Projects != null && 0 < Projects.Count)
		{
			foreach (ProjectPersistentData project2 in Projects)
			{
				if (project2.TryRestore(out var project, communityProject: true) && !_instance.QueueProject(project))
				{
					Debug.LogWarningFormat("Unable to queue restored project '{0}' at community!", project.Properties.name);
				}
			}
		}
		if (Buildables != null && 0 < Buildables.Count)
		{
			foreach (BuildablePersistentData buildable in Buildables)
			{
				buildable.RestoreReferences();
			}
		}
		MooringPointPersistentData.LinkUnlinkedBoats();
		if (Markers != null)
		{
			foreach (MarkerPersistentData marker in Markers)
			{
				marker.RestoreReferences();
			}
		}
		if (ResearchData != null)
		{
			ResearchData.RestoreReferences(_instance);
		}
	}
}
