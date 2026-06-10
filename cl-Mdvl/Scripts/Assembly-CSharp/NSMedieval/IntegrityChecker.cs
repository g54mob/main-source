using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Dictionary;
using NSMedieval.Modding;
using NSMedieval.Tools;
using NSMedieval.Utils;
using UnityEngine;
using UnityEngine.CrashReportHandler;

namespace NSMedieval
{
	[DisallowMultipleComponent]
	public class IntegrityChecker : MonoBehaviour
	{
		private const string StreamingAssetsChecksumsFileName = "Checksums";

		private const string BuildDataChecksumsFileName = "BuildDataChecksums";

		[NonSerialized]
		private static IntegrityChecker instance;

		private static SerializableDictionary<string, string> streamingAssetsActualChecksums;

		private static SerializableDictionary<string, string> streamingAssetsBakedChecksums;

		private static bool streamingAssetsGenuine = true;

		private static bool streamingAssetsIntegrityChecked = false;

		private static SerializableDictionary<string, string> buildDataActualChecksums;

		private static SerializableDictionary<string, string> buildDataBakedChecksums;

		private static bool buildDataGenuine = true;

		private static bool buildDataIntegrityChecked = false;

		private static bool unityGenuine;

		private static bool hasTrainer;

		private static readonly HashSet<string> IgnoreFilesSet = new HashSet<string>
		{
			"/HeraldryCustomSymbols/logo_foxy.png", "/FactionHeraldry/ancrene_disciples_bg.png", "/FactionHeraldry/ancrene_disciples_crest.png", "/FactionHeraldry/band_of_the she_wolf_bg.png", "/FactionHeraldry/band_of_the she_wolf_crest.png", "/FactionHeraldry/beirdd_cymraeg_bg.png", "/FactionHeraldry/beirdd_cymraeg_crest.png", "/FactionHeraldry/church_of_third_coming_bg.png", "/FactionHeraldry/church_of_third_coming_crest.png", "/FactionHeraldry/circle_of_avalon_bg.png",
			"/FactionHeraldry/circle_of_avalon_crest.png", "/FactionHeraldry/faithful_sons_of_england_bg.png", "/FactionHeraldry/faithful_sons_of_england_crest.png", "/FactionHeraldry/forest_bandits_bg.png", "/FactionHeraldry/forest_bandits_crest.png", "/FactionHeraldry/heresy_of_the_rose_bg.png", "/FactionHeraldry/heresy_of_the_rose_crest.png", "/FactionHeraldry/kingdom_of_york_bg.png", "/FactionHeraldry/kingdom_of_york_crest.png", "/FactionHeraldry/looters_bg.png",
			"/FactionHeraldry/looters_crest.png", "/FactionHeraldry/mountain_bandits_bg.png", "/FactionHeraldry/mountain_bandits_crest.png", "/FactionHeraldry/non_partisan_nomads_bg.png", "/FactionHeraldry/non_partisan_nomads_crest.png", "/FactionHeraldry/philosophers_of_the_natural_order_bg.png", "/FactionHeraldry/philosophers_of_the_natural_order_crest.png", "/FactionHeraldry/progeny_of_the_plague_bg.png", "/FactionHeraldry/progeny_of_the_plague_crest.png", "/FactionHeraldry/ravagers_bg.png",
			"/FactionHeraldry/ravagers_crest.png", "/FactionHeraldry/river_bandits_bg.png", "/FactionHeraldry/river_bandits_crest.png", "/FactionHeraldry/society_of_fellows_bg.png", "/FactionHeraldry/society_of_fellows_crest.png", "/StatsSystem/Attributes Enum.txt", "/Language Enum.txt", "/Worker/Skill Enum.txt", "/Resources/Resource Categories.txt", "/Master Bank.bank"
		};

		private static string StreamingAssetsChecksumsFilePath => "Assets/Resources/Checksums.json";

		public static bool StreamingAssetsGenuine => streamingAssetsGenuine;

		public static bool BuildDataGenuine => buildDataGenuine;

		public static bool UnityGenuine => unityGenuine;

		public static bool HasMods
		{
			get
			{
				if (!CheckHasEnabledMods() && !CheckHasModFolder() && !HasTrainer())
				{
					return HasBepInEx();
				}
				return true;
			}
		}

		public static bool StreamingAssetsIntegrityChecked => streamingAssetsIntegrityChecked;

		public static bool IsGameModified
		{
			get
			{
				if (UnityGenuine && StreamingAssetsGenuine && BuildDataGenuine)
				{
					return HasMods;
				}
				return true;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			instance = null;
			unityGenuine = false;
			hasTrainer = false;
			streamingAssetsActualChecksums = null;
			streamingAssetsBakedChecksums = null;
			streamingAssetsGenuine = true;
			streamingAssetsIntegrityChecked = false;
			buildDataActualChecksums = null;
			buildDataBakedChecksums = null;
			buildDataGenuine = true;
			buildDataIntegrityChecked = false;
		}

		private static void CalculateChecksums(string folderPath, Dictionary<string, string> outputCheckSums, params string[] ignoreFolderNames)
		{
			outputCheckSums.Clear();
			string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
			foreach (string text in files)
			{
				bool flag = false;
				foreach (string value in ignoreFolderNames)
				{
					if (text.Contains(value))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				string text2 = text.ToLower();
				if (!text2.EndsWith(".meta") && !text2.EndsWith(".bank"))
				{
					string text3 = text.Replace(folderPath, string.Empty).Replace("\\", "/");
					if (!ShouldIgnore(text3))
					{
						string hash = GetHash(text);
						outputCheckSums.Add(text3, hash);
					}
				}
			}
		}

		private static bool TryLoadBakedChecksums(string filePath, Dictionary<string, string> outputChecksums)
		{
			outputChecksums.Clear();
			bool isEnabled;
			bool isEnabled2;
			try
			{
				StringStringDictionary stringStringDictionary = JsonUtility.FromJson<StringStringDictionary>(File.ReadAllText(filePath));
				if (stringStringDictionary.Dictionary.Count == 0)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Could not read checksums from ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(filePath));
						messageBuilder.AppendLiteral(".");
					}
					Log.Error(messageBuilder);
					isEnabled = false;
					return isEnabled;
				}
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(20, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
				if (isEnabled2)
				{
					messageBuilder2.AppendLiteral("Successfully loaded ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(filePath));
				}
				Log.Info(messageBuilder2);
				foreach (KeyValuePair<string, string> item in stringStringDictionary.Dictionary)
				{
					outputChecksums.Add(item.Key, item.Value);
				}
			}
			catch (Exception t)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
				if (isEnabled2)
				{
					messageBuilder.AppendLiteral("Could not read checksums from ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(filePath));
					messageBuilder.AppendLiteral(". Exception happened: ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Error(messageBuilder);
				isEnabled = false;
				return isEnabled;
			}
			return true;
		}

		private static bool TryLoadBakedChecksumsFromResources(string checksumsFileName, Dictionary<string, string> outputChecksums, out bool shouldRecalculate)
		{
			shouldRecalculate = false;
			outputChecksums.Clear();
			TextAsset textAsset = UnityEngine.Resources.Load<TextAsset>(checksumsFileName);
			shouldRecalculate = textAsset == null;
			if (textAsset != null)
			{
				bool isEnabled;
				try
				{
					StringStringDictionary stringStringDictionary = JsonUtility.FromJson<StringStringDictionary>(textAsset.text);
					if (stringStringDictionary.Dictionary.Count == 0)
					{
						shouldRecalculate = true;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Could not read checksums from ");
							messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(checksumsFileName));
							messageBuilder.AppendLiteral(".");
						}
						Log.Error(messageBuilder);
					}
					else
					{
						FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Successfully loaded ");
							messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(checksumsFileName));
							messageBuilder2.AppendLiteral(" from Resources.");
						}
						Log.Info(messageBuilder2);
						foreach (KeyValuePair<string, string> item in stringStringDictionary.Dictionary)
						{
							outputChecksums.Add(item.Key, item.Value);
						}
					}
				}
				catch (Exception t)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Could not read checksums from ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(checksumsFileName));
						messageBuilder.AppendLiteral(". Exception happened: ");
						messageBuilder.AppendFormatted(t);
					}
					Log.Error(messageBuilder);
					shouldRecalculate = true;
				}
			}
			return textAsset != null;
		}

		private static bool ShouldIgnore(string fileName)
		{
			if (IgnoreFilesSet.Contains(fileName))
			{
				return true;
			}
			return fileName.StartsWith("/Modding/");
		}

		private static bool CheckAssetsIntegrity(Dictionary<string, string> bakedChecksums, Dictionary<string, string> actualChecksums)
		{
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(80, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Starting CheckAssetsIntegrity, actual checksums count: ");
				messageBuilder.AppendFormatted(actualChecksums.Count);
				messageBuilder.AppendLiteral(", baked checksums count: ");
				messageBuilder.AppendFormatted(bakedChecksums.Count);
			}
			Log.Info(messageBuilder);
			bool flag = true;
			FVLogDebugInterpolationHandler messageBuilder2;
			foreach (string key in bakedChecksums.Keys)
			{
				if (ShouldIgnore(key))
				{
					messageBuilder2 = new FVLogDebugInterpolationHandler(14, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Ignoring file ");
						messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(key));
					}
					Log.Debug(messageBuilder2);
					continue;
				}
				string text = bakedChecksums[key];
				if (!actualChecksums.TryGetValue(key, out var value))
				{
					messageBuilder2 = new FVLogDebugInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("File ");
						messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(key));
						messageBuilder2.AppendLiteral(" was deleted.");
					}
					Log.Debug(messageBuilder2);
					continue;
				}
				if (value.Equals("error"))
				{
					messageBuilder = new FVLogInfoInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Skipping ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(key));
						messageBuilder.AppendLiteral("; was not able to access it.");
					}
					Log.Info(messageBuilder);
					continue;
				}
				string text2 = actualChecksums[key];
				if (!text2.Equals(text))
				{
					flag = false;
					messageBuilder = new FVLogInfoInterpolationHandler(58, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("File ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(key));
						messageBuilder.AppendLiteral(" was changed. Baked checksum: '");
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral("', actual checksum: '");
						messageBuilder.AppendFormatted(text2);
						messageBuilder.AppendLiteral("'");
					}
					Log.Info(messageBuilder);
				}
			}
			messageBuilder2 = new FVLogDebugInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("AssetsGenuine: ");
				messageBuilder2.AppendFormatted(flag);
			}
			Log.Debug(messageBuilder2);
			return flag;
		}

		private static string GetHash(string fileName)
		{
			string hashStr = string.Empty;
			FileUtils.SafeFileOperation(ReadHash);
			return hashStr;
			void ReadHash()
			{
				try
				{
					using FileStream inputStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan);
					byte[] bytes = new SHA256Managed().ComputeHash(inputStream);
					hashStr = ProperBitConverter.BytesToHexString(bytes);
				}
				catch (UnauthorizedAccessException ex)
				{
					Log.Error("Cannot read hash for " + FilePathUtils.RemoveUserFromPath(fileName) + ". Error: " + ex.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
					hashStr = "error";
				}
				catch (DirectoryNotFoundException ex2)
				{
					Log.Error("Filename possibly too long: " + FilePathUtils.RemoveUserFromPath(fileName) + ". Error: " + ex2.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
					hashStr = "error";
				}
			}
		}

		private static bool CheckHasEnabledMods()
		{
			Dictionary<string, ModInstance> enabledMods = MonoSingleton<ModManager>.Instance.EnabledMods;
			if (enabledMods == null)
			{
				return false;
			}
			return enabledMods.Count > 0;
		}

		private static bool CheckHasModFolder()
		{
			string path = Path.Combine(Application.dataPath, "../mods/").Replace("\\", "/");
			if (Directory.Exists(path) && Directory.GetFiles(path).Length != 0)
			{
				return true;
			}
			return false;
		}

		private static bool HasTrainer()
		{
			hasTrainer = Type.GetType("Trainer.MainMenu.TrainerMenu") != null;
			return hasTrainer;
		}

		private static bool HasBepInEx()
		{
			string path = Path.Combine(Application.dataPath, "../BepInEx/").Replace("\\", "/");
			if (Directory.Exists(path) && (Directory.GetFiles(path).Length != 0 || Directory.GetDirectories(path).Length != 0))
			{
				return true;
			}
			return false;
		}

		private void Awake()
		{
			if (instance != null)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
				return;
			}
			instance = this;
			UnityEngine.Object.DontDestroyOnLoad(instance.gameObject);
			unityGenuine = Application.genuine;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(22, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Application.genuine = ");
				messageBuilder.AppendFormatted(unityGenuine);
			}
			Log.Info(messageBuilder);
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			streamingAssetsIntegrityChecked = false;
			if (streamingAssetsActualChecksums == null)
			{
				streamingAssetsActualChecksums = new SerializableDictionary<string, string>();
			}
			if (streamingAssetsBakedChecksums == null)
			{
				streamingAssetsBakedChecksums = new SerializableDictionary<string, string>();
			}
			buildDataIntegrityChecked = false;
			if (buildDataBakedChecksums == null)
			{
				buildDataBakedChecksums = new SerializableDictionary<string, string>();
			}
			if (buildDataActualChecksums == null)
			{
				buildDataActualChecksums = new SerializableDictionary<string, string>();
			}
			try
			{
				streamingAssetsIntegrityChecked = TryLoadBakedChecksumsFromResources("Checksums", streamingAssetsBakedChecksums.Dictionary, out var _);
				CalculateChecksums(Application.streamingAssetsPath, streamingAssetsActualChecksums.Dictionary);
				streamingAssetsGenuine = CheckAssetsIntegrity(streamingAssetsBakedChecksums.Dictionary, streamingAssetsActualChecksums.Dictionary);
				string text = Path.Combine(Application.streamingAssetsPath, "BuildDataChecksums.json");
				string text2 = Directory.GetParent(Application.streamingAssetsPath)?.FullName;
				if (File.Exists(text) && text2 != null)
				{
					buildDataIntegrityChecked = TryLoadBakedChecksums(text, buildDataBakedChecksums.Dictionary);
					CalculateChecksums(text2, buildDataActualChecksums.Dictionary, Application.streamingAssetsPath);
					buildDataGenuine = CheckAssetsIntegrity(buildDataBakedChecksums.Dictionary, buildDataActualChecksums.Dictionary);
				}
			}
			catch (Exception ex)
			{
				streamingAssetsIntegrityChecked = false;
				buildDataIntegrityChecked = false;
				Log.Debug("Integrity check failed: " + ex.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
				stopwatch.Stop();
				throw;
			}
			CrashReportHandler.SetUserMetadata("gm_app_genuine", unityGenuine.ToString());
			isEnabled = HasMods;
			CrashReportHandler.SetUserMetadata("gm_has_mods", isEnabled.ToString());
			CrashReportHandler.SetUserMetadata("gm_streaming_assets_genuine", streamingAssetsGenuine.ToString());
			messageBuilder = new FVLogInfoInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("HasMods = ");
				messageBuilder.AppendFormatted(HasMods);
			}
			Log.Info(messageBuilder);
			messageBuilder = new FVLogInfoInterpolationHandler(75, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("StreamingAssetsIntegrityChecked = ");
				messageBuilder.AppendFormatted(StreamingAssetsIntegrityChecked);
				messageBuilder.AppendLiteral(", Going Medieval_Data integrity checked: ");
				messageBuilder.AppendFormatted(buildDataIntegrityChecked);
			}
			Log.Info(messageBuilder);
			stopwatch.Stop();
			FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("*** Integrity check completed in ");
				messageBuilder2.AppendFormatted(stopwatch.Elapsed.TotalMilliseconds);
				messageBuilder2.AppendLiteral(" ms.");
			}
			Log.Debug(messageBuilder2);
			messageBuilder = new FVLogInfoInterpolationHandler(56, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\IntegrityChecker.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("StreamingAssets genuine: ");
				messageBuilder.AppendFormatted(streamingAssetsGenuine);
				messageBuilder.AppendLiteral(", Going Medieval_Data genuine: ");
				messageBuilder.AppendFormatted(buildDataGenuine);
			}
			Log.Info(messageBuilder);
		}

		public static string GetModsList()
		{
			if (!HasMods)
			{
				return "None";
			}
			List<string> list = new List<string>();
			foreach (string key in MonoSingleton<ModManager>.Instance.EnabledMods.Keys)
			{
				list.Add(key);
			}
			string path = Path.Combine(Application.dataPath, "../mods/").Replace("\\", "/");
			if (Directory.Exists(path))
			{
				list.AddRange(Directory.GetFiles(path, "*.dll").ToList());
				for (int i = 0; i < list.Count; i++)
				{
					list[i] = Path.GetFileName(list[i]);
				}
			}
			if (HasBepInEx())
			{
				list.Add("BepInEx");
			}
			if (hasTrainer)
			{
				list.Add("Trainer");
			}
			if (list.Count > 0)
			{
				return string.Join(", ", list);
			}
			return "None";
		}
	}
}
