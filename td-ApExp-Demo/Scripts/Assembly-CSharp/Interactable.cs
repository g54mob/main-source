using System;
using UnityEngine;
using UnityEngine.Localization;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Outline))]
public class Interactable : MonoBehaviour
{
	public enum InteractAnims
	{
		Idle = 0,
		Shovel = 1,
		Interact = 2
	}

	public delegate void InteractHandler(Interactor interactor);

	public delegate void Vector2Handler(Vector2 point);

	public Func<bool> CanInteract;

	public bool IsInterruptable = true;

	public bool ShowOnlyUpperTooltips;

	[Header("Interactable Settings")]
	[Tooltip("The localized key of the action name for the hotkey tooltip.")]
	public LocalizedString actionNameLocalized = new LocalizedString
	{
		TableReference = "LocalizationTable",
		TableEntryReference = "Action_Interact"
	};

	[Tooltip("The localized key of stopping the interaction for the hotkey tooltip.")]
	public LocalizedString inactionNameLocalized = new LocalizedString
	{
		TableReference = "LocalizationTable",
		TableEntryReference = "Action_Stop"
	};

	[Tooltip("Animation for player to play during interaction. Leave as idle for start only interactions.")]
	public InteractAnims interactAnim;

	[Tooltip("This is for things that happen instantly like pressing a button or grabbing ammo. ActiveInteractable is NOT updated.")]
	public bool startOnly = true;

	[Tooltip("If true you can move during an interaction to interrupt it. If false you can't move and the interaction won't be interrupted by movement.")]
	public bool movementInterrupts = true;

	public bool movementInterruptsGamepad = true;

	[Tooltip("If true you can press E during interaction to stop again.")]
	public bool interactInterrupts;

	[Tooltip("When interacting with this interactable, the player will move to this transform. If no transform the player won't move.")]
	public Transform positionDuringInteract;

	[Tooltip("When interacting with this interactable, the player will face this transform. If none, the player will remain facing the way they were.")]
	public Transform aimTargetDuringInteract;

	[Tooltip("Whether or not the cursor is used during interaction. This field is used by the UI to check whether or not the cursor should be visible.")]
	public bool isAimable;

	public Vector2 overridePosition;

	protected AudioSource audioSource;

	private Outline outline;

	public Interactor Interactor { get; set; }

	public event InteractHandler OnInteractStart;

	public event InteractHandler OnInteractUpdate;

	public event InteractHandler OnInteractEnd;

	public event Vector2Handler OnSetPoint;

	public event Vector2Handler OnTranslatePoint;

	protected void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		outline = GetComponent<Outline>();
	}

	public void InteractStart(Interactor interactor)
	{
		this.OnInteractStart?.Invoke(interactor);
		if (!startOnly)
		{
			Interactor = interactor;
		}
	}

	public void InteractUpdate(Interactor interactor)
	{
		this.OnInteractUpdate?.Invoke(interactor);
	}

	public void InteractEnd(Interactor interactor)
	{
		this.OnInteractEnd?.Invoke(interactor);
		Interactor = null;
	}

	public void SetPoint(Vector2 point)
	{
		this.OnSetPoint?.Invoke(point);
	}

	public void TranslatePoint(Vector2 point)
	{
		this.OnTranslatePoint?.Invoke(point);
	}

	public virtual void Select(Interactor interactor)
	{
		Health component = GetComponent<Health>();
		if (component == null)
		{
			outline.SetOutline(isActive: true, Color.white);
			return;
		}
		Color color = ((PlayerManager.Instance.Players.Count > 1) ? interactor.playerController.GetPlayerColor() : Color.white);
		outline.SetOutline(isActive: true, component.IsDead ? Color.black : color);
	}

	public virtual void Deselect(Interactor interactor)
	{
		outline.SetOutline(isActive: false, Color.white);
	}

	public void GetLocalizedActionName(Action<string> callback)
	{
		string localizedString = actionNameLocalized.GetLocalizedString();
		callback?.Invoke(localizedString);
	}

	public void GetLocalizedInactionName(Action<string> callback)
	{
		string localizedString = inactionNameLocalized.GetLocalizedString();
		callback?.Invoke(localizedString);
	}

	internal void Interrupt(Interactor interruptingInteractor)
	{
		Interactor interactor = Interactor;
		if ((bool)interactor)
		{
			interactor.playerController.StopInteracting();
			interactor.InterruptingInteractable = this;
			interactor.InterruptingInteractable.Interactor = interactor;
			this.OnInteractEnd?.Invoke(interactor);
			interactor.ActiveInteractable?.Deselect(interactor);
			interactor.ActiveInteractable = null;
			interactor.playerController.hotkeyTooltip.CloseAll();
			interactor.playerController.ForceIdleState();
		}
		interruptingInteractor.InterruptingInteractable?.Deselect(interruptingInteractor);
		interruptingInteractor.InterruptingInteractable = null;
		interruptingInteractor.ActiveInteractable = this;
		interruptingInteractor.ActiveInteractable?.Select(interruptingInteractor);
		interruptingInteractor.ActiveInteractable.Interactor = interruptingInteractor;
		interruptingInteractor.playerController.hotkeyTooltip.CloseAll();
		interruptingInteractor.playerController.hotkeyTooltip.SetInterruptable(interruptingInteractor.ActiveInteractable, interactor.playerController);
		Interactor = interruptingInteractor;
	}

	public Module GetModule()
	{
		return GetComponent<Module>();
	}
}
