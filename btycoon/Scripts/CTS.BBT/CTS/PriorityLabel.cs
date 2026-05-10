using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class PriorityLabel : MonoBehaviour
	{
		[SerializeField]
		private Image[] _taskIcon;

		[SerializeField]
		private TMP_Text _taskText;

		[SerializeField]
		private Toggle _activateToogle;

		[SerializeField]
		private Image _rectangleImage;

		[SerializeField]
		private Sprite _activedRectangle;

		[SerializeField]
		private Sprite _desactivedRectangle;

		private ChoreIcon? _choreIcon;

		private Draggable_Button _draggable_button;

		private ChoreCategory _chore;

		private ToolTipsShower _toolTips;

		private bool _isChoreActived;

		public bool IsChoreActived
		{
			get
			{
				return _isChoreActived;
			}
			set
			{
				_isChoreActived = value;
				_draggable_button.ManuallyDraggable = value;
				_activateToogle.onValueChanged.RemoveListener(OnToggleChanged);
				_activateToogle.isOn = value;
				_activateToogle.onValueChanged.AddListener(OnToggleChanged);
				_rectangleImage.sprite = (value ? _activedRectangle : _desactivedRectangle);
				for (int i = 0; i < _taskIcon.Length; i++)
				{
					_taskIcon[i].enabled = _activateToogle.isOn;
				}
			}
		}

		public bool IsOn
		{
			get
			{
				return _activateToogle.isOn;
			}
			set
			{
				if (_activateToogle.isOn != value)
				{
					_activateToogle.isOn = value;
					OnToggleChanged(_activateToogle.isOn);
				}
			}
		}

		public ChoreCategory Chore
		{
			get
			{
				return _chore;
			}
			set
			{
				_chore = value;
				LocalizationSettings_SelectedLocaleChanged(null);
			}
		}

		public Sprite SetSprite
		{
			set
			{
				for (int i = 0; i < _taskIcon.Length; i++)
				{
					_taskIcon[i].sprite = value;
				}
			}
		}

		public bool Interactable
		{
			get
			{
				return _activateToogle.interactable;
			}
			set
			{
				_activateToogle.interactable = value;
			}
		}

		public event Action<Priority> onToggleChanged;

		private void Awake()
		{
			_draggable_button = GetComponent<Draggable_Button>();
			_toolTips = GetComponent<ToolTipsShower>();
			Draggable_Button draggable_button = _draggable_button;
			draggable_button.onSlotPositionChanged = (Action<int>)Delegate.Combine(draggable_button.onSlotPositionChanged, new Action<int>(SetPositionText));
			_activateToogle.onValueChanged.AddListener(OnToggleChanged);
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		public void Init(ChoreIcon? choreIcon)
		{
			_choreIcon = choreIcon.Value;
			if (_choreIcon.HasValue)
			{
				LocalizationSettings_SelectedLocaleChanged(null);
				SetSprite = choreIcon.Value.icon;
			}
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			if (_choreIcon.HasValue)
			{
				_taskText.text = _choreIcon.Value.choreTitle.GetLocalizedString();
				SetTooltipData(_choreIcon.Value.choreTitle, _choreIcon.Value.choreText);
			}
		}

		public void OnToggleChanged(bool p_actived)
		{
			for (int i = 0; i < _taskIcon.Length; i++)
			{
				_taskIcon[i].enabled = p_actived;
			}
			if (!p_actived)
			{
				_draggable_button.ManuallyDraggable = false;
				_draggable_button.SendToBack();
			}
			else
			{
				_draggable_button.ManuallyDraggable = true;
				List<Draggable_Button> getButtonList = _draggable_button.slotManager.GetButtonList;
				for (int num = getButtonList.Count - 2; num >= 0; num--)
				{
					PriorityLabel priorityLabel = getButtonList[num].PriorityLabel;
					if (priorityLabel != this && priorityLabel.IsChoreActived)
					{
						_draggable_button.SendTo(num + 1);
						_isChoreActived = p_actived;
						_rectangleImage.sprite = (_isChoreActived ? _activedRectangle : _desactivedRectangle);
						this.onToggleChanged?.Invoke(new Priority
						{
							category = _chore,
							isEnable = _isChoreActived
						});
						SetPositionText(GetComponent<Draggable_Button>().SlotPosition);
						return;
					}
				}
				_draggable_button.SendTo(0);
			}
			_isChoreActived = p_actived;
			_rectangleImage.sprite = (_isChoreActived ? _activedRectangle : _desactivedRectangle);
			this.onToggleChanged?.Invoke(new Priority
			{
				category = _chore,
				isEnable = _isChoreActived
			});
			SetPositionText(GetComponent<Draggable_Button>().SlotPosition);
		}

		private void SetPositionText(int p_position)
		{
		}

		private void SetTooltipData(LocalizedString title, LocalizedString text)
		{
			_toolTips.SetTootipsInfo(title, text);
		}
	}
}
