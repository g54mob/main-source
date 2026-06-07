using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialSwitcher : MonoBehaviour
{
	[Serializable]
	public class MaterialWeight
	{
		public Material material;

		public float weight;
	}

	[Serializable]
	public class RendererMaterials
	{
		public Renderer targetRenderer;

		public List<MaterialWeight> materials;
	}

	public List<RendererMaterials> rendererMaterialsList;

	private void Reset()
	{
	}

	private void OnEnable()
	{
	}

	private void FetchRenderer()
	{
	}
}
