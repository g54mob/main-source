using System;
using SE.EvilLib.AudioManager;
using UnityEngine;

public class InteractableKnob : Interactable
{
	public Transform rotatingTransform;

	public AudioTypeSfx audioSfx;

	public float audioSfxGranularity;

	[NonSerialized]
	[HideInInspector]
	public float value;

	[NonSerialized]
	[HideInInspector]
	public float deltaValue;

	public bool unclamped;

	public float minAngle;

	public float maxAngle;

	public int minValue;

	public int maxValue;

	private float scroolSpeed;

	private float dragDistance;

	private Vector2 dragMouseOffest;

	private float dragStartValue;

	private float dragLastValue;

	private float lastAudioValue;

	private float lastAudioTime;

	private PlayingSound sound;

	public override bool InteractionEnabled()
	{
		return false;
	}

	public override void OnInteractionDown()
	{
	}

	private float ClampValue(float value)
	{
		return 0f;
	}

	public override void Update()
	{
	}
}
