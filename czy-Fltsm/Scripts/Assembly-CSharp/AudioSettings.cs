using System.Collections.Generic;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Flotsam/Settings/Audio Settings")]
public class AudioSettings : ScriptableObject
{
	[Header("Mixer")]
	[Tooltip("Audio mixer used for the game sounds.")]
	public AudioMixer AudioMixer;

	[Header("Music")]
	[Tooltip("Music clip properties to loop.")]
	public AudioClipProperties DefaultMusic;

	[Tooltip("The minimum time the music will wait before playing again.")]
	public float MinTransitionTime;

	[Tooltip("The minimum time the music will wait before playing again.")]
	public float MaxTransitionTime;

	[Tooltip("Main menu music")]
	public AudioClipProperties MenuMusic;

	[Header("Ambience")]
	public AudioClipProperties DefaultAmbience;

	public AudioClipProperties MenuAmbience;

	[Header("Stingers")]
	[Tooltip("Stinger for the start of a new game.")]
	public AudioClipProperties StingerNewGame;

	[Tooltip("Stinger for when you travel on the map.")]
	public AudioClipProperties StingerNewTile;

	[Tooltip("Stinger for when you create the first boat.")]
	public AudioClipProperties StingerFirstBoat;

	[Tooltip("Stinger for when you build the sails.")]
	public AudioClipProperties StingerSails;

	[Header("Sounds")]
	[Tooltip("Audio clip properties for missing sounds.")]
	public AudioClipProperties MissingAudioSound;

	[Tooltip("Audio clip properties for selections.")]
	public AudioClipProperties SelectionSound;

	[Tooltip("Audio clip properties for agent selection.")]
	public AudioClipProperties AgentSelectionSound;

	[Tooltip("Audio clip properties for error sounds.")]
	public AudioClipProperties ErrorAudioSound;

	[Tooltip("Audio clip properties for construction error sounds.")]
	public AudioClipProperties ErrorConstructionAudioSound;

	[Tooltip("Sounds for different audio types. In this order Agent/Boat/Flotsam/Construction/Storage.")]
	public List<AudioClipProperties> InventoryTypeAudioSoundList;

	[Tooltip("Sounds for the prefab changing states when constructing or destructing.")]
	public AudioClipProperties PrefabChangeAudioSound;

	[Tooltip("Sound for when the game starts.")]
	public AudioClipProperties GameStartSound;

	[Space]
	[Tooltip("Sound for when the map opens.")]
	public AudioClipProperties MapOpenSound;

	[Tooltip("Sound for when the map closes.")]
	public AudioClipProperties MapCloseSound;

	[Tooltip("Sound for when the city arrives to a new tile on the map.")]
	public AudioClipProperties MapArriveSound;

	[Tooltip("Sound for when the city is travelling on the map.")]
	public AudioClipProperties MapLoopSound;

	public AudioClipProperties LandmarkHoverEnterAudio;

	public AudioClipProperties LandmarkHoverExitAudio;

	[Header("Voices")]
	[Tooltip("The interval at which idle voice-lines should be spoken.")]
	[MinMaxRangeFloat(0f, 300f)]
	public RangedFloat IdleVoiceInterval = new RangedFloat(20f, 60f);

	[Tooltip("The interval at which attention voice-lines should be spoken.")]
	[MinMaxRangeFloat(0f, 300f)]
	public RangedFloat AttentionVoiceInterval = new RangedFloat(20f, 60f);

	[Tooltip("Chance to play a start project voice line.")]
	[Range(0f, 1f)]
	public float StartProjectVoiceChance = 0.33f;

	public void PlayInventoryTypeSound(InventoryType inventoryType, Transform transform)
	{
		if (!InventoryTypeAudioSoundList.IsNullOrEmpty())
		{
			AudioClipProperties audioClipProperties = ((InventoryType.Agent <= inventoryType && (int)inventoryType < InventoryTypeAudioSoundList.Count) ? InventoryTypeAudioSoundList[(int)inventoryType] : null);
			if ((bool)audioClipProperties)
			{
				AudioManager.Play(audioClipProperties, transform);
				return;
			}
			Debug.LogWarningFormat("No AudioClipProperties found for InventoryType.{0}", inventoryType);
		}
	}
}
