using UnityEngine;

public class SocialsButton : MonoBehaviour
{
	[SerializeField]
	private string steamUrl = "https://store.steampowered.com/app/4126480/Fishing_Inc/?utm_source=Game&utm_medium=SocialsButton&utm_campaign=InDemo";

	[SerializeField]
	private string discordUrl = "https://discord.gg/Y6VrgmAF";

	[SerializeField]
	private string feedbackUrl = "https://forms.google.com/your-form-id-here";

	public void OpenSteamPage()
	{
		Application.OpenURL(steamUrl);
		Debug.Log("Opening Steam: " + steamUrl);
	}

	public void OpenDiscordInvite()
	{
		Application.OpenURL(discordUrl);
		Debug.Log("Opening Discord: " + discordUrl);
	}

	public void OpenFeedbackForm()
	{
		Application.OpenURL(feedbackUrl);
		Debug.Log("Opening Feedback Form: " + feedbackUrl);
	}
}
