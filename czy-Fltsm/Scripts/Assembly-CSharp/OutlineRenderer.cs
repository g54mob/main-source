using System.Collections.Generic;
using UnityEngine;

public class OutlineRenderer : MonoBehaviour
{
	public List<Renderer> TargetRenderers = new List<Renderer>();

	public bool AutoAddAllChildRenderers;

	private void Awake()
	{
		if (AutoAddAllChildRenderers)
		{
			TargetRenderers.AddRange(GetComponentsInChildren<Renderer>());
		}
	}

	private void OnEnable()
	{
		for (int i = 0; i < TargetRenderers.Count; i++)
		{
			OutlineRenderManager.Instance.RegisterOutlineRenderer(TargetRenderers[i]);
		}
	}

	private void OnDisable()
	{
		for (int i = 0; i < TargetRenderers.Count; i++)
		{
			OutlineRenderManager.Instance.UnregisterOutlineRenderer(TargetRenderers[i]);
		}
	}
}
