using System;
using System.Collections;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	public abstract class PhysicsActor : MonoBehaviour
	{
		public enum RootMotionVelocityType
		{
			SetVelocity = 0,
			SetPlanarVelocity = 1,
			SetVerticalVelocity = 2
		}

		public enum RootMotionRotationType
		{
			SetRotation = 0,
			AddRotation = 1
		}

		[Header("Rigidbody")]
		[Tooltip("Interpolates the Transform component associated with this actor during Update calls. This is a custom implementation, the actor does not use Unity's default interpolation.")]
		public bool interpolateActor = true;

		[Tooltip("Whether or not to use continuous collision detection (rigidbody property). This won't affect character vs static obstacles interactions, but it will affect character vs dynamic rigidbodies.")]
		public bool useContinuousCollisionDetection = true;

		[Header("Root motion")]
		[Tooltip("This option activates root motion for the character. With root motion enabled, position and rotation are handled exclusively by the animation system.")]
		public bool UseRootMotion;

		[Tooltip("Whether or not to transfer position data from the root motion animation to the character.")]
		[Condition("UseRootMotion", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public bool UpdateRootPosition = true;

		[Tooltip("How the root velocity data is going to be applied to the actor.")]
		[Condition(new string[] { "UpdateRootPosition", "UseRootMotion" }, new ConditionAttribute.ConditionType[]
		{
			ConditionAttribute.ConditionType.IsTrue,
			ConditionAttribute.ConditionType.IsTrue
		}, new float[] { 0f, 0f }, ConditionAttribute.VisibilityType.NotEditable)]
		public RootMotionVelocityType rootMotionVelocityType;

		[Tooltip("Whether or not to transfer rotation data from the root motion animation to the character.")]
		[Condition("UseRootMotion", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public bool UpdateRootRotation = true;

		[Tooltip("How the root velocity data is going to be applied to the actor.")]
		[Condition(new string[] { "UpdateRootRotation", "UseRootMotion" }, new ConditionAttribute.ConditionType[]
		{
			ConditionAttribute.ConditionType.IsTrue,
			ConditionAttribute.ConditionType.IsTrue
		}, new float[] { 0f, 0f }, ConditionAttribute.VisibilityType.NotEditable)]
		public RootMotionRotationType rootMotionRotationType = RootMotionRotationType.AddRotation;

		private Vector3 startingPosition;

		private Vector3 targetPosition;

		private Quaternion startingRotation;

		private Quaternion targetRotation;

		private Coroutine postSimulationUpdateCoroutine;

		private AnimatorLink animatorLink;

		private bool wasInterpolatingActor;

		private bool internalResetFlag = true;

		private bool resetPositionFlag;

		private bool resetRotationFlag;

		public abstract RigidbodyComponent RigidbodyComponent { get; }

		public Animator Animator { get; private set; }

		public Vector3 Velocity
		{
			get
			{
				return RigidbodyComponent.Velocity;
			}
			set
			{
				RigidbodyComponent.Velocity = value;
			}
		}

		public Vector3 PlanarVelocity
		{
			get
			{
				return base.transform.TransformDirection(LocalPlanarVelocity);
			}
			set
			{
				LocalPlanarVelocity = base.transform.InverseTransformDirection(value);
			}
		}

		public Vector3 VerticalVelocity
		{
			get
			{
				return base.transform.TransformDirection(LocalVerticalVelocity);
			}
			set
			{
				LocalVerticalVelocity = base.transform.InverseTransformDirection(value);
			}
		}

		public Vector3 LocalVelocity
		{
			get
			{
				return base.transform.InverseTransformDirection(RigidbodyComponent.Velocity);
			}
			set
			{
				RigidbodyComponent.Velocity = base.transform.TransformDirection(value);
			}
		}

		public Vector3 LocalPlanarVelocity
		{
			get
			{
				Vector3 localVelocity = LocalVelocity;
				localVelocity.y = 0f;
				return localVelocity;
			}
			set
			{
				value.y = 0f;
				LocalVelocity = value + LocalVerticalVelocity;
			}
		}

		public Vector3 LocalVerticalVelocity
		{
			get
			{
				Vector3 localVelocity = LocalVelocity;
				localVelocity.x = (localVelocity.z = 0f);
				return localVelocity;
			}
			set
			{
				value.x = (value.z = 0f);
				LocalVelocity = LocalPlanarVelocity + value;
			}
		}

		public bool IsFalling => LocalVelocity.y < 0f;

		public bool IsAscending => LocalVelocity.y > 0f;

		public bool Is2D => RigidbodyComponent.Is2D;

		public Vector3 Position
		{
			get
			{
				return RigidbodyComponent.Position;
			}
			set
			{
				RigidbodyComponent.Position = value;
				targetPosition = value;
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return base.transform.rotation;
			}
			set
			{
				base.transform.rotation = value;
				targetRotation = value;
			}
		}

		public bool IsKinematic
		{
			get
			{
				return RigidbodyComponent.IsKinematic;
			}
			set
			{
				RigidbodyComponent.IsKinematic = value;
			}
		}

		public virtual Vector3 Up
		{
			get
			{
				return Rotation * Vector3.up;
			}
			set
			{
				Quaternion quaternion = Quaternion.FromToRotation(Up, value);
				Rotation = quaternion * Rotation;
			}
		}

		public virtual Vector3 Forward
		{
			get
			{
				if (!Is2D)
				{
					return Rotation * Vector3.forward;
				}
				return Rotation * Vector3.right;
			}
			set
			{
				Quaternion quaternion = Quaternion.FromToRotation(Forward, value);
				Rotation = quaternion * Rotation;
			}
		}

		public virtual Vector3 Right
		{
			get
			{
				if (!Is2D)
				{
					return Rotation * Vector3.right;
				}
				return Rotation * Vector3.forward;
			}
			set
			{
				Quaternion quaternion = Quaternion.FromToRotation(Right, value);
				Rotation = quaternion * Rotation;
			}
		}

		public event Action<float> OnPreSimulation;

		public event Action<float> OnPostSimulation;

		public event Action<Vector3, Quaternion> OnTeleport;

		public event Action OnAnimatorMoveEvent;

		public event Action<int> OnAnimatorIKEvent;

		public void Move(Vector3 position)
		{
			RigidbodyComponent.Move(position);
		}

		public void Teleport(Vector3 position)
		{
			Teleport(position, Rotation);
		}

		public void Teleport(Transform reference)
		{
			Teleport(reference.position, reference.rotation);
		}

		public void Teleport(Vector3 position, Quaternion rotation)
		{
			Position = position;
			Rotation = rotation;
			ResetInterpolationPosition();
			ResetInterpolationRotation();
			this.OnTeleport?.Invoke(Position, Rotation);
		}

		public virtual void SetRotation(Vector3 forward, Vector3 up)
		{
			Rotation = Quaternion.LookRotation(forward, up);
		}

		public virtual void RotateAround(Quaternion deltaRotation, Vector3 pivot)
		{
			Vector3 vector = pivot - Position;
			Rotation = deltaRotation * Rotation;
			Vector3 vector2 = deltaRotation * vector;
			Position += vector - vector2;
		}

		public virtual void SetYaw(Vector3 forward)
		{
			Rotation = Quaternion.AngleAxis(Vector3.SignedAngle(Forward, forward, Up), Up) * Rotation;
		}

		[Obsolete]
		public void SetYaw(float angle)
		{
			Rotation = Quaternion.AngleAxis(angle, Up) * Rotation;
		}

		public virtual void RotateYaw(float angle)
		{
			Rotation = Quaternion.AngleAxis(angle, Up) * Rotation;
		}

		public virtual void RotateYaw(float angle, Vector3 pivot)
		{
			Quaternion deltaRotation = Quaternion.AngleAxis(angle, Up);
			RotateAround(deltaRotation, pivot);
		}

		public virtual void RotatePitch(float angle)
		{
			Rotation = Quaternion.AngleAxis(angle, Right) * Rotation;
		}

		public virtual void RotatePitch(float angle, Vector3 pivot)
		{
			Quaternion deltaRotation = Quaternion.AngleAxis(angle, Right);
			RotateAround(deltaRotation, pivot);
		}

		public virtual void RotateRoll(float angle)
		{
			Rotation = Quaternion.AngleAxis(angle, Forward) * Rotation;
		}

		public virtual void RotateRoll(float angle, Vector3 pivot)
		{
			Quaternion deltaRotation = Quaternion.AngleAxis(angle, Forward);
			RotateAround(deltaRotation, pivot);
		}

		public virtual void TurnAround()
		{
			ResetInterpolationRotation();
			RotateYaw(180f);
		}

		public void InitializeAnimation()
		{
			Animator = GetComponentInChildren<Animator>(includeInactive: true);
			if (!(Animator == null))
			{
				Animator.updateMode = AnimatorUpdateMode.Fixed;
				if (!Animator.TryGetComponent<AnimatorLink>(out animatorLink))
				{
					animatorLink = Animator.gameObject.AddComponent<AnimatorLink>();
				}
			}
		}

		public void ResetIKWeights()
		{
			if (animatorLink != null)
			{
				animatorLink.ResetIKWeights();
			}
		}

		protected virtual void PreSimulationUpdate(float dt)
		{
		}

		protected virtual void PostSimulationUpdate(float dt)
		{
		}

		protected virtual void UpdateKinematicRootMotionPosition()
		{
			if (UpdateRootPosition)
			{
				Position += Animator.deltaPosition;
			}
		}

		protected virtual void UpdateKinematicRootMotionRotation()
		{
			if (UpdateRootRotation)
			{
				if (rootMotionRotationType == RootMotionRotationType.AddRotation)
				{
					Rotation *= Animator.deltaRotation;
				}
				else
				{
					Rotation = Animator.rootRotation;
				}
			}
		}

		protected virtual void UpdateDynamicRootMotionPosition()
		{
			if (UpdateRootPosition)
			{
				RigidbodyComponent.Move(Position + Animator.deltaPosition);
			}
		}

		protected virtual void UpdateDynamicRootMotionRotation()
		{
			if (UpdateRootRotation)
			{
				if (rootMotionRotationType == RootMotionRotationType.AddRotation)
				{
					Rotation *= Animator.deltaRotation;
				}
				else
				{
					Rotation = Animator.rootRotation;
				}
			}
		}

		private void PreSimulationRootMotionUpdate()
		{
			if (RigidbodyComponent.IsKinematic)
			{
				if (UpdateRootPosition)
				{
					UpdateKinematicRootMotionPosition();
				}
				if (UpdateRootRotation)
				{
					UpdateKinematicRootMotionRotation();
				}
			}
			else
			{
				if (UpdateRootPosition)
				{
					UpdateDynamicRootMotionPosition();
				}
				if (UpdateRootRotation)
				{
					UpdateDynamicRootMotionRotation();
				}
			}
		}

		private void OnAnimatorIKLinkMethod(int layerIndex)
		{
			this.OnAnimatorIKEvent?.Invoke(layerIndex);
		}

		public void SyncBody()
		{
			if (interpolateActor && wasInterpolatingActor)
			{
				Position = (startingPosition = targetPosition);
				Rotation = (startingRotation = targetRotation);
				if (internalResetFlag)
				{
					internalResetFlag = false;
					resetPositionFlag = false;
					resetRotationFlag = false;
				}
			}
		}

		public void InterpolateBody()
		{
			if (interpolateActor)
			{
				if (wasInterpolatingActor)
				{
					float t = (Time.time - Time.fixedTime) / Time.fixedDeltaTime;
					base.transform.SetPositionAndRotation(resetPositionFlag ? targetPosition : Vector3.Lerp(startingPosition, targetPosition, t), resetRotationFlag ? targetRotation : Quaternion.Slerp(startingRotation, targetRotation, t));
				}
				else
				{
					ResetInterpolationPosition();
					ResetInterpolationRotation();
				}
			}
		}

		public void UpdateInterpolationTargets()
		{
			if (interpolateActor)
			{
				targetPosition = Position;
				targetRotation = Rotation;
				if (resetPositionFlag)
				{
					startingPosition = targetPosition;
				}
				if (resetRotationFlag)
				{
					startingRotation = targetRotation;
				}
			}
		}

		public void ResetInterpolationPosition()
		{
			resetPositionFlag = true;
		}

		public void ResetInterpolationRotation()
		{
			resetRotationFlag = true;
		}

		public void ResetInterpolation()
		{
			ResetInterpolationPosition();
			ResetInterpolationRotation();
		}

		public bool IsAnimatorValid()
		{
			if (Animator == null)
			{
				return false;
			}
			if (Animator.runtimeAnimatorController == null)
			{
				return false;
			}
			if (!Animator.gameObject.activeSelf)
			{
				return false;
			}
			return true;
		}

		protected virtual void Awake()
		{
			base.gameObject.GetOrAddComponent<PhysicsActorSync>();
			InitializeAnimation();
		}

		protected virtual void OnEnable()
		{
			if (postSimulationUpdateCoroutine == null)
			{
				postSimulationUpdateCoroutine = StartCoroutine(PostSimulationUpdate());
			}
			if (animatorLink != null)
			{
				animatorLink.OnAnimatorMoveEvent += OnAnimatorMoveLinkMethod;
				animatorLink.OnAnimatorIKEvent += OnAnimatorIKLinkMethod;
			}
			startingPosition = (targetPosition = base.transform.position);
			startingRotation = (targetRotation = base.transform.rotation);
			ResetInterpolationPosition();
			ResetInterpolationRotation();
		}

		protected virtual void OnDisable()
		{
			if (postSimulationUpdateCoroutine != null)
			{
				StopCoroutine(postSimulationUpdateCoroutine);
				postSimulationUpdateCoroutine = null;
			}
			if (animatorLink != null)
			{
				animatorLink.OnAnimatorMoveEvent -= OnAnimatorMoveLinkMethod;
				animatorLink.OnAnimatorIKEvent -= OnAnimatorIKLinkMethod;
			}
		}

		protected virtual void Start()
		{
			RigidbodyComponent.ContinuousCollisionDetection = useContinuousCollisionDetection;
			RigidbodyComponent.UseInterpolation = false;
			targetPosition = (startingPosition = base.transform.position);
			targetRotation = (startingRotation = base.transform.rotation);
		}

		private void Update()
		{
			InterpolateBody();
			wasInterpolatingActor = interpolateActor;
			internalResetFlag = true;
		}

		private void OnAnimatorMoveLinkMethod()
		{
			if (!base.enabled || !UseRootMotion)
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			this.OnAnimatorMoveEvent?.Invoke();
			PreSimulationRootMotionUpdate();
			PreSimulationUpdate(deltaTime);
			this.OnPreSimulation?.Invoke(deltaTime);
			if (Is2D)
			{
				if (Right.z > 0f)
				{
					Right = Vector3.forward;
				}
				else
				{
					Right = Vector3.back;
				}
			}
			base.transform.SetPositionAndRotation(Position, Rotation);
		}

		private void FixedUpdate()
		{
			if (UseRootMotion)
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			PreSimulationUpdate(deltaTime);
			this.OnPreSimulation?.Invoke(deltaTime);
			if (Is2D)
			{
				if (Right.z > 0f)
				{
					Right = Vector3.forward;
				}
				else
				{
					Right = Vector3.back;
				}
			}
			base.transform.SetPositionAndRotation(Position, Rotation);
		}

		private IEnumerator PostSimulationUpdate()
		{
			YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
			while (true)
			{
				yield return waitForFixedUpdate;
				float deltaTime = Time.deltaTime;
				if (base.enabled)
				{
					PostSimulationUpdate(deltaTime);
					this.OnPostSimulation?.Invoke(deltaTime);
					UpdateInterpolationTargets();
				}
			}
		}
	}
}
