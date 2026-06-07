using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator/Ragdoll Attachable (Equipable)", 111)]
	public class RA2AttachableObject : MonoBehaviour
	{
		private class AttachableCollisionDetector : MonoBehaviour
		{
			public RA2AttachableObject Parent;

			private void OnCollisionEnter(Collision collision)
			{
				if (!(Parent == null))
				{
					Parent.CallOnCollisionEnter(collision);
				}
			}

			private void OnCollisionExit(Collision collision)
			{
				if (!(Parent == null))
				{
					Parent.CallOnCollisionExit(collision);
				}
			}
		}

		[Space(2f)]
		[HideInInspector]
		public bool ChangeLocalCoords = true;

		[HideInInspector]
		public Vector3 TargetLocalPosition = Vector3.zero;

		[HideInInspector]
		public Vector3 TargetLocalRotation = Vector3.zero;

		[Space(5f)]
		[Tooltip("If collider should be present on the animator and on the physical dummy")]
		public bool KeepColliderOnAnimator;

		[Tooltip("Changing attachable object layer to be same as animator bones and dummmy bones layers")]
		public bool ChangeObjectLayer = true;

		[FPD_SingleLineTwoProps("DetectCollisions", 0, 0, 10, 0, 0)]
		[Tooltip("Add collision indicator component to this model attached on the source animator bone and on the generated physics object")]
		public bool AddCollisionIndicators = true;

		[Tooltip("Adding collision detector component. To use it, you need to call myAttachable.AddEventToCallOnCollision()")]
		[HideInInspector]
		public bool DetectCollisions;

		[Space(5f)]
		public List<Collider> AttachableColliders = new List<Collider>();

		[Tooltip("Optional reference to item source rigidbody")]
		public Rigidbody OptionalRigidbody;

		[Space(5f)]
		[Tooltip("Set mass above zero, to generate fixed joint connection between attachable item and attachement bone, affecting weight putted on the bone.")]
		public float Mass;

		[HideInInspector]
		[Tooltip("Making connected mass multiplier lower, will produce lighter motion for the item.")]
		[Range(0f, 1f)]
		public float ConnectedMassMultiplier = 0.25f;

		[HideInInspector]
		[Range(0f, 5f)]
		public float MassScale = 1.5f;

		[HideInInspector]
		public int IgnoreChainsCollisions;

		[Tooltip("Making item more stiff but hold more precisely.")]
		[HideInInspector]
		[Range(0f, 1f)]
		public float HardMatching;

		[Tooltip("Making hard matching less powerful when item gets pushed away from the desired coordinates.")]
		[HideInInspector]
		[Range(0f, 1f)]
		public float SoftLimit;

		private bool wasOriginalRigidbodyKinematic;

		private Vector3 unwearVelocity = Vector3.zero;

		private Vector3 unwearAngularVelocity = Vector3.zero;

		private AttachableCollisionDetector collisionsDetector;

		private List<Action<Collision>> CollisionEvents;

		private List<Action<Collision>> CollisionExitEvents;

		public RagdollHandler AttachedTo { get; private set; }

		public RagdollChainBone AttachedToBone { get; private set; }

		public GameObject GeneratedPhysicsObject { get; private set; }

		public List<Collider> GeneratedPhysicsColliders { get; private set; }

		public Rigidbody lastRigidbody { get; private set; }

		public FixedJoint lastJoint { get; private set; }

		private void Reset()
		{
			GatherAllChildColliders();
			OptionalRigidbody = GetComponentInChildren<Rigidbody>();
			if ((bool)OptionalRigidbody)
			{
				Mass = OptionalRigidbody.mass;
			}
		}

		public void GatherAllChildColliders()
		{
			List<Collider> list = new List<Collider>();
			Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform obj in componentsInChildren)
			{
				list.Clear();
				obj.GetComponents(list);
				foreach (Collider item in list)
				{
					if (!AttachableColliders.Contains(item))
					{
						AttachableColliders.Add(item);
					}
				}
			}
		}

		public void GetCurrentLocalCoords()
		{
			TargetLocalPosition = base.transform.localPosition;
			TargetLocalRotation = base.transform.localRotation.eulerAngles;
		}

		internal void OnStartAttachingToRagdoll(RagdollHandler ragdollHandler, RagdollChainBone dummyBone)
		{
			if ((bool)OptionalRigidbody)
			{
				wasOriginalRigidbodyKinematic = OptionalRigidbody.isKinematic;
				OptionalRigidbody.isKinematic = true;
				OptionalRigidbody.detectCollisions = false;
			}
		}

		public void OnAttachToRagdoll(GameObject root, RagdollHandler ragdoll, RagdollChainBone bone, List<Collider> colliders)
		{
			AttachedTo = ragdoll;
			AttachedToBone = bone;
			GeneratedPhysicsColliders = colliders;
			if (GeneratedPhysicsObject != null && GeneratedPhysicsObject != root)
			{
				UnityEngine.Object.Destroy(GeneratedPhysicsObject);
			}
			GeneratedPhysicsObject = root;
			if (DetectCollisions)
			{
				collisionsDetector = GeneratedPhysicsObject.AddComponent<AttachableCollisionDetector>();
				collisionsDetector.Parent = this;
			}
			IgnoreChainCollisionsWith(ragdoll, ignore: true);
		}

		public void RemoveFromCurrentDummy()
		{
			if ((bool)lastRigidbody)
			{
				unwearVelocity = lastRigidbody.velocity;
				unwearAngularVelocity = lastRigidbody.angularVelocity;
			}
			if ((bool)GeneratedPhysicsObject)
			{
				UnityEngine.Object.Destroy(GeneratedPhysicsObject);
			}
			collisionsDetector = null;
			GeneratedPhysicsColliders = null;
			if (AttachedTo != null)
			{
				IgnoreChainCollisionsWith(AttachedTo, ignore: false);
			}
			AttachedTo = null;
			AttachedToBone = null;
			if (!OptionalRigidbody)
			{
				return;
			}
			OptionalRigidbody.isKinematic = wasOriginalRigidbodyKinematic;
			OptionalRigidbody.detectCollisions = true;
			if (!OptionalRigidbody.isKinematic)
			{
				StartCoroutine(IECallAfterFixedFrame(delegate
				{
					OptionalRigidbody.velocity = unwearVelocity;
					OptionalRigidbody.angularVelocity = unwearAngularVelocity;
				}));
			}
		}

		private IEnumerator IECallAfterFixedFrame(Action action)
		{
			yield return new WaitForFixedUpdate();
			action();
		}

		private void IgnoreChainCollisionsWith(RagdollHandler ragdoll, bool ignore)
		{
			ERagdollChainType ignoreChainsCollisions = (ERagdollChainType)IgnoreChainsCollisions;
			foreach (RagdollBonesChain chain in ragdoll.Chains)
			{
				if ((ignoreChainsCollisions & chain.ChainType) == 0)
				{
					continue;
				}
				foreach (Collider attachableCollider in AttachableColliders)
				{
					chain.IgnoreCollisionsWith(attachableCollider, ignore);
				}
				if (GeneratedPhysicsColliders == null)
				{
					continue;
				}
				foreach (Collider generatedPhysicsCollider in GeneratedPhysicsColliders)
				{
					chain.IgnoreCollisionsWith(generatedPhysicsCollider, ignore);
				}
			}
		}

		internal void UpdateOnRagdoll()
		{
			base.transform.localPosition = GeneratedPhysicsObject.transform.localPosition;
			base.transform.localRotation = GeneratedPhysicsObject.transform.localRotation;
		}

		internal void FixedUpdateTick()
		{
			if (!(HardMatching <= 0f) && !(lastRigidbody == null))
			{
				Vector3 animatorPosition = AttachedToBone.BoneProcessor.AnimatorPosition;
				animatorPosition += AttachedToBone.BoneProcessor.AnimatorRotation * Quaternion.Euler(TargetLocalRotation) * (lastRigidbody.centerOfMass + TargetLocalPosition);
				float num = 1f;
				if (SoftLimit > 0f)
				{
					float sqrMagnitude = (animatorPosition - lastRigidbody.worldCenterOfMass).sqrMagnitude;
					num = 1f / (sqrMagnitude * SoftLimit * 50f + 1f);
				}
				lastRigidbody.AddRigidbodyForceToMoveTowards(animatorPosition, HardMatching * num);
			}
		}

		internal virtual void OnGeneratePhysicsComponents(Rigidbody rig, FixedJoint joint)
		{
			lastRigidbody = rig;
			lastJoint = joint;
		}

		public void AddEventToCallOnCollision(Action<Collision> action)
		{
			if (CollisionEvents == null)
			{
				CollisionEvents = new List<Action<Collision>>();
			}
			if (!CollisionEvents.Contains(action))
			{
				CollisionEvents.Add(action);
			}
		}

		public void RemoveEventToCallOnCollision(Action<Collision> action)
		{
			if (CollisionEvents != null && CollisionEvents.Contains(action))
			{
				CollisionEvents.Remove(action);
			}
		}

		public void AddEventToCallOnCollisionExit(Action<Collision> action)
		{
			if (CollisionExitEvents == null)
			{
				CollisionExitEvents = new List<Action<Collision>>();
			}
			if (!CollisionExitEvents.Contains(action))
			{
				CollisionExitEvents.Add(action);
			}
		}

		public void RemoveEventToCallOnCollisionExit(Action<Collision> action)
		{
			if (CollisionExitEvents != null && CollisionExitEvents.Contains(action))
			{
				CollisionExitEvents.Remove(action);
			}
		}

		private void CallOnCollisionEnter(Collision collision)
		{
			if (CollisionEvents != null)
			{
				for (int i = 0; i < CollisionEvents.Count; i++)
				{
					CollisionEvents[i](collision);
				}
			}
		}

		private void CallOnCollisionExit(Collision collision)
		{
			if (CollisionExitEvents != null)
			{
				for (int i = 0; i < CollisionExitEvents.Count; i++)
				{
					CollisionExitEvents[i](collision);
				}
			}
		}
	}
}
