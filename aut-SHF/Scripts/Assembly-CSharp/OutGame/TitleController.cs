using DG.Tweening;
using InputControl;
using TMPro;
using UnityEngine;

namespace OutGame
{
	public class TitleController : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup menuGroup;

		[SerializeField]
		private VideoPlayerCtrl videoPlayerCtrl;

		[SerializeField]
		private int waitTimeForDemoMovie;

		[SerializeField]
		private TMP_Text verText;

		[SerializeField]
		private TMP_Text steamBuildIdText;

		[SerializeField]
		private GameObject loadButton;

		[SerializeField]
		private GameObject lodingObj;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		private Tween demoMoviePlayWaitTween;

		private bool isPlayingDemoMovie;

		private InputActionController input;

		private bool isFinishedPreparedAction;

		private bool isClosedGameMode;

		private bool isIncompatibleData;

		private bool isCompletelyIncompatibleData;

		private string[] trialAllowedLocales;

		[SerializeField]
		private GameObject developmentTextObj;

		[SerializeField]
		private GameObject trialTextObj;

		[SerializeField]
		private GameObject inhouseTrialTextObj;

		[SerializeField]
		private GameObject showLogoObj;

		[SerializeField]
		private CursorUIGroup releaseNoteButton;

		[SerializeField]
		private GameObject gameEndButton;

		[SerializeField]
		private CursorUIGroup webhookGroup;

		[SerializeField]
		private CursorUIGroup buttonGroup;

		[SerializeField]
		private CursorUIGroup profileGroup;

		[SerializeField]
		private CursorUIGroup languageGroup;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void OnNewGame()
		{
		}

		public void CheckAndStartNewGame(bool isOk)
		{
		}

		public void OnLoadGame()
		{
		}

		public void OnContinue()
		{
		}

		public void OnLoadScene(string sceneName)
		{
		}

		public void OnDisplayDialog(string dialogName)
		{
		}

		public void OnQuitApplication()
		{
		}

		private void OnDestroy()
		{
		}

		public void OpenChangeProfileDialog()
		{
		}

		private void DisableTitleMenuButton(GameObject buttonObj)
		{
		}

		public void SelectButtonGroupRight()
		{
		}

		public void SelectProfileGroupLeft()
		{
		}

		public void SelectProfileGroupRight()
		{
		}

		public void SelectLanguageGroupLeft()
		{
		}
	}
}
