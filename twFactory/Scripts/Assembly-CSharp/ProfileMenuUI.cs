using UnityEngine;

public class ProfileMenuUI : HUDMenu
{
	private LTMainMenuHUD ltMainMenuHud;

	[SerializeField]
	private UIList profilesList;

	protected override void Start()
	{
		base.Start();
		ltMainMenuHud = base.Hud as LTMainMenuHUD;
		SaveSystem.instance.onProfilesChanged += OnProfilesChanged;
		LoadProfilesList();
	}

	private void OnDestroy()
	{
		SaveSystem.instance.onProfilesChanged -= OnProfilesChanged;
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
		SaveSystem.instance.CurrentProfile.GenerateMetadata();
		SaveSystem.instance.SaveData();
	}

	private void LoadProfilesList()
	{
		profilesList.LoadList(SaveSystem.instance.GetAllProfiles());
	}

	private void OnProfilesChanged()
	{
		LoadProfilesList();
	}

	public void OnBackButtonPressed()
	{
		ltMainMenuHud.ShowMainMenuUI();
	}
}
