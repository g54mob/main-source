using System;
using System.Collections.Generic;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Saves;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors
{
	public class PopupManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _Fader;

		[SerializeField]
		private AutomationPopup _AutomationPopup;

		[SerializeField]
		private LargeMultiOptionPopup _LargeMultiOption;

		[SerializeField]
		private LargeMultiOptionSavePopup _LargeMultiOptionSaves;

		[SerializeField]
		private LargeLoadableDLCSelectionPopup _LargeLoadableDLCSelectionPopup;

		[SerializeField]
		private BlockingPopup _BlockingPopup;

		[SerializeField]
		private OkCancelPopup _OkCancelPopup;

		[SerializeField]
		private WarningPopup _WarningPopup;

		[SerializeField]
		private ErrorPopup _ErrorPopup;

		[SerializeField]
		private TwoButtonPopup _TwoButtonPopup;

		[SerializeField]
		private TextInputPopup _TextInputPopup;

		[SerializeField]
		private AdventureCompletedPopup _AdventureCompletedPopup;

		[SerializeField]
		private TutorialPopup _TutorialPopup;

		[SerializeField]
		private HelpPopup _HelpPopup;

		[SerializeField]
		private AccountErrorPopup _AccountErrorPopup;

		[SerializeField]
		private BlockingPopup _AccountBlockingPopup;

		[SerializeField]
		private AdvancedMusicSelection _AdvancedMusicSelection;

		[SerializeField]
		private EULAPopup _EULAPopup;

		private static PopupManager Instance;

		private GameObject _currentFader;

		private static DataManager _dataManager;

		private Dictionary<string, GameObject> _popups;

		private RewiredStandaloneInputModule _inputModule;

		public static bool IsShowingPopups => false;

		private RewiredStandaloneInputModule InputModule => null;

		[Inject]
		private void Construct(DataManager dataManager)
		{
		}

		private void Awake()
		{
		}

		public static LargeMultiOptionPopup CreateLargeMultiOption(string id, string title, string description, List<OptionDataSet> options, Action<int> callback, Action closedCallback = null, bool textIsLocalizationTerm = true, TextAlignmentOptions? textAlignment = null, bool centerTicks = false)
		{
			return null;
		}

		public static void CreateLoadableDLCSelection(string id, Action callback, bool textisLocalizationTerm = true, bool runCallbackIfNoDLC = true, bool showBackButton = false)
		{
		}

		public static TutorialPopup CreateTutorialPopup(string id, string titleTerm, string descriptionTerm, string buttonTerm)
		{
			return null;
		}

		private static void ApplyCanvasSettings(GameObject p, int sortingOrder = 11001)
		{
		}

		public static void CreateBlockingPopup(string id, string title, string description, bool textisLocalizationTerm, Action onClose = null)
		{
		}

		public static void CreateAccountBlockingPopup(string id, string title, string description, bool textisLocalizationTerm, Action onClose = null)
		{
		}

		public static void CreateSaveFileComparison(string id, string title, string description, List<SaveSummary> options, Action<int> callback, bool textIsLocalizationTerm = true, bool hasCancelButton = false, Action onCancel = null)
		{
		}

		public static void CreateOKCancelPopup(string id, string text, string description, Action<bool> callback, bool textIsLocalizationTerm = true)
		{
		}

		public static void CreateWarningPopup(string id, string text, string description, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true)
		{
		}

		public static void CreateOnlineErrorPopup(string id, string text, string description, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true)
		{
		}

		public static void CreateHelpPopup(string id, string text, string description, string helpText, string helpUrl, string qrCodeName, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool helpTextIsLocalizationTerm = true)
		{
		}

		public static void CreateAccountErrorPopup(string id, string text, string description, string helpText, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool helpTextIsLocalizationTerm = true)
		{
		}

		public static void CreateErrorPopup(string id, string error, bool textIsLocalizationTerm = false)
		{
		}

		public static void CreateTwoButtonPopup(string id, string title, string description, string button1Text, string button2Text, Action button1Callback, Action button2Callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true, bool button2TextIsLocalizationTerm = true)
		{
		}

		public static void CreateEULAPopup(string id, string title, string button1Text, string button2Text, Action button1Callback, Action button2Callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true, bool button2TextIsLocalizationTerm = true)
		{
		}

		public static void CreateTextInputPopup(string id, string title, string button1Text, Action<string> button1Callback, bool titleIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true)
		{
		}

		public static AdventureCompletedPopup CreateAdventureCompletedPopup(string id)
		{
			return null;
		}

		public static BasePopup CreateAdvancedMusicSelectionPopup(string id)
		{
			return null;
		}

		private void MakeFader(float targetAlpha = 0.5f, float duration = 0.1f)
		{
		}

		public static void ClosePopup(string id)
		{
		}

		public static bool PopupExists(string id)
		{
			return false;
		}

		public static GameObject GetPopup(string id)
		{
			return null;
		}

		public static T GetPopup<T>(string id) where T : Component
		{
			return null;
		}

		public static void SetAllowInput(bool val)
		{
		}

		private static string Translate(string text)
		{
			return null;
		}

		private void TestLargeMultiOption()
		{
		}

		public static void MakeTESTLargeMultiOption()
		{
		}

		private void TestTutorialPopup()
		{
		}

		public static void MakeTESTTutorialPopup()
		{
		}

		private void TestBlockingPopup()
		{
		}

		public static void MakeTESTBlockingPopup()
		{
		}

		private void TestAccountBlockingPopup()
		{
		}

		public static void MakeTESTAccountBlockingPopup()
		{
		}

		private void TestSaveFileComparison()
		{
		}

		public static void MakeTESTSaveFileComparison()
		{
		}

		private void TestOKCancel()
		{
		}

		public static void MakeTESTOKCancel()
		{
		}

		private void TestWarning()
		{
		}

		private void TestHelpError()
		{
		}

		public static void MakeTESTWarning()
		{
		}

		private void TestAccountError()
		{
		}

		public static void MakeTESTAccountError()
		{
		}

		private void TestError()
		{
		}

		public static void MakeTESTError()
		{
		}

		private void TestTwoButton()
		{
		}

		public static void MakeTESTTwoButton()
		{
		}

		private void TestAdventureCompleted()
		{
		}

		public static void MakeTESTAdventureCompleted()
		{
		}
	}
}
