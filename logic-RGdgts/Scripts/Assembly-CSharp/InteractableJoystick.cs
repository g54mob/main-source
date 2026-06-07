using System;
using DG.Tweening;
using SE.EvilLib.AudioManager;
using UnityEngine;

public class InteractableJoystick : Interactable
{
	[Serializable]
	public struct OffsettedSprite
	{
		public Transform sprite;

		public float offset;
	}

	private SpriteRenderer spriteRenderer;

	public Vector2 origin;

	public Vector2 offset;

	public float radius;

	public bool playSound;

	public float soundDownThreshold;

	public float soundUpThreshold;

	public AudioTypeSfx leftDownSound;

	public AudioTypeSfx leftUpSound;

	public AudioTypeSfx rightDownSound;

	public AudioTypeSfx rightUpSound;

	public AudioTypeSfx forwardDownSound;

	public AudioTypeSfx forwardUpSound;

	public AudioTypeSfx backDownSound;

	public AudioTypeSfx backUpSound;

	[NonSerialized]
	[HideInInspector]
	public Vector2 value;

	private Vector2 _value;

	private Vector2 _lastValue;

	private SpriteShadow shadow;

	private float movementMul;

	private IInputChip inputChipX;

	private InputBinding inputBindingX;

	private IInputChip inputChipY;

	private InputBinding inputBindingY;

	public OffsettedSprite[] offsettedSprites;

	private Vector2 mouseOffset;

	private Tween resetTween;

	private bool interactionStartedFromChip;

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
