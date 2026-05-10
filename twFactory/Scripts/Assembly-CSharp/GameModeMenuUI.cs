using System;
using UnityEngine;

public class GameModeMenuUI : HUDMenu
{
	private LTMainMenuHUD ltMainMenuHud;

	[SerializeField]
	private MatchSettings[] matchSettings;

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
		gameModesList.LoadList(matchSettings);
		foreach (UIListElement element in gameModesList.Elements)
		{
			element.onClickElement = (Action<UIListElement>)Delegate.Combine(element.onClickElement, (Action<UIListElement>)delegate(UIListElement x)
			{
				MatchInfo.instance.CurrentMatchSettings = (x as GameModeUI).MatchSettings;
				OnBackButtonPressed();
			});
		}
	}

	public void OnBackButtonPressed()
	{
		ltMainMenuHud.ShowNewGameMenuUI();
	}
}
