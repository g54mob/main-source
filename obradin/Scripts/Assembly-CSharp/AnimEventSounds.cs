using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventSounds : MonoBehaviour, AnimEventHandler.IHost
{
	[Serializable]
	public class Event
	{
		public string id;

		public AudioClip clip;

		public AudioClip[] extraClips;

		[NonSerialized]
		public ShuffleAudioClips shuffleAudioClips;
	}

	public bool useAudioOneShot;

	public List<Event> events;

	private AudioSource audioSource;

	private void Start()
	{
		if (!useAudioOneShot)
		{
			audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.spatialBlend = 1f;
		}
		foreach (Event @event in events)
		{
			if (@event.extraClips == null || @event.extraClips.Length == 0)
			{
				continue;
			}
			if (@event.extraClips.Length == 1)
			{
				@event.shuffleAudioClips = new ShuffleAudioClips(@event.clip, @event.extraClips[0]);
				continue;
			}
			if (@event.extraClips.Length == 2)
			{
				@event.shuffleAudioClips = new ShuffleAudioClips(@event.clip, @event.extraClips[0], @event.extraClips[1]);
				continue;
			}
			if (@event.extraClips.Length == 3)
			{
				@event.shuffleAudioClips = new ShuffleAudioClips(@event.clip, @event.extraClips[0], @event.extraClips[1], @event.extraClips[2]);
				continue;
			}
			throw new UnityException("Too many extraClips in AnimEventSounds: " + Util.GetObjectPath(base.gameObject));
		}
		Animator componentInChildren = GetComponentInChildren<Animator>();
		if (componentInChildren != null)
		{
			AnimEventHandler.Attach(componentInChildren.gameObject, this, "playsound");
		}
	}

	public void OnAnimEvent(string id)
	{
		foreach (Event @event in events)
		{
			if (id == @event.id)
			{
				AudioClip clip = ((@event.shuffleAudioClips == null) ? @event.clip : @event.shuffleAudioClips.next);
				if (useAudioOneShot)
				{
					AudioOneShot.Play3D(base.gameObject, clip);
				}
				else
				{
					audioSource.PlayOneShot(clip);
				}
				break;
			}
		}
	}
}
