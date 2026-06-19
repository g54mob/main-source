using System;
using System.Collections.Generic;
using DG.Tweening;

[Serializable]
public class CoreAmbienceLayer
{
	public List<CoreAmbienceTrack> Tracks;

	public int Level;

	public float BaseVolumeLevel;

	public float EffectVolumeModifier;

	public float VolumeOpacity;

	public Action<CoreAmbienceLayer> AnnounceEmpty;

	public Tween _tween;

	public static Action AnnounceOpacityUpdated;

	public CoreAmbienceLayer(int level, float volume)
	{
	}

	public void UpdateBaseVolumelevel(float volume)
	{
	}

	public void AddTrack(CoreAmbienceTrack track)
	{
	}

	public void RemoveTrack(CoreAmbienceTrack track)
	{
	}

	public void Initiate()
	{
	}

	public void Kill()
	{
	}

	public void SetVolumeDominance(float volume)
	{
	}

	public void ApplyVolume()
	{
	}

	public void SetVolumeOpacity(float volume)
	{
	}

	public Tween DoFadeOut()
	{
		return null;
	}

	public Tween DOFadeIn()
	{
		return null;
	}
}
