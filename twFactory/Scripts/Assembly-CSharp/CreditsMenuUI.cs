using UnityEngine;

public class CreditsMenuUI : HUDMenu
{
	private LTMainMenuHUD ltMainMenuHud;

	protected override void Start()
	{
		base.Start();
		ltMainMenuHud = base.Hud as LTMainMenuHUD;
	}

	public override bool BackButtonPressed()
	{
		if (base.BackButtonPressed())
		{
			OnBackButtonPressed();
			return true;
		}
		return false;
	}

	private void OnEnable()
	{
		base.Hud.BlurBackground(enable: true);
	}

	public void OnGiusCaminitiPressed()
	{
		Application.OpenURL("https://twitter.com/GiusCaminiti");
	}

	public void OnAlejandroMaciaPressed()
	{
		Application.OpenURL("https://twitter.com/macia_music");
	}

	public void OnBackButtonPressed()
	{
		ltMainMenuHud.ShowMainMenuUI();
	}
}
