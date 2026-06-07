using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class ShareCodePopUp3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private TMP_InputField _inputField;

		[SerializeField]
		private CheckBox3DUIView _gameDataPolicyCheckbox;

		[SerializeField]
		private GameObject _codeInputPanel;

		[SerializeField]
		private Button3DUIView _fetchButton;

		[SerializeField]
		private Button3DUIView[] _closeButtons;

		[SerializeField]
		private SaveGameCard3DUIView _saveGameCard;

		[SerializeField]
		private Button3DUIView _loadSaveButton;

		[SerializeField]
		private ShareCodeImportGallery3DUIView _galleryPanel;

		[SerializeField]
		private Button3DUIView _importBuildablesButton;

		private bool _inProgress;

		private BuildableTemplate[] buildableTemplates;

		protected override void Awake()
		{
		}

		public override void Back()
		{
		}

		public override bool IsBackable()
		{
			return false;
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void OnLoadStart()
		{
		}

		private void OnLoadFinish()
		{
		}

		private string GetShareCode()
		{
			return null;
		}

		private string AutoCorrectShareCode(string shareCode)
		{
			return null;
		}

		private void FetchSharedData()
		{
		}

		private void DisplayBuildableTemplates()
		{
		}

		private void ConfirmBuildableTemplateImport()
		{
		}

		private void LoadSharedSave()
		{
		}
	}
}
