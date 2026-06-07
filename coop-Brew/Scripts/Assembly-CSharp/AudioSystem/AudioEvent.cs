using System;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
	[Serializable]
	public class AudioEvent
	{
		[Header("Identity")]
		[Tooltip("Unique identifier for this audio event. Used for lookups and networking.")]
		public string id;

		[Tooltip("User-friendly display name for the inspector.")]
		public string displayName;

		[Tooltip("Category for routing and volume control.")]
		public AudioCategory category;

		[Tooltip("Optional tags for filtering and organization.")]
		public string[] tags;

		[TextArea(2, 4)]
		[Tooltip("Developer notes about this sound.")]
		public string notes;

		[Header("Audio")]
		[Tooltip("The audio clip to play.")]
		public AudioClip clip;

		[Tooltip("Optional mixer group for routing. If null, uses category default.")]
		public AudioMixerGroup mixerGroup;

		[Header("Volume & Pitch")]
		[Range(0f, 1f)]
		[Tooltip("Base volume level (0-1).")]
		public float baseVolume;

		[Tooltip("Random multiplier range for volume. Final = baseVolume * Random(x, y).")]
		public Vector2 volumeRandomRange;

		[Range(0.1f, 3f)]
		[Tooltip("Base pitch level.")]
		public float basePitch;

		[Tooltip("Random multiplier range for pitch. Final = basePitch * Random(x, y).")]
		public Vector2 pitchRandomRange;

		[Header("Playback")]
		[Tooltip("Whether this sound loops.")]
		public bool loop;

		[Range(0f, 256f)]
		[Tooltip("Audio source priority (0 = highest, 256 = lowest).")]
		public int priority;

		[Header("3D Spatial Settings")]
		[Tooltip("Enable 3D spatialization for this sound.")]
		public bool is3D;

		[Range(0f, 1f)]
		[Tooltip("How much the sound is affected by 3D positioning (0 = 2D, 1 = fully 3D).")]
		public float spatialBlend;

		[Tooltip("Distance at which sound is at full volume.")]
		public float minDistance;

		[Tooltip("Distance at which sound is inaudible.")]
		public float maxDistance;

		[Tooltip("How volume decreases with distance.")]
		public AudioRolloffMode rolloffMode;

		[Range(0f, 5f)]
		[Tooltip("Doppler effect intensity.")]
		public float dopplerLevel;

		[Range(-1f, 1f)]
		[Tooltip("Stereo pan (-1 = left, 0 = center, 1 = right). Only for 2D sounds.")]
		public float stereoPan;

		[Range(0f, 1.1f)]
		[Tooltip("Reverb zone mix level.")]
		public float reverbZoneMix;

		[Header("Limits & Cooldowns")]
		[Tooltip("Enable cooldown between plays of this sound.")]
		public bool useCooldown;

		[Tooltip("Minimum time between plays (seconds).")]
		public float cooldownSeconds;

		[Tooltip("Maximum simultaneous instances of this sound (0 = unlimited).")]
		public int maxSimultaneousInstances;

		public float GetRandomVolume()
		{
			return 0f;
		}

		public float GetRandomPitch()
		{
			return 0f;
		}

		public void ConfigureSource(AudioSource source)
		{
		}

		public static AudioEvent CreateDefault(string id, AudioClip clip = null)
		{
			return null;
		}
	}
}
