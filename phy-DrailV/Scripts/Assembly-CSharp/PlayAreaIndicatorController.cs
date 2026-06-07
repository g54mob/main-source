using UnityEngine;

public class PlayAreaIndicatorController : MonoBehaviour
{
	private void Start()
	{
		UpdateIndicator();
		GamePreferences.RegisterToPreferenceUpdated(Preferences.PlayAreaIndicator, UpdateIndicator);
	}

	private void UpdateIndicator()
	{
		bool active = GamePreferences.Get<bool>(Preferences.PlayAreaIndicator);
		base.gameObject.SetActive(active);
	}
}
