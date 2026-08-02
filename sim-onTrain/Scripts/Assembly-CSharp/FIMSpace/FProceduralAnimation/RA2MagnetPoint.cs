using System;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[DefaultExecutionOrder(50)]
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator/Ragdoll Magnet Point", 11)]
	public class RA2MagnetPoint : FimpossibleComponent
	{
		[HideInInspector]
		public GameObject ObjectWithRagdollAnimator;

		[Tooltip("Transform with rigidbody to connect it with this joint")]
		[HideInInspector]
		public Transform ToMove;

		[Space(3f)]
		[Range(0f, 2f)]
		public float DragPower = 1f;

		[Range(0f, 2f)]
		public float RotatePower;

		[Tooltip("Set zero to compensate body physics reaction on attachement movement in world, set 1 to be affected with natural physics reaction to bones movement.")]
		[Range(0f, 1f)]
		public float MotionInfluence = 1f;

		public bool KinematicOnMax;

		[Space(3f)]
		public Vector3 OriginOffset = Vector3.zero;

		public Quaternion RotationOffset = Quaternion.identity;

		private IRagdollAnimator2HandlerOwner handler;

		private Rigidbody moveRigidbody;

		[NonSerialized]
		private RagdollChainBone attachBone;

		private bool wasKinematic;

		private Transform lastToMove;

		private Vector3 _motionInfluenceOffset;

		private Vector3 _lastFixedPosition;

		private void Start()
		{
			attachBone = null;
			if ((bool)ObjectWithRagdollAnimator)
			{
				handler = ObjectWithRagdollAnimator.GetComponent<IRagdollAnimator2HandlerOwner>();
			}
			if (handler == null)
			{
				handler = GetComponent<IRagdollAnimator2HandlerOwner>();
				ObjectWithRagdollAnimator = base.gameObject;
			}
			_lastFixedPosition = base.transform.position;
			if (handler == null)
			{
				if (ToMove == null)
				{
					base.enabled = false;
				}
				else if (ToMove.GetComponent<Rigidbody>() == null)
				{
					base.enabled = false;
				}
			}
		}

		private void OnEnable()
		{
			wasKinematic = false;
			lastToMove = null;
		}

		private void FixedUpdate()
		{
			if (ToMove == null)
			{
				return;
			}
			if (handler != null && (attachBone == null || attachBone.SourceBone != ToMove))
			{
				attachBone = handler.GetRagdollHandler.User_GetBoneSetupBySourceAnimatorBone(ToMove);
			}
			if (attachBone == null && (lastToMove != ToMove || moveRigidbody == null))
			{
				moveRigidbody = ToMove.GetComponent<Rigidbody>();
			}
			if (attachBone == null && moveRigidbody == null)
			{
				return;
			}
			if (attachBone != null && (moveRigidbody == null || moveRigidbody.transform != attachBone.PhysicalDummyBone))
			{
				moveRigidbody = attachBone.GameRigidbody;
			}
			if (moveRigidbody == null)
			{
				return;
			}
			lastToMove = ToMove;
			Vector3 vector = base.transform.TransformPoint(OriginOffset);
			Quaternion quaternion = base.transform.rotation * RotationOffset;
			bool flag = false;
			if (DragPower > 0f)
			{
				if (DragPower > 1.99999f && KinematicOnMax)
				{
					flag = true;
				}
				else
				{
					moveRigidbody.AddRigidbodyForceToMoveTowards(vector, DragPower);
				}
			}
			if (RotatePower > 0f)
			{
				if (RotatePower > 1.99999f && KinematicOnMax)
				{
					flag = true;
				}
				else
				{
					moveRigidbody.AddRigidbodyTorqueToRotateTowards(quaternion, RotatePower * 1.5f);
				}
			}
			if (flag)
			{
				if (!wasKinematic)
				{
					if (attachBone != null)
					{
						attachBone.BypassKinematicControl = true;
					}
					wasKinematic = true;
					moveRigidbody.isKinematic = true;
				}
				if (DragPower > 0f)
				{
					moveRigidbody.transform.position = vector;
				}
				if (RotatePower > 0f)
				{
					moveRigidbody.transform.rotation = quaternion;
				}
			}
			else if (wasKinematic)
			{
				if (attachBone != null)
				{
					attachBone.BypassKinematicControl = false;
				}
				wasKinematic = false;
				moveRigidbody.isKinematic = false;
			}
			UpdateMotionInfluence();
		}

		private void UpdateMotionInfluence()
		{
			if (handler == null)
			{
				return;
			}
			if (MotionInfluence == 1f)
			{
				_lastFixedPosition = base.transform.position;
				return;
			}
			RagdollHandler getRagdollHandler = handler.GetRagdollHandler;
			_motionInfluenceOffset = base.transform.position - _lastFixedPosition;
			_lastFixedPosition = base.transform.position;
			Vector3 vector = _motionInfluenceOffset * (1f - MotionInfluence);
			if (vector.sqrMagnitude < 1E-05f)
			{
				return;
			}
			foreach (RagdollBonesChain chain in getRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.GameRigidbody.transform.position += vector;
					boneSetup.GameRigidbody.AddForce(vector, ForceMode.VelocityChange);
				}
			}
			_motionInfluenceOffset = Vector3.zero;
		}
	}
}
