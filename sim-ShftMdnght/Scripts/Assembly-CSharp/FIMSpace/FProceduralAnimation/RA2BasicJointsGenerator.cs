using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator/Basic Joints Chain Generator", 111)]
	public class RA2BasicJointsGenerator : FimpossibleComponent
	{
		public float Radius = 0.2f;

		[Space(3f)]
		public float Mass = 1f;

		[Space(3f)]
		public float MassScale = 1f;

		public float ConnectedMass = 1f;

		public float RigidbodyDrag;

		public float AngularDrag = 0.1f;

		public RigidbodyInterpolation Interpolation = RigidbodyInterpolation.Interpolate;

		[Space(4f)]
		public PhysicMaterial CollidersMaterial;

		[Tooltip("Applying alternative tensor forces for joints, in some cases it can make motion more stable")]
		public bool LimitTensors;

		[FPD_Header("Main Chain References", 6f, 4f, 2)]
		public Transform FirstParentBone;

		public Transform EndChildBone;

		[Space(5f)]
		[Tooltip("Generating rigidbody under parent bone of the first bone in chain for position control, otherwise objec will stay fixed in one position and rotation")]
		public bool AssignAnchor = true;

		private Rigidbody dummyRigidbody;

		[FPD_Header("Optional Configurable Joints Option", 6f, 4f, 2)]
		public bool ConfigurableJoints;

		public float Spring = 5000f;

		public float Damping = 10f;

		[HideInInspector]
		[SerializeField]
		private List<Rigidbody> rigidbodies = new List<Rigidbody>();

		[HideInInspector]
		[SerializeField]
		private List<ConfigurableJoint> configurableJoints = new List<ConfigurableJoint>();

		[SerializeField]
		[HideInInspector]
		private Transform generatedOn;

		private bool tensorSwitched;

		public bool WasInitialized { get; private set; }

		private void Start()
		{
			if (generatedOn != FirstParentBone)
			{
				ClearJoints();
				GenerateJoints();
			}
			UpdatePhysicalParameters();
			WasInitialized = true;
		}

		public override void OnValidate()
		{
			if (!Application.isPlaying || WasInitialized)
			{
				UpdatePhysicalParameters();
				base.OnValidate();
			}
		}

		private void GenerateJoints()
		{
			Transform transform = EndChildBone;
			if (AssignAnchor)
			{
				if (FirstParentBone.parent == null)
				{
					GameObject gameObject = new GameObject(base.name + "-GeneratedParent");
					gameObject.transform.position = FirstParentBone.position;
					gameObject.transform.rotation = FirstParentBone.rotation;
					FirstParentBone.SetParent(gameObject.transform, worldPositionStays: true);
				}
				dummyRigidbody = RagdollHandlerUtilities.GetOrGenerate<Rigidbody>(FirstParentBone.parent);
				dummyRigidbody.isKinematic = true;
			}
			while (transform != FirstParentBone && transform != null)
			{
				RagdollHandlerUtilities.GetOrGenerate<Rigidbody>(transform);
				Joint joint = GenerateJointOn(transform);
				Rigidbody orGenerate = RagdollHandlerUtilities.GetOrGenerate<Rigidbody>(transform.parent);
				GenerateJointOn(transform.parent);
				CapsuleCollider orGenerate2 = RagdollHandlerUtilities.GetOrGenerate<CapsuleCollider>(transform.parent);
				orGenerate2.material = CollidersMaterial;
				RagdollHandlerUtilities.AdjustColliderBasingOnStartEndPosition(transform.parent.position, transform.position, transform.parent, orGenerate2, Radius);
				joint.connectedBody = orGenerate;
				transform = transform.parent;
			}
			transform = EndChildBone;
			rigidbodies.Clear();
			configurableJoints.Clear();
			while (transform != FirstParentBone.parent && transform != null)
			{
				Rigidbody orGenerate3 = RagdollHandlerUtilities.GetOrGenerate<Rigidbody>(transform);
				Joint component = transform.GetComponent<Joint>();
				orGenerate3.mass = Mass;
				component.connectedMassScale = ConnectedMass;
				component.massScale = MassScale;
				rigidbodies.Add(orGenerate3);
				ConfigurableJoint configurableJoint = component as ConfigurableJoint;
				if ((bool)configurableJoint)
				{
					configurableJoints.Add(configurableJoint);
				}
				transform = transform.parent;
			}
			if (AssignAnchor && (bool)FirstParentBone && (bool)FirstParentBone.GetComponent<Joint>())
			{
				FirstParentBone.GetComponent<Joint>().connectedBody = dummyRigidbody;
			}
			generatedOn = FirstParentBone;
		}

		public void UpdatePhysicalParameters()
		{
			Transform transform = EndChildBone;
			if (FirstParentBone == null || (WasInitialized && FirstParentBone.GetComponent<Rigidbody>() == null))
			{
				return;
			}
			while (transform != FirstParentBone.parent && transform != null)
			{
				Rigidbody component = transform.GetComponent<Rigidbody>();
				if (component == null)
				{
					transform = transform.parent;
					continue;
				}
				component.mass = Mass;
				component.drag = RigidbodyDrag;
				component.angularDrag = AngularDrag;
				component.interpolation = Interpolation;
				Joint component2 = transform.GetComponent<Joint>();
				component2.connectedMassScale = ConnectedMass;
				component2.massScale = MassScale;
				transform = transform.parent;
			}
		}

		private void FixedUpdate()
		{
			foreach (ConfigurableJoint configurableJoint in configurableJoints)
			{
				JointDrive slerpDrive = configurableJoint.slerpDrive;
				slerpDrive.positionSpring = Spring;
				slerpDrive.positionDamper = Damping;
				configurableJoint.slerpDrive = slerpDrive;
			}
			if (LimitTensors)
			{
				tensorSwitched = true;
				{
					foreach (Rigidbody rigidbody in rigidbodies)
					{
						CalculateInertiaTensor(rigidbody);
					}
					return;
				}
			}
			if (!tensorSwitched)
			{
				return;
			}
			foreach (Rigidbody rigidbody2 in rigidbodies)
			{
				rigidbody2.ResetInertiaTensor();
			}
			tensorSwitched = false;
		}

		private void CalculateInertiaTensor(Rigidbody rig)
		{
			Vector3 localScale = base.transform.localScale;
			float mass = rig.mass;
			float x = mass / 12f * (localScale.y * localScale.y + localScale.z * localScale.z);
			float y = mass / 12f * (localScale.x * localScale.x + localScale.z * localScale.z);
			float z = mass / 12f * (localScale.x * localScale.x + localScale.y * localScale.y);
			rig.inertiaTensor = new Vector3(x, y, z);
			rig.inertiaTensorRotation = rig.transform.rotation;
		}

		private Joint GenerateJointOn(Transform target)
		{
			if (ConfigurableJoints)
			{
				ConfigurableJoint orGenerate = RagdollHandlerUtilities.GetOrGenerate<ConfigurableJoint>(target);
				orGenerate.xMotion = ConfigurableJointMotion.Locked;
				orGenerate.yMotion = ConfigurableJointMotion.Locked;
				orGenerate.zMotion = ConfigurableJointMotion.Locked;
				orGenerate.rotationDriveMode = RotationDriveMode.Slerp;
				return orGenerate;
			}
			return RagdollHandlerUtilities.GetOrGenerate<FixedJoint>(target);
		}

		private void ClearJoints()
		{
			Transform transform = EndChildBone;
			while (transform != FirstParentBone && transform != null)
			{
				RagdollHandlerUtilities.DestroyComponent<Joint>(transform);
				RagdollHandlerUtilities.DestroyComponent<Rigidbody>(transform);
				RagdollHandlerUtilities.DestroyComponent<Collider>(transform);
				transform = transform.parent;
			}
			if (FirstParentBone != null)
			{
				RagdollHandlerUtilities.DestroyComponent<Joint>(FirstParentBone);
				RagdollHandlerUtilities.DestroyComponent<Rigidbody>(FirstParentBone);
				RagdollHandlerUtilities.DestroyComponent<Collider>(FirstParentBone);
			}
			if (AssignAnchor && (bool)FirstParentBone)
			{
				RagdollHandlerUtilities.DestroyComponent<Rigidbody>(FirstParentBone.parent);
			}
			generatedOn = null;
		}
	}
}
