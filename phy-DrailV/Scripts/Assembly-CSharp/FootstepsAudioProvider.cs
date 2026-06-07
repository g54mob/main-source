using System.Collections.Generic;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

public class FootstepsAudioProvider : AFootstepsAudioProvider
{
	public FootstepsAudioScriptableObject data;

	private Dictionary<string, FootstepsAudioScriptableObject.SurfaceType> surfacesDictionary = new Dictionary<string, FootstepsAudioScriptableObject.SurfaceType>
	{
		{
			"defaultMaterial_GRASS",
			FootstepsAudioScriptableObject.SurfaceType.Grass
		},
		{
			"defaultMaterial_FOREST",
			FootstepsAudioScriptableObject.SurfaceType.Forest
		},
		{
			"defaultMaterial_GRAVEL",
			FootstepsAudioScriptableObject.SurfaceType.Gravel
		},
		{
			"defaultMaterial_BALLAST",
			FootstepsAudioScriptableObject.SurfaceType.Ballast
		},
		{
			"defaultMaterial_ROCK",
			FootstepsAudioScriptableObject.SurfaceType.Rock
		},
		{
			"defaultMaterial_LIQUID",
			FootstepsAudioScriptableObject.SurfaceType.Liquid
		},
		{
			"defaultMaterial_WOOD",
			FootstepsAudioScriptableObject.SurfaceType.Wood
		},
		{
			"defaultMaterial_METAL",
			FootstepsAudioScriptableObject.SurfaceType.Metal
		},
		{
			"defaultMaterial_SCRAP",
			FootstepsAudioScriptableObject.SurfaceType.Scrap
		},
		{
			"defaultMaterial_SNOW",
			FootstepsAudioScriptableObject.SurfaceType.Snow
		},
		{
			"defaultMaterial_PINENEEDLES",
			FootstepsAudioScriptableObject.SurfaceType.PineNeedles
		},
		{
			"defaultMaterial_YARD",
			FootstepsAudioScriptableObject.SurfaceType.Yard
		},
		{
			"defaultMaterial_ASPHALT",
			FootstepsAudioScriptableObject.SurfaceType.Asphalt
		}
	};

	private Dictionary<int, FootstepsAudioScriptableObject.SurfaceType> terrainTextureIndexToSurfaceType = new Dictionary<int, FootstepsAudioScriptableObject.SurfaceType>
	{
		{
			0,
			FootstepsAudioScriptableObject.SurfaceType.Rock
		},
		{
			1,
			FootstepsAudioScriptableObject.SurfaceType.Rock
		},
		{
			2,
			FootstepsAudioScriptableObject.SurfaceType.Rock
		},
		{
			3,
			FootstepsAudioScriptableObject.SurfaceType.Gravel
		},
		{
			4,
			FootstepsAudioScriptableObject.SurfaceType.Grass
		},
		{
			5,
			FootstepsAudioScriptableObject.SurfaceType.Grass
		},
		{
			6,
			FootstepsAudioScriptableObject.SurfaceType.Grass
		},
		{
			7,
			FootstepsAudioScriptableObject.SurfaceType.Yard
		},
		{
			8,
			FootstepsAudioScriptableObject.SurfaceType.Grass
		},
		{
			9,
			FootstepsAudioScriptableObject.SurfaceType.Forest
		},
		{
			10,
			FootstepsAudioScriptableObject.SurfaceType.Forest
		},
		{
			11,
			FootstepsAudioScriptableObject.SurfaceType.PineNeedles
		},
		{
			12,
			FootstepsAudioScriptableObject.SurfaceType.Grass
		},
		{
			13,
			FootstepsAudioScriptableObject.SurfaceType.Liquid
		},
		{
			14,
			FootstepsAudioScriptableObject.SurfaceType.Liquid
		},
		{
			15,
			FootstepsAudioScriptableObject.SurfaceType.Grass
		}
	};

	public override FootstepsAudioScriptableObject Data => data;

	public override Dictionary<string, FootstepsAudioScriptableObject.SurfaceType> SurfacesDictionary => surfacesDictionary;

	public override Dictionary<int, FootstepsAudioScriptableObject.SurfaceType> TerrainTextureIndexToSurfaceType => terrainTextureIndexToSurfaceType;

	public override void Play(AudioClip clip, Vector3 position, float volume, float pitch, Transform parent)
	{
		clip.Play(position, volume, pitch, 0f, 1f, 500f, default(AudioSourceCurves), null, parent);
	}

	public override bool IsPlayerAtWaterSurface(Vector3 footstepPosition)
	{
		float waterLevel = LevelInfo.WaterLevel;
		if (footstepPosition.y < waterLevel)
		{
			return footstepPosition.y + 1f > waterLevel;
		}
		return false;
	}

	public override float SamplePuddle(Vector3 footstepPosition)
	{
		Vector3 vector = ((SingletonBehaviour<WorldMover>.Instance != null) ? WorldMover.currentMove : Vector3.zero);
		float num = ((SingletonBehaviour<WeatherDriver>.Instance != null) ? ((float)SingletonBehaviour<WeatherDriver>.Instance.WetnessValue) : 0f);
		if (!SingletonBehaviour<PuddleSettings>.Instance)
		{
			return 0f;
		}
		return SingletonBehaviour<PuddleSettings>.Instance.SamplePuddles(footstepPosition - vector) * num;
	}
}
