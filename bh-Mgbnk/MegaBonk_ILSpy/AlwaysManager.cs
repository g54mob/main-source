using System;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Tools;
using Assets.Scripts.Utility;
using Inventory__Items__Pickups;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

public class AlwaysManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<JsonSerializerSettings> _003C_003E9__8_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal JsonSerializerSettings _003CAwake_003Eb__8_0()
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
			if (jsonSerializerSettings != null)
			{
				StringEnumConverter item = new StringEnumConverter();
				if (jsonSerializerSettings._003CConverters_003Ek__BackingField != null)
				{
					jsonSerializerSettings._003CConverters_003Ek__BackingField.Add(item);
					return jsonSerializerSettings;
				}
			}
			return (JsonSerializerSettings)(object)new NullReferenceException();
		}
	}

	public SaveManager saveManager;

	public DataManager dataManager;

	public SteamManager steamManager;

	public GameObject rewiredManager;

	public GameObject eventSystem;

	public AlwaysUi alwaysUi;

	public static AlwaysManager Instance;

	public Material playerMaterialPreset;

	private int index = 73;

	private Enemy testEnemy;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			GameObject target = base.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
			string version = Application.version;
			string unityVersion = Application.unityVersion;
			string message = "Playing on version " + version + "\n Unity Version " + unityVersion;
			Debug.Log(message);
			Func<JsonSerializerSettings> func = _003C_003Ec._003C_003E9__8_0;
			if (_003C_003Ec._003C_003E9__8_0 == null)
			{
				func = (_003C_003Ec._003C_003E9__8_0 = delegate
				{
					JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
					if (jsonSerializerSettings != null)
					{
						StringEnumConverter item = new StringEnumConverter();
						if (jsonSerializerSettings._003CConverters_003Ek__BackingField != null)
						{
							jsonSerializerSettings._003CConverters_003Ek__BackingField.Add(item);
							return jsonSerializerSettings;
						}
					}
					return (JsonSerializerSettings)(object)new NullReferenceException();
				});
			}
			JsonConvert._003CDefaultSettings_003Ek__BackingField = func;
			saveManager.Init();
			dataManager.Load();
			steamManager.Load();
			rewiredManager.SetActive(value: true);
			GameObject gameObject = eventSystem.gameObject;
			gameObject.SetActive(value: true);
			EnemyTargeting.Init();
			XpUtility.Init();
			Progression.Init();
			MyTime.Init();
			MoneyUtility.Init();
			FxUtility.Init();
			Potato.Init();
			DebuffFactory.Init();
			InteractablesStatus.Init();
			SaveManager._003CInstance_003Ek__BackingField.Load(loadBackup: false);
		}
		else
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
	}

	private void Start()
	{
		WindowManager.RefreshCursor();
	}

	private void Update()
	{
		if (Instance == this)
		{
			Potato.Update();
			WindowManager.Update();
			MyTime.Update();
			MyAchievements.Update();
		}
	}

	private void FixedUpdate()
	{
		MyTime.FixedUpdate();
		ChallengesTracker.Tick();
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			MyTime.Cleanup();
			Progression.Cleanup();
			MoneyUtility.Cleanup();
			FxUtility.Cleanup();
			Potato.Cleanup();
			EnemyTargeting.Cleanup();
			DebuffFactory.Cleanup();
			InteractablesStatus.Cleanup();
		}
	}
}
