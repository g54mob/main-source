using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class LoadingState : State<GameManager>
{
	private class LoadingAction
	{
		public string Name { get; set; }

		public Func<IEnumerator> Action { get; set; }

		public float ActionTime { get; set; }

		public float ActionWeight { get; set; }

		public int ActionIterations { get; set; }
	}

	private class LoadingActionComparer : IComparer<LoadingAction>
	{
		public int Compare(LoadingAction x, LoadingAction y)
		{
			return y.ActionTime.CompareTo(x.ActionTime);
		}
	}

	private GenericCollection<Properties> schematicsPropertiesCollection;

	private GenericCollection<Properties> materialsPropertiesCollection;

	private List<LoadingAction> loadingActions;

	public static LoadingState Instance { get; }

	static LoadingState()
	{
		Instance = new LoadingState();
	}

	private LoadingState()
	{
	}

	public override void Start(GameManager GAME)
	{
		schematicsPropertiesCollection = new GenericCollection<Properties>();
		materialsPropertiesCollection = new GenericCollection<Properties>();
		loadingActions = new List<LoadingAction>();
		int schematicsCount = GetSchematicsCount();
		int num = GetThumbnailsCount(PathNames.CampignLevelThumbnails) / 5;
		int num2 = GetThumbnailsCount(PathNames.UserLevelTemplates) / 5;
		int num3 = GetThumbnailsCount(PathNames.UserLevels) / 5;
		int num4 = GetFlagsCount(PathNames.FlagTextures) / 5;
		int iterations = 2 + num4;
		int iterations2 = 1 + schematicsCount / 2;
		int iterations3 = 4 + num + num2 + num3;
		int iterations4 = 9 + schematicsCount / 5;
		AddLoadingAction(() => LoadGroupA(), "GroupA", 1f, 2);
		AddLoadingAction(() => LoadFlags(), "Flags", 8f, iterations);
		AddLoadingAction(() => LoadSchematics(GAME), "Schematics", 55f, iterations2);
		AddLoadingAction(() => LoadGroupB(), "GroupB", 3f, 4);
		AddLoadingAction(() => LoadThumbnails(), "Thumbnails", 10f, iterations3);
		AddLoadingAction(() => LoadGroupC(), "GroupC", 1f, 2);
		AddLoadingAction(() => PopulatePools(), "PopulatePools", 18f, iterations4);
		AddLoadingAction(() => GAME.GUIManager.Initialize(GAME), "GUIInitialize", 4f);
		IEnumerator LoadFlags()
		{
			IEnumerator loadEnumerator = LoadFlagTextures(GAME.FlagTextureCollection, PathNames.FlagTextures);
			while (loadEnumerator.MoveNext())
			{
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForEndOfFrame();
		}
		IEnumerator LoadGroupA()
		{
			LoadOptions(GAME);
			LoadLEOptions(GAME);
			LoadLanguages(GAME);
			yield return new WaitForEndOfFrame();
			LoadSchematicsProperties(GAME);
			LoadMaterialsProperties(GAME);
			yield return new WaitForEndOfFrame();
		}
		IEnumerator LoadGroupB()
		{
			LoadDevCreationsParts(GAME);
			LoadUserCreationsParts(GAME);
			LoadCreationsPartsFromSchematics(GAME);
			LoadMenuCreations(GAME);
			yield return new WaitForEndOfFrame();
			LoadInventory(GAME);
			LoadQuickInventory(GAME);
			LoadCategories(GAME);
			yield return new WaitForEndOfFrame();
			LoadUserLevelParts(GAME);
			LoadLECategories(GAME);
			LoadLEQuickInventory(GAME);
			LoadSavedCreations(GAME, PathNames.UserCreations, CreationModel.CreationPlace.User);
			LoadBestCreations(GAME, PathNames.BestCreationsCampaign);
			LoadBestCreations(GAME, PathNames.BestCreationsSandbox);
			yield return new WaitForEndOfFrame();
			LoadLevelsByDirectory(GAME.CampaignLevelModelCollection, PathNames.CampaignLevels, LevelModel.LevelPlace.Campaign);
			LoadLevelsByDirectory(GAME.SandboxLevelModelCollection, PathNames.SandboxLevels, LevelModel.LevelPlace.Sandbox);
			LoadLevelsByDirectory(GAME.TutorialLevelModelCollection, PathNames.TutorialLevels, LevelModel.LevelPlace.Tutorial);
			LoadLevelsByDirectory(GAME.TemplateLevelModelCollection, PathNames.TemplateLevels, LevelModel.LevelPlace.Template);
			LoadLevelsByDirectory(GAME.DefenderLevelModelCollection, PathNames.DefenderLevels, LevelModel.LevelPlace.Defender);
			LoadLevelsByDirectory(GAME.UserAndWorkshopLevelModelCollection, PathNames.UserLevelTemplates, LevelModel.LevelPlace.New);
			LoadLevelsByDirectory(GAME.UserAndWorkshopLevelModelCollection, PathNames.UserLevels, LevelModel.LevelPlace.User);
			yield return new WaitForEndOfFrame();
		}
		IEnumerator LoadGroupC()
		{
			LoadAllSteamWorkshopContent(GAME);
			yield return new WaitForEndOfFrame();
			LoadUserProfile(GAME);
			LoadTutorialResources(GAME);
			CreateTutorialCampaignModel(GAME);
			CreateSandboxCampaignModel(GAME);
			CreateCampaignStructModelByData(GAME);
			CheckContentHashes(GAME);
			yield return new WaitForEndOfFrame();
		}
		IEnumerator LoadThumbnails()
		{
			IEnumerator loadEnumerator = LoadLevelThumbnails(GAME.LevelThumbnailCollection, PathNames.CampignLevelThumbnails);
			while (loadEnumerator.MoveNext())
			{
				yield return new WaitForEndOfFrame();
			}
			loadEnumerator = LoadLevelThumbnails(GAME.UserAndWorkshopLevelThumbnailCollection, PathNames.UserLevelTemplates);
			while (loadEnumerator.MoveNext())
			{
				yield return new WaitForEndOfFrame();
			}
			loadEnumerator = LoadLevelThumbnails(GAME.UserAndWorkshopLevelThumbnailCollection, PathNames.UserLevels);
			while (loadEnumerator.MoveNext())
			{
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForEndOfFrame();
		}
		IEnumerator PopulatePools()
		{
			IEnumerator loadEnumerator = PopulateObjectPools(GAME);
			while (loadEnumerator.MoveNext())
			{
				yield return new WaitForEndOfFrame();
			}
			loadEnumerator = AudioEffectsManager.Instance.PopulateAudioSourcePool();
			while (loadEnumerator.MoveNext())
			{
				yield return new WaitForEndOfFrame();
			}
			loadEnumerator = UIAudioEffectsManager.Instance.PopulateAudioSourcePool();
			while (loadEnumerator.MoveNext())
			{
				yield return new WaitForEndOfFrame();
			}
			loadEnumerator = VisualEffectsManager.Instance.PopulateVisualEffectsPool();
			while (loadEnumerator.MoveNext())
			{
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForEndOfFrame();
		}
	}

	public override void Enter(GameManager GAME)
	{
		GAME.StartCoroutine(ExecuteLoadingActions(GAME));
	}

	public override void Execute(GameManager GAME)
	{
	}

	public override void Exit(GameManager GAME)
	{
		GAME.OptionsModel.ApplyOptions(shouldApplyLanguageToo: false);
		GAME.GUIManager.LoadCreationView.RefreshOrderBy();
		GAME.GUIManager.LoadLevelView.RefreshOrderBy();
		GAME.StartupGame.HideLoadingPanel();
	}

	private void AddLoadingAction(Func<IEnumerator> action, string name, float weight = 1f, int iterations = 1)
	{
		loadingActions.Add(new LoadingAction
		{
			Name = name,
			Action = action,
			ActionWeight = weight,
			ActionIterations = iterations
		});
	}

	private IEnumerator ExecuteLoadingActions(GameManager gameManager)
	{
		yield return new WaitForEndOfFrame();
		float totalActionTime = 0f;
		float totalActionWeight = 0f;
		float accumulatedActionWeight = 0f;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < loadingActions.Count; i++)
		{
			totalActionWeight += loadingActions[i].ActionWeight;
		}
		for (int j = 0; j < loadingActions.Count; j++)
		{
			float startTime = Time.realtimeSinceStartup;
			int iterationsCounter = 0;
			IEnumerator loadingActionEnumerator = loadingActions[j].Action();
			while (loadingActionEnumerator.MoveNext())
			{
				float num = Mathf.Clamp((float)iterationsCounter++ / (float)loadingActions[j].ActionIterations, 0f, 1f);
				float num2 = accumulatedActionWeight + loadingActions[j].ActionWeight * num;
				float num3 = 0.05f + 0.95f * (num2 / totalActionWeight);
				gameManager.StartupGame.SetLoadingProgress(num3);
				Debug.Log($"[{Mathf.CeilToInt(num3 * 100f):00}%] = {j} - {loadingActions[j].Name} - {iterationsCounter}");
				yield return new WaitForEndOfFrame();
			}
			loadingActions[j].ActionTime = Time.realtimeSinceStartup - startTime;
			totalActionTime += loadingActions[j].ActionTime;
			accumulatedActionWeight += loadingActions[j].ActionWeight;
			gameManager.StartupGame.SetLoadingProgress(0.05f + 0.95f * (accumulatedActionWeight / totalActionWeight));
			stringBuilder.Append($"[{loadingActions[j].ActionTime:00.00}]({iterationsCounter:00} > {loadingActions[j].ActionIterations:00}): {loadingActions[j].Name}").AppendLine();
			yield return new WaitForEndOfFrame();
		}
		Debug.Log(stringBuilder.ToString());
		stringBuilder.Clear();
		for (int k = 0; k < loadingActions.Count; k++)
		{
			float num4 = loadingActions[k].ActionTime / totalActionTime * 100f;
			stringBuilder.Append($"[{num4:00.00} %]: {loadingActions[k].Name}").AppendLine();
		}
		Debug.Log(stringBuilder.ToString());
		gameManager.StartupGame.SetLoadingProgress(1f);
		if (Application.isEditor || SteamManager.Initialized)
		{
			gameManager.ChangeState(MenuState.Instance);
			yield break;
		}
		GameManager.Instance.StartupGame.HideLoadingPanel();
		string text = LanguagesManager.Instance.GetText("message.header.menu.authentication", "Could not connect to Steam");
		string text2 = LanguagesManager.Instance.GetText("message.info.menu.authentication", "You must be logged into Steam and have the game in order to play.");
		GUIManager.Instance.ShowMessageBox(text, text2, delegate
		{
			Application.Quit();
		}, isCancelEnabled: false);
	}

	private void LoadSchematicsProperties(GameManager GAME)
	{
		string text = ((!File.Exists(PathNames.SchematicsProperties)) ? PropertiesBuilder.PopulatePropertiesCollectionFromCSVFile(schematicsPropertiesCollection, PathNames.SchematicsPropertiesAES, isFileEncrypted: true) : PropertiesBuilder.PopulatePropertiesCollectionFromCSVFile(schematicsPropertiesCollection, PathNames.SchematicsProperties, isFileEncrypted: false));
		if (text != GAME.ContentHashData.GetSchematicPropertiesHash())
		{
			GAME.IsInvalidSchOrMatPropertiesHashes = true;
			Debug.LogError("Schematics Properties content hash is not equal!");
		}
	}

	private void LoadMaterialsProperties(GameManager GAME)
	{
		if (PropertiesBuilder.PopulatePropertiesCollectionFromCSVFile(materialsPropertiesCollection, PathNames.MaterialsPropertiesAES, isFileEncrypted: true) != GAME.ContentHashData.GetMaterialPropertiesHash())
		{
			GAME.IsInvalidSchOrMatPropertiesHashes = true;
			Debug.LogError("Materials Properties content hash is not equal!");
		}
		foreach (Properties allItem in materialsPropertiesCollection.GetAllItems())
		{
			MaterialSchematic materialSchematic = new MaterialSchematic(allItem);
			GAME.MaterialSchematicCollection.AddMaterialSchematic(materialSchematic);
		}
	}

	private void CheckContentHashes(GameManager gameManager)
	{
		gameManager.InvalidSchematicHashes.RemoveAllProperties();
		gameManager.InvalidLevelModelHashes.RemoveAllProperties();
		Properties schematicHashes = gameManager.ContentHashData.GetSchematicHashes();
		bool flag = true;
		foreach (Schematic allSchematic in gameManager.SchematicCollection.GetAllSchematics())
		{
			if (!schematicHashes.HasProperty(allSchematic.Id))
			{
				gameManager.InvalidSchematicHashes.AddProperty(allSchematic.Id, "New schematic");
				flag = false;
			}
			else if (schematicHashes.GetProperty(allSchematic.Id) != allSchematic.HashSHA256)
			{
				gameManager.InvalidSchematicHashes.AddProperty(allSchematic.Id, "Schematic altered");
				flag = false;
			}
		}
		Properties levelHashes = gameManager.ContentHashData.GetLevelHashes();
		bool flag2 = true;
		List<LevelModel> list = new List<LevelModel>();
		list.AddRange(gameManager.CampaignLevelModelCollection.GetAllItems());
		list.AddRange(gameManager.SandboxLevelModelCollection.GetAllItems());
		foreach (LevelModel item in list)
		{
			if (!levelHashes.HasProperty(item.Id))
			{
				gameManager.InvalidLevelModelHashes.AddProperty(item.Id, "New level");
				flag2 = false;
			}
			else if (levelHashes.GetProperty(item.Id) != item.HashSHA256)
			{
				gameManager.InvalidLevelModelHashes.AddProperty(item.Id, "Level altered");
				flag2 = false;
			}
		}
		if (flag && flag2)
		{
			return;
		}
		Debug.LogError("Some content hash is not equal!");
		foreach (string allKey in gameManager.InvalidSchematicHashes.GetAllKeys())
		{
			Debug.LogError("The schematic (" + allKey + ") is modified (" + gameManager.InvalidSchematicHashes.GetProperty(allKey) + ")");
		}
		foreach (string allKey2 in gameManager.InvalidLevelModelHashes.GetAllKeys())
		{
			Debug.LogError("The level model (" + allKey2 + ") is modified (" + gameManager.InvalidLevelModelHashes.GetProperty(allKey2) + ")");
		}
	}

	private IEnumerator LoadSchematics(GameManager GAME)
	{
		string[] schematicsFiles = Directory.GetFiles(PathNames.Schematics, "*schematic.xml", SearchOption.AllDirectories);
		for (int i = 0; i < schematicsFiles.Length; i++)
		{
			string schematicPath = schematicsFiles[i];
			Schematic newSchematic = SchematicBuilder.CreateSchematic(schematicPath, GAME.MaterialSchematicCollection);
			Properties properties = new Properties();
			properties.AddProperty("Name", GAME.LanguagesManager.GetText("block.name." + newSchematic.Id, newSchematic.Id));
			properties.AddProperty("Description", GAME.LanguagesManager.GetText("block.description." + newSchematic.Id, newSchematic.Id));
			newSchematic.Infos = properties;
			GAME.LanguagesManager.OnLanguageChangedEvent += delegate
			{
				string text = GAME.LanguagesManager.GetText("block.name." + newSchematic.Id, newSchematic.Id);
				string text2 = GAME.LanguagesManager.GetText("block.description." + newSchematic.Id, newSchematic.Id);
				newSchematic.UpdateInfos(text, text2);
			};
			Properties item = schematicsPropertiesCollection.GetItem(newSchematic.Id);
			if (item != null)
			{
				newSchematic.Properties = item;
			}
			else
			{
				newSchematic.IsUserMod = true;
			}
			newSchematic.MaterialSchematic = GAME.MaterialSchematicCollection.GetMaterialSchematics(newSchematic.MaterialId);
			GAME.SchematicCollection.AddSchematic(newSchematic);
			if ((i + 1) % 2 == 0)
			{
				yield return new WaitForEndOfFrame();
			}
		}
		yield return new WaitForEndOfFrame();
	}

	private int GetSchematicsCount()
	{
		return Directory.GetFiles(PathNames.Schematics, "*schematic.xml", SearchOption.AllDirectories).Length;
	}

	private void LoadInventory(GameManager GAME)
	{
		GAME.InventoryStatusModel = InventoryStatusBuilder.CreateInventoryStatus(PathNames.Inventory, GAME.SchematicCollection);
	}

	private void LoadQuickInventory(GameManager GAME)
	{
		GAME.MainQuickInventoryModel = QuickInventoryBuilder.CreateQuickInventory(PathNames.QuickInventory, GAME.CreationCollectionsManager);
		GAME.DefaultQuickInventoryModel = QuickInventoryBuilder.CreateQuickInventory(PathNames.DefaultQuickInventory, GAME.CreationCollectionsManager);
	}

	private void LoadCategories(GameManager GAME)
	{
		GAME.CategoriesModel = CategoriesBuilder.CreateCategories(PathNames.Categories, GAME.CreationCollectionsManager);
	}

	private void LoadLEQuickInventory(GameManager GAME)
	{
		GAME.LEQuickInventoryModel = LEQuickInventoryBuilder.CreateQuickInventory(PathNames.LEQuickInventory, GAME.LevelPartCollectionsManager);
		GAME.DefaultLEQuickInventoryModel = LEQuickInventoryBuilder.CreateQuickInventory(PathNames.DefaultLEQuickInventory, GAME.LevelPartCollectionsManager);
	}

	private void LoadLECategories(GameManager GAME)
	{
		GAME.LECategoriesModel = LECategoriesBuilder.CreateCategories(PathNames.LECategories, GAME.LevelPartCollectionsManager);
	}

	private void LoadUserLevelParts(GameManager GAME)
	{
		if (!Directory.Exists(PathNames.UserLevelParts))
		{
			Directory.CreateDirectory(PathNames.UserLevelParts);
		}
		string[] files = Directory.GetFiles(PathNames.UserLevelParts, "*.xml", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			CustomLevelObjectsModel customLevelObjectsModel = LevelModelBuilder.LoadCustomLevelObject(files[i]);
			customLevelObjectsModel.Origin = CustomLevelObjectsModel.OriginEnum.UserPart;
			GAME.LevelPartCollectionsManager.UserLevelPartsCollection.AddItem(customLevelObjectsModel);
		}
	}

	private void LoadDevCreationsParts(GameManager GAME)
	{
		if (!Directory.Exists(PathNames.DevParts))
		{
			Directory.CreateDirectory(PathNames.DevParts);
		}
		string[] files = Directory.GetFiles(PathNames.DevParts, "*.sav", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			CreationModel creationModel = CreationModelBuilder.LoadXml(files[i], GAME.SchematicCollection, isFileEncrypted: true);
			GAME.CreationCollectionsManager.DevCreationModelCollection.AddCreationModel(creationModel);
		}
	}

	private void LoadUserCreationsParts(GameManager GAME)
	{
		if (!Directory.Exists(PathNames.UserParts))
		{
			Directory.CreateDirectory(PathNames.UserParts);
		}
		string[] files = Directory.GetFiles(PathNames.UserParts, "*.sav", SearchOption.TopDirectoryOnly);
		foreach (string text in files)
		{
			CreationModel creationModel = CreationModelBuilder.LoadXml(text, GAME.SchematicCollection, isFileEncrypted: true);
			creationModel.IsDeletable = true;
			creationModel.FilePath = text;
			GAME.CreationCollectionsManager.UserCreationModelCollection.AddCreationModel(creationModel);
		}
	}

	private void LoadCreationsPartsFromSchematics(GameManager GAME)
	{
		foreach (Schematic allSchematic in GAME.SchematicCollection.GetAllSchematics())
		{
			CreationModel creationModel = CreationModelBuilder.BuildCreationModelFromSchematic(allSchematic);
			GAME.CreationCollectionsManager.CreationModelFromSchematicCollection.AddCreationModel(creationModel);
		}
	}

	private void LoadMenuCreations(GameManager GAME)
	{
		string[] files = Directory.GetFiles(PathNames.MenuCreations, "*.xml", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			LoadMenuCreation(files[i], isFileEncrypted: false);
		}
		files = Directory.GetFiles(PathNames.MenuCreations, "*.sav", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			LoadMenuCreation(files[i], isFileEncrypted: true);
		}
		void LoadMenuCreation(string creationPath, bool isFileEncrypted)
		{
			CreationModel creationModel = CreationModelBuilder.LoadXml(creationPath, GAME.SchematicCollection, isFileEncrypted);
			GAME.CreationCollectionsManager.MenuCreationModelCollection.AddCreationModel(creationModel);
		}
	}

	private void LoadSavedCreations(GameManager GAME, string directoryPath, CreationModel.CreationPlace creationPlace, string creationIdPrefix = "")
	{
		string[] files = Directory.GetFiles(directoryPath, "*.xml", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			LoadSavedCreation(files[i], isFileEncrypted: false);
		}
		files = Directory.GetFiles(directoryPath, "*.sav", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			LoadSavedCreation(files[i], isFileEncrypted: true);
		}
		void LoadSavedCreation(string creationPath, bool isFileEncrypted)
		{
			CreationModel creationModel = CreationModelBuilder.LoadXml(creationPath, GAME.SchematicCollection, isFileEncrypted);
			DateTime lastWriteTime = File.GetLastWriteTime(creationPath);
			creationModel.FileLastModifiedDate = lastWriteTime;
			if (!string.IsNullOrEmpty(creationIdPrefix))
			{
				creationModel.Id = creationIdPrefix + "_" + creationModel.Id;
			}
			creationModel.Place = creationPlace;
			GAME.SavedCreationsModel.AddCreation(creationModel);
		}
	}

	private void LoadBestCreations(GameManager gameManager, string directoryPath)
	{
		if (Directory.Exists(directoryPath))
		{
			string[] files = Directory.GetFiles(directoryPath, "*.sav", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < files.Length; i++)
			{
				CreationModel creationModel = CreationModelBuilder.LoadXml(files[i], gameManager.SchematicCollection, isFileEncrypted: true);
				gameManager.CreationCollectionsManager.BestCreationModelCollection.AddCreationModel(creationModel);
			}
		}
	}

	private void LoadUserProfile(GameManager GAME)
	{
		if (!File.Exists(PathNames.UserProfileAES))
		{
			GAME.UserProfileModel = new UserProfileModel();
			return;
		}
		GenericCollectionModel<LevelModel> genericCollectionModel = new GenericCollectionModel<LevelModel>();
		genericCollectionModel.AddItems(GAME.UserAndWorkshopLevelModelCollection.GetAllItems());
		genericCollectionModel.AddItems(GAME.DefenderLevelModelCollection.GetAllItems(), shouldOverride: true);
		genericCollectionModel.AddItems(GAME.SandboxLevelModelCollection.GetAllItems(), shouldOverride: true);
		genericCollectionModel.AddItems(GAME.CampaignLevelModelCollection.GetAllItems(), shouldOverride: true);
		genericCollectionModel.AddItems(GAME.TutorialLevelModelCollection.GetAllItems(), shouldOverride: true);
		GAME.UserProfileModel = UserProfileModelBuilder.LoadXmlFile(PathNames.UserProfileAES, genericCollectionModel, isFileEncrypted: true);
	}

	private void LoadOptions(GameManager gameManager)
	{
		OptionsModel optionsModel = ((!File.Exists(PathNames.Options)) ? new OptionsModel() : File.ReadAllText(PathNames.Options).XmlDeserialize<OptionsModel>());
		gameManager.ConstructionToolsModel.ConnectorGridSize = optionsModel.ConnectorGridSize;
		gameManager.ConstructionToolsModel.IsAutoFocusActivated = optionsModel.IsAutoFocusActivated;
		gameManager.ConstructionToolsModel.IsAutoConnectionsActivated = optionsModel.IsAutoConnectionsActivated;
		gameManager.OptionsModel = optionsModel;
	}

	private void LoadLEOptions(GameManager gameManager)
	{
		LEOptionsModel lEOptionsModel = ((!File.Exists(PathNames.LEOptions)) ? new LEOptionsModel() : File.ReadAllText(PathNames.LEOptions).XmlDeserialize<LEOptionsModel>());
		lEOptionsModel.SetUpdateAuxiliaryEvent(gameManager);
		gameManager.LevelEditorToolsModel.SnappingTypeValue = lEOptionsModel.SnappingType;
		gameManager.LevelEditorToolsModel.HandSnapStep = lEOptionsModel.HandSnapStep;
		gameManager.LevelEditorToolsModel.MoveSnapStep = lEOptionsModel.MoveSnapStep;
		gameManager.LevelEditorToolsModel.RotationSnapStep = lEOptionsModel.RotationSnapStep;
		gameManager.LevelEditorToolsModel.ScaleSnapStep = lEOptionsModel.ScaleSnapStep;
		gameManager.LevelEditorToolsModel.IsGridVisible = lEOptionsModel.IsGridVisible;
		gameManager.LevelEditorToolsModel.IsSnappingOn = lEOptionsModel.IsSnappingOn;
		gameManager.LEOptionsModel = lEOptionsModel;
	}

	private void LoadLevelsByDirectory(GenericCollectionModel<LevelModel> levelModelCollection, string directoryPath, LevelModel.LevelPlace levelPlace, string levelIdPrefix = "")
	{
		if (Directory.Exists(directoryPath))
		{
			string[] files = Directory.GetFiles(directoryPath, "lvl_*.xml", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < files.Length; i++)
			{
				LoadLevel(files[i], isEncryptedFile: false);
			}
			files = Directory.GetFiles(directoryPath, "lvl_*.sav", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < files.Length; i++)
			{
				LoadLevel(files[i], isEncryptedFile: true);
			}
		}
		void LoadLevel(string filePath, bool isEncryptedFile)
		{
			LevelModel levelModel = LevelModelBuilder.LoadXml(filePath, isEncryptedFile);
			DateTime lastWriteTime = File.GetLastWriteTime(filePath);
			levelModel.FileLastModifiedDate = lastWriteTime;
			if (!string.IsNullOrEmpty(levelIdPrefix))
			{
				levelModel.Id = levelIdPrefix + "_" + levelModel.Id;
			}
			levelModel.Place = levelPlace;
			levelModelCollection.AddItem(levelModel);
		}
	}

	private IEnumerator LoadLevelThumbnails(SpriteCollection spriteCollection, string directoryPath, string levelIdPrefix = "")
	{
		if (!Directory.Exists(directoryPath))
		{
			yield return new WaitForEndOfFrame();
			yield break;
		}
		string[] files = Directory.GetFiles(directoryPath, "*.png", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.TopDirectoryOnly);
		string[] thumbnailsFilePath = new string[files.Length + files2.Length];
		files.CopyTo(thumbnailsFilePath, 0);
		files2.CopyTo(thumbnailsFilePath, files.Length);
		for (int i = 0; i < thumbnailsFilePath.Length; i++)
		{
			string obj = thumbnailsFilePath[i];
			string text = Path.GetFileNameWithoutExtension(obj);
			if (!string.IsNullOrEmpty(levelIdPrefix))
			{
				text = text.Replace("lvl_", "");
				text = "lvl_" + levelIdPrefix + "_" + text;
			}
			Texture2D texture2D = Util.LoadPNG(obj);
			Rect rect = new Rect(0f, 0f, texture2D.width, texture2D.height);
			Sprite sprite = Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f));
			spriteCollection.AddSprite(text, sprite);
			if ((i + 1) % 5 == 0)
			{
				yield return new WaitForEndOfFrame();
			}
		}
		yield return new WaitForEndOfFrame();
	}

	private int GetThumbnailsCount(string directoryPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			return 0;
		}
		string[] files = Directory.GetFiles(directoryPath, "*.png", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.TopDirectoryOnly);
		return files.Length + files2.Length;
	}

	private IEnumerator LoadFlagTextures(TextureCollection textureCollection, string directoryPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			yield return new WaitForEndOfFrame();
			yield break;
		}
		string[] files = Directory.GetFiles(directoryPath, "*.png", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.TopDirectoryOnly);
		string[] flagsFilePath = new string[files.Length + files2.Length];
		files.CopyTo(flagsFilePath, 0);
		files2.CopyTo(flagsFilePath, files.Length);
		for (int i = 0; i < flagsFilePath.Length; i++)
		{
			string obj = flagsFilePath[i];
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(obj);
			Texture2D texture = Util.LoadPNG(obj);
			textureCollection.AddTexture(fileNameWithoutExtension, texture);
			if ((i + 1) % 5 == 0)
			{
				yield return new WaitForEndOfFrame();
			}
		}
		yield return new WaitForEndOfFrame();
	}

	private int GetFlagsCount(string directoryPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			return 0;
		}
		string[] files = Directory.GetFiles(directoryPath, "*.png", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.TopDirectoryOnly);
		return files.Length + files2.Length;
	}

	private void LoadLanguages(GameManager GAME)
	{
		string[] directories = Directory.GetDirectories(PathNames.Languages, "*", SearchOption.TopDirectoryOnly);
		foreach (string path in directories)
		{
			Properties properties = new Properties();
			string[] files = Directory.GetFiles(path, "*.txt", SearchOption.TopDirectoryOnly);
			foreach (string filePath in files)
			{
				PropertiesBuilder.PopulatePropertiesFromINIFile(properties, filePath);
			}
			GAME.LanguagesManager.AddLanguage(properties);
		}
		GAME.LanguagesManager.SetCurrentLanguage(GAME.OptionsModel.Language, shouldNotify: false);
	}

	private void LoadTutorialResources(GameManager gameManager)
	{
		string[] directories = Directory.GetDirectories(PathNames.TutorialLevels, "*", SearchOption.TopDirectoryOnly);
		foreach (string obj in directories)
		{
			string name = new DirectoryInfo(obj).Name;
			CreationModel creationModel = CreationModelBuilder.LoadXml(obj + "\\current.sav", gameManager.SchematicCollection, isFileEncrypted: true);
			gameManager.TutorialManager.AddCreationModel(name, creationModel);
			QuickInventoryModel quickInventoryModel = QuickInventoryBuilder.CreateQuickInventory(obj + "\\quick_inventory.xml", gameManager.CreationCollectionsManager);
			gameManager.TutorialManager.AddQuickInventoryModel(name, quickInventoryModel);
		}
	}

	private void LoadAllSteamWorkshopContent(GameManager gameManager)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		foreach (string listOfSubscribedItemsPath in SteamWorkshopManager.Instance.GetListOfSubscribedItemsPaths())
		{
			LoadSteamWorkshopItem(gameManager, listOfSubscribedItemsPath);
		}
		SteamWorkshopManager.Instance.OnWorkshopItemInstalled += delegate(string itemPath)
		{
			LoadSteamWorkshopItem(gameManager, itemPath);
		};
		SteamWorkshopManager.Instance.GetTrendsItems(LoadSteamWorkshopTrendsItems);
	}

	private void LoadSteamWorkshopItem(GameManager gameManager, string itemPath)
	{
		if (string.IsNullOrEmpty(itemPath) || string.IsNullOrWhiteSpace(itemPath))
		{
			return;
		}
		string[] files = Directory.GetFiles(itemPath, "*.wocmeta", SearchOption.TopDirectoryOnly);
		if (files.Length == 0)
		{
			return;
		}
		WOCMetaData wOCMetaData = WOCMetaData.LoadFromDisk(files[0]);
		if (wOCMetaData == null)
		{
			return;
		}
		if (wOCMetaData.Type == WOCMetaData.FileType.Contraption)
		{
			LoadSavedCreations(gameManager, itemPath, CreationModel.CreationPlace.Workshop, wOCMetaData.WorkshopId);
			SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.CONTRAPTION_DOWNLOADED_WORKSHOP);
		}
		else if (wOCMetaData.Type == WOCMetaData.FileType.Level)
		{
			LoadLevelsByDirectory(gameManager.UserAndWorkshopLevelModelCollection, itemPath, LevelModel.LevelPlace.Workshop, wOCMetaData.WorkshopId);
			IEnumerator enumerator = LoadLevelThumbnails(gameManager.UserAndWorkshopLevelThumbnailCollection, itemPath, wOCMetaData.WorkshopId);
			while (enumerator.MoveNext())
			{
			}
			SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.LEVEL_DOWNLOADED_WORKSHOP);
		}
	}

	private void LoadSteamWorkshopTrendsItems(ulong[] itemIds, string[] itemNames, string[] itemImageURLs)
	{
		GameManager.Instance.StartCoroutine(LoadingTrendsItems());
		IEnumerator LoadingTrendsItems()
		{
			for (int i = 0; i < itemIds.Length; i++)
			{
				UnityWebRequest request = UnityWebRequestTexture.GetTexture(itemImageURLs[i]);
				yield return request.SendWebRequest();
				if (request.isNetworkError || request.isHttpError)
				{
					Debug.Log(request.error);
				}
				else
				{
					Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
					GameManager.Instance.WorkshopTrendsModel.AddItem(itemIds[i], itemNames[i], texture);
				}
			}
		}
	}

	private void CreateTutorialCampaignModel(GameManager gameManager)
	{
		int num = 1;
		foreach (LevelModel allItem in gameManager.TutorialLevelModelCollection.GetAllItems())
		{
			if (!allItem.IsHidden)
			{
				gameManager.TutorialCampaignModel.AddLevelModel(allItem, num++);
			}
		}
	}

	private void CreateSandboxCampaignModel(GameManager gameManager)
	{
		string[] allLevelIds = gameManager.sandboxCampaignLevels.GetAllLevelIds();
		foreach (string text in allLevelIds)
		{
			foreach (LevelModel allItem in gameManager.SandboxLevelModelCollection.GetAllItems())
			{
				if (!allItem.IsHidden && text == allItem.Id)
				{
					gameManager.SandboxCampaignModel.AddItem(allItem);
					break;
				}
			}
		}
	}

	private void CreateCampaignStructModel(GameManager GAME)
	{
		int num = 1;
		foreach (LevelModel allItem in GAME.CampaignLevelModelCollection.GetAllItems())
		{
			if (!allItem.IsHidden)
			{
				if (Debug.isDebugBuild)
				{
					allItem.BestTime = 100f;
				}
				GAME.CampaignStructureModel.AddLevelModel(allItem, num++);
			}
		}
	}

	private void CreateCampaignStructModelByData(GameManager GAME)
	{
		string[] allLevelIds = GAME.mainCampaignLevels.GetAllLevelIds();
		int num = 1;
		string[] array = allLevelIds;
		foreach (string text in array)
		{
			foreach (LevelModel allItem in GAME.CampaignLevelModelCollection.GetAllItems())
			{
				if (text == allItem.Id)
				{
					if (Debug.isDebugBuild)
					{
						allItem.BestTime = 100f;
					}
					GAME.CampaignStructureModel.AddLevelModel(allItem, num++);
					GAME.GroupCampaignModel.AddLevelModel(allItem);
					break;
				}
			}
		}
		if (Debug.isDebugBuild)
		{
			GAME.CheatModel.IsAllLevelsEnabled = true;
		}
	}

	private IEnumerator PopulateObjectPools(GameManager GAME)
	{
		Dictionary<string, int> blockModelCounter = new Dictionary<string, int>();
		Dictionary<string, int> blockPlaceholderCounter = new Dictionary<string, int>();
		BlockModelsCounter(blockModelCounter);
		BlockPlaceholdersCounter(blockPlaceholderCounter);
		int counter = 1;
		foreach (Schematic schematic in GAME.SchematicCollection.GetAllSchematics())
		{
			int num = 3;
			if (blockModelCounter.ContainsKey(schematic.Id))
			{
				num += blockModelCounter[schematic.Id];
			}
			num += schematic.PrepoolingQuantity;
			num = Mathf.Clamp(num, 0, 300);
			string objectTypeId = ObjectNames.SchematicIdForModel(schematic.Id);
			ObjectPools.Instance.CreateNewInstances(objectTypeId, num, () => BlockViewBuilder.CreateBlockModel(0, schematic));
			int num2 = 1;
			if (blockPlaceholderCounter.ContainsKey(schematic.Id))
			{
				num2 += blockPlaceholderCounter[schematic.Id];
			}
			num2 += schematic.PrepoolingQuantity;
			num2 = Mathf.Clamp(num2, 0, 300);
			string objectTypeId2 = ObjectNames.SchematicIdForPlaceholder(schematic.Id);
			ObjectPools.Instance.CreateNewInstances(objectTypeId2, num2, () => BlockViewBuilder.CreatePlaceholderBlock(0, schematic, null));
			int num3 = 3;
			num3 += schematic.PrepoolingQuantity;
			string objectTypeId3 = ObjectNames.SchematicIdForRigid(schematic.Id);
			ObjectPools.Instance.CreateNewInstances(objectTypeId3, num3, () => BlockViewBuilder.CreateRigidBlock(0, schematic, null));
			int quantity = 6;
			string objectTypeId4 = ObjectNames.SchematicIdForButton(schematic.Id);
			ObjectPools.Instance.CreateNewInstances(objectTypeId4, quantity, () => BlockViewBuilder.CreateBlockModelButton3D(0, schematic));
			if (counter++ % 5 == 0)
			{
				yield return new WaitForEndOfFrame();
			}
		}
		int quantity2 = 30;
		ObjectPools.Instance.CreateNewInstances("hinge_joint_button_3d", quantity2, () => UnityEngine.Object.Instantiate(GAME.hingeJointButtonPrefab));
		yield return new WaitForEndOfFrame();
		int quantity3 = 60;
		ObjectPools.Instance.CreateNewInstances("all_joints_button_3d", quantity3, () => UnityEngine.Object.Instantiate(GAME.allJointsButtonPrefab));
		yield return new WaitForEndOfFrame();
		int quantity4 = 20;
		ObjectPools.Instance.CreateNewInstances("quick_keys_group", quantity4, () => Util.InstantiateForGUI(GAME.quickKeysGroupPrefab, null));
		yield return new WaitForEndOfFrame();
		int quantity5 = 30;
		ObjectPools.Instance.CreateNewInstances("quick_key_slot", quantity5, () => Util.InstantiateForGUI(GAME.quickKeySlotPrefab, null));
		yield return new WaitForEndOfFrame();
		PopulateLogicInstructionSlotObjectPools(GAME);
		yield return new WaitForEndOfFrame();
		PopulateQuickInventoryTabAndSlotObjectPools(GAME);
		yield return new WaitForEndOfFrame();
	}

	private void PopulateLogicInstructionSlotObjectPools(GameManager GAME)
	{
		int quantity = 10;
		ObjectPools.Instance.CreateNewInstances("key_trigger_instruction_slot", quantity, () => Util.InstantiateForGUI(GAME.GameStylesData.prefabStylesData.keyTriggerInstructionSlotPrefab, null, "KeyTriggerInstructionSlot"));
		ObjectPools.Instance.CreateNewInstances("comparator_instruction_slot", quantity, () => Util.InstantiateForGUI(GAME.GameStylesData.prefabStylesData.comparatorInstructionSlotPrefab, null, "ComparatorInstructionSlot"));
		ObjectPools.Instance.CreateNewInstances("set_instruction_slot", quantity, () => Util.InstantiateForGUI(GAME.GameStylesData.prefabStylesData.setInstructionSlotPrefab, null, "SetInstructionSlot"));
		ObjectPools.Instance.CreateNewInstances("accumulator_instruction_slot", quantity, () => Util.InstantiateForGUI(GAME.GameStylesData.prefabStylesData.accumulatorInstructionPrefab, null, "AccumulatorInstructionSlot"));
		ObjectPools.Instance.CreateNewInstances("operation_instruction_slot", quantity, () => Util.InstantiateForGUI(GAME.GameStylesData.prefabStylesData.operationInstructionPrefab, null, "OperationInstructionSlot"));
		ObjectPools.Instance.CreateNewInstances("delay_instruction_slot", quantity, () => Util.InstantiateForGUI(GAME.GameStylesData.prefabStylesData.delayInstructionSlotPrefab, null, "DelayInstructionSlot"));
		ObjectPools.Instance.CreateNewInstances("group_instruction_slot", quantity, () => Util.InstantiateForGUI(GAME.GameStylesData.prefabStylesData.groupInstructionSlorPrefab, null, "GroupInstructionSlot"));
	}

	private void PopulateQuickInventoryTabAndSlotObjectPools(GameManager gameManager)
	{
		int quantity = 15;
		int quantity2 = 100;
		ObjectPools.Instance.CreateNewInstances("quick_inventory_tab", quantity, () => Util.InstantiateForGUI(gameManager.GameStylesData.prefabStylesData.quickInventoryTabPrefab, null, "QuickInventoryTab"));
		ObjectPools.Instance.CreateNewInstances("quick_inventory_slot", quantity2, () => Util.InstantiateForGUI(gameManager.GameStylesData.prefabStylesData.quickInventorySlotPrefab, null, "QuickInventorySlot"));
		ObjectPools.Instance.CreateNewInstances("le_quick_inventory_tab", quantity, () => Util.InstantiateForGUI(gameManager.GameStylesData.prefabStylesData.leQuickInventoryTabPrefab, null, "LEQuickInventoryTab"));
		ObjectPools.Instance.CreateNewInstances("le_quick_inventory_slot", quantity2, () => Util.InstantiateForGUI(gameManager.GameStylesData.prefabStylesData.leQuickInventorySlotPrefab, null, "LEQuickInventorySlot"));
	}

	private void BlockModelsCounter(Dictionary<string, int> counter)
	{
		int num = GameManager.Instance.SavedCreationsModel.CreationModelCount();
		for (int i = 0; i < num; i++)
		{
			BlocksCounter(GameManager.Instance.SavedCreationsModel.GetCreationModel(i), counter);
		}
		foreach (CreationModel allCreationModel in GameManager.Instance.CreationCollectionsManager.UserCreationModelCollection.GetAllCreationModels())
		{
			BlocksCounter(allCreationModel, counter);
		}
	}

	private void BlockPlaceholdersCounter(Dictionary<string, int> counter)
	{
		int num = GameManager.Instance.MainQuickInventoryModel.TabCount();
		for (int i = 0; i < num; i++)
		{
			foreach (CreationModel allItem in GameManager.Instance.MainQuickInventoryModel.GetAllItems(i))
			{
				BlocksCounter(allItem, counter);
			}
		}
	}

	private void BlocksCounter(CreationModel creationModel, Dictionary<string, int> counter)
	{
		foreach (BlockModel item in creationModel.GetAllBlockModel())
		{
			string id = item.Schematic.Id;
			if (counter.ContainsKey(item.Schematic.Id))
			{
				counter[id]++;
			}
			else
			{
				counter.Add(id, 0);
			}
		}
	}
}
