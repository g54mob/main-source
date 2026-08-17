using System;
using Assets.Scripts.Game.MapGeneration;
using Assets.Scripts.Game.Spawning.New.Timelines;
using Assets.Scripts.MapGeneration.ProceduralTiles;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.Localization;

public class StageData : ScriptableObject
{
	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public MapEdgeFillType mapEdgeFillType;

	public Material waterMaterial;

	public GameObject waterSplashFx;

	public Material grassMaterial;

	public int grassPerChunk;

	public Material[] flatMaterials;

	public Material m_fillMiddle;

	public Material m_fillTop;

	public Material m_fillMiddleEdge;

	public Material m_fillTopEdge;

	public Material m_stairs;

	public Material triplanarMaterial;

	public GameObject particles;

	public Material skybox;

	public float fogIntensity;

	public Color fogColor;

	public Color ambienceColor;

	public Color lightColor;

	public float lightIntensity;

	public StageTimeline stageTimeline;

	public bool isWaterDamage;

	public MapParameters mapParameters;

	public RandomMapObject[] randomMapObjects;

	public StageTilePrefabs stageTilePrefabs;

	public TerrainData proceduralTerrainData;

	public NoiseData proceduralNoiseData;

	public float proceduralMapScale;

	public float farClipPlane;

	public ChallengeData[] challenges;

	public string GetName()
	{
		if (localizedName != null)
		{
			return localizedName.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetDescription()
	{
		if (localizedDescription != null)
		{
			return localizedDescription.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public Material GetSideMaterial(EFillType eFillType, bool useEdgeTextures = false)
	{
		if (eFillType != EFillType.Top && eFillType != EFillType.Both)
		{
			if (useEdgeTextures)
			{
				return m_fillMiddleEdge;
			}
			return m_fillMiddle;
		}
		if (useEdgeTextures)
		{
			return m_fillTopEdge;
		}
		return m_fillTop;
	}

	public Material GetTopMaterial()
	{
		Material[] array = flatMaterials;
		int num = UnityEngine.Random.Range(0, array.Length);
		if (num < array.Length)
		{
			return array[num];
		}
		return (Material)(object)new IndexOutOfRangeException();
	}

	public unsafe void ApplyFogAndSky(Light sunLight)
	{
		//IL_0014: Expected O, but got Ref
		//IL_0024: Invalid comparison between I4 and F4
		//IL_0093: Expected O, but got Ref
		//IL_005e: Expected O, but got Ref
		RenderSettings.skybox = skybox;
		Color color = default(Color);
		RenderSettings.ambientLight = (Color)(&color);
		if (0f < fogIntensity)
		{
			RenderSettings.fog = true;
			RenderSettings.fogDensity = fogIntensity;
			RenderSettings.fogColor = (Color)(&color);
			color = fogColor;
		}
		else
		{
			RenderSettings.fog = false;
			color = ambienceColor;
		}
		sunLight.color = (Color)(&color);
		sunLight.intensity = lightIntensity;
	}

	public GameObject SpawnParticles()
	{
		if (!(particles != null))
		{
			return null;
		}
		return UnityEngine.Object.Instantiate(particles);
	}

	public StageData()
	{
		//IL_0065: Expected O, but got I4
		//IL_0038: Expected O, but got F4
		grassPerChunk = 500;
		ambienceColor = (Color)1061079774;
		_ = 1061079774;
		_ = 1061079774;
		_ = 1065353216;
		Color color = MyColorUtility.StringToColor("#FFF4D6");
		lightIntensity = 1f;
		proceduralMapScale = 1f;
		lightColor = (Color)color.r;
		farClipPlane = 800f;
		base._002Ector();
	}
}
