using UnityEngine;

namespace HQFPSTemplate
{
	public class PivotDisplayer : MonoBehaviour
	{
		[SerializeField]
		private Color m_Color = Color.red;

		[SerializeField]
		private float m_Radius = 0.06f;

		[SerializeField]
		private bool m_AlwaysDraw = true;

		private void Start()
		{
			if (!Application.isEditor)
			{
				Object.Destroy(base.gameObject);
			}
		}

		private void OnDrawGizmos()
		{
			if (m_AlwaysDraw)
			{
				DrawSphere();
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (!m_AlwaysDraw)
			{
				DrawSphere();
			}
		}

		private void DrawSphere()
		{
			Gizmos.color = m_Color;
			Gizmos.DrawSphere(base.transform.position, m_Radius);
		}
	}
}
