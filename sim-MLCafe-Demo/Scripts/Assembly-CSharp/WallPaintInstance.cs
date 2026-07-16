using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallPaintInstance : MonoBehaviour
{
	[SerializeField]
	private Color defaultWallColor = new Color(0.1849056f, 0.1364114f, 0.153313f, 1f);

	[SerializeField]
	private Color appliedColor = Color.black;

	[SerializeField]
	private Color[] colorPallette;

	[SerializeField]
	private string targetShaderProperty = "_Color";

	public List<MeshRenderer> targetRenderer = new List<MeshRenderer>();

	public WallPaintSaveData saveData;

	public void Init(Vector2Int room, WallComponent.WallFaceDirection wall, int wallIndex)
	{
		saveData = new WallPaintSaveData();
		saveData.roomPosition = room;
		saveData.wall = wall;
		saveData.wallIndex = wallIndex;
		saveData.wallColor = defaultWallColor;
		ApplyColor(defaultWallColor);
	}

	public void Paint(Color color)
	{
		ApplyColor(color);
	}

	private void ApplyColor(Color color)
	{
		if (targetRenderer.Count == 0)
		{
			return;
		}
		targetRenderer = targetRenderer.Where((MeshRenderer x) => x != null).ToList();
		foreach (MeshRenderer item in targetRenderer)
		{
			if (!(item == null))
			{
				item.material.SetColor(targetShaderProperty, color);
			}
		}
		appliedColor = color;
		saveData.wallColor = appliedColor;
	}
}
