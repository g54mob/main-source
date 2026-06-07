using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class OutlineButton3D : Button3D
{
	protected List<Outline> outlines;

	protected override void Start()
	{
		base.Start();
		outlines = new List<Outline>();
		Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>(includeInactive: true);
		foreach (Renderer renderer in componentsInChildren)
		{
			if (!(renderer is SkinnedMeshRenderer))
			{
				Outline outline = renderer.gameObject.GetComponent<Outline>();
				if (outline == null)
				{
					outline = renderer.gameObject.AddComponent<Outline>();
				}
				outline.objectLayerMask = LayerNames.Button3DMask;
				outline.enabled = false;
				outlines.Add(outline);
			}
		}
	}

	protected override void SetColor(Color color)
	{
		foreach (Outline outline in outlines)
		{
			if (color != originalColor)
			{
				outline.color = Util.OutlineColorParser(color);
				outline.enabled = true;
			}
			else
			{
				outline.enabled = false;
			}
		}
	}
}
