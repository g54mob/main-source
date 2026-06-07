using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.Story;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh.Tk.UI.Dialogs.Notification
{
	public class InteractiveFictionDialog3DUIView : BaseNotificationDialog3DUIView
	{
		[CompilerGenerated]
		private sealed class _003CLoadIfScene_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string sceneName;

			public Action<GameObject> callback;

			private ResourceRequest _003Coperation_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CLoadIfScene_003Ed__70(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}
		}

		private readonly List<Action> _cleanUpActions;

		private bool _isEarlyClose;

		[SerializeField]
		private GameObject _leftPageContent;

		[SerializeField]
		private GameObject _rightPageContent;

		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private Transform _bookSocket;

		[SerializeField]
		private Transform _ifCanvas;

		[SerializeField]
		private TextBlock3DUIView _titleTextBlock;

		[SerializeField]
		private GameObject _ifSceneController;

		private IFAnimatedImageController _ifAnimatedImageController;

		[SerializeField]
		private GameObject _sceneFrame;

		[Header("Animation settings")]
		public float characterRevealSpeed;

		public float hideDecisionButtonTransitionDuration;

		public float clickDecitionToNextPageDelay;

		public Ease hideDecisionsEase;

		private List<TextBlock3DUIView.CharacterFadeEffect> _buttonFades;

		public float playVoiceOverAndHighlightTextDelay;

		public float playSlinkyAnimDelay;

		public float voiceOverTextStaggerTextDuration;

		[SerializeField]
		protected GameObject _skillsDecisionButtonPrefab;

		private Stopwatch _decisionStopWatch;

		private List<TkWebService.StoryDecisionTrackData> _decisionTracking;

		private List<string> _decisionHistory;

		private List<Action> _revealChoicesAction;

		private string[] _currentContentHashes;

		private TextBlock3DUIView _pageContentTextBlock;

		private UIDialogPageData _currentPageData;

		private Sequence _displayPageTextSequence;

		private Vector3 _canvasShowPosition;

		private Vector3 _canvasHidePosition;

		private bool _isLastPage;

		private ushort _dialogueSessionId;

		private InteractiveFictionBook3DUIView _currentBook;

		public List<InteractiveFictionBook3DUIView> bookPrefabs;

		private bool _listenToGlobalMouseClick;

		private List<Action> _animationActions;

		[SerializeField]
		private GameObject _fateSpinnerPrefab;

		private FateSpinner3DUIView _fateSpinner;

		private int _fateDecisionsMade;

		private bool _isStoppingVoiceOver;

		private VoiceOverHighlightsExtensions.HighlightTextFadeOutAction _currentHightlightedVOLine;

		private Tween _playNextAudioSectionTween;

		public bool IsRunningStory { get; set; }

		public bool IsBusy { get; set; }

		public bool CanSave => false;

		public bool IsCloseable => false;

		public bool IsSceneFrameActive => false;

		public bool IsDecisionsEnabled { get; private set; }

		public string CurrentIfPortalScene { get; private set; }

		public bool IsFateSpinnerActive => false;

		public bool IsVoiceOverPlaying { get; private set; }

		public GameObject VoiceOverSoundObject => null;

		public static void TryReopenIFDialog()
		{
		}

		protected override void Awake()
		{
		}

		private void OnLanguageChanged(object sender, EventArgs e)
		{
		}

		private void OnGameViewChanged(object sender, EventArgs e)
		{
		}

		private void SetupInput()
		{
		}

		protected override void OnAnimEventInternal(object sender, AnimationEventArgs e)
		{
		}

		public override void SetUIData(UINotificationData data)
		{
		}

		protected override GameObject AddDecisionButton(NotificationDecision decision, Action<NotificationDecision, GameObject> callback, Transform decisionContainer)
		{
			return null;
		}

		private void RecordDecision(NotificationDecision decision)
		{
		}

		private void UnhookButtonEvents(Button3DUIView button)
		{
		}

		protected override void ClearDecisionButtons()
		{
		}

		private void PlayDecisionAnimation(Button3DUIView selectedButton, NotificationDecision decision, Action triggerActionLogic)
		{
		}

		private void RevealChoices(bool userInitiated = false)
		{
		}

		private int GetInputNumberForDecision(NotificationDecision decision)
		{
			return 0;
		}

		protected override void DisplayPageTitle(UIDialogPageData page, Transform parent)
		{
		}

		protected void ClearPageTitle()
		{
		}

		private void RefreshCurrentPage()
		{
		}

		protected override void DisplayPageText(UIDialogPageData page, Transform parent)
		{
		}

		[IteratorStateMachine(typeof(_003CLoadIfScene_003Ed__70))]
		private IEnumerator LoadIfScene(string sceneName, Action<GameObject> callback)
		{
			return null;
		}

		public void ShowIfPortalOnLeftPage()
		{
		}

		private void ShowCanvas()
		{
		}

		private void HideCanvas()
		{
		}

		protected override void ShowPage(int page, Transform contentParent)
		{
		}

		private void Update()
		{
		}

		private void UpdateInput()
		{
		}

		private void OnSkipButtonPressed()
		{
		}

		private void OnMoveSelection(int selectionAdjustment)
		{
		}

		private void OnTriggerDecision(int decisionToTrigger)
		{
		}

		private void SetNewSessionId()
		{
		}

		public override void Open(ShowHideAnimationSpeed speed)
		{
		}

		public void SetBook(string ifBookId)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void ResetIfFrame()
		{
		}

		private void OnGeneralLeftClickPerformed(InputAction.CallbackContext obj)
		{
		}

		private void InstanceLeftMouseUpEvent(object sender, InputController.MouseClickEventArgs e)
		{
		}

		protected override void Opened()
		{
		}

		private void AnimateElements()
		{
		}

		private void AddFatePageElements(UIFatePageData page, Transform parent)
		{
		}

		private void InitFateSpinner()
		{
		}

		private void DisplayFateSpinner(UIFatePageData page)
		{
		}

		private void ClearPageContent()
		{
		}

		private void OnSpinComplete(object sender, EventArgs<bool> e)
		{
		}

		private void OnFateDecision(bool isSuccess)
		{
		}

		public override void UpdateUIData(UINotificationData uiNotificationData)
		{
		}

		protected void CloseBook()
		{
		}

		private void OnChaosMeterFinished(object sender, EventArgs<bool> eventArgs)
		{
		}

		protected override bool CanClose(ShowHideAnimationSpeed speed, bool forceClose)
		{
			return false;
		}

		public ActiveStory GetActiveStory()
		{
			return null;
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Closed()
		{
		}

		private void CleanUpBook()
		{
		}

		public void Reopen()
		{
		}

		protected override void OnDisable()
		{
		}

		public override void BackOrClose()
		{
		}

		public override bool IsBackable()
		{
			return false;
		}

		public override void Back()
		{
		}

		private void StopVoiceOver()
		{
		}

		private void PlayVoiceOverHighlights(ushort sessionId, TMP_Text text, string[] voiceOverIds, GameObject characterHighlightParticlePrefab, bool hasAudioMarkersSetup)
		{
		}
	}
}
