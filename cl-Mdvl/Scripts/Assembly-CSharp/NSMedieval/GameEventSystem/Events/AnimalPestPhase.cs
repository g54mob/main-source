using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("AnimalPestPhase", "")]
	public class AnimalPestPhase : SingleExecutePhaseBase
	{
		[SerializeField]
		private uint newsMessageId;

		public AnimalPestPhase()
		{
		}

		public override void OnLoaded(bool fromSave)
		{
			Subscribe();
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
		}

		public override void OnEnd()
		{
			Unsubscribe();
		}

		protected override void Execute()
		{
			if (!MonoSingleton<RaidEnemySelector>.Instance.PurchaseEnemiesForAnimalRaid(out var enemiesToSpawn, base.Blueprint))
			{
				Log.Error("Purchase enemies failed", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\AnimalPestPhase.cs");
				return;
			}
			AnimalType animalType = base.Blueprint.AnimalType;
			int num = ((base.Blueprint.Count != null && base.Blueprint.UseRaidPoints) ? Math.Min(enemiesToSpawn.Count, base.Blueprint.Count.Max) : enemiesToSpawn.Count);
			Log.Debug("Got " + num + " animal(s)", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\AnimalPestPhase.cs");
			Room room = VillageManager.ActiveVillage.Map.RoomDetection.FindBestRoomSafe(RoomCheck, RoomScore);
			if (room == null)
			{
				Log.Error("Room could not be found, this should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\AnimalPestPhase.cs");
				Dispose();
				return;
			}
			for (int i = 0; i < num; i++)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\AnimalPestPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Spawning animal: ");
					messageBuilder.AppendFormatted(enemiesToSpawn[i].GetID());
				}
				Log.Debug(messageBuilder);
				BodyType bodyType = ((base.Blueprint.GenderDistribution == 0f || !(UnityEngine.Random.Range(0f, 1f) >= base.Blueprint.GenderDistribution)) ? BodyType.Male : BodyType.Female);
				float lifePhasePercent = UnityEngine.Random.Range(0f, 0.95f);
				AnimalInstance animal = MonoSingleton<AnimalManager>.Instance.SpawnAnimal(enemiesToSpawn[i].GetID(), room.BelowFloorNodes.PickRandom().WorldPosition, bodyType, -1, lifePhasePercent);
				animal.SetAnimalType(animalType);
				if (base.Blueprint.HasAnimalType)
				{
					animal.SetAnimalType(animalType);
				}
				animal.SetName(string.Empty);
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					animal.GetGoapAgent()?.StartTicker();
				});
			}
			if (animalType == AnimalType.WildAggressive)
			{
				MonoSingleton<GameSpeedManager>.Instance.SetSpeedPause();
				newsMessageId = GameEventUtil.PublishNews(base.EventInstance, 0);
			}
		}

		public static bool RoomCheck(Room room)
		{
			int num = 0;
			FVLogDebugInterpolationHandler messageBuilder;
			bool isEnabled;
			foreach (MapNode wallNode in room.WallNodes)
			{
				if (wallNode.VoxelType == null)
				{
					continue;
				}
				if (wallNode.VoxelType.GetID() != "Dirt" && wallNode.VoxelType.GetID() != "WetlandDirt" && wallNode.VoxelType.GetID() != "Rocky")
				{
					messageBuilder = new FVLogDebugInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\AnimalPestPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Room Node (");
						messageBuilder.AppendFormatted(wallNode.Position);
						messageBuilder.AppendLiteral("): ");
						messageBuilder.AppendFormatted(wallNode.VoxelType.GetID());
					}
					Log.Debug(messageBuilder);
				}
				else
				{
					num++;
				}
			}
			FVLogger logger = GameEventPhaseBase.Logger;
			messageBuilder = new FVLogDebugInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\AnimalPestPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Room Wall voxels result: ");
				messageBuilder.AppendFormatted(num);
			}
			logger.Debug(in messageBuilder);
			if (num <= 0)
			{
				return false;
			}
			foreach (ResourcePileInstance allPileInstance in MonoSingleton<ResourcePileManager>.Instance.AllPileInstances)
			{
				if (!(allPileInstance.Blueprint.Nutrition <= 0f) && room.GetResourceCount(allPileInstance.Blueprint.GetID()) > 0)
				{
					isEnabled = true;
					return isEnabled;
				}
			}
			return false;
		}

		private float RoomScore(Room room)
		{
			float num = 0f;
			foreach (ResourcePileInstance allPileInstance in MonoSingleton<ResourcePileManager>.Instance.AllPileInstances)
			{
				if (!(allPileInstance.Blueprint.Nutrition <= 0f))
				{
					num += allPileInstance.Blueprint.Nutrition * (float)room.GetResourceCount(allPileInstance.Blueprint.GetID());
				}
			}
			return num;
		}

		private void Subscribe()
		{
			MonoSingleton<NewsManager>.Instance.OnDialogClosed += OnNewsDialogClosed;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<NewsManager>.IsInstantiated())
			{
				MonoSingleton<NewsManager>.Instance.OnDialogClosed -= OnNewsDialogClosed;
			}
		}

		private void OnNewsDialogClosed(uint newsId, int chosenOptionIndex)
		{
			if (newsId == newsMessageId && chosenOptionIndex == 1)
			{
				MonoSingleton<GlobalWarningMessagesManager>.Instance.JumpToAggressiveAnimal();
			}
		}

		public AnimalPestPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
