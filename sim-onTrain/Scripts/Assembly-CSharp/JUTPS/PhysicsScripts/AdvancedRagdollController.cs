using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JUTPS.PhysicsScripts
{
	[AddComponentMenu("JU TPS/Physics/Advanced Ragdoll Controller")]
	public class AdvancedRagdollController : MonoBehaviour
	{
		public enum RagdollState
		{
			Animated = 0,
			WaitStablePosition = 1,
			Ragdolled = 2,
			BlendToAnim = 3
		}

		private Vector3 groundNormal;

		private GameObject character;

		private Animator animator;

		private bool isStartAnimatorUpdateInPhysics;

		private Rigidbody rigidBody;

		[HideInInspector]
		public bool RagdollEnabled;

		public RagdollState State;

		private bool GetUpFromBelly;

		public Transform[] AllBones;

		public Rigidbody[] RagdollBones;

		public Transform Hips;

		public Transform HipsParent;

		private Transform Head;

		private Rigidbody HipsRigidbody;

		private List<BoneTransformInfo> bones = new List<BoneTransformInfo>();

		public float BlendAmount;

		[Range(1f, 5f)]
		public float TimeToGetUp = 3f;

		[Range(1f, 5f)]
		public float BlendSpeed = 2f;

		public float RagdollDrag = 0.5f;

		public bool RagdollWhenPressKeyG;

		public bool ViewHumanBodyBones;

		public bool ViewBodyPhysics;

		public bool ViewBodyDirection;

		public bool FilterByBoneLayer = true;

		private Vector3 UpDirection;

		private void Start()
		{
			Invoke("StartAdvancedRagdollController", 0.001f);
		}

		private void Update()
		{
			if (RagdollWhenPressKeyG && Keyboard.current.gKey.isPressed)
			{
				State = RagdollState.Ragdolled;
			}
			RagdollStatesController();
		}

		private void LateUpdate()
		{
			BlendRagdollToAnimator();
		}

		private void OnDisable()
		{
			if (Hips != null)
			{
				Hips.gameObject.SetActive(value: false);
			}
		}

		private void OnEnable()
		{
			if (Hips != null)
			{
				Hips.gameObject.SetActive(value: true);
			}
		}

		private void OnDestroy()
		{
			if (Hips != null)
			{
				Object.Destroy(Hips.gameObject);
			}
		}

		public void StartAdvancedRagdollController()
		{
			character = base.gameObject;
			animator = GetComponent<Animator>();
			rigidBody = GetComponent<Rigidbody>();
			isStartAnimatorUpdateInPhysics = animator.updateMode == AnimatorUpdateMode.AnimatePhysics;
			if (animator == null || character == null)
			{
				return;
			}
			Hips = animator.GetBoneTransform(HumanBodyBones.Hips);
			HipsParent = Hips.parent;
			HipsRigidbody = Hips.GetComponent<Rigidbody>();
			Head = animator.GetBoneTransform(HumanBodyBones.Head);
			RagdollBones = Hips.GetComponentsInChildren<Rigidbody>();
			AllBones = Hips.GetComponentsInChildren<Transform>();
			Transform[] allBones;
			if (FilterByBoneLayer)
			{
				List<Transform> list = new List<Transform>();
				allBones = AllBones;
				foreach (Transform transform in allBones)
				{
					if (transform.gameObject.layer == 15)
					{
						list.Add(transform);
					}
				}
				AllBones = list.ToArray();
				List<Rigidbody> list2 = new List<Rigidbody>();
				Rigidbody[] ragdollBones = RagdollBones;
				foreach (Rigidbody rigidbody in ragdollBones)
				{
					if (rigidbody.gameObject.layer == 15)
					{
						list2.Add(rigidbody);
					}
				}
				RagdollBones = list2.ToArray();
			}
			allBones = AllBones;
			foreach (Transform transform2 in allBones)
			{
				bones.Add(new BoneTransformInfo(transform2.transform));
			}
			SetActiveRagdoll(Enabled: false);
		}

		public void RagdollStatesController()
		{
			if (HipsRigidbody == null)
			{
				State = RagdollState.Animated;
				return;
			}
			if (State == RagdollState.Animated && !animator.enabled)
			{
				animator.enabled = true;
				RagdollEnabled = false;
				SetActiveRagdoll(Enabled: false);
				Hips.parent = HipsParent;
			}
			if (State == RagdollState.Ragdolled)
			{
				if (!RagdollEnabled)
				{
					SetActiveRagdoll(Enabled: true, Inertia: true);
					Hips.parent = null;
				}
				if (HipsRigidbody.velocity.magnitude < 0.01f && !IsInvoking("SetWaitStablePositionInvoked"))
				{
					Invoke("SetWaitStablePositionInvoked", TimeToGetUp);
				}
				if (Hips.parent == null)
				{
					LayerMask layerMask = LayerMask.GetMask("Default", "Terrain", "Walls");
					Physics.Raycast(Hips.position, -base.transform.up, out var hitInfo, 0.5f, layerMask);
					Vector3 position = Hips.position;
					position.y = hitInfo.point.y;
					base.transform.position = position;
					groundNormal = ((hitInfo.normal != Vector3.zero) ? hitInfo.normal : Vector3.up);
					SetTransformRotationToBodyDirection();
				}
				base.transform.position = Hips.position;
			}
			if (State == RagdollState.WaitStablePosition)
			{
				Hips.parent = HipsParent;
				foreach (BoneTransformInfo bone in bones)
				{
					bone.StoredPosition = bone.Transform.localPosition;
					bone.StoredRotation = bone.Transform.localRotation;
				}
				GetUp();
				State = RagdollState.BlendToAnim;
			}
			if (State == RagdollState.BlendToAnim)
			{
				animator.updateMode = AnimatorUpdateMode.Normal;
			}
			else if (isStartAnimatorUpdateInPhysics)
			{
				animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
			}
			LayerMask layerMask2 = LayerMask.GetMask("Default", "Terrain", "Walls");
			if (Physics.Raycast(Hips.position, Hips.forward, out var _, 0.5f, layerMask2))
			{
				GetUpFromBelly = true;
			}
			else
			{
				GetUpFromBelly = false;
			}
		}

		public void BlendRagdollToAnimator()
		{
			if (State != RagdollState.BlendToAnim)
			{
				return;
			}
			foreach (BoneTransformInfo bone in bones)
			{
				bone.Transform.localPosition = Vector3.Slerp(bone.Transform.localPosition, bone.StoredPosition, BlendAmount);
				bone.Transform.localRotation = Quaternion.Slerp(bone.Transform.localRotation, bone.StoredRotation, BlendAmount);
			}
			BlendAmount = Mathf.MoveTowards(BlendAmount, 0f, BlendSpeed * Time.deltaTime);
			if (BlendAmount <= 0f)
			{
				State = RagdollState.Animated;
			}
			if (IsInvoking("SetWaitStablePositionInvoked"))
			{
				CancelInvoke("SetWaitStablePositionInvoked");
			}
		}

		public void SetActiveRagdoll(bool Enabled, bool Inertia = false)
		{
			Rigidbody[] ragdollBones = RagdollBones;
			for (int i = 0; i < ragdollBones.Length; i++)
			{
				ragdollBones[i].isKinematic = !Enabled;
			}
			RagdollEnabled = Enabled;
			animator.enabled = !Enabled;
			if (Inertia)
			{
				ragdollBones = RagdollBones;
				foreach (Rigidbody obj in ragdollBones)
				{
					obj.velocity = GetComponent<Rigidbody>().velocity;
					obj.angularVelocity = Vector3.zero;
					obj.angularDrag = RagdollDrag;
				}
			}
			if (Enabled)
			{
				rigidBody.isKinematic = true;
				rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			}
			else
			{
				rigidBody.isKinematic = false;
				rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			}
			character.GetComponent<CapsuleCollider>().enabled = !Enabled;
		}

		private void SetWaitStablePositionInvoked()
		{
			State = RagdollState.WaitStablePosition;
		}

		public void GetUp()
		{
			SetTransformRotationToBodyDirection();
			SetActiveRagdoll(Enabled: false);
			BlendAmount = 1f;
			if (GetUpFromBelly)
			{
				animator.Play("Get Up From Belly", 0, 0f);
			}
			else
			{
				animator.Play("Get Up From Back", 0, 0f);
			}
		}

		public void SetTransformRotationToBodyDirection()
		{
			UpDirection = base.transform.up;
			UpDirection = Vector3.Lerp(UpDirection, groundNormal, 5f * Time.deltaTime);
			base.transform.rotation = Quaternion.FromToRotation(base.transform.forward, BodyDirection()) * base.transform.rotation;
			Hips.rotation = Quaternion.FromToRotation(BodyDirection(), base.transform.forward) * Hips.rotation;
			base.transform.rotation = Quaternion.FromToRotation(base.transform.up, UpDirection) * base.transform.rotation;
		}

		public Vector3 BodyDirection()
		{
			Vector3 vector = Hips.position - Head.position;
			vector.y = 0f;
			if (GetUpFromBelly)
			{
				return -vector.normalized;
			}
			return vector.normalized;
		}

		public void Fall()
		{
			State = RagdollState.Ragdolled;
		}
	}
}
