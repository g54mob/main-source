using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using MoonSharp.Interpreter;
using Rewired;
using Steamworks;
using UnityEngine;

public class Mod
{
	private bool DebugInfo;

	public bool StartedUp;

	public string FolderLocation;

	private List<Texture> ModTextures;

	private List<AudioClip> ModSounds;

	private List<GameObject> ModModels;

	public List<ObjectType> CustomIDs;

	public List<ModManager.ExposedData> ExposedVars;

	public string SteamTitle;

	public string SteamDescription;

	public IList<string> SteamTags;

	public string SteamContentFolder;

	public string SteamContentImage;

	public string SteamImageName;

	public DynValue InputKeyPressCallback;

	public DynValue InputMouseDownCallback;

	public bool IsUsingKeybindings;

	public bool MenuStartedUp { get; private set; }

	public string Name { get; private set; }

	public bool IsLocal { get; private set; }

	public List<Script> LuaScripts { get; private set; }

	public int ItemsToLoad { get; private set; }

	public bool IsEnabled { get; private set; }

	public PublishedFileId_t m_PublishedFileId { get; private set; }

	public Mod(string ModName, int ItemsInMod, string Folder, bool LocalMod)
	{
		if (DebugInfo)
		{
			Debug.Log("MOD CREATED - " + ModName + " - ITEMS: " + ItemsInMod);
		}
		StartedUp = false;
		Name = ModName;
		FolderLocation = Folder;
		ItemsToLoad = ItemsInMod;
		IsLocal = LocalMod;
		MenuStartedUp = false;
		LuaScripts = new List<Script>();
		ModTextures = new List<Texture>();
		ModSounds = new List<AudioClip>();
		ModModels = new List<GameObject>();
		CustomIDs = new List<ObjectType>();
		ExposedVars = new List<ModManager.ExposedData>();
		IsEnabled = true;
		InputKeyPressCallback = DynValue.NewNil();
		InputMouseDownCallback = DynValue.NewNil();
	}

	public void AddSound(AudioClip Sound)
	{
		ModSounds.Add(Sound);
		int itemsToLoad = ItemsToLoad - 1;
		ItemsToLoad = itemsToLoad;
	}

	public AudioClip GetSound(string FileName)
	{
		for (int i = 0; i < ModSounds.Count; i++)
		{
			if (ModSounds[i].name == FileName)
			{
				return ModSounds[i];
			}
		}
		return null;
	}

	public void AddTexture(Texture Tex)
	{
		ModTextures.Add(Tex);
		int itemsToLoad = ItemsToLoad - 1;
		ItemsToLoad = itemsToLoad;
	}

	public Texture GetTexture(string FileName)
	{
		for (int i = 0; i < ModTextures.Count; i++)
		{
			if (ModTextures[i].name == FileName)
			{
				return ModTextures[i];
			}
		}
		return null;
	}

	public List<Texture> GetAllTextures()
	{
		return ModTextures;
	}

	public void AddModel(GameObject Model, string FileLoc, string Name)
	{
		ModModels.Add(Model);
		int itemsToLoad = ItemsToLoad - 1;
		ItemsToLoad = itemsToLoad;
	}

	public void AddScripts(string[] Scripts)
	{
		ModManager.Instance.AddModScripts(Scripts);
		for (int i = 0; i < Scripts.Length; i++)
		{
			Script script = new Script(CoreModules.Preset_SoftSandbox);
			string code = File.ReadAllText(Scripts[i]);
			if (script != null)
			{
				try
				{
					RegisterScriptGlobals(script);
					script.DoString(code);
				}
				catch (ScriptRuntimeException ex)
				{
					string descriptionOverride = "Function: " + Name + "\nError: " + ex.DecoratedMessage;
					ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Lua, descriptionOverride);
				}
			}
			LuaScripts.Add(script);
		}
	}

	private void RegisterScriptGlobals(Script NewScript)
	{
		if (NewScript.Globals != null)
		{
			NewScript.Globals["ModSound"] = ModManager.Instance.ModSoundClass;
			NewScript.Globals["ModVariable"] = ModManager.Instance.ModVariableClass;
			NewScript.Globals["ModBase"] = ModManager.Instance.ModBaseClass;
			NewScript.Globals["ModConverter"] = ModManager.Instance.ModConverterClass;
			NewScript.Globals["ModBuilding"] = ModManager.Instance.ModBuildingClass;
			NewScript.Globals["ModDecorative"] = ModManager.Instance.ModDecorativeClass;
			NewScript.Globals["ModTiles"] = ModManager.Instance.ModTilesClass;
			NewScript.Globals["ModPlayer"] = ModManager.Instance.ModPlayerClass;
			NewScript.Globals["ModBot"] = ModManager.Instance.ModBotClass;
			NewScript.Globals["ModDebug"] = ModManager.Instance.ModDebugClass;
			NewScript.Globals["ModHoldable"] = ModManager.Instance.ModHoldableClass;
			NewScript.Globals["ModFood"] = ModManager.Instance.ModFoodClass;
			NewScript.Globals["ModObject"] = ModManager.Instance.ModObjectClass;
			NewScript.Globals["ModTool"] = ModManager.Instance.ModToolClass;
			NewScript.Globals["ModCamera"] = ModManager.Instance.ModCameraClass;
			NewScript.Globals["ModQuest"] = ModManager.Instance.ModQuestClass;
			NewScript.Globals["ModGoTo"] = ModManager.Instance.ModGoToClass;
			NewScript.Globals["ModHat"] = ModManager.Instance.ModHatClass;
			NewScript.Globals["ModTop"] = ModManager.Instance.ModTopClass;
			NewScript.Globals["ModUI"] = ModManager.Instance.ModUIClass;
			NewScript.Globals["ModStorage"] = ModManager.Instance.ModStorageClass;
			NewScript.Globals["ModMedicine"] = ModManager.Instance.ModMedicineClass;
			NewScript.Globals["ModToy"] = ModManager.Instance.ModToyClass;
			NewScript.Globals["ModEducation"] = ModManager.Instance.ModEducationClass;
			NewScript.Globals["ModSaveData"] = ModManager.Instance.ModSaveDataClass;
		}
	}

	public void CallFunction(Script CurrScript, string FuncName, params DynValue[] args)
	{
		if ((GeneralUtils.m_InGame && (FuncName.Equals("OnUpdate") || FuncName.Equals("BeforeLoad") || FuncName.Equals("AfterLoad") || FuncName.Equals("AfterLoad_CreatedWorld") || FuncName.Equals("AfterLoad_LoadedWorld") || FuncName.Equals("Creation"))) || (!GeneralUtils.m_InGame && (FuncName.Equals("SteamDetails") || FuncName.Equals("Creation") || FuncName.Equals("AfterLoad_CreatedWorld") || FuncName.Equals("Expose"))))
		{
			if (DebugInfo)
			{
				Debug.Log(string.Concat("SCRIPT ", CurrScript, " FUNC: ", FuncName, " ARGS ", args));
			}
			try
			{
				CurrScript.Call(CurrScript.Globals[FuncName], args);
			}
			catch (ScriptRuntimeException ex)
			{
				string text = (IsLocal ? Name : (Name + "\\" + SteamTitle));
				string descriptionOverride = text + "\nFunction: " + FuncName + "\nError: " + ex.DecoratedMessage;
				ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Lua, descriptionOverride);
			}
		}
	}

	private void MenuStart(bool CallCreation = true)
	{
		for (int i = 0; i < LuaScripts.Count; i++)
		{
			if (LuaScripts[i].Globals["SteamDetails"] != null)
			{
				CallFunction(LuaScripts[i], "SteamDetails");
			}
		}
		for (int j = 0; j < LuaScripts.Count; j++)
		{
			if (LuaScripts[j].Globals["Expose"] != null)
			{
				CallFunction(LuaScripts[j], "Expose");
			}
		}
		if (CallCreation)
		{
			for (int k = 0; k < LuaScripts.Count; k++)
			{
				ModManager.Instance.CreationScript = LuaScripts[k];
				if (LuaScripts[k].Globals["Creation"] != null)
				{
					CallFunction(LuaScripts[k], "Creation");
				}
			}
		}
		MenuStartedUp = true;
	}

	private void GameStart()
	{
		for (int i = 0; i < LuaScripts.Count; i++)
		{
			if (LuaScripts[i].Globals["Creation"] != null)
			{
				CallFunction(LuaScripts[i], "Creation");
			}
		}
		for (int j = 0; j < LuaScripts.Count; j++)
		{
			if (LuaScripts[j].Globals["BeforeLoad"] != null)
			{
				CallFunction(LuaScripts[j], "BeforeLoad");
			}
		}
		foreach (ObjectType customID in CustomIDs)
		{
			ObjectTypeList.Instance.UpdateBootVars(customID);
		}
	}

	public void PostCreate()
	{
		for (int i = 0; i < LuaScripts.Count; i++)
		{
			if (LuaScripts[i].Globals["AfterLoad"] != null)
			{
				CallFunction(LuaScripts[i], "AfterLoad");
			}
		}
	}

	public void PostCreateSpecific(bool Created)
	{
		if (!IsEnabled)
		{
			return;
		}
		for (int i = 0; i < LuaScripts.Count; i++)
		{
			if (Created)
			{
				if (LuaScripts[i].Globals["AfterLoad_CreatedWorld"] != null)
				{
					CallFunction(LuaScripts[i], "AfterLoad_CreatedWorld");
				}
			}
			else if (LuaScripts[i].Globals["AfterLoad_LoadedWorld"] != null)
			{
				CallFunction(LuaScripts[i], "AfterLoad_LoadedWorld");
			}
		}
		PostCreate();
	}

	public void SetupInitialMapData()
	{
		if (!IsEnabled)
		{
			return;
		}
		for (int i = 0; i < LuaScripts.Count; i++)
		{
			if (LuaScripts[i].Globals["AfterLoad_CreatedWorld"] != null)
			{
				CallFunction(LuaScripts[i], "AfterLoad_CreatedWorld");
			}
		}
	}

	public void Update()
	{
		if (!GeneralUtils.m_InGame)
		{
			if (ItemsToLoad == 0 && !MenuStartedUp)
			{
				AddExposedVariable("ModsEnabledTitle", DynValue.NewBoolean(true), null, null, null, true);
				MenuStart();
				LoadExposedVariables();
			}
		}
		else
		{
			if (!IsEnabled)
			{
				return;
			}
			if (!StartedUp && ItemsToLoad == 0)
			{
				GameStart();
				StartedUp = true;
				return;
			}
			for (int i = 0; i < LuaScripts.Count; i++)
			{
				if (LuaScripts[i].Globals["OnUpdate"] != null)
				{
					CallFunction(LuaScripts[i], "OnUpdate", DynValue.NewNumber(Time.deltaTime));
				}
			}
		}
	}

	public void SetSteamWorkshopDetails(string Title, string Description, IList<string> Tags, string ContentImage)
	{
		SteamTitle = Title;
		SteamDescription = Description;
		SteamTags = Tags;
		SteamContentFolder = FolderLocation;
		SteamContentImage = FolderLocation + "/textures/" + ContentImage;
		SteamImageName = ContentImage.Replace("\\", "").Replace(".png", "").Replace(".jpg", "")
			.Replace(".jpeg", "")
			.ToLower();
	}

	public void UploadToSteamWorkshop()
	{
		SteamWorkshopManager.Instance.CreateWorkshopItem(this);
	}

	public void SetPublishedFieldID(PublishedFileId_t NewPublishedFileId)
	{
		m_PublishedFileId = NewPublishedFileId;
		string contents = NewPublishedFileId.ToString();
		string text = FolderLocation + "\\steamModID";
		try
		{
			File.WriteAllText(text, contents);
		}
		catch (UnauthorizedAccessException ex)
		{
			ErrorMessage.LogError("Summary Save - UnauthorizedAccessException : " + text + " " + ex.ToString());
		}
	}

	public void SetLoadedPublishedID(string[] IDs)
	{
		for (int i = 0; i < IDs.Length; i++)
		{
			string text = File.ReadAllText(IDs[i]);
			if (text.Length > 0)
			{
				ulong value = Convert.ToUInt64(text);
				m_PublishedFileId = new PublishedFileId_t(value);
				if (DebugInfo)
				{
					Debug.Log("LOADED ID " + m_PublishedFileId);
				}
			}
		}
	}

	public GameObject GetCustomModel(string Name)
	{
		foreach (GameObject modModel in ModModels)
		{
			if (modModel.name == Name)
			{
				return modModel;
			}
		}
		return null;
	}

	public void AddExposedVariable(string UniqueName, DynValue DefaultValue, DynValue Callback, DynValue Min = null, DynValue Max = null, bool UsingLookup = false)
	{
		foreach (ModManager.ExposedData exposedVar in ExposedVars)
		{
			if (exposedVar.VarName.Equals(UniqueName))
			{
				return;
			}
		}
		if (Callback != null && Callback.Type != DataType.Function)
		{
			string descriptionOverride = "Error: ModBase.ExposeVariable - Callback is not a function";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return;
		}
		ModManager.ExposedData item = new ModManager.ExposedData
		{
			VarName = UniqueName,
			VarType = DefaultValue.Type,
			VarValue = DefaultValue,
			Callback = Callback,
			MinValue = Min,
			MaxValue = Max,
			UsesLookup = UsingLookup,
			IsKeybinding = false
		};
		if (item.VarType == DataType.Number && Min != null && Max != null && Min.Type == DataType.Number && Max.Type == DataType.Number && (DefaultValue.Number < Min.Number || DefaultValue.Number > Max.Number))
		{
			string descriptionOverride2 = "Error: ModBase.ExposeVariable '" + UniqueName + "' - Value is outside of Min/Max Range";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride2);
			return;
		}
		if (item.VarType == DataType.Number && Min == null)
		{
			item.MinValue = DynValue.NewNumber(0.0);
		}
		if (item.VarType == DataType.Number && Max == null)
		{
			item.MaxValue = DynValue.NewNumber(100.0);
		}
		ExposedVars.Add(item);
	}

	public void AddExposedVariableList(string UniqueName, DynValue[] DefaultOptions, int SelectedOption, DynValue Callback)
	{
		foreach (ModManager.ExposedData exposedVar in ExposedVars)
		{
			if (exposedVar.VarName.Equals(UniqueName))
			{
				return;
			}
		}
		if (Callback != null && Callback.Type != DataType.Function)
		{
			string descriptionOverride = "Error: ModBase.ExposeVariable - Callback is not a function";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return;
		}
		ModManager.ExposedData item = new ModManager.ExposedData
		{
			VarName = UniqueName,
			VarType = DataType.Table,
			VarValue = DynValue.NewNumber(SelectedOption),
			Callback = Callback,
			UsesLookup = false,
			IsKeybinding = false,
			VarValuesList = new List<DynValue>()
		};
		foreach (DynValue item2 in DefaultOptions)
		{
			item.VarValuesList.Add(item2);
		}
		ExposedVars.Add(item);
	}

	public void AddExposedKeybinding(string UniqueName, int Key, DynValue Callback)
	{
		foreach (ModManager.ExposedData exposedVar in ExposedVars)
		{
			if (exposedVar.VarName.Equals(UniqueName))
			{
				return;
			}
		}
		if (Callback != null && Callback.Type != DataType.Function)
		{
			string descriptionOverride = "Error: ModBase.AddExposedKeybinding - Callback is not a function";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return;
		}
		ModManager.ExposedData item = new ModManager.ExposedData
		{
			VarName = UniqueName,
			VarType = DataType.Nil,
			VarValue = DynValue.NewNumber(Key),
			Callback = Callback,
			MinValue = DynValue.NewNil(),
			MaxValue = DynValue.NewNil(),
			UsesLookup = false,
			IsKeybinding = true
		};
		ExposedVars.Add(item);
		IsUsingKeybindings = true;
	}

	public void RegisterForInputPress(DynValue Callback)
	{
		InputKeyPressCallback = Callback;
		ModManager.Instance.RegisteredForInputPressCallback = true;
		foreach (Script luaScript in LuaScripts)
		{
			if (luaScript.IsOwnership(luaScript, Callback))
			{
				ModManager.Instance.RegisteredInputModsKeyPress.Add(this, luaScript);
			}
		}
	}

	public void RegisterForInputMouseDown(DynValue Callback)
	{
		InputMouseDownCallback = Callback;
		ModManager.Instance.RegisteredForInputMouseDownCallback = true;
		foreach (Script luaScript in LuaScripts)
		{
			if (luaScript.IsOwnership(luaScript, Callback))
			{
				ModManager.Instance.RegisteredInputModsMouseDown.Add(this, luaScript);
			}
		}
	}

	public void UpdateExposedVariable(string UniqueName, DynValue Value, bool Save = true)
	{
		if (UniqueName.Equals("ModsEnabledTitle"))
		{
			IsEnabled = Value.Boolean;
			foreach (ObjectType customID in CustomIDs)
			{
				foreach (ModCustom modCustomClass in ModManager.Instance.ModCustomClasses)
				{
					if (modCustomClass.IsEnabled.ContainsKey(customID))
					{
						if (!IsEnabled && ObjectTypeList.Instance != null)
						{
							ObjectTypeList.Instance.DisableCustomItem(customID);
						}
						modCustomClass.IsEnabled.Remove(customID);
						modCustomClass.IsEnabled.Add(customID, IsEnabled);
					}
				}
			}
		}
		int count = ExposedVars.Count;
		for (int i = 0; i < count; i++)
		{
			if (!ExposedVars[i].VarName.Equals(UniqueName))
			{
				continue;
			}
			ModManager.ExposedData exposedData = default(ModManager.ExposedData);
			exposedData = ExposedVars[i];
			exposedData.VarValue = Value;
			ExposedVars.RemoveAt(i);
			ExposedVars.Insert(i, exposedData);
			if (exposedData.Callback == null)
			{
				break;
			}
			foreach (Script luaScript in LuaScripts)
			{
				DynValue[] args = new DynValue[2]
				{
					exposedData.VarValue,
					DynValue.NewString(exposedData.VarName)
				};
				if (luaScript.IsOwnership(luaScript, exposedData.Callback))
				{
					luaScript.Call(exposedData.Callback, args);
				}
			}
			break;
		}
		if (Save)
		{
			SaveExposedVariables();
		}
	}

	public void UpdateKeybindingsCall(InputActionEventData data)
	{
		if (!IsEnabled)
		{
			return;
		}
		foreach (ModManager.ExposedData exposedVar in ExposedVars)
		{
			if (!exposedVar.IsKeybinding || (int)exposedVar.VarValue.Number != data.actionId - 49 + 1 || exposedVar.Callback == null)
			{
				continue;
			}
			foreach (Script luaScript in LuaScripts)
			{
				DynValue[] args = new DynValue[1] { DynValue.NewString(exposedVar.VarName) };
				if (luaScript.IsOwnership(luaScript, exposedVar.Callback))
				{
					luaScript.Call(exposedVar.Callback, args);
				}
			}
		}
	}

	private void LoadExposedVariables()
	{
		string path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\" + Name + "\\Config.txt";
		if (!IsLocal)
		{
			path = FolderLocation + "\\Config.txt";
		}
		if (!File.Exists(path))
		{
			return;
		}
		StreamReader streamReader = new StreamReader(path);
		string text;
		while ((text = streamReader.ReadLine()) != null)
		{
			int num = text.IndexOf('=');
			if (num == -1)
			{
				continue;
			}
			string text2 = text.Substring(0, num);
			string text3 = text.Substring(num + 1, text.Length - num - 1);
			if (text2.Equals("Enabled"))
			{
				UpdateExposedVariable("ModsEnabledTitle", DynValue.NewBoolean(bool.Parse(text3)), false);
				continue;
			}
			float result = 0f;
			if (text3.Equals("true") || text3.Equals("false"))
			{
				UpdateExposedVariable(text2, DynValue.NewBoolean(bool.Parse(text3)), false);
			}
			else if (float.TryParse(text3, NumberStyles.Number, CultureInfo.InvariantCulture, out result))
			{
				UpdateExposedVariable(text2, DynValue.NewNumber(result), false);
			}
		}
		streamReader.Close();
	}

	private void SaveExposedVariables()
	{
		string text = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\" + Name + "\\Config.txt";
		if (!IsLocal)
		{
			text = FolderLocation + "\\Config.txt";
		}
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		foreach (ModManager.ExposedData exposedVar in ExposedVars)
		{
			if (exposedVar.IsKeybinding)
			{
				continue;
			}
			try
			{
				if (exposedVar.VarName.Equals("ModsEnabledTitle"))
				{
					File.AppendAllText(text, string.Concat("Enabled=", exposedVar.VarValue, "\n"));
					continue;
				}
				File.AppendAllText(text, string.Concat(exposedVar.VarName, "=", exposedVar.VarValue, "\n"));
			}
			catch (UnauthorizedAccessException ex)
			{
				ErrorMessage.LogError("Summary Save - UnauthorizedAccessException : " + text + " " + ex.ToString());
				break;
			}
		}
	}

	public void ResetScriptsBefore()
	{
		ExposedVars.Clear();
		LuaScripts.Clear();
		InputKeyPressCallback = null;
		InputMouseDownCallback = null;
	}

	public void ResetScriptsAfter()
	{
		AddExposedVariable("ModsEnabledTitle", DynValue.NewBoolean(true), null, null, null, true);
		MenuStart(false);
		LoadExposedVariables();
	}
}
