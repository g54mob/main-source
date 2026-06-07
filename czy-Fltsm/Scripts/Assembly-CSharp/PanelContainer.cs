using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using PajamaLlama.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
public class PanelContainer : MonoBehaviour, IPanel, ICancelable
{
	[Serializable]
	public class PanelTutorial
	{
		[SerializeField]
		private PanelID _panelID = PanelID.None;

		[SerializeField]
		private TutorialID _tutorialID;

		public PanelID PanelID => _panelID;

		public TutorialID TutorialID => _tutorialID;
	}

	[Header("Panel Settings")]
	[SerializeField]
	private Panel[] _panels;

	[SerializeField]
	private PanelContainerExclusivity _exclusivity;

	[SerializeField]
	private PanelID[] _excludedPanels;

	[SerializeField]
	private bool _draggable = true;

	[SerializeField]
	private bool _closeOnCancel = true;

	[SerializeField]
	private PanelContainerFlags _flags = PanelContainerFlags.BlockCursorContext | PanelContainerFlags.BlockCameraInput | PanelContainerFlags.BlockDPadInput;

	[SerializeField]
	private TextMeshProUGUI _titleField;

	[Header("Tutorial")]
	[SerializeField]
	private GameObject _panelTutorialButton;

	[SerializeField]
	private List<PanelTutorial> _panelTutorials = new List<PanelTutorial>();

	[Header("Tween")]
	[SerializeField]
	private PanelContainerTween _tween = PanelContainerTween.Position;

	[SerializeField]
	private Easing _openEasing;

	[SerializeField]
	[ConditionalEnumHide("_openEasing", 0, false, HideInInspector = true, Inverse = true)]
	private float _openDuration;

	[SerializeField]
	private Easing _closeEasing;

	[SerializeField]
	[ConditionalEnumHide("_closeEasing", 0, false, HideInInspector = true, Inverse = true)]
	private float _closeDuration;

	[SerializeField]
	[ConditionalEnumHide("_tween", 1, false)]
	private Vector2 _from;

	[SerializeField]
	[ConditionalEnumHide("_tween", 1, false)]
	private Vector2 _to;

	private PanelContainerState _state;

	private RectTransform _rectTransform;

	private Canvas _canvas;

	private Vector2 _dragOffset;

	private Vector2 _dragLimitHorizontal = Vector2.zero;

	private Vector2 _dragLimitVertical = Vector2.zero;

	private EventTrigger _eventTrigger;

	private RectTransformAnchoredPositionTweener _positionTweener;

	private Coroutine _tweenCoroutine;

	public Panel OpenPanel { get; private set; }

	public PanelID ID
	{
		get
		{
			if (!OpenPanel)
			{
				return PanelID.None;
			}
			return OpenPanel.ID;
		}
	}

	public PanelContainerExclusivity Exclusivity => _exclusivity;

	public PanelID[] ExcludedPanels => _excludedPanels;

	public PanelContainerFlags Flags => _flags;

	public PanelContainerState State
	{
		get
		{
			return _state;
		}
		private set
		{
			if (_state != value)
			{
				_state = value;
				if (OpenPanel != null)
				{
					OpenPanel.OnContainerStateChanged(_state);
				}
			}
		}
	}

	public bool CloseOnCancel => _closeOnCancel;

	protected virtual void Awake()
	{
		_rectTransform = base.transform as RectTransform;
		if (_canvas == null && !TryGetComponent<Canvas>(out _canvas))
		{
			Debugger.Log(base.gameObject.name + " has no canvas component. Attach one please.", this);
			_canvas = base.gameObject.AddComponent<Canvas>();
		}
	}

	private void OnEnable()
	{
		if (_openEasing != Easing.None)
		{
			State = PanelContainerState.Opening;
			switch (_tween)
			{
			case PanelContainerTween.Position:
				StartPositionTween(_openEasing, _to, _openDuration, OnOpen);
				break;
			case PanelContainerTween.Scale:
				StartScaleTween(_openEasing, 0f, 1f, _openDuration, OnOpen);
				break;
			}
		}
		else
		{
			OnOpen();
		}
		if (GameManager.UIManager != null)
		{
			GameManager.UIManager.AddOpenPanel(this);
		}
	}

	protected virtual void Start()
	{
		if (!_draggable)
		{
			return;
		}
		if (TryGetComponent<EventTrigger>(out _eventTrigger))
		{
			Debugger.Warning("An event trigger is already on this object.", base.gameObject);
			return;
		}
		_eventTrigger = base.gameObject.AddComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry
		{
			eventID = EventTriggerType.BeginDrag
		};
		entry.callback.AddListener(delegate
		{
			SetDragOffset();
		});
		_eventTrigger.triggers.Add(entry);
		EventTrigger.Entry entry2 = new EventTrigger.Entry
		{
			eventID = EventTriggerType.Drag
		};
		entry2.callback.AddListener(delegate
		{
			Drag();
		});
		_eventTrigger.triggers.Add(entry2);
		if (_draggable && (!Mathf.Approximately(_rectTransform.anchorMin.x, _rectTransform.anchorMax.x) || !Mathf.Approximately(_rectTransform.anchorMin.y, _rectTransform.anchorMax.y)))
		{
			Debugger.Error($"A draggable panel ({base.name}) cannot have a stretched anchor. This will create unwanted behaviours.");
		}
	}

	protected virtual void LateUpdate()
	{
		if (_closeOnCancel && FlotsamInputManager.GetUICancel())
		{
			Close();
		}
	}

	private void OnDisable()
	{
		State = PanelContainerState.Closed;
		if (GameManager.UIManager != null)
		{
			GameManager.UIManager.RemoveOpenPanel(this);
		}
		FlotsamInputManager.RemoveCancelable(this);
	}

	public bool CanOpen(PanelID id, IPanelContext context = null)
	{
		Panel[] panels = _panels;
		foreach (Panel panel in panels)
		{
			if ((bool)panel && panel.CanBeOpened(id, context))
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool Open(PanelID id, IPanelContext context = null)
	{
		Panel[] panels = _panels;
		foreach (Panel panel in panels)
		{
			if (!panel.Open(id, context))
			{
				continue;
			}
			if (OpenPanel != panel)
			{
				if (OpenPanel != null)
				{
					OpenPanel.Close();
				}
				OpenPanel = panel;
				OpenPanel.OnContainerStateChanged(State);
			}
			if (base.gameObject.activeSelf)
			{
				OnOpen();
			}
			else
			{
				base.gameObject.SetActive(value: true);
			}
			if ((bool)_titleField)
			{
				_titleField.text = OpenPanel.Title;
			}
			if (_rectTransform == null)
			{
				_rectTransform = base.transform as RectTransform;
			}
			if (_panelTutorialButton != null)
			{
				_panelTutorialButton.SetActive(_panelTutorials.Find((PanelTutorial tutorial) => tutorial.PanelID == id) != null);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
			return true;
		}
		return false;
	}

	public bool TryGetPanel(PanelID id, out Panel panel)
	{
		panel = ((_panels != null) ? _panels.Find((Panel panel2) => panel2.ID == id) : null);
		return panel != null;
	}

	private void OnOpen()
	{
		if (_state == PanelContainerState.Closing && _tweenCoroutine != null)
		{
			StopCoroutine(_tweenCoroutine);
		}
		State = PanelContainerState.Open;
		if (_closeOnCancel)
		{
			FlotsamInputManager.PushCancelable(this);
		}
	}

	public void Close()
	{
		if (base.gameObject.activeSelf && State != PanelContainerState.Closing)
		{
			State = PanelContainerState.Closing;
			FinalUpdate.RegisterOneShot(FinalClose);
			FlotsamInputManager.RemoveCancelable(this);
		}
	}

	private void FinalClose()
	{
		if (State != PanelContainerState.Closing)
		{
			return;
		}
		if (_closeEasing == Easing.None)
		{
			OnClose();
			return;
		}
		switch (_tween)
		{
		case PanelContainerTween.Position:
			StartPositionTween(_closeEasing, _from, _closeDuration, OnClose);
			break;
		case PanelContainerTween.Scale:
			StartScaleTween(_closeEasing, 1f, 0f, _closeDuration, OnClose);
			break;
		}
	}

	private void OnClose()
	{
		if ((bool)OpenPanel)
		{
			OpenPanel.Close();
			OpenPanel = null;
		}
		base.gameObject.SetActive(value: false);
	}

	public void SetDragOffset()
	{
		_dragOffset = _rectTransform.anchoredPosition - UIManager.CanvasMousePosition;
		UpdateDragLimits();
	}

	public void Drag()
	{
		Vector2 anchoredPosition = UIManager.CanvasMousePosition + _dragOffset;
		anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, _dragLimitHorizontal.x, _dragLimitHorizontal.y);
		anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, _dragLimitVertical.x, _dragLimitVertical.y);
		_rectTransform.anchoredPosition = anchoredPosition;
	}

	public void OpenCurrentPanelTutorial()
	{
		if (_panelTutorials.IsNullOrEmpty())
		{
			return;
		}
		PanelID iD = ID;
		foreach (PanelTutorial panelTutorial in _panelTutorials)
		{
			if (panelTutorial.PanelID == iD)
			{
				GameManager.UIManager.ClosePanel(iD);
				TutorialEvent.Dispatch(GameEventType.TutorialPanelPopup, panelTutorial.TutorialID);
				break;
			}
		}
	}

	public void Initialize()
	{
		Panel[] panels = _panels;
		for (int i = 0; i < panels.Length; i++)
		{
			panels[i].Initialize();
		}
	}

	protected void UpdateDragLimits()
	{
		Vector2 vector = new Vector2(0f - GameManager.UIManager.CanvasResolution.x * _rectTransform.anchorMin.x, 0f - GameManager.UIManager.CanvasResolution.y * _rectTransform.anchorMin.y);
		_dragLimitHorizontal.x = vector.x + _rectTransform.sizeDelta.x * _rectTransform.pivot.x;
		_dragLimitHorizontal.y = vector.x + GameManager.UIManager.CanvasResolution.x - _rectTransform.sizeDelta.x * (1f - _rectTransform.pivot.x);
		_dragLimitVertical.x = vector.y + _rectTransform.sizeDelta.y * _rectTransform.pivot.y;
		_dragLimitVertical.y = vector.y + GameManager.UIManager.CanvasResolution.y - _rectTransform.sizeDelta.y * (1f - _rectTransform.pivot.y);
	}

	public void AddFlags(PanelContainerFlags flags)
	{
		_flags |= flags;
		GameManager.UIManager.MarkFlagsDirty();
	}

	public void RemoveFlags(PanelContainerFlags flags)
	{
		_flags &= ~flags;
		GameManager.UIManager.MarkFlagsDirty();
	}

	public bool TryCancel()
	{
		Close();
		return true;
	}

	private void StartPositionTween(Easing easing, Vector2 to, float duration, UnityAction callback = null)
	{
		if (_tweenCoroutine != null)
		{
			StopCoroutine(_tweenCoroutine);
		}
		_tweenCoroutine = StartCoroutine(TweenPositionRoutine(easing, to, duration, callback));
	}

	private IEnumerator TweenPositionRoutine(Easing easing, Vector2 to, float duration, UnityAction callback)
	{
		float num = Vector2.Distance(_from, _to) / duration;
		float duration2 = Vector2.Distance(_rectTransform.anchoredPosition, to) / num;
		if (_positionTweener == null)
		{
			_positionTweener = new RectTransformAnchoredPositionTweener(_rectTransform, to);
		}
		else
		{
			_positionTweener.Initialize(_rectTransform, to);
		}
		yield return Tweener.TweenRoutine(duration2, easing, true, _positionTweener);
		callback?.Invoke();
		_tweenCoroutine = null;
	}

	private void StartScaleTween(Easing easing, float from, float to, float duration, UnityAction callback = null)
	{
		if (_tweenCoroutine != null)
		{
			StopCoroutine(_tweenCoroutine);
		}
		_tweenCoroutine = StartCoroutine(TweenScaleRoutine(easing, from, to, duration, callback));
	}

	private IEnumerator TweenScaleRoutine(Easing easing, float from, float to, float duration, UnityAction callback)
	{
		_rectTransform.localScale = new Vector3(from, from, from);
		yield return Tweener.TweenRoutine(duration, easing, true, new TransformScaleTweener(_rectTransform, to, is2D: true));
		callback?.Invoke();
		_tweenCoroutine = null;
	}
}
