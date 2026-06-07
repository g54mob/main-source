using UnityEngine;
using VolumetricLines.Utils;

namespace VolumetricLines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteInEditMode]
	public class VolumetricLineStripBehavior : MonoBehaviour
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

		private Material m_material;

		private MeshFilter m_meshFilter;

		[SerializeField]
		private Vector3[] m_lineVertices;

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

		public Vector3[] LineVertices => m_lineVertices;

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
			UpdateLineVertices(m_lineVertices);
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

		public void UpdateLineVertices(Vector3[] m_newSetOfVertices)
		{
			if (m_newSetOfVertices == null)
			{
				return;
			}
			if (m_newSetOfVertices.Length < 3)
			{
				Debug.LogError("Add at least 3 vertices to the VolumetricLineStrip");
				return;
			}
			m_lineVertices = m_newSetOfVertices;
			Vector3[] array = new Vector3[m_lineVertices.Length * 2 + 4];
			int[] array2 = new int[(m_lineVertices.Length * 2 + 2) * 3];
			int num = 0;
			int num2 = 0;
			array[num++] = m_lineVertices[0];
			array[num++] = m_lineVertices[0];
			for (int i = 0; i < m_lineVertices.Length; i++)
			{
				array[num++] = m_lineVertices[i];
				array[num++] = m_lineVertices[i];
				array2[num2++] = num - 2;
				array2[num2++] = num - 3;
				array2[num2++] = num - 4;
				array2[num2++] = num - 1;
				array2[num2++] = num - 2;
				array2[num2++] = num - 3;
			}
			array[num++] = m_lineVertices[m_lineVertices.Length - 1];
			array[num++] = m_lineVertices[m_lineVertices.Length - 1];
			array2[num2++] = num - 2;
			array2[num2++] = num - 3;
			array2[num2++] = num - 4;
			array2[num2++] = num - 1;
			array2[num2++] = num - 2;
			array2[num2++] = num - 3;
			Vector2[] array3 = new Vector2[array.Length];
			Vector2[] array4 = new Vector2[array.Length];
			int num3 = 0;
			int num4 = 0;
			array3[num3++] = new Vector2(1f, 0f);
			array3[num3++] = new Vector2(1f, 1f);
			array3[num3++] = new Vector2(0.5f, 0f);
			array3[num3++] = new Vector2(0.5f, 1f);
			array4[num4++] = new Vector2(1f, -1f);
			array4[num4++] = new Vector2(1f, 1f);
			array4[num4++] = new Vector2(0f, -1f);
			array4[num4++] = new Vector2(0f, 1f);
			for (int j = 1; j < m_lineVertices.Length - 1; j++)
			{
				if ((j & 1) == 1)
				{
					array3[num3++] = new Vector2(0.5f, 0f);
					array3[num3++] = new Vector2(0.5f, 1f);
				}
				else
				{
					array3[num3++] = new Vector2(0.5f, 0f);
					array3[num3++] = new Vector2(0.5f, 1f);
				}
				array4[num4++] = new Vector2(0f, 1f);
				array4[num4++] = new Vector2(0f, -1f);
			}
			array3[num3++] = new Vector2(0.5f, 0f);
			array3[num3++] = new Vector2(0.5f, 1f);
			array3[num3++] = new Vector2(0f, 0f);
			array3[num3++] = new Vector2(0f, 1f);
			array4[num4++] = new Vector2(0f, 1f);
			array4[num4++] = new Vector2(0f, -1f);
			array4[num4++] = new Vector2(1f, 1f);
			array4[num4++] = new Vector2(1f, -1f);
			Vector3[] array5 = new Vector3[array.Length];
			Vector4[] array6 = new Vector4[array.Length];
			int num5 = 0;
			int num6 = 0;
			array5[num5++] = m_lineVertices[1];
			array5[num5++] = m_lineVertices[1];
			array5[num5++] = m_lineVertices[1];
			array5[num5++] = m_lineVertices[1];
			array6[num6++] = m_lineVertices[1];
			array6[num6++] = m_lineVertices[1];
			array6[num6++] = m_lineVertices[1];
			array6[num6++] = m_lineVertices[1];
			for (int k = 1; k < m_lineVertices.Length - 1; k++)
			{
				array5[num5++] = m_lineVertices[k - 1];
				array5[num5++] = m_lineVertices[k - 1];
				array6[num6++] = m_lineVertices[k + 1];
				array6[num6++] = m_lineVertices[k + 1];
			}
			array5[num5++] = m_lineVertices[m_lineVertices.Length - 2];
			array5[num5++] = m_lineVertices[m_lineVertices.Length - 2];
			array5[num5++] = m_lineVertices[m_lineVertices.Length - 2];
			array5[num5++] = m_lineVertices[m_lineVertices.Length - 2];
			array6[num6++] = m_lineVertices[m_lineVertices.Length - 2];
			array6[num6++] = m_lineVertices[m_lineVertices.Length - 2];
			array6[num6++] = m_lineVertices[m_lineVertices.Length - 2];
			array6[num6++] = m_lineVertices[m_lineVertices.Length - 2];
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.normals = array5;
			mesh.tangents = array6;
			mesh.uv = array3;
			mesh.uv2 = array4;
			mesh.SetIndices(array2, MeshTopology.Triangles, 0);
			mesh.RecalculateBounds();
			GetComponent<MeshFilter>().mesh = mesh;
		}

		private void Start()
		{
			UpdateLineVertices(m_lineVertices);
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
