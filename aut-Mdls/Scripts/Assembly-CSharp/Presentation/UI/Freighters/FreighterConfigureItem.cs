#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Freighter;
using Data.FactoryFloor.Freighter.Actions;
using Presentation.Locators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.Freighters
{
	public class FreighterConfigureItem : MonoBehaviour
	{
		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private ReferenceObjectDatabase _referenceObjectDatabase;

		[SerializeField]
		private TextMeshProUGUI _indexText;

		[SerializeField]
		private Image _warningIcon;

		[SerializeField]
		private TMP_Dropdown _freightHubDropdown;

		[SerializeField]
		private FreighterActionCycleButton[] _actionButtons;

		[SerializeField]
		private FreightHubInventorySlotDisplay[] _freightHubInventorySlots;

		[SerializeField]
		private FreighterSlotActionsDatabase _slotActionsDatabase;

		[SerializeField]
		private Button _removeButton;

		[SerializeField]
		private Button _locateButton;

		private FreighterPathBehaviour _freighterPathBehaviour;

		private FreighterStopConfiguration _freighterStopConfiguration;

		private bool _missingFreightHub;

		private int _stopIndex;

		private List<TMP_Dropdown.OptionData> _dropdownOptions;

		private List<TMP_Dropdown.OptionData> _missingDropdownOptions;

		private Action<int> _changedStopCallback;

		private Action<int> _removeStopCallback;

		private Dictionary<int, int> _freightHubReferenceIdToOptionIndex;

		private string _missingErrorString;

		public void Awake()
		{
			for (int i = 0; i < _actionButtons.Length; i++)
			{
				_actionButtons[i].Setup(_slotActionsDatabase.Actions);
				FreighterActionCycleButton obj = _actionButtons[i];
				obj.OnActionChanged = (Action<int>)Delegate.Combine(obj.OnActionChanged, new Action<int>(OnActionValueChanged));
			}
			_freightHubDropdown.onValueChanged.AddListener(OnFreightHubValueChanged);
			_removeButton.onClick.AddListener(OnRemoveButtonClicked);
			_locateButton.onClick.AddListener(OnLocateButtonClicked);
			LocalizationUtility.OnLanguageUpdate += SetTexts;
			SetTexts();
		}

		private void OnDestroy()
		{
			_freightHubDropdown.onValueChanged.RemoveListener(OnFreightHubValueChanged);
			for (int i = 0; i < _actionButtons.Length; i++)
			{
				FreighterActionCycleButton obj = _actionButtons[i];
				obj.OnActionChanged = (Action<int>)Delegate.Remove(obj.OnActionChanged, new Action<int>(OnActionValueChanged));
			}
			_removeButton.onClick.RemoveListener(OnRemoveButtonClicked);
			_locateButton.onClick.RemoveListener(OnLocateButtonClicked);
			LocalizationUtility.OnLanguageUpdate -= SetTexts;
		}

		private void OnEnable()
		{
			FreightHubBehaviour.OnFreightHubsChanged += OnFreightHubsChanged;
		}

		private void OnDisable()
		{
			FreightHubBehaviour.OnFreightHubsChanged -= OnFreightHubsChanged;
		}

		public void Initalize(Dictionary<int, int> freightHubReferenceIdToOptionIndex, List<TMP_Dropdown.OptionData> freightHubOptions, Action<int> stopChangedCallback, Action<int> removeStopCallback)
		{
			_freightHubReferenceIdToOptionIndex = freightHubReferenceIdToOptionIndex;
			_dropdownOptions = freightHubOptions;
			_missingDropdownOptions = new List<TMP_Dropdown.OptionData>();
			_freightHubDropdown.options = freightHubOptions;
			_missingFreightHub = false;
			_changedStopCallback = stopChangedCallback;
			_removeStopCallback = removeStopCallback;
			_freightHubDropdown.interactable = true;
		}

		private void SetTexts()
		{
			_missingErrorString = LocalizationUtility.GetLocalizedText("FreightersUI.DropdownMissingError");
		}

		private void OnFreightHubsChanged()
		{
			UpdateDropdown();
		}

		private List<TMP_Dropdown.OptionData> GetUpdatedDropdownOptions()
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>(_dropdownOptions);
			for (int i = 0; i < list.Count; i++)
			{
				int freightHubRefIdAtDropdownIndex = GetFreightHubRefIdAtDropdownIndex(i);
				if (!_referenceObjectDatabase.TryGetObjectFromReferenceID(freightHubRefIdAtDropdownIndex, out var _))
				{
					list[i] = new TMP_Dropdown.OptionData(_missingErrorString ?? "");
				}
			}
			return list;
		}

		private void UpdateDropdown()
		{
			int freightHubRefIdAtDropdownIndex = GetFreightHubRefIdAtDropdownIndex(_freightHubDropdown.value);
			ReferenceFactoryObjectBehaviour referenceObject;
			bool flag = _referenceObjectDatabase.TryGetObjectFromReferenceID(freightHubRefIdAtDropdownIndex, out referenceObject);
			_missingFreightHub = !flag;
			_warningIcon.gameObject.SetActive(!flag);
			_freightHubDropdown.options = GetUpdatedDropdownOptions();
		}

		public void Populate(int stopIndex, FreighterPathBehaviour path)
		{
			ChangeStopIndex(stopIndex);
			_freighterPathBehaviour = path;
			_freighterStopConfiguration = _freighterPathBehaviour.Stops[_stopIndex];
			int value;
			bool flag = _freightHubReferenceIdToOptionIndex.TryGetValue(_freighterStopConfiguration.freightHubReferenceId, out value);
			_missingFreightHub = !flag;
			_warningIcon.gameObject.SetActive(!flag);
			if (!flag)
			{
				_missingDropdownOptions.Clear();
				_missingDropdownOptions.AddRange(_dropdownOptions);
				_missingDropdownOptions.Insert(value, new TMP_Dropdown.OptionData(_missingErrorString ?? ""));
			}
			_freightHubDropdown.options = (flag ? _dropdownOptions : _missingDropdownOptions);
			_freightHubDropdown.SetValueWithoutNotify(value);
			for (int i = 0; i < _actionButtons.Length; i++)
			{
				if (i >= _freighterStopConfiguration.freighterDockSlotActions.Length)
				{
					_actionButtons[i].SetValueWithoutNotify(0);
				}
				else
				{
					_actionButtons[i].SetValueWithoutNotify(_freighterStopConfiguration.freighterDockSlotActions[i].DatabaseIndex);
				}
			}
			PopulateFreightHubCargo(path.Stops[stopIndex].freightHubReferenceId);
		}

		public void PopulateEmpty(int stopIndex, FreighterPathBehaviour path)
		{
			ChangeStopIndex(stopIndex);
			_freighterPathBehaviour = path;
			_freightHubDropdown.SetValueWithoutNotify(0);
			for (int i = 0; i < _actionButtons.Length; i++)
			{
				_actionButtons[i].SetValueWithoutNotify(0);
			}
			_freightHubDropdown.interactable = true;
			_freightHubDropdown.options = _dropdownOptions;
			_missingFreightHub = _freightHubReferenceIdToOptionIndex.IsNullOrEmpty();
			_warningIcon.gameObject.SetActive(_missingFreightHub);
			for (int j = 0; j < _freightHubInventorySlots.Length; j++)
			{
				_freightHubInventorySlots[j].Reset();
			}
		}

		private void PopulateFreightHubCargo(int freighterReferenceId)
		{
			if (_referenceObjectDatabase.TryGetObjectFromReferenceID(freighterReferenceId, out var referenceObject))
			{
				if (referenceObject.FactoryObject.TryGetFactoryObjectBehaviour<FreightHubBehaviour>(out var behaviour))
				{
					for (int i = 0; i < _freightHubInventorySlots.Length; i++)
					{
						_freightHubInventorySlots[i].SetFreightHub(behaviour);
					}
				}
			}
			else
			{
				for (int j = 0; j < _freightHubInventorySlots.Length; j++)
				{
					_freightHubInventorySlots[j].Reset();
				}
			}
		}

		public bool IsStopConfigurationValid()
		{
			return !_missingFreightHub;
		}

		public FreighterStopConfiguration CreateStopConfiguration()
		{
			int num = (_missingFreightHub ? (_freightHubDropdown.value - 1) : _freightHubDropdown.value);
			FreighterSlotAction[] array = new FreighterSlotAction[_actionButtons.Length];
			for (int i = 0; i < _actionButtons.Length; i++)
			{
				int value = _actionButtons[i].Value;
				array[i] = _slotActionsDatabase.Actions[value];
			}
			foreach (KeyValuePair<int, int> item in _freightHubReferenceIdToOptionIndex)
			{
				if (item.Value == num)
				{
					return new FreighterStopConfiguration
					{
						freightHubReferenceId = item.Key,
						freighterDockSlotActions = array
					};
				}
			}
			this.DevException(string.Format("Failed: Dropdown value {0} was not found in {1}", num, "_freightHubReferenceIdToOptionIndex"), "CreateStopConfiguration", 230);
			return null;
		}

		private bool TryGetSelectedFreightHub(out int freightHubReferenceId)
		{
			int num = (_missingFreightHub ? (_freightHubDropdown.value - 1) : _freightHubDropdown.value);
			foreach (KeyValuePair<int, int> item in _freightHubReferenceIdToOptionIndex)
			{
				if (item.Value == num)
				{
					freightHubReferenceId = item.Key;
					return true;
				}
			}
			freightHubReferenceId = -1;
			return false;
		}

		private int GetFreightHubRefIdAtDropdownIndex(int index)
		{
			foreach (KeyValuePair<int, int> item in _freightHubReferenceIdToOptionIndex)
			{
				if (item.Value == index)
				{
					return item.Key;
				}
			}
			return -1;
		}

		public void ChangeStopIndex(int stopIndex)
		{
			_stopIndex = stopIndex;
			_indexText.SetText($"{_stopIndex + 1}.");
		}

		private void OnFreightHubValueChanged(int index)
		{
			_changedStopCallback(_stopIndex);
			if (TryGetSelectedFreightHub(out var freightHubReferenceId))
			{
				PopulateFreightHubCargo(freightHubReferenceId);
			}
		}

		private void OnActionValueChanged(int _)
		{
			_changedStopCallback(_stopIndex);
		}

		private void OnRemoveButtonClicked()
		{
			_removeStopCallback(_stopIndex);
		}

		private void OnLocateButtonClicked()
		{
			if (TryGetSelectedFreightHub(out var freightHubReferenceId) && _referenceObjectDatabase.TryGetObjectFromReferenceID(freightHubReferenceId, out var referenceObject))
			{
				_cameraViewLocator.CameraView.LerpToTarget(referenceObject.Position, blockInput: false);
				_cameraViewLocator.CameraView.SetIsFollowingTarget();
			}
		}
	}
}
