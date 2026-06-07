using System;
using UnityEngine;

[Serializable]
public struct PopupRegistry
{
	public ConfirmationPopup generic;

	public FirstGamePopup firstGame;

	public RehirePopup rehire;

	public HistoryPopup history;

	public GalleryPopup gallery;

	public SettingsPopup settings;

	public CustomizationPopup customization;

	public AchievementPopup achievement;

	public MinesweeperPopup minesweeper;

	public MediaPlayerPopup mediaPlayer;

	public MailPopup mail;

	public NotInDemoPopup notInDemo;

	public BsodPopup bsod;

	public GameObject gnormanMuffled;
}
