using SE.EvilLib.AudioManager;
using UnityEngine;

public class InteractableButton : Interactable
{
	public Sprite pressed;

	private Sprite normal;

	private SpriteRenderer spriteRenderer;

	private TurnableSpriteRendererAnimator turnableAnimator;

	public TurnableSpriteRendererAnimator[] additionalTargets;

	public SpriteShadow moveShadow;

	public FloatRange shadowMultiplierRange;

	public bool playSound;

	public AudioTypeSfx downSound;

	public bool playUpSound;

	public AudioTypeSfx upSound;

	private IInputChip inputChip;

	private InputBinding inputBinding;

	private bool interactionStartedFromChip;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public override void Update()
	{
	}

	public override bool InteractionEnabled()
	{
		return false;
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

	private void ShowPressed()
	{
	}

	private void ShowNormal()
	{
	}

	public void SetInputSource(IInputChip inputChip, InputBinding inputBinding)
	{
	}
}
