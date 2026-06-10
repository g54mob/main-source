using System;
using UnityEngine;
using UnityEngine.UI;

public class MapDuctsButtonController : ButtonController
{
	public NewFloor floor;

	public Vector2 range;

	public Image generatedImage;

	public Texture2D tex;

	public bool rebuildImage;

	private Action UpdateMapTex;

	public void Setup(NewFloor newAddress)
	{
	}

	public void UpdateMapImageEndOfFrame()
	{
	}

	public void GenerateMapImage()
	{
	}
}
