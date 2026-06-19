using System;
using System.Collections.Generic;

namespace TH20
{
	public class CollaborativeMetagameData : MustCallDestroy
	{
		public enum TutorialType
		{
			CollaborativePortfolioTutorial = 0,
			CollaborativeProjectTutorial = 1,
			GlobalProjectTutorial = 2
		}

		public struct TutorialData
		{
			public LocalisedString Title;

			public LocalisedString Body;
		}

		private class ObjectiveRecord
		{
			public int? SuperBugId;

			public Guid? ProjectId;

			public int NodeId;
		}

		private Dictionary<Guid, uint> _lastViewRecord;

		private HashSet<int> _superBugIntrosSeen;

		private HashSet<int> _superBugCompletionsSeen;

		private HashSet<TutorialType> _tutorialsSeen;

		private int _numGlobalNodesCompletedSeen;

		private int _currentSuperBugId;

		[DontSave]
		private ObjectiveRecord _unseenCompletedObjective;

		[DontSave]
		public Action OnLastViewTimeUpdated;

		[DontSave]
		private CollaborativePortfolio _portfolio;

		[DontSave]
		private Metagame _metagame;

		public int? UnseenCompletedSuperBugId
		{
			get
			{
				if (_unseenCompletedObjective == null)
				{
					return null;
				}
				return _unseenCompletedObjective.SuperBugId;
			}
		}

		public Guid? UnseenCompletedProjectId
		{
			get
			{
				if (_unseenCompletedObjective == null)
				{
					return null;
				}
				return _unseenCompletedObjective.ProjectId;
			}
		}

		public int? UnseenCompletedNodeId
		{
			get
			{
				if (_unseenCompletedObjective == null)
				{
					return null;
				}
				return _unseenCompletedObjective.NodeId;
			}
		}

		public CollaborativeMetagameData(App app, Metagame metagame)
		{
			_metagame = metagame;
			_portfolio = app.CollaborativePortfolio;
			CollaborativePortfolio portfolio = _portfolio;
			portfolio.OnLatestDataGathered = (Action)Delegate.Combine(portfolio.OnLatestDataGathered, new Action(OnLatestDataGathered));
			_portfolio.SetMetagameReference(metagame);
			ObjectiveEvents objectiveEvents = metagame.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			if (_lastViewRecord == null)
			{
				_lastViewRecord = new Dictionary<Guid, uint>();
			}
			if (_superBugIntrosSeen == null)
			{
				_superBugIntrosSeen = new HashSet<int>();
			}
			if (_superBugCompletionsSeen == null)
			{
				_superBugCompletionsSeen = new HashSet<int>();
			}
			if (_tutorialsSeen == null)
			{
				_tutorialsSeen = new HashSet<TutorialType>();
			}
		}

		public void RestoreFromSave(App app, Metagame metagame)
		{
			_metagame = metagame;
			_portfolio = app.CollaborativePortfolio;
			CollaborativePortfolio portfolio = _portfolio;
			portfolio.OnLatestDataGathered = (Action)Delegate.Combine(portfolio.OnLatestDataGathered, new Action(OnLatestDataGathered));
			_portfolio.SetMetagameReference(metagame);
			ObjectiveEvents objectiveEvents = metagame.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			if (_lastViewRecord == null)
			{
				_lastViewRecord = new Dictionary<Guid, uint>();
			}
			if (_superBugIntrosSeen == null)
			{
				_superBugIntrosSeen = new HashSet<int>();
			}
			if (_superBugCompletionsSeen == null)
			{
				_superBugCompletionsSeen = new HashSet<int>();
			}
			if (_tutorialsSeen == null)
			{
				_tutorialsSeen = new HashSet<TutorialType>();
			}
		}

		public override void Destroy()
		{
			base.Destroy();
			if (_metagame != null)
			{
				ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}
			_portfolio.OnActiveObjectiveUpdated(force: true);
			CollaborativePortfolio portfolio = _portfolio;
			portfolio.OnLatestDataGathered = (Action)Delegate.Remove(portfolio.OnLatestDataGathered, new Action(OnLatestDataGathered));
			_portfolio.SetMetagameReference(null);
		}

		public void LogLastView(Guid? projectID)
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				_unseenCompletedObjective = null;
				if (projectID.HasValue)
				{
					_lastViewRecord[projectID.Value] = OnlineManager.GetServerTime();
				}
				OnLastViewTimeUpdated.InvokeSafe();
			}
		}

		public void LogLastGlobalView()
		{
			if (OnlineManager.IsInitializedAndLoggedOn() && _metagame?.SuperBugManager?.Data != null)
			{
				_numGlobalNodesCompletedSeen = _metagame.SuperBugManager.Data.NumCompletedNodes;
				_currentSuperBugId = ((_metagame.SuperBugManager.DownloadedProjectDefinition != null) ? _metagame.SuperBugManager.DownloadedProjectDefinition.SuperBugID : (-1));
			}
		}

		public bool HasGlobalProjectChanged()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return false;
			}
			if (_metagame?.SuperBugManager?.Data == null)
			{
				return false;
			}
			if (_metagame.SuperBugManager.DownloadedProjectDefinition != null && _metagame.SuperBugManager.DownloadedProjectDefinition.SuperBugID != _currentSuperBugId)
			{
				return true;
			}
			return _numGlobalNodesCompletedSeen != _metagame.SuperBugManager.Data.NumCompletedNodes;
		}

		public bool HasProjectGotNewData(CollaborativeProject project)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return false;
			}
			_lastViewRecord.TryGetValue(project.ProjectID, out var value);
			return project.LastUpdateTime > value;
		}

		public uint GetLastViewTimestamp(Guid projectID)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return 0u;
			}
			_lastViewRecord.TryGetValue(projectID, out var value);
			return value;
		}

		public bool HasPortfolioGotNewData()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return false;
			}
			for (int i = 0; i < _portfolio.ActiveProjectSlots.Count; i++)
			{
				if (_portfolio.ActiveProjectSlots[i] != null)
				{
					uint lastViewTimestamp = GetLastViewTimestamp(_portfolio.ActiveProjectSlots[i].ProjectID);
					if (_portfolio.ActiveProjectSlots[i].LastUpdateTime > lastViewTimestamp)
					{
						return true;
					}
				}
			}
			for (int j = 0; j < _portfolio.ProjectsInvitedTo.Count; j++)
			{
				CollaborativeProjectData collaborativeProjectData = _portfolio.ProjectsInvitedTo[j];
				uint lastViewTimestamp2 = GetLastViewTimestamp(collaborativeProjectData.ProjectID);
				if (collaborativeProjectData.LastUpdateTime > lastViewTimestamp2)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasSeenSuperBugIntro(int superBugId)
		{
			return _superBugIntrosSeen.Contains(superBugId);
		}

		public bool HasSeenSuperBugCompletion(int superBugId)
		{
			return _superBugCompletionsSeen.Contains(superBugId);
		}

		public bool HasSeenTutorial(TutorialType tutorialType)
		{
			return _tutorialsSeen.Contains(tutorialType);
		}

		public void OnSeenSuperBugIntro(int superBugId)
		{
			_superBugIntrosSeen.Add(superBugId);
		}

		public void OnSeenSuperBugCompletion(int superBugId)
		{
			_superBugCompletionsSeen.Add(superBugId);
		}

		public void OnSeenTutorial(TutorialType tutorialType)
		{
			_tutorialsSeen.Add(tutorialType);
		}

		private void ValidateViewRecords()
		{
			List<Guid> list = new List<Guid>();
			foreach (KeyValuePair<Guid, uint> item in _lastViewRecord)
			{
				bool flag = false;
				for (int i = 0; i < _portfolio.ActiveProjectSlots.Count; i++)
				{
					if (item.Key == _portfolio.ActiveProjectSlots[i].ProjectID)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					foreach (CollaborativeProjectData item2 in _portfolio.ProjectsInvitedTo)
					{
						if (item2.Collaborators.ContainsValue(item2.ProjectID))
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					list.Add(item.Key);
				}
			}
			foreach (Guid item3 in list)
			{
				_lastViewRecord.Remove(item3);
			}
		}

		private void OnLatestDataGathered()
		{
			ValidateViewRecords();
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (objective is ResearchProjectObjective)
			{
				ResearchProjectObjective researchProjectObjective = objective as ResearchProjectObjective;
				_unseenCompletedObjective = new ObjectiveRecord
				{
					ProjectId = researchProjectObjective.ProjectID,
					NodeId = researchProjectObjective.NodeID
				};
			}
			else if (objective is SuperBugObjective)
			{
				SuperBugObjective superBugObjective = objective as SuperBugObjective;
				_unseenCompletedObjective = new ObjectiveRecord
				{
					SuperBugId = superBugObjective.SuperBugID,
					NodeId = superBugObjective.NodeID
				};
			}
		}
	}
}
