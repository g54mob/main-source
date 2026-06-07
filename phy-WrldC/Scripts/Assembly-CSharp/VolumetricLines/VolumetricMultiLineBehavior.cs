using UnityEngine;

namespace VolumetricLines
{
	public class VolumetricMultiLineBehavior : MonoBehaviour
	{
		[SerializeField]
		public Material m_templateMaterial;

		[SerializeField]
		private bool m_doNotOverwriteTemplateMaterialProperties;

		[SerializeField]
		private Color m_lineColor;

		[SerializeField]
		private float m_lineWidth;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_lightSaberFactor;

		[SerializeField]
		private Vector3[] m_lineVertices;

		private VolumetricLineBehavior[] m_volumetricLines;

		public Material TemplateMaterial
		{
			get
			{
				return m_templateMaterial;
			}
			set
			{
				m_templateMaterial = value;
			}
		}

		public bool DoNotOverwriteTemplateMaterialProperties
		{
			get
			{
				return m_doNotOverwriteTemplateMaterialProperties;
			}
			set
			{
				m_doNotOverwriteTemplateMaterialProperties = value;
			}
		}

		public Color LineColor
		{
			get
			{
				return m_lineColor;
			}
			set
			{
				m_lineColor = value;
				if (m_volumetricLines == null)
				{
					return;
				}
				for (int i = 0; i < m_volumetricLines.Length; i++)
				{
					if (null != m_volumetricLines[i] && (bool)m_volumetricLines[i])
					{
						m_volumetricLines[i].LineColor = value;
					}
				}
			}
		}

		public float LineWidth
		{
			get
			{
				return m_lineWidth;
			}
			set
			{
				m_lineWidth = value;
				if (m_volumetricLines == null)
				{
					return;
				}
				for (int i = 0; i < m_volumetricLines.Length; i++)
				{
					if (null != m_volumetricLines[i] && (bool)m_volumetricLines[i])
					{
						m_volumetricLines[i].LineWidth = value;
					}
				}
			}
		}

		public float LightSaberFactor
		{
			get
			{
				return m_lightSaberFactor;
			}
			set
			{
				m_lightSaberFactor = value;
				if (m_volumetricLines == null)
				{
					return;
				}
				for (int i = 0; i < m_volumetricLines.Length; i++)
				{
					if (null != m_volumetricLines[i] && (bool)m_volumetricLines[i])
					{
						m_volumetricLines[i].LightSaberFactor = value;
					}
				}
			}
		}

		public void CreateAllVolumetricLines()
		{
			if (m_volumetricLines == null)
			{
				m_volumetricLines = new VolumetricLineBehavior[m_lineVertices.Length - 1];
				for (int i = 0; i < m_lineVertices.Length - 1; i++)
				{
					int num = i;
					GameObject obj = new GameObject("multiline" + num);
					obj.transform.SetParent(base.gameObject.transform);
					obj.transform.localPosition = Vector3.zero;
					obj.transform.localRotation = Quaternion.identity;
					VolumetricLineBehavior volumetricLineBehavior = obj.AddComponent<VolumetricLineBehavior>();
					volumetricLineBehavior.TemplateMaterial = TemplateMaterial;
					volumetricLineBehavior.DoNotOverwriteTemplateMaterialProperties = DoNotOverwriteTemplateMaterialProperties;
					volumetricLineBehavior.LineWidth = LineWidth;
					volumetricLineBehavior.LineColor = LineColor;
					volumetricLineBehavior.LightSaberFactor = LightSaberFactor;
					volumetricLineBehavior.StartPos = m_lineVertices[i];
					volumetricLineBehavior.EndPos = m_lineVertices[i + 1];
					m_volumetricLines[i] = volumetricLineBehavior;
				}
			}
		}

		public void DestroyAllVolumetricLines()
		{
			if (m_volumetricLines == null)
			{
				return;
			}
			for (int i = 0; i < m_volumetricLines.Length; i++)
			{
				if (!(null == m_volumetricLines[i]) && (bool)m_volumetricLines[i])
				{
					GameObject gameObject = m_volumetricLines[i].gameObject;
					if ((bool)gameObject)
					{
						Object.Destroy(gameObject);
					}
				}
			}
			m_volumetricLines = null;
		}

		public void UpdateLineVertices(Vector3[] newSetOfVertices)
		{
			DestroyAllVolumetricLines();
			m_lineVertices = newSetOfVertices;
			CreateAllVolumetricLines();
		}

		private void SetAllMaterialProperties()
		{
			LineColor = LineColor;
			LineWidth = LineWidth;
			LightSaberFactor = LightSaberFactor;
		}

		private void Start()
		{
			CreateAllVolumetricLines();
		}

		private void OnDestroy()
		{
			DestroyAllVolumetricLines();
		}

		private void OnValidate()
		{
			SetAllMaterialProperties();
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			if (m_lineVertices != null)
			{
				for (int i = 0; i < m_lineVertices.Length - 1; i++)
				{
					Gizmos.DrawLine(base.gameObject.transform.TransformPoint(m_lineVertices[i]), base.gameObject.transform.TransformPoint(m_lineVertices[i + 1]));
				}
			}
		}
	}
}
