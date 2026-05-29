using System;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerManager : NoktaSingleton<SpeakerManager>
{
	public List<Speaker> Speakers;

	public Action OnSpeakerChanged;

	public AudioSource[] ChildrenAudioSources => null;

	private void Awake()
	{
	}

	public void AddSpeaker(Speaker speaker)
	{
	}

	public void RotateSpeaker(Speaker speaker, float rotY)
	{
	}

	public void RemoveSpeaker(Speaker speaker)
	{
	}
}
