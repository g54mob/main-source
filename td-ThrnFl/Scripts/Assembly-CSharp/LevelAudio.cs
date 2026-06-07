using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudio : MonoBehaviour
{
	[Serializable]
	public class CivilisationAudioSource
	{
		public AudioSource audioSource;

		public float volumeAtCastleCenterBuild = 0.1f;

		public float targetVolume;

		public int targetBuildingAmount;
	}

	public List<CivilisationAudioSource> managedCivAudioSources;

	private int buildingCount;

	private void OnValidate()
	{
		foreach (CivilisationAudioSource managedCivAudioSource in managedCivAudioSources)
		{
			if (managedCivAudioSource.audioSource != null)
			{
				managedCivAudioSource.targetVolume = managedCivAudioSource.audioSource.volume;
			}
		}
	}

	private void Start()
	{
		for (int num = managedCivAudioSources.Count - 1; num >= 0; num--)
		{
			CivilisationAudioSource civilisationAudioSource = managedCivAudioSources[num];
			if (civilisationAudioSource.audioSource == null)
			{
				managedCivAudioSources.RemoveAt(num);
			}
			else
			{
				civilisationAudioSource.targetVolume = civilisationAudioSource.audioSource.volume;
				civilisationAudioSource.audioSource.volume = 0f;
			}
		}
		ThronefallAudioManager.Instance.onBuildingBuild.AddListener(OnNewBuildingBuilt);
	}

	private void OnNewBuildingBuilt()
	{
		for (int num = managedCivAudioSources.Count - 1; num >= 0; num--)
		{
			CivilisationAudioSource civilisationAudioSource = managedCivAudioSources[num];
			civilisationAudioSource.audioSource.volume = Mathf.Lerp(civilisationAudioSource.volumeAtCastleCenterBuild, civilisationAudioSource.targetVolume, Mathf.InverseLerp(0f, civilisationAudioSource.targetBuildingAmount, buildingCount));
			if (buildingCount >= civilisationAudioSource.targetBuildingAmount)
			{
				managedCivAudioSources.RemoveAt(num);
			}
		}
		buildingCount++;
		if (managedCivAudioSources.Count < 1)
		{
			ThronefallAudioManager.Instance.onBuildingBuild.RemoveListener(OnNewBuildingBuilt);
		}
	}
}
