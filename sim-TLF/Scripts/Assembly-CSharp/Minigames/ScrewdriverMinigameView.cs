using JSAM;
using Minigames.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Minigames
{
	public class ScrewdriverMinigameView : MonoBehaviour
	{
		[Header("Components")]
		[SerializeField]
		private ScrewdriverTool _screwdriver;

		[SerializeField]
		private ScrewFastener _screw;

		[SerializeField]
		private HintSystem _hintSystem;

		[SerializeField]
		private AppearSystem _appearSystem;

		[Header("Movement")]
		[SerializeField]
		private float _outerRadius = 50f;

		[SerializeField]
		private float _innerRadius = 30f;

		[SerializeField]
		private float _moveSpeed = 10f;

		[SerializeField]
		private float _rotationSpeed = 5f;

		[SerializeField]
		private float _alignTolerance = 5f;

		[Header("Progress")]
		[SerializeField]
		private AnimationCurve _progressCurve = AnimationCurve.Linear(0f, 0f, 5f, 2f);

		[Header("Dead Zones")]
		[SerializeField]
		private RectTransform[] _deadZones;

		private Canvas _canvas;

		private CircularConstraint _circularConstraint;

		private ProgressTracker _progressTracker;

		private DeadZoneChecker _deadZoneChecker;

		private Vector2 _targetLocalPos;

		private Vector2 _currentVelocity;

		private float _initialAngleOffset;

		private float _previousMouseAngle;

		private bool _isEngaged;

		private bool _musicPlayed;

		public float Progress => _progressTracker.Progress;

		public ProgressTracker Progressor => _progressTracker;

		public void Init()
		{
			_canvas = GetComponentInParent<Canvas>();
			_circularConstraint = new CircularConstraint(_screwdriver.Transform.parent as RectTransform, _screw.Transform);
			_progressTracker = new ProgressTracker(_progressCurve);
			_deadZoneChecker = new DeadZoneChecker(_deadZones, _canvas);
			_progressTracker.OnCompleted += OnMinigameComplete;
			float z = _screwdriver.Transform.localEulerAngles.z;
			float currentRotation = _screw.GetCurrentRotation();
			_initialAngleOffset = Mathf.DeltaAngle(currentRotation, z);
			_targetLocalPos = _screwdriver.Transform.localPosition;
		}

		private void Start()
		{
			_hintSystem.Init(_progressTracker);
		}

		private void OnEnable()
		{
			if (_progressTracker.Progress == 0f)
			{
				_appearSystem.PlayAppearAnimation();
			}
		}

		private void OnDisable()
		{
			AudioManager.StopSoundIfPlaying(MiniGamesLibrarySounds.ScrewProgress);
		}

		private void Update()
		{
			Vector2 mouseLocalPosition = GetMouseLocalPosition();
			if (_deadZoneChecker.IsInDeadZone(mouseLocalPosition, _canvas.transform as RectTransform))
			{
				SetScrewSound(isScrewing: false);
				return;
			}
			Vector2 vector = _canvas.transform.TransformPoint(mouseLocalPosition);
			bool isInRing = _circularConstraint.IsInRing(vector, _innerRadius, _outerRadius);
			bool isAligned = _screw.IsAlignedWith(_screwdriver, _initialAngleOffset, _alignTolerance);
			if (!_isEngaged)
			{
				HandleFreeMovement(mouseLocalPosition, vector, isInRing, isAligned);
			}
			else
			{
				HandleEngagedRotation(vector, isInRing);
			}
		}

		public void SetProgress(float progress)
		{
			_progressTracker.SetProgress(progress);
		}

		private void HandleFreeMovement(Vector2 mouseLocalPos, Vector2 mouseWorld, bool isInRing, bool isAligned)
		{
			SetScrewSound(isScrewing: false);
			_targetLocalPos = mouseLocalPos;
			Vector2 localPosition = Vector2.SmoothDamp(_screwdriver.Transform.localPosition, _targetLocalPos, ref _currentVelocity, 1f / _moveSpeed);
			_screwdriver.UpdatePosition(localPosition);
			RotateScrewdriverToScrew();
			if (isInRing && isAligned)
			{
				_isEngaged = true;
				SnapTipToScrewCenter();
				_screwdriver.Engage(_screwdriver.Transform.localPosition);
				_previousMouseAngle = _circularConstraint.GetAngleAroundCenter(mouseWorld);
			}
		}

		private void HandleEngagedRotation(Vector2 mouseWorld, bool isInRing)
		{
			if (!isInRing)
			{
				_isEngaged = false;
				_screwdriver.Disengage();
				SetScrewSound(isScrewing: false);
				return;
			}
			float angleAroundCenter = _circularConstraint.GetAngleAroundCenter(mouseWorld);
			float num = Mathf.DeltaAngle(_previousMouseAngle, angleAroundCenter);
			_screwdriver.RotateAroundAxis(num);
			_screw.Rotate(num);
			SnapTipToScrewCenter();
			_progressTracker.AddRotation(0f - num);
			SetScrewSound(num < 0f);
			_previousMouseAngle = angleAroundCenter;
		}

		private void SetScrewSound(bool isScrewing)
		{
			if (isScrewing)
			{
				if (!AudioManager.IsSoundPlaying(MiniGamesLibrarySounds.ScrewProgress))
				{
					AudioManager.PlaySound(MiniGamesLibrarySounds.ScrewProgress);
				}
			}
			else
			{
				AudioManager.StopSoundIfPlaying(MiniGamesLibrarySounds.ScrewProgress);
			}
		}

		private Vector2 GetMouseLocalPosition()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Mouse.current.position.ReadValue(), _canvas.worldCamera, out var localPoint);
			return localPoint;
		}

		private void SnapTipToScrewCenter()
		{
			if (!(_screwdriver.InteractionPoint == null))
			{
				Vector3 vector = _screw.Transform.position - _screwdriver.InteractionPoint.position;
				_screwdriver.Transform.position += vector;
			}
		}

		private void RotateScrewdriverToScrew()
		{
			Transform parent = _screwdriver.Transform.parent;
			if (!(parent == null))
			{
				Vector3 vector = parent.InverseTransformPoint(_screw.Transform.position);
				Vector3 localPosition = _screwdriver.Transform.localPosition;
				float num = vector.x - localPosition.x;
				float num2 = vector.y - localPosition.y;
				if (!(num * num + num2 * num2 < 1E-06f))
				{
					float z = Mathf.Atan2(num2, num) * 57.29578f + _screwdriver.RotationOffset;
					Quaternion b = Quaternion.Euler(0f, 0f, z);
					_screwdriver.Transform.localRotation = Quaternion.Slerp(_screwdriver.Transform.localRotation, b, Time.deltaTime * _rotationSpeed);
				}
			}
		}

		private void OnMinigameComplete()
		{
			Debug.Log("Screwdriver minigame completed! Progress: " + _progressTracker.Progress);
		}
	}
}
