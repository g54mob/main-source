using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class BlockBodyModelButton3D : OutlineButton3D
{
	private List<BlockBodyModelButton3D> siblingsBlockButton3D;

	public BlockModel BlockModel => BlockBodyModel.ParentBlockModel;

	public BlockBodyModel BlockBodyModel { get; set; }

	protected override void Start()
	{
		base.Start();
		siblingsBlockButton3D = new List<BlockBodyModelButton3D>();
		BlockBodyModelButton3D[] componentsInChildren = base.gameObject.GetBlockView().GetComponentsInChildren<BlockBodyModelButton3D>();
		foreach (BlockBodyModelButton3D blockBodyModelButton3D in componentsInChildren)
		{
			if (blockBodyModelButton3D != this)
			{
				siblingsBlockButton3D.Add(blockBodyModelButton3D);
			}
		}
	}

	protected override void SetColor(Color color)
	{
		base.SetColor(color);
		foreach (BlockBodyModelButton3D item in siblingsBlockButton3D)
		{
			item.FromSiblingSetColor(color);
		}
	}

	private void FromSiblingSetColor(Color color)
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
