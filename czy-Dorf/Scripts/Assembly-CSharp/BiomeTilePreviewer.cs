using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BiomeTilePreviewer : MonoBehaviour
{
	[SerializeField]
	private Biome previewBiome;

	[SerializeField]
	private Vector2Int previewTileAmount;

	[SerializeField]
	private Vector2 previewTileOffset;

	[SerializeField]
	private TileGenerator tileGenerator;

	[SerializeField]
	private BiomeManager biomeManager;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private QuestSystemConfiguration defaultQuestSystemConfiguration;

	[SerializeField]
	private Material skyboxMat;

	[SerializeField]
	private Vector3 hsvOffsetColor2 = new Vector3(0f, -20f, 7f);

	[SerializeField]
	private Material waterMat;

	private List<Tile> previewTiles;

	[SerializeField]
	private KeyCode previewButton;

	private void CreatePreviewTiles()
	{
		biomeManager.Debug_OverrideBiomes(previewBiome);
		if (previewTiles != null)
		{
			foreach (Tile previewTile in previewTiles)
			{
				previewTile.DestroyTile();
			}
		}
		previewTiles = new List<Tile>();
		for (int i = 0; i < previewTileAmount.y; i++)
		{
			for (int j = 0; j < previewTileAmount.x; j++)
			{
				Tile tile = tileGenerator.GenerateTile(null, 0.2f);
				if (tile is QuestTile questTile)
				{
					questTile.QuestWatcher.HideQuest();
				}
				tile.transform.parent = base.transform;
				tile.transform.localPosition = new Vector3((float)j * previewTileOffset.x, 0f, (float)i * previewTileOffset.y);
				if ((bool)previewBiome)
				{
					biomeManager.ApplyBiome(tile, previewBiome);
				}
				previewTiles.Add(tile);
			}
		}
		Color cameraBackgroundColor;
		Color.RGBToHSV(cameraBackgroundColor = previewBiome.CameraBackgroundColor, out var H, out var S, out var V);
		Vector3 vector = new Vector3(H + hsvOffsetColor2.x / 100f, S + hsvOffsetColor2.y / 100f, V + hsvOffsetColor2.z / 100f);
		Color value = Color.HSVToRGB(vector.x, vector.y, vector.z);
		skyboxMat.SetColor("_Color1", cameraBackgroundColor);
		skyboxMat.SetColor("_Color2", value);
		foreach (ColorOption colorOption in previewBiome.WaterColorSet.colorOptions)
		{
			waterMat.SetColor(colorOption.propertyName, colorOption.possibleColors.Evaluate(0f));
		}
	}

	private void Start()
	{
		sceneLoader.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
		questManager.SetConfiguration(defaultQuestSystemConfiguration);
		questManager.Reset(null);
		CreatePreviewTiles();
	}

	private void Update()
	{
		if (Input.GetKeyDown(previewButton))
		{
			CreatePreviewTiles();
		}
	}
}
