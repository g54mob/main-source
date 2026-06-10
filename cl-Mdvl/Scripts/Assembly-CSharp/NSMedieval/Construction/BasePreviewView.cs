using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class BasePreviewView : MonoBehaviour
	{
		[SerializeField]
		private List<MeshRenderer> previewMeshRenderers = new List<MeshRenderer>();

		[NonSerialized]
		private MaterialPropertyBlock materialPropertyBlock;

		private List<GameObject> gameObjects = new List<GameObject>();

		public void ColorBlueprint(float shaderValue)
		{
			if (materialPropertyBlock == null)
			{
				materialPropertyBlock = new MaterialPropertyBlock();
			}
			materialPropertyBlock.SetFloat("_materialChange", shaderValue);
			foreach (MeshRenderer previewMeshRenderer in previewMeshRenderers)
			{
				previewMeshRenderer.SetPropertyBlock(materialPropertyBlock);
			}
		}

		public void UpdateLayers(int layer)
		{
			foreach (GameObject gameObject in gameObjects)
			{
				gameObject.layer = layer;
			}
		}

		private void Start()
		{
			foreach (MeshRenderer previewMeshRenderer in previewMeshRenderers)
			{
				gameObjects.Add(previewMeshRenderer.gameObject);
			}
		}
	}
}
