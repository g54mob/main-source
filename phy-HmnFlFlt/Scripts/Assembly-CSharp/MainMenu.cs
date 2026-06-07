using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuTransition
{
	public static bool hideLogo;

	public GameObject logo;

	public ButtonGroup menuButtons;

	public VerticalLayoutGroup buttonLayout;

	public Button extrasButton;

	public Button workshopButton;

	private bool transitioning;

	public static bool InMainMenu;

	public override void OnGotFocus()
	{
		base.OnGotFocus();
		transitioning = false;
		InMainMenu = true;
		Physics.autoSimulation = true;
		logo.SetActive(StartupExperienceUI.instance == null || !StartupExperienceUI.instance.gameObject.activeInHierarchy);
		if (TutorialRepository.instance.HasAvailableItems() || VideoRepository.instance.HasAvailableItems())
		{
			extrasButton.gameObject.SetActive(true);
		}
		else
		{
			extrasButton.gameObject.SetActive(false);
		}
		if (workshopButton != null)
		{
			workshopButton.gameObject.SetActive(false);
		}
		menuButtons.RebuildLinks(true);
	}

	protected override void Update()
	{
		bool flag = StartupExperienceUI.instance == null || !StartupExperienceUI.instance.gameObject.activeInHierarchy;
		if (logo.activeSelf != flag)
		{
			Debug.LogError("MainMenu: Emergency fixup of logo visibility");
			logo.SetActive(flag);
		}
		base.Update();
	}

	private void DLCAvailableClick()
	{
	}

	public override void OnLostFocus()
	{
		base.OnLostFocus();
		RemoveStartExperienceLogo();
		InMainMenu = false;
	}

	public void PlayClick()
	{
		if (MenuSystem.CanInvoke && !transitioning)
		{
			TransitionForward<SelectPlayersMenu>();
		}
	}

	public void WorkshopClick()
	{
		if (MenuSystem.CanInvoke && !transitioning)
		{
			LevelSelectMenu2.instance.SetMultiplayerMode(false);
			LevelSelectMenu2.instance.ShowSubscribed();
			TransitionForward<LevelSelectMenu2>();
		}
	}

	public void MultiplayerClick()
	{
		if (MenuSystem.CanInvoke && !transitioning)
		{
			TransitionForward<MultiplayerMenu>();
		}
	}

	public void OptionsClick()
	{
		if (MenuSystem.CanInvoke && !transitioning)
		{
			OptionsMenu.returnToPause = false;
			TransitionForward<OptionsMenu>();
		}
	}

	public void CustomizeClick()
	{
		if (MenuSystem.CanInvoke && !transitioning)
		{
			if (GiftService.instance != null)
			{
				GiftService.instance.RefreshStatus();
			}
			transitioning = true;
			StartCoroutine(TransitionToCustomisation());
		}
	}

	private IEnumerator TransitionToCustomisation()
	{
		RemoveStartExperienceLogo();
		if (MenuSystem.instance.activeMenu == this)
		{
			MenuSystem.instance.FocusOnMouseOver(false);
			Transition(-0.99f, 0.3f);
		}
		float dur = 0.5f;
		MenuCameraEffects.FadeToBlack(dur);
		yield return null;
		yield return new WaitForSeconds(dur);
		yield return null;
		transitioning = false;
		MenuSystem.instance.TransitionForward<CustomizationRootMenu>(this, 0f, 10000f);
	}

	public void ExtrasClick()
	{
		if (MenuSystem.CanInvoke && !transitioning)
		{
			TransitionForward<ExtrasMenu>();
		}
	}

	public void ExitClick()
	{
		if (MenuSystem.CanInvoke && !transitioning)
		{
			TransitionForward<ConfirmQuitMenu>();
		}
	}

	public override void ApplyMenuEffects()
	{
		MenuCameraEffects.FadeInMainMenu();
	}

	private void RemoveStartExperienceLogo()
	{
		if (StartupExperienceUI.instance != null)
		{
			logo.SetActive(true);
			if (StartupExperienceUI.instance.gameObject != null)
			{
				StartupExperienceUI.instance.gameObject.SetActive(false);
			}
			Object.Destroy(StartupExperienceUI.instance.gameObject);
		}
		else
		{
			logo.SetActive(true);
		}
	}

	private void Start()
	{
	}
}
