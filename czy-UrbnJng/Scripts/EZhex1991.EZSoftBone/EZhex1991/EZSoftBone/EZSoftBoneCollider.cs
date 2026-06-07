using UnityEngine;

namespace EZhex1991.EZSoftBone
{
	[RequireComponent(typeof(Collider))]
	public class EZSoftBoneCollider : EZSoftBoneColliderBase
	{
		[SerializeField]
		private Collider m_ReferenceCollider;

		[SerializeField]
		private float m_Margin;

		[SerializeField]
		private bool m_InsideMode;

		public Collider referenceCollider
		{
			get
			{
				if (m_ReferenceCollider == null)
				{
					m_ReferenceCollider = GetComponent<Collider>();
				}
				return m_ReferenceCollider;
			}
		}

		public float margin
		{
			get
			{
				return m_Margin;
			}
			set
			{
				m_Margin = value;
			}
		}

		public bool insideMode
		{
			get
			{
				return m_InsideMode;
			}
			set
			{
				m_InsideMode = value;
			}
		}

		public override void Collide(ref Vector3 position, float spacing)
		{
			if (referenceCollider is SphereCollider)
			{
				SphereCollider collider = referenceCollider as SphereCollider;
				if (insideMode)
				{
					EZSoftBoneUtility.PointInsideSphere(ref position, collider, spacing + margin);
				}
				else
				{
					EZSoftBoneUtility.PointOutsideSphere(ref position, collider, spacing + margin);
				}
			}
			else if (referenceCollider is CapsuleCollider)
			{
				CapsuleCollider collider2 = referenceCollider as CapsuleCollider;
				if (insideMode)
				{
					EZSoftBoneUtility.PointInsideCapsule(ref position, collider2, spacing + margin);
				}
				else
				{
					EZSoftBoneUtility.PointOutsideCapsule(ref position, collider2, spacing + margin);
				}
			}
			else if (referenceCollider is BoxCollider)
			{
				BoxCollider collider3 = referenceCollider as BoxCollider;
				if (insideMode)
				{
					EZSoftBoneUtility.PointInsideBox(ref position, collider3, spacing + margin);
				}
				else
				{
					EZSoftBoneUtility.PointOutsideBox(ref position, collider3, spacing + margin);
				}
			}
			else if (referenceCollider is MeshCollider)
			{
				if (!CheckConvex(referenceCollider as MeshCollider))
				{
					Debug.LogError("Non-Convex Mesh Collider is not supported", this);
					base.enabled = false;
				}
				else if (insideMode)
				{
					Debug.LogError("Inside Mode On Mesh Collider is not supported", this);
					insideMode = false;
				}
				else
				{
					EZSoftBoneUtility.PointOutsideCollider(ref position, referenceCollider, spacing + margin);
				}
			}
		}

		private bool CheckConvex(MeshCollider meshCollider)
		{
			if (meshCollider.sharedMesh != null)
			{
				return meshCollider.convex;
			}
			return false;
		}

		private void Reset()
		{
			m_ReferenceCollider = GetComponent<Collider>();
		}
	}
}
