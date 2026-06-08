using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrailerConfigLoader : MonoBehaviour
{
	[SerializeField]
	private TrailerCamera trailerCam;

	[SerializeField]
	private BiomeManager biomeManager;

	[SerializeField]
	private SaveLoadSystem saveLoadSystem;

	[SerializeField]
	private List<Biome> availableBiomes;

	[SerializeField]
	private KeyCode loadAndApplyConfigKey = KeyCode.F1;

	[SerializeField]
	private KeyCode reloadSceneKey = KeyCode.F5;

	private string configPath = "TrailerCamConfig.json";

	private TrailerConfig config;

	private void Start()
	{
		config = JsonLoader.LoadJsonFromDataLocation<TrailerConfig>(configPath);
		if (config == null)
		{
			JsonSaver.SaveAsJson(new TrailerConfig(), configPath);
		}
	}

	private void LoadConfig()
	{
		config = JsonLoader.LoadJsonFromDataLocation<TrailerConfig>(configPath);
	}

	private void Update()
	{
		if (Input.GetKeyDown(loadAndApplyConfigKey))
		{
			LoadConfig();
			ApplyConfiguration();
		}
	}

	private void ApplyConfiguration()
	{
		if (config != null && config.biomeSe != -1)
		{
			biomeManager.SetBiomes(availableBiomes[config.biomeSe], availableBiomes[config.biomeSw], availableBiomes[config.biomeNe], availableBiomes[config.biomeNw]);
			trailerCam.startPosition = config.trailerCamStartPos;
			trailerCam.startRotation = config.trailerCamStartRot;
			trailerCam.endPosition = config.trailerCamEndPos;
			trailerCam.endRotation = config.trailerCamEndRot;
			trailerCam.transitionDuration = config.trailerCamDuration;
			trailerCam.loopType = (LoopType)config.trailerCamLoopType;
			trailerCam.ResetToStartOrientation();
			trailerCam.extraRotation = config.extraRotation;
			trailerCam.extraRotationDuration = config.extraRotationDuration;
			trailerCam.automaticallyStartExtraRotationAfter = config.automaticallyStartExtraRotationAfterSeconds;
			if (!string.IsNullOrWhiteSpace(config.loadGameName))
			{
				saveLoadSystem.LoadSaveGame(config.loadGameName);
			}
		}
	}

	private void SaveConfigFile()
	{
		TrailerConfig obj = new TrailerConfig
		{
			trailerCamStartPos = trailerCam.startPosition,
			trailerCamStartRot = trailerCam.startRotation,
			trailerCamEndPos = trailerCam.endPosition,
			trailerCamEndRot = trailerCam.endRotation,
			trailerCamDuration = trailerCam.transitionDuration,
			automaticallyStartExtraRotationAfterSeconds = trailerCam.automaticallyStartExtraRotationAfter,
			extraRotation = trailerCam.extraRotation,
			extraRotationDuration = trailerCam.extraRotationDuration
		};
		List<Biome> biomes = biomeManager.GetBiomes();
		obj.biomeSe = availableBiomes.IndexOf(biomes[0]);
		obj.biomeSw = availableBiomes.IndexOf(biomes[1]);
		obj.biomeNe = availableBiomes.IndexOf(biomes[2]);
		obj.biomeNw = availableBiomes.IndexOf(biomes[3]);
		obj.loadGameName = saveLoadSystem.defaultSaveName;
		JsonSaver.SaveAsJson(obj, configPath);
	}
}
