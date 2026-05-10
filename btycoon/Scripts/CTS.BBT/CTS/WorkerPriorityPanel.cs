using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class WorkerPriorityPanel : AbsAgentPanel
	{
		private SlotManager _slotManager;

		[SerializeField]
		private Draggable_Button _buttonSlotPrefab;

		[SerializeField]
		private ChoreIcon[] choreIcons;

		[SerializeField]
		private Button _resetButton;

		[SerializeField]
		private Toggle _autonomyToggle;

		[SerializeField]
		private float buttonSize = 89f;

		[SerializeField]
		private Transform _buttonsContainer;

		[SerializeField]
		private Image _disabledPanel;

		[SerializeField]
		private RectTransform _containerRectTransform;

		private List<ChoreCategory> categories;

		private readonly List<PriorityLabel> _buttons = new List<PriorityLabel>();

		public void HighlightAutonomy(bool isActive)
		{
			if (CTSSingleton<Highlighter>.InstanceExists())
			{
				if (isActive)
				{
					CTSSingleton<Highlighter>.Instance.Highlight((RectTransform)_autonomyToggle.transform);
				}
				else
				{
					CTSSingleton<Highlighter>.Instance.StopHighlight((RectTransform)_autonomyToggle.transform);
				}
			}
		}

		public void HighlightCategory(ChoreCategory category)
		{
			if (!CTSSingleton<Highlighter>.InstanceExists())
			{
				return;
			}
			foreach (PriorityLabel button in _buttons)
			{
				if (button.Chore == category)
				{
					CTSSingleton<Highlighter>.Instance.Highlight((RectTransform)button.transform);
				}
			}
		}

		public void StopHighlightCategory(ChoreCategory category)
		{
			if (!CTSSingleton<Highlighter>.InstanceExists())
			{
				return;
			}
			foreach (PriorityLabel button in _buttons)
			{
				if (button.Chore == category)
				{
					CTSSingleton<Highlighter>.Instance.StopHighlight((RectTransform)button.transform);
				}
			}
		}

		protected override void Awake()
		{
			base.Awake();
			_slotManager = GetComponentInChildren<SlotManager>();
			SlotManager slotManager = _slotManager;
			slotManager.onReorganised = (Action)Delegate.Combine(slotManager.onReorganised, new Action(OnListChanged));
			_autonomyToggle.onValueChanged.AddListener(OnToggleAutonomy);
			_resetButton.onClick.AddListener(OnReset);
			if (categories == null)
			{
				categories = ((ChoreCategory[])Enum.GetValues(typeof(ChoreCategory))).ToList();
				categories.Remove(ChoreCategory.Default);
			}
			base.RectTransform.sizeDelta = new Vector2(base.RectTransform.sizeDelta.x, 120f + buttonSize * (float)categories.Count);
		}

		private void Start()
		{
			foreach (ChoreCategory category in categories)
			{
				Draggable_Button draggable_Button = UnityEngine.Object.Instantiate(_buttonSlotPrefab, _buttonsContainer);
				draggable_Button.PriorityLabel.Chore = category;
				ChoreIcon? choreInfo = GetChoreInfo(category);
				if (choreInfo.HasValue)
				{
					draggable_Button.PriorityLabel.Init(choreInfo);
				}
				draggable_Button.PriorityLabel.onToggleChanged += OnPriorityToggleChanged;
				_buttons.Add(draggable_Button.PriorityLabel);
				_slotManager.AddDraggableButton(draggable_Button);
			}
			OnWorkerGlobalAutonomyChanged(Worker.GlobalAutonomyEnabled);
			SetAgentInfo();
		}

		private void OnEnable()
		{
			Worker.CVarAutonomyEnabled.SubscribeToChange(OnWorkerGlobalAutonomyChanged);
			WorkerChoreAssigner.OnAutonomyActive += OnWorkerAutonomyChanged;
			WorkerChoreAssigner.OnPriorityStatusChanged += OnWorkerPriorityChanged;
			OnWorkerGlobalAutonomyChanged(Worker.GlobalAutonomyEnabled);
			if (!(base._agent is Worker worker))
			{
				return;
			}
			OnWorkerAutonomyChanged(worker, worker.ChoreAssigner.ObjectLock.IsUnlocked());
			foreach (ChoreCategory category in categories)
			{
				OnWorkerPriorityChanged(worker, category, worker.ChoreAssigner.TryGetPrioritySelfActive(category, out var selfEnabled) && selfEnabled);
			}
		}

		private void OnDisable()
		{
			Worker.CVarAutonomyEnabled.UnsubscribeToChange(OnWorkerGlobalAutonomyChanged);
			WorkerChoreAssigner.OnAutonomyActive -= OnWorkerAutonomyChanged;
			WorkerChoreAssigner.OnPriorityStatusChanged -= OnWorkerPriorityChanged;
		}

		protected override void OnDestroy()
		{
			foreach (PriorityLabel button in _buttons)
			{
				button.onToggleChanged -= OnPriorityToggleChanged;
			}
		}

		private void OnPriorityToggleChanged(Priority p_priority)
		{
			if (!(base._agent == null) && base._agent is Worker worker)
			{
				worker.ChoreAssigner.TogglePriority(p_priority.category, p_priority.isEnable);
			}
		}

		public override void SetAgentInfo()
		{
			if (!(base._agent is Worker worker))
			{
				return;
			}
			Priority[] array = new Priority[categories.Count];
			foreach (ChoreCategory category in categories)
			{
				if (worker.ChoreAssigner.TryGetPriority(category, out var selfEnabled, out var priority))
				{
					array[priority] = new Priority
					{
						isEnable = selfEnabled,
						isHided = false,
						category = category
					};
				}
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].category == ChoreCategory.Default)
				{
					array[i].isHided = true;
				}
			}
			foreach (PriorityLabel button in _buttons)
			{
				bool active = false;
				Priority[] array2 = array;
				for (int j = 0; j < array2.Length; j++)
				{
					Priority priority2 = array2[j];
					if (priority2.category == button.Chore)
					{
						active = !priority2.isHided;
						break;
					}
				}
				button.gameObject.SetActive(active);
			}
			_slotManager.ReorganiseFromWorker(array);
			OnWorkerAutonomyChanged(worker, worker.ChoreAssigner.ObjectLock.IsUnlocked());
			foreach (ChoreCategory category2 in categories)
			{
				OnWorkerPriorityChanged(worker, category2, worker.ChoreAssigner.TryGetPrioritySelfActive(category2, out var selfEnabled2) && selfEnabled2);
			}
		}

		private bool IsHidedChore(ChoreCategory cat, Worker worker)
		{
			if (cat == ChoreCategory.Capture && !worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Hypnosis))
			{
				return true;
			}
			if (cat == ChoreCategory.Witnesses && !worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.ClearingMemory))
			{
				return true;
			}
			return false;
		}

		private void OnToggleAutonomy(bool toggleOn)
		{
			if (!(base._agent == null) && base._agent is Worker worker)
			{
				_disabledPanel.enabled = !toggleOn;
				_disabledPanel.rectTransform.sizeDelta = _containerRectTransform.sizeDelta;
				worker.ChoreAssigner.SetActive(toggleOn);
				_autonomyToggle.isOn = worker.ChoreAssigner.ObjectLock.IsUnlocked();
			}
		}

		private void OnReset()
		{
			if (!(base._agent is Worker worker))
			{
				return;
			}
			Priority[] array = new Priority[categories.Count];
			for (int i = 0; i < categories.Count; i++)
			{
				Priority priority = new Priority
				{
					isEnable = true,
					isHided = IsHidedChore(categories[i], worker),
					category = categories[i]
				};
				if (priority.category == ChoreCategory.Capture)
				{
					priority.isEnable = worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Hypnosis);
				}
				else if (priority.category == ChoreCategory.Witnesses)
				{
					priority.isEnable = worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.ClearingMemory);
				}
				array[i] = priority;
			}
			_slotManager.ReorganiseFromWorker(array);
			OnListChanged();
			for (int j = 0; j < _buttons.Count; j++)
			{
				_buttons[j].OnToggleChanged(array[j].isEnable);
			}
		}

		private Sprite GetChoreSprite(ChoreCategory p_chore)
		{
			for (int i = 0; i < choreIcons.Length; i++)
			{
				if (choreIcons[i].chore == p_chore)
				{
					return choreIcons[i].icon;
				}
			}
			return null;
		}

		private ChoreIcon? GetChoreInfo(ChoreCategory p_chore)
		{
			for (int i = 0; i < choreIcons.Length; i++)
			{
				if (choreIcons[i].chore == p_chore)
				{
					return choreIcons[i];
				}
			}
			return null;
		}

		private void OnListChanged()
		{
			if (!(base._agent == null) && base._agent is Worker worker)
			{
				List<Draggable_Button> getButtonList = _slotManager.GetButtonList;
				for (int i = 0; i < getButtonList.Count; i++)
				{
					worker.ChoreAssigner.SetCategoryPriority(getButtonList[i].PriorityLabel.Chore, i);
				}
			}
		}

		public override void ClearAgentInfo()
		{
		}

		private void OnWorkerPriorityChanged(Worker worker, ChoreCategory cat, bool value)
		{
			if (worker != base._agent)
			{
				return;
			}
			foreach (PriorityLabel button in _buttons)
			{
				if (button.Chore == cat)
				{
					button.IsOn = value;
				}
			}
		}

		private void OnWorkerAutonomyChanged(Worker worker, bool value)
		{
			if (!(worker != base._agent))
			{
				_autonomyToggle.isOn = value;
				_disabledPanel.enabled = !value || !Worker.GlobalAutonomyEnabled;
			}
		}

		private void OnWorkerGlobalAutonomyChanged(bool value)
		{
			_autonomyToggle.interactable = value;
			if ((bool)base._agent)
			{
				_disabledPanel.enabled = !value || base._agent.Cast<Worker>().ChoreAssigner.ObjectLock.IsLocked();
			}
			else
			{
				_disabledPanel.enabled = !value;
			}
			_resetButton.interactable = value;
		}
	}
}
