using UnityEngine;

namespace Port
{
	public class AmbientSoundLoop : MonoBehaviour
	{
		[Header("Clips")]
		[SerializeField]
		private AudioClip[] clips;

		[Header("Volume")]
		[SerializeField]
		[Range(0f, 1f)]
		private float maxVolume;

		[Header("Crossfade")]
		[Tooltip("How long the crossfade lasts (seconds)")]
		[SerializeField]
		private float crossfadeDuration;

		[Tooltip("How many seconds before a clip ends to start the crossfade")]
		[SerializeField]
		private float crossfadeLeadTime;

		[Header("3D Sound")]
		[SerializeField]
		[Range(0f, 1f)]
		private float spatialBlend;

		[SerializeField]
		private float minDistance;

		[SerializeField]
		private float maxDistance;

		[Header("Variety")]
		[SerializeField]
		private bool randomizePitch;

		[SerializeField]
		private Vector2 pitchRange;

		[SerializeField]
		private bool shuffleOrder;

		private AudioSource sourceA;

		private AudioSource sourceB;

		private bool aIsActive;

		private bool isCrossfading;

		private float crossfadeProgress;

		private int lastClipIndex;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void StartCrossfade()
		{
		}

		private void UpdateCrossfade()
		{
		}

		private AudioClip PickClip()
		{
			return null;
		}

		private void PlayClipOn(AudioSource source, AudioClip clip)
		{
		}

		private AudioSource CreateSource()
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
