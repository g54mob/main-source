using System.Collections.Generic;
using UnityEngine;

public class OutlineControl : MonoBehaviour
{
	[Tooltip("ID to use when drawing the outlines of this object. Outlines occur when two adjacent pixels have different IDs")]
	public byte ID;

	[Tooltip("If true, randomly generate a random outline ID for this object at runtime.")]
	public bool UseRandomUID = true;

	[Tooltip("Should this object use the outline ID of the root transform?")]
	public bool UseRootUID;

	[Tooltip("Should the color of this object's outline copy that of the root transform?")]
	public bool UseRootColor = true;

	[Tooltip("The color to use for the outline.")]
	public Color Color;

	private List<int> OutlineMaterialIndices;

	private float FloatUID => (float)(int)ID % 255f;

	private void Awake()
	{
		OutlineMaterialIndices = new List<int>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			for (int i = 0; i < component.materials.Length; i++)
			{
				if (component.materials[i].HasProperty("_OutlineColor"))
				{
					component.materials[i] = new Material(component.materials[i]);
					OutlineMaterialIndices.Add(i);
				}
			}
		}
		if (UseRandomUID)
		{
			ID = (byte)Random.Range(0, 255);
		}
	}

	private void Start()
	{
		OutlineControl component = base.transform.root.gameObject.GetComponent<OutlineControl>();
		if (component != null)
		{
			if (UseRootUID)
			{
				ID = component.ID;
			}
			if (UseRootColor)
			{
				Color = component.Color;
			}
		}
		else if (UseRootColor || UseRootUID)
		{
			Debug.LogWarning("Root ID or Color was requested for the outline, but the root transform doesn't have an OutlineControl MonoBehaviour! Please add the component.");
		}
		Renderer component2 = GetComponent<Renderer>();
		if (!(component2 != null))
		{
			return;
		}
		new Vector4(Color.r, Color.g, Color.b, FloatUID);
		foreach (int outlineMaterialIndex in OutlineMaterialIndices)
		{
			component2.materials[outlineMaterialIndex].SetFloat("_ID", FloatUID);
			component2.materials[outlineMaterialIndex].SetColor("_OutlineColor", Color);
		}
	}
}
