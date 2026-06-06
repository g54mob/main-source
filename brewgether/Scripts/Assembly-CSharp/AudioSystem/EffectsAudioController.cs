using UnityEngine;

namespace AudioSystem
{
	public class EffectsAudioController : MonoBehaviour
	{
		[Header("Default Buff Sound")]
		[Tooltip("Default sound played when a buff is applied and no custom sound is assigned.")]
		[SerializeField]
		private AudioClip defaultBuffActivationSound;

		[Tooltip("Volume for buff activation sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float buffActivationVolume;

		[Header("Audio Settings")]
		[Tooltip("Spatial blend (0 = 2D, 1 = 3D).")]
		[Range(0f, 1f)]
		[SerializeField]
		private float spatialBlend;

		[Tooltip("Minimum distance for 3D sound.")]
		[SerializeField]
		private float minDistance;

		[Tooltip("Maximum distance for 3D sound.")]
		[SerializeField]
		private float maxDistance;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public static EffectsAudioController Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void PlayBuffActivation(Vector3 position, AudioClip customClip = null)
		{
		}

		private void PlayClipAtPosition(AudioClip clip, Vector3 position, float volume)
		{
		}
	}
}
