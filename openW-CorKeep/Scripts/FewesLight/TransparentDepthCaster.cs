using System.Collections.Generic;
using UnityEngine;

public class TransparentDepthCaster : MonoBehaviour
{
	private static Material s_depthMaterial;

	public static readonly HashSet<TransparentDepthCaster> instances = new HashSet<TransparentDepthCaster>();

	private Renderer m_renderer;

	private Material[] m_originalMaterials;

	private Material[] m_depthMaterials;

	private bool m_setup;

	public static Material depthMaterial
	{
		get
		{
			if (!s_depthMaterial)
			{
				s_depthMaterial = Resources.Load<Material>("Materials/DepthMaterial");
			}
			return s_depthMaterial;
		}
	}

	public static void EnableDepthMaterials()
	{
		foreach (TransparentDepthCaster instance in instances)
		{
			instance.m_renderer.materials = instance.m_depthMaterials;
		}
	}

	public static void EnableOriginalMaterials()
	{
		foreach (TransparentDepthCaster instance in instances)
		{
			instance.m_renderer.materials = instance.m_originalMaterials;
		}
	}

	private void Setup()
	{
		if (depthMaterial == null)
		{
			Debug.LogError("Depth material was null!");
			base.enabled = false;
			instances.Remove(this);
			return;
		}
		m_renderer = GetComponent<Renderer>();
		if (m_renderer.materials == null || m_renderer.materials.Length < 1)
		{
			Debug.LogError("Unable to setup TransparentDepthCaster for renderer with no material!");
			base.enabled = false;
			instances.Remove(this);
			return;
		}
		m_originalMaterials = new Material[m_renderer.materials.Length];
		m_depthMaterials = new Material[m_renderer.materials.Length];
		for (int i = 0; i < m_depthMaterials.Length; i++)
		{
			m_originalMaterials[i] = m_renderer.materials[i];
			m_depthMaterials[i] = depthMaterial;
		}
		m_setup = true;
	}

	private void OnEnable()
	{
		if (!m_setup)
		{
			Setup();
		}
		instances.Add(this);
	}

	private void OnDisable()
	{
		instances.Remove(this);
	}
}
