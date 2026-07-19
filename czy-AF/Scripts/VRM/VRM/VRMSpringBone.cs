using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	[DefaultExecutionOrder(11000)]
	public class VRMSpringBone : MonoBehaviour
	{
		public enum SpringBoneUpdateType
		{
			LateUpdate = 0,
			FixedUpdate = 1
		}

		public class VRMSpringBoneLogic
		{
			private Transform m_transform;

			private float m_length;

			private Vector3 m_currentTail;

			private Vector3 m_prevTail;

			private Vector3 m_localDir;

			private Quaternion m_localRotation;

			public Vector3 m_boneAxis;

			public Transform Head => m_transform;

			public Vector3 Tail => m_transform.localToWorldMatrix.MultiplyPoint(m_boneAxis * m_length);

			public Quaternion LocalRotation => m_localRotation;

			public float Radius { get; set; }

			private Quaternion ParentRotation
			{
				get
				{
					if (!(m_transform.parent != null))
					{
						return Quaternion.identity;
					}
					return m_transform.parent.rotation;
				}
			}

			public VRMSpringBoneLogic(Transform center, Transform transform, Vector3 localChildPosition)
			{
				m_transform = transform;
				Vector3 vector = m_transform.TransformPoint(localChildPosition);
				m_currentTail = ((center != null) ? center.InverseTransformPoint(vector) : vector);
				m_prevTail = m_currentTail;
				m_localRotation = transform.localRotation;
				m_boneAxis = localChildPosition.normalized;
				m_length = localChildPosition.magnitude;
			}

			public void Update(Transform center, float stiffnessForce, float dragForce, Vector3 external, List<SphereCollider> colliders)
			{
				Vector3 vector = ((center != null) ? center.TransformPoint(m_currentTail) : m_currentTail);
				Vector3 vector2 = ((center != null) ? center.TransformPoint(m_prevTail) : m_prevTail);
				Vector3 vector3 = vector + (vector - vector2) * (1f - dragForce) + ParentRotation * m_localRotation * m_boneAxis * stiffnessForce + external;
				vector3 = m_transform.position + (vector3 - m_transform.position).normalized * m_length;
				vector3 = Collision(colliders, vector3);
				m_prevTail = ((center != null) ? center.InverseTransformPoint(vector) : vector);
				m_currentTail = ((center != null) ? center.InverseTransformPoint(vector3) : vector3);
				Head.rotation = ApplyRotation(vector3);
			}

			protected virtual Quaternion ApplyRotation(Vector3 nextTail)
			{
				Quaternion quaternion = ParentRotation * m_localRotation;
				return Quaternion.FromToRotation(quaternion * m_boneAxis, nextTail - m_transform.position) * quaternion;
			}

			protected virtual Vector3 Collision(List<SphereCollider> colliders, Vector3 nextTail)
			{
				foreach (SphereCollider collider in colliders)
				{
					float num = Radius + collider.Radius;
					if (Vector3.SqrMagnitude(nextTail - collider.Position) <= num * num)
					{
						Vector3 normalized = (nextTail - collider.Position).normalized;
						Vector3 vector = collider.Position + normalized * (Radius + collider.Radius);
						nextTail = m_transform.position + (vector - m_transform.position).normalized * m_length;
					}
				}
				return nextTail;
			}

			public void DrawGizmo(Transform center, float radius, Color color)
			{
				Vector3 obj = ((center != null) ? center.TransformPoint(m_currentTail) : m_currentTail);
				Vector3 vector = ((center != null) ? center.TransformPoint(m_prevTail) : m_prevTail);
				Gizmos.color = Color.gray;
				Gizmos.DrawLine(obj, vector);
				Gizmos.DrawWireSphere(vector, radius);
				Gizmos.color = color;
				Gizmos.DrawLine(obj, m_transform.position);
				Gizmos.DrawWireSphere(obj, radius);
			}
		}

		public struct SphereCollider
		{
			public Vector3 Position;

			public float Radius;
		}

		[SerializeField]
		public string m_comment;

		[SerializeField]
		[Header("Gizmo")]
		private bool m_drawGizmo;

		[SerializeField]
		private Color m_gizmoColor = Color.yellow;

		[SerializeField]
		[Range(0f, 4f)]
		[Header("Settings")]
		public float m_stiffnessForce = 1f;

		[SerializeField]
		[Range(0f, 2f)]
		public float m_gravityPower;

		[SerializeField]
		public Vector3 m_gravityDir = new Vector3(0f, -1f, 0f);

		[SerializeField]
		[Range(0f, 1f)]
		public float m_dragForce = 0.4f;

		[SerializeField]
		public Transform m_center;

		[SerializeField]
		public List<Transform> RootBones = new List<Transform>();

		private Dictionary<Transform, Quaternion> m_initialLocalRotationMap;

		[SerializeField]
		[Range(0f, 0.5f)]
		[Header("Collider")]
		public float m_hitRadius = 0.02f;

		[SerializeField]
		public VRMSpringBoneColliderGroup[] ColliderGroups;

		[SerializeField]
		public SpringBoneUpdateType m_updateType;

		private List<VRMSpringBoneLogic> m_verlet = new List<VRMSpringBoneLogic>();

		private List<SphereCollider> m_colliderList = new List<SphereCollider>();

		private void Awake()
		{
			Setup();
		}

		[ContextMenu("Reset bones")]
		public void Setup(bool force = false)
		{
			if (RootBones == null)
			{
				return;
			}
			if (force || m_initialLocalRotationMap == null)
			{
				m_initialLocalRotationMap = new Dictionary<Transform, Quaternion>();
			}
			else
			{
				foreach (KeyValuePair<Transform, Quaternion> item in m_initialLocalRotationMap)
				{
					item.Key.localRotation = item.Value;
				}
				m_initialLocalRotationMap.Clear();
			}
			m_verlet.Clear();
			foreach (Transform rootBone in RootBones)
			{
				if (!(rootBone != null))
				{
					continue;
				}
				foreach (Transform item2 in rootBone.transform.Traverse())
				{
					m_initialLocalRotationMap[item2] = item2.localRotation;
				}
				SetupRecursive(m_center, rootBone);
			}
		}

		public void SetLocalRotationsIdentity()
		{
			foreach (VRMSpringBoneLogic item in m_verlet)
			{
				item.Head.localRotation = Quaternion.identity;
			}
		}

		private static IEnumerable<Transform> GetChildren(Transform parent)
		{
			int i = 0;
			while (i < parent.childCount)
			{
				yield return parent.GetChild(i);
				int num = i + 1;
				i = num;
			}
		}

		private void SetupRecursive(Transform center, Transform parent)
		{
			if (parent.childCount == 0)
			{
				Vector3 vector = parent.position - parent.parent.position;
				Vector3 point = parent.position + vector.normalized * 0.07f;
				m_verlet.Add(new VRMSpringBoneLogic(center, parent, parent.worldToLocalMatrix.MultiplyPoint(point)));
			}
			else
			{
				Transform obj = GetChildren(parent).First();
				Vector3 localPosition = obj.localPosition;
				Vector3 lossyScale = obj.lossyScale;
				m_verlet.Add(new VRMSpringBoneLogic(center, parent, new Vector3(localPosition.x * lossyScale.x, localPosition.y * lossyScale.y, localPosition.z * lossyScale.z)));
			}
			foreach (Transform item in parent)
			{
				SetupRecursive(center, item);
			}
		}

		private void LateUpdate()
		{
			if (m_updateType == SpringBoneUpdateType.LateUpdate)
			{
				UpdateProcess(Time.deltaTime);
			}
		}

		private void FixedUpdate()
		{
			if (m_updateType == SpringBoneUpdateType.FixedUpdate)
			{
				UpdateProcess(Time.fixedDeltaTime);
			}
		}

		private void UpdateProcess(float deltaTime)
		{
			if (m_verlet == null || m_verlet.Count == 0)
			{
				if (RootBones == null)
				{
					return;
				}
				Setup();
			}
			m_colliderList.Clear();
			if (ColliderGroups != null)
			{
				VRMSpringBoneColliderGroup[] colliderGroups = ColliderGroups;
				foreach (VRMSpringBoneColliderGroup vRMSpringBoneColliderGroup in colliderGroups)
				{
					if (vRMSpringBoneColliderGroup != null)
					{
						VRMSpringBoneColliderGroup.SphereCollider[] colliders = vRMSpringBoneColliderGroup.Colliders;
						foreach (VRMSpringBoneColliderGroup.SphereCollider sphereCollider in colliders)
						{
							m_colliderList.Add(new SphereCollider
							{
								Position = vRMSpringBoneColliderGroup.transform.TransformPoint(sphereCollider.Offset),
								Radius = sphereCollider.Radius
							});
						}
					}
				}
			}
			float stiffnessForce = m_stiffnessForce * deltaTime;
			Vector3 external = m_gravityDir * (m_gravityPower * deltaTime);
			foreach (VRMSpringBoneLogic item in m_verlet)
			{
				item.Radius = m_hitRadius;
				item.Update(m_center, stiffnessForce, m_dragForce, external, m_colliderList);
			}
		}

		private void OnDrawGizmos()
		{
			if (!m_drawGizmo)
			{
				return;
			}
			foreach (VRMSpringBoneLogic item in m_verlet)
			{
				item.DrawGizmo(m_center, m_hitRadius, m_gizmoColor);
			}
		}
	}
}
