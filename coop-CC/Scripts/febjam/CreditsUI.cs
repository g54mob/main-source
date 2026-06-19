using Aggro.Core;
using FMODUnity;
using UnityEngine;

public class CreditsUI : EntityBehaviourBase, IInputController
{
	private static readonly int Show = Animator.StringToHash("show");

	private static readonly int Hide = Animator.StringToHash("hide");

	public Animator animator;

	public StudioEventEmitter creditsOST;

	public float fastForwardMultiplier = 2f;

	public float scrollTime = 60f;

	private float scrollTimer;

	public bool active;

	protected override void OnUpdatePresentation()
	{
		if (AggroInputManager.input.Credits.Exit.WasPressedThisFrame())
		{
			HideCredits();
			AggroInputManager.RemoveController(this);
		}
		float num = (AggroInputManager.input.Credits.FastForward.IsPressed() ? fastForwardMultiplier : 1f);
		animator.speed = num;
		if (active)
		{
			scrollTimer += Time.deltaTime * num;
			if (scrollTimer >= scrollTime)
			{
				HideCredits();
				AggroInputManager.RemoveController(this);
			}
		}
	}

	public void ShowCredits()
	{
		AggroInputManager.PushController(this);
		animator.SetTrigger(Show);
		animator.ResetTrigger(Hide);
		active = true;
		scrollTimer = 0f;
	}

	public void HideCredits()
	{
		animator.SetTrigger(Hide);
		animator.ResetTrigger(Show);
		active = false;
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.Credits.Enable();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.Credits.Disable();
	}
}
