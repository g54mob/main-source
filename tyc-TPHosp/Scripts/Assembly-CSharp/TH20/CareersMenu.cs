using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CareersMenu : AnimatedMenuBase
	{
		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private DynamicLayoutGroup _layoutGroup;

		[SerializeField]
		private GameObject _menuRowPrefab;

		[SerializeField]
		private DynamicButton _closeButton;

		private readonly Dictionary<MetagameObjective, CareersMenuRow> _rows = new Dictionary<MetagameObjective, CareersMenuRow>();

		private bool _eventsRegistered;

		private Metagame _metagame;

		private MetagameMap _metagameMap;

		private MetagameButtonsMenu _metagameButtonsMenu;

		private FoundationStatusMenu _foundationStatusMenu;

		public void Setup(MetagameMap metagameMap, MetagameButtonsMenu metagameButtonsMenu)
		{
			_metagame = metagameMap.Metagame;
			_metagameMap = metagameMap;
			_metagameButtonsMenu = metagameButtonsMenu;
			_foundationStatusMenu = metagameMap.HUD.FindMenu<FoundationStatusMenu>();
			_closeButton.onPrimaryDown.AddListener(OnClosePressed);
			RegisterEvents();
			InstantiateRows();
			Refresh();
		}

		private void OnDestroy()
		{
			_closeButton.onPrimaryDown.RemoveListener(OnClosePressed);
			foreach (KeyValuePair<MetagameObjective, CareersMenuRow> row in _rows)
			{
				UnityEngine.Object.Destroy(row.Value);
			}
			_rows.Clear();
		}

		private void RegisterEvents()
		{
			if (!_eventsRegistered)
			{
				base.OnClosed = (Action)Delegate.Combine(base.OnClosed, new Action(OnClosedEvent));
				HUDEvents hUDEvents = _metagameMap.HUDEvents;
				hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
				ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
				objectiveEvents.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Combine(objectiveEvents.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
				ObjectiveEvents objectiveEvents2 = _metagame.ObjectiveEvents;
				objectiveEvents2.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents2.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
				_eventsRegistered = true;
			}
		}

		protected override void Update()
		{
			base.Update();
			_scrollRect.content.sizeDelta = new Vector2(_scrollRect.content.sizeDelta.x, _layoutGroup.preferredHeight);
		}

		private void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
			RefreshObjective(subGoal.GetOwnerObjective() as MetagameObjective);
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			RefreshObjective(objective as MetagameObjective);
		}

		private void OnClosePressed()
		{
			_metagameButtonsMenu.OnCareerGoalsPressed();
		}

		private void UnregisterEvents()
		{
			if (_eventsRegistered)
			{
				base.OnClosed = (Action)Delegate.Remove(base.OnClosed, new Action(OnClosedEvent));
				HUDEvents hUDEvents = _metagameMap.HUDEvents;
				hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
				ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
				objectiveEvents.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Remove(objectiveEvents.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
				ObjectiveEvents objectiveEvents2 = _metagame.ObjectiveEvents;
				objectiveEvents2.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents2.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
				_eventsRegistered = false;
			}
		}

		private void OnMenuOpen(MenuBase menuBase)
		{
			if (menuBase != this)
			{
				CloseMenu();
			}
		}

		private void OnClosedEvent()
		{
			UnregisterEvents();
		}

		private void RefreshObjective(MetagameObjective objective)
		{
			if (objective != null && _rows.TryGetValue(objective, out var value))
			{
				value.Setup(objective, this, _metagameMap);
			}
		}

		public void Refresh()
		{
			foreach (KeyValuePair<MetagameObjective, CareersMenuRow> row in _rows)
			{
				MetagameObjective key = row.Key;
				CareersMenuRow value = row.Value;
				if (!key.ShouldBeDisplayed())
				{
					GameObjectUtils.SetActive(value.gameObject, isActive: false);
					continue;
				}
				GameObjectUtils.SetActive(value.gameObject, isActive: true);
				value.Setup(key, this, _metagameMap);
			}
			_metagameButtonsMenu.RefreshCareerMenuNotification();
			_foundationStatusMenu.Refresh();
		}

		private void InstantiateRows()
		{
			foreach (MetagameObjective objective in _metagame.ObjectiveManager.Objectives)
			{
				if (!objective.MetagameObjectiveDefinition.HideFromUI && !_rows.TryGetValue(objective, out var value))
				{
					value = UnityEngine.Object.Instantiate(_menuRowPrefab, _scrollRect.content.transform, worldPositionStays: false).GetComponent<CareersMenuRow>();
					value.Setup(objective, this, _metagameMap);
					_rows.Add(objective, value);
				}
			}
		}
	}
}
