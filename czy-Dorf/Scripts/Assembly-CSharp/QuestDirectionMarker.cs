using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using Dorfromantik;
using Dorfromantik.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuestDirectionMarker : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private sealed class _003CHighlightingUpdate_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public QuestDirectionMarker _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CHighlightingUpdate_003Ed__48(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			QuestDirectionMarker questDirectionMarker = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				questDirectionMarker.questDirectionScreen.ReorderQuestMarkers();
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			case 2:
				_003C_003E1__state = -1;
				break;
			case 3:
				_003C_003E1__state = -1;
				break;
			case 4:
				_003C_003E1__state = -1;
				break;
			}
			if (questDirectionMarker.Visible && !questDirectionMarker.isAboutToBeDestroyed)
			{
				if (!questDirectionMarker.mainCamera)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				if (CameraUtility.IsVisibleByCamera(questDirectionMarker.IsFlagQuestMarker ? (questDirectionMarker.questWatcher.ClosingQuestFlag.transform.position + Vector3.up * 0.325f) : questDirectionMarker.questWatcher.QuestLabel.transform.position, questDirectionMarker.mainCamera, Vector2.zero))
				{
					questDirectionMarker.Show(newShow: false);
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					return true;
				}
				if (questDirectionMarker.questWatcher.QuestTile.State != TileState.placed)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 3;
					return true;
				}
				Vector2 sizeDelta = questDirectionMarker.canvas.sizeDelta;
				Vector2 vector = questDirectionMarker.rectTransform.sizeDelta * questDirectionMarker.uiScalingManager.CurrentOffscreenQuestMarkerScale * (questDirectionMarker.IsFlagQuestMarker ? questDirectionMarker.flagQuestScale : 1f);
				Vector3 vector2 = (questDirectionMarker.IsFlagQuestMarker ? (questDirectionMarker.questWatcher.ClosingQuestFlag.transform.position + Vector3.up * 0.325f) : questDirectionMarker.questWatcher.QuestLabel.transform.position);
				questDirectionMarker.groundPlane = new Plane(Vector3.up, vector2);
				Ray ray = questDirectionMarker.mainCamera.ScreenPointToRay(new Vector3((float)Screen.width * 0.5f, (float)Screen.height * 0.5f, 0f));
				questDirectionMarker.groundPlane.Raycast(ray, out var enter);
				Vector3 point = ray.GetPoint(enter);
				Vector3 normalized = (questDirectionMarker.groundPlane.ClosestPointOnPlane(vector2) - point).normalized;
				Vector2 intersectionPointFromRectCenter = MathUtility.GetIntersectionPointFromRectCenter((questDirectionMarker.mainCamera.WorldToScreenPoint(point + normalized) - questDirectionMarker.mainCamera.WorldToScreenPoint(point)).normalized, questDirectionMarker.canvas.rect);
				intersectionPointFromRectCenter.x = Mathf.Clamp(intersectionPointFromRectCenter.x, (0f - sizeDelta.x) / 2f + vector.x / 2f + questDirectionMarker.screenEdgeDistance, sizeDelta.x / 2f - vector.x / 2f - questDirectionMarker.screenEdgeDistance);
				intersectionPointFromRectCenter.y = Mathf.Clamp(intersectionPointFromRectCenter.y, (0f - sizeDelta.y) / 2f + vector.y / 2f + questDirectionMarker.screenEdgeDistance, questDirectionMarker.canvas.sizeDelta.y / 2f - vector.y / 2f - questDirectionMarker.screenEdgeDistance);
				questDirectionMarker.rectTransform.anchoredPosition = intersectionPointFromRectCenter;
				questDirectionMarker.Show(newShow: true);
				_003C_003E2__current = null;
				_003C_003E1__state = 4;
				return true;
			}
			if (!questDirectionMarker.isAboutToBeDestroyed)
			{
				questDirectionMarker.Show(newShow: false);
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private QuestWatcher questWatcher;

	private RectTransform rectTransform;

	private Camera mainCamera;

	private RectTransform canvas;

	[SerializeField]
	private bool displayCount;

	[SerializeField]
	private float screenEdgeDistance = 10f;

	[SerializeField]
	private UnityEvent onClick;

	[SerializeField]
	private float flagQuestScale = 0.5f;

	[SerializeField]
	private float fulfilledPunchScale = 0.25f;

	[SerializeField]
	private GameObject visual;

	[SerializeField]
	private TextMeshProUGUI countText;

	[SerializeField]
	private Image elementIcon;

	[SerializeField]
	private Image background;

	[SerializeField]
	private Image fulfillmentIcon;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private QuestUiComponentLibrary componentLibrary;

	[SerializeField]
	private UiScalingManager uiScalingManager;

	[SerializeField]
	private Sprite fulfilledSprite;

	[SerializeField]
	private Sprite failedSprite;

	[SerializeField]
	[FormerlySerializedAs("cameraFocusTreshold")]
	private Vector2 cameraFocusThreshold = new Vector2(0.4f, 0.4f);

	[SerializeField]
	private float autoCamSpeedMultiplier = 3f;

	private Plane groundPlane = new Plane(Vector3.up, 0f);

	private CameraMovement cameraMover;

	private QuestConditionWatcher watchedCondition;

	private Tween scaleTween;

	private bool isAffectedByCurrentTile;

	private bool isAboutToBeDestroyed;

	private QuestDirectionScreen questDirectionScreen;

	private bool _003CIsFlagQuestMarker_003Ek__BackingField;

	private int _003CQuestCount_003Ek__BackingField;

	private FulfillmentStatus _003CFulfillmentStatus_003Ek__BackingField;

	public bool IsFlagQuestMarker
	{
		get
		{
			return _003CIsFlagQuestMarker_003Ek__BackingField;
		}
		private set
		{
			_003CIsFlagQuestMarker_003Ek__BackingField = value;
		}
	}

	public int QuestCount
	{
		get
		{
			return _003CQuestCount_003Ek__BackingField;
		}
		private set
		{
			_003CQuestCount_003Ek__BackingField = value;
		}
	}

	public FulfillmentStatus FulfillmentStatus
	{
		get
		{
			return _003CFulfillmentStatus_003Ek__BackingField;
		}
		private set
		{
			_003CFulfillmentStatus_003Ek__BackingField = value;
		}
	}

	public bool Visible
	{
		get
		{
			if (!inputRouter.HighlightingQuests)
			{
				return isAffectedByCurrentTile;
			}
			return true;
		}
	}

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
	}

	private void Start()
	{
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		inputRouter.OnHighlightQuests += StartHighlighting;
		StartHighlighting(inputRouter.HighlightingQuests);
	}

	private void StartHighlighting(bool newHighlighting)
	{
		if (newHighlighting)
		{
			StartCoroutine(HighlightingUpdate());
		}
	}

	public void Setup(QuestDirectionScreen questDirectionScreen, QuestWatcher watcher)
	{
		this.questDirectionScreen = questDirectionScreen;
		cameraMover = OverwritingSingleton<IngameUi>.Instance.cameraContainer.GetComponent<CameraMovement>();
		questWatcher = watcher;
		IsFlagQuestMarker = watcher.GetConditionWatcher(0).Condition.conditionType == QuestConditionType.CloseGroup;
		if (IsFlagQuestMarker)
		{
			elementIcon.sprite = componentLibrary.flagSprite;
			elementIcon.color = watcher.GetConditionWatcher(0).GroupType.color;
		}
		else
		{
			elementIcon.sprite = watcher.GetConditionWatcher(0).ElementType.sprite;
		}
		watchedCondition = questWatcher.GetConditionWatcher(0);
		if (displayCount)
		{
			countText.gameObject.SetActive(watchedCondition.Condition.conditionType != QuestConditionType.CloseGroup);
		}
		watchedCondition.OnConditionFulfillmentChanged += ConditionFulfillmentChanged;
		questWatcher.OnAffectedByCurrentTile += HighlightDueToBeingAffectedByCurrentTile;
		ShortcutExtensions.DOScale(visual.transform, 0f, 0f);
	}

	private void HighlightDueToBeingAffectedByCurrentTile(bool isAffected)
	{
		if (settingsRouter.AutomaticallyHighlightOffscreenQuestsWhenPreviewingTile)
		{
			isAffectedByCurrentTile = isAffected;
			if (isAffected && !inputRouter.HighlightingQuests)
			{
				StartCoroutine(HighlightingUpdate());
			}
			background.raycastTarget = !isAffectedByCurrentTile;
		}
	}

	private void ConditionFulfillmentChanged(int conditionIndex, FulfillmentStatus newFulfillmentStatus, int currentValue, int targetValue, QuestFailedReason failedReason)
	{
		if (displayCount)
		{
			FulfillmentStatus = newFulfillmentStatus;
			QuestCount = currentValue;
			countText.text = watchedCondition.Condition.GetLabelText().Replace("[currentValue]", currentValue.ToString());
			countText.gameObject.SetActive(!IsFlagQuestMarker && (newFulfillmentStatus == FulfillmentStatus.Changed || newFulfillmentStatus == FulfillmentStatus.Unchanged));
			fulfillmentIcon.gameObject.SetActive(!IsFlagQuestMarker && (newFulfillmentStatus == FulfillmentStatus.Fulfilled || newFulfillmentStatus == FulfillmentStatus.Unfulfillable));
			fulfillmentIcon.sprite = ((newFulfillmentStatus == FulfillmentStatus.Unfulfillable) ? failedSprite : fulfilledSprite);
			ChangeColor(newFulfillmentStatus);
			if (Visible)
			{
				questDirectionScreen.ReorderQuestMarkers();
			}
		}
	}

	private void ChangeColor(FulfillmentStatus newFulfillmentStatus)
	{
		Color color = newFulfillmentStatus switch
		{
			FulfillmentStatus.Fulfilled => Constants.UI.Colors.QuestFulfilled, 
			FulfillmentStatus.Unfulfillable => Constants.UI.Colors.QuestFailed, 
			_ => Color.white, 
		};
		if (base.gameObject.activeInHierarchy)
		{
			DOTweenModuleUI.DOColor(background, color, 0.1f);
		}
		else
		{
			background.color = color;
		}
	}

	private IEnumerator HighlightingUpdate()
	{
		return new _003CHighlightingUpdate_003Ed__48(0)
		{
			_003C_003E4__this = this
		};
	}

	public void MoveCameraToQuest()
	{
		cameraMover.MoveCameraTowardsPrecisePosition(questWatcher.transform.position, 2f);
	}

	private void Show(bool newShow)
	{
		if (!base.gameObject)
		{
			Debug.LogError(base.name + " triggers Show but is null");
			return;
		}
		float num = uiScalingManager.CurrentOffscreenQuestMarkerScale * (IsFlagQuestMarker ? flagQuestScale : 1f);
		if (base.gameObject.activeInHierarchy)
		{
			Tween tween = scaleTween;
			if (tween != null)
			{
				TweenExtensions.Kill(tween);
			}
			scaleTween = ShortcutExtensions.DOScale(visual.transform, newShow ? num : 0f, 0.3f);
		}
		else
		{
			visual.transform.localScale = Vector3.one * (newShow ? num : 0f);
		}
	}

	public void Destroy()
	{
		if (!base.gameObject)
		{
			Debug.LogError(base.name + " triggers Destroy but is null");
		}
		else
		{
			if (isAboutToBeDestroyed)
			{
				return;
			}
			isAboutToBeDestroyed = true;
			if (!base.gameObject.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			Sequence sequence = DOTween.Sequence();
			switch (questWatcher.CurrentFulfillmentStatus)
			{
			case FulfillmentStatus.Fulfilled:
				TweenSettingsExtensions.Append(sequence, ShortcutExtensions.DOPunchScale(base.transform, Vector3.one * fulfilledPunchScale, 0.5f));
				TweenSettingsExtensions.AppendInterval(sequence, 1.5f);
				break;
			case FulfillmentStatus.Unfulfillable:
				TweenSettingsExtensions.Append(sequence, ShortcutExtensions.DOShakeRotation(base.transform, 0.5f, 30f));
				TweenSettingsExtensions.AppendInterval(sequence, 1.5f);
				break;
			}
			TweenSettingsExtensions.Append(sequence, ShortcutExtensions.DOScale(visual.transform, 0f, 0.3f));
			TweenSettingsExtensions.OnComplete(sequence, delegate
			{
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}
	}

	private void OnDestroy()
	{
		watchedCondition.OnConditionFulfillmentChanged -= ConditionFulfillmentChanged;
		questWatcher.OnAffectedByCurrentTile -= HighlightDueToBeingAffectedByCurrentTile;
		inputRouter.OnHighlightQuests -= StartHighlighting;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		onClick?.Invoke();
	}

	private void _003CDestroy_003Eb__53_0()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
