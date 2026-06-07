using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	[AddComponentMenu("Dark Tonic/Master Audio/Ambient Sound")]
	[AudioScriptOrder(-20)]
	public class AmbientSound : MonoBehaviour
	{
		[SoundGroup]
		public string AmbientSoundGroup;

		public EventSounds.VariationType variationType;

		public string variationName;

		public float playVolume;

		public MasterAudio.AmbientSoundExitMode exitMode;

		public float exitFadeTime;

		public MasterAudio.AmbientSoundReEnterMode reEnterMode;

		public float reEnterFadeTime;

		[Tooltip("This option is useful if your caller ever moves, as it will make the Audio Source follow to the location of the caller every frame.")]
		public bool FollowCaller;

		[Tooltip("Using this option, the Audio Source will be updated every frame to the closest position on the caller's collider, if any. This will override the Follow Caller option above and happen instead.")]
		public bool UseClosestColliderPosition;

		public bool UseTopCollider;

		public bool IncludeChildColliders;

		[Tooltip("This is for diagnostic purposes only. Do not change or assign this field.")]
		public Transform RuntimeFollower;

		private Transform _trans;

		public float colliderMaxDistance;

		public long lastTimeMaxDistanceCalced;

		public bool IsValidSoundGroup => false;

		public Transform Trans => null;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void StopTrackers()
		{
		}

		public void CalculateRadius()
		{
		}

		public AudioSource GetNamedOrFirstAudioSource()
		{
			return null;
		}

		public List<AudioSource> GetAllVariationAudioSources()
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public void StartTrackers()
		{
		}
	}
}
