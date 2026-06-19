#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class AmbulanceSelectionMenu : MonoBehaviour
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Opening and Closing")]
			public float FullOpenPositionY;

			public float PartiallyOpenPositionY;

			public float HiddenPositionY;

			public SharedInstance<AnimationProperties> OpeningProperties;

			public SharedInstance<AnimationProperties> ClosingProperties;

			[InspectorDivider]
			[InspectorMargin(8)]
			[InspectorHeader("Ambulance Rows")]
			public GameObject RowPrefab;
		}

		private enum DisplayPosition
		{
			Full = 0,
			Partial = 1,
			Hide = 2
		}

		public enum AssignButtonMode
		{
			Assign = 0,
			Unassign = 1,
			Reassign = 2,
			Inactive = 3
		}

		[SerializeField]
		private DynamicButton _closeMenuButton;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _severityText;

		[SerializeField]
		private TMP_Text _descriptionText;

		[SerializeField]
		private TMP_Text _ambulanceCountText;

		[SerializeField]
		private Image _locationArtworkImage;

		[SerializeField]
		private Transform _rowParent;

		[SerializeField]
		private ScrollRect _scrollView;

		private Level _level;

		private Config _config;

		private RectTransformAnimator _rectTransformAnimator;

		private PlayerAmbulanceDepartment _ambulanceDepartment;

		private ChallengeAmbulanceEmergency _ambulanceEmergency;

		private List<RibbonDispatchRow> _dispatchRows = new List<RibbonDispatchRow>();

		private RibbonDispatchRow lastSelectedRow;

		private bool _updateLiveInformation;

		private RectTransform _rectTransform;

		private DisplayPosition _currentDisplayPosition;

		private Vector2 _positionToLerpFrom;

		private Vector2 _positionToLerpTo;

		public bool InActivePosition => _currentDisplayPosition == DisplayPosition.Full;

		public void Setup(Level level, Config config, PlayerAmbulanceDepartment ambulanceDepartment, RectTransformAnimator animator)
		{
			_level = level;
			_config = config;
			_ambulanceDepartment = ambulanceDepartment;
			_rectTransformAnimator = animator;
			_rectTransform = (RectTransform)base.transform;
			_currentDisplayPosition = DisplayPosition.Hide;
			_rectTransform.localPosition = GetPositionFromDisplayPosition(_currentDisplayPosition);
			_closeMenuButton.onPrimaryDown.AddListener(PeekSelectionMenu);
			CloseSelectionMenu();
			LocalizationManager.OnLocalizeEvent += OnLocalize;
		}

		private void OnLocalize()
		{
			UpdateEmergencyInformation();
		}

		public void OnDestroy()
		{
			_closeMenuButton.onPrimaryDown.RemoveAllListeners();
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
		}

		public void OpenSelectionMenu(ChallengeAmbulanceEmergency ambulanceEmergency)
		{
			if (_currentDisplayPosition != DisplayPosition.Full || _ambulanceEmergency != ambulanceEmergency)
			{
				_ambulanceEmergency = ambulanceEmergency;
				UpdateDisplayPosition(DisplayPosition.Full);
				_closeMenuButton.gameObject.SetActive(value: true);
				_locationArtworkImage.gameObject.SetActive(value: true);
				_updateLiveInformation = true;
				UpdateEmergencyInformation();
				UpdateRowInformation();
			}
		}

		public void PeekSelectionMenu()
		{
			if (InActivePosition)
			{
				_level.ChallengeManager.OnCloseSatNavSubMenu.InvokeSafe(param: true);
			}
			UpdateDisplayPosition(DisplayPosition.Partial);
			_closeMenuButton.gameObject.SetActive(value: false);
			_locationArtworkImage.gameObject.SetActive(value: false);
			_updateLiveInformation = false;
		}

		public void PeekSelectionMenu(ChallengeAmbulanceEmergency ambulanceEmergency)
		{
			if (ambulanceEmergency != null)
			{
				_ambulanceEmergency = ambulanceEmergency;
				UpdateEmergencyInformation();
			}
			UpdateDisplayPosition(DisplayPosition.Partial);
			_closeMenuButton.gameObject.SetActive(value: false);
			_locationArtworkImage.gameObject.SetActive(value: false);
			_updateLiveInformation = false;
			if (_dispatchRows.Count > 0)
			{
				RemoveAmbulanceRows();
			}
			InstantiateAmbulanceRows(_ambulanceEmergency);
		}

		public void CloseSelectionMenu()
		{
			_ambulanceEmergency = null;
			UpdateDisplayPosition(DisplayPosition.Hide);
			_closeMenuButton.gameObject.SetActive(value: false);
			_locationArtworkImage.gameObject.SetActive(value: false);
			_updateLiveInformation = false;
		}

		private void Update()
		{
			if (_updateLiveInformation)
			{
				UpdateRowInformation();
				UpdateLiveInformation();
			}
		}

		private void InstantiateAmbulanceRows(ChallengeAmbulanceEmergency emergency)
		{
			if (emergency == null)
			{
				return;
			}
			foreach (PlayerAmbulance item in (from a in _ambulanceDepartment.Ambulances.Cast<PlayerAmbulance>().ToList()
				orderby !a.CanBeAssignedTo(emergency, includeReassign: false), !a.CanBeAssignedTo(emergency, includeReassign: true)
				select a).ThenBy((PlayerAmbulance ambulance) => ambulance.CalculateETA(emergency)).ToList())
			{
				if (item != null)
				{
					RibbonDispatchRow component = UnityEngine.Object.Instantiate(_config.RowPrefab, _rowParent).GetComponent<RibbonDispatchRow>();
					if (component != null)
					{
						component.Setup(item, emergency);
						_dispatchRows.Add(component);
						component.OnAmbulanceSelected = (Action<RibbonDispatchRow>)Delegate.Combine(component.OnAmbulanceSelected, new Action<RibbonDispatchRow>(OnRowAmbulanceSelected));
						component.OnAssignClicked = (Action<RibbonDispatchRow, AssignButtonMode>)Delegate.Combine(component.OnAssignClicked, new Action<RibbonDispatchRow, AssignButtonMode>(OnRowAssignClicked));
					}
				}
			}
			_scrollView.normalizedPosition = Vector2.up;
		}

		private void AutoSelectRow(RibbonDispatchRow row)
		{
			if (lastSelectedRow != null)
			{
				lastSelectedRow.DeselectRow();
				lastSelectedRow = null;
			}
			if (row != null)
			{
				lastSelectedRow = row;
			}
		}

		private void RemoveAmbulanceRows()
		{
			for (int num = _dispatchRows.Count - 1; num >= 0; num--)
			{
				RibbonDispatchRow ribbonDispatchRow = _dispatchRows[num];
				ribbonDispatchRow.OnAmbulanceSelected = (Action<RibbonDispatchRow>)Delegate.Remove(ribbonDispatchRow.OnAmbulanceSelected, new Action<RibbonDispatchRow>(OnRowAmbulanceSelected));
				RibbonDispatchRow ribbonDispatchRow2 = _dispatchRows[num];
				ribbonDispatchRow2.OnAssignClicked = (Action<RibbonDispatchRow, AssignButtonMode>)Delegate.Remove(ribbonDispatchRow2.OnAssignClicked, new Action<RibbonDispatchRow, AssignButtonMode>(OnRowAssignClicked));
				UnityEngine.Object.Destroy(_dispatchRows[num].gameObject);
			}
			_dispatchRows.Clear();
		}

		private void UpdateDisplayPosition(DisplayPosition targetDisplayPosition)
		{
			Vector3 positionFromDisplayPosition = GetPositionFromDisplayPosition(targetDisplayPosition);
			AnimationProperties animationProperties = ((targetDisplayPosition == DisplayPosition.Hide) ? _config.ClosingProperties.Instance : _config.OpeningProperties.Instance);
			_currentDisplayPosition = targetDisplayPosition;
			if (animationProperties != null)
			{
				_rectTransformAnimator.Animate(animationProperties.Curve, _rectTransform, positionFromDisplayPosition, Quaternion.identity, animationProperties.Duration, animationProperties.InterruptOtherAnimations);
				return;
			}
			Logging.Error(LogChannels.GUI, "Missing Animation Data: Skipping Animation");
			base.transform.localPosition = positionFromDisplayPosition;
		}

		private void UpdateEmergencyInformation()
		{
			if (_ambulanceEmergency != null)
			{
				_titleText.text = _ambulanceEmergency.Definition.NameLocalised.Translation;
				_severityText.text = _ambulanceEmergency.Definition.SeverityDisplayValue.ToString();
				_descriptionText.text = _ambulanceEmergency.Definition.DescriptionLocalised.Translation;
				_locationArtworkImage.sprite = _ambulanceEmergency.Definition.Location.Instance.LocationArtwork;
				UpdateLiveInformation();
			}
		}

		private void UpdateLiveInformation()
		{
			if (_dispatchRows != null)
			{
				int num = _dispatchRows.Count((RibbonDispatchRow row) => row.IsAssignable);
				int count = _dispatchRows.Count;
				_ambulanceCountText.text = num + "/" + count;
			}
		}

		private void UpdateRowInformation()
		{
			foreach (RibbonDispatchRow dispatchRow in _dispatchRows)
			{
				dispatchRow.UpdateLiveInformation();
			}
		}

		private void OnRowAmbulanceSelected(RibbonDispatchRow row)
		{
		}

		private void OnRowAssignClicked(RibbonDispatchRow row, AssignButtonMode mode)
		{
			if (_ambulanceEmergency != null)
			{
				PlayerAmbulance playerAmbulance = row.Ambulance as PlayerAmbulance;
				switch (mode)
				{
				case AssignButtonMode.Assign:
					_ambulanceEmergency.AssignAmbulance(row.Ambulance);
					row.Ambulance.BeginGettingReady();
					break;
				case AssignButtonMode.Reassign:
					playerAmbulance.QueueNewEmergency(_ambulanceEmergency);
					break;
				case AssignButtonMode.Unassign:
					playerAmbulance.UnassignNowOrOnReturn(_ambulanceEmergency);
					break;
				}
				row.UpdateLiveInformation();
			}
		}

		private Vector3 GetPositionFromDisplayPosition(DisplayPosition displayPosition)
		{
			Vector3 localPosition = _rectTransform.localPosition;
			switch (displayPosition)
			{
			case DisplayPosition.Full:
				localPosition.y = _config.FullOpenPositionY;
				break;
			case DisplayPosition.Partial:
				localPosition.y = _config.PartiallyOpenPositionY;
				break;
			case DisplayPosition.Hide:
				localPosition.y = _config.HiddenPositionY;
				break;
			default:
				localPosition.y = _config.HiddenPositionY;
				break;
			}
			return localPosition;
		}

		public RibbonDispatchRow CircleFirstAssignButton(bool active)
		{
			if (_dispatchRows == null || _dispatchRows.Count <= 0)
			{
				return null;
			}
			_dispatchRows[0].CircleAssignButton(active);
			return _dispatchRows[0];
		}
	}
}
