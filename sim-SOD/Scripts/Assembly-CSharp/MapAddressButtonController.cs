using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapAddressButtonController : ButtonController
{
	public NewGameLocation gameLocation;

	public Image typeIcon;

	public Vector2 range;

	public Vector3 roughWorldPosition;

	public Image generatedImage;

	public Texture2D tex;

	public bool rebuildImage;

	private List<GameObject> spawnedMapDoors;

	private List<NewRoom> mapDoorRooms;

	private Action UpdateMapTex;

	public void Setup(NewGameLocation newAddress)
	{
	}

	public void UpdateMapImageEndOfFrame()
	{
	}

	public void GenerateMapImage()
	{
	}

	public void UnloadMapImage()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateIcon()
	{
	}

	public void UpdateTooltip()
	{
	}

	private Texture2D RotateTexture(Texture2D tex, float angle)
	{
		return null;
	}

	private Color GetPixel(Texture2D tex, float x, float y)
	{
		return default(Color);
	}

	private float Rot_x(float angle, float x, float y)
	{
		return 0f;
	}

	private float Rot_y(float angle, float x, float y)
	{
		return 0f;
	}

	public override void OnHoverStart()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public override void OnLeftDoubleClick()
	{
	}

	public override void OnRightClick()
	{
	}

	public void OpenFolder()
	{
	}

	public void MapRoute()
	{
	}

	public void DoFastTravel()
	{
	}

	public void DoFastTravelBuilding()
	{
	}

	public float GetYWeightedDistanceFromWorldPosition(Vector3 worldPos)
	{
		return 0f;
	}
}
