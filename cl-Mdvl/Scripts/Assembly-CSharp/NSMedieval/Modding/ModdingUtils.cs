using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.UI.ScenarioEditor;
using Steamworks;
using UnityEngine;

namespace NSMedieval.Modding
{
	public abstract class ModdingUtils
	{
		public const string InfoFileName = "ModInfo.json";

		public const string PreviewFileName = "Preview.png";

		public const string PreviewModFileName = "PreviewMod.png";

		public const string PreviewScenarioFileName = "PreviewScenario.png";

		public const string PreviewTranslationFileName = "PreviewTranslation.png";

		public const string WorkshopIdFileName = "WorkshopId.json";

		public static readonly string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

		public const string ModsDir = "Foxy Voxel/Going Medieval/Mods";

		public const string DataDir = "Data";

		public const string ModelsDir = "Models";

		public const string TexturesDir = "Textures";

		public const string SpritesDir = "Sprites";

		public const string AddressablesDir = "AddressableAssets";

		public const string LocalizationDir = "Localization";

		public const string ScenariosDir = "Scenarios";

		private static readonly string[] DefaultTags = new string[2] { "Replace", "Us" };

		private const string ObsoleteScenariosPath = "UserData\\Scenarios";

		private const string DefaultTemplateModName = "My Default Mod Template";

		public static string LoadPath;

		public string ModRootPath => Path.Combine(MyDocumentsPath, "Foxy Voxel/Going Medieval/Mods");

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			LoadPath = string.Empty;
		}

		public static void SetLoadPath(string path)
		{
			LoadPath = path;
		}

		public static void UpdateScenario(string scenarioId, ScenarioSaveData scenarioSaveData)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Updating scenario ");
				messageBuilder.AppendFormatted(scenarioId);
			}
			Log.Debug(messageBuilder);
			if (!MonoSingleton<ModManager>.Instance.GetScenarioModInstance(scenarioId, out var scenarioModInstance))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Failed to update scenario ");
					messageBuilder2.AppendFormatted(scenarioId);
					messageBuilder2.AppendLiteral(", skipping.");
				}
				Log.Error(messageBuilder2);
			}
			else
			{
				string data = JsonUtility.ToJson(new ScenarioSaveRepo(scenarioSaveData), prettyPrint: true);
				FileUtils.SafeWriteAllText(scenarioModInstance.ScenarioFilePath, data);
				scenarioModInstance.UpdateData();
			}
		}

		public static void CreateNewScenario(ScenarioSaveData scenarioSaveData)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating new scenario ");
				messageBuilder.AppendFormatted(scenarioSaveData.ID);
			}
			Log.Debug(messageBuilder);
			string str = scenarioSaveData.ID.Replace("_", " ");
			str = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
			string path = scenarioSaveData.ID + ".json";
			string text = Path.Combine(Path.Combine(GetModDataDirectoryPath(str), "Scenarios"), path);
			string data = JsonUtility.ToJson(new ScenarioSaveRepo(scenarioSaveData), prettyPrint: true);
			CreateDefaultScenarioModDirectory(str);
			FilePathUtils.CheckAndCreatePath(text);
			FileUtils.SafeWriteAllText(text, data);
			MonoSingleton<ModManager>.Instance.RegisterNewInstance(Path.Combine(GetRootDirectoryPath(), str));
		}

		public static void CreateDefaultScenarioModDirectory(string modName)
		{
			FilePathUtils.CheckAndCreatePath(Path.Combine(GetModDataDirectoryPath(modName), "Scenarios"));
			CreateDefaultModInfo(modName, GetModModel(modName, new string[1] { ModTag.Scenario.ToString() }));
			CopyPreviewImage(modName, "PreviewScenario.png");
		}

		public static void CheckScenariosConversion()
		{
			string path = Path.Combine(FileReaders.Get.GetPersistentDataPath(), "UserData\\Scenarios");
			if (!Directory.Exists(path))
			{
				return;
			}
			string[] files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);
			bool isEnabled;
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				string str = fileName.Replace(".json", "").Replace("_", " ");
				str = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
				CreateDefaultScenarioModDirectory(str);
				string text2 = Path.Combine(Path.Combine(GetModDataDirectoryPath(str), "Scenarios"), fileName);
				if (File.Exists(text2))
				{
					File.Delete(text);
					continue;
				}
				File.Copy(text, text2);
				File.Delete(text);
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Converted ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(text));
					messageBuilder.AppendLiteral(" scenario to mod");
				}
				Log.Info(messageBuilder);
			}
			if (Directory.GetFiles(path).Length == 0)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(9, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Deleting ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Info(messageBuilder);
				Directory.Delete(path);
			}
		}

		public static void CreateDefaultLocalizationMod(string modName)
		{
			FilePathUtils.CheckAndCreatePath(Path.Combine(GetModDataDirectoryPath(modName), "Localization"));
			CreateDefaultModInfo(modName, GetModModel(modName, new string[1] { ModTag.Localization.ToString() }));
			CopyPreviewImage(modName, "PreviewTranslation.png");
		}

		public static string GetLocalizationModPath(string modName)
		{
			return Path.Combine(GetRootDirectoryPath(), modName, "Data", "Localization");
		}

		public static string GenerateAuthorName()
		{
			string result = "[author_name]";
			if (SteamSdkManager.IsSteamInitialised)
			{
				result = SteamFriends.GetPersonaName();
			}
			return result;
		}

		private static ModModel GetModModel(string modName, string[] tags)
		{
			string text = GenerateAuthorName();
			return new ModModel((text + "." + modName).ToLower().Replace(" ", "_"), modName, "Add some description here...", text, "0.1", Application.version, tags);
		}

		public static void CreateDefaultModInfo(string modName, ModModel modModel)
		{
			string path = Path.Combine(GetRootDirectoryPath(), modName, "ModInfo.json");
			if (!File.Exists(path))
			{
				string contents = JsonUtility.ToJson(modModel, prettyPrint: true);
				File.WriteAllText(path, contents);
			}
		}

		public static void CopyPreviewImage(string modName, string sourceImage = "PreviewMod.png")
		{
			string sourceFileName = Path.Combine(Application.streamingAssetsPath, "Modding", sourceImage);
			string text = Path.Combine(GetRootDirectoryPath(), modName, "Preview.png");
			if (!File.Exists(text))
			{
				File.Copy(sourceFileName, text);
			}
		}

		public static string GetRootDirectoryPath()
		{
			string text = Path.Combine(MyDocumentsPath, "Foxy Voxel/Going Medieval/Mods");
			if (Directory.Exists(text))
			{
				Log.Info("Directory exists: " + FilePathUtils.RemoveUserFromPath(text), "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
				return text;
			}
			try
			{
				Directory.CreateDirectory(text);
				Log.Info("Directory created: " + FilePathUtils.RemoveUserFromPath(text), "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
				return text;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
				return string.Empty;
			}
		}

		public static string GetModDataDirectoryPath(string modName)
		{
			return Path.Combine(Path.Combine(GetRootDirectoryPath(), modName), "Data");
		}

		public static string GetPreviewModImagePath(string rootFolderPath)
		{
			return Path.Combine(rootFolderPath, "Preview.png");
		}

		public static Sprite GetSpriteFromPath(string path)
		{
			Texture2D texture2D = new Texture2D(640, 360);
			if (!File.Exists(path))
			{
				return null;
			}
			byte[] data = FileUtils.SafeReadAllBytes(path);
			texture2D.LoadImage(data);
			return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
		}

		public static void CreateDefaultTemplate()
		{
			FilePathUtils.CheckAndCreatePath(Path.Combine(GetDefaultTemplateModPath(), "Models"));
			FilePathUtils.CheckAndCreatePath(Path.Combine(GetDefaultTemplateModPath(), "Textures"));
			FilePathUtils.CheckAndCreatePath(Path.Combine(GetDefaultTemplateModPath(), "Sprites"));
			CreateDefaultModInfo("My Default Mod Template", GetModModel("My Default Mod Template", new string[1] { ModTag.General.ToString() }));
			CopyPreviewImage("My Default Mod Template");
		}

		public static string GetDefaultTemplateModPath()
		{
			return Path.Combine(GetRootDirectoryPath(), "My Default Mod Template", "Data");
		}

		public static bool RootFolderAccessible()
		{
			bool flag = false;
			if (!string.IsNullOrEmpty(MyDocumentsPath))
			{
				flag = FilePathUtils.CanWriteToFolder(MyDocumentsPath);
			}
			if (!flag)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(67, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModdingUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Root Folder path is not accessible. MyDocumentsPath null or empty: ");
					messageBuilder.AppendFormatted(string.IsNullOrEmpty(MyDocumentsPath));
				}
				Log.Warning(messageBuilder);
				string text = MonoSingleton<LocalizationController>.Instance.GetText("local_folder_not_accessible_warning");
				List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
				{
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), delegate
					{
						Process.Start("ms-settings:windowsdefender");
					}),
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
					{
					})
				};
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(text, buttonActions));
			}
			return flag;
		}

		public static bool OnWorkshopShowPreview(ModInstance modInstance, ModManipulationLayout modManipulationLayout, Action modEditCallback = null)
		{
			modManipulationLayout.gameObject.SetActive(value: false);
			if (modInstance == null)
			{
				UnityEngine.Debug.LogError("Instance is null. This should never happen!");
				return false;
			}
			modManipulationLayout.gameObject.SetActive(value: true);
			modManipulationLayout.SetData(modInstance, modEditCallback);
			return true;
		}

		public static void OpenFolderInExplorer(string folderPath)
		{
			if (Directory.Exists(folderPath))
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = folderPath,
					UseShellExecute = true,
					Verb = "open"
				});
			}
			else
			{
				UnityEngine.Debug.LogError("Folder path does not exist: " + FilePathUtils.RemoveUserFromPath(folderPath));
			}
		}
	}
}
