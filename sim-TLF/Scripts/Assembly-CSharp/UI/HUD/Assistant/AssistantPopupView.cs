using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Assistant;
using DG.Tweening;
using JSAM;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using TMPEffects.CharacterData;
using TMPEffects.Components;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.HUD.Assistant
{
	public class AssistantPopupView : UIView, IPointerDownHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField]
		private RectTransform dragHandle;

		[SerializeField]
		private RectTransform windowRoot;

		[SerializeField]
		private Button _hideButton;

		[SerializeField]
		private Button _foldButton;

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private Button _closeSpeechBubbleButton;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private Button _advanceButton;

		[SerializeField]
		private GameObject _assistantObject;

		[SerializeField]
		private TextMeshProUGUI _bubbleText;

		[SerializeField]
		private TMPWriter _bubbleTextWriter;

		[SerializeField]
		private AssistantAnimator _assistantAnimator;

		[SerializeField]
		private AssistantMissionView _assistantMissionViewPrefab;

		[SerializeField]
		private Transform _missionsParent;

		[SerializeField]
		private RectTransform _bubbleContainer;

		[SerializeField]
		private float bubbleTweenDuration = 0.25f;

		[SerializeField]
		private Ease bubbleEase = Ease.OutCubic;

		[SerializeField]
		private float bubbleTargetWidth = 650f;

		[SerializeField]
		private Vector2 unfoldedSize = new Vector2(600f, 400f);

		[SerializeField]
		private Vector2 foldedSize = new Vector2(300f, 100f);

		[SerializeField]
		private Vector2 hidenSize = new Vector2(300f, 100f);

		[SerializeField]
		private float tweenDuration = 0.2f;

		[SerializeField]
		private Ease _tweenEase = Ease.InOutCubic;

		private Vector2 pointerDownPos;

		private Vector2 offset;

		private bool isDragging;

		private ObservableProperty<bool> _folded = new ObservableProperty<bool>();

		private ObservableProperty<bool> _hiden = new ObservableProperty<bool>();

		private ObservableProperty<bool> _closed = new ObservableProperty<bool>();

		private ObservableProperty<bool> _bubbleVisible = new ObservableProperty<bool>();

		private ObservableList<AssistantMissionViewModel> _missions = new ObservableList<AssistantMissionViewModel>();

		private const float dragThreshold = 8f;

		private Dictionary<AssistantMissionViewModel, AssistantMissionView> _missionsViews = new Dictionary<AssistantMissionViewModel, AssistantMissionView>();

		private new void Awake()
		{
			if (_bubbleContainer != null)
			{
				_bubbleContainer.gameObject.SetActive(value: false);
			}
		}

		protected override void Start()
		{
			BindingSet<AssistantPopupView, AssistantPopupViewModel> bindingSet = this.CreateBindingSet<AssistantPopupView, AssistantPopupViewModel>();
			AssistantPopupViewModel service = Context.GetApplicationContext().GetService<AssistantPopupViewModel>();
			this.SetDataContext(service);
			bindingSet.Bind(_hideButton).For((Button v) => v.onClick).To((AssistantPopupViewModel vm) => vm.HideCommand)
				.OneWay();
			bindingSet.Bind(_closeButton).For((Button v) => v.onClick).To((AssistantPopupViewModel vm) => vm.CloseCommand)
				.OneWay();
			bindingSet.Bind(_foldButton).For((Button v) => v.onClick).To((AssistantPopupViewModel vm) => vm.FoldCommand)
				.OneWay();
			bindingSet.Bind(_closeSpeechBubbleButton).For((Button v) => v.onClick).To((AssistantPopupViewModel vm) => vm.CloseSpeechBubble)
				.OneWay();
			bindingSet.Bind(_advanceButton).For((Button v) => v.onClick).To((AssistantPopupViewModel vm) => vm.AdvanceSpeechCommand)
				.OneWay();
			bindingSet.Bind(_bubbleText).For((TextMeshProUGUI v) => v.text).To((AssistantPopupViewModel vm) => vm.SpeechBubbleText)
				.OneWay();
			bindingSet.Bind(this).For((AssistantPopupView v) => v._hiden).To((AssistantPopupViewModel vm) => vm.Hidden)
				.OneWay();
			bindingSet.Bind(this).For((AssistantPopupView v) => v._closed).To((AssistantPopupViewModel vm) => vm.Closed)
				.OneWay();
			bindingSet.Bind(this).For((AssistantPopupView v) => v._folded).To((AssistantPopupViewModel vm) => vm.Folded)
				.OneWay();
			bindingSet.Bind(this).For((AssistantPopupView v) => v._bubbleVisible).To((AssistantPopupViewModel vm) => vm.BubbleVisible)
				.OneWay();
			bindingSet.Bind(this).For((AssistantPopupView v) => v._missions).To((AssistantPopupViewModel vm) => vm.Missions)
				.OneWay();
			bindingSet.Bind().For((AssistantPopupView v) => v.SpeechAnimStart).To((AssistantPopupViewModel vm) => vm.StartSpeech);
			bindingSet.Bind().For((AssistantPopupView v) => v.OnSkipToEndSpeech).To((AssistantPopupViewModel vm) => vm.SkipToEndSpeech);
			bindingSet.Build();
			_bubbleTextWriter.OnStartWriter.AddListener(WritingStarted);
			_bubbleTextWriter.OnFinishWriter.AddListener(WritingFinished);
			_bubbleTextWriter.OnCharacterShown.AddListener(NewCharacterAppeared);
			service.Folded.ValueChanged += FoldedValueChanged;
			service.Closed.ValueChanged += ClosedValueChanged;
			service.Hidden.ValueChanged += HidenValueChanged;
			service.BubbleVisible.ValueChanged += BubbleVisibleChanged;
			service.Missions.CollectionChanged += MissionsChanged;
			if (windowRoot == null)
			{
				windowRoot = GetComponent<RectTransform>();
			}
			Alpha = 0f;
			service.Closed.Value = true;
		}

		private void SpeechAnimStart(object sender, InteractionEventArgs args)
		{
			_bubbleTextWriter.RestartWriter();
		}

		private void OnSkipToEndSpeech(object sender, InteractionEventArgs args)
		{
			if (_bubbleTextWriter.IsWriting)
			{
				_bubbleTextWriter.StopWriter();
				_bubbleTextWriter.ResetWriter();
				ShowAllCharactersInstantly();
			}
			if (this.GetDataContext() is AssistantPopupViewModel assistantPopupViewModel)
			{
				assistantPopupViewModel.IsTextAnimatorPlaying = false;
			}
			_assistantAnimator.SetSmileNeutral();
		}

		private void ShowAllCharactersInstantly()
		{
			TextMeshProUGUI bubbleText = _bubbleText;
			if (bubbleText == null)
			{
				return;
			}
			bubbleText.ForceMeshUpdate();
			TMP_TextInfo textInfo = bubbleText.textInfo;
			for (int i = 0; i < textInfo.characterCount; i++)
			{
				TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
				if (tMP_CharacterInfo.isVisible)
				{
					int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
					int vertexIndex = tMP_CharacterInfo.vertexIndex;
					Color32[] colors = textInfo.meshInfo[materialReferenceIndex].colors32;
					for (int j = 0; j < 4; j++)
					{
						colors[vertexIndex + j].a = byte.MaxValue;
					}
				}
			}
			for (int k = 0; k < textInfo.meshInfo.Length; k++)
			{
				Mesh mesh = bubbleText.textInfo.meshInfo[k].mesh;
				bubbleText.UpdateGeometry(mesh, k);
			}
			bubbleText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
		}

		private void MissionsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				CreateNewMissionView(e.NewItems[0] as AssistantMissionViewModel);
				break;
			case NotifyCollectionChangedAction.Remove:
				ClearMission(e.OldItems[0] as AssistantMissionViewModel);
				break;
			case NotifyCollectionChangedAction.Reset:
				ClearAllMissions();
				break;
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
				break;
			}
		}

		private void ClearAllMissions()
		{
			foreach (KeyValuePair<AssistantMissionViewModel, AssistantMissionView> missionsView in _missionsViews)
			{
				if (missionsView.Value != null)
				{
					UnityEngine.Object.Destroy(missionsView.Value.gameObject);
				}
			}
			_missionsViews.Clear();
		}

		private void ClearMission(AssistantMissionViewModel assistantMissionViewModel)
		{
			UnityEngine.Object.Destroy(_missionsViews[assistantMissionViewModel].gameObject);
		}

		private void CreateNewMissionView(AssistantMissionViewModel assistantMissionViewModel)
		{
			AssistantMissionView assistantMissionView = UnityEngine.Object.Instantiate(_assistantMissionViewPrefab, _missionsParent);
			assistantMissionViewModel.MissionCount = _missionsViews.Count + 1;
			assistantMissionView.SetDataContext(assistantMissionViewModel);
			assistantMissionView.CreateBinding();
			_missionsViews.Add(assistantMissionViewModel, assistantMissionView);
		}

		private void NewCharacterAppeared(TMPWriter arg0, CharData arg1)
		{
			AudioManager.PlaySound(UILibrarySounds.UIMascotTalk);
		}

		private void WritingStarted(TMPWriter arg0)
		{
			_assistantAnimator.SetSpeak();
		}

		private void WritingFinished(TMPWriter arg0)
		{
			Debug.Log("Writing Finished");
			(this.GetDataContext() as AssistantPopupViewModel).IsTextAnimatorPlaying = false;
			_assistantAnimator.SetSmileNeutral();
		}

		private void HidenValueChanged(object sender, EventArgs e)
		{
			_assistantObject.SetActive(!_hiden.Value);
			Debug.Log("Hiden changed: " + _hiden.Value);
			windowRoot.DOSizeDelta(_hiden.Value ? hidenSize : unfoldedSize, tweenDuration).SetEase(_tweenEase);
		}

		private void ClosedValueChanged(object sender, EventArgs e)
		{
			Alpha = ((!_closed.Value) ? 1 : 0);
			_canvasGroup.blocksRaycasts = !_closed.Value;
		}

		private void FoldedValueChanged(object sender, EventArgs e)
		{
			Debug.Log("Folded changed: " + _folded.Value);
			windowRoot.DOSizeDelta(_folded.Value ? foldedSize : unfoldedSize, tweenDuration).SetEase(_tweenEase);
		}

		private void BubbleVisibleChanged(object sender, EventArgs e)
		{
			if (_bubbleVisible.Value)
			{
				_bubbleContainer.gameObject.SetActive(value: true);
				_bubbleContainer.sizeDelta = new Vector2(0f, _bubbleContainer.sizeDelta.y);
				_bubbleContainer.DOSizeDelta(new Vector2(bubbleTargetWidth, _bubbleContainer.sizeDelta.y), bubbleTweenDuration).SetEase(bubbleEase);
			}
			else
			{
				_bubbleContainer.DOSizeDelta(new Vector2(0f, _bubbleContainer.sizeDelta.y), bubbleTweenDuration).SetEase(bubbleEase).OnComplete(delegate
				{
					_bubbleContainer.gameObject.SetActive(value: false);
				});
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.I))
			{
				AssistantPopupViewModel assistantPopupViewModel = this.GetDataContext() as AssistantPopupViewModel;
				if (assistantPopupViewModel.Closed.Value)
				{
					assistantPopupViewModel.Appear();
				}
				else
				{
					assistantPopupViewModel.Disappear();
				}
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (RectTransformUtility.RectangleContainsScreenPoint(dragHandle, eventData.position, eventData.pressEventCamera))
			{
				pointerDownPos = eventData.position;
				isDragging = false;
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (Vector2.Distance(eventData.position, pointerDownPos) > 8f && RectTransformUtility.RectangleContainsScreenPoint(dragHandle, eventData.position, eventData.pressEventCamera))
			{
				isDragging = true;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(windowRoot, eventData.position, eventData.pressEventCamera, out offset);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (isDragging && RectTransformUtility.ScreenPointToLocalPointInRectangle(windowRoot.parent as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
			{
				windowRoot.localPosition = localPoint - offset;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			isDragging = false;
		}
	}
}
