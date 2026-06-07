using System.Collections;
using DV.CabControls;
using DV.Common;
using DV.Utils;
using UnityEngine;

public class VisualSwitch : MonoBehaviour
{
	public Junction junction;

	public Animator animator;

	private float speedMult = 2f;

	public bool invertDirection;

	public GameObject switchButtonGO;

	[InspectorButton("Switch", true, true)]
	public bool switchNow;

	private Coroutine animatorCoro;

	private Collider[] buttonColliders;

	private ButtonBase switchButton;

	private const float ANIMATOR_DISABLE_DELAY = 2f;

	public void Start()
	{
		PlayAnimation();
		junction.Switched += OnSwitched;
		switchButton = switchButtonGO.GetComponent<ButtonBase>();
		if (switchButton != null)
		{
			switchButton.Used += Switch;
			buttonColliders = switchButton.GetComponentsInChildren<Collider>();
		}
		else
		{
			Debug.LogError("There is no ButtonBase on switchButtonGO.\nManual switching won't work!");
		}
		OnSwitchingAllowedChanged(GameFeatureFlags.Flag.JunctionSwitching, GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.JunctionSwitching));
		GameFeatureFlags.RegisterListenerFor(GameFeatureFlags.Flag.JunctionSwitching, OnSwitchingAllowedChanged);
		SingletonBehaviour<JunctionSwitcherManager>.Instance.SwitchingAllowedWhitelistChanged += OnSwitchingAllowedChanged;
	}

	public void SetManualInteractionAllowedState(bool allowed)
	{
		if (!(switchButton == null))
		{
			switchButton.InteractionAllowed = allowed;
		}
	}

	private void OnSwitchingAllowedChanged()
	{
		ApplyAllowedState(SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(junction));
	}

	private void OnSwitchingAllowedChanged(GameFeatureFlags.Flag flag, bool allowed)
	{
		if (flag == GameFeatureFlags.Flag.JunctionSwitching)
		{
			ApplyAllowedState(SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(junction));
		}
	}

	private void ApplyAllowedState(bool allowed)
	{
		if (!switchButton)
		{
			return;
		}
		switchButton.InteractionAllowed = allowed;
		if (buttonColliders != null)
		{
			Collider[] array = buttonColliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = allowed;
			}
		}
	}

	private void OnDestroy()
	{
		GameFeatureFlags.UnregisterListenerFor(GameFeatureFlags.Flag.JunctionSwitching, OnSwitchingAllowedChanged);
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<JunctionSwitcherManager>.Instance.SwitchingAllowedWhitelistChanged -= OnSwitchingAllowedChanged;
		}
	}

	public void Switch()
	{
		if (!junction)
		{
			Debug.Log("VisualSwitch has no junction assigned");
		}
		if (SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(junction))
		{
			junction.Switch(Junction.SwitchMode.REGULAR);
		}
	}

	private void OnSwitched(Junction.SwitchMode mode, int branch)
	{
		if (junction == null)
		{
			Debug.LogError("OnSwitched was called while junction is null, this should never happen, please investigage.", this);
		}
		else
		{
			DoVisual(mode);
		}
	}

	public void SwitchTo(bool left)
	{
		if ((!left || junction.selectedBranch != 0) && (left || junction.selectedBranch != 1))
		{
			junction.Switch(Junction.SwitchMode.REGULAR);
		}
	}

	private void DoVisual(Junction.SwitchMode mode)
	{
		PlayAnimation();
		if (mode != Junction.SwitchMode.NO_SOUND)
		{
			PlaySound(mode);
		}
	}

	private void PlaySound(Junction.SwitchMode mode)
	{
		if (mode == Junction.SwitchMode.FORCED)
		{
			SingletonBehaviour<AudioManager>.Instance.switchForcedClips.Play(base.transform.position, 1f, 0.5f, 150f, 5f, 500f, default(AudioSourceCurves), SingletonBehaviour<AudioManager>.Instance.switchGroup);
		}
		else
		{
			SingletonBehaviour<AudioManager>.Instance.switchClips.Play(base.transform.position, 1f, 0.5f, 150f, 5f, 500f, default(AudioSourceCurves), SingletonBehaviour<AudioManager>.Instance.switchGroup);
		}
	}

	private void EnableAnimator()
	{
		if (!animator.enabled)
		{
			animator.enabled = true;
		}
		if (animatorCoro != null)
		{
			StopCoroutine(animatorCoro);
		}
		animatorCoro = StartCoroutine(DisableAnimatorCoro());
	}

	private IEnumerator DisableAnimatorCoro()
	{
		yield return WaitFor.Seconds(2f);
		animator.enabled = false;
		animatorCoro = null;
	}

	private void PlayAnimation()
	{
		if (!animator)
		{
			return;
		}
		EnableAnimator();
		float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (invertDirection ? (junction.selectedBranch == 1) : (junction.selectedBranch == 0))
		{
			animator.SetFloat("speed", speedMult);
			if (normalizedTime < 0f)
			{
				animator.Play("junction", 0, 0f);
			}
		}
		else
		{
			animator.SetFloat("speed", 0f - speedMult);
			if (normalizedTime > 1f)
			{
				animator.Play("junction", 0, 1f);
			}
		}
	}
}
