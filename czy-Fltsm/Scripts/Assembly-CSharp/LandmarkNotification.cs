using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LandmarkNotification : SceneUIBehaviour
{
	public enum States
	{
		Idle = 0,
		Notification = 1,
		Working = 2
	}

	[Header("Landmark")]
	[SerializeField]
	private Image _icon;

	[Header("Notification")]
	[SerializeField]
	private Image _notification;

	[Header("Interaction")]
	[SerializeField]
	private Button _button;

	[SerializeField]
	private Image _selectionHighlight;

	[SerializeField]
	private Image _check;

	private States _state;

	private SelectionLink _landmarkSelectionLink;

	private Animator _animator;

	private Sprite _defaultNotificationIcon;

	private bool _isSelecting;

	public LandmarkBehaviour LandmarkBehaviour { get; private set; }

	public void Initialize(LandmarkBehaviour landmarkBehaviour)
	{
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationIdle, OnNotificationIdle);
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationUpdate, OnNotificationUpdate);
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationWorking, OnNotificationWorking);
		if (landmarkBehaviour.Landmark.NotificationIcon != null)
		{
			_icon.sprite = landmarkBehaviour.Landmark.NotificationIcon;
		}
		_button.onClick.AddListener(OnSelectLandmark);
		_isSelecting = false;
		_selectionHighlight.enabled = false;
		_check.enabled = false;
		LandmarkBehaviour = landmarkBehaviour;
		_landmarkSelectionLink = landmarkBehaviour.Landmark.GetComponentInChildren<SelectionLink>();
		_animator = GetComponent<Animator>();
		_defaultNotificationIcon = _notification.sprite;
		if (LandmarkBehaviour.ReturnIsActive())
		{
			SetState(States.Working);
		}
		else
		{
			SetState(States.Notification);
		}
	}

	private void Update()
	{
		if (!_isSelecting)
		{
			_selectionHighlight.enabled = Selector.Selection == _landmarkSelectionLink;
		}
	}

	protected override void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationIdle, OnNotificationIdle);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationUpdate, OnNotificationUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationWorking, OnNotificationWorking);
		_button.onClick.RemoveListener(OnSelectLandmark);
	}

	private void OnNotificationIdle(GameEvent gameEvent)
	{
		if (ReturnProcessEvent(gameEvent as LandmarkNotificationEvent))
		{
			SetState(States.Idle);
		}
	}

	private void OnNotificationUpdate(GameEvent gameEvent)
	{
		LandmarkNotificationEvent evt = gameEvent as LandmarkNotificationEvent;
		if (ReturnProcessEvent(evt))
		{
			_notification.sprite = _defaultNotificationIcon;
			SetState(States.Notification);
		}
	}

	private void OnNotificationWorking(GameEvent gameEvent)
	{
		if (ReturnProcessEvent(gameEvent as LandmarkNotificationEvent))
		{
			SetState(States.Working);
		}
	}

	private void OnSelectLandmark()
	{
		if (!_isSelecting && !(Selector.Selection == _landmarkSelectionLink))
		{
			Selector.DeselectAll();
			_selectionHighlight.enabled = true;
			if (_state == States.Notification)
			{
				_animator.SetTrigger("Idle");
			}
			Selector.Select(LandmarkBehaviour.Landmark.gameObject, ObjectType.Landmark);
		}
	}

	public void FocusCameraOnLandmark()
	{
		GameManager.UIManager.IsPanelOpen(PanelID.LandmarkPanel);
		Selector.DeselectAll();
		_isSelecting = true;
		_selectionHighlight.enabled = true;
		if (_state == States.Notification)
		{
			_animator.SetTrigger("Idle");
		}
		Selector.Select(LandmarkBehaviour.Landmark.gameObject, ObjectType.Landmark);
		CameraController.Instance.CenterOnTransform(LandmarkBehaviour.Landmark.transform, LandmarkBehaviour.Landmark.CameraZoomLevel, CameraController.TargetFocusOrientationType.LookAtTarget, delegate
		{
			_isSelecting = false;
		});
	}

	private void SetState(States state)
	{
		if (_state == state)
		{
			return;
		}
		switch (state)
		{
		case States.Idle:
			_animator.SetTrigger("Idle");
			break;
		case States.Notification:
			_animator.SetTrigger("Notification");
			if (!_check.enabled && LandmarkBehaviour.ReturnIsCompleted())
			{
				StartCoroutine(CheckCoroutine());
				AudioManager.Play(GameManager.Settings.LandmarkSettings.landmarkCompletedSound);
			}
			break;
		case States.Working:
			_animator.SetTrigger("Working");
			break;
		}
		_state = state;
	}

	private bool ReturnProcessEvent(LandmarkNotificationEvent evt)
	{
		if (evt == null)
		{
			return false;
		}
		return evt.LandmarkBehaviour == LandmarkBehaviour;
	}

	private IEnumerator CheckCoroutine()
	{
		_check.enabled = true;
		_check.transform.localScale = Vector3.zero;
		yield return Tweener.TweenRoutine(0.5f, EasingFunctions.BounceOut, true, new TransformScaleTweener(_check.transform, 1f, is2D: true));
	}
}
