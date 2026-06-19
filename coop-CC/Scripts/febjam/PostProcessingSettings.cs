using Aggro.Core;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingSettings : EntityBehaviourBase
{
	private static readonly int DEPTHOFFIELD_SETTING_ID = AggroSettings.IdToHash("video-depthoffield");

	private static readonly int BLOOM_SETTING_ID = AggroSettings.IdToHash("video-bloom");

	private Volume _volume;

	protected override void OnEntityCreated()
	{
		_volume = GetComponent<Volume>();
		SetDepthOfField(AggroSettings.GetSetting<ToggleSetting>(DEPTHOFFIELD_SETTING_ID).value);
		SetBloom(AggroSettings.GetSetting<ToggleSetting>(BLOOM_SETTING_ID).value);
	}

	public static void SetDepthOfFieldAllPosts(bool option)
	{
		PostProcessingSettings[] array = Object.FindObjectsByType<PostProcessingSettings>(FindObjectsSortMode.None);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetDepthOfField(option);
		}
	}

	public static void SetBloomAllPosts(bool option)
	{
		PostProcessingSettings[] array = Object.FindObjectsByType<PostProcessingSettings>(FindObjectsSortMode.None);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetBloom(option);
		}
	}

	private void SetDepthOfField(bool option)
	{
		_volume = GetComponent<Volume>();
		VolumeComponent volumeComponent = _volume.profile.components.Find((VolumeComponent x) => x is DepthOfField);
		if ((bool)volumeComponent)
		{
			volumeComponent.active = option;
		}
	}

	private void SetBloom(bool option)
	{
		_volume = GetComponent<Volume>();
		VolumeComponent volumeComponent = _volume.profile.components.Find((VolumeComponent x) => x is Bloom);
		if ((bool)volumeComponent)
		{
			volumeComponent.active = option;
		}
	}
}
