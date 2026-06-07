using FIMSpace.Basics;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_Fred2AI : FimpossibleComponent
	{
		public enum EAIStage
		{
			FindPosition = 0,
			PositionToAttack = 1,
			StartAttacking = 2,
			DuringAttack = 3,
			OnTheGround = 4,
			GetUp = 5,
			None = 6
		}

		[Header("It's just example script - not dedicated for real gameplay")]
		public RagdollAnimator2 Ragdoll;

		public LayerMask GroundMask;

		private Rigidbody rig;

		private FAnimationClips anim;

		[Space(5f)]
		public Transform Enemy;

		private bool initialized;

		private EAIStage aiStage;

		private Vector3 attackPosition = Vector3.zero;

		private bool canWalkAnimation = true;

		private float getUpDur;

		[Header("Debug AI Settings")]
		public Vector2 ToAttackDistance = new Vector2(4f, 5f);

		public float MovSpeed = 1f;

		public float RotSpeed = 2f;

		public Vector3 JumpImpact = new Vector3(0f, 1f, 4f);

		public Vector3 JumpHelpTorque = Vector3.zero;

		public float JumpBoost = 1f;

		public Vector3 GetUpHelperTorque = Vector3.zero;

		private float nearPointToleranceLowerer = 1f;

		private float stuckTimer;

		private float sd_layer;

		private float smoothDampSpd = 0.25f;

		private float sd_extraX;

		private float sd_extraZ;

		private Vector3 MovementDir;

		private int _hash_ExtraX = -1;

		private int _hash_ExtraZ = -1;

		private bool attackExecution;

		private bool forceWalkAnim;

		private bool hittedEnemy;

		private float attackDur;

		private float tryGetUpDur;

		private float tryGetSign = 1f;

		private float lastTryGetup = -1f;

		private bool disableRigMove;

		private float accel;

		private bool wasMoving;

		public Animator TargetAnimator => Ragdoll.Handler.Mecanim;

		private float SetAdditive
		{
			set
			{
				SetAdditiveW = Mathf.SmoothDamp(TargetAnimator.GetLayerWeight(1), value, ref sd_layer, 0.1f);
			}
		}

		private float SetAdditiveW
		{
			set
			{
				TargetAnimator.SetLayerWeight(1, value);
			}
		}

		private float SetX
		{
			set
			{
				ExtraX = Mathf.SmoothDamp(ExtraX, value, ref sd_extraX, smoothDampSpd);
			}
		}

		private float SetZ
		{
			set
			{
				ExtraZ = Mathf.SmoothDamp(ExtraZ, value, ref sd_extraZ, smoothDampSpd);
			}
		}

		public float ExtraX
		{
			get
			{
				return TargetAnimator.GetFloat(_hash_ExtraX);
			}
			protected set
			{
				TargetAnimator.SetFloat(_hash_ExtraX, value);
			}
		}

		public float ExtraZ
		{
			get
			{
				return TargetAnimator.GetFloat(_hash_ExtraZ);
			}
			protected set
			{
				TargetAnimator.SetFloat(_hash_ExtraZ, value);
			}
		}

		private void Start()
		{
			PrepareHashes();
			anim = new FAnimationClips(TargetAnimator);
			anim.AddClip("Idle");
			anim.AddClip("Jump Attack");
			anim.AddClip("Roll");
			anim.AddClip("Walk");
			anim.AddClip("Fall");
			anim.AddClip("Try Get Up");
			anim.AddClip("Get Up");
			rig = GetComponent<Rigidbody>();
			initialized = true;
		}

		private Vector3 ZeroY(Vector3 v)
		{
			v.y = 0f;
			return v;
		}

		private void FixedUpdate()
		{
			if (!initialized)
			{
				return;
			}
			wasMoving = false;
			forceWalkAnim = false;
			disableRigMove = false;
			bool flag = false;
			MovementDir = base.transform.forward;
			if (aiStage == EAIStage.FindPosition)
			{
				canWalkAnimation = true;
				aiStage = EAIStage.PositionToAttack;
				attackPosition = Enemy.position;
				tryGetSign = -1f;
				attackPosition += (base.transform.position - Enemy.position).normalized * Random.Range(ToAttackDistance.x, ToAttackDistance.y);
				nearPointToleranceLowerer = 1f;
				stuckTimer = 0f;
			}
			else if (aiStage == EAIStage.PositionToAttack)
			{
				canWalkAnimation = true;
				float num = FVectorMethods.DistanceTopDown(base.transform.position, attackPosition);
				if (num < 0.2f * nearPointToleranceLowerer)
				{
					aiStage = EAIStage.StartAttacking;
				}
				else if (num < 1.25f)
				{
					nearPointToleranceLowerer += Time.fixedDeltaTime * 0.1f;
					if (accel > 0.3f)
					{
						accel -= Time.fixedDeltaTime * 2f;
					}
					MovementDir = Vector3.Slerp(MovementDir, (ZeroY(attackPosition) - ZeroY(base.transform.position)).normalized, num * 0.7f);
				}
				GoForward();
				RotateTowards(attackPosition);
			}
			else if (aiStage == EAIStage.StartAttacking)
			{
				hittedEnemy = false;
				Vector3 normalized = (Enemy.position - base.transform.position).normalized;
				if (Mathf.Abs(Vector3.Angle(base.transform.forward, normalized)) < 7f)
				{
					attackExecution = true;
					disableRigMove = true;
					anim.CrossFadeInFixedTime("Jump Attack");
					canWalkAnimation = false;
					attackDur = 0f;
				}
				if (!attackExecution)
				{
					canWalkAnimation = true;
					RotateTowards(Enemy.position);
					forceWalkAnim = true;
				}
			}
			else if (aiStage == EAIStage.DuringAttack)
			{
				attackExecution = false;
				disableRigMove = true;
				canWalkAnimation = false;
				if (hittedEnemy)
				{
					hittedEnemy = false;
					anim.CrossFadeInFixedTime("Fall");
				}
				attackDur += Time.fixedDeltaTime;
				if (attackDur > 0.6f)
				{
					if (Ragdoll.User_GetChainBonesVelocity(ERagdollChainType.Core).magnitude < 1f)
					{
						stuckTimer += Time.fixedDeltaTime;
						if (stuckTimer > 4f)
						{
							stuckTimer = 0f;
							aiStage = EAIStage.OnTheGround;
						}
					}
					if ((bool)Ragdoll.User_ProbeGroundBelowAnchorBone(GroundMask, 0.45f).transform)
					{
						aiStage = EAIStage.OnTheGround;
						anim.CrossFadeInFixedTime("Fall");
					}
				}
			}
			else if (aiStage == EAIStage.OnTheGround)
			{
				canWalkAnimation = false;
				ERagdollGetUpType eRagdollGetUpType = Ragdoll.User_CanGetUpByRotation(canBeNone: true, null, includeLeftRightSide: false, 0.35f, true);
				bool flag2 = Ragdoll.User_ProbeGroundBelow(Ragdoll.Handler.GetChain(ERagdollChainType.Core).GetBone(2), GroundMask, 0.4f).transform;
				if (!flag2 && eRagdollGetUpType != ERagdollGetUpType.None && Ragdoll.User_GetChainBonesVelocity(ERagdollChainType.Core).magnitude < 0.2f)
				{
					stuckTimer += Time.fixedDeltaTime;
					if (stuckTimer > 2f)
					{
						stuckTimer = 0f;
						Ragdoll.User_AddAllBonesImpact(Vector3.up * 0.15f, 0.125f);
						Ragdoll.User_SetAllPhysicalTorque(Vector3.one, 0.2f);
					}
				}
				if (tryGetUpDur < 0.1f && eRagdollGetUpType == ERagdollGetUpType.FromFacedown)
				{
					SetX = 0f;
					SetZ = 1f;
					if (flag2 && Ragdoll.User_GetChainBonesVelocity(ERagdollChainType.Core).magnitude < 0.3f)
					{
						anim.CrossFadeInFixedTime("Get Up", 0.2f);
						rig.rotation = Ragdoll.User_GetMappedRotationHipsToHead(Vector3.up, checkIfOnBack: false);
						rig.position = Ragdoll.User_ProbeGroundBelow(Ragdoll.Handler.GetChain(ERagdollChainType.Core).GetBone(2), GroundMask, 1f).point;
						Ragdoll.User_TransitionToStandingMode(0.6f, 0.3f, 0f);
						aiStage = EAIStage.GetUp;
						getUpDur = 0.6f;
						accel = 0f;
					}
				}
				else
				{
					ERagdollGetUpType eRagdollGetUpType2 = Ragdoll.User_LayingOnSide();
					switch (eRagdollGetUpType)
					{
					case ERagdollGetUpType.FromBack:
						SetZ = -0.5f;
						break;
					case ERagdollGetUpType.FromFacedown:
						SetZ = 0.7f;
						break;
					default:
						SetZ = 0f;
						break;
					}
					switch (eRagdollGetUpType2)
					{
					case ERagdollGetUpType.FromLeftSide:
						SetX = 0.5f;
						break;
					case ERagdollGetUpType.FromRightSide:
						SetX = -0.5f;
						break;
					default:
						SetX = Mathf.Sin(Time.fixedTime * 1.5f);
						break;
					}
					if (tryGetUpDur <= 0f)
					{
						float magnitude = Ragdoll.User_GetChainBonesVelocity(ERagdollChainType.Core, average: false).magnitude;
						flag = true;
						if (Time.time - lastTryGetup > 1.5f && magnitude < 0.8f && eRagdollGetUpType == ERagdollGetUpType.FromBack)
						{
							tryGetSign = 0f - tryGetSign;
							tryGetUpDur = 2f;
							anim.CrossFadeInFixedTime("Try Get Up");
						}
					}
					else
					{
						tryGetUpDur -= Time.fixedDeltaTime;
						if (eRagdollGetUpType != ERagdollGetUpType.FromFacedown)
						{
							Ragdoll.User_SetPhysicalTorqueOnRigidbody(Ragdoll.Handler.GetAnchorBoneController.GameRigidbody, GetUpHelperTorque * tryGetSign, 0f, relativeSpace: true, ForceMode.Acceleration, deltaScale: true);
							Ragdoll.User_SetPhysicalTorqueOnRigidbody(Ragdoll.Handler.GetChain(ERagdollChainType.Core).GetBone(1).GameRigidbody, GetUpHelperTorque * tryGetSign * 0.9f, 0f, relativeSpace: true, ForceMode.Acceleration, deltaScale: true);
							Ragdoll.User_SetPhysicalTorqueOnRigidbody(Ragdoll.Handler.GetChain(ERagdollChainType.Core).GetBone(2).GameRigidbody, GetUpHelperTorque * tryGetSign * 0.8f, 0f, relativeSpace: true, ForceMode.Acceleration, deltaScale: true);
						}
						if (tryGetUpDur <= 0f)
						{
							anim.CrossFadeInFixedTime("Fall");
							lastTryGetup = Time.time;
						}
					}
				}
			}
			else if (aiStage == EAIStage.GetUp)
			{
				getUpDur -= Time.fixedDeltaTime;
				if (getUpDur < 0f)
				{
					aiStage = EAIStage.FindPosition;
				}
			}
			if (!disableRigMove)
			{
				Vector3 velocity = MovementDir * MovSpeed * accel;
				velocity.y = rig.velocity.y;
				rig.velocity = velocity;
			}
			if (!wasMoving)
			{
				accel = Mathf.Lerp(accel, 0f, Time.fixedDeltaTime * 4f);
			}
			HandleBasicAnimations();
			if (flag)
			{
				SetAdditive = 0.4f + Mathf.Abs(Mathf.Sin(Time.fixedTime * 1.5f) * 0.6f);
			}
			else
			{
				SetAdditive = 0f;
			}
		}

		protected virtual void PrepareHashes()
		{
			_hash_ExtraX = Animator.StringToHash("ExtraX");
			_hash_ExtraZ = Animator.StringToHash("ExtraZ");
		}

		private void HandleBasicAnimations()
		{
			if (canWalkAnimation)
			{
				if (forceWalkAnim)
				{
					anim.CrossFadeInFixedTime("Walk", 0.2f);
				}
				else if (accel < 0.05f)
				{
					anim.CrossFadeInFixedTime("Idle", 0.2f);
				}
				else
				{
					anim.CrossFadeInFixedTime("Walk", 0.2f);
				}
			}
		}

		public void EJumpAttack()
		{
			aiStage = EAIStage.DuringAttack;
			Ragdoll.User_SwitchFallState();
			Vector3 vector = base.transform.TransformVector(JumpImpact);
			Ragdoll.User_SetAllBonesVelocity(vector);
			Vector3 vector2 = vector;
			vector2.y *= 0.4f;
			Ragdoll.User_AddAllBonesImpact(vector2 * 0.02f * JumpBoost, 0.15f);
			Ragdoll.User_SetAllPhysicalTorque(JumpHelpTorque, 0.125f, relativeSpace: true);
		}

		private void OnDrawGizmosSelected()
		{
			if ((bool)Enemy)
			{
				Gizmos.DrawRay(Enemy.position, (base.transform.position - Enemy.position).normalized * ToAttackDistance.y);
				if (attackPosition != Vector3.zero)
				{
					Gizmos.DrawRay(attackPosition, Vector3.up);
				}
			}
		}

		private void GoForward()
		{
			wasMoving = true;
			accel = Mathf.Lerp(accel, 1f, Time.fixedDeltaTime * 4f);
		}

		private void RotateTowards(Vector3 pos)
		{
			rig.angularVelocity = Vector3.zero;
			Vector3 forward = Vector3.ProjectOnPlane(pos - base.transform.position, Vector3.up);
			rig.rotation = Quaternion.Slerp(rig.rotation, Quaternion.LookRotation(forward), Time.fixedDeltaTime * RotSpeed);
		}
	}
}
