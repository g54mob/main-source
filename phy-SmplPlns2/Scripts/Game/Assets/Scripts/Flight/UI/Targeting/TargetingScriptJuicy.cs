using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Input;
using Jundroo.Common.Cache;
using Jundroo.Juicy.Widgets;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Targeting
{
	public class TargetingScriptJuicy : TargetingScript
	{
		private enum FireWeaponStateType
		{
			None = 0,
			ReadyToFire = 1,
			Active = 2
		}

		private Widget _centerReticle;

		private TextWidget _countermeasureLabel;

		private CachedIntString _countermeasureLabelCache = new CachedIntString((int x) => "x" + ((x > 99) ? "99+" : x.ToString()));

		private Widget _countermeasuresButton;

		private CustomController _customController;

		private Widget _fireButton;

		private TextWidget _fireButtonLabel;

		private CachedIntString _fireButtonLabelCache = new CachedIntString((int x) => "x" + ((x > 99) ? "99+" : x.ToString()));

		private FireWeaponStateType? _fireButtonState;

		private Widget _firePanel;

		private Widget _gunButton;

		private TextWidget _lockWarning;

		private ImageWidget _offscreenArrow;

		private Transform _offscreenIndicator;

		private TextWidget _offscreenLabel;

		private Widget _root;

		private Widget _targetBoxContainer;

		public override Transform OffscreenIndicator => _offscreenIndicator;

		public override void EnableOffscreenIndicator(Vector3 screenPosition, float angle, string name, string text, Color color)
		{
			_offscreenActive = true;
			screenPosition.z = 0f;
			_offscreenIndicator.localPosition = GetLocalPoint(screenPosition, _offscreenIndicator.parent.GetComponent<RectTransform>());
			_offscreenIndicator.localRotation = Quaternion.Euler(0f, 0f, angle);
			_offscreenArrow.Color.Base = 0.75f * color;
			_offscreenLabel.Text = name + "\n" + text;
			_offscreenLabel.Color.Base = color;
			_offscreenLabel.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - angle);
		}

		public void Initialize(FlightUIScript flightUI, Widget root)
		{
			base.MainCamera = flightUI.MainCamera;
			_root = root;
			_targetBoxContainer = root.FindWidget("target-boxes");
			_firePanel = root.FindWidget("fire-panel");
			_gunButton = root.FindWidget("fire-guns-button");
			_fireButton = root.FindWidget("fire-weapon-button");
			_fireButtonLabel = root.FindWidget<TextWidget>("fire-weapon-count");
			_centerReticle = root.FindWidget("center-reticle");
			_countermeasuresButton = root.FindWidget("fire-countermeasures-button");
			_countermeasureLabel = root.FindWidget<TextWidget>("fire-countermeasures-count");
			_offscreenIndicator = root.FindWidget("offscreen-indicator").transform;
			_offscreenLabel = root.FindWidget<TextWidget>("offscreen-text");
			_offscreenArrow = root.FindWidget<ImageWidget>("offscreen-arrow");
			base.PlayerLockedSound = root.FindWidget<AudioWidget>("sound-player-lock")?.AudioSource;
			base.PlayerWarningSound = root.FindWidget<AudioWidget>("sound-player-warning")?.AudioSource;
			base.TargetLockSound = root.FindWidget<AudioWidget>("sound-target-lock")?.AudioSource;
			base.TargetAcquiringSound = root.FindWidget<AudioWidget>("sound-target-acquiring")?.AudioSource;
			_lockWarning = root.FindWidget<TextWidget>("lock-warning-text");
		}

		protected override void Awake()
		{
			base.Awake();
			Game.Instance.XRDeviceManager.HmdActiveChanged += OnHmdActiveChanged;
		}

		protected override ITargetBox CreateTargetBox(TrackedTarget trackedTarget)
		{
			ITargetBox targetBox;
			if (trackedTarget.Target.TargetType == TargetType.Laser)
			{
				Widget widget = _root.Context.CreateWidgetFromTemplate("target-box-laser", _targetBoxContainer);
				TargetBoxLaserScript targetBoxLaserScript = widget.gameObject.AddComponent<TargetBoxLaserScript>();
				targetBoxLaserScript.Initialize(trackedTarget, this, base.MainCamera, widget);
				targetBox = targetBoxLaserScript;
			}
			else
			{
				Widget widget2 = _root.Context.CreateWidgetFromTemplate("target-box", _targetBoxContainer);
				TargetBoxScriptJuicy targetBoxScriptJuicy = widget2.gameObject.AddComponent<TargetBoxScriptJuicy>();
				targetBoxScriptJuicy.Initialize(trackedTarget, this, base.MainCamera, widget2);
				targetBox = targetBoxScriptJuicy;
			}
			if (targetBox.TrackedTarget.IsTracking)
			{
				targetBox.SetActive(active: true);
			}
			else
			{
				targetBox.SetActive(active: false);
			}
			return targetBox;
		}

		protected override TargetingCircleScript CreateTargetingCircle(Transform targetingTransform)
		{
			if (base.Aircraft == null)
			{
				return null;
			}
			GameObject obj = new GameObject("TargetingCircle");
			obj.layer = 10;
			obj.transform.SetParent(targetingTransform, worldPositionStays: false);
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
			obj.transform.localPosition = Vector3.zero;
			return obj.AddComponent<TargetingCircleScript>();
		}

		protected override void EnableCenterReticle(bool enabled)
		{
			_centerReticle.Visible = enabled;
		}

		protected override void EnableLockWarning(bool enable, string text)
		{
			_lockWarning.Visible = enable;
			_lockWarning.Text = text;
		}

		protected Vector2 GetLocalPoint(Vector3 screenPos, RectTransform parent)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, screenPos, null, out var localPoint);
			return localPoint;
		}

		protected void LateUpdate()
		{
			if (base.Aircraft != null && base.Aircraft.MainCockpit != null)
			{
				Transform transform = base.Aircraft.MainCockpit.transform;
				if (_centerReticle.Visible && transform != null)
				{
					Vector3 position = base.MainCamera.WorldToScreenPoint(transform.TransformPoint(new Vector3(0f, 0f, 1000f)));
					position.z = 0f;
					_centerReticle.Rect.position = position;
				}
			}
		}

		protected override void OnAircraftChanged(AircraftScript aircraft)
		{
			base.OnAircraftChanged(aircraft);
			_gunButton.Visible = base.Aircraft?.TargetingSystem.GunsActive ?? false;
			_fireButton.Visible = base.Aircraft?.TargetingSystem.WeaponsOnboard ?? false;
			_customController.SetButtonValue(Game.Inputs.FireGuns.Id, value: false);
			_customController.SetButtonValue(Game.Inputs.LaunchCountermeasures.Id, value: false);
			_customController.SetButtonValue(Game.Inputs.FireWeapons.Id, value: false);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Game.Instance.XRDeviceManager.HmdActiveChanged -= OnHmdActiveChanged;
		}

		protected override void SetLockWarningText(string text)
		{
			_lockWarning.Text = text;
		}

		protected override void Start()
		{
			base.Start();
			if (ReInput.controllers.CustomControllers.Count == 0)
			{
				Debug.LogError("The custom controller could not be found");
				return;
			}
			_customController = ReInput.controllers.CustomControllers[0];
			_gunButton.PointerDown += OnGunButtonPressed;
			_gunButton.PointerUp += OnGunButtonReleased;
			if (_countermeasuresButton != null)
			{
				_countermeasuresButton.PointerDown += OnCountermeasuresButtonPressed;
				_countermeasuresButton.PointerUp += OnCountermeasuresButtonReleased;
			}
			_fireButton.PointerDown += OnFireButtonPressed;
			_fireButton.PointerUp += OnFireButtonReleased;
		}

		protected override void Update()
		{
			base.Update();
			if (base.WeaponFunction == WeaponFunction.None)
			{
				_firePanel.Visible = false;
				ReleaseCountermeasuresInput();
			}
			else
			{
				_firePanel.Visible = true;
				FireWeaponStateType fireWeaponStateType = FireWeaponStateType.None;
				AircraftScript aircraft = base.Aircraft;
				if ((object)aircraft != null && aircraft.TargetingSystem.CanFire)
				{
					fireWeaponStateType = FireWeaponStateType.ReadyToFire;
				}
				else if (base.Aircraft?.TargetingSystem.SelectedWeaponSystem != null)
				{
					fireWeaponStateType = FireWeaponStateType.Active;
				}
				if (_fireButtonState != fireWeaponStateType)
				{
					_fireButtonState = fireWeaponStateType;
					_fireButton.EnableClass("fire-weapon-ready", fireWeaponStateType == FireWeaponStateType.ReadyToFire);
					_fireButton.EnableClass("fire-weapon-active", fireWeaponStateType == FireWeaponStateType.Active);
					_fireButton.EnableClass("fire-weapon-inactive", fireWeaponStateType == FireWeaponStateType.None);
				}
				if (_fireButtonState != FireWeaponStateType.None)
				{
					int ammo = base.Aircraft.TargetingSystem.SelectedWeaponSystem.Ammo;
					_fireButtonLabel.Text = _fireButtonLabelCache.Update(ammo);
				}
			}
			if ((TouchControlsType)Game.Instance.Settings.Gameplay.General.TouchControlsType != TouchControlsType.Off)
			{
				_gunButton.Visible = base.Aircraft?.TargetingSystem.GunsActive ?? false;
			}
		}

		protected override void UpdateCountermeasures(int countermeasureAmmo)
		{
			base.UpdateCountermeasures(countermeasureAmmo);
			if (countermeasureAmmo > 0)
			{
				_countermeasuresButton.Visible = true;
				_countermeasuresButton.RemoveClass("countermeasures-empty");
			}
			else
			{
				_countermeasuresButton.AddClass("countermeasures-empty");
			}
			_countermeasureLabel.Text = _countermeasureLabelCache.Update(countermeasureAmmo);
		}

		private void OnCountermeasuresButtonPressed(Widget widget)
		{
			if (_customController != null)
			{
				_customController.SetButtonValue(Game.Inputs.LaunchCountermeasures.Id, value: true);
			}
		}

		private void OnCountermeasuresButtonReleased(Widget widget)
		{
			ReleaseCountermeasuresInput();
		}

		private void OnFireButtonPressed(Widget widget)
		{
			if (_customController != null)
			{
				_customController.SetButtonValue(Game.Inputs.FireWeapons.Id, value: true);
			}
		}

		private void OnFireButtonReleased(Widget widget)
		{
			if (_customController != null)
			{
				_customController.SetButtonValue(Game.Inputs.FireWeapons.Id, value: false);
			}
		}

		private void OnGunButtonPressed(Widget widget)
		{
			if (_customController != null)
			{
				_customController.SetButtonValue(Game.Inputs.FireGuns.Id, value: true);
			}
		}

		private void OnGunButtonReleased(Widget widget)
		{
			if (_customController != null)
			{
				_customController.SetButtonValue(Game.Inputs.FireGuns.Id, value: false);
			}
		}

		private void OnHmdActiveChanged(bool active)
		{
			base.gameObject.SetActive(!active);
		}

		private void ReleaseCountermeasuresInput()
		{
			if (_customController != null)
			{
				_customController.SetButtonValue(Game.Inputs.LaunchCountermeasures.Id, value: false);
			}
		}
	}
}
