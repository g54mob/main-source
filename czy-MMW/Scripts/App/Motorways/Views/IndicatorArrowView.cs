using Client;
using Factory;
using Factory.Pools;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class IndicatorArrowView : MonoBehaviour, IView, IReusable
	{
		private enum State
		{
			Intro = 0,
			Idle = 1,
			Exit = 2
		}

		public enum IndicatorType
		{
			NewBuilding = 0,
			DestinationUpgrade = 1,
			DestinationBigPin = 2,
			DestinationImminentFail = 3
		}

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private SpriteRenderer _pinInside;

		[SerializeField]
		private Transform _iconsTransform;

		[SerializeField]
		private GameObject _iconPlus;

		[SerializeField]
		private GameObject _iconCircleOutline;

		[SerializeField]
		private GameObject _iconCircleFill;

		[SerializeField]
		private GameObject _iconAlert;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private GameCamera _gameCamera;

		private RectTransform _safeAreaRect;

		private Bounds _targetBounds;

		private Vector3 _targetPositionOnBounds;

		private Vector3[] _safeAreaWorldCorners = new Vector3[4];

		private State _state;

		private float _timeUntilKnock;

		private float _knockDelay;

		private int _knockNumber;

		private float _exitDelay;

		private static readonly int AnimatorKnockHash = Animator.StringToHash("Knock");

		private static readonly int AnimatorExitHash = Animator.StringToHash("Exit");

		private static readonly int AnimatorIdleHash = Animator.StringToHash("Idle");

		private const float InnerBoundaryPercent = 0.17f;

		private const float OuterBoundaryPercent = 0.12f;

		private void Initialise(DestinationView destinationView, IndicatorType indicatorType, RectTransform safeAreaTransform, int knockNumber, float knockDelay, float exitDelay)
		{
			_iconPlus.SetActive(indicatorType == IndicatorType.NewBuilding);
			_iconCircleOutline.SetActive(indicatorType == IndicatorType.DestinationUpgrade);
			_iconCircleFill.SetActive(indicatorType == IndicatorType.DestinationBigPin);
			_iconAlert.SetActive(indicatorType == IndicatorType.DestinationImminentFail);
			if (indicatorType == IndicatorType.DestinationImminentFail)
			{
				_pinInside.color = Color.black;
			}
			else
			{
				_pinInside.color = destinationView.GetBuildingColor(ThemeComponentGroupTarget.BuildingBase);
			}
			_safeAreaRect = safeAreaTransform;
			_targetBounds = destinationView.GetBounds();
			_targetPositionOnBounds = _targetBounds.center;
			_state = State.Intro;
			_knockDelay = knockDelay;
			_knockNumber = knockNumber;
			_exitDelay = exitDelay;
			ClampPosition();
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			ClampPosition();
			if (_state != State.Exit && !_cameraView.playerZoomedIn)
			{
				SetState(State.Exit);
			}
			if (_state == State.Intro)
			{
				TickIntro();
			}
			else if (_state == State.Idle)
			{
				TickIdle(timeInterval.Delta);
			}
			else if (_state == State.Exit)
			{
				return TickExit();
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void ClampPosition()
		{
			Camera defaultCamera = _gameCamera.DefaultCamera;
			_safeAreaRect.GetWorldCorners(_safeAreaWorldCorners);
			Vector3 vector = defaultCamera.WorldToScreenPoint(_safeAreaWorldCorners[0]);
			Vector3 vector2 = defaultCamera.WorldToScreenPoint(_safeAreaWorldCorners[2]);
			Rect screenRect = Rect.MinMaxRect(vector.x, vector.y, vector2.x, vector2.y);
			Vector3 vector3 = defaultCamera.WorldToScreenPoint(_targetBounds.min);
			Vector3 vector4 = defaultCamera.WorldToScreenPoint(_targetBounds.max);
			Rect screenTargetRect = Rect.MinMaxRect(vector3.x, vector3.y, vector4.x, vector4.y);
			Rect boundaryRect = GetBoundaryRect(ref screenRect, 0.12f);
			bool num = !screenTargetRect.Overlaps(screenRect);
			Vector3 position;
			if (num)
			{
				position = GetTargetScreenPositionOnBounds(screenTargetRect, screenRect, vector3.z);
				_targetPositionOnBounds = defaultCamera.ScreenToWorldPoint(position);
			}
			else
			{
				position = defaultCamera.WorldToScreenPoint(_targetPositionOnBounds);
			}
			Vector3 vector5 = new Vector3(Mathf.Clamp(position.x, boundaryRect.xMin, boundaryRect.xMax), Mathf.Clamp(position.y, boundaryRect.yMin, boundaryRect.yMax), position.z);
			Vector3 vector6 = defaultCamera.ScreenToWorldPoint(vector5);
			base.transform.position = vector6;
			if (num)
			{
				Vector3 vector7 = _targetPositionOnBounds - vector6;
				float z = Mathf.Atan2(vector7.y, vector7.x) * 57.29578f + 90f;
				Vector3 euler = new Vector3(0f, 0f, z);
				base.transform.rotation = Quaternion.Euler(euler);
				_iconsTransform.rotation = Quaternion.identity;
			}
			else if (_state != State.Exit && GetBoundaryRect(ref screenRect, 0.17f).Contains(vector5))
			{
				SetState(State.Exit);
			}
		}

		private static Vector3 GetTargetScreenPositionOnBounds(Rect screenTargetRect, Rect screenRect, float zDepth)
		{
			Vector2 center = screenTargetRect.center;
			Vector3 result = new Vector3(center.x, center.y, zDepth);
			if (screenTargetRect.min.x > screenRect.xMax)
			{
				result.x = screenTargetRect.min.x;
			}
			else if (screenTargetRect.max.x < screenRect.xMin)
			{
				result.x = screenTargetRect.max.x;
			}
			if (screenTargetRect.min.y > screenRect.yMax)
			{
				result.y = screenTargetRect.min.y;
			}
			else if (screenTargetRect.max.y < screenRect.yMin)
			{
				result.y = screenTargetRect.max.y;
			}
			return result;
		}

		private Rect GetBoundaryRect(ref Rect screenRect, float gapPercent)
		{
			float num = screenRect.width * gapPercent;
			float num2 = screenRect.height * gapPercent;
			return Rect.MinMaxRect(screenRect.xMin + num, screenRect.yMin + num2, screenRect.xMax - num, screenRect.yMax - num2);
		}

		private void SetState(State newState)
		{
			if (newState == _state)
			{
				return;
			}
			_state = newState;
			if (_state != State.Intro)
			{
				if (_state == State.Idle)
				{
					_timeUntilKnock = _knockDelay;
				}
				else if (_state == State.Exit)
				{
					_animator.SetTrigger(AnimatorExitHash);
				}
			}
		}

		private void TickIntro()
		{
			if (IsInAnimState(AnimatorIdleHash))
			{
				SetState(State.Idle);
			}
		}

		private void TickIdle(float tickTime)
		{
			if (!IsInAnimState(AnimatorKnockHash) && _timeUntilKnock >= 0f)
			{
				_timeUntilKnock -= tickTime;
				if (_timeUntilKnock < 0f)
				{
					_animator.SetTrigger(AnimatorKnockHash);
					_knockNumber--;
					if (_knockNumber > 0)
					{
						_timeUntilKnock += _knockDelay;
					}
				}
			}
			if (_exitDelay >= 0f)
			{
				_exitDelay -= tickTime;
				if (_exitDelay < 0f)
				{
					SetState(State.Exit);
				}
			}
		}

		private TickResult TickExit()
		{
			AnimatorStateInfo currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.shortNameHash == AnimatorExitHash && currentAnimatorStateInfo.normalizedTime >= 1f)
			{
				return TickResult.Destroy;
			}
			return TickResult.ContinueTicking;
		}

		private bool IsInAnimState(int stateHash)
		{
			return _animator.GetCurrentAnimatorStateInfo(0).shortNameHash == stateHash;
		}

		public void Reset()
		{
			ClearIcon();
			_targetBounds = default(Bounds);
			_targetPositionOnBounds = Vector3.zero;
			base.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			SetState(State.Intro);
			_timeUntilKnock = 0f;
			_knockDelay = 0f;
			_knockNumber = 0;
			_exitDelay = 0f;
		}

		private void ClearIcon()
		{
			_iconPlus.SetActive(value: false);
			_iconCircleOutline.SetActive(value: false);
			_iconCircleFill.SetActive(value: false);
			_iconAlert.SetActive(value: false);
		}

		public static IndicatorArrowView Create(ViewClient client, DestinationView destinationView, IndicatorType type, RectTransform safeAreaRect, int knockNumber, float knockDelay, float exitDelay)
		{
			IndicatorArrowView indicatorArrowView = client.Scope.Get<IndicatorArrowView>();
			indicatorArrowView.Initialise(destinationView, type, safeAreaRect, knockNumber, knockDelay, exitDelay);
			client.AddView(indicatorArrowView);
			return indicatorArrowView;
		}
	}
}
