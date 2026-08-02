using System;
using System.Collections;
using System.Collections.Generic;
using FIMSpace.AnimationTools;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[Serializable]
	public class RagdollChainBone
	{
		public enum EColliderType
		{
			Capsule = 0,
			Sphere = 1,
			Box = 2,
			Mesh = 3,
			Other = 4
		}

		public enum ECapsuleDirection
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		[Serializable]
		public class ColliderSetup
		{
			public EColliderType ColliderType;

			public Vector3 ColliderCenter = Vector3.zero;

			public float ColliderSizeMultiply = 1f;

			public ECapsuleDirection CapsuleDirection = ECapsuleDirection.Y;

			public float ColliderRadius = 0.1f;

			public float ColliderLength = 0.3f;

			public Vector3 ColliderBoxSize = Vector3.one;

			public Mesh ColliderMesh;

			public Collider OtherReference;

			public Vector3 RotationCorrection = Vector3.zero;

			public Transform ColliderExtraTransform;

			[NonSerialized]
			public Collider GameCollider;

			[NonSerialized]
			public Collider GameColliderOnSource;

			[NonSerialized]
			public float BoundedIgnoreScale = 1f;

			public Quaternion RotationCorrectionQ => Quaternion.Euler(RotationCorrection);

			public bool UsingExtraTransform
			{
				get
				{
					if (!(RotationCorrection != Vector3.zero))
					{
						return ColliderType == EColliderType.Mesh;
					}
					return true;
				}
			}

			public Vector3 GetScaleModded(RagdollBonesChain chain, RagdollChainBone bone)
			{
				if (bone.SourceBone == null)
				{
					return Vector3.one * chain.GetScaleMultiplier();
				}
				return Vector3.Scale(bone.SourceBone.lossyScale, new Vector3(ColliderSizeMultiply, ColliderSizeMultiply, ColliderSizeMultiply)) * chain.GetScaleMultiplier();
			}

			public Vector3 ScaleUsingThickness(Vector3 scale, float thickness, RagdollBonesChain chain, RagdollChainBone bone)
			{
				if (thickness == 0f || thickness == 1f)
				{
					return scale;
				}
				int index = chain.GetIndex(bone);
				RagdollChainBone bone2;
				if (index == chain.BoneSetups.Count - 1)
				{
					bone2 = chain.GetBone(index - 1);
					if (bone == null)
					{
						return scale;
					}
				}
				else
				{
					bone2 = chain.GetBone(index + 1);
				}
				if (index >= 0 && bone2 != null && bone.SourceBone != null && bone2.SourceBone != null)
				{
					Vector3 direction = bone2.SourceBone.position - bone.SourceBone.position;
					direction = bone.SourceBone.InverseTransformDirection(direction).normalized;
					Vector3 b = FVectorMethods.ChooseDominantAxis(direction);
					if (b.x == 0f)
					{
						b.x = thickness;
					}
					else
					{
						b.x = 1f;
					}
					if (b.y == 0f)
					{
						b.y = thickness;
					}
					else
					{
						b.y = 1f;
					}
					if (b.z == 0f)
					{
						b.z = thickness;
					}
					else
					{
						b.z = 1f;
					}
					return Vector3.Scale(scale, b);
				}
				return scale;
			}

			public float GetAverageScale(RagdollChainBone bone, float chainMultiply = 1f)
			{
				float num = ColliderSizeMultiply * bone.SourceBone.lossyScale.x * chainMultiply;
				if (ColliderType == EColliderType.Capsule)
				{
					return num * (ColliderRadius * 2f * ColliderLength);
				}
				if (ColliderType == EColliderType.Sphere)
				{
					return num * (ColliderRadius * 2f);
				}
				if (ColliderType == EColliderType.Box)
				{
					return num * (ColliderRadius * 2f);
				}
				if (ColliderType == EColliderType.Mesh)
				{
					if (ColliderMesh != null)
					{
						return num * ColliderMesh.bounds.extents.magnitude;
					}
					if (ColliderType == EColliderType.Other && OtherReference != null)
					{
						return num * OtherReference.bounds.extents.magnitude;
					}
				}
				return num;
			}

			public Vector3 GetColliderSizeAxes()
			{
				if (ColliderType == EColliderType.Capsule)
				{
					return new Vector3(ColliderRadius, ColliderLength, ColliderRadius);
				}
				if (ColliderType == EColliderType.Sphere)
				{
					return new Vector3(ColliderRadius, ColliderRadius, ColliderRadius);
				}
				if (ColliderType == EColliderType.Box)
				{
					return ColliderBoxSize;
				}
				return new Vector3(ColliderSizeMultiply, ColliderSizeMultiply, ColliderSizeMultiply);
			}

			public Collider RefreshCollider(RagdollChainBone bone, bool fallMode, int colliderIndex, RagdollBonesChain chain, bool onSource)
			{
				Transform transform = (onSource ? bone.SourceBone : bone.PhysicalDummyBone);
				Collider collider = null;
				Transform transform2 = null;
				PhysicMaterial physicMaterial = bone.OverrideMaterial;
				if (physicMaterial == null && chain.ParentHandler != null && (bool)chain.ParentHandler.CollidersPhysicMaterial)
				{
					physicMaterial = ((!((bool)chain.ParentHandler.PhysicMaterialOnFall && fallMode)) ? chain.ParentHandler.CollidersPhysicMaterial : chain.ParentHandler.PhysicMaterialOnFall);
				}
				if (colliderIndex > 0)
				{
					string text = transform.name + ":[" + colliderIndex + "] RagdollCollider";
					transform2 = transform.Find(text);
					if (transform2 == null)
					{
						transform2 = RagdollHandler.CreateTransform(text, chain.ParentHandler.RagdollDummyLayer);
					}
					transform2.SetParent(transform, worldPositionStays: false);
					transform2.SetAsLastSibling();
					transform2.localRotation = RotationCorrectionQ;
					ColliderExtraTransform = transform2;
					transform = transform2;
				}
				else if (UsingExtraTransform)
				{
					string text2 = transform.name + ":RagdollCollider";
					transform2 = transform.Find(text2);
					if (transform2 == null)
					{
						transform2 = RagdollHandler.CreateTransform(text2, chain.ParentHandler.RagdollDummyLayer);
					}
					transform2.SetParent(transform, worldPositionStays: false);
					transform2.SetAsLastSibling();
					transform2.localRotation = RotationCorrectionQ;
					ColliderExtraTransform = transform2;
					transform = transform2;
				}
				else
				{
					transform2 = transform.Find(transform.name + ":RagdollCollider");
					if ((bool)transform2)
					{
						RagdollHandlerUtilities.DestroyObject(transform2.gameObject);
					}
				}
				float num = chain.ChainScaleMultiplier * ColliderSizeMultiply;
				float thicknessMultiplier = chain.GetThicknessMultiplier();
				if (chain.ParentHandler != null)
				{
					num *= chain.ParentHandler.RagdollSizeMultiplier;
				}
				if (ColliderType == EColliderType.Capsule)
				{
					DisposeWrongCollider(typeof(CapsuleCollider));
					CapsuleCollider orGenerate = bone.GetOrGenerate<CapsuleCollider>(transform);
					orGenerate.radius = ColliderRadius * num * thicknessMultiplier;
					orGenerate.height = ColliderLength * num;
					orGenerate.direction = (int)CapsuleDirection;
					orGenerate.center = ColliderCenter;
					collider = orGenerate;
				}
				else if (ColliderType == EColliderType.Sphere)
				{
					DisposeWrongCollider(typeof(SphereCollider));
					SphereCollider orGenerate2 = bone.GetOrGenerate<SphereCollider>(transform);
					orGenerate2.radius = ColliderRadius * num * thicknessMultiplier;
					orGenerate2.center = ColliderCenter;
					collider = orGenerate2;
				}
				else if (ColliderType == EColliderType.Box)
				{
					DisposeWrongCollider(typeof(BoxCollider));
					BoxCollider orGenerate3 = bone.GetOrGenerate<BoxCollider>(transform);
					orGenerate3.size = ScaleUsingThickness(ColliderBoxSize * num, thicknessMultiplier, chain, bone);
					orGenerate3.center = ColliderCenter;
					collider = orGenerate3;
				}
				else if (ColliderType == EColliderType.Mesh)
				{
					DisposeWrongCollider(typeof(MeshCollider));
					transform2.localPosition = ColliderCenter;
					transform2.localScale = ScaleUsingThickness(ColliderBoxSize * num, thicknessMultiplier, chain, bone);
					MeshCollider orGenerate4 = bone.GetOrGenerate<MeshCollider>(transform2);
					orGenerate4.sharedMesh = ColliderMesh;
					collider = orGenerate4;
				}
				else if (ColliderType == EColliderType.Other)
				{
					if (OtherReference != null)
					{
						DisposeWrongCollider(OtherReference.GetType());
						if ((bool)transform2)
						{
							transform2.localPosition = Vector3.zero;
							transform2.localScale = Vector3.one;
						}
						Collider collider2 = transform.gameObject.GetComponent(OtherReference.GetType()) as Collider;
						if (collider2 == null)
						{
							collider2 = transform.gameObject.AddComponent(OtherReference.GetType()) as Collider;
						}
						RagdollBonesChain.CopyColliderSettingTo(OtherReference, collider2);
						collider = collider2;
					}
					else
					{
						collider = null;
					}
				}
				if (onSource)
				{
					GameColliderOnSource = collider;
				}
				else
				{
					GameCollider = collider;
				}
				if (physicMaterial != null)
				{
					bone.ApplyPhysicMaterial(physicMaterial);
				}
				if ((bool)GameCollider && (bool)GameColliderOnSource)
				{
					Physics.IgnoreCollision(GameCollider, GameColliderOnSource, ignore: true);
				}
				return collider;
			}

			private void ProceedIgnore(Collider a, Collider b, bool ignore)
			{
				if (Physics.GetIgnoreCollision(a, b) != ignore)
				{
					Physics.IgnoreCollision(a, b, ignore);
				}
			}

			public void IgnoreCollisionWith(Collider coll, bool ignore)
			{
				if ((bool)GameCollider)
				{
					ProceedIgnore(coll, GameCollider, ignore);
				}
				if ((bool)GameColliderOnSource)
				{
					ProceedIgnore(coll, GameColliderOnSource, ignore);
				}
				if (ColliderType == EColliderType.Other && (bool)OtherReference)
				{
					ProceedIgnore(coll, OtherReference, ignore);
				}
			}

			public void IgnoreCollisionWith(ColliderSetup oColl, bool ignore)
			{
				if ((bool)oColl.GameCollider)
				{
					IgnoreCollisionWith(oColl.GameCollider, ignore);
				}
				if ((bool)oColl.GameColliderOnSource)
				{
					IgnoreCollisionWith(oColl.GameColliderOnSource, ignore);
				}
				if (oColl.ColliderType == EColliderType.Other && (bool)OtherReference)
				{
					IgnoreCollisionWith(oColl.OtherReference, ignore);
				}
			}

			private void DisposeWrongCollider(Type targetType)
			{
				if (!(GameCollider == null) && GameCollider.GetType() != targetType)
				{
					if (GameCollider is MeshCollider)
					{
						RagdollHandlerUtilities.DestroyObject(GameCollider.gameObject);
					}
					else
					{
						RagdollHandlerUtilities.DestroyObject(GameCollider);
					}
				}
			}

			public float Editor_GetHandleSize(RagdollChainBone bone)
			{
				if (bone.SourceBone == null)
				{
					return 0.1f;
				}
				float num = bone.SourceBone.lossyScale.x * ColliderSizeMultiply;
				if (ColliderType == EColliderType.Box)
				{
					return num * (ColliderBoxSize.magnitude * 0.25f);
				}
				if (ColliderType == EColliderType.Capsule)
				{
					return num * ((ColliderLength + ColliderRadius * 2f) * 0.15f);
				}
				if (ColliderType == EColliderType.Sphere)
				{
					return num * (ColliderRadius * 0.4f);
				}
				return num * 0.1f;
			}

			public void DisposeRuntimeObjects()
			{
				if ((bool)GameCollider)
				{
					RagdollHandlerUtilities.DestroyObject(GameCollider);
				}
				if ((bool)ColliderExtraTransform)
				{
					RagdollHandlerUtilities.DestroyObject(ColliderExtraTransform);
				}
			}

			public Vector3 CalculateLocalSize()
			{
				Vector3 result = default(Vector3);
				if (ColliderType == EColliderType.Box)
				{
					return ColliderBoxSize;
				}
				if (ColliderType == EColliderType.Capsule)
				{
					result = new Vector3(ColliderRadius, ColliderLength, ColliderRadius);
				}
				else if (ColliderType == EColliderType.Sphere)
				{
					result = new Vector3(ColliderRadius, ColliderRadius, ColliderRadius);
				}
				else if ((bool)GameCollider)
				{
					return GameCollider.bounds.size;
				}
				return result;
			}

			public Vector3 CalculateSize()
			{
				return Vector3.Scale(CalculateLocalSize(), GameCollider.transform.lossyScale);
			}

			public void CopySettingsFromColliderComponent(Collider collider)
			{
				if (collider is BoxCollider)
				{
					ColliderCenter = ((BoxCollider)collider).center;
					ColliderBoxSize = ((BoxCollider)collider).size;
				}
				else if (collider is SphereCollider)
				{
					ColliderCenter = ((SphereCollider)collider).center;
					ColliderRadius = ((SphereCollider)collider).radius;
				}
				else if (collider is CapsuleCollider)
				{
					ColliderCenter = ((CapsuleCollider)collider).center;
					ColliderRadius = ((CapsuleCollider)collider).radius;
					ColliderLength = ((CapsuleCollider)collider).height;
					CapsuleDirection = (ECapsuleDirection)((CapsuleCollider)collider).direction;
				}
				else if (collider is MeshCollider)
				{
					ColliderMesh = ((MeshCollider)collider).sharedMesh;
				}
			}

			public void CopySettingsFromOtherSetup(ColliderSetup copyFrom)
			{
				if (copyFrom != null)
				{
					ColliderType = copyFrom.ColliderType;
					ColliderCenter = copyFrom.ColliderCenter;
					ColliderSizeMultiply = copyFrom.ColliderSizeMultiply;
					CapsuleDirection = copyFrom.CapsuleDirection;
					ColliderRadius = copyFrom.ColliderRadius;
					ColliderLength = copyFrom.ColliderLength;
					ColliderBoxSize = copyFrom.ColliderBoxSize;
					ColliderMesh = copyFrom.ColliderMesh;
					OtherReference = copyFrom.OtherReference;
					RotationCorrection = copyFrom.RotationCorrection;
				}
			}
		}

		[Serializable]
		public class InBetweenBone
		{
			public Transform SourceBone;

			public Transform DummyBone;

			[SerializeField]
			private Quaternion initLocalRotation;

			[SerializeField]
			private Quaternion animatorLocalRotation;

			internal Rigidbody rigidbody;

			internal FixedJoint FixedJoint;

			public Quaternion InitLocalRotation => initLocalRotation;

			internal void Initialize()
			{
				initLocalRotation = SourceBone.localRotation;
				animatorLocalRotation = initLocalRotation;
			}

			internal void AssignParent(Transform setParentIfNoParent)
			{
				if (!(DummyBone.parent != null))
				{
					DummyBone.SetParent(setParentIfNoParent, worldPositionStays: true);
					Initialize();
				}
			}

			internal void Calibrate()
			{
				SourceBone.localRotation = initLocalRotation;
			}

			internal void CaptureAnimator()
			{
				animatorLocalRotation = SourceBone.localRotation;
			}

			public void SyncWithAnimator()
			{
				DummyBone.localRotation = animatorLocalRotation;
			}

			internal Rigidbody GenerateRigidbody()
			{
				if ((bool)rigidbody)
				{
					return rigidbody;
				}
				rigidbody = DummyBone.gameObject.AddComponent<Rigidbody>();
				rigidbody.isKinematic = true;
				rigidbody.useGravity = false;
				return rigidbody;
			}

			internal void DestroyPhysicalComponents()
			{
				if ((bool)FixedJoint)
				{
					RagdollHandlerUtilities.DestroyObject(FixedJoint);
				}
				if ((bool)rigidbody)
				{
					RagdollHandlerUtilities.DestroyObject(rigidbody);
				}
			}
		}

		[Serializable]
		public struct ReferencePoseCoordinates
		{
			public Vector3 LocalSpacePosition;

			public Quaternion LocalSpaceRotation;

			public Vector3 RootSpacePosition;

			public Quaternion RootSpaceRotation;
		}

		public Transform SourceBone;

		public Transform PhysicalDummyBone;

		[NonSerialized]
		public Transform DetachParent;

		internal bool IsAnchor;

		internal int SourceBoneDepth = -1;

		internal bool BypassKinematicControl;

		[HideInInspector]
		public float BoundedIgnoreScale = 1f;

		[NonSerialized]
		public bool WasDismembered;

		[NonSerialized]
		public bool ParentDismembered;

		[Tooltip("Helper indicator value, which can be used for custom scripts hit bone indication")]
		public ERagdollBoneID BoneID = ERagdollBoneID.Unknown;

		[SerializeField]
		[HideInInspector]
		private List<ColliderSetup> colliders = new List<ColliderSetup>
		{
			new ColliderSetup()
		};

		[Tooltip("Multiplying target collider rigidbody mass. It's using the 'Max Mass' ragdoll value + Chain Mass Multiplier.")]
		[Range(0f, 1f)]
		public float MassMultiplier = 0.1f;

		[Tooltip("Controlling power of ragdoll physical forces for a single bone")]
		public float ForceMultiplier = 1f;

		[Tooltip("Extra power added to the bones joints springs with use of less sensitive calculations. Can be helpful for adjusting spine springs. ")]
		public float MusclesBoost;

		[Tooltip("First rotation axis for the Unity Physical Joint component")]
		public EJointAxis MainAxis;

		public Vector3 TargetMainAxis = Vector3.right;

		public bool InverseMainAxis;

		[Tooltip("Low Twist or lowAngularXLimit : -177 : 177 : Needs to be lower than High Twist Limit")]
		[Range(-177f, 177f)]
		public float MainAxisLowLimit = -60f;

		[Tooltip("HighTwist or highAngularXLimit : -177 : 177")]
		[Range(-177f, 177f)]
		public float MainAxisHighLimit = 60f;

		[Tooltip("Secondary rotation axis for the Unity Physical Joint component")]
		public EJointAxis SecondaryAxis = EJointAxis.Y;

		public Vector3 TargetSecondaryAxis = Vector3.up;

		public bool InverseSecondaryAxis;

		[Tooltip("Secondary axis angle limit plus-minus 3 : 177 degrees")]
		[Range(3f, 177f)]
		public float SecondaryAxisAngleLimit = 30f;

		[Tooltip("Last axis angle limit plus-minus 3 : 177 degrees")]
		[Range(3f, 177f)]
		public float ThirdAxisAngleLimit = 40f;

		public PhysicMaterial OverrideMaterial;

		public bool UseIndividualParameters;

		[Tooltip("Override rigidbody interpolation mode.")]
		public RigidbodyInterpolation OverrideInterpolation = RigidbodyInterpolation.Interpolate;

		[Tooltip("Override rigidbody collision detection mode.")]
		public CollisionDetectionMode OverrideDetectionMode;

		[Tooltip("Override Drag Parameter value for rigidbody")]
		public float OverrideDragValue;

		[Tooltip("Override Angular Drag Parameter value for rigidbody")]
		public float OverrideAngularDrag = 0.2f;

		[Tooltip("Set greater than zero, to override bone's joint animation matching spring power")]
		public float OverrideSpringPower;

		[Tooltip("Set greater than zero, to override bone's joint animation matching damping parameter")]
		public float OverrideSpringDamp;

		[Range(0f, 1f)]
		public float HardMatchingMultiply = 1f;

		[Range(0f, 1f)]
		public float HardMatchOverride;

		[Range(0f, 1.5f)]
		public float ConnectionMassOverride;

		[Tooltip("Set true if you want to skip this bone in collision detection send events.")]
		public bool DisableCollisionEvents;

		[Tooltip("Set true if you want to use joint limits all the time.")]
		public bool ForceLimitsAllTheTime;

		[Tooltip("Setting bone kinematic during standing mode to make it better in sync with currently played animation")]
		public bool ForceKinematicOnStanding;

		private bool _wasForceKinematicOnStanding;

		[Tooltip("Setting configurable motion lock to limited to 0.000001f translation value : you can use linear spring limits now")]
		public bool AllowConfigurablePosition;

		public float LinearSpringLimit = 10000f;

		public float LinearSpringDamping = 5f;

		[Tooltip("Selective bone ragdoll blend multiplier")]
		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		public float BoneBlendMultiplier = 1f;

		public Vector3 LocalRight = Vector3.right;

		public Vector3 LocalUp = Vector3.up;

		public Vector3 LocalForward = Vector3.forward;

		public Vector3 ToBase = Vector3.zero;

		public ReferencePoseCoordinates StoredReferencePose;

		[NonSerialized]
		public float OverrideBlend;

		private Coroutine _forceBlendCoro;

		private float _forceBlendStartOverr;

		private bool wasPhysicsDisabled;

		private bool kinematicOnDisabled;

		[field: NonSerialized]
		public RagdollBonesChain ParentChain { get; private set; }

		[field: NonSerialized]
		public RagdollChainBone ParentBone { get; private set; }

		public RagdollBoneProcessor BoneProcessor { get; private set; }

		public RagdollBoneProcessor Posing => BoneProcessor;

		public Rigidbody InitialConnectedBody { get; internal set; }

		public Vector3 InitialJointAnchor { get; private set; } = Vector3.zero;

		public bool PlaymodeInitialized { get; private set; }

		public Rigidbody GameRigidbody { get; private set; }

		public Collider MainBoneCollider => BaseColliderSetup.GameCollider;

		public ConfigurableJoint Joint { get; private set; }

		public List<ColliderSetup> Colliders => colliders;

		public ColliderSetup BaseColliderSetup => colliders[0];

		public List<InBetweenBone> InBetweenBones { get; private set; }

		public bool UsingExtraTransform
		{
			get
			{
				bool result = false;
				foreach (ColliderSetup collider in colliders)
				{
					if (collider.UsingExtraTransform)
					{
						result = true;
						break;
					}
				}
				return result;
			}
		}

		public float TargetConnectedMassScale { get; private set; } = 1f;

		public void GenerateDummyBone(Transform transform)
		{
			if (!(PhysicalDummyBone != null))
			{
				PhysicalDummyBone = transform;
			}
		}

		public void PlaymodeInitialize(RagdollBonesChain parentChain)
		{
			if (!PlaymodeInitialized)
			{
				ParentChain = parentChain;
				BoneProcessor = new RagdollBoneProcessor(this);
				PlaymodeInitialized = true;
				if ((bool)SourceBone)
				{
					SourceBoneDepth = SkeletonRecognize.SkeletonInfo.GetDepth(SourceBone, parentChain.ParentHandler.GetBaseTransform());
				}
			}
		}

		public void ApplyToAllColliders(Action<Collider> action)
		{
			foreach (ColliderSetup collider in colliders)
			{
				if ((bool)collider.GameCollider)
				{
					action(collider.GameCollider);
				}
			}
		}

		public void SwitchOffJointAnimationMatching()
		{
			JointDrive slerpDrive = Joint.slerpDrive;
			slerpDrive.positionSpring = 0f;
			slerpDrive.positionDamper = 0f;
			Joint.slerpDrive = slerpDrive;
			HardMatchingMultiply = 0f;
			Joint_SetAngularMotionLock(ConfigurableJointMotion.Limited);
		}

		public ColliderSetup AddColliderSetup()
		{
			ColliderSetup colliderSetup = new ColliderSetup();
			ColliderSetup copyFrom = null;
			if (colliders.Count > 0)
			{
				copyFrom = colliders[colliders.Count - 1];
			}
			colliders.Add(colliderSetup);
			colliderSetup.CopySettingsFromOtherSetup(copyFrom);
			return colliderSetup;
		}

		public void RemoveColliderSetup(int indexToRemove)
		{
			if (indexToRemove != 0 && colliders.ContainsIndex(indexToRemove, true))
			{
				colliders[indexToRemove].DisposeRuntimeObjects();
				colliders.RemoveAt(indexToRemove);
			}
		}

		public ColliderSetup GetColliderSetup(int index)
		{
			if (colliders.ContainsIndex(index, true))
			{
				return colliders[index];
			}
			return null;
		}

		public Matrix4x4 GetMatrix(Vector3 centerOffset, Vector3 scale, Quaternion correctionRot)
		{
			if (SourceBone == null)
			{
				return Matrix4x4.identity;
			}
			return Matrix4x4.TRS(SourceBone.TransformPoint(centerOffset), SourceBone.rotation * correctionRot, scale);
		}

		public Vector3 GetMainAxis()
		{
			if (MainAxis == EJointAxis.X)
			{
				return InverseMainAxis ? Vector3.left : Vector3.right;
			}
			if (MainAxis == EJointAxis.Y)
			{
				return InverseMainAxis ? Vector3.down : Vector3.up;
			}
			if (MainAxis == EJointAxis.Z)
			{
				return InverseMainAxis ? Vector3.back : Vector3.forward;
			}
			return TargetMainAxis.normalized;
		}

		public void SetMainAxisByVector(Vector3 dir)
		{
			dir.Normalize();
			dir = FVectorMethods.ChooseDominantAxis(dir);
			if (dir.x > 0.3f)
			{
				InverseMainAxis = false;
				MainAxis = EJointAxis.X;
			}
			else if (dir.x < -0.3f)
			{
				InverseMainAxis = true;
				MainAxis = EJointAxis.X;
			}
			else if (dir.y > 0.3f)
			{
				InverseMainAxis = false;
				MainAxis = EJointAxis.Y;
			}
			else if (dir.y < -0.3f)
			{
				InverseMainAxis = true;
				MainAxis = EJointAxis.Y;
			}
			else if (dir.z > 0.3f)
			{
				InverseMainAxis = false;
				MainAxis = EJointAxis.Z;
			}
			else if (dir.z < -0.3f)
			{
				InverseMainAxis = true;
				MainAxis = EJointAxis.Z;
			}
		}

		public void SetSecondaryAxisByVector(Vector3 dir)
		{
			dir.Normalize();
			dir = FVectorMethods.ChooseDominantAxis(dir);
			if (dir.x > 0.3f)
			{
				InverseSecondaryAxis = false;
				SecondaryAxis = EJointAxis.X;
			}
			else if (dir.x < -0.3f)
			{
				InverseSecondaryAxis = true;
				SecondaryAxis = EJointAxis.X;
			}
			else if (dir.y > 0.3f)
			{
				InverseSecondaryAxis = false;
				SecondaryAxis = EJointAxis.Y;
			}
			else if (dir.y < -0.3f)
			{
				InverseSecondaryAxis = true;
				SecondaryAxis = EJointAxis.Y;
			}
			else if (dir.z > 0.3f)
			{
				InverseSecondaryAxis = false;
				SecondaryAxis = EJointAxis.Z;
			}
			else if (dir.z < -0.3f)
			{
				InverseSecondaryAxis = true;
				SecondaryAxis = EJointAxis.Z;
			}
		}

		public float GetMainAxisLowLimit(RagdollBonesChain chain)
		{
			return MainAxisLowLimit * chain.AxisLimitRange;
		}

		public float GetMainAxisHighLimit(RagdollBonesChain chain)
		{
			return MainAxisHighLimit * chain.AxisLimitRange;
		}

		public Vector3 GetSecondaryAxis()
		{
			if (SecondaryAxis == EJointAxis.X)
			{
				return InverseSecondaryAxis ? Vector3.left : Vector3.right;
			}
			if (SecondaryAxis == EJointAxis.Y)
			{
				return InverseSecondaryAxis ? Vector3.down : Vector3.up;
			}
			if (SecondaryAxis == EJointAxis.Z)
			{
				return InverseSecondaryAxis ? Vector3.back : Vector3.forward;
			}
			return TargetSecondaryAxis.normalized;
		}

		public float GetSecondaryAxisAngleLimit(RagdollBonesChain chain)
		{
			return SecondaryAxisAngleLimit * chain.AxisLimitRange;
		}

		public float GetThirdAxisAngleLimit(RagdollBonesChain chain)
		{
			return ThirdAxisAngleLimit * chain.AxisLimitRange;
		}

		public Vector3 GetThirdAxis()
		{
			return Vector3.Cross(GetMainAxis(), GetSecondaryAxis());
		}

		public float GetMass(RagdollBonesChain chain)
		{
			if (chain.ParentHandler == null)
			{
				return 1f;
			}
			return chain.ParentHandler.ReferenceMass * chain.MassMultiplier * MassMultiplier;
		}

		public void DoAutoMassSettings(RagdollHandler handler, RagdollBonesChain chain)
		{
			int num = -1;
			for (int i = 0; i < chain.BoneSetups.Count; i++)
			{
				if (chain.BoneSetups[i] == this)
				{
					num = i;
				}
			}
			if (num != -1)
			{
				MassMultiplier = chain.GetBoneMassPercentage(num, chain.GetChainTypePercentageMass() * 0.01f) * 0.01f;
			}
		}

		public float GetRigidbodyDrag(RagdollBonesChain chain)
		{
			return chain.ParentHandler.RigidbodyDragValue;
		}

		public float GetRigidbodyAngularDrag(RagdollBonesChain chain)
		{
			return chain.ParentHandler.RigidbodyAngularDragValue;
		}

		public float GetMainAxisLimitContactDistance(RagdollBonesChain chain)
		{
			return chain.ParentHandler.JointContactDistance;
		}

		public float GetMainAxisLimitBounciness(RagdollBonesChain chain)
		{
			return chain.ParentHandler.JointBounciness;
		}

		public float GetMainAxisLimitSpring(RagdollBonesChain chain)
		{
			return chain.ParentHandler.JointLimitSpring;
		}

		public float GetMainAxisLimitDamper(RagdollBonesChain chain)
		{
			return chain.ParentHandler.JointLimitDamper;
		}

		public float GetOtherAxesLimitSpring(RagdollBonesChain chain)
		{
			return chain.ParentHandler.JointLimitSpring;
		}

		public float GetOtherAxesLimitDamper(RagdollBonesChain chain)
		{
			return chain.ParentHandler.JointLimitDamper;
		}

		public void StoreHelperReferenceValues(Transform baseTransform)
		{
			LocalRight = SourceBone.InverseTransformDirection(baseTransform.right);
			LocalUp = SourceBone.InverseTransformDirection(baseTransform.up);
			LocalForward = SourceBone.InverseTransformDirection(baseTransform.forward);
			ToBase = SourceBone.InverseTransformPoint(baseTransform.position);
		}

		public void SetInBetweenBones(List<InBetweenBone> inBetweenBones)
		{
			InBetweenBones = inBetweenBones;
		}

		public Rigidbody RefreshRigidbody(RagdollHandler handler, RagdollBonesChain chain, bool onSource)
		{
			Transform transform = (onSource ? SourceBone : PhysicalDummyBone);
			Rigidbody rigidbody = (GameRigidbody = ((GameRigidbody == null) ? GetOrGenerate<Rigidbody>(transform) : GameRigidbody));
			if (handler.MaxAngularVelocity > 0f)
			{
				rigidbody.maxAngularVelocity = handler.MaxAngularVelocity;
			}
			if (handler.MaxVelocity > 0f)
			{
				rigidbody.SetMaxLinearVelocityU2022(handler.MaxVelocity);
			}
			if (handler.MaxDepenetrationVelocity > 0f)
			{
				rigidbody.maxDepenetrationVelocity = handler.MaxDepenetrationVelocity;
			}
			rigidbody.mass = GetMass(chain);
			if (UseIndividualParameters)
			{
				rigidbody.interpolation = OverrideInterpolation;
				rigidbody.collisionDetectionMode = OverrideDetectionMode;
				rigidbody.drag = OverrideDragValue;
				rigidbody.angularDrag = OverrideAngularDrag;
				RefreshSolversCount(handler);
			}
			else
			{
				RefreshRigidbodyOptimizationParameters(handler);
				rigidbody.drag = GetRigidbodyDrag(chain);
				rigidbody.angularDrag = GetRigidbodyAngularDrag(chain);
			}
			return rigidbody;
		}

		public void RefreshRigidbodyOptimizationParameters(RagdollHandler handler)
		{
			RefreshSolversCount(handler);
			if (handler.disableInterpolation)
			{
				GameRigidbody.interpolation = RigidbodyInterpolation.None;
			}
			else
			{
				GameRigidbody.interpolation = handler.RigidbodiesInterpolation;
			}
			if (handler.onlyDiscreteDetection)
			{
				GameRigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
			}
			else
			{
				GameRigidbody.collisionDetectionMode = handler.RigidbodiesDetectionMode;
			}
		}

		private void RefreshSolversCount(RagdollHandler handler)
		{
			GameRigidbody.solverIterations = handler.UnitySolverIterations;
			if (handler.UnityVelocitySolverIterations < 1)
			{
				GameRigidbody.solverVelocityIterations = Physics.defaultSolverVelocityIterations;
			}
			else
			{
				GameRigidbody.solverVelocityIterations = handler.UnityVelocitySolverIterations;
			}
		}

		protected void RefreshRigidbodyInterpolation(RagdollHandler handler)
		{
			if (UseIndividualParameters)
			{
				GameRigidbody.interpolation = OverrideInterpolation;
			}
			else
			{
				GameRigidbody.interpolation = handler.RigidbodiesInterpolation;
			}
		}

		public void ApplyPhysicMaterial(PhysicMaterial pMaterial)
		{
			ApplyToAllColliders(delegate(Collider c)
			{
				c.sharedMaterial = pMaterial;
			});
		}

		public void RefreshCollider(RagdollBonesChain chain, bool fallMode, bool onSource)
		{
			for (int i = 0; i < colliders.Count; i++)
			{
				colliders[i].RefreshCollider(this, fallMode, i, chain, onSource);
			}
		}

		private T GetOrGenerate<T>(Transform from) where T : Component
		{
			T val = from.GetComponent<T>();
			if (val == null)
			{
				val = from.gameObject.AddComponent<T>();
			}
			return val;
		}

		public ConfigurableJoint RefreshJoint(RagdollBonesChain chain, bool fallMode, bool onSource, bool playmodeRefresh, bool applyConnectedMassScale)
		{
			Transform transform = (onSource ? SourceBone : PhysicalDummyBone);
			ConfigurableJoint configurableJoint = Joint;
			if (configurableJoint == null)
			{
				configurableJoint = transform.GetComponent<ConfigurableJoint>();
				if (configurableJoint == null)
				{
					configurableJoint = transform.gameObject.AddComponent<ConfigurableJoint>();
				}
				configurableJoint.rotationDriveMode = RotationDriveMode.Slerp;
			}
			Joint = configurableJoint;
			if (!playmodeRefresh)
			{
				configurableJoint.axis = GetMainAxis();
				configurableJoint.secondaryAxis = GetSecondaryAxis();
			}
			if (!WasDismembered)
			{
				RefreshJointLimitSwitch(chain);
			}
			Joint_UpdateAngleLimits(chain);
			Joint_UpdateAngularSpringLimits(chain);
			RefreshDynamicPhysicalParameters(chain, fallMode, applyConnectedMassScale);
			configurableJoint.enableCollision = false;
			configurableJoint.enablePreprocessing = chain.ParentHandler.PreProcessing;
			configurableJoint.projectionMode = chain.ParentHandler.ProjectionMode;
			return configurableJoint;
		}

		public void RefreshJointLimitSwitch(RagdollBonesChain parentChain)
		{
			if (IsAnchor)
			{
				Joint_SetMotionLock(ConfigurableJointMotion.Free);
				Joint_SetAngularMotionLock(ConfigurableJointMotion.Free);
				return;
			}
			if (AllowConfigurablePosition)
			{
				Joint_SetMotionLock(ConfigurableJointMotion.Limited);
				SoftJointLimit linearLimit = Joint.linearLimit;
				linearLimit.limit = 1E-05f;
				Joint.linearLimit = linearLimit;
				SoftJointLimitSpring linearLimitSpring = Joint.linearLimitSpring;
				linearLimitSpring.spring = LinearSpringLimit;
				linearLimitSpring.damper = LinearSpringDamping;
				Joint.linearLimitSpring = linearLimitSpring;
			}
			else
			{
				Joint_SetMotionLock(ConfigurableJointMotion.Locked);
			}
			if (ForceLimitsAllTheTime)
			{
				Joint_SetAngularMotionLock(ConfigurableJointMotion.Limited);
				return;
			}
			bool flag = parentChain.UnlimitedRotations;
			if (!flag)
			{
				flag = parentChain.ParentHandler.UnlimitedRotationOnStandingModeCheck();
			}
			Joint_SetAngularMotionLock((!flag) ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Free);
		}

		public void RefreshDynamicPhysicalParameters(RagdollBonesChain chain, bool fallMode, bool applyConnectedMassScale)
		{
			float fadeInBlend = chain.ParentHandler.FadeInBlend;
			if (ConnectionMassOverride > 0f)
			{
				TargetConnectedMassScale = ConnectionMassOverride * fadeInBlend;
				if (applyConnectedMassScale)
				{
					Joint.connectedMassScale = TargetConnectedMassScale;
				}
				return;
			}
			if (fallMode)
			{
				if ((bool)Joint)
				{
					if (chain.ConnectedMassOverride)
					{
						TargetConnectedMassScale = chain.ConnectedMassScale;
						if (applyConnectedMassScale)
						{
							Joint.connectedMassScale = TargetConnectedMassScale;
						}
					}
					else
					{
						TargetConnectedMassScale = chain.ConnectedMassScale * chain.ParentHandler.MassMultiplyOnFalling * fadeInBlend;
						if (applyConnectedMassScale)
						{
							Joint.connectedMassScale = TargetConnectedMassScale;
						}
					}
				}
				if (chain.ParentHandler.NoGravityOnStanding)
				{
					GameRigidbody.useGravity = true;
				}
			}
			else
			{
				if ((bool)Joint)
				{
					if (chain.ConnectedMassOverride)
					{
						TargetConnectedMassScale = chain.ConnectedMassScale;
						if (applyConnectedMassScale)
						{
							Joint.connectedMassScale = TargetConnectedMassScale;
						}
					}
					else
					{
						TargetConnectedMassScale = chain.ConnectedMassScale * chain.ParentHandler.ConnectedMassMultiply * fadeInBlend;
						if (applyConnectedMassScale)
						{
							Joint.connectedMassScale = TargetConnectedMassScale;
						}
					}
				}
				if (chain.ParentHandler.NoGravityOnStanding)
				{
					GameRigidbody.useGravity = false;
				}
			}
			if (ForceKinematicOnStanding)
			{
				if (chain.ParentHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
				{
					if (chain.ParentHandler.Caller == null || Time.unscaledTime - chain.ParentHandler.LastStandingModeAtTime > 0.1f)
					{
						SwitchIsKinematic(kinematic: true);
					}
					else
					{
						chain.ParentHandler.Caller.StartCoroutine(chain.ParentHandler._IE_CallAfter(0f, delegate
						{
							if (chain.ParentHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
							{
								SwitchIsKinematic(kinematic: true);
							}
						}, Mathf.RoundToInt(Mathf.Max(1f, 0.15f / Time.fixedDeltaTime))));
					}
					_wasForceKinematicOnStanding = true;
				}
				else
				{
					SwitchIsKinematic(kinematic: false);
					RefreshRigidbodyInterpolation(chain.ParentHandler);
					_wasForceKinematicOnStanding = true;
				}
			}
			else if (_wasForceKinematicOnStanding)
			{
				SwitchIsKinematic(kinematic: false);
				RefreshRigidbodyInterpolation(chain.ParentHandler);
				_wasForceKinematicOnStanding = false;
			}
		}

		private void SwitchIsKinematic(bool kinematic)
		{
			if (!BypassKinematicControl)
			{
				RagdollHandlerUtilities.SwitchKinematic(GameRigidbody, !kinematic);
			}
		}

		public void ConfigureJointAnchors()
		{
			if (!(Joint.connectedBody == null))
			{
				Joint.autoConfigureConnectedAnchor = false;
				Transform physicalDummyBone;
				if (ParentBone != null)
				{
					physicalDummyBone = ParentBone.PhysicalDummyBone;
				}
				else
				{
					ParentBone = ParentChain.ConnectionBone;
					physicalDummyBone = ParentChain.ConnectionBone.PhysicalDummyBone;
				}
				if (InitialJointAnchor == Vector3.zero)
				{
					InitialJointAnchor = Joint.connectedBody.transform.InverseTransformPoint(PhysicalDummyBone.position);
				}
				Vector3 position = physicalDummyBone.TransformPoint(InitialJointAnchor);
				Vector3 connectedAnchor = Joint.connectedBody.transform.InverseTransformPoint(position);
				Joint.connectedAnchor = connectedAnchor;
			}
		}

		private void Joint_UpdateAngleLimits(RagdollBonesChain chain)
		{
			if (!(Joint == null))
			{
				SoftJointLimit lowAngularXLimit = Joint.lowAngularXLimit;
				lowAngularXLimit.limit = GetMainAxisLowLimit(chain);
				lowAngularXLimit.contactDistance = GetMainAxisLimitContactDistance(chain);
				lowAngularXLimit.bounciness = GetMainAxisLimitBounciness(chain);
				Joint.lowAngularXLimit = lowAngularXLimit;
				lowAngularXLimit = Joint.highAngularXLimit;
				lowAngularXLimit.limit = GetMainAxisHighLimit(chain);
				lowAngularXLimit.contactDistance = GetMainAxisLimitContactDistance(chain);
				lowAngularXLimit.bounciness = GetMainAxisLimitBounciness(chain);
				Joint.highAngularXLimit = lowAngularXLimit;
				lowAngularXLimit = Joint.angularYLimit;
				lowAngularXLimit.limit = GetSecondaryAxisAngleLimit(chain);
				lowAngularXLimit.contactDistance = GetMainAxisLimitContactDistance(chain);
				lowAngularXLimit.bounciness = GetMainAxisLimitBounciness(chain);
				Joint.angularYLimit = lowAngularXLimit;
				lowAngularXLimit = Joint.angularZLimit;
				lowAngularXLimit.limit = GetThirdAxisAngleLimit(chain);
				lowAngularXLimit.contactDistance = GetMainAxisLimitContactDistance(chain);
				lowAngularXLimit.bounciness = GetMainAxisLimitBounciness(chain);
				Joint.angularZLimit = lowAngularXLimit;
			}
		}

		private void Joint_UpdateAngularSpringLimits(RagdollBonesChain chain)
		{
			if (!(Joint == null))
			{
				float mainAxisLimitSpring = GetMainAxisLimitSpring(chain);
				float mainAxisLimitDamper = GetMainAxisLimitDamper(chain);
				SoftJointLimitSpring angularXLimitSpring = Joint.angularXLimitSpring;
				angularXLimitSpring.spring = mainAxisLimitSpring;
				angularXLimitSpring.damper = mainAxisLimitDamper;
				Joint.angularXLimitSpring = angularXLimitSpring;
				angularXLimitSpring = Joint.angularYZLimitSpring;
				angularXLimitSpring.spring = mainAxisLimitSpring;
				angularXLimitSpring.damper = mainAxisLimitDamper;
				Joint.angularYZLimitSpring = angularXLimitSpring;
			}
		}

		public void Joint_SetMotionLock(ConfigurableJointMotion mode)
		{
			if (!(Joint == null))
			{
				Joint.xMotion = mode;
				Joint.yMotion = mode;
				Joint.zMotion = mode;
			}
		}

		public void Joint_SetAngularMotionLock(ConfigurableJointMotion mode)
		{
			if (!(Joint == null))
			{
				Joint.angularXMotion = mode;
				Joint.angularYMotion = mode;
				Joint.angularZMotion = mode;
			}
		}

		public void Joint_SetPositionLimit(float limitValue)
		{
			if (!(Joint == null))
			{
				SoftJointLimit linearLimit = Joint.linearLimit;
				linearLimit.limit = limitValue;
				Joint.linearLimit = linearLimit;
			}
		}

		public void SetJointMatchingParameters(float spring, float dampingValue)
		{
			if (Joint == null)
			{
				return;
			}
			if (OverrideSpringPower > 0f)
			{
				spring = OverrideSpringPower;
			}
			if (OverrideSpringDamp > 0f)
			{
				dampingValue = OverrideSpringDamp;
			}
			JointDrive angularXDrive = Joint.angularXDrive;
			if (angularXDrive.positionSpring != spring || angularXDrive.positionDamper != dampingValue)
			{
				if (spring <= 0f)
				{
					angularXDrive.positionSpring = 0f;
					angularXDrive.positionDamper = 0f;
				}
				else
				{
					angularXDrive.positionSpring = spring;
					angularXDrive.positionDamper = dampingValue;
				}
				Joint.slerpDrive = angularXDrive;
			}
		}

		public void SetJointMatchingParametersPosition(float spring, float dampingValue)
		{
			JointDrive xDrive = Joint.xDrive;
			xDrive.positionSpring = spring;
			xDrive.positionDamper = dampingValue;
			Joint.xDrive = xDrive;
			Joint.yDrive = xDrive;
			Joint.zDrive = xDrive;
		}

		public void SetZeroDrive()
		{
			JointDrive angularXDrive = Joint.angularXDrive;
			angularXDrive.positionSpring = 0f;
			angularXDrive.positionDamper = 0f;
			Joint.slerpDrive = angularXDrive;
			JointDrive xDrive = Joint.xDrive;
			xDrive.positionSpring = 0f;
			xDrive.positionDamper = 0f;
			Joint.xDrive = xDrive;
			Joint.yDrive = xDrive;
			Joint.zDrive = xDrive;
		}

		public void SetJointMatchingMaximumForce(float maximumForce)
		{
			JointDrive angularXDrive = Joint.angularXDrive;
			angularXDrive.maximumForce = maximumForce;
			Joint.slerpDrive = angularXDrive;
		}

		public void TryIdentifyBoneID(RagdollBonesChain chain, bool changeOnlyIfUnknown = false)
		{
			if (changeOnlyIfUnknown && BoneID != ERagdollBoneID.Unknown)
			{
				return;
			}
			if (chain.ParentHandler != null)
			{
				Animator mecanim = chain.ParentHandler.Mecanim;
				if ((bool)mecanim && mecanim.isHuman)
				{
					foreach (object value in Enum.GetValues(typeof(HumanBodyBones)))
					{
						if ((int)value >= 0)
						{
							HumanBodyBones humanBodyBones = (HumanBodyBones)value;
							if (SourceBone == mecanim.GetBoneTransform(humanBodyBones))
							{
								BoneID = (ERagdollBoneID)humanBodyBones;
								return;
							}
						}
					}
				}
			}
			int index = chain.GetIndex(this);
			if (chain.ChainType == ERagdollChainType.LeftLeg)
			{
				switch (index)
				{
				case 0:
					BoneID = ERagdollBoneID.LeftUpperLeg;
					break;
				case 1:
					BoneID = ERagdollBoneID.LeftLowerLeg;
					break;
				default:
					BoneID = ERagdollBoneID.LeftFoot;
					break;
				}
			}
			else if (chain.ChainType == ERagdollChainType.RightLeg)
			{
				switch (index)
				{
				case 0:
					BoneID = ERagdollBoneID.RightUpperLeg;
					break;
				case 1:
					BoneID = ERagdollBoneID.RightLowerLeg;
					break;
				default:
					BoneID = ERagdollBoneID.RightFoot;
					break;
				}
			}
			else if (chain.ChainType == ERagdollChainType.LeftArm)
			{
				switch (index)
				{
				case 0:
					BoneID = ERagdollBoneID.LeftUpperArm;
					break;
				case 1:
					BoneID = ERagdollBoneID.LeftLowerArm;
					break;
				default:
					BoneID = ERagdollBoneID.LeftHand;
					break;
				}
			}
			else if (chain.ChainType == ERagdollChainType.RightArm)
			{
				switch (index)
				{
				case 0:
					BoneID = ERagdollBoneID.RightUpperArm;
					break;
				case 1:
					BoneID = ERagdollBoneID.RightLowerArm;
					break;
				default:
					BoneID = ERagdollBoneID.RightHand;
					break;
				}
			}
			else
			{
				if (chain.ChainType != ERagdollChainType.Core)
				{
					return;
				}
				if (index == 0)
				{
					BoneID = ERagdollBoneID.Hips;
					return;
				}
				if (index == chain.BoneSetups.Count - 1)
				{
					BoneID = ERagdollBoneID.Head;
					return;
				}
				switch (index)
				{
				case 1:
					BoneID = ERagdollBoneID.Spine;
					break;
				case 2:
					BoneID = ERagdollBoneID.Chest;
					break;
				case 3:
					BoneID = ERagdollBoneID.UpperChest;
					break;
				}
			}
		}

		public void TryDoAutoSettings(RagdollHandler handler, RagdollBonesChain chain)
		{
			TryIdentifyBoneID(chain, changeOnlyIfUnknown: true);
			if (chain.BoneSetups.Count > 1)
			{
				BaseColliderSetup.ColliderType = chain.BoneSetups[chain.BoneSetups.Count - 2].BaseColliderSetup.ColliderType;
				int index = chain.GetIndex(this);
				if (index < chain.BoneSetups.Count - 1)
				{
					chain.AdjustColliderSettingsBasingOnTheStartEndPosition(this, index, SourceBone.position, chain.GetBone(index + 1).SourceBone.position);
				}
			}
			DoAutoMassSettings(handler, chain);
		}

		public void User_ForceOverrideBlendFor(RagdollHandler parentHandler, float duration, float transitionTime = 0.1f, float targetOverrideBlend = 1f)
		{
			if (!(parentHandler.Caller == null))
			{
				if (_forceBlendCoro != null)
				{
					parentHandler.Caller.StopCoroutine(_forceBlendCoro);
				}
				else
				{
					_forceBlendStartOverr = OverrideBlend;
				}
				_forceBlendCoro = parentHandler.Caller.StartCoroutine(IEForceOverrideBlend(parentHandler, duration, transitionTime, targetOverrideBlend));
			}
		}

		public void User_ForceStopOverrideBlend(RagdollHandler parentHandler)
		{
			if (_forceBlendCoro != null)
			{
				parentHandler.Caller.StopCoroutine(_forceBlendCoro);
			}
			OverrideBlend = 0f;
		}

		private IEnumerator IEForceOverrideBlend(RagdollHandler parentHandler, float duration, float transitionTime = 0.1f, float targetOverrideBlend = 1f)
		{
			float elapsed = 0f;
			float startBlend = _forceBlendStartOverr;
			while (elapsed < transitionTime)
			{
				elapsed += parentHandler.Delta;
				OverrideBlend = Mathf.Lerp(startBlend, targetOverrideBlend, elapsed / transitionTime);
				yield return null;
			}
			elapsed = 0f;
			while (elapsed < duration)
			{
				elapsed += parentHandler.Delta;
				OverrideBlend = targetOverrideBlend;
				yield return null;
			}
			elapsed = 0f;
			while (elapsed < transitionTime)
			{
				elapsed += parentHandler.Delta;
				OverrideBlend = Mathf.Lerp(targetOverrideBlend, startBlend, elapsed / transitionTime);
				yield return null;
			}
			OverrideBlend = startBlend;
		}

		internal void DestroyInBetweenBones(RagdollHandler parent)
		{
			if (InBetweenBones == null)
			{
				return;
			}
			foreach (InBetweenBone inBetweenBone in InBetweenBones)
			{
				parent.skeletonFillExtraBonesList.Remove(inBetweenBone);
				if (!(inBetweenBone.DummyBone == null))
				{
					RagdollHandlerUtilities.DestroyObject(inBetweenBone.DummyBone.gameObject);
				}
			}
			InBetweenBones.Clear();
			InBetweenBones = null;
		}

		public void IgnoreCollisionsWith(RagdollChainBone otherBone, bool ignore = true)
		{
			foreach (ColliderSetup collider in otherBone.Colliders)
			{
				foreach (ColliderSetup collider2 in Colliders)
				{
					collider2.IgnoreCollisionWith(collider, ignore);
				}
			}
		}

		public void IgnoreCollisionsWith(Collider coll, bool ignore = true)
		{
			foreach (ColliderSetup collider in Colliders)
			{
				collider.IgnoreCollisionWith(coll, ignore);
			}
		}

		public void SetJointFreeMotion()
		{
			Joint_SetAngularMotionLock(ConfigurableJointMotion.Free);
			Joint_SetMotionLock(ConfigurableJointMotion.Free);
			JointDrive slerpDrive = Joint.slerpDrive;
			slerpDrive.positionDamper = 0f;
			slerpDrive.positionSpring = 0f;
			Joint.slerpDrive = slerpDrive;
		}

		public void SwitchPhysics(bool enable)
		{
			if (enable == !wasPhysicsDisabled)
			{
				return;
			}
			if (!enable)
			{
				if (!GameRigidbody.isKinematic)
				{
					GameRigidbody.velocity = Vector3.zero;
					GameRigidbody.angularVelocity = Vector3.zero;
				}
				kinematicOnDisabled = GameRigidbody.isKinematic;
				GameRigidbody.isKinematic = true;
			}
			else
			{
				GameRigidbody.isKinematic = kinematicOnDisabled;
				if (ParentChain != null && ParentChain.ParentHandler != null)
				{
					RefreshRigidbodyOptimizationParameters(ParentChain.ParentHandler);
				}
			}
			GameRigidbody.detectCollisions = enable;
			if (!enable)
			{
				GameRigidbody.Sleep();
			}
			else
			{
				GameRigidbody.WakeUp();
			}
			foreach (ColliderSetup collider in colliders)
			{
				collider.GameCollider.enabled = enable;
			}
			wasPhysicsDisabled = !enable;
		}

		public void CheckIfShouldIgnoreByBounds(RagdollChainBone otherBone, float boundsSize)
		{
			foreach (ColliderSetup collider in colliders)
			{
				Bounds bounds = collider.GameCollider.bounds;
				bounds.size *= boundsSize;
				foreach (ColliderSetup collider2 in otherBone.colliders)
				{
					Bounds bounds2 = collider2.GameCollider.bounds;
					bounds2.size *= boundsSize;
					if (bounds.Intersects(bounds2))
					{
						IgnoreCollisionsWith(otherBone);
						break;
					}
				}
			}
		}

		public void StoreCalibrationPose()
		{
			BoneProcessor.StoreCalibrationPose();
		}

		public void RestoreCalibrationPose()
		{
			BoneProcessor.RestoreCalibrationPose();
		}

		internal void SetParentBone(RagdollChainBone parentBone)
		{
			ParentBone = parentBone;
		}
	}
}
