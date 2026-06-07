using System;
using SE.EvilLib.AudioManager;
using UnityEngine;

public class InteractableDPad : Interactable
{
	public enum Directions
	{
		Four = 0,
		Eight = 1
	}

	private TurnableSpriteRenderer spriteRenderer;

	public Vector2 origin;

	public int deadZone;

	public Directions directions;

	public TurnableSprite centerSprite;

	public TurnableSprite forwardSprite;

	public TurnableSprite backSprite;

	public TurnableSprite leftSprite;

	public TurnableSprite rightSprite;

	public TurnableSprite forwardLeftSprite;

	public TurnableSprite forwardRightSprite;

	public TurnableSprite backLeftSprite;

	public TurnableSprite backRightSprite;

	public bool playSound;

	public AudioTypeSfx downSound;

	public AudioTypeSfx upSound;

	public AudioTypeSfx moveSound;

	[NonSerialized]
	[HideInInspector]
	public Vector2Int value;

	private Vector2Int lastValue;

	private IInputChip inputChipX;

	private InputBinding inputBindingX;

	private IInputChip inputChipY;

	private InputBinding inputBindingY;

	private bool interactionStartedFromChip;

	private float lastSoundTime;

	private void Awake()
	{
	}

	public override void OnInteractionDown()
	{
	}

	public override void OnInteractionUp()
	{
	}

	public override void OnInteractionStop()
	{
	}

	private void ResetPosition()
	{
	}

	public override void Update()
	{
	}

	public void SetInputSourceX(IInputChip inputChip, InputBinding inputBinding)
	{
	}

	public void SetInputSourceY(IInputChip inputChip, InputBinding inputBinding)
	{
	}
}
