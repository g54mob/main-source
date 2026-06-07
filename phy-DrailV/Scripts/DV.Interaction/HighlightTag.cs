using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class HighlightTag : MonoBehaviour
{
	[Tooltip("Optional, leave empty to use this gameObject")]
	public GameObject targetObject;

	public List<Renderer> renderers;

	public float overrideDistance;

	private void Awake()
	{
		if (renderers == null)
		{
			renderers = new List<Renderer>();
		}
		if (((targetObject != null) ? targetObject : base.gameObject).TryGetComponent<Renderer>(out var component) && !renderers.Contains(component))
		{
			renderers.Add(component);
		}
		for (int num = renderers.Count - 1; num >= 0; num--)
		{
			if (renderers[num] == null)
			{
				renderers.RemoveAt(num);
			}
		}
	}
}
