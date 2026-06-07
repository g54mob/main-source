using System;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class FarmingMinigameButton : DraggableButton
{
	[NonSerialized]
	public MinigamePanelFarming parentMap;

	public Coord coord;

	public Image terrainImage;

	public Image topLayerImage;

	public Image cropImage;

	public NaturalResource plantedResource;

	public bool isWaterSource;

	public float waterAmount;

	public float grassAmount;

	public float cropAmount;

	public FarmingMinigameButton[] neighbors = new FarmingMinigameButton[4];

	public bool pendingWaterFull;

	public float pendingWaterAmount;

	public float tempWaterAmount;

	public float pendingGrassAmount;

	private float displayedCropAmount = -1f;

	private int hasDisplayedFullyGrown;

	public float maxWater;

	public float flowMultiplier;

	private static readonly Color wateredDirtColor = new Color(0.52f, 0.5f, 0.46f, 1f);

	public FarmingTerrainType terrainType { get; private set; }

	public void Init(int x, int y)
	{
		coord = new Coord(x, y);
	}

	public void PostProcess()
	{
		if (isWaterSource)
		{
			waterAmount = StartupManager.Instance.waterPressure;
		}
		else
		{
			waterAmount += pendingWaterAmount;
			if (waterAmount < 0f)
			{
				waterAmount = 0f;
			}
		}
		pendingWaterAmount = 0f;
		UpdateColors();
	}

	public void PostProcessGrass()
	{
		pendingGrassAmount *= waterAmount;
		grassAmount += pendingGrassAmount;
		grassAmount = Mathf.Clamp01(grassAmount);
		pendingGrassAmount = 0f;
		UpdateColors();
	}

	public void UpdateColors()
	{
		if (terrainType == FarmingTerrainType.Trench)
		{
			terrainImage.color = Color.white;
			if (isWaterSource)
			{
				topLayerImage.color = Color.white;
			}
			else
			{
				topLayerImage.color = new Color(1f, 1f, 1f, waterAmount);
			}
		}
		else if (terrainType == FarmingTerrainType.Ground)
		{
			terrainImage.color = Color.Lerp(Color.white, wateredDirtColor, waterAmount / maxWater);
			topLayerImage.color = new Color(1f, 1f, 1f, grassAmount);
		}
		else if (terrainType == FarmingTerrainType.Farm)
		{
			terrainImage.color = Color.Lerp(Color.white, wateredDirtColor, waterAmount / maxWater);
			topLayerImage.color = Color.white;
		}
		else
		{
			terrainImage.color = Color.white;
			topLayerImage.color = Color.white;
		}
		if (plantedResource == NaturalResource.None)
		{
			return;
		}
		if (cropAmount >= 1f)
		{
			if (hasDisplayedFullyGrown != 2)
			{
				cropImage.sprite = IconManager.SpriteForPlantedResource(plantedResource);
				hasDisplayedFullyGrown = 2;
			}
		}
		else if (hasDisplayedFullyGrown != 1 && hasDisplayedFullyGrown != 1)
		{
			cropImage.sprite = IconManager.Instance.growingCrops;
			hasDisplayedFullyGrown = 1;
		}
	}

	public void SetPlantedCrop(NaturalResource r)
	{
		plantedResource = r;
		UpdateIcon();
	}

	public void SetTerrainType(FarmingTerrainType t)
	{
		terrainType = t;
		UpdateTerrainTypeMetadata();
		UpdateIcon();
		UpdateColors();
	}

	private void UpdateTerrainTypeMetadata()
	{
		if (terrainType == FarmingTerrainType.Rock)
		{
			flowMultiplier = 0f;
			maxWater = 0f;
		}
		else if (terrainType == FarmingTerrainType.Farm)
		{
			flowMultiplier = 0.25f;
			maxWater = 0.5f;
		}
		else if (terrainType == FarmingTerrainType.Ground)
		{
			flowMultiplier = 0.5f;
			maxWater = 0.25f;
		}
		else
		{
			flowMultiplier = 1f;
			maxWater = 2f;
		}
	}

	public void UpdateIcon()
	{
		switch (terrainType)
		{
		case FarmingTerrainType.Trench:
			terrainImage.sprite = IconManager.SpriteForTerrainTexture(FarmingTextureType.Trench);
			topLayerImage.sprite = IconManager.SpriteForTerrainTexture(FarmingTextureType.Water);
			break;
		case FarmingTerrainType.Farm:
			terrainImage.sprite = IconManager.SpriteForTerrainTexture(FarmingTextureType.Dirt);
			topLayerImage.sprite = IconManager.SpriteForTerrainTexture(FarmingTextureType.Farm);
			break;
		case FarmingTerrainType.Ground:
			terrainImage.sprite = IconManager.SpriteForTerrainTexture(FarmingTextureType.Dirt);
			topLayerImage.sprite = IconManager.SpriteForTerrainTexture(FarmingTextureType.Grass);
			break;
		case FarmingTerrainType.Rock:
			terrainImage.sprite = IconManager.SpriteForTerrainTexture(FarmingTextureType.Dirt);
			topLayerImage.sprite = IconManager.SpriteForTerrainTexture(FarmingTextureType.Rock);
			break;
		}
		cropImage.enabled = plantedResource != NaturalResource.None;
	}

	public void LoadFromData(fsData data)
	{
		if (data.TryAsList(out var result) && result.Count >= 3 && result[0].TryAsInt(out var i))
		{
			int num = i / 100;
			int num2 = i % 100;
			plantedResource = (NaturalResource)num;
			terrainType = (FarmingTerrainType)num2;
			UpdateTerrainTypeMetadata();
			float num3 = (float)result[1].AsDouble;
			if (num3 < 0f)
			{
				isWaterSource = true;
				waterAmount = maxWater;
			}
			else
			{
				waterAmount = num3;
			}
			grassAmount = (float)result[2].AsDouble;
			if (result.Count >= 4)
			{
				fsData fsData2 = result[3];
				cropAmount = (float)fsData2.AsDouble;
			}
			else
			{
				cropAmount = 0f;
			}
		}
	}

	public fsData GetData()
	{
		List<fsData> list = new List<fsData>();
		int num = (int)(terrainType + (int)plantedResource * 100);
		list.Add(new fsData(num));
		float num2 = waterAmount;
		if (isWaterSource)
		{
			num2 = -1f;
		}
		list.Add(new fsData(num2));
		list.Add(new fsData(grassAmount));
		if (cropAmount > 0f)
		{
			list.Add(new fsData(cropAmount));
		}
		return new fsData(list);
	}
}
