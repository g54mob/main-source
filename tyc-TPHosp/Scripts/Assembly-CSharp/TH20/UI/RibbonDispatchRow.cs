using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class RibbonDispatchRow : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private TMP_Text _statusText;

		[SerializeField]
		private TMP_Text _etaText;

		[SerializeField]
		private Image _ambulanceIcon;

		[SerializeField]
		private ProgressBarMaskable _maintenanceProgress;

		[SerializeField]
		private RectTransform _iconHoverRect;

		[SerializeField]
		private DynamicButton _assignButton;

		[SerializeField]
		private Sprite _assignButtonSprite;

		[SerializeField]
		private Sprite _unassignButtonSprite;

		[SerializeField]
		private Sprite _reassignButtonSprite;

		[SerializeField]
		private LocalisedString _assignButtonLabel;

		[SerializeField]
		private LocalisedString _unassignButtonLabel;

		[SerializeField]
		private LocalisedString _reassignButtonLabel;

		[SerializeField]
		private GameObject _tutorialCircle;

		[SerializeField]
		private GameObject _infoPanel;

		[SerializeField]
		private TMP_Text _infoText;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private float _unassignableAlpha = 0.5f;

		public Action<RibbonDispatchRow> OnAmbulanceSelected;

		public Action<RibbonDispatchRow, AmbulanceSelectionMenu.AssignButtonMode> OnAssignClicked;

		private PlayerAmbulance _ambulance;

		private ChallengeAmbulanceEmergency _challengeAmbulanceEmergency;

		private bool _isJourneyFutile;

		private AmbulanceSelectionMenu.AssignButtonMode _assignButtonMode;

		private ButtonAnimator _assignButtonAnimator;

		private bool _currentlySelected;

		private const float MaxMaintenanceValue = 100f;

		private const int SecondsPerMin = 60;

		public Ambulance Ambulance => _ambulance;

		public bool IsAssignable
		{
			get
			{
				if (_assignButtonMode != AmbulanceSelectionMenu.AssignButtonMode.Assign)
				{
					return _assignButtonMode == AmbulanceSelectionMenu.AssignButtonMode.Reassign;
				}
				return true;
			}
		}

		public void Setup(PlayerAmbulance ambulance, ChallengeAmbulanceEmergency emergency)
		{
			_ambulance = ambulance;
			_challengeAmbulanceEmergency = emergency;
			_assignButtonAnimator = _assignButton.GetComponent<ButtonAnimator>();
			base.transform.position = Vector3.zero;
			_infoPanel.SetActive(value: false);
			_infoText.text = ambulance.Config.AmbulanceFunction.Translation;
			UpdateRowInformation();
			UpdateLiveInformation();
			RegisterEvents();
		}

		public void OnDestroy()
		{
			UnregisterEvents();
		}

		private void RegisterEvents()
		{
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			_assignButton.onPrimaryDown.AddListener(SelectRowForAssignment);
		}

		private void UnregisterEvents()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			_assignButton.onPrimaryDown.RemoveAllListeners();
		}

		private void OnLocalize()
		{
			RefreshAssignable();
			UpdateRowInformation();
			UpdateLiveInformation();
		}

		public void SelectRowForInformation()
		{
			if (_ambulance != null)
			{
				OnAmbulanceSelected.InvokeSafe(this);
			}
		}

		public void SelectRowForAssignment()
		{
			if (_assignButtonMode != AmbulanceSelectionMenu.AssignButtonMode.Inactive)
			{
				_challengeAmbulanceEmergency.Level.ChallengeManager.OnSetPathSatNav.InvokeSafe(param: true);
				OnAssignClicked.InvokeSafe(this, _assignButtonMode);
			}
		}

		public void DeselectRow()
		{
		}

		private void UpdateRowInformation()
		{
			_nameText.text = _ambulance.Config.AmbulanceName.Translation;
			_etaText.text = string.Empty;
			int num = (int)_ambulance.CalculateETA(_challengeAmbulanceEmergency);
			int num2 = num / 60;
			if (num2 > 0)
			{
				_etaText.text = LocalizationManager.GetTranslation("TimeSpan/TimeSpan_Minutes_CS").Replace("{[MINUTES]}", num2.ToString()) + " ";
				num %= 60;
			}
			_etaText.text += LocalizationManager.GetTranslation("TimeSpan/TimeSpan_Seconds_CS").Replace("{[SECONDS]}", num.ToString());
			_ambulanceIcon.overrideSprite = _ambulance.Config.UISelectionSprite;
		}

		public void UpdateLiveInformation()
		{
			RefreshAssignable();
			_statusText.text = GetStatus();
			_maintenanceProgress.Progress = Mathf.Clamp01((100f - _ambulance.MaintenanceLevel) / 100f);
			CheckIsSelected();
			_infoPanel.SetActive(_currentlySelected);
			_ambulance.ShouldHighlight = _currentlySelected;
		}

		private void CheckIsSelected()
		{
			Rect screenSpaceRect = _iconHoverRect.GetScreenSpaceRect();
			Vector2 mousePos = _ambulance.Owner.Level.InputManager.GetMousePos();
			mousePos.y = (float)Screen.height - mousePos.y;
			if (screenSpaceRect.Contains(mousePos))
			{
				_currentlySelected = true;
			}
			else
			{
				_currentlySelected = false;
			}
		}

		private void RefreshAssignable()
		{
			bool flag = _ambulance.AmbulanceEmergency != null && _ambulance.AmbulanceEmergency == _challengeAmbulanceEmergency && _ambulance.QueuedEmergency == null && !_ambulance.UnassignOnReturn;
			if (_ambulance.CanBeAssignedTo(_challengeAmbulanceEmergency, includeReassign: false))
			{
				_assignButtonMode = AmbulanceSelectionMenu.AssignButtonMode.Assign;
				_assignButton.image.sprite = _assignButtonSprite;
				_assignButton.SetTMPText(_assignButtonLabel.Translation);
			}
			else if (_ambulance.CanBeAssignedTo(_challengeAmbulanceEmergency, includeReassign: true))
			{
				_assignButtonMode = AmbulanceSelectionMenu.AssignButtonMode.Reassign;
				_assignButton.image.sprite = _reassignButtonSprite;
				_assignButton.SetTMPText(_reassignButtonLabel.Translation);
			}
			else if (flag)
			{
				_assignButtonMode = AmbulanceSelectionMenu.AssignButtonMode.Unassign;
				_assignButton.image.sprite = _unassignButtonSprite;
				_assignButton.SetTMPText(_unassignButtonLabel.Translation);
			}
			else
			{
				_assignButtonMode = AmbulanceSelectionMenu.AssignButtonMode.Inactive;
			}
			bool flag2 = _assignButtonMode != AmbulanceSelectionMenu.AssignButtonMode.Inactive;
			_assignButton.interactable = flag2;
			_assignButtonAnimator.CurrentState = ((!flag2) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
		}

		private string GetStatus()
		{
			if (_ambulance.IsBrokenDown)
			{
				return ScriptLocalization.Menu_AmbulanceStatus.Status_BrokenDown;
			}
			if (_challengeAmbulanceEmergency.IsJourneyFutile(_ambulance))
			{
				return ScriptLocalization.Menu_AmbulanceStatus.Status_JourneyFutile;
			}
			if (_assignButtonMode == AmbulanceSelectionMenu.AssignButtonMode.Assign)
			{
				return ScriptLocalization.Menu_AmbulanceStatus.Status_Available;
			}
			switch (_ambulance.CurrentState)
			{
			case Ambulance.State.GettingReady:
			case Ambulance.State.ReadyToLeave:
			case Ambulance.State.WaitingForClearExitRoute:
			case Ambulance.State.VisuallyLeavingBase:
			case Ambulance.State.MovingToEmergency:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_EnRoute;
			case Ambulance.State.AtEmergency:
			case Ambulance.State.RescuePatients:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_OnSite;
			case Ambulance.State.ReturningToBase:
			case Ambulance.State.WaitingForClearParkingRoute:
			case Ambulance.State.VisuallyReturning:
			case Ambulance.State.AtHospital:
			case Ambulance.State.Parking:
			case Ambulance.State.UnloadingStaff:
			case Ambulance.State.UnloadingPatients:
			case Ambulance.State.ApplyWearAndTear:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_Returning;
			case Ambulance.State.Maintenance:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_Maintenance;
			default:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_Available;
			}
		}

		public void CircleAssignButton(bool active)
		{
			GameObjectUtils.SetActive(_tutorialCircle, active);
		}
	}
}
