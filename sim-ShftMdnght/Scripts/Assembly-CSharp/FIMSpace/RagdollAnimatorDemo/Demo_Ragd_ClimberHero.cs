using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_ClimberHero : FimpossibleComponent
	{
		private class HandControll
		{
			public RagdollChainBone ragdollBone;

			public bool isAttached;

			public Collider attachedTo;

			public Vector3 attachLocalPos = Vector3.zero;

			public Quaternion attachLocalRot = Quaternion.identity;

			public void Detach()
			{
				ragdollBone.GameRigidbody.isKinematic = false;
				isAttached = false;
				attachedTo = null;
				ragdollBone.MainBoneCollider.enabled = true;
			}
		}

		public RagdollAnimator2 RagdollAnimator;

		public FBasic_RigidbodyMover Mover;

		public Animator Mecanim;

		[Space(5f)]
		public LayerMask CatchLayer;

		public float CatchRadius = 0.1f;

		[Space(5f)]
		public float WavingImputPower = 1f;

		[Space(5f)]
		[Tooltip("Divider for the animator velocity property (for animation clip blend tree)")]
		public float VelocityParamDiv = 2f;

		public bool PreventStretch = true;

		public bool StopOnGrounded = true;

		private float _sd;

		private int _hash;

		private RagdollAnimatorFeatureHelper blendOnCollision;

		private bool wasGrounded = true;

		private float catchCulldown;

		private HandControll leftHand;

		private HandControll rightHand;

		private Vector3 scheduledWaveImpact = Vector3.zero;

		private bool wasJump;

		private int overlaps;

		private Collider[] overlapColliders = new Collider[8];

		private HandControll GetHand(int i)
		{
			if (i <= 0)
			{
				return leftHand;
			}
			return rightHand;
		}

		private void Start()
		{
			_hash = Animator.StringToHash("HandsLevel");
			blendOnCollision = RagdollAnimator.Handler.GetExtraFeatureHelper<RAF_BlendOnCollisions>();
			leftHand = new HandControll
			{
				ragdollBone = RagdollAnimator.Handler.GetChain(ERagdollChainType.LeftArm).LastBone
			};
			rightHand = new HandControll
			{
				ragdollBone = RagdollAnimator.Handler.GetChain(ERagdollChainType.RightArm).LastBone
			};
			Mover.OnJump = OnJump;
		}

		private bool AnyCatched()
		{
			bool result = false;
			for (int i = 0; i < 2; i++)
			{
				if (GetHand(i).isAttached)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		private void Update()
		{
			float value = Mover.Rigb.velocity.y / VelocityParamDiv;
			value = Mathf.Clamp(value, -1f, 1f);
			bool flag = AnyCatched();
			float current = Mecanim.GetFloat(_hash);
			current = Mathf.SmoothDamp(current, AnyCatched() ? 2f : value, ref _sd, 0.15f, 1000000f, Time.deltaTime);
			Mecanim.SetFloat(_hash, current);
			if (flag)
			{
				RagdollAnimator.Handler.AnimatingMode = RagdollHandler.EAnimatingMode.Falling;
				Mover.UpdateInput = false;
				if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
				{
					WaveImpact(GetCameraDirection(Vector3.forward));
				}
				if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
				{
					WaveImpact(-GetCameraDirection(Vector3.forward));
				}
				if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
				{
					WaveImpact(GetCameraDirection(Vector3.right));
				}
				if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
				{
					WaveImpact(-GetCameraDirection(Vector3.right));
				}
				if (Input.GetKeyDown(KeyCode.Space))
				{
					Mover.jumpRequest = Mover.JumpPower;
				}
			}
			else
			{
				Mover.UpdateInput = true;
				RagdollAnimator.User_TransitionToStandingMode(0.4f, 0f);
			}
			if (wasGrounded == Mover.isGrounded)
			{
				return;
			}
			if (blendOnCollision != null)
			{
				blendOnCollision.Enabled = Mover.isGrounded;
			}
			wasGrounded = Mover.isGrounded;
			if (Mover.isGrounded)
			{
				wasJump = false;
			}
			else if (!wasJump)
			{
				Mecanim.CrossFadeInFixedTime("Jump Motion", 0.1f);
			}
			if (!StopOnGrounded)
			{
				return;
			}
			for (int i = 0; i < 2; i++)
			{
				GetHand(i).isAttached = false;
			}
			if (Mover.isGrounded && !flag)
			{
				for (int j = 0; j < 2; j++)
				{
					GetHand(j).Detach();
				}
			}
		}

		private Vector3 GetCameraDirection(Vector3 direction)
		{
			return Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, Vector3.up);
		}

		private void WaveImpact(Vector3 dir)
		{
			scheduledWaveImpact = dir;
		}

		private void FixedUpdate()
		{
			if (scheduledWaveImpact != Vector3.zero)
			{
				Vector3 velocity = scheduledWaveImpact;
				velocity *= WavingImputPower;
				RagdollBonesChain chain = RagdollAnimator.Handler.GetChain(ERagdollChainType.LeftLeg);
				RagdollAnimator.User_AddChainImpact(chain, velocity, 0f);
				chain = RagdollAnimator.Handler.GetChain(ERagdollChainType.RightLeg);
				RagdollAnimator.User_AddChainImpact(chain, velocity, 0f);
				chain = RagdollAnimator.Handler.GetChain(ERagdollChainType.Core);
				for (int i = 0; i < 2; i++)
				{
					RagdollChainBone bone = chain.BoneSetups[i];
					RagdollAnimator.User_AddBoneImpact(bone, velocity, 0f);
				}
				scheduledWaveImpact = Vector3.zero;
			}
			catchCulldown -= Time.fixedDeltaTime;
			if (!Mover.isGrounded)
			{
				if (catchCulldown < 0f)
				{
					CheckHands();
				}
				if (AnyCatched())
				{
					RagdollChainBone getAnchorBoneController = RagdollAnimator.Handler.GetAnchorBoneController;
					Mover.Rigb.velocity = getAnchorBoneController.GameRigidbody.velocity;
					Mover.Rigb.position = RagdollAnimator.User_GetPosition_FeetMiddle();
				}
			}
			if (PreventStretch)
			{
				float num = Vector3.Distance(GetHand(0).ragdollBone.BoneProcessor.lastAppliedPosition, GetHand(1).ragdollBone.BoneProcessor.lastAppliedPosition);
				float num2 = GetHand(0).ragdollBone.ParentChain.ChainBonesLength + GetHand(1).ragdollBone.ParentChain.ChainBonesLength;
				if (num > num2 * 1.7f)
				{
					GetHand(0).Detach();
					GetHand(1).Detach();
				}
			}
		}

		private void OnJump()
		{
			wasJump = true;
			RagdollAnimator.Handler.GetAnchorBoneController.GameRigidbody.velocity = Mover.Rigb.velocity;
			Mecanim.CrossFadeInFixedTime("Jump", 0.07f);
			catchCulldown = 0.6f;
			for (int i = 0; i < 2; i++)
			{
				GetHand(i).Detach();
			}
		}

		private void LateUpdate()
		{
			for (int i = 0; i < 2; i++)
			{
				HandControll hand = GetHand(i);
				if (hand.isAttached)
				{
					hand.ragdollBone.GameRigidbody.position = hand.attachedTo.transform.TransformPoint(hand.attachLocalPos);
					hand.ragdollBone.GameRigidbody.rotation = hand.attachedTo.transform.rotation * hand.attachLocalRot;
				}
			}
		}

		private void OnDrawGizmos()
		{
			if (leftHand != null)
			{
				Gizmos.color = Color.green * 0.7f;
				for (int i = 0; i < 2; i++)
				{
					Gizmos.DrawWireSphere(GetHand(i).ragdollBone.GameRigidbody.position, CatchRadius);
				}
			}
		}

		private void CheckHands()
		{
			for (int i = 0; i < 2; i++)
			{
				HandControll hand = GetHand(i);
				if (hand.isAttached)
				{
					hand.ragdollBone.GameRigidbody.position = hand.attachedTo.transform.TransformPoint(hand.attachLocalPos);
					hand.ragdollBone.GameRigidbody.rotation = hand.attachedTo.transform.rotation * hand.attachLocalRot;
					continue;
				}
				hand.ragdollBone.GameRigidbody.isKinematic = false;
				overlaps = Physics.OverlapSphereNonAlloc(hand.ragdollBone.GameRigidbody.position, CatchRadius, overlapColliders, CatchLayer);
				for (int j = 0; j < overlaps; j++)
				{
					Collider collider = overlapColliders[j];
					hand.ragdollBone.MainBoneCollider.enabled = false;
					if (!(collider == hand.attachedTo))
					{
						Vector3 position = collider.ClosestPoint(hand.ragdollBone.GameRigidbody.position);
						hand.isAttached = true;
						hand.attachedTo = collider;
						hand.ragdollBone.GameRigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
						hand.ragdollBone.GameRigidbody.isKinematic = true;
						hand.ragdollBone.GameRigidbody.position = position;
						hand.attachLocalRot = collider.transform.rotation.QToLocal(hand.ragdollBone.GameRigidbody.transform.rotation);
						hand.attachLocalPos = collider.transform.InverseTransformPoint(position);
						break;
					}
				}
			}
		}
	}
}
