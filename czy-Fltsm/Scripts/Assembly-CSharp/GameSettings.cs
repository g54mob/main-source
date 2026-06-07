using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/Game Settings")]
public class GameSettings : ScriptableObject
{
	public const string PATH = "Settings";

	public const string SCRIPTABLE_OBJECT_PATH = "Assets/Game Settings";

	[Header("Version")]
	public GameVersion Version;

	[Header("Gameplay")]
	[Tooltip("Settings related to gameplay.")]
	public GameplaySettings GameplaySettings;

	[Header("Game Session")]
	[Tooltip("Settings for the default game session.")]
	public SessionSettings SessionSettings;

	[Header("World")]
	[Tooltip("Settings for the world")]
	public WorldProperties WorldSettings;

	[Header("Buildables")]
	[Tooltip("Settings for buildables.")]
	public BuildableSettings BuildableSettings;

	[Header("Boats")]
	public BoatSettings BoatSettings;

	[Header("Projects")]
	[Tooltip("Settings for projects.")]
	public ProjectSettings ProjectSettings;

	[Header("Audio")]
	[Tooltip("Settings for audio.")]
	public AudioSettings AudioSettings;

	[Header("UI")]
	[Tooltip("The UI settings.")]
	public UISettings UISettings;

	[Header("FX")]
	[Tooltip("The FX settings.")]
	public FXSettings FXSettings;

	[Header("Data")]
	[Tooltip("The data settings.")]
	public DataSettings DataSettings;

	[Header("Items")]
	[Tooltip("The item settings.")]
	public ItemSettings ItemSettings;

	[Header("Flotsam")]
	[Tooltip("The flotsam settings.")]
	public FlotsamSettings FlotsamSettings;

	[Header("Points of interest")]
	[Tooltip("The landmark settings.")]
	public LandmarkSettings LandmarkSettings;

	[Header("Cursors")]
	[Tooltip("The cursor settings.")]
	public CursorSettings CursorSettings;

	[Header("Agents and animals")]
	public AgentSettings AgentSettings;

	[Header("Research")]
	public TechTree TechTree;

	[Header("Default Player Settings")]
	[Tooltip("Volume of the master audio in decibels.")]
	[Range(0f, 1f)]
	public float MasterVolume = 0.8f;

	[Header("UNSORTED")]
	[Tooltip("Force to use whenever the player taps on a buoyant object.")]
	public float PokeForce = 2.5f;

	[Tooltip("Play the music track.")]
	public bool PlayMusic;

	private static GameSettings _instance;

	public static GameSettings Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogException(new Exception("GameSettings were not provisioned by GameManager."));
				SetInstance(Resources.Load<GameSettings>("Settings"));
			}
			return _instance;
		}
	}

	public static void SetInstance(GameSettings instance)
	{
		_instance = instance;
	}

	public static WorldProperties ReturnWorldSettings()
	{
		if ((bool)GameManager.Settings)
		{
			return GameManager.Settings.WorldSettings;
		}
		return null;
	}
}
