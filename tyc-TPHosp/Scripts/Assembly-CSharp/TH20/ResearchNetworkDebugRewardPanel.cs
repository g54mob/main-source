using System;
using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ResearchNetworkDebugRewardPanel : MonoBehaviour
	{
		private enum PickerResponseID
		{
			RoomItemPicker = 1,
			WallpaperPicker = 2,
			FlooringPicker = 3
		}

		public Action OnSavePressed;

		[SerializeField]
		private DynamicButton _saveButton;

		[SerializeField]
		private Toggle _kudoshToggle;

		[SerializeField]
		private TMP_InputField _kudoshInput;

		[SerializeField]
		private GameObject _kudoshDisablePanel;

		[SerializeField]
		private Toggle _roomItemToggle;

		[SerializeField]
		private DynamicButton _roomItemButton;

		[SerializeField]
		private Image _roomItemIcon;

		[SerializeField]
		private TMP_Text _roomItemName;

		[SerializeField]
		private GameObject _roomItemDisablePanel;

		[SerializeField]
		private Toggle _developerPromiseToggle;

		[SerializeField]
		private TMP_InputField _developerPromiseInput;

		[SerializeField]
		private TMP_Text _developerPromiseTranslationText;

		[SerializeField]
		private GameObject _developerPromiseDisablePanel;

		[SerializeField]
		private Toggle _wallpaperToggle;

		[SerializeField]
		private DynamicButton _wallpaperButton;

		[SerializeField]
		private Image _wallpaperIcon;

		[SerializeField]
		private TMP_Text _wallpaperName;

		[SerializeField]
		private GameObject _wallpaperDisablePanel;

		[SerializeField]
		private Toggle _flooringToggle;

		[SerializeField]
		private DynamicButton _flooringButton;

		[SerializeField]
		private Image _flooringIcon;

		[SerializeField]
		private TMP_Text _flooringName;

		[SerializeField]
		private GameObject _flooringDisablePanel;

		private SuperBugNode _node;

		private SharedInstance_TH20TH20_RoomItemDefinition _roomItemDefinition;

		private bool _isSettingUp;

		private void OnEnable()
		{
			_kudoshToggle.onValueChanged.AddListener(OnTogglePressed);
			_roomItemToggle.onValueChanged.AddListener(OnTogglePressed);
			_developerPromiseToggle.onValueChanged.AddListener(OnTogglePressed);
			_wallpaperToggle.onValueChanged.AddListener(OnTogglePressed);
			_flooringToggle.onValueChanged.AddListener(OnTogglePressed);
			_kudoshInput.onValueChanged.AddListener(OnKudoshChanged);
			_roomItemButton.onPrimaryDown.AddListener(OnRoomItemSelectPressed);
			_developerPromiseInput.onValueChanged.AddListener(OnDeveloperPromiseTextChanged);
			_wallpaperButton.onPrimaryDown.AddListener(OnWallpaperSelectPressed);
			_flooringButton.onPrimaryDown.AddListener(OnFlooringSelectPressed);
			_saveButton.onPrimaryDown.AddListener(OnSaveButtonPressed);
		}

		private void OnDisable()
		{
			_kudoshToggle.onValueChanged.AddListener(OnTogglePressed);
			_roomItemToggle.onValueChanged.AddListener(OnTogglePressed);
			_developerPromiseToggle.onValueChanged.AddListener(OnTogglePressed);
			_wallpaperToggle.onValueChanged.AddListener(OnTogglePressed);
			_flooringToggle.onValueChanged.AddListener(OnTogglePressed);
			_kudoshInput.onValueChanged.RemoveListener(OnKudoshChanged);
			_roomItemButton.onPrimaryDown.RemoveListener(OnRoomItemSelectPressed);
			_developerPromiseInput.onValueChanged.RemoveListener(OnDeveloperPromiseTextChanged);
			_wallpaperButton.onPrimaryDown.RemoveListener(OnWallpaperSelectPressed);
			_flooringButton.onPrimaryDown.RemoveListener(OnFlooringSelectPressed);
			_saveButton.onPrimaryDown.RemoveListener(OnSaveButtonPressed);
		}

		public void Show([NotNull] SuperBugNode node)
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
			_node = node;
			Setup();
		}

		private void Setup()
		{
			_isSettingUp = true;
			if (_node.Rewards == null)
			{
				RefreshEmpty();
				_isSettingUp = false;
				return;
			}
			_kudoshToggle.isOn = false;
			_roomItemToggle.isOn = false;
			_developerPromiseToggle.isOn = false;
			_wallpaperToggle.isOn = false;
			_flooringToggle.isOn = false;
			foreach (IRewardMetagame reward in _node.Rewards)
			{
				if (reward is RewardSilver)
				{
					RewardSilver rewardSilver = reward as RewardSilver;
					_kudoshInput.text = rewardSilver.Amount.ToString();
					_kudoshToggle.isOn = true;
				}
				else if (reward is RewardRoomItemMetagame)
				{
					RewardRoomItemMetagame rewardRoomItemMetagame = reward as RewardRoomItemMetagame;
					_roomItemDefinition = rewardRoomItemMetagame.Definition as SharedInstance_TH20TH20_RoomItemDefinition;
					if (_roomItemDefinition != null && !_roomItemDefinition.IsNull())
					{
						_roomItemIcon.overrideSprite = _roomItemDefinition.Instance.GetIcon();
						_roomItemName.text = _roomItemDefinition.Instance.GetLocalisedName();
					}
					else
					{
						_roomItemIcon.overrideSprite = null;
						_roomItemName.text = string.Empty;
					}
					_roomItemToggle.isOn = true;
				}
				else if (reward is RewardDeveloperPromise)
				{
					RewardDeveloperPromise rewardDeveloperPromise = reward as RewardDeveloperPromise;
					_developerPromiseInput.text = rewardDeveloperPromise.PromiseText;
					LocalizationManager.TryGetTranslation(_developerPromiseInput.text, out var Translation);
					_developerPromiseTranslationText.text = Translation;
					_developerPromiseToggle.isOn = true;
				}
			}
			_isSettingUp = false;
			OnTogglePressed(value: false);
		}

		private void RefreshEmpty()
		{
			_kudoshToggle.isOn = false;
			_roomItemToggle.isOn = false;
			_developerPromiseToggle.isOn = false;
			_wallpaperToggle.isOn = false;
			_flooringToggle.isOn = false;
			GameObjectUtils.SetActive(_kudoshDisablePanel, isActive: true);
			GameObjectUtils.SetActive(_roomItemDisablePanel, isActive: true);
			GameObjectUtils.SetActive(_developerPromiseDisablePanel, isActive: true);
			GameObjectUtils.SetActive(_wallpaperDisablePanel, isActive: true);
			GameObjectUtils.SetActive(_flooringDisablePanel, isActive: true);
			_roomItemIcon.overrideSprite = null;
			_roomItemName.text = string.Empty;
			_developerPromiseTranslationText.text = string.Empty;
			_developerPromiseInput.text = string.Empty;
			_wallpaperIcon.overrideSprite = null;
			_wallpaperName.text = string.Empty;
			_flooringIcon.overrideSprite = null;
			_flooringName.text = string.Empty;
		}

		private void OnKudoshChanged(string value)
		{
		}

		private void OnRoomItemSelectPressed()
		{
		}

		private void OnDeveloperPromiseTextChanged(string value)
		{
		}

		private void OnWallpaperSelectPressed()
		{
		}

		private void OnFlooringSelectPressed()
		{
		}

		private void SaveState()
		{
			if (_kudoshToggle.isOn && !_kudoshInput.text.IsNullOrEmpty())
			{
				if (int.TryParse(_kudoshInput.text, out var result))
				{
					AddOrReplaceReward(RewardSilver.Create(result));
				}
			}
			else
			{
				RemoveReward<RewardSilver>();
			}
			if (_roomItemToggle.isOn && _roomItemDefinition != null)
			{
				AddOrReplaceReward(RewardRoomItemMetagame.Create(_roomItemDefinition));
			}
			else
			{
				RemoveReward<RewardRoomItemMetagame>();
			}
			if (_developerPromiseToggle.isOn && !_developerPromiseInput.text.IsNullOrEmpty())
			{
				AddOrReplaceReward(RewardDeveloperPromise.Create(_developerPromiseInput.text));
			}
			else
			{
				RemoveReward<RewardDeveloperPromise>();
			}
		}

		private void OnSaveButtonPressed()
		{
			SaveState();
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
			OnSavePressed.InvokeSafe();
		}

		private void OnTogglePressed(bool value)
		{
			if (!_isSettingUp)
			{
				GameObjectUtils.SetActive(_kudoshDisablePanel, !_kudoshToggle.isOn);
				GameObjectUtils.SetActive(_roomItemDisablePanel, !_roomItemToggle.isOn);
				GameObjectUtils.SetActive(_developerPromiseDisablePanel, !_developerPromiseToggle.isOn);
				GameObjectUtils.SetActive(_wallpaperDisablePanel, !_wallpaperToggle.isOn);
				GameObjectUtils.SetActive(_flooringDisablePanel, !_flooringToggle.isOn);
			}
		}

		private T FindRewardInCollection<T>() where T : IRewardMetagame
		{
			if (_node.Rewards == null)
			{
				return null;
			}
			foreach (IRewardMetagame reward in _node.Rewards)
			{
				if (reward is T)
				{
					return reward as T;
				}
			}
			return null;
		}

		private void AddOrReplaceReward<T>(T reward) where T : IRewardMetagame
		{
			if (_node.Rewards == null)
			{
				_node.Rewards = new List<IRewardMetagame>();
			}
			RemoveReward<T>();
			_node.Rewards.Add(reward);
		}

		private void RemoveReward<T>() where T : IRewardMetagame
		{
			if (_node.Rewards != null)
			{
				T val = FindRewardInCollection<T>();
				if (val != null)
				{
					_node.Rewards.Remove(val);
				}
			}
		}
	}
}
