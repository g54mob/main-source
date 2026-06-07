using UnityEngine;
using VolumetricLines.Utils;

namespace VolumetricLines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteInEditMode]
	public class VolumetricLineBehavior : MonoBehaviour
	{
		[SerializeField]
		public Material m_templateMaterial;

		[SerializeField]
		private bool m_doNotOverwriteTemplateMaterialProperties;

		[SerializeField]
		private Vector3 m_startPos;

		[SerializeField]
		private Vector3 m_endPos = new Vector3(0f, 0f, 100f);

		[SerializeField]
		private Color m_lineColor;

		[SerializeField]
		private float m_lineWidth;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_lightSaberFactor;

		private Material m_material;

		private MeshFilter m_meshFilter;

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
				CreateMaterial();
				if (null != m_material)
				{
					m_lineColor = value;
					m_material.color = m_lineColor;
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
				CreateMaterial();
				if (null != m_material)
				{
					m_lineWidth = value;
					m_material.SetFloat("_LineWidth", m_lineWidth);
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
				CreateMaterial();
				if (null != m_material)
				{
					m_lightSaberFactor = value;
					m_material.SetFloat("_LightSaberFactor", m_lightSaberFactor);
				}
			}
		}

		public Vector3 StartPos
		{
			get
			{
				return m_startPos;
			}
			set
			{
				m_startPos = value;
				SetStartAndEndPoints(m_startPos, m_endPos);
			}
		}

		public Vector3 EndPos
		{
			get
			{
				return m_endPos;
			}
			set
			{
				m_endPos = value;
				SetStartAndEndPoints(m_startPos, m_endPos);
			}
		}

		private void CreateMaterial()
		{
			if (null != m_templateMaterial && null == m_material)
			{
				m_material = Object.Instantiate(m_templateMaterial);
				GetComponent<MeshRenderer>().sharedMaterial = m_material;
				SetAllMaterialProperties();
			}
		}

		private void DestroyMaterial()
		{
			if (null != m_material)
			{
				Object.DestroyImmediate(m_material);
				m_material = null;
			}
		}

		private void SetAllMaterialProperties()
		{
			SetStartAndEndPoints(m_startPos, m_endPos);
			if (null != m_material)
			{
				if (!m_doNotOverwriteTemplateMaterialProperties)
				{
					m_material.color = m_lineColor;
					m_material.SetFloat("_LineWidth", m_lineWidth);
					m_material.SetFloat("_LightSaberFactor", m_lightSaberFactor);
				}
				m_material.SetFloat("_LineScale", base.transform.GetGlobalUniformScaleForLineWidth());
			}
		}

		public void SetStartAndEndPoints(Vector3 startPoint, Vector3 endPoint)
		{
			Vector3[] vertices = new Vector3[8] { startPoint, startPoint, startPoint, startPoint, endPoint, endPoint, endPoint, endPoint };
			Vector3[] normals = new Vector3[8] { endPoint, endPoint, endPoint, endPoint, startPoint, startPoint, startPoint, startPoint };
			if (null != m_meshFilter)
			{
				Mesh sharedMesh = m_meshFilter.sharedMesh;
				if (null != sharedMesh)
				{
					sharedMesh.vertices = vertices;
					sharedMesh.normals = normals;
					sharedMesh.RecalculateBounds();
				}
			}
		}

		private void Start()
		{
			Vector3[] vertices = new Vector3[8] { m_startPos, m_startPos, m_startPos, m_startPos, m_endPos, m_endPos, m_endPos, m_endPos };
			Vector3[] normals = new Vector3[8] { m_endPos, m_endPos, m_endPos, m_endPos, m_startPos, m_startPos, m_startPos, m_startPos };
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.uv = VolumetricLineVertexData.TexCoords;
			mesh.uv2 = VolumetricLineVertexData.VertexOffsets;
			mesh.SetIndices(VolumetricLineVertexData.Indices, MeshTopology.Triangles, 0);
			mesh.RecalculateBounds();
			m_meshFilter = GetComponent<MeshFilter>();
			m_meshFilter.mesh = mesh;
			CreateMaterial();
		}

		private void OnDestroy()
		{
			DestroyMaterial();
		}

		private void Update()
		{
			if (base.transform.hasChanged && null != m_material)
			{
				m_material.SetFloat("_LineScale", base.transform.GetGlobalUniformScaleForLineWidth());
			}
		}

		private void OnValidate()
		{
			CreateMaterial();
			SetAllMaterialProperties();
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(base.gameObject.transform.TransformPoint(m_startPos), base.gameObject.transform.TransformPoint(m_endPos));
		}
	}
}
