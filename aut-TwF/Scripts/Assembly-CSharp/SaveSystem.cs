using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Sirenix.Utilities;
using Steamworks;
using UnityEngine;

public class SaveSystem : MonoBehaviour, ISavable
{
	private const string SAVE_DIRECTORY_NAME = "SavedData";

	public static SaveSystem instance;

	[SerializeField]
	private bool isDevelopmentVersion;

	[SerializeField]
	private string developmentVersion = "dev_0";

	[Savable("saveProfiles", true, false)]
	private List<SaveProfile> saveProfiles;

	private SaveProfile currentProfile;

	[Savable("savedGameMetadata", true, false)]
	private Dictionary<string, object> savedGameMetadata;

	private bool isLoading;

	private List<string> pendingSaveGroups = new List<string>();

	private Dictionary<string, object> savedData;

	private string lastSavedGameVersion = "";

	private Coroutine delayedProfileMetadataCoroutine;

	public Dictionary<string, object> SavedData => savedData;

	public Dictionary<string, object> SavedGameMetadata => savedGameMetadata;

	public string LastSavedGameVersion
	{
		get
		{
			return lastSavedGameVersion;
		}
		private set
		{
			lastSavedGameVersion = value;
		}
	}

	public SaveProfile CurrentProfile
	{
		get
		{
			return currentProfile;
		}
		private set
		{
			if (currentProfile != value)
			{
				currentProfile = value;
				savedData = new Dictionary<string, object>();
				if (currentProfile != null)
				{
					PlayerPrefs.SetString("currentSaveProfile", CurrentProfile.Id);
					LoadMainData();
				}
				this.onActiveProfileChanged?.Invoke(currentProfile);
			}
		}
	}

	public event Action<string> onSave;

	public event Action<string> onPreLoad;

	public event Action<string> onLoad;

	public event Action onProfilesChanged;

	public event Action<SaveProfile> onActiveProfileChanged;

	public event Action<SaveProfile, bool> onProfileDataDeleted;

	public void DeleteAllData()
	{
		if (Directory.Exists(GetBaseFolderPath()))
		{
			Directory.Delete(GetBaseFolderPath());
			savedData = new Dictionary<string, object>();
		}
	}

	private void DeleteProfileData(SaveProfile profile)
	{
		if (Directory.Exists(GetProfileFolderPath(profile.Id)))
		{
			Directory.Delete(GetProfileFolderPath(profile.Id), recursive: true);
			this.onProfileDataDeleted?.Invoke(profile, profile.Id == CurrentProfile.Id);
		}
	}

	public void DeletePlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			savedData = new Dictionary<string, object>();
			saveProfiles = new List<SaveProfile>();
			if (!Directory.Exists(GetBaseFolderPath()))
			{
				Directory.CreateDirectory(GetBaseFolderPath());
			}
			LoadProfiles();
		}
		else if (instance.gameObject != base.gameObject)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public SaveProfile CreateNewProfile(string displayName, bool generateEmptyMetadata = false)
	{
		SaveProfile saveProfile = new SaveProfile("saveProfile_" + saveProfiles.Count, displayName);
		saveProfiles.Add(saveProfile);
		if (generateEmptyMetadata)
		{
			saveProfile.GenerateEmptyMetadata();
		}
		SaveProfiles();
		this.onProfilesChanged?.Invoke();
		return saveProfile;
	}

	public bool SelectProfile(string profileId)
	{
		SaveProfile saveProfile = saveProfiles.Find((SaveProfile x) => x.Id == profileId);
		if (saveProfile != null)
		{
			CurrentProfile = saveProfile;
			return true;
		}
		return false;
	}

	public void RenameProfile(string profileId, string newName)
	{
		FindProfileById(profileId).DisplayName = newName;
		SaveProfiles();
		if (CurrentProfile.Id == profileId)
		{
			this.onActiveProfileChanged?.Invoke(CurrentProfile);
		}
		this.onProfilesChanged?.Invoke();
	}

	public void DeleteProfile(SaveProfile profile)
	{
		DeleteProfileData(profile);
		bool num = profile.Id == CurrentProfile.Id;
		saveProfiles.Remove(saveProfiles.Find((SaveProfile x) => x.Id == profile.Id));
		if (num)
		{
			if (saveProfiles.Count > 0)
			{
				SelectProfile(saveProfiles[0].Id);
			}
			else
			{
				string displayName = "Tower Factory";
				SelectProfile(CreateNewProfile(displayName).Id);
			}
		}
		SaveProfiles();
		this.onProfilesChanged?.Invoke();
	}

	private void SaveProfiles()
	{
		SetDataById("SaveSystem", GetDataToSaveFromObject(base.gameObject, "profiles"), "profiles");
		InternalSaveData("profiles", GetBaseFolderPath(), "Profiles");
	}

	private void LoadProfiles()
	{
		InternalLoadData(GetProfilesPath(), "profiles");
		if (savedData.ContainsKey("profiles"))
		{
			LoadObjectData(base.gameObject, (SavedData["profiles"] as Dictionary<string, object>)["SaveSystem"] as Dictionary<string, object>);
		}
		else
		{
			LoadObjectData(base.gameObject, null);
		}
		this.onProfilesChanged?.Invoke();
	}

	public List<SaveProfile> GetAllProfiles()
	{
		return saveProfiles;
	}

	public SaveProfile FindProfileById(string profileId)
	{
		for (int i = 0; i < saveProfiles.Count; i++)
		{
			if (saveProfiles[i].Id == profileId)
			{
				return saveProfiles[i];
			}
		}
		return null;
	}

	private string GetApplicationPath()
	{
		return Application.persistentDataPath + "/files";
	}

	private string GetProfileFolderPath(string profileId)
	{
		if (isDevelopmentVersion)
		{
			return GetApplicationPath() + "/SavedData/DevelopmentBuild_" + developmentVersion + "/" + profileId;
		}
		return GetApplicationPath() + "/SavedData/" + profileId;
	}

	private string GetBaseFolderPath()
	{
		if (isDevelopmentVersion)
		{
			return GetApplicationPath() + "/SavedData/DevelopmentBuild_" + developmentVersion;
		}
		return GetApplicationPath() + "/SavedData";
	}

	private string GetSavePath(string fileName = "")
	{
		return GetProfileFolderPath(CurrentProfile.Id) + ((fileName != "") ? ("/" + fileName + ".save") : "");
	}

	private string GetOldSavePath()
	{
		return GetBaseFolderPath() + "/Data.dat";
	}

	private string GetProfilesPath()
	{
		return GetBaseFolderPath() + "/Profiles.save";
	}

	public object GetDataById(string id, Dictionary<string, object> savedData)
	{
		if (savedData.ContainsKey(id))
		{
			return savedData[id];
		}
		return null;
	}

	public void SetDataById(string id, object data, string saveGroup)
	{
		if (!SavedData.ContainsKey(saveGroup))
		{
			SavedData.Add(saveGroup, new Dictionary<string, object>());
		}
		Dictionary<string, object> dictionary = SavedData[saveGroup] as Dictionary<string, object>;
		if (dictionary.ContainsKey(id))
		{
			dictionary[id] = data;
		}
		else
		{
			dictionary.Add(id, data);
		}
	}

	public bool HasLoadedData(string saveGroup)
	{
		if (SavedData != null)
		{
			return SavedData.ContainsKey(saveGroup.ToLower());
		}
		return false;
	}

	public bool ExistsSavedDataFile(string saveGroup)
	{
		try
		{
			return File.Exists(GetSavePath() + "/" + saveGroup.ToTitleCase() + ".save");
		}
		catch
		{
			return false;
		}
	}

	public bool ExistsSavedGame()
	{
		return ExistsSavedDataFile("SavedGame");
	}

	public bool DeleteSavedGame()
	{
		try
		{
			if (SavedData.ContainsKey("savedgame"))
			{
				SavedData.Remove("savedgame");
			}
			if (ExistsSavedDataFile("SavedGame"))
			{
				File.Delete(GetSavePath() + "/SavedGame.save");
			}
			savedGameMetadata = null;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool SaveData(string saveGroup = "Main", bool eraseExistingData = false)
	{
		if (isLoading)
		{
			pendingSaveGroups.AddUnique(saveGroup);
			return true;
		}
		if (CurrentProfile == null && (saveProfiles == null || saveProfiles.Count < 1 || !SelectProfile(saveProfiles[0].Id)))
		{
			CreateDefaultProfile();
		}
		if (CurrentProfile.GenerateMetadata())
		{
			SaveProfiles();
			this.onProfilesChanged?.Invoke();
		}
		else
		{
			this.StartCoroutineCheckingVar(DelayedProfileMetadataCoroutine(), ref delayedProfileMetadataCoroutine);
		}
		return InternalSaveData(saveGroup, GetSavePath(), saveGroup.ToTitleCase(), eraseExistingData);
	}

	public bool SaveGame(Dictionary<string, object> metadata)
	{
		savedGameMetadata = metadata;
		return SaveData("SavedGame", eraseExistingData: true);
	}

	private IEnumerator DelayedProfileMetadataCoroutine()
	{
		yield return null;
		CurrentProfile.GenerateMetadata();
		SaveProfiles();
		this.onProfilesChanged?.Invoke();
	}

	private bool InternalSaveData(string saveGroup, string directoryPath, string fileName, bool eraseExistingData = false)
	{
		saveGroup = saveGroup.ToLower();
		if (!eraseExistingData && !SavedData.ContainsKey(saveGroup))
		{
			SavedData.Add(saveGroup, new Dictionary<string, object>());
		}
		if (eraseExistingData && SavedData.ContainsKey(saveGroup))
		{
			SavedData.Remove(saveGroup);
		}
		this.onSave?.Invoke(saveGroup);
		lastSavedGameVersion = Application.version;
		SetDataById("lastSavedGameVersion", lastSavedGameVersion, "main");
		return SaveDataToFile(SavedData[saveGroup], directoryPath, fileName);
	}

	private bool SaveDataToFile(object dataToSave, string directoryPath, string fileName)
	{
		try
		{
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = File.Create(directoryPath + "/" + fileName + ".save");
			binaryFormatter.SurrogateSelector = GetSurrogateSelector();
			binaryFormatter.Serialize(fileStream, dataToSave);
			fileStream.Close();
			return true;
		}
		catch (IOException ex)
		{
			Debug.LogError("Error saving data to " + directoryPath + "/" + fileName + ".save: " + ex.Message);
			return false;
		}
	}

	public bool LoadMainData()
	{
		if (!File.Exists(GetSavePath("Main")) && File.Exists(GetOldSavePath()))
		{
			if (File.Exists(GetBaseFolderPath() + "/Data_OLD.dat"))
			{
				File.Delete(GetOldSavePath());
				return InternalLoadData(GetSavePath("Main"), "main");
			}
			if (InternalLoadData(GetOldSavePath(), "main") && SaveData())
			{
				File.Move(GetOldSavePath(), GetBaseFolderPath() + "/Data_OLD.dat");
				return true;
			}
			return false;
		}
		return InternalLoadData(GetSavePath("Main"), "main");
	}

	public bool LoadSavedGameData()
	{
		return InternalLoadData(GetSavePath("SavedGame"), "savedGame");
	}

	private bool InternalLoadData(string path, string saveGroup)
	{
		this.onPreLoad?.Invoke(saveGroup);
		saveGroup = saveGroup.ToLower();
		Dictionary<string, object> dictionary = LoadDataFromFile(path) as Dictionary<string, object>;
		isLoading = true;
		if (dictionary != null)
		{
			pendingSaveGroups.Clear();
			if (!savedData.ContainsKey(saveGroup))
			{
				savedData.Add(saveGroup, new Dictionary<string, object>());
			}
			savedData[saveGroup] = dictionary;
			if (dictionary != null && dictionary.ContainsKey("lastSavedGameVersion"))
			{
				lastSavedGameVersion = dictionary["lastSavedGameVersion"] as string;
			}
			this.onLoad?.Invoke(saveGroup);
			if (pendingSaveGroups.Count > 0)
			{
				foreach (string pendingSaveGroup in pendingSaveGroups)
				{
					SaveData(pendingSaveGroup);
				}
			}
			isLoading = false;
			return true;
		}
		savedData.Remove(saveGroup);
		this.onLoad?.Invoke(saveGroup);
		isLoading = false;
		return false;
	}

	private object LoadDataFromFile(string filePath)
	{
		try
		{
			if (File.Exists(filePath))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				binaryFormatter.SurrogateSelector = GetSurrogateSelector();
				object result = binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return result;
			}
		}
		catch (IOException ex)
		{
			Debug.LogError("Error loading data from " + filePath + ": " + ex.Message);
		}
		return null;
	}

	private SurrogateSelector GetSurrogateSelector()
	{
		SurrogateSelector surrogateSelector = new SurrogateSelector();
		Vector2SerializationSurrogate surrogate = new Vector2SerializationSurrogate();
		Vector3SerializationSurrogate surrogate2 = new Vector3SerializationSurrogate();
		QuaternionSerializationSurrogate surrogate3 = new QuaternionSerializationSurrogate();
		surrogateSelector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), surrogate);
		surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), surrogate2);
		surrogateSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), surrogate3);
		return surrogateSelector;
	}

	private static List<FieldInfo> GetClassFields(Type type, bool getParentFields)
	{
		List<FieldInfo> list = new List<FieldInfo>();
		list.AddRange(type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
		if (getParentFields)
		{
			type = type.BaseType;
			while (type != null && typeof(ISavable).IsAssignableFrom(type))
			{
				list.AddRange(type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				type = type.BaseType;
			}
		}
		return list;
	}

	public static Dictionary<string, object> GetDataToSaveFromObject(object context, string saveGroup, bool hasSaveTransformAtt = false)
	{
		if (context != null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			ISavable[] array = null;
			GameObject gameObject = context as GameObject;
			if (!gameObject)
			{
				gameObject = (context as MonoBehaviour)?.gameObject;
			}
			if ((bool)gameObject)
			{
				SaveComponent component = gameObject.GetComponent<SaveComponent>();
				if (((bool)component && component.SaveGroup.ToLower() == saveGroup.ToLower() && component.SaveTransform) || hasSaveTransformAtt)
				{
					dictionary.Add("transform.position", gameObject.transform.position);
					dictionary.Add("transform.rotation", gameObject.transform.rotation);
					dictionary.Add("transform.scale", gameObject.transform.localScale);
				}
				array = gameObject.GetComponents<ISavable>();
			}
			else if (context is ISavable)
			{
				array = new ISavable[1] { context as ISavable };
			}
			ISavable[] array2 = array;
			foreach (ISavable savable in array2)
			{
				if (savable.IgnoreSave())
				{
					continue;
				}
				savable.OnSave();
				foreach (FieldInfo classField in GetClassFields(savable.GetType(), getParentFields: true))
				{
					if (!(Attribute.GetCustomAttribute(classField, typeof(SavableAttribute)) is SavableAttribute savableAttribute))
					{
						continue;
					}
					if ((classField.FieldType.IsArray && typeof(ISavable).IsAssignableFrom(classField.FieldType.GetElementType())) || (typeof(IList).IsAssignableFrom(classField.FieldType) && classField.FieldType.GetGenericArguments().Length != 0 && typeof(ISavable).IsAssignableFrom(classField.FieldType.GetGenericArguments()[0])))
					{
						List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
						if (classField.GetValue(savable) is IList list2)
						{
							foreach (object item in list2)
							{
								if (item == null || !(item as ISavable).IgnoreSave())
								{
									list.Add(GetDataToSaveFromObject(item, saveGroup, savableAttribute.saveTransform));
								}
							}
						}
						if (list.Count > 0)
						{
							dictionary.TryAdd(savableAttribute.id, list);
						}
					}
					else if (typeof(IDictionary).IsAssignableFrom(classField.FieldType) && typeof(ISavable).IsAssignableFrom(classField.FieldType.GetGenericArguments()[1]))
					{
						IDictionary dictionary2 = classField.GetValue(savable) as IDictionary;
						Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
						if (dictionary2 != null)
						{
							foreach (string key in dictionary2.Keys)
							{
								if (dictionary2[key] == null || !(dictionary2[key] as ISavable).IgnoreSave())
								{
									dictionary3.Add(key, GetDataToSaveFromObject(dictionary2[key], saveGroup, savableAttribute.saveTransform));
								}
							}
						}
						if (dictionary3.Count > 0)
						{
							dictionary.TryAdd(savableAttribute.id, dictionary3);
						}
					}
					else if (classField.FieldType.GetInterfaces().Contains(typeof(ISavable)))
					{
						dictionary.TryAdd(savableAttribute.id, GetDataToSaveFromObject(classField.GetValue(savable), saveGroup, savableAttribute.saveTransform));
					}
					else
					{
						dictionary.TryAdd(savableAttribute.id, classField.GetValue(savable));
					}
				}
			}
			return dictionary;
		}
		return null;
	}

	public static void LoadObjectData(object context, Dictionary<string, object> dataToLoad, bool hasSaveTransformAtt = false)
	{
		bool hasLoadedSomething = false;
		ISavable[] array = null;
		if (context == null)
		{
			return;
		}
		GameObject gameObject = context as GameObject;
		if (!gameObject)
		{
			gameObject = (context as MonoBehaviour)?.gameObject;
		}
		if ((bool)gameObject)
		{
			SaveComponent component = gameObject.GetComponent<SaveComponent>();
			if ((((bool)component && component.SaveTransform) || hasSaveTransformAtt) && dataToLoad != null && dataToLoad.ContainsKey("transform.position"))
			{
				gameObject.transform.position = (Vector3)dataToLoad["transform.position"];
				gameObject.transform.rotation = (Quaternion)dataToLoad["transform.rotation"];
				gameObject.transform.localScale = (Vector3)dataToLoad["transform.scale"];
			}
			array = gameObject.GetComponents<ISavable>();
		}
		else if (context is ISavable)
		{
			array = new ISavable[1] { context as ISavable };
		}
		ISavable[] array2 = array;
		foreach (ISavable savable in array2)
		{
			if (savable.IgnoreSave())
			{
				continue;
			}
			savable.OnPreLoad();
			if (dataToLoad != null)
			{
				hasLoadedSomething = false;
				foreach (FieldInfo classField in GetClassFields(savable.GetType(), getParentFields: true))
				{
					if (!(Attribute.GetCustomAttribute(classField, typeof(SavableAttribute)) is SavableAttribute savableAttribute))
					{
						continue;
					}
					if (savableAttribute.autoLoad)
					{
						if (!dataToLoad.ContainsKey(savableAttribute.id))
						{
							continue;
						}
						object obj = dataToLoad[savableAttribute.id];
						if (obj == null)
						{
							continue;
						}
						if ((classField.FieldType.IsArray && typeof(ISavable).IsAssignableFrom(classField.FieldType.GetElementType())) || (typeof(IList).IsAssignableFrom(classField.FieldType) && classField.FieldType.GetGenericArguments().Length != 0 && typeof(ISavable).IsAssignableFrom(classField.FieldType.GetGenericArguments()[0])))
						{
							int num = 0;
							if (classField.GetValue(savable) is IList list)
							{
								foreach (object item in list)
								{
									if ((item == null || !(item as ISavable).IgnoreSave()) && (obj as List<Dictionary<string, object>>).Count > num)
									{
										LoadObjectData(item, (obj as List<Dictionary<string, object>>)[num], savableAttribute.saveTransform);
										num++;
									}
								}
							}
						}
						else if (typeof(IDictionary).IsAssignableFrom(classField.FieldType) && typeof(ISavable).IsAssignableFrom(classField.FieldType.GetGenericArguments()[1]))
						{
							int num2 = 0;
							if (classField.GetValue(savable) is IDictionary dictionary)
							{
								foreach (ISavable value in dictionary.Values)
								{
									if (savable == null || !savable.IgnoreSave())
									{
										LoadObjectData(value, (obj as List<Dictionary<string, object>>)[num2], savableAttribute.saveTransform);
									}
								}
								num2++;
							}
						}
						else if (classField.FieldType.GetInterfaces().Contains(typeof(ISavable)))
						{
							LoadObjectData(classField.GetValue(savable), obj as Dictionary<string, object>, savableAttribute.saveTransform);
						}
						else
						{
							classField.SetValue(savable, obj);
						}
						hasLoadedSomething = true;
					}
					else
					{
						hasLoadedSomething = true;
					}
				}
			}
			savable.OnLoad(dataToLoad, hasLoadedSomething);
		}
	}

	private void CreateDefaultProfile()
	{
		string displayName = "Tower Factory";
		if (SteamManager.Initialized)
		{
			displayName = SteamFriends.GetPersonaName();
		}
		SelectProfile(CreateNewProfile(displayName).Id);
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (saveProfiles.Count > 0)
		{
			return;
		}
		if (hasLoadedSomething)
		{
			foreach (Dictionary<string, object> item in data["saveProfiles"] as List<Dictionary<string, object>>)
			{
				SaveProfile saveProfile = new SaveProfile("", "");
				LoadObjectData(saveProfile, item);
				saveProfiles.Add(saveProfile);
			}
			if (PlayerPrefs.HasKey("currentSaveProfile"))
			{
				if (!SelectProfile(PlayerPrefs.GetString("currentSaveProfile")))
				{
					SelectProfile(saveProfiles[0].Id);
				}
			}
			else if (saveProfiles == null || saveProfiles.Count < 1 || !SelectProfile(saveProfiles[0].Id))
			{
				CreateDefaultProfile();
			}
		}
		else
		{
			CreateDefaultProfile();
		}
	}

	public void OnSave()
	{
		if (CurrentProfile == null && saveProfiles != null && saveProfiles.Count > 0)
		{
			CurrentProfile = saveProfiles[0];
		}
	}
}
