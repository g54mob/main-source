using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.UI.Dialogs;
using I18n;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.UI
{
	[InitializeOnGameStarted]
	public class FeedbackWindow3DUIView : ShowHideAnimation3DUIView
	{
		private static readonly Dictionary<string, int> _recentErrors;

		private static readonly Dictionary<string, int> _quietErrors;

		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private Button3DUIView _sendButton;

		[SerializeField]
		private TMP_InputField _emailText;

		[SerializeField]
		private TMP_InputField _subjectText;

		private static string _defaultSubject;

		private string _errorReportSubject;

		[SerializeField]
		private TextMeshProUGUII18n _errorReportMessageText;

		[SerializeField]
		private GameObject _layoutSwitchButtonsParent;

		[SerializeField]
		private Button3DUIView _defaultLayoutButton;

		[SerializeField]
		private Button3DUIView _errorLayoutButton;

		[SerializeField]
		private GameObject _defaultFeedbackLayout;

		[SerializeField]
		private GameObject _errorFeedbackLayout;

		[SerializeField]
		private TMP_InputField _feedbackText;

		[SerializeField]
		private TMP_InputField _errorFeedbackText;

		[SerializeField]
		private BaseInteractable3DUIView _errorTooltipProvider;

		[SerializeField]
		private CheckBox3DUIView _screenshotCheckBox;

		[SerializeField]
		private MeshRenderer _screenshotRenderer;

		private Texture _screenshotTexture;

		[SerializeField]
		private Transform _screenshotParentTransform;

		[SerializeField]
		private DokoDemoPainterPaintable _painter;

		[SerializeField]
		private DokoDemoPainterPen _painterPen;

		[SerializeField]
		private Transform _editModeScaleParentTransform;

		[SerializeField]
		private Vector3 _editModeScaleParentStartPosition;

		[SerializeField]
		private Button3DUIView _editToggleButton;

		[SerializeField]
		private Button3DUIView _bigPictureButton;

		[SerializeField]
		private Button3DUIView _backButton;

		[SerializeField]
		private Button3DUIView _eraseButton;

		[SerializeField]
		private CheckBox3DUIView _saveGameCheckBox;

		[SerializeField]
		private CheckBox3DUIView _techDataCheckBox;

		[SerializeField]
		private CheckBox3DUIView _privacyCheckBox;

		[SerializeField]
		private TextMeshProUGUII18n _helperText;

		[SerializeField]
		private IfFeedbackButton3DUIView[] _emotionButtons;

		private bool _isEditMode;

		private Sequence _editModeScreenshotSequence;

		private const float _editModeTransitionDuration = 0.2f;

		private List<Action> _cleanUpActions;

		private bool _isOpenPending;

		private InputMode _lastInputMode;

		public const string FEEDBACK_VIEW = "feedback-main";

		public const string CORRUPTION_WARNING_VIEW = "corruption-warning";

		private string _openOnView;

		private bool _isReportInProgress;

		private bool _openedWithReport;

		private bool _isReportQueued;

		[SerializeField]
		private ShowHideAnimation3DUIView _mainWindow;

		[SerializeField]
		private SimpleDecisionWindow3DUIView _decisionWindow;

		[SerializeField]
		private SaveGameCard3DUIView _saveGameCard;

		private bool _hasShownCorruptionWarning;

		public bool IsOpen => false;

		public bool IsReportInProgress => false;

		public static event EventHandler OpenStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler ScreenshotTaken
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Application_logMessageReceived(string errorMessage, string stackTrace, LogType type)
		{
		}

		private void Start()
		{
		}

		private void SaveLoadManagerOnPreLoadEvent(object sender, EventArgs e)
		{
		}

		private void OnCurrentProfileChanged(object sender, EventArgs<PlayerProfile> e)
		{
		}

		private void Update()
		{
		}

		private void ToggleScreenshotEditMode()
		{
		}

		private void ResetPainter()
		{
		}

		protected override void OnDisable()
		{
		}

		private void UpdatePainter()
		{
		}

		protected override void Closed()
		{
		}

		private void ClickEmotionButton(Button3DUIView button)
		{
		}

		protected override bool CanOpen(ShowHideAnimationSpeed speed)
		{
			return false;
		}

		public override void Open(ShowHideAnimationSpeed speed)
		{
		}

		private void SetLayout(bool showErrorLayout, bool enableSwitchButtons)
		{
		}

		public void OpenOnCorruptionWarning()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void ShowMainWindow()
		{
		}

		private Texture CreateScreenshot()
		{
			return null;
		}

		private void OnReportStart()
		{
		}

		private void OnReportFinish()
		{
		}

		private string GetFeedbackTextBody()
		{
			return null;
		}

		private string GetSubject()
		{
			return null;
		}

		private void SendFeedbackReport()
		{
		}

		private string GetTavernId()
		{
			return null;
		}

		private void SaveGame(Action<Stream> onSaved, Action onError)
		{
		}

		private string GatherTechnicalInfo()
		{
			return null;
		}

		private string GatherExtendedInfo(bool includeTechnicalInfo)
		{
			return null;
		}

		public void OpenQueuedAutoReport()
		{
		}

		public static string GetErrorReportMessage()
		{
			return null;
		}

		private bool TrySetReportData(string errorMessage, string defaultFeedbackText)
		{
			return false;
		}

		private void OnFeedbackFinished()
		{
		}

		public void OnPossibleCorruptionDetected()
		{
		}

		private bool TryShowCorruptionWarning()
		{
			return false;
		}

		private bool ShouldShowCorruptionWarning()
		{
			return false;
		}

		private void ShowPostFeedbackWindow()
		{
		}

		private void HideWindowsThenClose()
		{
		}

		private SaveLoadManager.SaveGameHeader GetPreviousSave(SaveLoadManager.SaveGameHeader currentSave, bool ignoreSavesWithErrors)
		{
			return null;
		}

		public void ToggleShowHide()
		{
		}

		public void BackOrClose()
		{
		}
	}
}
