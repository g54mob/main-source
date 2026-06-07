using UnityEngine;

public class InGameHUD : HUD
{
	[SerializeField]
	private HUDMenu inGameUI;

	[SerializeField]
	private HUDMenu pauseUI;

	private bool isPauseMenuOpen;

	public bool IsPauseMenuOpen
	{
		get
		{
			return isPauseMenuOpen;
		}
		protected set
		{
			isPauseMenuOpen = value;
		}
	}

	protected override void Start()
	{
		base.Start();
		GameManager.instance.onPause += OnGamePaused;
		GameManager.instance.onResume += OnGameResumed;
		IsPauseMenuOpen = false;
		ShowInGameUI();
	}

	public virtual void ShowInGameUI()
	{
		ShowMenu(inGameUI);
	}

	public virtual void ShowPauseUI()
	{
		ShowMenu(pauseUI);
	}

	protected virtual void OnGamePaused()
	{
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
		{
			ShowPauseUI();
			BlurBackground(enable: true);
			IsPauseMenuOpen = true;
		}
	}

	protected virtual void OnGameResumed()
	{
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
		{
			ShowInGameUI();
			BlurBackground(enable: false);
			IsPauseMenuOpen = false;
		}
	}
}
