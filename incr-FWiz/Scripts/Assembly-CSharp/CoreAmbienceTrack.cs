using System;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using Unity.Collections;
using UnityEngine;

[Serializable]
public class CoreAmbienceTrack
{
	public EventReference EventReference;

	[ReadOnly]
	public EventInstance EventInstance;

	public int Level;

	[HideInInspector]
	public float BaseVolumeLevel;

	[HideInInspector]
	public float ParentVolumeLevel;

	public float FadeInTime;

	public float FadeOutTime;

	public Action<CoreAmbienceTrack> AnnounceKill;

	private Tween _currentTween;

	public bool Started { get; private set; }

	public bool Killed { get; private set; }

	public CoreAmbienceTrack(EventReference eventReference, int level)
	{
	}

	public void EvaluateOverallVolume()
	{
	}

	public void UpdateLayerVolumeLevel(float volume)
	{
	}

	public void UpdateBaseVolumeLevel(float volume)
	{
	}

	public void Revive()
	{
	}

	public void End()
	{
	}

	public void StartPlaying()
	{
	}

	public Tween DOFadeRelease()
	{
		return null;
	}

	public Tween DOFadeIn()
	{
		return null;
	}
}
