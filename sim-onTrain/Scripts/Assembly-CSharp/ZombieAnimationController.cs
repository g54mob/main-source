using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class ZombieAnimationController : NetworkBehaviour
{
	private Animator animator;

	public NetworkAnimator networkAnimator;

	private ZombieController controller;

	private ZombieDamageDealer damageDealer;

	private ZombieSoundController soundController;

	public float attack1Time = 1f;

	public float attack2Time = 1f;

	public float attack3Time = 1f;

	[Header("Move Attack Duration")]
	public float moveAttackDuration = 3.1f;

	[Header("Standing Attacks (Full Body - BaseLayer)")]
	public List<string> standingAttacks = new List<string> { "Attack1", "Attack2", "Attack3" };

	[Header("Move Attacks (UpperBody Layer)")]
	public List<string> moveAttacks = new List<string> { "MoveAttack1", "MoveAttack2" };

	[Header("Layer Settings")]
	public int upperBodyLayerIndex = 1;

	public int lowerBodyLayerIndex = 2;

	public float layerTransitionSpeed = 10f;

	private bool isMoveAttacking;

	private Coroutine moveAttackCoroutine;

	private Vector3 initialLocalPosition;

	private Quaternion initialLocalRotation;

	private Coroutine runningHitCoroutine;

	public Animator Animator
	{
		get
		{
			if (!(animator == null))
			{
				return animator;
			}
			return GetComponent<Animator>();
		}
	}

	public bool IsMoveAttacking => isMoveAttacking;

	private void Start()
	{
		networkAnimator = GetComponentInParent<NetworkAnimator>();
		controller = GetComponentInParent<ZombieController>();
		damageDealer = GetComponentInParent<ZombieDamageDealer>();
		soundController = GetComponentInParent<ZombieSoundController>();
		initialLocalPosition = base.transform.localPosition;
		initialLocalRotation = base.transform.localRotation;
	}

	private void LateUpdate()
	{
		if (base.transform.localPosition != initialLocalPosition)
		{
			base.transform.localPosition = initialLocalPosition;
		}
		if (base.transform.localRotation != initialLocalRotation)
		{
			base.transform.localRotation = initialLocalRotation;
		}
	}

	public void Attack(bool isMoving = false)
	{
		if (!base.isServer)
		{
			CmdAttack(isMoving);
		}
		else if (isMoving)
		{
			PerformMoveAttack();
		}
		else
		{
			PerformStandingAttack();
		}
	}

	private void PerformStandingAttack()
	{
		if (standingAttacks != null && standingAttacks.Count != 0)
		{
			int index = Random.Range(0, standingAttacks.Count);
			string trigger = standingAttacks[index];
			networkAnimator.SetTrigger(trigger);
		}
	}

	private void PerformMoveAttack()
	{
		if (moveAttacks != null && moveAttacks.Count != 0)
		{
			int index = Random.Range(0, moveAttacks.Count);
			string attackTrigger = moveAttacks[index];
			if (moveAttackCoroutine != null)
			{
				StopCoroutine(moveAttackCoroutine);
			}
			moveAttackCoroutine = StartCoroutine(MoveAttackRoutine(attackTrigger));
		}
	}

	private IEnumerator MoveAttackRoutine(string attackTrigger)
	{
		isMoveAttacking = true;
		float currentWeight = Animator.GetLayerWeight(upperBodyLayerIndex);
		while (currentWeight < 1f)
		{
			currentWeight = Mathf.MoveTowards(currentWeight, 1f, Time.deltaTime * layerTransitionSpeed);
			Animator.SetLayerWeight(upperBodyLayerIndex, currentWeight);
			yield return null;
		}
		Animator.SetLayerWeight(upperBodyLayerIndex, 1f);
		networkAnimator.SetTrigger(attackTrigger);
		yield return new WaitForSeconds(moveAttackDuration);
		currentWeight = Animator.GetLayerWeight(upperBodyLayerIndex);
		while (currentWeight > 0f)
		{
			currentWeight = Mathf.MoveTowards(currentWeight, 0f, Time.deltaTime * layerTransitionSpeed);
			Animator.SetLayerWeight(upperBodyLayerIndex, currentWeight);
			yield return null;
		}
		Animator.SetLayerWeight(upperBodyLayerIndex, 0f);
		isMoveAttacking = false;
		moveAttackCoroutine = null;
		if (controller != null)
		{
			controller.OnMoveAttackComplete();
		}
	}

	public void AttackFromAnimationEvent()
	{
		if (base.isServer && NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound(GameAudios.ZombieAttack, base.transform.position);
		}
		if (damageDealer != null)
		{
			damageDealer.CheckHit();
			damageDealer.CheckPropHit();
		}
		else
		{
			Debug.LogWarning("[ZombieAnimationController] " + base.gameObject.name + ": DamageDealer NULL!");
		}
		OnAttackComplete();
	}

	public void OnAttackStateCompleted()
	{
		if (controller != null)
		{
			controller.OnAnimationAttackStateCompleted();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAttack(bool isMoving)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(isMoving);
		SendCommandInternal("System.Void ZombieAnimationController::CmdAttack(System.Boolean)", 17592132, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void OnStepWalk()
	{
		if (soundController != null)
		{
			soundController.PlayWalkFootstep();
		}
	}

	public void OnStepSprint()
	{
		if (soundController != null)
		{
			soundController.PlaySprintFootstep();
		}
	}

	public void OnJumpLanded()
	{
		if (soundController != null)
		{
			soundController.PlayLandingSound();
		}
	}

	public void Death()
	{
		if (!base.isServer)
		{
			CmdDeath();
		}
		else
		{
			networkAnimator.SetTrigger("Death");
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdDeath()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ZombieAnimationController::CmdDeath()", -998924623, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void GetDamage()
	{
		if (base.isServer)
		{
			CmdGetDamage();
		}
		else
		{
			CmdGetDamage();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdGetDamage()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ZombieAnimationController::CmdGetDamage()", -1971911582, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void ReactToHit(string bodyPart)
	{
		if (base.isServer)
		{
			CmdReactToHit(bodyPart);
		}
		else
		{
			CmdReactToHit(bodyPart);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdReactToHit(string bodyPart)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(bodyPart);
		SendCommandInternal("System.Void ZombieAnimationController::CmdReactToHit(System.String)", 1571376868, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void PlayRunningHit(BodyHitPart hitPart, Vector3 hitDirection)
	{
		string runningHitTrigger = GetRunningHitTrigger(hitPart, hitDirection);
		if (base.isServer)
		{
			networkAnimator.SetTrigger(runningHitTrigger);
			StartRunningHitBlend(hitPart);
		}
		else
		{
			CmdPlayRunningHit(runningHitTrigger);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdPlayRunningHit(string trigger)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(trigger);
		SendCommandInternal("System.Void ZombieAnimationController::CmdPlayRunningHit(System.String)", -1757393355, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void StartRunningHitBlend(BodyHitPart hitPart)
	{
		if (!isMoveAttacking)
		{
			if (runningHitCoroutine != null)
			{
				StopCoroutine(runningHitCoroutine);
			}
			float runningHitDuration = GetRunningHitDuration(hitPart);
			bool includeLowerBody = hitPart == BodyHitPart.RightLeg || hitPart == BodyHitPart.LeftLeg;
			runningHitCoroutine = StartCoroutine(RunningHitBlendRoutine(runningHitDuration, includeLowerBody));
		}
	}

	private float GetRunningHitDuration(BodyHitPart hitPart)
	{
		switch (hitPart)
		{
		case BodyHitPart.RightArm:
		case BodyHitPart.LeftArm:
			return 0.83f;
		case BodyHitPart.RightLeg:
		case BodyHitPart.LeftLeg:
			return 0.87f;
		default:
			return 1.07f;
		}
	}

	private IEnumerator RunningHitBlendRoutine(float animDuration, bool includeLowerBody)
	{
		float blendIn = 0.1f;
		float blendOut = 0.3f;
		float holdTime = Mathf.Max(0f, animDuration - blendIn - blendOut);
		float elapsed = 0f;
		float startWeightUpper = Animator.GetLayerWeight(upperBodyLayerIndex);
		float startWeightLower = (includeLowerBody ? Animator.GetLayerWeight(lowerBodyLayerIndex) : 0f);
		while (elapsed < blendIn)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / blendIn;
			Animator.SetLayerWeight(upperBodyLayerIndex, Mathf.Lerp(startWeightUpper, 1f, t));
			if (includeLowerBody)
			{
				Animator.SetLayerWeight(lowerBodyLayerIndex, Mathf.Lerp(startWeightLower, 1f, t));
			}
			yield return null;
		}
		Animator.SetLayerWeight(upperBodyLayerIndex, 1f);
		if (includeLowerBody)
		{
			Animator.SetLayerWeight(lowerBodyLayerIndex, 1f);
		}
		yield return new WaitForSeconds(holdTime);
		elapsed = 0f;
		while (elapsed < blendOut)
		{
			elapsed += Time.deltaTime;
			float t2 = elapsed / blendOut;
			Animator.SetLayerWeight(upperBodyLayerIndex, Mathf.Lerp(1f, 0f, t2));
			if (includeLowerBody)
			{
				Animator.SetLayerWeight(lowerBodyLayerIndex, Mathf.Lerp(1f, 0f, t2));
			}
			yield return null;
		}
		Animator.SetLayerWeight(upperBodyLayerIndex, 0f);
		if (includeLowerBody)
		{
			Animator.SetLayerWeight(lowerBodyLayerIndex, 0f);
		}
		runningHitCoroutine = null;
	}

	private string GetRunningHitTrigger(BodyHitPart hitPart, Vector3 hitDirection)
	{
		return hitPart switch
		{
			BodyHitPart.RightArm => "hit_armR", 
			BodyHitPart.LeftArm => "hit_armL", 
			BodyHitPart.RightLeg => "hit_kneeR", 
			BodyHitPart.LeftLeg => "hit_kneeL", 
			_ => GetDirectionalHitTrigger(hitDirection), 
		};
	}

	private string GetDirectionalHitTrigger(Vector3 hitDirection)
	{
		if (hitDirection == Vector3.zero)
		{
			return "hit_front";
		}
		Vector3 normalized = base.transform.InverseTransformDirection(-hitDirection).normalized;
		float num = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f;
		if (num >= -22.5f && num < 22.5f)
		{
			return "hit_front";
		}
		if (num >= 22.5f && num < 67.5f)
		{
			return "hit_R45";
		}
		if (num >= 67.5f && num < 112.5f)
		{
			return "hit_R";
		}
		if (num >= 112.5f || num < -112.5f)
		{
			return "hit_back";
		}
		if (num >= -112.5f && num < -67.5f)
		{
			return "hit_L";
		}
		if (num >= -67.5f && num < -22.5f)
		{
			return "hit_L45";
		}
		return "hit_front";
	}

	public void ReactHead()
	{
		if (base.isServer)
		{
			CmdReactHead();
		}
		else
		{
			CmdReactHead();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdReactHead()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ZombieAnimationController::CmdReactHead()", 832805756, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void ReactLeftArm()
	{
		if (base.isServer)
		{
			CmdReactLeftArm();
		}
		else
		{
			CmdReactLeftArm();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdReactLeftArm()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ZombieAnimationController::CmdReactLeftArm()", 76311067, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void ReactRightArm()
	{
		if (base.isServer)
		{
			CmdReactRightArm();
		}
		else
		{
			CmdReactRightArm();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdReactRightArm()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ZombieAnimationController::CmdReactRightArm()", -650538308, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void ReactLeftLeg()
	{
		if (base.isServer)
		{
			CmdReactLeftLeg();
		}
		else
		{
			CmdReactLeftLeg();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdReactLeftLeg()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ZombieAnimationController::CmdReactLeftLeg()", 86076749, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void ReactRightLeg()
	{
		if (base.isServer)
		{
			CmdReactRightLeg();
		}
		else
		{
			CmdReactRightLeg();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdReactRightLeg()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ZombieAnimationController::CmdReactRightLeg()", -640772626, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void Jump()
	{
		if (base.isServer)
		{
			CmdJump();
		}
		else
		{
			CmdJump();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdJump()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ZombieAnimationController::CmdJump()", 431774195, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SetWalkSpeed(float speed)
	{
		Animator.SetFloat("WalkSpeed", speed);
	}

	public bool IsAttacking()
	{
		AnimatorStateInfo currentAnimatorStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
		bool flag = false;
		foreach (string standingAttack in standingAttacks)
		{
			if (currentAnimatorStateInfo.IsName(standingAttack) && currentAnimatorStateInfo.normalizedTime < 1f)
			{
				flag = true;
				break;
			}
		}
		AnimatorStateInfo currentAnimatorStateInfo2 = Animator.GetCurrentAnimatorStateInfo(upperBodyLayerIndex);
		bool flag2 = false;
		foreach (string moveAttack in moveAttacks)
		{
			if (currentAnimatorStateInfo2.IsName(moveAttack) && currentAnimatorStateInfo2.normalizedTime < 1f)
			{
				flag2 = true;
				break;
			}
		}
		if (!(flag || flag2))
		{
			return isMoveAttacking;
		}
		return true;
	}

	public bool IsReacting()
	{
		AnimatorStateInfo currentAnimatorStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
		bool num = currentAnimatorStateInfo.IsName("ReactHead");
		bool flag = currentAnimatorStateInfo.IsName("ReactLeftArm");
		bool flag2 = currentAnimatorStateInfo.IsName("ReactRightArm");
		bool flag3 = currentAnimatorStateInfo.IsName("ReactLeftLeg");
		bool flag4 = currentAnimatorStateInfo.IsName("ReactRightLeg");
		if (num || flag || flag2 || flag3 || flag4)
		{
			return currentAnimatorStateInfo.normalizedTime < 1f;
		}
		return false;
	}

	public bool IsJumping()
	{
		AnimatorStateInfo currentAnimatorStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimatorStateInfo.IsName("Jump"))
		{
			return currentAnimatorStateInfo.normalizedTime < 1f;
		}
		return false;
	}

	public bool IsGrounded()
	{
		AnimatorStateInfo currentAnimatorStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
		if (!IsJumping())
		{
			return !currentAnimatorStateInfo.IsName("Jump");
		}
		return false;
	}

	public void OnAttackComplete()
	{
		controller.OnAttackComplete();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAttack__Boolean(bool isMoving)
	{
		Attack(isMoving);
	}

	protected static void InvokeUserCode_CmdAttack__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAttack called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdAttack__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdDeath()
	{
		Death();
	}

	protected static void InvokeUserCode_CmdDeath(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDeath called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdDeath();
		}
	}

	protected void UserCode_CmdGetDamage()
	{
		networkAnimator.SetTrigger("Damage");
	}

	protected static void InvokeUserCode_CmdGetDamage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdGetDamage called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdGetDamage();
		}
	}

	protected void UserCode_CmdReactToHit__String(string bodyPart)
	{
		string trigger = "React" + bodyPart;
		networkAnimator.SetTrigger(trigger);
	}

	protected static void InvokeUserCode_CmdReactToHit__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReactToHit called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdReactToHit__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdPlayRunningHit__String(string trigger)
	{
		networkAnimator.SetTrigger(trigger);
	}

	protected static void InvokeUserCode_CmdPlayRunningHit__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayRunningHit called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdPlayRunningHit__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdReactHead()
	{
		Debug.Log($"[ZOMBIE] CmdReactHead - networkAnimator={networkAnimator != null}, isServer={base.isServer}");
		networkAnimator.SetTrigger("ReactHead");
	}

	protected static void InvokeUserCode_CmdReactHead(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReactHead called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdReactHead();
		}
	}

	protected void UserCode_CmdReactLeftArm()
	{
		networkAnimator.SetTrigger("ReactLeftArm");
	}

	protected static void InvokeUserCode_CmdReactLeftArm(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReactLeftArm called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdReactLeftArm();
		}
	}

	protected void UserCode_CmdReactRightArm()
	{
		networkAnimator.SetTrigger("ReactRightArm");
	}

	protected static void InvokeUserCode_CmdReactRightArm(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReactRightArm called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdReactRightArm();
		}
	}

	protected void UserCode_CmdReactLeftLeg()
	{
		networkAnimator.SetTrigger("ReactLeftLeg");
	}

	protected static void InvokeUserCode_CmdReactLeftLeg(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReactLeftLeg called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdReactLeftLeg();
		}
	}

	protected void UserCode_CmdReactRightLeg()
	{
		networkAnimator.SetTrigger("ReactRightLeg");
	}

	protected static void InvokeUserCode_CmdReactRightLeg(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReactRightLeg called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdReactRightLeg();
		}
	}

	protected void UserCode_CmdJump()
	{
		networkAnimator.SetTrigger("Jump");
	}

	protected static void InvokeUserCode_CmdJump(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdJump called on client.");
		}
		else
		{
			((ZombieAnimationController)obj).UserCode_CmdJump();
		}
	}

	static ZombieAnimationController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdAttack(System.Boolean)", InvokeUserCode_CmdAttack__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdDeath()", InvokeUserCode_CmdDeath, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdGetDamage()", InvokeUserCode_CmdGetDamage, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdReactToHit(System.String)", InvokeUserCode_CmdReactToHit__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdPlayRunningHit(System.String)", InvokeUserCode_CmdPlayRunningHit__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdReactHead()", InvokeUserCode_CmdReactHead, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdReactLeftArm()", InvokeUserCode_CmdReactLeftArm, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdReactRightArm()", InvokeUserCode_CmdReactRightArm, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdReactLeftLeg()", InvokeUserCode_CmdReactLeftLeg, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdReactRightLeg()", InvokeUserCode_CmdReactRightLeg, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieAnimationController), "System.Void ZombieAnimationController::CmdJump()", InvokeUserCode_CmdJump, requiresAuthority: false);
	}
}
