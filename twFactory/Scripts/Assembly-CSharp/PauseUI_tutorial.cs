using UnityEngine.SceneManagement;

public class PauseUI_tutorial : HUDMenu
{
	private bool isExiting;

	public override bool BackButtonPressed()
	{
		if (!isExiting && base.BackButtonPressed())
		{
			OnContinueButtonPressed();
			return true;
		}
		return false;
	}

	public void OnContinueButtonPressed()
	{
		LTFunctionLibrary.GetLTGameManager().PauseGame(pause: false);
	}

	public void OnSettingsButtonPressed()
	{
		(base.Hud as LTHUD).ShowSettingsUI();
	}

	public void OnExitButtonPressed()
	{
		float time = 1f;
		isExiting = true;
		float masterVolume = SettingsController.instance.GetMasterVolume();
		base.Hud.FadeInOut.FadeIn(time, delegate(float timePercentage)
		{
			AudioSystem.Instance.SetMixerVolume(masterVolume - masterVolume * timePercentage, AudioSystem.EAudioMixerGroup.Master);
		}, delegate
		{
			LoadingScreenController.sceneToLoadIdx = 0;
			SceneManager.LoadScene(1, LoadSceneMode.Single);
		});
	}
}
