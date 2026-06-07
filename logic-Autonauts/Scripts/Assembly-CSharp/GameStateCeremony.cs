using System.Collections.Generic;

public class GameStateCeremony : GameStateBase
{
	private bool m_Blur;

	protected new void Awake()
	{
		base.Awake();
		HighlightObject(null);
		HudManager.Instance.RolloversEnabled(false);
		HudManager.Instance.SetHudButtonsActive(false);
		CameraManager.Instance.EnableVignette(true);
		Cursor.Instance.NoTarget();
		TutorialPanelController.Instance.CeremonyActive(true);
		HudManager.Instance.SetIndicatorsVisible(false);
	}

	protected new void OnDestroy()
	{
		HudManager.Instance.SetIndicatorsVisible(true);
		TutorialPanelController.Instance.CeremonyActive(false);
		HudManager.Instance.RolloversEnabled(true);
		HudManager.Instance.SetHudButtonsActive(true);
		if (m_Blur)
		{
			CameraManager.Instance.RestorePausedDOFEffect();
		}
		else
		{
			CameraManager.Instance.EnableVignette(false);
		}
		base.OnDestroy();
	}

	public void SetBlur()
	{
		m_Blur = true;
		CameraManager.Instance.SetPausedDOFEffect();
	}

	public override void UpdateState()
	{
		if (!MyInputManager.m_Rewired.GetButtonDown("Quit"))
		{
			return;
		}
		CeremonyManager.CeremonyType type = CeremonyManager.Instance.m_CurrentCeremonyData.m_Type;
		if (type != CeremonyManager.CeremonyType.RocketIntro && type != CeremonyManager.CeremonyType.CommsIntro && type != CeremonyManager.CeremonyType.Go && type != CeremonyManager.CeremonyType.QuestEnded)
		{
			return;
		}
		if (type == CeremonyManager.CeremonyType.RocketIntro || type == CeremonyManager.CeremonyType.CommsIntro || type == CeremonyManager.CeremonyType.Go)
		{
			if (GameOptionsManager.Instance.m_Options.m_TutorialEnabled)
			{
				TutorialPanelController.Instance.StartTutorial();
			}
			List<BaseClass> players = CollectionManager.Instance.GetPlayers();
			CameraManager.Instance.Focus(players[0].transform.position);
			CameraManager.Instance.SetDistance(13f);
		}
		CeremonyManager.Instance.SkipCeremony();
	}
}
