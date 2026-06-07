using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class CommunityResearchPersistentdata
{
	public int[] ResearchedBuildableIndices;

	[OptionalField(VersionAdded = 2)]
	public int ResearchPoints;

	[OptionalField(VersionAdded = 2)]
	public CommunityResearch.Research.PersistentData[] ResearchProgresses;

	[OptionalField(VersionAdded = 3)]
	public string CurrentResearchGuid;

	public PersistentReference<Project>.Reference ResearchProject;

	[OptionalField(VersionAdded = 4)]
	public float StudyTime;

	public int CurrentResearch;

	public float Progress;

	public CommunityResearchPersistentdata(CommunityResearch research)
	{
		ResearchedBuildableIndices = new int[research.ResearchedBuildableProperties.Count];
		int num = 0;
		foreach (BuildableProperties researchedBuildableProperty in research.ResearchedBuildableProperties)
		{
			ResearchedBuildableIndices[num] = GameManager.PersistenceManager.ReturnPropertiesIndex(researchedBuildableProperty);
			num++;
		}
		CurrentResearchGuid = ((research.CurrentResearch == null) ? null : research.CurrentResearch.Guid);
		ResearchPoints = research.ResearchPoints;
		int count = research.ResearchProgresses.Count;
		ResearchProgresses = new CommunityResearch.Research.PersistentData[count];
		for (int i = 0; i < count; i++)
		{
			ResearchProgresses[i] = new CommunityResearch.Research.PersistentData(research.ResearchProgresses[i]);
		}
		ResearchProject = research.ResearchProject;
		StudyTime = research.StudyTime;
	}

	public void Restore(Community community)
	{
		for (int i = 0; i < ResearchedBuildableIndices.Length; i++)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<BuildableProperties>(ResearchedBuildableIndices[i], out var reference))
			{
				community.Research.UnlockBuildable(reference);
			}
		}
		community.Research.AddResearchPoints(ResearchPoints);
		community.Research.RestoreStudyTime(StudyTime);
		RestoreProgress(community);
	}

	private void RestoreProgress(Community community)
	{
		if (ResearchProgresses == null)
		{
			return;
		}
		CommunityResearch.Research.PersistentData[] researchProgresses = ResearchProgresses;
		for (int i = 0; i < researchProgresses.Length; i++)
		{
			if (researchProgresses[i].TryRestore(out var research))
			{
				community.Research.ResearchProgresses.Add(research);
			}
			else
			{
				Debug.LogWarning("[TODO] Handle lost progress points because of reserach that could not be restored!");
			}
		}
	}

	public void RestoreReferences(Community community)
	{
		if (!ResearchProject.TryReturn(out var instance))
		{
			instance = null;
		}
		if (GameManager.Settings.TechTree.FindTechTreeNodeByGuid(CurrentResearchGuid, out var node))
		{
			community.Research.StartResearch(node, instance);
		}
	}
}
