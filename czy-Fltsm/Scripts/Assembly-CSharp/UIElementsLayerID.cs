using System;

[Flags]
public enum UIElementsLayerID
{
	HUD = 1,
	Panels_Background = 2,
	Dialogue = 4,
	BottomBar_Game = 8,
	BottomBar_WorldMap = 0x10,
	Panels_Foreground = 0x20,
	HUD_Sticky = 0x40,
	CharacterPortrait = 0x80,
	Panels_Sticky = 0x100
}
