using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelObjectivesList : MonoBehaviour
	{
		[SerializeField]
		private GameObject _objectiveItemPrefab;

		[SerializeField]
		private GameObject _collaborativeObjectiveItemPrefab;

		[SerializeField]
		private GameObject _objectivesList;

		[SerializeField]
		private Scrollbar _objectivesListScrollbar;

		[SerializeField]
		private DynamicLayoutGroup _objectivesDynamicLayoutGroup;

		[SerializeField]
		private float _maxListHeight = 550f;

		[SerializeField]
		private float _scrollAreaHeightHeadroom = 20f;

		[SerializeField]
		private int _rightMarginScroll = 26;

		[SerializeField]
		private int _leftMarginScroll = 8;

		[SerializeField]
		private int _rightMarginNoScroll = 8;

		[SerializeField]
		private int _leftMarginNoScroll = 8;

		private ObjectiveEvents _objectiveEvents;

		private Metagame _metagame;

		private Level _level;

		private bool _foundCollaborativePortfolio;

		private bool _checkResizeScrollAreaPending;

		private ObjectiveMenuItemBase _superBugObjectiveMenuItem;

		private readonly Dictionary<Objective, ObjectiveMenuItemBase> _objectiveMenuItems = new Dictionary<Objective, ObjectiveMenuItemBase>();

		public int NumVisibleObjectiveItems => _objectiveMenuItems.Count;

		public void Setup(LevelScriptManager levelScriptManager, ObjectiveEvents objectiveEvents, Metagame metagame, Level level)
		{
			_objectiveEvents = objectiveEvents;
			_metagame = metagame;
			_level = level;
			List<Objective> list = new List<Objective>();
			list.AddRange(levelScriptManager.ActiveObjectives);
			list.AddRange(levelScriptManager.StaffChallenges);
			list.AddRange(levelScriptManager.OnlineChallenges);
			foreach (Objective item in list)
			{
				switch (item.State)
				{
				case Objective.ObjectiveState.Unstarted:
					OnObjectiveDiscovered(item);
					break;
				case Objective.ObjectiveState.Active:
					OnObjectiveDiscovered(item);
					OnObjectiveStarted(item);
					break;
				}
			}
			if (metagame.App.GameMode is GameModeCareer && OnlineManager.IsInitializedAndLoggedOn() && metagame.App.UserProfile.IsCollaborativeProjectsUnlocked)
			{
				CollaborativePortfolio collaborativePortfolio = metagame.CollaborativePortfolio;
				collaborativePortfolio.OnPortfolioInitialised = (Action)Delegate.Combine(collaborativePortfolio.OnPortfolioInitialised, new Action(OnCollaborativeResearchInitialised));
				_foundCollaborativePortfolio = true;
				OnCollaborativeResearchInitialised();
			}
			RegisterEvents();
		}

		public void Destroy()
		{
			foreach (ObjectiveMenuItemBase value in _objectiveMenuItems.Values)
			{
				UnityEngine.Object.Destroy(value.gameObject);
			}
			UnregisterEvents();
			if (_foundCollaborativePortfolio)
			{
				CollaborativePortfolio collaborativePortfolio = _metagame.CollaborativePortfolio;
				collaborativePortfolio.OnPortfolioInitialised = (Action)Delegate.Remove(collaborativePortfolio.OnPortfolioInitialised, new Action(OnCollaborativeResearchInitialised));
			}
		}

		private void RegisterEvents()
		{
			UnregisterEvents();
			ObjectiveEvents objectiveEvents = _objectiveEvents;
			objectiveEvents.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Combine(objectiveEvents.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
			ObjectiveEvents objectiveEvents2 = _objectiveEvents;
			objectiveEvents2.OnObjectiveDiscovered = (Action<Objective>)Delegate.Combine(objectiveEvents2.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
			ObjectiveEvents objectiveEvents3 = _objectiveEvents;
			objectiveEvents3.OnObjectiveStarted = (Action<Objective>)Delegate.Combine(objectiveEvents3.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
			ObjectiveEvents objectiveEvents4 = _objectiveEvents;
			objectiveEvents4.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents4.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			ObjectiveEvents objectiveEvents5 = _objectiveEvents;
			objectiveEvents5.OnObjectiveRestarting = (Action<Objective>)Delegate.Combine(objectiveEvents5.OnObjectiveRestarting, new Action<Objective>(OnObjectiveRestarting));
			ObjectiveEvents objectiveEvents6 = _metagame.ObjectiveEvents;
			objectiveEvents6.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Combine(objectiveEvents6.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
			ObjectiveEvents objectiveEvents7 = _metagame.ObjectiveEvents;
			objectiveEvents7.OnObjectiveDiscovered = (Action<Objective>)Delegate.Combine(objectiveEvents7.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
			ObjectiveEvents objectiveEvents8 = _metagame.ObjectiveEvents;
			objectiveEvents8.OnObjectiveStarted = (Action<Objective>)Delegate.Combine(objectiveEvents8.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
			ObjectiveEvents objectiveEvents9 = _metagame.ObjectiveEvents;
			objectiveEvents9.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents9.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			ObjectiveEvents objectiveEvents10 = _metagame.ObjectiveEvents;
			objectiveEvents10.OnObjectiveRestarting = (Action<Objective>)Delegate.Combine(objectiveEvents10.OnObjectiveRestarting, new Action<Objective>(OnObjectiveRestarting));
			ObjectiveEvents objectiveEvents11 = _metagame.ObjectiveEvents;
			objectiveEvents11.OnObjectiveKickStateChanged = (Action<ResearchProjectObjective>)Delegate.Combine(objectiveEvents11.OnObjectiveKickStateChanged, new Action<ResearchProjectObjective>(OnObjectiveKickStateChanged));
			ObjectiveEvents objectiveEvents12 = _metagame.ObjectiveEvents;
			objectiveEvents12.OnObjectiveReadyForDestroy = (Action<Objective>)Delegate.Combine(objectiveEvents12.OnObjectiveReadyForDestroy, new Action<Objective>(OnObjectiveReadyForDestroy));
		}

		private void UnregisterEvents()
		{
			if (_objectiveEvents != null)
			{
				ObjectiveEvents objectiveEvents = _objectiveEvents;
				objectiveEvents.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Remove(objectiveEvents.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
				ObjectiveEvents objectiveEvents2 = _objectiveEvents;
				objectiveEvents2.OnObjectiveDiscovered = (Action<Objective>)Delegate.Remove(objectiveEvents2.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
				ObjectiveEvents objectiveEvents3 = _objectiveEvents;
				objectiveEvents3.OnObjectiveStarted = (Action<Objective>)Delegate.Remove(objectiveEvents3.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
				ObjectiveEvents objectiveEvents4 = _objectiveEvents;
				objectiveEvents4.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents4.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
				ObjectiveEvents objectiveEvents5 = _objectiveEvents;
				objectiveEvents5.OnObjectiveRestarting = (Action<Objective>)Delegate.Remove(objectiveEvents5.OnObjectiveRestarting, new Action<Objective>(OnObjectiveRestarting));
			}
			if (_metagame != null)
			{
				ObjectiveEvents objectiveEvents6 = _metagame.ObjectiveEvents;
				objectiveEvents6.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Remove(objectiveEvents6.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
				ObjectiveEvents objectiveEvents7 = _metagame.ObjectiveEvents;
				objectiveEvents7.OnObjectiveDiscovered = (Action<Objective>)Delegate.Remove(objectiveEvents7.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
				ObjectiveEvents objectiveEvents8 = _metagame.ObjectiveEvents;
				objectiveEvents8.OnObjectiveStarted = (Action<Objective>)Delegate.Remove(objectiveEvents8.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
				ObjectiveEvents objectiveEvents9 = _metagame.ObjectiveEvents;
				objectiveEvents9.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents9.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
				ObjectiveEvents objectiveEvents10 = _metagame.ObjectiveEvents;
				objectiveEvents10.OnObjectiveRestarting = (Action<Objective>)Delegate.Remove(objectiveEvents10.OnObjectiveRestarting, new Action<Objective>(OnObjectiveRestarting));
				ObjectiveEvents objectiveEvents11 = _metagame.ObjectiveEvents;
				objectiveEvents11.OnObjectiveKickStateChanged = (Action<ResearchProjectObjective>)Delegate.Remove(objectiveEvents11.OnObjectiveKickStateChanged, new Action<ResearchProjectObjective>(OnObjectiveKickStateChanged));
				ObjectiveEvents objectiveEvents12 = _metagame.ObjectiveEvents;
				objectiveEvents12.OnObjectiveReadyForDestroy = (Action<Objective>)Delegate.Remove(objectiveEvents12.OnObjectiveReadyForDestroy, new Action<Objective>(OnObjectiveReadyForDestroy));
			}
		}

		public void Update()
		{
			CheckScrollAreaResize();
		}

		private void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
			Objective ownerObjective = subGoal.GetOwnerObjective();
			if (_objectiveMenuItems.ContainsKey(subGoal.GetOwnerObjective()))
			{
				_objectiveMenuItems[ownerObjective].UpdateSubGoal(subGoal);
			}
			if (ownerObjective == _metagame.CollaborativePortfolio.ActiveObjective)
			{
				_metagame.CollaborativePortfolio.OnActiveObjectiveUpdated();
			}
			SetResizeScrollAreaPending();
		}

		private void OnObjectiveDiscovered(Objective objective)
		{
			if (objective.IsVisible && objective.ShowGUIOnDiscover())
			{
				CreateMenuItem(objective);
			}
		}

		private void OnObjectiveStarted(Objective objective)
		{
			if (_objectiveMenuItems.TryGetValue(objective, out var value))
			{
				value.OnObjectiveStarted();
			}
			else if (objective.IsVisible && !objective.ShowGUIOnDiscover())
			{
				CreateMenuItem(objective);
			}
			SetResizeScrollAreaPending();
		}

		private void OnCollaborativeResearchInitialised()
		{
			if (_metagame.CollaborativePortfolio.PortfolioDataController != null)
			{
				CollaborativePortfolioData portfolioData = _metagame.CollaborativePortfolio.PortfolioDataController.PortfolioData;
				if (portfolioData != null && portfolioData.ActiveObjective != null)
				{
					CreateMenuItem(portfolioData.ActiveObjective);
				}
			}
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (!_objectiveMenuItems.TryGetValue(objective, out var value))
			{
				return;
			}
			value.OnObjectiveCompleted(completionType);
			if (objective is ResearchProjectObjective || objective is SuperBugObjective)
			{
				if (completionType == Objective.CompletionType.Abandoned)
				{
					RemoveAndDestroyObjectiveImmediately(value);
				}
			}
			else if (!objective.IsReplayable || completionType != Objective.CompletionType.Failed)
			{
				RemoveObjective(objective);
			}
		}

		private void OnObjectiveRestarting(Objective objective)
		{
			if (_objectiveMenuItems.TryGetValue(objective, out var value))
			{
				value.OnObjectiveRestarting();
			}
		}

		private void OnObjectiveKickStateChanged(ResearchProjectObjective objective)
		{
			if (_objectiveMenuItems.TryGetValue(objective, out var value))
			{
				value.OnObjectiveKickStateChanged();
			}
		}

		private void OnObjectiveReadyForDestroy(Objective objective)
		{
			if (_objectiveMenuItems.TryGetValue(objective, out var value))
			{
				value.OnObjectiveReadyForDestroy();
				RemoveAndDestroyObjectiveImmediately(value);
			}
		}

		private void RemoveObjective(Objective objective)
		{
			if (objective.IsVisible && _objectiveMenuItems.ContainsKey(objective))
			{
				_objectiveMenuItems.Remove(objective);
			}
		}

		private void RemoveAndDestroyObjectiveImmediately(ObjectiveMenuItemBase objectiveMenuItem)
		{
			if (_objectiveMenuItems.ContainsKey(objectiveMenuItem.Objective))
			{
				_objectiveMenuItems.Remove(objectiveMenuItem.Objective);
				UnityEngine.Object.Destroy(objectiveMenuItem.gameObject);
				SetResizeScrollAreaPending();
			}
		}

		private void RemoveAndDestroyObjectiveImmediately(Objective objective)
		{
			if (_objectiveMenuItems.TryGetValue(objective, out var value))
			{
				_objectiveMenuItems.Remove(objective);
				UnityEngine.Object.Destroy(value.gameObject);
				SetResizeScrollAreaPending();
			}
		}

		private void CreateMenuItem(Objective objective)
		{
			ObjectiveMenuItemBase objectiveMenuItemBase;
			if (objective is ResearchProjectObjective)
			{
				if (_superBugObjectiveMenuItem != null)
				{
					RemoveAndDestroyObjectiveImmediately(_superBugObjectiveMenuItem);
					_superBugObjectiveMenuItem = null;
				}
				GameObject obj = UnityEngine.Object.Instantiate(_collaborativeObjectiveItemPrefab, _objectivesList.transform, worldPositionStays: false);
				obj.transform.SetAsLastSibling();
				objectiveMenuItemBase = (_superBugObjectiveMenuItem = obj.GetComponent<ObjectiveMenuItemBase>());
			}
			else if (objective is SuperBugObjective)
			{
				if (_superBugObjectiveMenuItem != null)
				{
					RemoveAndDestroyObjectiveImmediately(_superBugObjectiveMenuItem);
					_superBugObjectiveMenuItem = null;
				}
				GameObject obj2 = UnityEngine.Object.Instantiate(_collaborativeObjectiveItemPrefab, _objectivesList.transform, worldPositionStays: false);
				obj2.transform.SetAsLastSibling();
				objectiveMenuItemBase = (_superBugObjectiveMenuItem = obj2.GetComponent<ObjectiveMenuItemBase>());
			}
			else if (objective.Definition.OverrideObjectivePrefab != null)
			{
				objectiveMenuItemBase = UnityEngine.Object.Instantiate(objective.Definition.OverrideObjectivePrefab, _objectivesList.transform, worldPositionStays: false).GetComponent<ObjectiveMenuItemBase>();
				if (_superBugObjectiveMenuItem != null)
				{
					_superBugObjectiveMenuItem.transform.SetAsLastSibling();
				}
			}
			else
			{
				objectiveMenuItemBase = UnityEngine.Object.Instantiate(_objectiveItemPrefab, _objectivesList.transform, worldPositionStays: false).GetComponent<ObjectiveMenuItemBase>();
				if (_superBugObjectiveMenuItem != null)
				{
					_superBugObjectiveMenuItem.transform.SetAsLastSibling();
				}
			}
			objectiveMenuItemBase.Initialise(_level, objective);
			_objectiveMenuItems.Add(objective, objectiveMenuItemBase);
			SetResizeScrollAreaPending();
		}

		private void OnEnable()
		{
			SetResizeScrollAreaPending();
		}

		public LevelObjectiveSubGoal GetMostImportantUnfinishedSubgoal()
		{
			for (int i = 0; i < 2; i++)
			{
				foreach (KeyValuePair<Objective, ObjectiveMenuItemBase> objectiveMenuItem in _objectiveMenuItems)
				{
					ObjectiveMenuItemBase value = objectiveMenuItem.Value;
					if (!(value == null))
					{
						LevelObjectiveSubGoal mostImportantUnfinishedSubGoal = value.GetMostImportantUnfinishedSubGoal((i == 0) ? (-1) : 0);
						if (mostImportantUnfinishedSubGoal != null)
						{
							return mostImportantUnfinishedSubGoal;
						}
					}
				}
			}
			return null;
		}

		public RectTransform GetTransformOfSubGoalMenuItem(ObjectiveSubGoal subGoal)
		{
			RectTransform rectTransform = null;
			foreach (KeyValuePair<Objective, ObjectiveMenuItemBase> objectiveMenuItem in _objectiveMenuItems)
			{
				rectTransform = objectiveMenuItem.Value.GetSubGoalTransform(subGoal);
				if (rectTransform != null)
				{
					break;
				}
			}
			return rectTransform;
		}

		public void SetResizeScrollAreaPending()
		{
			_checkResizeScrollAreaPending = true;
		}

		public void CheckScrollAreaResize()
		{
			_checkResizeScrollAreaPending = false;
			LayoutElement component = GetComponent<LayoutElement>();
			if (!(component != null) || !(_objectivesDynamicLayoutGroup != null) || !(_objectivesListScrollbar != null))
			{
				return;
			}
			bool flag = false;
			float num = 0f;
			ObjectiveMenuItemBase[] componentsInChildren = _objectivesList.transform.GetComponentsInChildren<ObjectiveMenuItemBase>();
			if (componentsInChildren.Length != 0)
			{
				float minimumSpacing = _objectivesDynamicLayoutGroup.minimumSpacing;
				float num2 = _objectivesDynamicLayoutGroup.padding.top;
				float num3 = _objectivesDynamicLayoutGroup.padding.bottom;
				num += num2;
				ObjectiveMenuItemBase[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					float height = ((RectTransform)array[i].gameObject.transform).rect.height;
					num += height;
					num += minimumSpacing;
					if (height <= 0f)
					{
						flag = true;
						break;
					}
				}
				num -= minimumSpacing;
				num += num3;
			}
			if (!flag)
			{
				bool flag2 = num < _maxListHeight - _scrollAreaHeightHeadroom;
				component.preferredHeight = (flag2 ? (num + _scrollAreaHeightHeadroom) : _maxListHeight);
				int num4 = (flag2 ? _leftMarginNoScroll : _leftMarginScroll);
				int num5 = (flag2 ? _rightMarginNoScroll : _rightMarginScroll);
				if (_objectivesDynamicLayoutGroup.padding.left != num4 || _objectivesDynamicLayoutGroup.padding.right != num5)
				{
					_objectivesDynamicLayoutGroup.padding.left = num4;
					_objectivesDynamicLayoutGroup.padding.right = num5;
					_objectivesDynamicLayoutGroup.SetDirty();
				}
				((RectTransform)_objectivesListScrollbar.gameObject.transform).localScale = (flag2 ? Vector3.zero : Vector3.one);
			}
			else
			{
				_checkResizeScrollAreaPending = true;
			}
		}
	}
}
