using System;
using SE.EvilLib.AudioManager;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class InteractableSwitch : Interactable
{
	public TurnableSpriteRendererAnimator animator;

	[NonSerialized]
	[OdinSerialize]
	public TurnableSpriteRendererAnimator.Animation animation;

	public Sprite onSprite;

	private Sprite normalSprite;

	private SpriteRenderer spriteRenderer;

	public TurnableSpriteRendererAnimator[] additionalTargets;

	public bool initializeAtStart;

	public bool startStatus;

	public bool playSound;

	public AudioTypeSfx switchOnSound;

	public AudioTypeSfx switchOffSound;

	private IInputChip inputChip;

	private InputBinding inputBinding;

	public UnityEvent onTurnOn;

	public UnityEvent onTurnOff;

	private int creationFrame;

	private bool init;

	public bool isOn { get; private set; }

	private void Awake()
	{
	}

	private void Init()
	{
	}

	private void Start()
	{
	}

	public override void OnInteractionDown()
	{
	}

	public void TurnOn()
	{
	}

	public void TurnOff()
	{
	}

	public void Toggle()
	{
	}

	public override void Update()
	{
	}

	public void SetInputSource(IInputChip inputChip, InputBinding inputBinding)
	{
	}
}
