using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI
{
	public class AccountHelpAndSupportUI : MonoBehaviour, IUIObject, ISelectableUI
	{
		private const string ACCOUNT_HELP_URL = "https://poncle.games/account-help";

		private const string PRIVACY_POLICY_URL = "https://poncle.games/privacy-policy";

		[SerializeField]
		private TextMeshProUGUI _HelpText;

		[SerializeField]
		private TextMeshProUGUI _HelpButtonText;

		[SerializeField]
		private TextMeshProUGUI _PrivacyPolicyText;

		[SerializeField]
		private TextMeshProUGUI _PrivacyPolicyButtonText;

		[SerializeField]
		private Button _HelpButton;

		[SerializeField]
		private Button _PrivacyPolicyButton;

		private void Awake()
		{
		}

		public void SetHelpText(string text)
		{
		}

		public void SetPrivacyPolicyText(string text)
		{
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public void UpdateNavigation(Selectable above, Selectable below, Selectable left, Selectable right)
		{
		}
	}
}
