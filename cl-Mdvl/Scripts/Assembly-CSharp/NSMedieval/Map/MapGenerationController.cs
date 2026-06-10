using System;
using System.Collections;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model.MapNew;
using NSMedieval.Tools;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Map
{
	public class MapGenerationController : MonoSingleton<MapGenerationController>
	{
		[NonSerialized]
		private MapGenerationParameters mapToGenerate;

		[NonSerialized]
		private MapGenerationParameters mapGenerating;

		[NonSerialized]
		private MapGenerationParameters lastMapGenerated;

		public bool IsMapGenerationSuccessful { get; private set; }

		public bool IsMapGenerationFinished { get; private set; }

		[field: NonSerialized]
		public MapGenerator MapGenerator { get; set; }

		public event Action MapGenerationStartedEvent;

		public event Action<bool> MapGenerationFinishedEvent;

		public void MapGenerationStarted()
		{
			IsMapGenerationSuccessful = false;
			IsMapGenerationFinished = false;
			this.MapGenerationStartedEvent?.Invoke();
		}

		public void MapGenerationFinished(bool success)
		{
			IsMapGenerationSuccessful = success;
			IsMapGenerationFinished = true;
			this.MapGenerationFinishedEvent?.Invoke(success);
		}

		private void Start()
		{
			StartCoroutine(MapGenerationRefreshLoop());
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			StopAllCoroutines();
			this.MapGenerationStartedEvent = null;
			this.MapGenerationFinishedEvent = null;
		}

		public void StartMapGeneration(string mapSeed)
		{
			GameStartController gameStartController = MonoSingleton<GameStartController>.Instance;
			if (string.IsNullOrEmpty(gameStartController?.SelectedMapType) || gameStartController?.SelectedMapSize == null || MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data == null)
			{
				return;
			}
			MapGenerationParameters mapGenerationParameters = new MapGenerationParameters(Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(gameStartController.SelectedMapType), gameStartController.SelectedMapSize, mapSeed, MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.VillagePosition);
			bool isEnabled;
			if (mapGenerationParameters.Equals(mapToGenerate))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(82, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("StartMapGeneration: won't start because the map is already scheduled to generate ");
					messageBuilder.AppendFormatted(mapGenerationParameters);
					messageBuilder.AppendLiteral(" ");
				}
				Log.Debug(messageBuilder);
				return;
			}
			if (mapGenerationParameters.Equals(mapGenerating))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(71, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("StartMapGeneration: won't start because the map is already generating ");
					messageBuilder.AppendFormatted(mapGenerationParameters);
					messageBuilder.AppendLiteral(" ");
				}
				Log.Debug(messageBuilder);
				return;
			}
			if (mapGenerationParameters.Equals(lastMapGenerated))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(77, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("StartMapGeneration: won't start because the last map generated is the same: ");
					messageBuilder.AppendFormatted(lastMapGenerated);
					messageBuilder.AppendLiteral(" ");
				}
				Log.Debug(messageBuilder);
				return;
			}
			FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationController.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Scheduled map generation of ");
				messageBuilder2.AppendFormatted(mapGenerationParameters);
			}
			Log.Info(messageBuilder2);
			mapToGenerate = mapGenerationParameters;
			MapGenerator?.StopMapGenerationThread();
		}

		private IEnumerator MapGenerationRefreshLoop()
		{
			while (true)
			{
				if (mapToGenerate == null || mapGenerating != null || (MapGenerator != null && !MapGenerator.ThreadFinished))
				{
					yield return new WaitForEndOfFrame();
					continue;
				}
				mapGenerating = mapToGenerate;
				mapToGenerate = null;
				if (MapGenerator == null)
				{
					MapGenerator = new MapGenerator();
				}
				GridDataIndexTools.InitialiseFastMethods(mapGenerating.MapSize.Width, mapGenerating.MapSize.Height, mapGenerating.MapSize.Length);
				yield return MapGenerator.GenerateMapCoroutine(mapGenerating);
				lastMapGenerated = mapGenerating;
				mapGenerating = null;
			}
		}

		public void DisposeMapGenerator()
		{
			MapGenerator?.Dispose();
			MapGenerator = null;
		}
	}
}
