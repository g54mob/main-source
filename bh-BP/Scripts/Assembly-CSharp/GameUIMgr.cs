using UnityEngine;

public class GameUIMgr : MonoBehaviour
{
	public static GameUIMgr I;

	public GameOverUI GameOver;

	public LevelUpUI LevelUp;

	public PauseUI Pause;

	public GameCheatUI Cheat;

	public GameCharInfoUI CharInfo;

	public DialogUI Dialog;

	public GameHoverPopup HovPopup;

	public BlueprintFoundUI BlueprintFound;

	public EggFoundUI EggFound;

	public BaseSettingsUI Settings;

	public GameTutUI TutUI;

	public MaskedFTUEOverlay FTUEOverlay;

	public ReviveUI Revive;

	public EncyclopediaUI Encyclopedia;

	public TouchControlsUI TouchControls;

	public CreditsUI Credits;

	public FullScreenMessageUI DemoComplete;

	private void Awake()
	{
	}
}
