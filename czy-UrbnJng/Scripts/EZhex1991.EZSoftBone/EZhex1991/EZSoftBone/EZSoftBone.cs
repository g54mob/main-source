using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EZhex1991.EZSoftBone
{
	public class EZSoftBone : MonoBehaviour
	{
		public enum UnificationMode
		{
			None = 0,
			Rooted = 1,
			Unified = 2
		}

		public enum DeltaTimeMode
		{
			DeltaTime = 0,
			UnscaledDeltaTime = 1,
			Constant = 2
		}

		private class Bone
		{
			public Bone parentBone;

			public Vector3 localPosition;

			public Quaternion localRotation;

			public Bone leftBone;

			public Vector3 leftPosition;

			public Bone rightBone;

			public Vector3 rightPosition;

			public List<Bone> childBones = new List<Bone>();

			public Transform transform;

			public Vector3 worldPosition;

			public Transform systemSpace;

			public Vector3 systemPosition;

			public int depth;

			public float boneLength;

			public float treeLength;

			public float normalizedLength;

			public float radius;

			public float damping;

			public float stiffness;

			public float resistance;

			public float slackness;

			public Vector3 speed;

			public Bone(Transform systemSpace, Transform transform, IEnumerable<Transform> endBones, int startDepth, int depth, float nodeLength, float boneLength)
			{
				this.transform = transform;
				this.systemSpace = systemSpace;
				worldPosition = transform.position;
				systemPosition = ((systemSpace == null) ? worldPosition : systemSpace.InverseTransformPoint(worldPosition));
				localPosition = transform.localPosition;
				localRotation = transform.localRotation;
				this.depth = depth;
				if (depth > startDepth)
				{
					this.boneLength = boneLength + nodeLength;
				}
				treeLength = Mathf.Max(treeLength, this.boneLength);
				if (transform.childCount > 0 && !endBones.Contains(transform))
				{
					for (int i = 0; i < transform.childCount; i++)
					{
						Transform child = transform.GetChild(i);
						if (child.gameObject.activeSelf)
						{
							Bone bone = new Bone(systemSpace, child, endBones, startDepth, depth + 1, Vector3.Distance(child.position, transform.position), this.boneLength)
							{
								parentBone = this
							};
							childBones.Add(bone);
							treeLength = Mathf.Max(treeLength, bone.treeLength);
						}
					}
				}
				normalizedLength = ((treeLength == 0f) ? 0f : (this.boneLength / treeLength));
			}

			public void SetTreeLength()
			{
				SetTreeLength(treeLength);
			}

			public void SetTreeLength(float treeLength)
			{
				this.treeLength = treeLength;
				normalizedLength = ((treeLength == 0f) ? 0f : (boneLength / treeLength));
				for (int i = 0; i < childBones.Count; i++)
				{
					childBones[i].SetTreeLength(treeLength);
				}
			}

			public void SetLeftSibling(Bone left)
			{
				if (left != this && left != rightBone)
				{
					leftBone = left;
					leftPosition = transform.InverseTransformPoint(left.worldPosition);
				}
			}

			public void SetRightSibling(Bone right)
			{
				if (right != this && right != leftBone)
				{
					rightBone = right;
					rightPosition = transform.InverseTransformPoint(right.worldPosition);
				}
			}

			public void Inflate(float baseRadius, AnimationCurve radiusCurve)
			{
				radius = radiusCurve.Evaluate(normalizedLength) * baseRadius;
				for (int i = 0; i < childBones.Count; i++)
				{
					childBones[i].Inflate(baseRadius, radiusCurve);
				}
			}

			public void Inflate(float baseRadius, AnimationCurve radiusCurve, EZSoftBoneMaterial material)
			{
				radius = radiusCurve.Evaluate(normalizedLength) * baseRadius;
				damping = material.GetDamping(normalizedLength);
				stiffness = material.GetStiffness(normalizedLength);
				resistance = material.GetResistance(normalizedLength);
				slackness = material.GetSlackness(normalizedLength);
				for (int i = 0; i < childBones.Count; i++)
				{
					childBones[i].Inflate(baseRadius, radiusCurve, material);
				}
			}

			public void RevertTransforms(int startDepth)
			{
				if (depth > startDepth)
				{
					transform.localPosition = localPosition;
					transform.localRotation = localRotation;
				}
				for (int i = 0; i < childBones.Count; i++)
				{
					childBones[i].RevertTransforms(startDepth);
				}
			}

			public void UpdateTransform(bool siblingRotationConstraints, int startDepth)
			{
				if (depth > startDepth)
				{
					if (childBones.Count == 1)
					{
						Bone bone = childBones[0];
						transform.rotation *= Quaternion.FromToRotation(bone.localPosition, transform.InverseTransformVector(bone.worldPosition - worldPosition));
						if (siblingRotationConstraints)
						{
							if (leftBone != null && rightBone != null)
							{
								Vector3 fromDirection = leftPosition;
								Vector3 toDirection = transform.InverseTransformVector(leftBone.worldPosition - worldPosition);
								Quaternion a = Quaternion.FromToRotation(fromDirection, toDirection);
								Vector3 fromDirection2 = rightPosition;
								Vector3 toDirection2 = transform.InverseTransformVector(rightBone.worldPosition - worldPosition);
								Quaternion b = Quaternion.FromToRotation(fromDirection2, toDirection2);
								transform.rotation *= Quaternion.Lerp(a, b, 0.5f);
							}
							else if (leftBone != null)
							{
								Vector3 fromDirection3 = leftPosition;
								Vector3 toDirection3 = transform.InverseTransformVector(leftBone.worldPosition - worldPosition);
								Quaternion quaternion = Quaternion.FromToRotation(fromDirection3, toDirection3);
								transform.rotation *= quaternion;
							}
							else if (rightBone != null)
							{
								Vector3 fromDirection4 = rightPosition;
								Vector3 toDirection4 = transform.InverseTransformVector(rightBone.worldPosition - worldPosition);
								Quaternion quaternion2 = Quaternion.FromToRotation(fromDirection4, toDirection4);
								transform.rotation *= quaternion2;
							}
						}
					}
					transform.position = worldPosition;
				}
				if (systemSpace != null)
				{
					systemPosition = systemSpace.InverseTransformPoint(worldPosition);
				}
				for (int i = 0; i < childBones.Count; i++)
				{
					childBones[i].UpdateTransform(siblingRotationConstraints, startDepth);
				}
			}

			public void SetRestState()
			{
				worldPosition = transform.position;
				systemPosition = ((systemSpace == null) ? worldPosition : systemSpace.InverseTransformPoint(worldPosition));
				speed = Vector3.zero;
				for (int i = 0; i < childBones.Count; i++)
				{
					childBones[i].SetRestState();
				}
			}

			public void UpdateSpace()
			{
				if (!(systemSpace == null))
				{
					worldPosition = systemSpace.TransformPoint(systemPosition);
					for (int i = 0; i < childBones.Count; i++)
					{
						childBones[i].UpdateSpace();
					}
				}
			}
		}

		public static readonly float DeltaTime_Min = 1E-06f;

		[SerializeField]
		private List<Transform> m_RootBones;

		[SerializeField]
		private List<Transform> m_EndBones;

		[SerializeField]
		private EZSoftBoneMaterial m_Material;

		private EZSoftBoneMaterial m_InstanceMaterial;

		[SerializeField]
		private int m_StartDepth;

		[SerializeField]
		private UnificationMode m_SiblingConstraints;

		[SerializeField]
		private bool m_ClosedSiblings;

		[SerializeField]
		private bool m_SiblingRotationConstraints = true;

		[SerializeField]
		private UnificationMode m_LengthUnification;

		[SerializeField]
		private LayerMask m_CollisionLayers = 1;

		[SerializeField]
		private List<Collider> m_ExtraColliders = new List<Collider>();

		[SerializeField]
		private float m_Radius;

		[SerializeField]
		[EZCurveRect(0f, 0f, 1f, 1f)]
		private AnimationCurve m_RadiusCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

		[SerializeField]
		private DeltaTimeMode m_DeltaTimeMode;

		[SerializeField]
		private float m_ConstantDeltaTime = 0.03f;

		[SerializeField]
		[Range(1f, 10f)]
		private int m_Iterations = 1;

		[SerializeField]
		private float m_SleepThreshold = 0.005f;

		[SerializeField]
		private Transform m_GravityAligner;

		[SerializeField]
		private Vector3 m_Gravity;

		[SerializeField]
		private EZSoftBoneForceField m_ForceModule;

		[SerializeField]
		private float m_ForceScale = 1f;

		[SerializeField]
		private Transform m_SimulateSpace;

		public CustomForce customForce;

		private List<Bone> m_Structures = new List<Bone>();

		public List<Transform> rootBones => m_RootBones;

		public List<Transform> endBones => m_EndBones;

		public EZSoftBoneMaterial sharedMaterial
		{
			get
			{
				if (m_Material == null)
				{
					m_Material = EZSoftBoneMaterial.defaultMaterial;
				}
				return m_Material;
			}
			set
			{
				m_Material = value;
			}
		}

		public EZSoftBoneMaterial material
		{
			get
			{
				if (m_InstanceMaterial == null)
				{
					m_InstanceMaterial = (m_Material = UnityEngine.Object.Instantiate(sharedMaterial));
				}
				return m_InstanceMaterial;
			}
			set
			{
				m_InstanceMaterial = (m_Material = value);
			}
		}

		public int startDepth
		{
			get
			{
				return m_StartDepth;
			}
			set
			{
				m_StartDepth = value;
			}
		}

		public UnificationMode siblingConstraints
		{
			get
			{
				return m_SiblingConstraints;
			}
			set
			{
				m_SiblingConstraints = value;
			}
		}

		public bool closedSiblings
		{
			get
			{
				return m_ClosedSiblings;
			}
			set
			{
				m_ClosedSiblings = value;
			}
		}

		public bool siblingRotationConstraints
		{
			get
			{
				return m_SiblingRotationConstraints;
			}
			set
			{
				m_SiblingRotationConstraints = value;
			}
		}

		public UnificationMode lengthUnification
		{
			get
			{
				return m_LengthUnification;
			}
			set
			{
				m_LengthUnification = value;
			}
		}

		public LayerMask collisionLayers
		{
			get
			{
				return m_CollisionLayers;
			}
			set
			{
				m_CollisionLayers = value;
			}
		}

		public List<Collider> extraColliders => m_ExtraColliders;

		public float radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		public AnimationCurve radiusCurve => m_RadiusCurve;

		public DeltaTimeMode deltaTimeMode
		{
			get
			{
				return m_DeltaTimeMode;
			}
			set
			{
				m_DeltaTimeMode = value;
			}
		}

		public float constantDeltaTime
		{
			get
			{
				return m_ConstantDeltaTime;
			}
			set
			{
				m_ConstantDeltaTime = value;
			}
		}

		public int iterations
		{
			get
			{
				return m_Iterations;
			}
			set
			{
				m_Iterations = value;
			}
		}

		public float sleepThreshold
		{
			get
			{
				return m_SleepThreshold;
			}
			set
			{
				m_SleepThreshold = Mathf.Max(0f, value);
			}
		}

		public Transform gravityAligner
		{
			get
			{
				return m_GravityAligner;
			}
			set
			{
				m_GravityAligner = value;
			}
		}

		public Vector3 gravity
		{
			get
			{
				return m_Gravity;
			}
			set
			{
				m_Gravity = value;
			}
		}

		public EZSoftBoneForceField forceModule
		{
			get
			{
				return m_ForceModule;
			}
			set
			{
				m_ForceModule = value;
			}
		}

		public float forceScale
		{
			get
			{
				return m_ForceScale;
			}
			set
			{
				m_ForceScale = value;
			}
		}

		public Transform simulateSpace
		{
			get
			{
				return m_SimulateSpace;
			}
			set
			{
				m_SimulateSpace = value;
			}
		}

		public float globalRadius { get; private set; }

		public Vector3 globalForce { get; private set; }

		private void Awake()
		{
			InitStructures();
		}

		private void OnEnable()
		{
			SetRestState();
		}

		private void Update()
		{
			RevertTransforms(startDepth);
		}

		private void LateUpdate()
		{
			switch (deltaTimeMode)
			{
			case DeltaTimeMode.DeltaTime:
				UpdateStructures(Time.deltaTime);
				break;
			case DeltaTimeMode.UnscaledDeltaTime:
				UpdateStructures(Time.unscaledDeltaTime);
				break;
			case DeltaTimeMode.Constant:
				UpdateStructures(constantDeltaTime);
				break;
			}
			UpdateTransforms();
		}

		private void OnDisable()
		{
			RevertTransforms(startDepth);
		}

		public void RevertTransforms()
		{
			RevertTransforms(startDepth);
		}

		public void RevertTransforms(int startDepth)
		{
			for (int i = 0; i < m_Structures.Count; i++)
			{
				m_Structures[i].RevertTransforms(startDepth);
			}
		}

		public void InitStructures()
		{
			CreateBones();
			SetSiblings();
			SetTreeLength();
			RefreshRadius();
		}

		public void SetRestState()
		{
			for (int i = 0; i < m_Structures.Count; i++)
			{
				m_Structures[i].SetRestState();
			}
		}

		private void CreateBones()
		{
			m_Structures.Clear();
			if (rootBones == null || rootBones.Count == 0)
			{
				return;
			}
			for (int i = 0; i < rootBones.Count; i++)
			{
				if (!(rootBones[i] == null))
				{
					Bone item = new Bone(simulateSpace, rootBones[i], endBones, startDepth, 0, 0f, 0f);
					m_Structures.Add(item);
				}
			}
		}

		private void SetSiblings()
		{
			if (siblingConstraints == UnificationMode.Rooted)
			{
				for (int i = 0; i < m_Structures.Count; i++)
				{
					Queue<Bone> queue = new Queue<Bone>();
					queue.Enqueue(m_Structures[i]);
					SetSiblingsByDepth(queue, closedSiblings);
				}
			}
			else if (siblingConstraints == UnificationMode.Unified)
			{
				Queue<Bone> queue2 = new Queue<Bone>();
				for (int j = 0; j < m_Structures.Count; j++)
				{
					queue2.Enqueue(m_Structures[j]);
				}
				if (queue2.Count > 0)
				{
					SetSiblingsByDepth(queue2, closedSiblings);
				}
			}
		}

		private void SetSiblingsByDepth(Queue<Bone> bones, bool closed)
		{
			Bone bone = bones.Dequeue();
			for (int i = 0; i < bone.childBones.Count; i++)
			{
				bones.Enqueue(bone.childBones[i]);
			}
			Bone bone2 = bone;
			Bone bone3 = null;
			while (bones.Count > 0)
			{
				bone3 = bones.Dequeue();
				for (int j = 0; j < bone3.childBones.Count; j++)
				{
					bones.Enqueue(bone3.childBones[j]);
				}
				if (bone2.depth == bone3.depth)
				{
					bone2.SetRightSibling(bone3);
					bone3.SetLeftSibling(bone2);
				}
				else
				{
					if (closed)
					{
						bone2.SetRightSibling(bone);
						bone.SetLeftSibling(bone2);
					}
					bone = bone3;
				}
				bone2 = bone3;
			}
			if (bone3 != null && closed)
			{
				bone.SetLeftSibling(bone3);
				bone3.SetRightSibling(bone);
			}
		}

		private void SetTreeLength()
		{
			if (lengthUnification == UnificationMode.Rooted)
			{
				for (int i = 0; i < m_Structures.Count; i++)
				{
					m_Structures[i].SetTreeLength();
				}
			}
			else if (lengthUnification == UnificationMode.Unified)
			{
				float num = 0f;
				for (int j = 0; j < m_Structures.Count; j++)
				{
					num = Mathf.Max(num, m_Structures[j].treeLength);
				}
				for (int k = 0; k < m_Structures.Count; k++)
				{
					m_Structures[k].SetTreeLength(num);
				}
			}
		}

		public void RefreshRadius()
		{
			globalRadius = base.transform.lossyScale.Abs().Max() * radius;
			for (int i = 0; i < m_Structures.Count; i++)
			{
				m_Structures[i].Inflate(globalRadius, radiusCurve);
			}
		}

		private void UpdateStructures(float deltaTime)
		{
			if (deltaTime <= DeltaTime_Min)
			{
				return;
			}
			globalRadius = base.transform.lossyScale.Abs().Max() * radius;
			for (int i = 0; i < m_Structures.Count; i++)
			{
				m_Structures[i].Inflate(globalRadius, radiusCurve, sharedMaterial);
				if (simulateSpace != null)
				{
					m_Structures[i].UpdateSpace();
				}
			}
			globalForce = gravity;
			if (gravityAligner != null)
			{
				Vector3 normalized = gravityAligner.TransformDirection(gravity).normalized;
				Vector3 normalized2 = gravity.normalized;
				float num = Mathf.Acos(Vector3.Dot(normalized, normalized2)) / MathF.PI;
				globalForce *= num;
			}
			deltaTime /= (float)iterations;
			for (int j = 0; j < iterations; j++)
			{
				for (int k = 0; k < m_Structures.Count; k++)
				{
					UpdateBones(m_Structures[k], deltaTime);
				}
			}
		}

		private void UpdateBones(Bone bone, float deltaTime)
		{
			if (bone.depth > startDepth)
			{
				Vector3 worldPosition;
				Vector3 vector = (worldPosition = bone.worldPosition);
				Vector3 vector2 = globalForce;
				if (forceModule != null && forceModule.isActiveAndEnabled)
				{
					vector2 += forceModule.GetForce(bone.normalizedLength) * forceScale;
				}
				if (customForce != null)
				{
					vector2 += customForce(bone.normalizedLength);
				}
				vector2.x *= base.transform.localScale.x;
				vector2.y *= base.transform.localScale.y;
				vector2.z *= base.transform.localScale.z;
				bone.speed += vector2 * (1f - bone.resistance) / iterations;
				bone.speed *= 1f - bone.damping;
				if (bone.speed.sqrMagnitude > sleepThreshold)
				{
					worldPosition += bone.speed * deltaTime;
				}
				Vector3 vector3 = bone.parentBone.worldPosition - bone.parentBone.transform.position;
				Vector3 b = bone.parentBone.transform.TransformPoint(bone.localPosition) + vector3;
				worldPosition = Vector3.Lerp(worldPosition, b, bone.stiffness / (float)iterations);
				Vector3 normalized = (worldPosition - bone.parentBone.worldPosition).normalized;
				float magnitude = bone.parentBone.transform.TransformVector(bone.localPosition).magnitude;
				b = bone.parentBone.worldPosition + normalized * magnitude;
				int num = 1;
				if (siblingConstraints != UnificationMode.None)
				{
					if (bone.leftBone != null)
					{
						Vector3 normalized2 = (worldPosition - bone.leftBone.worldPosition).normalized;
						float magnitude2 = bone.transform.TransformVector(bone.leftPosition).magnitude;
						b += bone.leftBone.worldPosition + normalized2 * magnitude2;
						num++;
					}
					if (bone.rightBone != null)
					{
						Vector3 normalized3 = (worldPosition - bone.rightBone.worldPosition).normalized;
						float magnitude3 = bone.transform.TransformVector(bone.rightPosition).magnitude;
						b += bone.rightBone.worldPosition + normalized3 * magnitude3;
						num++;
					}
				}
				b /= (float)num;
				worldPosition = Vector3.Lerp(b, worldPosition, bone.slackness / (float)iterations);
				if (bone.radius > 0f)
				{
					foreach (EZSoftBoneColliderBase enabledCollider in EZSoftBoneColliderBase.EnabledColliders)
					{
						if (bone.transform != enabledCollider.transform && collisionLayers.Contains(enabledCollider.gameObject.layer))
						{
							enabledCollider.Collide(ref worldPosition, bone.radius);
						}
					}
					foreach (Collider extraCollider in extraColliders)
					{
						if (bone.transform != extraCollider.transform && extraCollider.enabled)
						{
							EZSoftBoneUtility.PointOutsideCollider(ref worldPosition, extraCollider, bone.radius);
						}
					}
				}
				bone.speed = (bone.speed + (worldPosition - vector) / deltaTime) * 0.5f;
				bone.worldPosition = worldPosition;
			}
			else
			{
				bone.worldPosition = bone.transform.position;
			}
			for (int i = 0; i < bone.childBones.Count; i++)
			{
				UpdateBones(bone.childBones[i], deltaTime);
			}
		}

		private void UpdateTransforms()
		{
			for (int i = 0; i < m_Structures.Count; i++)
			{
				m_Structures[i].UpdateTransform(siblingRotationConstraints, startDepth);
			}
		}
	}
}
