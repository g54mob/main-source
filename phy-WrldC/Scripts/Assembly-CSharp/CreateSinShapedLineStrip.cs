using System;
using UnityEngine;
using VolumetricLines;

public class CreateSinShapedLineStrip : MonoBehaviour
{
	public int m_numVertices = 50;

	public Material m_volumetricLineStripMaterial;

	public Color m_color;

	public float m_start;

	public float m_end = (float)Math.PI;

	private void Start()
	{
		GameObject obj = new GameObject();
		obj.transform.parent = base.transform;
		obj.AddComponent<MeshFilter>();
		obj.AddComponent<MeshRenderer>();
		VolumetricLineStripBehavior volumetricLineStripBehavior = obj.AddComponent<VolumetricLineStripBehavior>();
		volumetricLineStripBehavior.DoNotOverwriteTemplateMaterialProperties = false;
		volumetricLineStripBehavior.TemplateMaterial = m_volumetricLineStripMaterial;
		volumetricLineStripBehavior.LineColor = m_color;
		volumetricLineStripBehavior.LineWidth = 55f;
		volumetricLineStripBehavior.LightSaberFactor = 0.83f;
		Vector3[] array = new Vector3[m_numVertices];
		for (int i = 0; i < m_numVertices; i++)
		{
			float num = Mathf.Lerp(m_start, m_end, (float)i / (float)(m_numVertices - 1));
			float y = Mathf.Sin(num);
			array[i] = base.gameObject.transform.TransformPoint(new Vector3(num, y, 0f));
		}
		volumetricLineStripBehavior.UpdateLineVertices(array);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		for (int i = 0; i < m_numVertices; i++)
		{
			float num = Mathf.Lerp(m_start, m_end, (float)i / (float)(m_numVertices - 1));
			float y = Mathf.Sin(num);
			Gizmos.DrawSphere(base.gameObject.transform.TransformPoint(new Vector3(num, y, 0f)), 5f);
		}
	}
}
