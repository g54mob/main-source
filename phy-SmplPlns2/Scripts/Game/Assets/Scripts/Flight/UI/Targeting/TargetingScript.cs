using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Targeting
{
	public abstract class TargetingScript : MonoBehaviour
	{
		protected bool _offscreenActive;

		private Transform _currentTargetingTransform;

		[SerializeField]
		private Camera _mainCamera;

		[SerializeField]
		private AudioSource _playerLockedSound;

		[SerializeField]
		private AudioSource _playerWarningSound;

		[SerializeField]
		private AudioSource _targetAcquiringSound;

		private List<ITargetBox> _targetBoxes = new List<ITargetBox>();

		private TargetingCircleScript _targetingCircle;

		[SerializeField]
		private AudioSource _targetLockSound;

		private TargetingSystem.WarningState _targetWarningState;

		private TargetingSystem.WarningState _warningState;

		public AircraftScript Aircraft { get; private set; }

		public WeaponFunction WeaponFunction { get; private set; }

		public Camera MainCamera
		{
			get
			{
				return _mainCamera;
			}
			protected set
			{
				_mainCamera = value;
			}
		}

		public TargetingSystem.TargetingSystemMode Mode { get; private set; }

		public virtual Transform OffscreenIndicator { get; }

		public AudioSource PlayerLockedSound
		{
			get
			{
				return _playerLockedSound;
			}
			set
			{
				_playerLockedSound = value;
			}
		}

		public AudioSource PlayerWarningSound
		{
			get
			{
				return _playerWarningSound;
			}
			set
			{
				_playerWarningSound = value;
			}
		}

		public AudioSource TargetAcquiringSound
		{
			get
			{
				return _targetAcquiringSound;
			}
			set
			{
				_targetAcquiringSound = value;
			}
		}

		public AudioSource TargetLockSound
		{
			get
			{
				return _targetLockSound;
			}
			set
			{
				_targetLockSound = value;
			}
		}

		public abstract void EnableOffscreenIndicator(Vector3 screenPosition, float angle, string name, string text, Color color);

		public void SetAircraft(AircraftScript aircraft)
		{
			for (int num = _targetBoxes.Count - 1; num >= 0; num--)
			{
				ITargetBox targetBox = _targetBoxes[num];
				RemoveTargetBox(targetBox);
			}
			if (Aircraft != null)
			{
				Aircraft.TargetingSystem.TargetAdded -= TargetingSystemTargetAdded;
				Aircraft.TargetingSystem.TargetRemoved -= TargetingSystemTargetRemoved;
				Aircraft.TargetingSystem.TargetEnteredRange -= TargetingSystemTargetAdded;
				Aircraft.TargetingSystem.TargetLeftRange -= TargetingSystemTargetRemoved;
			}
			Aircraft = aircraft;
			if (Aircraft != null)
			{
				Aircraft.TargetingSystem.TargetAdded += TargetingSystemTargetAdded;
				Aircraft.TargetingSystem.TargetRemoved += TargetingSystemTargetRemoved;
				Aircraft.TargetingSystem.TargetEnteredRange += TargetingSystemTargetAdded;
				Aircraft.TargetingSystem.TargetLeftRange += TargetingSystemTargetRemoved;
				foreach (TrackedTarget target in Aircraft.TargetingSystem.Targets)
				{
					ITargetBox item = CreateTargetBox(target);
					_targetBoxes.Add(item);
				}
			}
			OnAircraftChanged(Aircraft);
		}

		protected virtual void Awake()
		{
		}

		protected abstract ITargetBox CreateTargetBox(TrackedTarget trackedTarget);

		protected abstract TargetingCircleScript CreateTargetingCircle(Transform targetingTransform);

		protected abstract void EnableCenterReticle(bool enabled);

		protected abstract void EnableLockWarning(bool enable, string text);

		protected virtual void OnAircraftChanged(AircraftScript aircraft)
		{
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			instance.PlayerAircraftLoadCompleted -= OnPlayerAircraftLoadCompleted;
			instance.PlayerAircraftUnloaded -= OnPlayerAircraftUnloaded;
		}

		protected abstract void SetLockWarningText(string text);

		protected virtual void Start()
		{
			EnableLockWarning(enable: false, null);
			FlightSceneScript instance = FlightSceneScript.Instance;
			instance.PlayerAircraftLoadCompleted += OnPlayerAircraftLoadCompleted;
			instance.PlayerAircraftUnloaded += OnPlayerAircraftUnloaded;
		}

		protected virtual void Update()
		{
			OffscreenIndicator.gameObject.SetActive(_offscreenActive);
			_offscreenActive = false;
			TargetingSystem targetingSystem = Aircraft?.TargetingSystem;
			if (targetingSystem != null)
			{
				Mode = targetingSystem.Mode;
				WeaponFunction = targetingSystem.WeaponFunction;
			}
			else
			{
				Mode = TargetingSystem.TargetingSystemMode.Off;
				WeaponFunction = WeaponFunction.None;
			}
			TargetingSystem.WarningState warningState = targetingSystem?.CurrentWarningState ?? TargetingSystem.WarningState.None;
			if (_warningState != warningState)
			{
				_warningState = warningState;
				if (_warningState == TargetingSystem.WarningState.Acquiring)
				{
					EnableLockWarning(enable: true, "WARNING");
					PlayerLockedSound.Stop();
					PlayerWarningSound.Play();
				}
				else if (_warningState == TargetingSystem.WarningState.Locked)
				{
					EnableLockWarning(enable: true, "LOCKED");
					PlayerLockedSound.Play();
					PlayerWarningSound.Stop();
				}
				else
				{
					EnableLockWarning(enable: false, null);
					PlayerLockedSound.Stop();
					PlayerWarningSound.Stop();
				}
			}
			TargetingSystem.WarningState warningState2 = targetingSystem?.CurrentTargetWarningState ?? TargetingSystem.WarningState.None;
			if (_targetWarningState != warningState2)
			{
				_targetWarningState = warningState2;
				if (_targetWarningState == TargetingSystem.WarningState.Locked)
				{
					TargetLockSound.Play();
					TargetAcquiringSound.Stop();
				}
				else if (_targetWarningState == TargetingSystem.WarningState.Acquiring)
				{
					TargetLockSound.Stop();
					TargetAcquiringSound.Play();
				}
				else
				{
					TargetLockSound.Stop();
					TargetAcquiringSound.Stop();
				}
			}
			if (PauseManager.Paused)
			{
				PlayerWarningSound.Stop();
				PlayerLockedSound.Stop();
				TargetAcquiringSound.Stop();
				TargetLockSound.Stop();
				_warningState = TargetingSystem.WarningState.None;
				_targetWarningState = TargetingSystem.WarningState.None;
			}
			Transform transform = targetingSystem?.TargetingTransform;
			if (_targetingCircle != null && _currentTargetingTransform == transform)
			{
				float num = targetingSystem?.TargetingAngle ?? 0f;
				if (_targetingCircle.Angle != num)
				{
					_targetingCircle.Angle = num;
				}
				UpdateCountermeasures(targetingSystem?.CountermeasureAmmo ?? 0);
				CameraController controller = CameraManagerScript.Instance.Controller;
				EnableCenterReticle(targetingSystem != null && targetingSystem.ShowGunReticule && controller.AllowGunReticle(transform));
				if (_targetingCircle != null)
				{
					if (Game.Instance.UserInterface.AnyDialogsOpen || FlightUIScript.UIHidden)
					{
						_targetingCircle.Visible = false;
					}
					else
					{
						_targetingCircle.Visible = controller.AllowMissileLocking(transform) && num > 0f;
					}
				}
			}
			else
			{
				if (_targetingCircle != null)
				{
					Object.Destroy(_targetingCircle.gameObject);
				}
				_currentTargetingTransform = transform;
				_targetingCircle = CreateTargetingCircle(_currentTargetingTransform);
			}
		}

		protected virtual void UpdateCountermeasures(int countermeasureAmmo)
		{
		}

		private ITargetBox FindTargetBox(TrackedTarget trackedTarget)
		{
			foreach (ITargetBox targetBox in _targetBoxes)
			{
				if (targetBox.TrackedTarget == trackedTarget)
				{
					return targetBox;
				}
			}
			return null;
		}

		private void OnPlayerAircraftLoadCompleted(object sender, FlightScenePlayerAircraftLoadCompletedEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				SetAircraft(e.Aircraft);
			}
		}

		private void OnPlayerAircraftUnloaded(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				SetAircraft(null);
			}
		}

		private void RemoveTargetBox(ITargetBox targetBox)
		{
			_targetBoxes.Remove(targetBox);
			targetBox.Destroy();
		}

		private void TargetingSystemTargetAdded(object sender, TrackedTargetEventArgs e)
		{
			if (FindTargetBox(e.TrackedTarget) == null)
			{
				ITargetBox item = CreateTargetBox(e.TrackedTarget);
				_targetBoxes.Add(item);
			}
		}

		private void TargetingSystemTargetRemoved(object sender, TrackedTargetEventArgs e)
		{
			ITargetBox targetBox = FindTargetBox(e.TrackedTarget);
			if (targetBox != null)
			{
				RemoveTargetBox(targetBox);
			}
		}
	}
}
