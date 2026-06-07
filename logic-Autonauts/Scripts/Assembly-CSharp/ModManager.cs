using System;
using System.Collections.Generic;
using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using Rewired;
using Steamworks;
using UnityEngine;

[MoonSharpUserData]
public class ModManager : MonoBehaviour
{
	public enum ErrorState
	{
		No_Error = 0,
		Error_Upload_Steam = 1,
		Error_Upload_Title = 2,
		Error_Upload_Description = 3,
		Error_Upload_Image = 4,
		Error_Upload_Tags = 5,
		Error_Restart = 6,
		Error_FailedSubcribe = 7,
		Error_FailedUnsubcribe = 8,
		Error_Delete_Steam = 9,
		Error_FailedResults = 10,
		Error_AcceptTCs = 11,
		Error_Lua = 12,
		Error_Misc = 13,
		Error_Clash = 14
	}

	public struct ExposedData
	{
		public string VarName;

		public DynValue VarValue;

		public DataType VarType;

		public DynValue MinValue;

		public DynValue MaxValue;

		public bool UsesLookup;

		public DynValue Callback;

		public bool IsKeybinding;

		public List<DynValue> VarValuesList;
	}

	public enum CallbackTypes
	{
		None = 0,
		FoodConsumed = 1,
		ClothingTopAdded = 2,
		ClothingTopRemoved = 3,
		ClothingHatAdded = 4,
		ClothingHatRemoved = 5,
		ConverterComplete = 6,
		HoldablePickedUp = 7,
		HoldableDroppedOnGround = 8,
		AddedToConverter = 9
	}

	public struct CallbackData
	{
		public ObjectType Object;

		public Script OwnerScript;

		public CallbackTypes CallbackType;

		public DynValue CallbackFunction;
	}

	private bool DebugInfo;

	public static ModManager Instance;

	public List<Mod> CurrentMods;

	public List<Mod> LocalMods;

	public ModBase ModBaseClass;

	public ModSound ModSoundClass;

	public ModVariable ModVariableClass;

	public ModConverter ModConverterClass;

	public ModBuilding ModBuildingClass;

	public ModDecorative ModDecorativeClass;

	public ModTiles ModTilesClass;

	public ModPlayer ModPlayerClass;

	public ModBot ModBotClass;

	public ModDebug ModDebugClass;

	public ModCamera ModCameraClass;

	public ModHoldable ModHoldableClass;

	public ModFood ModFoodClass;

	public ModObject ModObjectClass;

	public ModTool ModToolClass;

	public ModQuest ModQuestClass;

	public ModGoTo ModGoToClass;

	public ModHat ModHatClass;

	public ModTop ModTopClass;

	public ModUI ModUIClass;

	public ModStorage ModStorageClass;

	public ModMedicine ModMedicineClass;

	public ModToy ModToyClass;

	public ModEducation ModEducationClass;

	public ModSaveData ModSaveDataClass;

	public List<ModCustom> ModCustomClasses;

	public int CustomCreations;

	public Mod MenuSelectedMod;

	private List<string> AllModsScripts;

	public Script CreationScript;

	public bool MenuForceErrorReturn;

	public string OverrideErrorMessage;

	private bool ShowErrorMessageWhenSafe;

	private bool ScriptClashFound;

	public string SpawnsInfo = "";

	private string SpawnsInfoUpdated = "";

	public bool InMainUpdateState;

	private bool HasReset;

	public bool FailSafeDisabled;

	public bool RegisteredForInputPressCallback;

	public bool RegisteredForInputMouseDownCallback;

	private bool DoneInputSetup;

	public Dictionary<Mod, Script> RegisteredInputModsKeyPress;

	public Dictionary<Mod, Script> RegisteredInputModsMouseDown;

	private List<CallbackData> ModCallbacks;

	public ErrorState CurrentErrorState { get; private set; }

	public EResult SteamErrorCode { get; private set; }

	public Dictionary<ObjectType, string> m_ModStrings { get; private set; }

	public GameOptions m_GameOptionsRef { get; private set; }

	public void RegisterNewMod(Mod NewMod)
	{
		CurrentMods.Add(NewMod);
		if (NewMod.IsLocal)
		{
			LocalMods.Add(NewMod);
			if (DebugInfo)
			{
				Debug.Log(NewMod);
			}
		}
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else if (this != Instance)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		CurrentMods = new List<Mod>();
		LocalMods = new List<Mod>();
		m_ModStrings = new Dictionary<ObjectType, string>();
		RegisteredInputModsKeyPress = new Dictionary<Mod, Script>();
		RegisteredInputModsMouseDown = new Dictionary<Mod, Script>();
		ModCallbacks = new List<CallbackData>();
		UserData.RegisterAssembly();
		Script.DefaultOptions.DebugPrint = delegate(string s)
		{
			Debug.Log(s);
		};
		AllModsScripts = new List<string>();
		ModSoundClass = new ModSound();
		ModVariableClass = new ModVariable();
		ModConverterClass = new ModConverter();
		ModBuildingClass = new ModBuilding();
		ModBaseClass = new ModBase();
		ModDecorativeClass = new ModDecorative();
		ModTilesClass = new ModTiles();
		ModPlayerClass = new ModPlayer();
		ModBotClass = new ModBot();
		ModDebugClass = new ModDebug();
		ModHoldableClass = new ModHoldable();
		ModCameraClass = new ModCamera();
		ModFoodClass = new ModFood();
		ModObjectClass = new ModObject();
		ModToolClass = new ModTool();
		ModQuestClass = new ModQuest();
		ModGoToClass = new ModGoTo();
		ModHatClass = new ModHat();
		ModTopClass = new ModTop();
		ModUIClass = new ModUI();
		ModStorageClass = new ModStorage();
		ModMedicineClass = new ModMedicine();
		ModToyClass = new ModToy();
		ModEducationClass = new ModEducation();
		ModSaveDataClass = new ModSaveData();
		ModCustomClasses = new List<ModCustom>();
		ModCustomClasses.Add(ModConverterClass);
		ModCustomClasses.Add(ModBuildingClass);
		ModCustomClasses.Add(ModDecorativeClass);
		ModCustomClasses.Add(ModHoldableClass);
		ModCustomClasses.Add(ModFoodClass);
		ModCustomClasses.Add(ModToolClass);
		ModCustomClasses.Add(ModGoToClass);
		ModCustomClasses.Add(ModHatClass);
		ModCustomClasses.Add(ModTopClass);
		ModCustomClasses.Add(ModEducationClass);
		ModCustomClasses.Add(ModToyClass);
		ModCustomClasses.Add(ModMedicineClass);
		foreach (ModCustom modCustomClass in ModCustomClasses)
		{
			modCustomClass.Init();
		}
		ModDebugClass.ClearLog();
	}

	private void Start()
	{
	}

	private void ResetBeforeLoad()
	{
		VariableManager.Instance.ReInit();
		StorageTypeManager.Instance.Reset();
		AudioManager.Instance.ResetAllModSounds();
		foreach (Mod currentMod in CurrentMods)
		{
			currentMod.StartedUp = false;
		}
		FailSafeDisabled = false;
	}

	public void PostCreateScripts(bool CreatedGame)
	{
		for (int i = 0; i < CurrentMods.Count; i++)
		{
			CurrentMods[i].PostCreateSpecific(CreatedGame);
		}
		UpdateSaveSpawnsInfo("Nothing", 0, 0, true);
		InMainUpdateState = true;
	}

	private void InputCallbackPressed(InputActionEventData data)
	{
		foreach (Mod currentMod in CurrentMods)
		{
			if (currentMod.IsEnabled && currentMod.IsUsingKeybindings)
			{
				currentMod.UpdateKeybindingsCall(data);
			}
		}
	}

	private void Update()
	{
		if ((bool)MyInputManager.Instance && !DoneInputSetup && (bool)AudioManager.Instance)
		{
			DoneInputSetup = true;
			for (int i = 0; i < 10; i++)
			{
				MyInputManager.m_Rewired.AddInputEventDelegate(InputCallbackPressed, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, 49 + i);
			}
		}
		if (RegisteredForInputPressCallback)
		{
			for (int j = 0; j <= 296; j++)
			{
				KeyCode keyCode = (KeyCode)j;
				if (keyCode == KeyCode.F1 || keyCode == KeyCode.F2 || keyCode == KeyCode.F9 || keyCode == KeyCode.F10 || !Input.GetKeyDown(keyCode))
				{
					continue;
				}
				foreach (KeyValuePair<Mod, Script> item in RegisteredInputModsKeyPress)
				{
					if (item.Key.IsEnabled)
					{
						DynValue[] args = new DynValue[1] { DynValue.NewString(keyCode.ToString()) };
						item.Value.Call(item.Key.InputKeyPressCallback, args);
					}
				}
				break;
			}
		}
		if (RegisteredForInputMouseDownCallback && Input.GetMouseButtonDown(0))
		{
			foreach (KeyValuePair<Mod, Script> item2 in RegisteredInputModsMouseDown)
			{
				if (item2.Key.IsEnabled && (bool)HudManager.Instance)
				{
					TileCoord NewCoord = default(TileCoord);
					Vector3 HitPosition = default(Vector3);
					int UID = -1;
					GameStateManager.Instance.GetCurrentState().GetObjectUnderMouse(true, true, true, true, out UID, out NewCoord, out HitPosition);
					DynValue[] args2 = new DynValue[3]
					{
						DynValue.NewNumber(NewCoord.x),
						DynValue.NewNumber(NewCoord.y),
						DynValue.NewNumber(UID)
					};
					item2.Value.Call(item2.Key.InputMouseDownCallback, args2);
				}
			}
		}
		if (!GeneralUtils.m_InGame)
		{
			if (Instance.GetComponent<AudioSource>() != null)
			{
				UnityEngine.Object.Destroy(Instance.gameObject.GetComponent<AudioSource>());
			}
			HasReset = false;
		}
		else if (!HasReset)
		{
			ResetBeforeLoad();
			HasReset = true;
		}
		for (int k = 0; k < CurrentMods.Count; k++)
		{
			CurrentMods[k].Update();
		}
		if (ShowErrorMessageWhenSafe && GameStateManager.Instance != null)
		{
			GameStateManager.State actualState = GameStateManager.Instance.GetActualState();
			if (actualState == GameStateManager.State.Normal || actualState == GameStateManager.State.Edit || actualState == GameStateManager.State.MainMenu || actualState == GameStateManager.State.Start)
			{
				Debug.Log(actualState);
				LaunchErrorMessage();
				ShowErrorMessageWhenSafe = false;
			}
		}
		if (ScriptClashFound && GameStateManager.Instance != null && CurrentErrorState != ErrorState.No_Error && (bool)GameStateManager.Instance && GameStateManager.Instance.GetActualState() == GameStateManager.State.MainMenu)
		{
			OutputErrorText();
			GameStateManager.Instance.PushState(GameStateManager.State.ModsError);
			GameStateManager.Instance.GetCurrentState().GetComponent<GameStateModsError>().SetCurrentError();
			ScriptClashFound = false;
		}
	}

	public AudioClip FindModAudioClip(string FileName)
	{
		Mod lastCalledMod = GetLastCalledMod();
		if (lastCalledMod != null)
		{
			AudioClip sound = lastCalledMod.GetSound(FileName.ToLower());
			if (sound != null)
			{
				return sound;
			}
		}
		if (DebugInfo)
		{
			Debug.LogError("FindModAudioClip: Didn't Find Audio, Searching all mods");
		}
		return FindModAudioClipAllMods(FileName);
	}

	public AudioClip FindModAudioClipAllMods(string FileName)
	{
		for (int i = 0; i < CurrentMods.Count; i++)
		{
			AudioClip sound = CurrentMods[i].GetSound(FileName.ToLower());
			if (sound != null)
			{
				return sound;
			}
		}
		if (DebugInfo)
		{
			Debug.LogError("FindModAudioClipAllMods: Didn't Find Audio!");
		}
		return null;
	}

	public Texture FindModTexture(string FileName)
	{
		Mod lastCalledMod = GetLastCalledMod();
		if (lastCalledMod != null)
		{
			Texture texture = lastCalledMod.GetTexture(FileName.ToLower());
			if (texture != null)
			{
				return texture;
			}
		}
		if (DebugInfo)
		{
			Debug.LogError("FindModTexture: Didn't Find Texture, Searching all mods");
		}
		return FindModTextureAllMods(FileName);
	}

	public Texture FindModTextureAllMods(string FileName)
	{
		for (int i = 0; i < CurrentMods.Count; i++)
		{
			Texture texture = CurrentMods[i].GetTexture(FileName.ToLower());
			if (texture != null)
			{
				return texture;
			}
		}
		if (DebugInfo)
		{
			Debug.LogError("FindModTextureAllMods: Didn't Find Texture!");
		}
		return null;
	}

	public List<Texture2D> GetAllModTextures()
	{
		List<Texture2D> list = new List<Texture2D>();
		for (int i = 0; i < CurrentMods.Count; i++)
		{
			foreach (Texture allTexture in CurrentMods[i].GetAllTextures())
			{
				list.Add(allTexture as Texture2D);
			}
		}
		return list;
	}

	public void AddModString(ObjectType KeyName, string ObjectName)
	{
		if (!m_ModStrings.ContainsKey(KeyName))
		{
			m_ModStrings.Add(KeyName, ObjectName);
		}
	}

	public bool FindModStringFromValue(string ValueName, out string FoundValue)
	{
		foreach (KeyValuePair<ObjectType, string> modString in m_ModStrings)
		{
			if (modString.Value.Contains(ValueName))
			{
				FoundValue = modString.Value;
				return true;
			}
		}
		FoundValue = ValueName;
		return false;
	}

	public bool GetCustomClassData(ObjectType ObjID, out string UniqueName, out string PrefabLocation, out ObjectSubCategory SubCat, out bool CanStack)
	{
		foreach (ModCustom modCustomClass in ModCustomClasses)
		{
			if (modCustomClass.ModIDOriginals.TryGetValue(ObjID, out UniqueName))
			{
				PrefabLocation = modCustomClass.GetPrefabLocation();
				SubCat = modCustomClass.GetSubcategory();
				CanStack = modCustomClass.GetStackable();
				return true;
			}
		}
		UniqueName = "";
		PrefabLocation = "";
		SubCat = ObjectSubCategory.Any;
		CanStack = false;
		return false;
	}

	public void SetErrorSteam(ErrorState InErrorState, EResult InErrorCode = EResult.k_EResultOK)
	{
		CurrentErrorState = InErrorState;
		SteamErrorCode = InErrorCode;
		MenuForceErrorReturn = true;
		OverrideErrorMessage = string.Concat(InErrorState, " ", InErrorCode);
		OutputErrorText();
	}

	public void SetErrorLua(ErrorState InErrorState, string DescriptionOverride = null)
	{
		CurrentErrorState = InErrorState;
		MenuForceErrorReturn = true;
		OverrideErrorMessage = DescriptionOverride;
		ShowErrorMessageWhenSafe = true;
	}

	public void ClearError()
	{
		CurrentErrorState = ErrorState.No_Error;
		SteamErrorCode = EResult.k_EResultOK;
		OverrideErrorMessage = "";
		ShowErrorMessageWhenSafe = false;
	}

	public bool AllModsInitialised()
	{
		if (!ModLoaderManager.Instance.IsFullyLoaded())
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < CurrentMods.Count; i++)
		{
			num += (CurrentMods[i].MenuStartedUp ? 1 : 0);
		}
		return num == CurrentMods.Count;
	}

	public bool IsModelUsingCustomModel(ObjectType NewType, out string ModelName)
	{
		ModelName = "";
		foreach (ModCustom modCustomClass in ModCustomClasses)
		{
			if (modCustomClass.ModModels.TryGetValue(NewType, out ModelName))
			{
				return modCustomClass.IsUsingCustomModel(NewType);
			}
		}
		return false;
	}

	public GameObject GetModModel(ObjectType NewType)
	{
		string value = "";
		for (int i = 0; i < CurrentMods.Count; i++)
		{
			if (!CurrentMods[i].CustomIDs.Contains(NewType))
			{
				continue;
			}
			foreach (ModCustom modCustomClass in ModCustomClasses)
			{
				if (modCustomClass.ModModels.TryGetValue(NewType, out value))
				{
					return CurrentMods[i].GetCustomModel(value);
				}
			}
		}
		return null;
	}

	public ObjectType GetModObjectTypeFromName(string Name)
	{
		foreach (ModCustom modCustomClass in ModCustomClasses)
		{
			foreach (KeyValuePair<ObjectType, string> modIDOriginal in modCustomClass.ModIDOriginals)
			{
				if (modIDOriginal.Value.Equals(Name))
				{
					return modIDOriginal.Key;
				}
			}
		}
		return ObjectType.Nothing;
	}

	public void GetCustomModelTransform(ObjectType NewType, out Vector3 ModelTranslation, out Vector3 ModelRotation, out Vector3 ModelScale)
	{
		ModelScale = new Vector3(-1f, 1f, 1f);
		ModelRotation = new Vector3(0f, 0f, 0f);
		ModelTranslation = new Vector3(0f, 0f, 0f);
		using (List<ModCustom>.Enumerator enumerator = ModCustomClasses.GetEnumerator())
		{
			while (enumerator.MoveNext() && !enumerator.Current.GetModelScale(NewType, out ModelScale))
			{
			}
		}
		using (List<ModCustom>.Enumerator enumerator = ModCustomClasses.GetEnumerator())
		{
			while (enumerator.MoveNext() && !enumerator.Current.GetModelTranslation(NewType, out ModelTranslation))
			{
			}
		}
		using (List<ModCustom>.Enumerator enumerator = ModCustomClasses.GetEnumerator())
		{
			while (enumerator.MoveNext() && !enumerator.Current.GetModelRotation(NewType, out ModelRotation))
			{
			}
		}
	}

	private void LaunchErrorMessage()
	{
		if (CurrentErrorState != ErrorState.No_Error)
		{
			OutputErrorText();
			GameStateManager.Instance.PushState(GameStateManager.State.ModsError);
			GameStateManager.Instance.GetCurrentState().GetComponent<GameStateModsError>().SetCurrentError();
		}
	}

	private void OutputErrorText()
	{
		string overrideErrorMessage = OverrideErrorMessage;
		string text = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\ModError.txt";
		try
		{
			File.WriteAllText(text, overrideErrorMessage);
		}
		catch (UnauthorizedAccessException ex)
		{
			ErrorMessage.LogError("Summary Save - UnauthorizedAccessException : " + text + " " + ex.ToString());
		}
	}

	public void AddModScripts(string[] MainScripts)
	{
		foreach (string text in MainScripts)
		{
			if (text.Contains("StreamingAssets"))
			{
				AllModsScripts.Add(text);
			}
		}
	}

	public void CheckAllModScriptsForClash()
	{
		string[] array = new string[10] { "ModBase.Set", "ModBase.SpawnItem", "ModBuilding.CreateBuilding", "ModConverter.CreateConverter", "ModDecorative.CreateDecorative", "ModSound.ChangeSound", "ModSound.ChangeVolume", "ModSound.ChangePitch", "ModTiles.SetTile", "ModVariable.Set" };
		foreach (string checkStr in array)
		{
			CheckSingleScriptForClash(checkStr);
		}
	}

	public void CheckSingleScriptForClash(string CheckStr)
	{
	}

	public void LoadInitialSpawnsInfo()
	{
		string path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\ModSpawns.txt";
		if (File.Exists(path))
		{
			SpawnsInfo = File.ReadAllText(path);
			SpawnsInfoUpdated = SpawnsInfo;
		}
	}

	public void UpdateSaveSpawnsInfo(string Item = "Nothing", int xPos = 0, int yPos = 0, bool Save = false)
	{
		if (Save)
		{
			string text = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\ModSpawns.txt";
			try
			{
				File.WriteAllText(text, SpawnsInfoUpdated);
				return;
			}
			catch (UnauthorizedAccessException ex)
			{
				ErrorMessage.LogError("Summary Save - UnauthorizedAccessException : " + text + " " + ex.ToString());
				return;
			}
		}
		SpawnsInfoUpdated = SpawnsInfoUpdated + Item + "-" + xPos + "-" + yPos + "-";
	}

	public Mod GetLastCalledMod()
	{
		Script lastCalledScript = GetLastCalledScript();
		foreach (Mod currentMod in CurrentMods)
		{
			foreach (Script luaScript in currentMod.LuaScripts)
			{
				if (luaScript.Equals(lastCalledScript))
				{
					return currentMod;
				}
			}
		}
		return null;
	}

	public Script GetLastCalledScript()
	{
		return MethodMemberDescriptor.CurrentScript;
	}

	public void OutputAllDataTypes()
	{
		if (!TextManager.Instance)
		{
			return;
		}
		if (!Directory.Exists(Path.Combine(Application.streamingAssetsPath, "Mods\\TypesOutput")))
		{
			Directory.CreateDirectory(Path.Combine(Application.streamingAssetsPath, "Mods\\TypesOutput"));
		}
		string path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\TypesOutput\\Types-Objects.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		File.AppendAllText(path, "Object Types:\n\n");
		for (int i = 0; i < 673; i++)
		{
			ObjectType objectType = (ObjectType)i;
			File.AppendAllText(path, objectType.ToString() + " (" + TextManager.Instance.Get(objectType.ToString()) + ")\n");
		}
		path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\TypesOutput\\Types-FarmerStates.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		File.AppendAllText(path, "Farmer States:\n\n");
		for (int j = 0; j < 52; j++)
		{
			Farmer.State state = (Farmer.State)j;
			File.AppendAllText(path, state.ToString() + "\n");
		}
		path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\TypesOutput\\Types-Tiles.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		File.AppendAllText(path, "Tile Types:\n\n");
		for (int k = 0; k < 71; k++)
		{
			Tile.TileType newType = (Tile.TileType)k;
			File.AppendAllText(path, newType.ToString() + " (" + TextManager.Instance.Get(Tile.GetNameFromType(newType)).ToString() + ")\n");
		}
		path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\TypesOutput\\Types-GameStates.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		File.AppendAllText(path, "Game States:\n\n");
		for (int l = 0; l < 59; l++)
		{
			GameStateManager.State state2 = (GameStateManager.State)l;
			File.AppendAllText(path, state2.ToString() + "\n");
		}
		path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\TypesOutput\\Types-AudioEvents.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		File.AppendAllText(path, "Audio Events:\n\n");
		List<AudioSource> allSounds = AudioManager.Instance.GetAllSounds();
		List<string> list = new List<string>();
		foreach (AudioSource item in allSounds)
		{
			if (item != null && item.clip != null && !list.Contains(item.clip.name.ToString()))
			{
				list.Add(item.clip.name.ToString());
			}
		}
		foreach (string item2 in list)
		{
			File.AppendAllText(path, item2 + "\n");
		}
		path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\TypesOutput\\Types-GameModels.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		File.AppendAllText(path, "Models:\n\n");
		ObjectTypeInfo[] objects = ObjectTypeList.m_Objects;
		foreach (ObjectTypeInfo objectTypeInfo in objects)
		{
			if (objectTypeInfo.m_ModelName.Length > 0 && objectTypeInfo.m_ModelName.Contains("Models/"))
			{
				File.AppendAllText(path, objectTypeInfo.m_ModelName + "\n");
			}
		}
		path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\TypesOutput\\Types-Variables.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		File.AppendAllText(path, "Variables:\n\n");
		foreach (KeyValuePair<string, VariableManager.Value> variable in VariableManager.Instance.m_Variables)
		{
			string text = variable.Key.Replace(".", " ");
			if (variable.Value.m_String != null && variable.Value.m_String.Length > 0)
			{
				File.AppendAllText(path, text + " Value:" + variable.Value.m_String + "\n");
			}
			else if ((float)variable.Value.m_Int != variable.Value.m_Float)
			{
				File.AppendAllText(path, text + " Value:" + variable.Value.m_Float + "\n");
			}
			else
			{
				File.AppendAllText(path, text + " Value:" + variable.Value.m_Int + "\n");
			}
		}
	}

	public void ReloadScripts()
	{
		AllModsScripts.Clear();
		Instance.RegisteredForInputPressCallback = false;
		Instance.RegisteredForInputMouseDownCallback = false;
		Instance.RegisteredInputModsKeyPress.Clear();
		Instance.RegisteredInputModsMouseDown.Clear();
		foreach (Mod currentMod in CurrentMods)
		{
			currentMod.ResetScriptsBefore();
			if (Directory.Exists(currentMod.FolderLocation))
			{
				string[] files = Directory.GetFiles(currentMod.FolderLocation, "*.lua", SearchOption.AllDirectories);
				currentMod.AddScripts(files);
				currentMod.ResetScriptsAfter();
			}
		}
		ResetBeforeLoad();
	}

	public void SetInitialMapData(GameOptions Ref)
	{
		m_GameOptionsRef = Ref;
		for (int i = 0; i < CurrentMods.Count; i++)
		{
			CurrentMods[i].SetupInitialMapData();
		}
		m_GameOptionsRef = null;
	}

	public void RegisterCustomCallback(CallbackData Info)
	{
		ModCallbacks.Add(Info);
	}

	public void CheckCustomCallback(CallbackTypes Type, ObjectType Obj, TileCoord Location, int ObjectUniqueID, int PlayerUniqueID)
	{
		foreach (CallbackData modCallback in ModCallbacks)
		{
			if (modCallback.Object != Obj || modCallback.CallbackType != Type)
			{
				continue;
			}
			string value = "";
			using (List<ModCustom>.Enumerator enumerator2 = ModCustomClasses.GetEnumerator())
			{
				while (enumerator2.MoveNext() && !enumerator2.Current.ModIDOriginals.TryGetValue(Obj, out value))
				{
				}
			}
			DynValue[] args = new DynValue[5]
			{
				DynValue.NewString(value),
				DynValue.NewNumber(Location.x),
				DynValue.NewNumber(Location.y),
				DynValue.NewNumber(ObjectUniqueID),
				DynValue.NewNumber(PlayerUniqueID)
			};
			modCallback.OwnerScript.Call(modCallback.CallbackFunction, args);
		}
	}
}
