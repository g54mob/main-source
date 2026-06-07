using System;
using UnityEngine;

public class GameModeMenuUI : HUDMenu
{
	private LTMainMenuHUD ltMainMenuHud;

	[SerializeField]
	private GameMode[] gameModes;

	private UIList gameModesList;

	protected override void Awake()
	{
		base.Awake();
		gameModesList = GetComponent<UIList>();
	}

	protected override void Start()
	{
		base.Start();
		ltMainMenuHud = base.Hud as LTMainMenuHUD;
	}

	private void OnEnable()
	{
		SetupGameModesUIs();
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

	private void SetupGameModesUIs()
	{
		gameModesList.LoadList(gameModes);
		foreach (UIListElement element in gameModesList.Elements)
		{
			element.onClickElement = (Action<UIListElement>)Delegate.Combine(element.onClickElement, (Action<UIListElement>)delegate(UIListElement x)
			{
				MatchInfo.instance.CurrentGameMode = (x as GameModeUI).GameMode;
				OnBackButtonPressed();
			});
		}
	}

	public void OnBackButtonPressed()
	{
		ltMainMenuHud.ShowNewGameMenuUI();
	}
}
