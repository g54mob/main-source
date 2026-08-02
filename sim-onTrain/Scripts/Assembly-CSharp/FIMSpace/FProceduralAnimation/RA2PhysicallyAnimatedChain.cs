using System;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator/Ragdoll Animated Chain", 111)]
	public class RA2PhysicallyAnimatedChain : FimpossibleComponent
	{
		[Serializable]
		public struct BoneReference
		{
			public Transform sourceBone;

			public Transform physicalBone;

			public ConfigurableJoint joint;

			public BoneReference(Transform src, ConfigurableJoint jnt)
			{
				sourceBone = src;
				joint = jnt;
				physicalBone = joint.transform;
			}
		}

		private class JointHelper
		{
			public ConfigurableJoint joint;

			public RagdollBoneProcessor processor;

			public Quaternion lastFixedRotation;

			public Rigidbody rigidbody;

			public Collider collider;

			public Transform sourceBone;

			public JointHelper(Transform src, ConfigurableJoint jnt, Collider coll)
			{
				joint = jnt;
				sourceBone = src;
				collider = coll;
				rigidbody = jnt.GetComponent<Rigidbody>();
				processor = new RagdollBoneProcessor(jnt, sourceBone, jnt.gameObject.GetComponent<Rigidbody>());
				lastFixedRotation = jnt.transform.localRotation;
			}
		}

		[FPD_Header("Animating Properties", 1f, 4f, 2)]
		public float SpringsPower = 1000f;

		[FPD_FixedCurveWindow(0f, 0f, 1f, 1f, 0f, 1f, 1f, 1f)]
		public AnimationCurve SpringOverChain = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);

		public float Damping = 5f;

		[Space(6f)]
		[Range(0f, 1f)]
		public float PositionHardMatching;

		[FPD_FixedCurveWindow(0f, 0f, 1f, 1f, 0f, 1f, 1f, 1f)]
		public AnimationCurve HardMatchOverChain = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);

		[Space(8f)]
		public float RigidbodiesMass = 1f;

		[Tooltip("Use curve to multiply RigidbodiesMass value over the chain. Value on the left is first parent bone mass, on the right - last child bone mass.")]
		[FPD_FixedCurveWindow(0f, 0f, 1f, 1f, 0f, 1f, 1f, 1f)]
		public AnimationCurve MassOverChain = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);

		public float RigidbodyDrag;

		public float AngularDrag = 1f;

		public RigidbodyInterpolation Interpolation = RigidbodyInterpolation.Interpolate;

		public bool KinematicAnchor = true;

		[Space(8f)]
		[Tooltip("Optional, use for animate physics sync")]
		public Animator Mecanim;

		public bool Calibrate = true;

		[FPD_Header("Main References for chain generating", 6f, 4f, 2)]
		public Transform FirstParentBone;

		public Transform EndChildBone;

		[Space(3f)]
		[Tooltip("Optional. If you generating chain for parented bone, like arm, you should assign there FirstParentBone.")]
		public Transform TargetParent;

		[FPD_Header("Joints Generator Settings", 6f, 4f, 2)]
		[FPD_Layers]
		public int DummyLayer;

		public float MassScale = 1f;

		public float ConnectedMass = 1f;

		[Space(3f)]
		public float Radius = 0.2f;

		[Tooltip("Use curve to multiply colliders radius value over the chain. Value on the left is first parent bone collider radius multiplier, on the right - last child bone collider multiplier.")]
		[FPD_FixedCurveWindow(0f, 0f, 1f, 1f, 0f, 1f, 1f, 1f)]
		public AnimationCurve RadiusOverChain = AnimationCurve.EaseInOut(0f, 1f, 1f, 1f);

		[Space(3f)]
		public PhysicMaterial CollidersMaterial;

		public bool HideGeneratedDummy;

		[SerializeField]
		[HideInInspector]
		private GameObject generatedDummy;

		private Rigidbody dummyRigidbody;

		private Vector3 targetAnchorPosition;

		private Quaternion targetAnchorRotation;

		[SerializeField]
		[HideInInspector]
		public List<BoneReference> joints = new List<BoneReference>();

		private List<JointHelper> jointControllers = new List<JointHelper>();

		private bool fixedInitialized;

		private int fixedFramesElapsed;

		private bool animatePhysics;

		private bool unscaledTime;

		private bool scheduledFixedUpdate = true;

		private bool _wasDisabled;

		public GameObject GeneratedDummy => generatedDummy;

		private JointHelper FirstBone => jointControllers[0];

		public bool WasInitialized { get; private set; }

		private void UpdateAnimatePhysicsVariable()
		{
			if ((bool)Mecanim)
			{
				animatePhysics = Mecanim.updateMode == AnimatorUpdateMode.AnimatePhysics;
				unscaledTime = Mecanim.updateMode == AnimatorUpdateMode.UnscaledTime;
			}
		}

		private void Awake()
		{
			if (FirstParentBone == null || EndChildBone == null)
			{
				Debug.Log("[Ragdoll Animator 2 Helper] Not Assigned bone reference in " + base.name + "!");
				UnityEngine.Object.Destroy(this);
				return;
			}
			if (!generatedDummy)
			{
				GenerateJoints();
				Physics.SyncTransforms();
			}
			if (TargetParent == null)
			{
				if ((bool)FirstParentBone.parent)
				{
					generatedDummy.transform.SetParent(FirstParentBone.parent, worldPositionStays: true);
				}
			}
			else
			{
				generatedDummy.transform.SetParent(TargetParent, worldPositionStays: true);
			}
			if (HideGeneratedDummy)
			{
				generatedDummy.gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			for (int i = 0; i < joints.Count; i++)
			{
				joints[i].joint.gameObject.layer = DummyLayer;
				joints[i].joint.connectedMassScale = ConnectedMass;
				joints[i].joint.massScale = MassScale;
				Collider component = joints[i].joint.GetComponent<Collider>();
				if ((bool)component)
				{
					component.sharedMaterial = CollidersMaterial;
				}
				JointHelper jointHelper = new JointHelper(joints[i].sourceBone, joints[i].joint, component);
				jointControllers.Add(jointHelper);
				jointHelper.processor.CaptureAnimatorPose();
				joints[i].joint.transform.SetParent(generatedDummy.transform, worldPositionStays: true);
			}
			jointControllers.Reverse();
			dummyRigidbody = generatedDummy.GetComponent<Rigidbody>();
			dummyRigidbody.mass = RigidbodiesMass;
			dummyRigidbody.interpolation = Interpolation;
			if (jointControllers.Count == 0 || jointControllers[0] == null)
			{
				Debug.Log("[Ragdoll Animator 2 - Animated Chain] Couldn't generate any joint! Check this object setup : " + base.name);
				base.enabled = false;
				return;
			}
			targetAnchorPosition = FirstBone.sourceBone.parent.position;
			targetAnchorRotation = FirstBone.sourceBone.parent.rotation;
			UpdateComponentsParameters();
			WasInitialized = true;
		}

		public void UpdateComponentsParameters()
		{
			if (jointControllers != null)
			{
				for (int i = 0; i < jointControllers.Count; i++)
				{
					jointControllers[i].joint.gameObject.layer = DummyLayer;
					jointControllers[i].joint.connectedMassScale = ConnectedMass;
					jointControllers[i].joint.massScale = MassScale;
					jointControllers[i].rigidbody.mass = RigidbodiesMass;
					jointControllers[i].rigidbody.drag = RigidbodyDrag;
					jointControllers[i].rigidbody.angularDrag = AngularDrag;
					jointControllers[i].collider.sharedMaterial = CollidersMaterial;
				}
			}
		}

		private void Update()
		{
			if ((bool)Mecanim)
			{
				animatePhysics = Mecanim.updateMode == AnimatorUpdateMode.AnimatePhysics;
			}
			if (animatePhysics || !Calibrate)
			{
				return;
			}
			foreach (JointHelper jointController in jointControllers)
			{
				jointController.processor.CalibrateRotation();
			}
		}

		private void FixedUpdate()
		{
			if (fixedFramesElapsed < 2)
			{
				fixedInitialized = false;
				fixedFramesElapsed++;
				return;
			}
			if (!fixedInitialized)
			{
				fixedInitialized = true;
			}
			scheduledFixedUpdate = true;
			if (animatePhysics && Calibrate)
			{
				foreach (JointHelper jointController in jointControllers)
				{
					jointController.processor.CalibrateRotation();
				}
			}
			float num = (float)jointControllers.Count - 1f;
			if (num == 0f)
			{
				num = 1f;
			}
			for (int i = 0; i < jointControllers.Count; i++)
			{
				JointHelper jointHelper = jointControllers[i];
				float time = (float)i / num;
				JointDrive slerpDrive = jointHelper.joint.slerpDrive;
				slerpDrive.positionSpring = SpringOverChain.Evaluate(time) * SpringsPower;
				slerpDrive.positionDamper = Damping;
				jointHelper.joint.slerpDrive = slerpDrive;
				jointHelper.rigidbody.mass = MassOverChain.Evaluate(time) * RigidbodiesMass;
				jointHelper.processor.ApplyJointRotation();
			}
			if (PositionHardMatching > 0f)
			{
				for (int j = 0; j < jointControllers.Count; j++)
				{
					JointHelper jointHelper2 = jointControllers[j];
					float time2 = (float)j / num;
					jointHelper2.processor.HardMatchBonePosition(HardMatchOverChain.Evaluate(time2) * PositionHardMatching);
				}
			}
			if (KinematicAnchor)
			{
				dummyRigidbody.isKinematic = true;
				generatedDummy.transform.position = targetAnchorPosition;
				generatedDummy.transform.rotation = targetAnchorRotation;
			}
			else
			{
				dummyRigidbody.isKinematic = false;
				dummyRigidbody.AddRigidbodyForceToMoveTowards(targetAnchorPosition, 1f);
				dummyRigidbody.AddRigidbodyTorqueToRotateTowards(targetAnchorRotation, 1f);
			}
		}

		private void LateUpdate()
		{
			if (animatePhysics)
			{
				if (!scheduledFixedUpdate)
				{
					return;
				}
				scheduledFixedUpdate = false;
			}
			if (!fixedInitialized)
			{
				return;
			}
			foreach (JointHelper jointController in jointControllers)
			{
				jointController.processor.CaptureAnimatorPose();
			}
			targetAnchorPosition = FirstBone.sourceBone.parent.position;
			targetAnchorRotation = FirstBone.sourceBone.parent.rotation;
			foreach (JointHelper jointController2 in jointControllers)
			{
				jointController2.sourceBone.rotation = jointController2.joint.transform.rotation;
			}
		}

		public override void OnValidate()
		{
			base.OnValidate();
		}

		private void OnEnable()
		{
			if (WasInitialized && _wasDisabled)
			{
				SwitchAllPhysics(enabled: true);
			}
		}

		private void OnDisable()
		{
			if (WasInitialized && !_wasDisabled)
			{
				SwitchAllPhysics(enabled: false);
			}
		}

		public void SwitchAllPhysics(bool enabled)
		{
			if (FirstBone.rigidbody == null)
			{
				return;
			}
			for (int i = 0; i < jointControllers.Count; i++)
			{
				jointControllers[i].rigidbody.detectCollisions = enabled;
				jointControllers[i].rigidbody.isKinematic = enabled;
				jointControllers[i].collider.enabled = enabled;
				if (!enabled)
				{
					jointControllers[i].rigidbody.Sleep();
				}
				else
				{
					jointControllers[i].rigidbody.WakeUp();
				}
			}
			_wasDisabled = !enabled;
		}

		private void GenerateJoints()
		{
			if ((bool)generatedDummy)
			{
				RagdollHandlerUtilities.DestroyObject(generatedDummy);
			}
			joints.Clear();
			Transform transform = EndChildBone;
			int num = 0;
			while (transform != FirstParentBone && transform != null)
			{
				num++;
				transform = transform.parent;
			}
			transform = EndChildBone;
			float num2 = (float)num - 1f;
			if (num2 == 0f)
			{
				num2 = 1f;
			}
			int num3 = 0;
			while (transform != FirstParentBone && transform != null)
			{
				GameObject obj = new GameObject(transform.parent.name);
				Transform t = obj.transform;
				obj.layer = DummyLayer;
				obj.transform.position = transform.parent.position;
				obj.transform.rotation = transform.parent.rotation;
				RagdollHandlerUtilities.GetOrGenerate<Rigidbody>(t);
				ConfigurableJoint orGenerate = RagdollHandlerUtilities.GetOrGenerate<ConfigurableJoint>(t);
				if (!ContainsJoint(orGenerate))
				{
					joints.Add(new BoneReference(transform.parent, orGenerate));
				}
				CapsuleCollider orGenerate2 = RagdollHandlerUtilities.GetOrGenerate<CapsuleCollider>(t);
				orGenerate2.material = CollidersMaterial;
				float num4 = (float)num3 / num2;
				float radius = RadiusOverChain.Evaluate(1f - num4) * Radius;
				RagdollHandlerUtilities.AdjustColliderBasingOnStartEndPosition(transform.parent.position, transform.position, transform.parent, orGenerate2, radius);
				num3++;
				transform = transform.parent;
			}
			generatedDummy = new GameObject(base.name + "-GeneratedDummy");
			generatedDummy.layer = DummyLayer;
			generatedDummy.transform.position = FirstParentBone.parent.position;
			generatedDummy.transform.rotation = FirstParentBone.parent.rotation;
			generatedDummy.transform.SetParent(base.transform, worldPositionStays: true);
			dummyRigidbody = generatedDummy.AddComponent<Rigidbody>();
			dummyRigidbody.isKinematic = true;
			joints[joints.Count - 1].joint.transform.SetParent(generatedDummy.transform, worldPositionStays: true);
			for (int i = 0; i < joints.Count - 1; i++)
			{
				joints[i].joint.transform.SetParent(joints[i + 1].joint.transform, worldPositionStays: true);
			}
			for (int j = 0; j < joints.Count; j++)
			{
				ConfigurableJoint joint = joints[j].joint;
				joint.GetComponent<Rigidbody>().mass = RigidbodiesMass;
				joint.connectedBody = joint.transform.parent.GetComponent<Rigidbody>();
				joint.connectedMassScale = ConnectedMass;
				joint.xMotion = ConfigurableJointMotion.Locked;
				joint.yMotion = ConfigurableJointMotion.Locked;
				joint.zMotion = ConfigurableJointMotion.Locked;
				joint.rotationDriveMode = RotationDriveMode.Slerp;
			}
		}

		private void ClearJoints()
		{
			if ((bool)generatedDummy)
			{
				RagdollHandlerUtilities.DestroyObject(generatedDummy);
			}
		}

		private bool ContainsJoint(ConfigurableJoint joint)
		{
			for (int i = 0; i < joints.Count; i++)
			{
				if (joints[i].joint == joint)
				{
					return true;
				}
			}
			return false;
		}
	}
}
