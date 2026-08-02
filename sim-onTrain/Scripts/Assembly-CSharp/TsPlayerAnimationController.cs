using DG.Tweening;
using HQFPSTemplate;
using JUTPS.ItemSystem;
using Mirror;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

public class TsPlayerAnimationController : MonoBehaviour
{
	private Animator anim;

	public HoldableItem selectedItem;

	private NetworkAnimator networkAnim;

	public bool isCPRActive;

	public int fullBodyLayerIndex;

	private Tween animLayerTween;

	private Tween axeLayerTween;

	private Tween axeLockTween;

	public InputReader inputReader;

	public PlayerWeaponVisuals weaponVisuals;

	private PlayerInput_PC playerInputPC;

	public Animator Anim
	{
		get
		{
			if (!(anim == null))
			{
				return anim;
			}
			return GetComponent<Animator>();
		}
	}

	public NetworkAnimator NetworkAnim
	{
		get
		{
			if (!(networkAnim == null))
			{
				return networkAnim;
			}
			return GetComponent<NetworkAnimator>();
		}
	}

	private void Start()
	{
		inputReader = GetComponent<InputReader>();
		weaponVisuals = GetComponent<PlayerWeaponVisuals>();
		playerInputPC = GetComponentInParent<PlayerInput_PC>();
	}

	public void Sleep(bool sleep)
	{
		Anim.SetBool(AnimationKeys.SleepAnimation, sleep);
		if (sleep)
		{
			Anim.SetLayerWeight(fullBodyLayerIndex, 1f);
		}
		else
		{
			Anim.SetLayerWeight(fullBodyLayerIndex, 0f);
		}
	}

	public void TakeItem()
	{
		NetworkAnim.SetTrigger(AnimationKeys.PickAnimation);
	}

	public void PlayBuildAnimation()
	{
		NetworkAnim.SetTrigger(AnimationKeys.BuildAnimation);
	}

	public void DrinkWater()
	{
		Anim.SetBool(AnimationKeys.Drinking, value: true);
	}

	public void StopDrinking()
	{
		Anim.SetBool(AnimationKeys.Drinking, value: false);
	}

	public void Death()
	{
		NetworkAnim.SetTrigger(AnimationKeys.DeathAnimation);
	}

	public void Faint()
	{
		animLayerTween?.Kill();
		axeLayerTween?.Kill();
		axeLockTween?.Kill();
		Anim.SetLayerWeight(fullBodyLayerIndex, 1f);
		Anim.SetBool(AnimationKeys.FaintAnimation, value: true);
	}

	public void CPR()
	{
		isCPRActive = true;
		Anim.SetLayerWeight(fullBodyLayerIndex, 1f);
		Anim.SetBool(AnimationKeys.CPRAnimation, value: true);
		if (weaponVisuals != null)
		{
			weaponVisuals.SuspendRigForCPR();
		}
		if (playerInputPC != null)
		{
			playerInputPC.isCPRActive = true;
		}
	}

	public void StopCPR()
	{
		isCPRActive = false;
		Anim.SetLayerWeight(fullBodyLayerIndex, 0f);
		Anim.SetBool(AnimationKeys.CPRAnimation, value: false);
		if (weaponVisuals != null)
		{
			weaponVisuals.RestoreRigAfterCPR();
		}
		if (playerInputPC != null)
		{
			playerInputPC.isCPRActive = false;
		}
	}

	public void Revive()
	{
		animLayerTween?.Kill();
		axeLayerTween?.Kill();
		axeLockTween?.Kill();
		for (int i = 0; i < Anim.layerCount; i++)
		{
			Anim.SetLayerWeight(i, 0f);
		}
		Anim.SetLayerWeight(0, 1f);
		Anim.SetBool(AnimationKeys.FaintAnimation, value: false);
		Anim.SetBool(AnimationKeys.CPRAnimation, value: false);
		Anim.SetBool(AnimationKeys.SleepAnimation, value: false);
		Anim.SetBool(AnimationKeys.Drinking, value: false);
		isCPRActive = false;
		Debug.Log("[Revive] Animator fully reset to Base Layer");
	}

	public void Swing1()
	{
		Anim.SetTrigger(AnimationKeys.Swing1);
	}

	public void Swing2()
	{
		Anim.SetTrigger(AnimationKeys.Swing2);
	}

	public void Swing3()
	{
		Anim.SetTrigger(AnimationKeys.Swing3);
	}

	public void SetNetworkTriggerWithUpperBody(int layerIndex, string animName, float animationTime)
	{
		animLayerTween.Kill();
		Anim.SetLayerWeight(layerIndex, 1f);
		NetworkAnim.SetTrigger(animName);
		animLayerTween = DOVirtual.DelayedCall(animationTime, delegate
		{
			Anim.SetLayerWeight(layerIndex, 0f);
		});
	}

	public void SetAxeTrigger(int layerIndex, int lockedLayerIndex, string animName, float animationTime)
	{
		axeLayerTween.Kill();
		axeLockTween.Kill();
		NetworkAnim.SetTrigger(animName);
		Anim.SetLayerWeight(lockedLayerIndex, 0f);
		Anim.SetLayerWeight(layerIndex, 1f);
		axeLayerTween = DOVirtual.DelayedCall(animationTime, delegate
		{
			Anim.SetLayerWeight(layerIndex, 0f);
		});
		axeLockTween = DOVirtual.DelayedCall(animationTime, delegate
		{
			Anim.SetLayerWeight(lockedLayerIndex, 1f);
		});
	}
}
