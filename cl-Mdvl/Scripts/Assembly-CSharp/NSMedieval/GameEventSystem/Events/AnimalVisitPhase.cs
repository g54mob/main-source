using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.View.Animals;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("AnimalVisitPhase", "")]
	public class AnimalVisitPhase : GameEventLinearPhaseBase
	{
		[SerializeField]
		private HashSet<AnimalInstance> animals = new HashSet<AnimalInstance>();

		[SerializeField]
		private TimeInterval timeInterval;

		[SerializeField]
		private uint newsMessageId;

		private const string fvs_animals = "animals";

		private const string fvs_timeInterval = "timeInterval";

		private const string fvs_newsMessageId = "newsMessageId";

		private bool IsEndlessEvent
		{
			get
			{
				if (base.Blueprint.DurationHours.Min == 0f)
				{
					return base.Blueprint.DurationHours.Max == 0f;
				}
				return false;
			}
		}

		public AnimalVisitPhase()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
			animals = null;
		}

		public override bool OnStart()
		{
			if (!MonoSingleton<RaidEnemySelector>.Instance.PurchaseEnemiesForAnimalRaid(out var enemiesToSpawn, base.Blueprint))
			{
				GameEventPhaseBase.Logger.Error("Purchase enemies failed");
				return false;
			}
			FVLogInfoInterpolationHandler messageBuilder;
			bool isEnabled;
			if (!IsEndlessEvent)
			{
				int randomDurationMinutes = base.Blueprint.GetRandomDurationMinutes();
				timeInterval = TimeInterval.FromNowMinutes(randomDurationMinutes);
				FVLogger logger = GameEventPhaseBase.Logger;
				messageBuilder = new FVLogInfoInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\AnimalGroup\\AnimalVisitPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Animals will leave the map in ");
					messageBuilder.AppendFormatted(randomDurationMinutes);
					messageBuilder.AppendLiteral(" minutes");
				}
				logger.Info(in messageBuilder);
			}
			else
			{
				GameEventPhaseBase.Logger.Info("Animals will not leave the map, the event is endless");
			}
			AnimalType animalType = base.Blueprint.AnimalType;
			int num = ((base.Blueprint.Count != null && base.Blueprint.UseRaidPoints) ? Math.Min(enemiesToSpawn.Count, base.Blueprint.Count.Max) : enemiesToSpawn.Count);
			animals.Clear();
			for (int i = 0; i < num; i++)
			{
				FVLogger logger2 = GameEventPhaseBase.Logger;
				messageBuilder = new FVLogInfoInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\AnimalGroup\\AnimalVisitPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Spawning animal: ");
					messageBuilder.AppendFormatted(enemiesToSpawn[i].GetID());
				}
				logger2.Info(in messageBuilder);
				BodyType bodyType = ((base.Blueprint.GenderDistribution == 0f || !(UnityEngine.Random.Range(0f, 1f) >= base.Blueprint.GenderDistribution)) ? BodyType.Male : BodyType.Female);
				float lifePhasePercent = UnityEngine.Random.Range(0f, 0.95f);
				AnimalInstance animal = MonoSingleton<AnimalManager>.Instance.SpawnAnimal(enemiesToSpawn[i].GetID(), Vector3.zero, bodyType, -1, lifePhasePercent);
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
				animals.Add(animal);
			}
			NPCStartPositionManager.SetStartPositionsForAgents(animals.First().WalkableModel, animals.ToList());
			SetAnimalsSpawnPoints();
			Subscribe();
			ShowStartText();
			if (animalType == AnimalType.WildAggressive)
			{
				MonoSingleton<GameSpeedManager>.Instance.SetSpeedPause();
				newsMessageId = GameEventUtil.PublishNews(base.EventInstance, 0);
			}
			return true;
		}

		private void SetAnimalsSpawnPoints()
		{
			foreach (AnimalInstance animal in animals)
			{
				animal.SpawnPosition = animal.GetPosition();
			}
		}

		public override void OnLoaded(bool fromSave)
		{
			Subscribe();
		}

		private void Subscribe()
		{
			MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent += OnAnimalRemoved;
			MonoSingleton<NewsManager>.Instance.OnDialogClosed += OnNewsDialogClosed;
		}

		private void OnNewsDialogClosed(uint newsId, int chosenOptionIndex)
		{
			if (newsId == newsMessageId && chosenOptionIndex == 1)
			{
				MonoSingleton<GlobalWarningMessagesManager>.Instance.JumpToAggressiveAnimal();
			}
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent -= OnAnimalRemoved;
			}
			if (MonoSingleton<NewsManager>.IsInstantiated())
			{
				MonoSingleton<NewsManager>.Instance.OnDialogClosed -= OnNewsDialogClosed;
			}
		}

		protected override bool TickShouldEnd()
		{
			if (IsEndlessEvent)
			{
				return true;
			}
			if (animals.Count == 0)
			{
				return true;
			}
			return timeInterval.HasEnded;
		}

		public override void OnEnd()
		{
			Unsubscribe();
			if (!IsEndlessEvent)
			{
				RetreatAnimals();
				ShowEndText();
			}
		}

		private void RetreatAnimals()
		{
			if (animals == null)
			{
				return;
			}
			foreach (AnimalInstance animal in animals)
			{
				AnimalType animalType = animal.AnimalType;
				if (animalType != AnimalType.Domestic && animalType != AnimalType.Pet)
				{
					animal.LeaveMap();
				}
			}
		}

		private void OnAnimalRemoved(AnimalInstance animalInstance)
		{
			if (base.Blueprint == null || !MonoSingleton<GameEventSystem>.Instance.IsEventRunning(base.Blueprint.GetID()))
			{
				if (base.Blueprint == null)
				{
					GameEventPhaseBase.Logger.Error("OnAnimalRemoved: Blueprint is NULL.");
					return;
				}
				FVLogger logger = GameEventPhaseBase.Logger;
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\AnimalGroup\\AnimalVisitPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnAnimalRemoved: event ");
					messageBuilder.AppendFormatted(base.Blueprint.GetID());
					messageBuilder.AppendLiteral(" is not running.");
				}
				logger.Error(in messageBuilder);
			}
			else if (animals == null)
			{
				GameEventPhaseBase.Logger.Error("OnAnimalRemoved: animals is NULL.");
			}
			else if (animals.Contains(animalInstance))
			{
				animals.Remove(animalInstance);
			}
		}

		private void ShowStartText()
		{
			if (string.IsNullOrEmpty(base.Blueprint.MessageStart) || animals == null || !animals.Any())
			{
				return;
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText(base.Blueprint.MessageStart);
			if (!string.IsNullOrEmpty(text) && animals != null)
			{
				string localizedName = AnimalUtils.GetLocalizedName(animals.First().Blueprint);
				text = text.Replace("<number>", animals.Count.ToString()).Replace("<animal>", localizedName);
				AnimalView view = MonoSingleton<AnimalManager>.Instance.GetView(animals.FirstOrDefault((AnimalInstance animal) => animal != null));
				MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(text, view, follow: true);
			}
		}

		private void ShowEndText()
		{
			string text = (animals.Any((AnimalInstance animalInstance) => animalInstance.AnimalType == AnimalType.Wild || animalInstance.AnimalType == AnimalType.WildAggressive) ? MonoSingleton<LocalizationController>.Instance.GetText(base.Blueprint.MessageEnd) : MonoSingleton<LocalizationController>.Instance.GetText(base.Blueprint.MessageEndAlternative));
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (text.Contains("<animal>"))
			{
				string localizedName = AnimalUtils.GetLocalizedName(animals.First((AnimalInstance animal) => animal != null).Blueprint);
				text = text.Replace("<animal>", localizedName);
			}
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("animals", animals);
			serializer.Write("timeInterval", timeInterval);
			serializer.Write("newsMessageId", newsMessageId);
		}

		public AnimalVisitPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			animals = deserializer.ReadObjectHashSet<AnimalInstance>("animals");
			timeInterval = deserializer.ReadObject<TimeInterval>("timeInterval");
			newsMessageId = deserializer.ReadUInt("newsMessageId");
		}
	}
}
