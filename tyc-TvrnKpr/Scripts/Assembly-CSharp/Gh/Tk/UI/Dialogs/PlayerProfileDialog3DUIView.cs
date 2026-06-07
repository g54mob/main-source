using System;
using System.Collections.Generic;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class PlayerProfileDialog3DUIView : BaseDialog3DUIView, IPrefabProvider
	{
		[SerializeField]
		private Button3DUIView[] _closeButtons;

		[SerializeField]
		private TextMeshProI18n _title;

		[SerializeField]
		private TMP_InputField _profileNameInput;

		[SerializeField]
		private TMP_InputField _emailInput;

		[SerializeField]
		private TextMeshProUGUII18n _feedbackText;

		[SerializeField]
		private Button3DUIView _newsletterButton;

		[SerializeField]
		private CheckBox3DUIView _newsletterPolicyCheckbox;

		[SerializeField]
		private Button3DUIView _changeProfileButton;

		[SerializeField]
		private Button3DUIView _newProfileButton;

		[SerializeField]
		private Button3DUIView _editSkillsButton;

		[SerializeField]
		private Button3DUIView _statsTabButton;

		[SerializeField]
		private Button3DUIView _profileTabButton;

		[SerializeField]
		private Button3DUIView _cancelButton;

		[SerializeField]
		private Button3DUIView _saveButton;

		[SerializeField]
		private GameObject _profilesPage;

		[SerializeField]
		private GameObject _profileEditPage;

		[SerializeField]
		private GameObject _statsPage;

		[SerializeField]
		private Container3DUIView _statsPageContent;

		[SerializeField]
		private GameObject _profileButtonPrefab;

		[SerializeField]
		private Container3DUIView _profileButtonsContainer;

		[SerializeField]
		private DissolveArea3DUIView _dissolveArea;

		private bool _isInitialized;

		[SerializeField]
		private List<GameObject> _layoutPrefabs;

		[SerializeField]
		private GameObject _simpleStatPrefab;

		[SerializeField]
		private GameObject _statHeaderPrefab;

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void NewsletterSubscribeSuccess(string result)
		{
		}

		private void NewsletterSubscribeError(string result)
		{
		}

		private void RefreshTabButtons()
		{
		}

		private void OpenProfileEditPage(PlayerProfile profile)
		{
		}

		private void OpenProfilePickerPage()
		{
		}

		private void OpenStatsPage()
		{
		}

		private void UpdateDissolveMaterials()
		{
		}

		public GameObject GetPrefab(string prefabName)
		{
			return null;
		}

		protected void AddStatElement(string labelKey, string value, Transform container)
		{
		}

		protected void AddStatHeader(string heading)
		{
		}

		private void AddStats()
		{
		}

		private void AddGameStatElement(string key, string labelKey, Func<float, float> converterFunc = null, bool obfuscateIfZero = false)
		{
		}

		private void CloseAllPages()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}
	}
}
