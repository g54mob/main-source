using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FolioPin : MonoBehaviour
{
	public FolioSpec.PinSpec spec;

	public Image image;

	[Readonly]
	public bool localized;

	[HideInInspector]
	public bool touched;

	[NonSerialized]
	public bool dynamicPosition;

	public RectTransform rt
	{
		get
		{
			return GetComponent<RectTransform>();
		}
	}

	private void OnEnable()
	{
		if (spec != null && spec.mesh != null)
		{
			CanvasRenderer component = GetComponent<CanvasRenderer>();
			component.SetMaterial(spec.material, null);
			component.SetMesh(spec.mesh);
			component.cull = false;
		}
	}

	private void OnDisable()
	{
		if (spec != null && spec.mesh != null)
		{
			CanvasRenderer component = GetComponent<CanvasRenderer>();
			if (component != null)
			{
				component.cull = true;
			}
		}
	}
}
