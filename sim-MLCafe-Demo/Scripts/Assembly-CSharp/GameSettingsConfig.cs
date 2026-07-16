using System;
using Game.Audio;
using Game.General;
using Game.Graphics;
using Game.Twitch;
using UnityEngine;

[Serializable]
public class GameSettingsConfig
{
	[Header("General Game Settings")]
	public GeneralSettingsContainer generalSettings;

	[Header("Graphics")]
	public GraphicsContainer graphics;

	[Header("Audio")]
	public AudioSettingsContainer audioSettings;

	[Header("Twitch")]
	public TwitchSettingsContainer twitchSettings;

	public GameSettingsConfig()
	{
		generalSettings = GeneralSettingsContainer.DefaultSettings();
		graphics = GraphicsContainer.DefaultSettings();
		audioSettings = AudioSettingsContainer.DefaultSettings();
		twitchSettings = TwitchSettingsContainer.DefaultSettings();
	}
}
