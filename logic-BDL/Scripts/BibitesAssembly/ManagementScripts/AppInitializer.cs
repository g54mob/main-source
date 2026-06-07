using System;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json.Linq;
using OneUseScripts;
using SettingScripts;
using UnityEngine;
using Utility;

namespace ManagementScripts
{
	public class AppInitializer : MonoBehaviour
	{
		private static readonly int RadiusExpandFactor = Shader.PropertyToID("_radiusExpandFactor");

		public static DateTime openTime;

		public static DateTime lastOfficialScenariosImportTime;

		public static bool display060Warning = false;

		public static bool firstTimeEver = false;

		private void Awake()
		{
			openTime = DateTime.Now;
			ProcessArguments();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			if (!Directory.Exists(SaveController.SavePath))
			{
				Directory.CreateDirectory(SaveController.SavePath);
			}
			if (!Directory.Exists(SaveController.AutoSavePath))
			{
				Directory.CreateDirectory(SaveController.AutoSavePath);
			}
			string savedBibitePath = SaveSystem.savedBibitePath;
			string bibiteTemplatePath = SaveSystem.bibiteTemplatePath;
			if (!Directory.Exists(savedBibitePath))
			{
				Directory.CreateDirectory(savedBibitePath);
			}
			if (!Directory.Exists(bibiteTemplatePath))
			{
				Directory.CreateDirectory(bibiteTemplatePath);
			}
			TextAsset[] array = Resources.LoadAll<TextAsset>("BibiteTemplates/");
			GameManager.defaultBibites.Clear();
			TextAsset[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				JObject jObject = JObject.Parse(array2[i].text);
				string text = jObject["name"].ToString();
				using StreamWriter streamWriter = File.CreateText(Path.Combine(bibiteTemplatePath, text + ".bb8template"));
				streamWriter.Write(jObject.ToString());
				GameManager.defaultBibites.Add(text.ToLower());
			}
			ReImportOfficialScenarios();
			PatronsImporter.LoadPatronsInfo();
			if (UserSettings.FirstTimeBeingOpened.val)
			{
				firstTimeEver = true;
				UserSettings.FirstTimeBeingOpened.SetValue(_value: false);
			}
			if (UserSettings.versionOnLastOpen < Utility.Version.Parse("0.6a5"))
			{
				UserSettings.SpeciesSpanPreference.ResetValue();
			}
			if (UserSettings.versionOnLastOpen < Utility.Version.Parse("0.6a9"))
			{
				UserSettings.ReloadAfterAutosaves.SetValue(_value: false);
			}
			if (UserSettings.versionOnLastOpen < Utility.Version.Parse("0.6.0.1") && UserSettings.versionOnLastOpen > Utility.Version.Parse("0.4"))
			{
				display060Warning = true;
			}
			if (UserSettings.versionOnLastOpen < Utility.Version.Parse("0.6.1a4"))
			{
				ChallengesProgress.ResetHighscore("Down With The Basics");
				string text2 = Path.Combine(Application.persistentDataPath, "Scenarios/");
				if (Directory.Exists(text2))
				{
					File.Delete(Path.Combine(text2, "Default Challenge.zip"));
				}
			}
			UserSettings.versionOnLastOpen = Utility.Version.Present;
		}

		public static void ReImportOfficialScenarios()
		{
			lastOfficialScenariosImportTime = DateTime.Now;
			string text = Path.Combine(Application.persistentDataPath, "Scenarios/");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			TextAsset[] array = Resources.LoadAll<TextAsset>("Scenarios/");
			int num = 0;
			GameManager.defaultScenarios.Clear();
			GameManager.defaultChallenges.Clear();
			GameManager.defaultScenarioKeys.Clear();
			GameManager.defaultChallengesKeys.Clear();
			TextAsset[] array2 = array;
			foreach (TextAsset textAsset in array2)
			{
				string path = textAsset.name + ".zip";
				num++;
				string text2 = Path.Combine(text, path);
				File.WriteAllBytes(text2, textAsset.bytes);
				GameManager.defaultScenarios.Add(textAsset.name.ToLower());
				GameManager.defaultScenarioKeys.Add(ChallengesProgress.NameToKey(textAsset.name));
				using ZipArchive zipArchive = ZipFile.Open(text2, ZipArchiveMode.Read);
				JObject jObject = SaveSystem.ReadJObjectFromArchive(zipArchive.GetEntry("scenario.info"));
				bool flag = false;
				if (jObject["isChallenge"] != null)
				{
					flag = jObject["isChallenge"].ToObject<bool>();
				}
				if (flag)
				{
					GameManager.defaultChallenges.Add(textAsset.name.ToLower());
					GameManager.defaultChallengesKeys.Add(ChallengesProgress.NameToKey(textAsset.name));
				}
			}
		}

		public void ProcessArguments()
		{
			bool enable = false;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs.Length == 0)
			{
				Debug.Log("No arguments provided");
			}
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				Debug.Log("ARG " + i + ": " + commandLineArgs[i]);
				if (commandLineArgs[i] == "-steam")
				{
					enable = true;
				}
			}
			GetComponent<SteamManager>().enable = enable;
		}

		private void Start()
		{
			GameManager.OpenMenu();
			Shader.SetGlobalFloat(RadiusExpandFactor, 1f);
		}
	}
}
