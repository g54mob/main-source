using UnityEngine;

namespace VRM
{
	[DisallowMultipleComponent]
	public class VRMBindposeGizmo : MonoBehaviour
	{
		[SerializeField]
		private Mesh m_target;

		[SerializeField]
		private float[] m_boneWeights;

		[SerializeField]
		[Range(0.1f, 1f)]
		private float m_gizmoSize = 0.02f;

		[SerializeField]
		private Color m_meshGizmoColor = Color.yellow;

		[SerializeField]
		private Color m_bindGizmoColor = Color.red;

		private void Reset()
		{
			SkinnedMeshRenderer component = GetComponent<SkinnedMeshRenderer>();
			if (!(component == null))
			{
				m_target = component.sharedMesh;
			}
		}

		private void OnDrawGizmos()
		{
			if (m_target == null)
			{
				return;
			}
			Gizmos.matrix = base.transform.localToWorldMatrix;
			if (m_target.bindposes != null && m_target.bindposes.Length != 0)
			{
				if (m_boneWeights == null || m_boneWeights.Length != m_target.bindposes.Length)
				{
					m_boneWeights = new float[m_target.bindposes.Length];
					BoneWeight[] boneWeights = m_target.boneWeights;
					for (int i = 0; i < boneWeights.Length; i++)
					{
						BoneWeight boneWeight = boneWeights[i];
						if (boneWeight.weight0 > 0f)
						{
							m_boneWeights[boneWeight.boneIndex0] += boneWeight.weight0;
						}
						if (boneWeight.weight1 > 0f)
						{
							m_boneWeights[boneWeight.boneIndex1] += boneWeight.weight1;
						}
						if (boneWeight.weight2 > 0f)
						{
							m_boneWeights[boneWeight.boneIndex2] += boneWeight.weight2;
						}
						if (boneWeight.weight3 > 0f)
						{
							m_boneWeights[boneWeight.boneIndex3] += boneWeight.weight3;
						}
					}
				}
				Gizmos.color = m_meshGizmoColor;
				Gizmos.DrawWireMesh(m_target);
				for (int j = 0; j < m_target.bindposes.Length; j++)
				{
					Color color = m_bindGizmoColor * m_boneWeights[j];
					color.a = 1f;
					Gizmos.color = color;
					Gizmos.matrix = base.transform.localToWorldMatrix * m_target.bindposes[j].inverse;
					Gizmos.DrawWireCube(Vector3.zero, Vector3.one * m_gizmoSize);
				}
			}
			else
			{
				Gizmos.color = Color.gray;
				Gizmos.DrawWireMesh(m_target);
			}
		}
	}
}
