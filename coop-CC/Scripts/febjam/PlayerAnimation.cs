using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlayerAnimation : NetworkEntityBehaviourBase
{
	private static readonly int Uproot;

	private static readonly int Sneeze;

	public NetworkAnimator networkAnimator;

	public VehicleController vc;

	public PlayerGrabber playerGrabber;

	public Animator animator;

	public PlayerStress playerStress;

	public NitroController nitroController;

	public float headLookSpeed = 5f;

	private float _headLookTarget;

	public float leanSpeed = 5f;

	public bool tiptapActive;

	public float tiptapActiveProgress;

	public float taptapTransitionSpeed = 0.7f;

	public MeshRenderer cursewordRenderer;

	public float bonkBlendSpeed = 1f;

	private int bonkLayerIndex = -1;

	private int turnLayerIndex = -1;

	protected override void OnEntityCreated()
	{
		bonkLayerIndex = animator.GetLayerIndex("bonk");
		turnLayerIndex = animator.GetLayerIndex("turning");
	}

	protected override void OnUpdatePresentation()
	{
		cursewordRenderer.SetPropertyBlockFloat("_playerCrashingOut", playerStress.crashingOut ? 1f : 0f);
		cursewordRenderer.SetPropertyBlockVector("_PlayerForwardDir", vc.transform.forward);
	}

	protected override void OnUpdatePresentationLate()
	{
		if (base.isLocalPlayer)
		{
			animator.SetFloat("wheelSpeedNormalized", vc.rb.velocity.magnitude * vc.travelSign / vc.maxSpeedForward);
			animator.SetBool("nitroActive", nitroController.nitroActiveSync);
			animator.SetFloat("stressLevel", playerStress.stressNormalizedValue * 5f);
			animator.SetBool("slippingOut", vc.slippingOutSync);
			if (playerStress.crashingOut)
			{
				animator.SetBool("crashingOut", value: true);
			}
			else
			{
				animator.SetBool("crashingOut", value: false);
			}
			tiptapActiveProgress = Mathf.Clamp01(tiptapActiveProgress + (tiptapActive ? 1f : (-1f)) * Time.deltaTime * taptapTransitionSpeed);
			animator.SetFloat("taptapActive", tiptapActiveProgress);
			_headLookTarget = ((vc.drifting || tiptapActive) ? 0f : 1f);
			if (vc.slippingOutSync)
			{
				animator.SetLayerWeight(turnLayerIndex, 0f);
			}
			else
			{
				animator.SetLayerWeight(turnLayerIndex, Mathf.Lerp(animator.GetLayerWeight(1), _headLookTarget, headLookSpeed * Time.deltaTime));
			}
			float turnDirForVisual = vc.GetTurnDirForVisual();
			float b = (vc.drifting ? ((0f - turnDirForVisual) * vc.driftSign) : 0f);
			animator.SetFloat("lean", Mathf.Lerp(animator.GetFloat("lean"), b, leanSpeed * Time.deltaTime));
			float layerWeight = animator.GetLayerWeight(3);
			animator.SetLayerWeight(bonkLayerIndex, Mathf.Clamp(layerWeight - bonkBlendSpeed * Time.deltaTime, 0f, 1f));
			animator.SetBool("drifting", vc.drifting);
			animator.SetBool("driftR", vc.driftSign > 0f);
			animator.SetBool("driftL", vc.driftSign < 0f);
			animator.SetBool("lifted", playerGrabber.syncLiftRaised);
			if (playerGrabber.hasCandidate)
			{
				animator.SetBool("canGrab", value: true);
			}
			else
			{
				animator.SetBool("canGrab", value: false);
			}
		}
	}

	public void PlayGrabDenied()
	{
		networkAnimator.SetTrigger("attemptGrab");
	}

	public void PlaySlipOut()
	{
		animator.SetTrigger("slipOut");
		animator.SetBool("slippingOut", value: true);
	}

	public void PlayUpRoot()
	{
		animator.SetTrigger(Uproot);
	}

	public void PlaySneeze()
	{
		animator.SetTrigger(Sneeze);
	}

	public void PlayBonk()
	{
		if (base.isLocalPlayer)
		{
			networkAnimator.SetTrigger("bonk");
		}
		animator.SetLayerWeight(bonkLayerIndex, 1f);
	}

	[ClientRpc]
	public void RpcPlayBonk()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerAnimation::RpcPlayBonk()", -1992693867, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	static PlayerAnimation()
	{
		Uproot = Animator.StringToHash("uproot");
		Sneeze = Animator.StringToHash("sneeze");
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerAnimation), "System.Void PlayerAnimation::RpcPlayBonk()", InvokeUserCode_RpcPlayBonk);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcPlayBonk()
	{
		PlayBonk();
	}

	protected static void InvokeUserCode_RpcPlayBonk(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayBonk called on server.");
		}
		else
		{
			((PlayerAnimation)obj).UserCode_RpcPlayBonk();
		}
	}
}
