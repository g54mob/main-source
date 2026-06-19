using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ShadersLayerColorTableUpdater : MonoBehaviour
{
	public TileTypeColorTable tileTypeColorTable;

	private List<int> colorShaderIds = new List<int>();

	private List<Color> colors = new List<Color>();

	public BiomesTable biomesTable;

	private readonly int biomeStartsShaderID = Shader.PropertyToID("biomeStarts");

	private readonly int biomeEndsShaderID = Shader.PropertyToID("biomeEnds");

	private readonly int biomeStartAnglesShaderID = Shader.PropertyToID("biomeStartAngles");

	private readonly int biomeEndAnglesShaderID = Shader.PropertyToID("biomeEndAngles");

	private void Awake()
	{
		InitColorIds();
		UpdateTilesetColors();
		if (!Application.isPlaying)
		{
			UpdateBiomeParameters();
		}
	}

	private void InitColorIds()
	{
		colorShaderIds.Clear();
		colors.Clear();
		for (int i = 0; i < tileTypeColorTable.tileSetColors.Count; i++)
		{
			int pugMapTileset = (int)tileTypeColorTable.tileSetColors[i].pugMapTileset;
			foreach (TileTypeColorTable.TileColor tileColor in tileTypeColorTable.tileSetColors[i].tileColors)
			{
				string text = tileColor.tileType.ToString() + pugMapTileset;
				colorShaderIds.Add(Shader.PropertyToID(text));
				colors.Add(tileColor.color);
			}
		}
	}

	private bool UpdateTilesetColors()
	{
		bool flag = false;
		int num = 0;
		for (int i = 0; i < tileTypeColorTable.tileSetColors.Count; i++)
		{
			foreach (TileTypeColorTable.TileColor tileColor in tileTypeColorTable.tileSetColors[i].tileColors)
			{
				if (colorShaderIds.Count <= num || colors.Count <= num || tileColor.color != colors[num])
				{
					num++;
					flag = true;
					break;
				}
				Shader.SetGlobalColor(colorShaderIds[num], tileColor.color);
				num++;
			}
		}
		if (colorShaderIds.Count == num)
		{
			return !flag;
		}
		return false;
	}

	private void UpdateBiomeParameters()
	{
		List<float> list = new List<float>();
		List<float> list2 = new List<float>();
		List<float> list3 = new List<float>();
		List<float> list4 = new List<float>();
		for (int i = 0; i < 75; i++)
		{
			list.Add(0f);
			list2.Add(0f);
			list3.Add(0f);
			list4.Add(0f);
		}
		foreach (BiomesTable.BiomeLayers biomeLayer in biomesTable.biomeLayers)
		{
			float num = biomeLayer.biomeParameters[0].angleWidth - 10f;
			float num2 = 0f;
			float num3 = num2 + 5f + num;
			if (biomeLayer.biomeParameters.Count == 1)
			{
				num2 = 0f;
				num3 = 360f;
			}
			int num4 = 0;
			for (int j = 0; j < biomeLayer.biomeParameters.Count; j++)
			{
				BiomesTable.BiomeParameters value = biomeLayer.biomeParameters[j];
				value.angleWitdhPerBiome = biomeLayer.biomeParameters[0].angleWidth;
				value.startAngle = num2;
				value.endAngle = num3;
				value.endAngle = num3;
				num4++;
				num = ((num4 < biomeLayer.biomeParameters.Count) ? (biomeLayer.biomeParameters[num4].angleWidth - 10f) : 0f);
				num2 = num3 + 5f;
				num3 = num2 + 5f + num;
				list[(int)value.biome] = value.start;
				list2[(int)value.biome] = value.end;
				list3[(int)value.biome] = value.startAngle;
				list4[(int)value.biome] = value.endAngle;
				biomeLayer.biomeParameters[j] = value;
			}
		}
		Shader.SetGlobalFloatArray(biomeStartsShaderID, list);
		Shader.SetGlobalFloatArray(biomeEndsShaderID, list2);
		Shader.SetGlobalFloatArray(biomeStartAnglesShaderID, list3);
		Shader.SetGlobalFloatArray(biomeEndAnglesShaderID, list4);
	}
}
