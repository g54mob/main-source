using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class AmbulanceStatus : MonoBehaviour
	{
		[SerializeField]
		private GameObject _jobRoot;

		[SerializeField]
		private GameObject _activeRoot;

		[SerializeField]
		private Image _doctorImage;

		[SerializeField]
		private Image _doctorQualificationImage;

		[SerializeField]
		private Image _priorityJobImage;

		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private TMP_Text _statusText;

		[SerializeField]
		private TMP_Text _etaText;

		[SerializeField]
		private ProgressBarMaskable _progress;

		[SerializeField]
		private InWorldHUDElement _inWorldHUDElement;

		[SerializeField]
		private float _iconYOffset = 2f;

		[SerializeField]
		private float cameraHeightToCull;

		[DontSave]
		private Transform _cameraTransform;

		private Level _level;

		private RoomItem _roomItem;

		private PlayerAmbulance _ambulance;

		private JobAmbulance _currentJob;

		private float _currentCameraHeight;

		private bool _forceVisible;

		private bool _destroyed;

		private const int SecondsPerMin = 60;

		public void Initialise(PlayerAmbulance ambulance, Level ownerLevel)
		{
			_level = ownerLevel;
			_ambulance = ambulance;
			_inWorldHUDElement.Position = _ambulance.AmbulanceItem.GetStatusIconPosition() + Vector3.up * _iconYOffset;
			_inWorldHUDElement.CanBeHidden = true;
			_level.HUD.AddElement(_inWorldHUDElement, _level.HUD.InWorldTransform);
			_nameText.text = _ambulance.Config.AmbulanceName.Translation;
			_etaText.text = string.Empty;
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Combine(buildEvents.OnCursorHoverStart, new Action<ICursorSelectable>(OnCursorHoverStart));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnCursorHoverOut = (Action<ICursorSelectable>)Delegate.Combine(buildEvents2.OnCursorHoverOut, new Action<ICursorSelectable>(OnCursorHoverOut));
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraZoom = (Action<float>)Delegate.Combine(cameraEvents.OnCameraZoom, new Action<float>(OnCameraZoom));
			_cameraTransform = _level.CameraLogic.CameraComponent?.transform;
			_currentCameraHeight = _cameraTransform?.position.y ?? 2.1474836E+09f;
			Update();
		}

		private void Update()
		{
			bool isActive = false;
			bool isActive2 = false;
			if (_destroyed)
			{
				return;
			}
			GameObjectUtils.SetActive(_jobRoot, isActive: false);
			GameObjectUtils.SetActive(_activeRoot, isActive: false);
			if ((_ambulance.IsBrokenDown || _ambulance.IsUndergoingMaintenance() || _ambulance.IsUndergoingUpgrade()) && !_ambulance.IsAwayFromLevel)
			{
				return;
			}
			if (!_ambulance.IsOnWorldMap)
			{
				_currentJob = ((_ambulance.CurrentlyUnassignedJobs.Count > 0) ? _ambulance.CurrentlyUnassignedJobs[0] : null);
				if (_currentJob == null)
				{
					return;
				}
				GameObjectUtils.SetActive(_jobRoot, isActive: true);
				isActive2 = _currentJob.HighPriority;
				isActive = true;
				SetQualificationIcon(_currentJob.RequiredQualification(), _doctorQualificationImage);
			}
			else if (_ambulance.IsAwayFromLevel && (_forceVisible || _currentCameraHeight < cameraHeightToCull))
			{
				GameObjectUtils.SetActive(_activeRoot, isActive: true);
				float num = _ambulance.Progress / 100f;
				if (_ambulance.CurrentState == Ambulance.State.ReturningToBase)
				{
					_progress.Direction = ProgressBarMaskable.ProgressDirection.RightToLeft;
					num = 1f - num;
				}
				else
				{
					_progress.Direction = ProgressBarMaskable.ProgressDirection.LeftToRight;
				}
				_progress.Progress = Mathf.Clamp01(num);
				int num2 = (int)(_ambulance.CalculateETA() * (1f - num));
				int num3 = num2 / 60;
				_etaText.text = string.Empty;
				if (num3 > 0)
				{
					_etaText.text = LocalizationManager.GetTranslation("TimeSpan/TimeSpan_Minutes_CS").Replace("{[MINUTES]}", num3.ToString()) + " ";
					num2 %= 60;
				}
				_etaText.text += LocalizationManager.GetTranslation("TimeSpan/TimeSpan_Seconds_CS").Replace("{[SECONDS]}", num2.ToString());
			}
			_statusText.text = GetStatusText();
			GameObjectUtils.SetActive(_doctorImage.gameObject, isActive);
			GameObjectUtils.SetActive(_priorityJobImage.gameObject, isActive2);
		}

		private void SetQualificationIcon(QualificationDefinition qualification, Image qualificationImage)
		{
			if (qualification == null)
			{
				GameObjectUtils.SetActive(qualificationImage.gameObject, isActive: false);
				return;
			}
			qualificationImage.sprite = qualification.Icon;
			GameObjectUtils.SetActive(qualificationImage.gameObject, isActive: true);
		}

		public string GetStatusText()
		{
			switch (_ambulance.CurrentState)
			{
			case Ambulance.State.MovingToEmergency:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_EnRoute;
			case Ambulance.State.AtEmergency:
			case Ambulance.State.RescuePatients:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_OnSite;
			case Ambulance.State.ReturningToBase:
			case Ambulance.State.WaitingForClearParkingRoute:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_Returning;
			default:
				return ScriptLocalization.Menu_AmbulanceStatus.Status_Available;
			}
		}

		public void Destroy()
		{
			_destroyed = true;
			_level.HUD.RemoveElement(_inWorldHUDElement);
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraZoom = (Action<float>)Delegate.Remove(cameraEvents.OnCameraZoom, new Action<float>(OnCameraZoom));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Remove(buildEvents.OnCursorHoverStart, new Action<ICursorSelectable>(OnCursorHoverStart));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnCursorHoverOut = (Action<ICursorSelectable>)Delegate.Remove(buildEvents2.OnCursorHoverOut, new Action<ICursorSelectable>(OnCursorHoverOut));
			GameObjectUtils.SetActive(_jobRoot, isActive: false);
			GameObjectUtils.SetActive(_activeRoot, isActive: false);
		}

		private void OnCursorHoverStart(ICursorSelectable obj)
		{
			if (obj == _ambulance.AmbulanceItem)
			{
				_forceVisible = true;
			}
		}

		private void OnCursorHoverOut(ICursorSelectable obj)
		{
			if (obj == _ambulance.AmbulanceItem)
			{
				_forceVisible = false;
			}
		}

		private void OnCameraZoom(float obj)
		{
			if (_cameraTransform == null)
			{
				_cameraTransform = _level.CameraLogic.CameraComponent?.transform;
				if (_cameraTransform == null)
				{
					return;
				}
			}
			_currentCameraHeight = _cameraTransform.position.y;
		}

		public void UpdatePosition()
		{
			_inWorldHUDElement.Position = _ambulance.AmbulanceItem.GetStatusIconPosition() + Vector3.up * _iconYOffset;
		}
	}
}
