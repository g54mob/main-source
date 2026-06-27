using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	[Obsolete("This is the old way of implementing MaryQuinn's music. Don's use this component, it should be reworked.")]
	public class MaryQueenMusicSwitcher : MonoBehaviour
	{
		private static class Style
		{
			public const string Distances = "Distances Settings";

			public const string JazzMusicSettings = "Jazz Music Settings";

			public const string MainMusicSettings = "Main Music Settings";
		}

		[SerializeField]
		private float minDistForMaxJazz = 2f;

		[SerializeField]
		private float mutedMusicThreshold = 5f;

		[SerializeField]
		private float maxDistForMaxMain = 8f;

		[SerializeField]
		private EventReference jazzMusic;

		[SerializeField]
		private string jazzMusicVolumeParameterName = "Parameter 12";

		[SerializeField]
		private bool invertJazzParameterValue;

		[SerializeField]
		private string mainMusicVolumeParameterName = "Parameter 13";

		[SerializeField]
		private bool invertMainMusicParameterValue;

		private IAudioPlayerService audioService;

		private BackgroundLoopingSoundsService backgroundLoopingSoundsService;

		private Transform playerTransform;

		private EventInstance jazzMusicInstance;

		private PARAMETER_ID jazzMusicVolumeParameterId;

		private float previousJazzDistanceRatio;

		private float previousMainMusicDistanceRatio;

		private bool isActive;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				if (isActive != value)
				{
					isActive = value;
					if (value)
					{
						audioService.TryToStartSoundEvent(jazzMusic, out jazzMusicInstance);
						jazzMusicVolumeParameterId = audioService.GetSoundInstanceParameterIdByName(jazzMusicInstance, jazzMusicVolumeParameterName);
						audioService.SetSoundEventInstanceParameterValue(jazzMusicInstance, jazzMusicVolumeParameterId, 0f);
						UpdateMusicParameters();
					}
					else
					{
						audioService.StopSoundEventInstance(jazzMusicInstance);
						jazzMusicInstance.clearHandle();
					}
				}
			}
		}

		[Inject]
		private void Construct(IAudioPlayerService audioService, BackgroundLoopingSoundsService backgroundLoopingSoundsService, [Inject(Id = "playerTransform")] Transform playerTransform)
		{
			this.audioService = audioService;
			this.backgroundLoopingSoundsService = backgroundLoopingSoundsService;
			this.playerTransform = playerTransform;
			if (base.isActiveAndEnabled)
			{
				IsActive = true;
			}
		}

		private void OnEnable()
		{
			if (playerTransform != null)
			{
				IsActive = true;
			}
		}

		private void OnDisable()
		{
			IsActive = false;
		}

		private void Update()
		{
			if (IsActive)
			{
				UpdateMusicParameters();
			}
		}

		private void UpdateMusicParameters()
		{
			if (!(playerTransform == null))
			{
				float currentDistance = Vector3.Distance(base.transform.position, playerTransform.position);
				float distanceRatio = GetDistanceRatio(currentDistance, minDistForMaxJazz, mutedMusicThreshold);
				float distanceRatio2 = GetDistanceRatio(currentDistance, mutedMusicThreshold, maxDistForMaxMain);
				if (distanceRatio != previousJazzDistanceRatio || distanceRatio2 != previousMainMusicDistanceRatio)
				{
					float parameterValue = (invertJazzParameterValue ? distanceRatio : (1f - distanceRatio));
					float newParameterValue = (invertMainMusicParameterValue ? (1f - distanceRatio2) : distanceRatio2);
					backgroundLoopingSoundsService.TryToChangeSoundParameter(BackgroundLoopingSoundType.Music, mainMusicVolumeParameterName, newParameterValue);
					audioService.SetSoundEventInstanceParameterValue(jazzMusicInstance, jazzMusicVolumeParameterId, parameterValue);
					previousJazzDistanceRatio = distanceRatio;
					previousMainMusicDistanceRatio = distanceRatio2;
				}
			}
		}

		private static float GetDistanceRatio(float currentDistance, float minDistance, float maxDistance)
		{
			float num = Mathf.Clamp(currentDistance, minDistance, maxDistance);
			float num2 = maxDistance - minDistance;
			return (num - minDistance) / num2;
		}
	}
}
