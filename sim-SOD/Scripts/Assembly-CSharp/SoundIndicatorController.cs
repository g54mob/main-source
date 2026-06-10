using System;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.UI;

public class SoundIndicatorController : MonoBehaviour
{
	[Serializable]
	public class AudioIcon
	{
		public RectTransform rect;

		public Image img;

		public float fadeIn;

		public bool remove;
	}

	[Header("Components")]
	public RectTransform rect;

	public JuiceController juice;

	public Image additionalGraphic;

	[Tooltip("Check true if this is for footstep sounds, as it will simlate the surface being walked on...")]
	[Header("State")]
	public bool isFootstep;

	[Tooltip("Keep this updated when checking for footsteps...")]
	public bool rightFoot;

	public AudioEvent currentEvent;

	private EventDescription description;

	public List<AudioController.ActiveListener> currentListeners;

	public float currentHearingRange;

	public int currentIconCount;

	private int previousIconCount;

	public float colourLerp;

	public Color col;

	public Vector2 iconOffset;

	public List<AudioIcon> spawnedIcons;

	public List<AudioIcon> fullIcons;

	public void SetSoundEvent(AudioEvent newEvent, bool updateEvent = true)
	{
	}

	public void UpdateCurrentEvent()
	{
	}

	private void Update()
	{
	}
}
