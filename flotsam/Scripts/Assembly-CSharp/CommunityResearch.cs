using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Debugs;
using UnityEngine;

public class CommunityResearch
{
	public class Research
	{
		[Serializable]
		public class PersistentData
		{
			[OptionalField(VersionAdded = 2)]
			public string Guid;

			public int Progress;

			public int BuildablePropertiesIndex;

			public PersistentData(Research research)
			{
				Guid = research.TechTreeNode.Guid;
				Progress = research.Progress;
			}

			public bool TryRestore(out Research research)
			{
				if (GameManager.Settings.TechTree.FindTechTreeNodeByGuid(Guid, out var node))
				{
					research = new Research(node, Progress);
					return true;
				}
				Debug.LogErrorFormat("Unable to restore research entry with GUID: {0}", Guid);
				research = null;
				return false;
			}
		}

		public TechTreeNode TechTreeNode;

		public int Cost;

		public int Progress;

		public string Guid => TechTreeNode.Guid;

		public string Name => TechTreeNode.Name;

		public int RemainingCost => Cost - Progress;

		public Research(TechTreeNode node, int progress)
		{
			TechTreeNode = node;
			Cost = node.GetRequirementAmount<KnowledgeRequirement>();
			Progress = progress;
		}

		public Research(TechTreeNode node)
			: this(node, 0)
		{
		}

		public static bool TryInstantiateFromGuid(string guid, out Research research)
		{
			if ((bool)GameManager.Settings && GameManager.Settings.TechTree.FindTechTreeNodeByGuid(guid, out var node))
			{
				research = new Research(node);
				return true;
			}
			research = null;
			return false;
		}
	}

	public int ResearchPoints;

	private Community _community;

	private GameplaySettings _settings;

	public HashSet<BuildableProperties> ResearchedBuildableProperties { get; private set; } = new HashSet<BuildableProperties>();

	public List<ResearchStation> ResearchStations { get; private set; } = new List<ResearchStation>();

	public Research CurrentResearch { get; private set; }

	public List<Research> ResearchProgresses { get; private set; }

	public Project ResearchProject { get; private set; }

	public bool HasPoints => ResearchPoints > 0;

	public int CurrentProgress
	{
		get
		{
			if (CurrentResearch != null)
			{
				return CurrentResearch.Progress;
			}
			return 0;
		}
	}

	public int CurrentCost
	{
		get
		{
			if (CurrentResearch != null)
			{
				return CurrentResearch.Cost;
			}
			return 0;
		}
	}

	public ItemProperties StudyItem => _settings.StudyItem;

	public float StudyTime { get; private set; }

	public CommunityResearch(Community community)
	{
		_community = community;
		_settings = GameSettings.Instance.GameplaySettings;
		ResearchProgresses = new List<Research>();
	}

	public void SetResearchProject(Project project)
	{
		if (project != null)
		{
			ResearchProject = project;
			project.FinishedEvent.AddListener(OnResearchProjectFinish);
		}
	}

	private void OnResearchProjectFinish(Project project, bool success)
	{
		project.FinishedEvent.RemoveListener(OnResearchProjectFinish);
		ResearchProject = null;
	}

	public void AddResearchPoints(int amount = 1)
	{
		ResearchPoints += amount;
		new GameEvent(GameEventType.ResearchPointsUpdated).Dispatch();
	}

	public bool RemoveResearchPoints(int amount = 1)
	{
		if (ResearchPoints < amount)
		{
			return false;
		}
		ResearchPoints -= amount;
		new GameEvent(GameEventType.ResearchPointsUpdated).Dispatch();
		return true;
	}

	public bool ResearchPoint()
	{
		if (CurrentResearch == null)
		{
			return true;
		}
		if (RemoveResearchPoints())
		{
			CurrentResearch.Progress++;
			new ResearchEvent(GameEventType.ResearchProgressPointsUpdated, CurrentResearch).Dispatch();
			if (CurrentResearch.Progress >= CurrentResearch.Cost)
			{
				FinishResearch();
				return true;
			}
		}
		return false;
	}

	public bool IsResearching()
	{
		return CurrentResearch != null;
	}

	public bool IsCurrentResearch(TechTreeNode node)
	{
		if (CurrentResearch != null)
		{
			return CurrentResearch.TechTreeNode == node;
		}
		return false;
	}

	public bool TryResearchGetProgress(TechTreeNode node, out int progress)
	{
		if (CurrentResearch != null && CurrentResearch.TechTreeNode == node)
		{
			progress = CurrentResearch.Progress;
			return true;
		}
		foreach (Research researchProgress in ResearchProgresses)
		{
			progress = researchProgress.Progress;
			if (researchProgress.TechTreeNode == node && 0 < progress && progress < node.Cost)
			{
				return true;
			}
		}
		progress = 0;
		return false;
	}

	public void AddResearchStation(ResearchStation station)
	{
		if (!ResearchStations.AddUnique(station))
		{
			Debugger.Error("Could not add a research station since it already exists.", station);
		}
	}

	public void RemoveResearchStation(ResearchStation station)
	{
		if (!ResearchStations.RemoveSafely(station))
		{
			Debugger.Error("Could not delete a research station since it didn't exist", station);
		}
	}

	public int GetActiveResearchStationCount()
	{
		int num = 0;
		if (ResearchStations.IsNullOrEmpty())
		{
			return num;
		}
		foreach (ResearchStation researchStation in ResearchStations)
		{
			if (researchStation.IsResearching)
			{
				num++;
			}
		}
		return num;
	}

	public void StartResearch(TechTreeNode node, Project project = null)
	{
		if (!TryReturnResearch(node, out var research))
		{
			research = new Research(node);
			ResearchProgresses.Add(research);
		}
		if (CurrentResearch == research)
		{
			return;
		}
		if (CurrentResearch != null)
		{
			CancelResearch();
		}
		CurrentResearch = research;
		if (project == null)
		{
			project = new Project(GameManager.Settings.ProjectSettings.ResearchProject, Construction.Townheart.gameObject);
			if (!_community.QueueProject(project))
			{
				Debug.LogError("Unable to queue research project in community.");
			}
		}
		ResearchProject = project;
		ResearchProject.FinishedEvent.AddListener(OnResearchProjectFinish);
		new ResearchEvent(GameEventType.ResearchStarted, CurrentResearch).Dispatch();
	}

	public void FinishResearch()
	{
		if (CurrentResearch != null)
		{
			Research currentResearch = CurrentResearch;
			CurrentResearch = null;
			ResearchProgresses.Remove(currentResearch);
			currentResearch.TechTreeNode.Unlock();
			GameManager.UIManager.NotificationHandler.AddNotification(GameManager.Settings.UISettings.ResearchFinishedNotification, new ResearchObjectOfInterest(currentResearch));
			new ResearchEvent(GameEventType.ResearchFinished, currentResearch).Dispatch();
		}
	}

	public void CancelResearch()
	{
		Research currentResearch = CurrentResearch;
		if (ResearchProject == null)
		{
			Debug.LogWarning("Research was canceled, but ResearchProject is NULL.");
		}
		else
		{
			ResearchProject?.Stop(ProjectFlags.Cancelled);
			ResearchProject = null;
		}
		CurrentResearch = null;
		if (currentResearch != null)
		{
			new ResearchEvent(GameEventType.ResearchCancelled, currentResearch).Dispatch();
		}
	}

	public void UnlockBuildable(BuildableProperties properties)
	{
		ResearchedBuildableProperties.Add(properties);
		properties.Unlock();
	}

	public bool RequiresMoreResearchStations(ResearchStation ignoredStation)
	{
		if (CurrentResearch == null)
		{
			return false;
		}
		int cost = CurrentResearch.Cost;
		int num = ReturnGeneratingPoints(ignoredStation);
		return cost > num;
	}

	public bool HasPointToResearch(ResearchStation ignoredStation)
	{
		if (CurrentResearch == null)
		{
			return false;
		}
		int num = ReturnGeneratingPoints(ignoredStation);
		int num2 = ResearchPoints - num;
		if (num < CurrentResearch.RemainingCost)
		{
			return 0 < num2;
		}
		return false;
	}

	private int ReturnGeneratingPoints(ResearchStation ignoredStation)
	{
		int num = 0;
		foreach (ResearchStation researchStation in ResearchStations)
		{
			if (!(ignoredStation == researchStation) && researchStation.ReservingAgent != null)
			{
				num++;
			}
		}
		return num;
	}

	public bool HasBuiltResearchStation()
	{
		foreach (ResearchStation researchStation in ResearchStations)
		{
			if (researchStation.Buildable.BuildPhase == BuildPhase.Finished)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasAvailableResearchStation()
	{
		foreach (ResearchStation researchStation in ResearchStations)
		{
			if (researchStation.ReturnCanRun() && !(researchStation.ReservingAgent != null))
			{
				return true;
			}
		}
		return false;
	}

	public ResearchStation ReturnClosestAvailableResearchStation(Agent agent)
	{
		float num = float.MaxValue;
		ResearchStation result = null;
		foreach (ResearchStation researchStation in ResearchStations)
		{
			if (!researchStation.ReturnCanRun())
			{
				continue;
			}
			if (researchStation.ReservingAgent == agent)
			{
				return researchStation;
			}
			if (!(researchStation.ReservingAgent != null))
			{
				float num2 = Vector3.Distance(agent.transform.position, researchStation.transform.position);
				if (num2 < num)
				{
					num = num2;
					result = researchStation;
				}
			}
		}
		return result;
	}

	public ResearchStation ReturnReservedResearchStation(Agent agent)
	{
		foreach (ResearchStation researchStation in ResearchStations)
		{
			if (researchStation.ReservingAgent == agent)
			{
				return researchStation;
			}
		}
		return null;
	}

	public bool IsResearched(ResearchUnlockable properties)
	{
		if ((bool)properties)
		{
			if (!UnlockableManager.IsUnlocked(properties))
			{
				if (properties is BuildableProperties item)
				{
					return ResearchedBuildableProperties.Contains(item);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public bool TryReturnResearch(TechTreeNode node, out Research research)
	{
		research = null;
		foreach (Research researchProgress in ResearchProgresses)
		{
			if (researchProgress.TechTreeNode == node)
			{
				research = researchProgress;
				return true;
			}
		}
		return false;
	}

	public bool HasStudyTime()
	{
		if (!(StudyTime > 0f))
		{
			return _community.Inventory.ReturnCount(_settings.StudyItem) > 0;
		}
		return true;
	}

	public float RemainingStudyTimeNormalized()
	{
		return StudyTime / _settings.StudyTimePerItem;
	}

	public float GetStudyExperiencePerSecond()
	{
		return _settings.StudyExperiencePerItem / _settings.StudyTimePerItem;
	}

	public void RestoreStudyTime(float studyTime)
	{
		StudyTime = studyTime;
	}

	public float AllocateStudyTime(float deltaTime, Storage storage)
	{
		if (deltaTime <= StudyTime)
		{
			StudyTime -= deltaTime;
			return deltaTime;
		}
		GameplaySettings gameplaySettings = GameSettings.Instance.GameplaySettings;
		ItemProperties studyItem = gameplaySettings.StudyItem;
		if ((storage.TryReserveItem(studyItem, out var item) || _community.Inventory.TryReserveItem(studyItem, out item)) && item.TryTakeFromInventory(out var _))
		{
			StudyTime += gameplaySettings.StudyTimePerItem;
		}
		if (StudyTime < deltaTime)
		{
			deltaTime = StudyTime;
		}
		StudyTime -= deltaTime;
		return deltaTime;
	}
}
