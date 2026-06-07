using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BuildingLandingPadCulling : MonoBehaviour
{
	[SerializeField]
	private List<Renderer> _cullableRenderers = new List<Renderer>();

	public void ForceCullableRenderers(bool value)
	{
		foreach (Renderer cullableRenderer in _cullableRenderers)
		{
			cullableRenderer.forceRenderingOff = value;
		}
	}

	[Button("Find All MeshRenderers", EButtonEnableMode.Always)]
	private void EditorFindAllMeshRenderers()
	{
		GetComponentsInChildren(_cullableRenderers);
	}
}
