using System;
using System.Collections.Generic;
using KitchenEditor;
using Platforms;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "GameData", menuName = "Kitchen/GameData Helper", order = 2)]
	public class GameDataConstructor : KitchenObject, IGameDataObjectMap
	{
		public Dictionary<int, GameDataObject> All;

		public List<GameDataObject> GameDataObjects;

		public List<ProcessGraph> ProcessGraphs;

		public List<UnlockGraph> UnlockGraphs;

		public List<ResearchGraph> ResearchGraphs;

		public GameDifficultySettings Difficulty;

		public StringSubstitutor StringSubstitutions;

		public ReferableObjects ReferableObjects;

		public List<FontLookup> Fonts;

		public AchievementConfiguration AchievementConfiguration;

		public T Get<T>(int id) where T : GameDataObject
		{
			return (T)All[id];
		}

		public T Get<T>(T obj) where T : GameDataObject
		{
			return (T)All[obj.ID];
		}

		public void Populate()
		{
		}

		public GameData BuildGameData()
		{
			GameData gameData = new GameData(1000);
			foreach (GameDataObject gameDataObject in GameDataObjects)
			{
				try
				{
					gameDataObject.SetupForGame();
					Locale currentLocale = Localisation.CurrentLocale;
					gameDataObject.Localise(currentLocale, StringSubstitutions);
					if (gameDataObject is GlobalLocalisation globalLocalisation)
					{
						gameData.GlobalLocalisation = globalLocalisation;
					}
				}
				catch (Exception message)
				{
					Debug.LogError("Failed to initialise GDO " + gameDataObject.name);
					Debug.LogError(message);
				}
			}
			if (!Application.isEditor || Application.isPlaying)
			{
				foreach (FontLookup font in Fonts)
				{
					try
					{
						Locale currentLocale2 = Localisation.CurrentLocale;
						font.SetLocale(currentLocale2);
					}
					catch (Exception message2)
					{
						Debug.LogError("Failed to initialise Font " + font.name);
						Debug.LogError(message2);
					}
				}
			}
			foreach (ProcessGraph processGraph in ProcessGraphs)
			{
				try
				{
					processGraph.AddData(this);
				}
				catch (Exception message3)
				{
					Debug.LogError("Failed to initialise graph " + processGraph.name);
					Debug.LogError(message3);
				}
			}
			foreach (UnlockGraph unlockGraph in UnlockGraphs)
			{
				try
				{
					unlockGraph.AddData(this);
				}
				catch (Exception message4)
				{
					Debug.LogError("Failed to initialise graph " + unlockGraph.name);
					Debug.LogError(message4);
				}
			}
			foreach (ResearchGraph researchGraph in ResearchGraphs)
			{
				try
				{
					researchGraph.AddData(this);
				}
				catch (Exception message5)
				{
					Debug.LogError("Failed to initialise graph " + researchGraph.name);
					Debug.LogError(message5);
				}
			}
			gameData.Substitutions = StringSubstitutions;
			gameData.Difficulty = Difficulty;
			gameData.ReferableObjects = ReferableObjects;
			gameData.Fonts = Fonts;
			foreach (GameDataObject gameDataObject2 in GameDataObjects)
			{
				if (gameData.Objects.ContainsKey(gameDataObject2.ID))
				{
					Debug.LogWarning($"Duplicate key found for object with ID {gameDataObject2.ID}! This duplicate will not be added...");
					continue;
				}
				gameData.Objects.Add(gameDataObject2.ID, gameDataObject2);
				if (gameDataObject2 is IHasPrefab hasPrefab)
				{
					gameData.Prefabs.Add(gameDataObject2.ID, hasPrefab.Prefab);
				}
			}
			foreach (GameDataObject gameDataObject3 in GameDataObjects)
			{
				gameDataObject3.SetupFinal();
			}
			gameData.InitialiseViews();
			if (Platform.Current != null)
			{
				Platform.Current.LoadAchievements(AchievementConfiguration);
			}
			return gameData;
		}
	}
}
