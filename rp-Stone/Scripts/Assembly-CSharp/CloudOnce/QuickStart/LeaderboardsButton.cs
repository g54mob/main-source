using UnityEngine;
using UnityEngine.UI;

namespace CloudOnce.QuickStart
{
	[AddComponentMenu("CloudOnce/Show Leaderboards Button", 4)]
	public class LeaderboardsButton : MonoBehaviour
	{
		private Button button;

		private static void OnSignedInChanged(bool isSignedIn)
		{
			Cloud.OnSignedInChanged -= OnSignedInChanged;
			if (isSignedIn)
			{
				Cloud.Leaderboards.ShowOverlay();
			}
		}

		private static void SubscribeEvent()
		{
			Cloud.OnSignedInChanged -= OnSignedInChanged;
			Cloud.OnSignedInChanged += OnSignedInChanged;
		}

		private void OnButtonClicked()
		{
			if (Cloud.IsSignedIn)
			{
				Cloud.Leaderboards.ShowOverlay();
				return;
			}
			SubscribeEvent();
			Cloud.SignIn();
		}

		private void Awake()
		{
			button = GetComponent<Button>();
			if (button == null)
			{
				Debug.LogError("Show Leaderboards Button script placed on GameObject that is not a button. Script is only compatible with UI buttons created from GameObject menu (GameObjects -> UI -> Button).");
			}
		}

		private void Start()
		{
			button.onClick.AddListener(OnButtonClicked);
		}

		private void OnDestroy()
		{
			button.onClick.RemoveListener(OnButtonClicked);
			Cloud.OnSignedInChanged -= OnSignedInChanged;
		}
	}
}
