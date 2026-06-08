using UnityEngine;
using UnityEngine.UI;

namespace CloudOnce.QuickStart
{
	[AddComponentMenu("CloudOnce/Google Sign In-Out Button", 5)]
	public class GoogleSignOutButton : MonoBehaviour
	{
		private Button cachedButton;

		private Text textComponent;

		private Button CachedButton => cachedButton ?? (cachedButton = GetComponent<Button>());

		private Text TextComponent => textComponent ?? (textComponent = GetComponentInChildren<Text>());

		private void UpdateButtonText(bool isSignedIn)
		{
			TextComponent.text = (isSignedIn ? "Sign out" : "Sign in");
		}

		private void Awake()
		{
			Cloud.OnSignedInChanged += UpdateButtonText;
			if (CachedButton != null)
			{
				CachedButton.onClick.AddListener(OnButtonClicked);
				UpdateButtonText(Cloud.IsSignedIn);
			}
			else
			{
				Debug.LogError("Google Sign In/Out Button script placed on GameObject that is not a button. Script is only compatible with UI buttons created from GameObject menu (GameObjects -> UI -> Button).");
			}
		}

		private void OnButtonClicked()
		{
			if (Cloud.IsSignedIn)
			{
				Cloud.SignOut();
			}
			else
			{
				Cloud.SignIn();
			}
		}

		private void OnEnable()
		{
			UpdateButtonText(Cloud.IsSignedIn);
		}

		private void OnDestroy()
		{
			if (CachedButton != null)
			{
				CachedButton.onClick.RemoveListener(OnButtonClicked);
			}
			Cloud.OnSignedInChanged -= UpdateButtonText;
		}
	}
}
