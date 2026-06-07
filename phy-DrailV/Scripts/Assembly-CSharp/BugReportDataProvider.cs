using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cysharp.Threading.Tasks;
using DV.CabControls;
using DV.CashRegister;
using DV.InventorySystem;
using DV.OriginShift;
using DV.Telemetry;
using DV.UI;
using DV.UserManagement;
using DV.Utils;
using DV.WeatherSystem;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

public class BugReportDataProvider : ABugReportDataProvider
{
	private const string GFX_BENCHMARK_PREFIX = "BENCHMARK_TRAINRUN_[Y]_[HB]_[G-01-S]_";

	private const string PHYSICS_BENCHMARK_PREFIX = "BENCHMARK_PHYSICS_";

	private const int SAVE_GAME_MAX_COUNT = 50;

	private const int SCREENSHOT_MAX_WIDTH = 1920;

	private const int SCREENSHOT_MAX_HEIGHT = 1080;

	public override bool IsReportingSupported()
	{
		return SingletonBehaviour<APlatformProvider>.Instance.SupportsBugReporting;
	}

	private static string FindLatest(string path, string startsWith = "", string endsWith = "")
	{
		if (!Directory.Exists(path))
		{
			return null;
		}
		string[] files = Directory.GetFiles(path);
		List<(string, DateTime)> list = new List<(string, DateTime)>();
		bool flag = !string.IsNullOrEmpty(startsWith);
		bool flag2 = !string.IsNullOrEmpty(endsWith);
		string[] array = files;
		foreach (string text in array)
		{
			string fileName = Path.GetFileName(text);
			if ((!flag || fileName.StartsWith(startsWith)) && (!flag2 || fileName.EndsWith(endsWith)))
			{
				list.Add((text, File.GetCreationTime(text)));
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		int index = 0;
		for (int j = 1; j < list.Count; j++)
		{
			if (list[j].Item2 > list[index].Item2)
			{
				index = j;
			}
		}
		return list[index].Item1;
	}

	private string GetGameInfo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Real-world timestamp: " + DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"));
		stringBuilder.AppendLine("In-game timestamp: " + SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"));
		stringBuilder.AppendLine("Weather seed: " + SingletonBehaviour<WeatherDriver>.Instance.weatherSeed);
		stringBuilder.AppendLine("Resolution: " + Screen.width + " x " + Screen.height + " @ " + Screen.currentResolution.refreshRate + " Hz");
		stringBuilder.AppendLine("VR mode: " + (VRManager.IsVREnabled() ? VRManager.GetCurrentSDK().ToString() : "non-VR"));
		stringBuilder.AppendLine("Player position: " + PlayerManager.PlayerTransform.AbsolutePosition());
		stringBuilder.AppendLine("Player rotation: " + PlayerManager.PlayerTransform.rotation.eulerAngles);
		stringBuilder.AppendLine("Player car: " + ((PlayerManager.Car == null) ? string.Empty : PlayerManager.Car.CarGUID));
		float num = (float)SingletonBehaviour<Inventory>.Instance.PlayerMoney;
		foreach (CashRegisterBase allCashRegister in CashRegisterBase.allCashRegisters)
		{
			num += (float)allCashRegister.DepositedCash;
		}
		stringBuilder.AppendLine("Player money: " + num);
		stringBuilder.AppendLine("Inventory storage: " + string.Join("; ", from x in SingletonBehaviour<StorageController>.Instance.StorageInventory.GetStorageItemList()
			select StorageSerializer.GetStorageItemSpecData(x).itemPrefabName));
		stringBuilder.AppendLine("World storage: " + string.Join("; ", from x in SingletonBehaviour<StorageController>.Instance.StorageWorld.GetStorageItemList()
			select StorageSerializer.GetStorageItemSpecData(x).itemPrefabName));
		stringBuilder.AppendLine("L&F storage: " + string.Join("; ", from x in SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.GetStorageItemList()
			select StorageSerializer.GetStorageItemSpecData(x).itemPrefabName));
		stringBuilder.AppendLine("Item containers storage: " + string.Join("; ", from x in SingletonBehaviour<StorageController>.Instance.StorageItemContainers.GetStorageItemList()
			select StorageSerializer.GetStorageItemSpecData(x).itemPrefabName));
		stringBuilder.AppendLine("Installed gadgets storage: " + string.Join("; ", from x in SingletonBehaviour<StorageController>.Instance.StorageInstalledGadgets.GetStorageItemList()
			select StorageSerializer.GetStorageItemSpecData(x).itemPrefabName));
		return stringBuilder.ToString();
	}

	public override async UniTask PackAdditionalBasics(List<PackingPath> fileList)
	{
		string reportPath = Path.Combine(Application.persistentDataPath, "REPORT");
		if ((bool)SingletonBehaviour<PerformanceTelemetry>.Instance)
		{
			string perfPath = Path.Combine(reportPath, "Performance.csv");
			SingletonBehaviour<PerformanceTelemetry>.Instance.SaveCSV(perfPath);
			while (SingletonBehaviour<PerformanceTelemetry>.Instance.IsStillWriting)
			{
				await UniTask.Yield();
			}
			fileList.Add(new PackingPath(perfPath));
		}
		string systemInfoPath = Path.Combine(reportPath, "SystemInfo.txt");
		string cmdLinePath = Path.Combine(reportPath, "CommandLine.txt");
		string snapshotPath = Path.Combine(reportPath, "Snapshot.dat");
		string gamePath = Path.Combine(reportPath, "Game.txt");
		string prefsPath = Path.Combine(reportPath, "Preferences.ini");
		await UniTask.SwitchToThreadPool();
		File.WriteAllLines(systemInfoPath, Bootstrap.StartupInfo);
		File.WriteAllLines(cmdLinePath, Bootstrap.commandLineArgs);
		await UniTask.SwitchToMainThread();
		if (SceneSwitcher.IsInGameWorld)
		{
			SingletonBehaviour<SaveGameManager>.Instance.SaveCurrentDataEncrypted(snapshotPath);
			string perfPath = GetGameInfo();
			await UniTask.SwitchToThreadPool();
			File.WriteAllText(gamePath, perfPath);
			await UniTask.SwitchToMainThread();
		}
		GamePreferences.SavePreferences();
		string prefData = SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.RawData;
		await UniTask.SwitchToThreadPool();
		File.WriteAllText(prefsPath, prefData);
		await UniTask.SwitchToMainThread();
		fileList.Add(new PackingPath(systemInfoPath));
		fileList.Add(new PackingPath(cmdLinePath));
		if (SceneSwitcher.IsInGameWorld)
		{
			fileList.Add(new PackingPath(snapshotPath));
		}
		if (SceneSwitcher.IsInGameWorld)
		{
			fileList.Add(new PackingPath(gamePath));
		}
		fileList.Add(new PackingPath(prefsPath));
	}

	public override void CleanupAdditionalBasics()
	{
		string path = Path.Combine(Application.persistentDataPath, "REPORT");
		File.Delete(Path.Combine(path, "Performance.csv"));
		File.Delete(Path.Combine(path, "SystemInfo.txt"));
		File.Delete(Path.Combine(path, "CommandLine.txt"));
		File.Delete(Path.Combine(path, "Snapshot.dat"));
		File.Delete(Path.Combine(path, "Game.txt"));
		File.Delete(Path.Combine(path, "Preferences.ini"));
	}

	public override bool CheckSaveGames()
	{
		if (SingletonBehaviour<UserManager>.Instance.CurrentUser != null && SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession != null)
		{
			return SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.Saves.Count > 0;
		}
		return false;
	}

	public override async UniTask PackSaveGames(List<PackingPath> fileList)
	{
		int num = Mathf.Min(50, SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.Saves.Count);
		List<string> list = new List<string>();
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			list.Clear();
			SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.Saves[i].GetFiles(list);
			foreach (string item in list)
			{
				fileList.Add(new PackingPath(SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(item)));
			}
			if (!flag && list.Count > 0)
			{
				string directoryName = Path.GetDirectoryName(SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(list[0]));
				string[] files = Directory.GetFiles(directoryName, "*.bak");
				foreach (string path in files)
				{
					fileList.Add(new PackingPath(path));
				}
				files = Directory.GetFiles(directoryName, "*.log");
				foreach (string path2 in files)
				{
					fileList.Add(new PackingPath(path2));
				}
				flag = true;
			}
		}
		string filesystemPath = SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(SingletonBehaviour<UserManager>.Instance.CurrentUser.GameDataPath);
		if (Directory.Exists(filesystemPath))
		{
			string[] files = Directory.GetFiles(filesystemPath, "*.*", SearchOption.AllDirectories);
			foreach (string path3 in files)
			{
				string directoryName2 = Path.GetDirectoryName(path3);
				if (directoryName2.Length > filesystemPath.Length)
				{
					string text = directoryName2.Substring(filesystemPath.Length);
					if (text[0] == Path.DirectorySeparatorChar)
					{
						text = text.Substring(1);
					}
					fileList.Add(new PackingPath(path3, text));
				}
				else
				{
					fileList.Add(new PackingPath(path3));
				}
			}
		}
		string text2 = Path.Combine(SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.BasePath), "sessionData.json");
		string text3 = Path.Combine(SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(SingletonBehaviour<UserManager>.Instance.CurrentUser.UserBasePath), "userData.json");
		if (File.Exists(text2))
		{
			fileList.Add(new PackingPath(text2, "Meta"));
		}
		else
		{
			Debug.LogError("[PACKING] File not found: " + text2);
		}
		if (File.Exists(text3))
		{
			fileList.Add(new PackingPath(text3, "Meta"));
		}
		else
		{
			Debug.LogError("[PACKING] File not found: " + text3);
		}
	}

	public override void CleanupSaveGames()
	{
	}

	public override bool CheckScreenshot()
	{
		return SingletonBehaviour<SaveGameManager>.Instance.HasStashedScreenshot;
	}

	public override Texture GetScreenshotForPreview()
	{
		if (SingletonBehaviour<SaveGameManager>.Instance.HasStashedScreenshot)
		{
			return SingletonBehaviour<SaveGameManager>.Instance.GetFullStashedScreenshot();
		}
		return null;
	}

	public override (Texture texture, bool isTemporary) GetScreenshotForPacking()
	{
		if (SingletonBehaviour<SaveGameManager>.Instance.HasStashedScreenshot)
		{
			RenderTexture fullStashedScreenshot = SingletonBehaviour<SaveGameManager>.Instance.GetFullStashedScreenshot();
			if (fullStashedScreenshot.width <= 1920 && fullStashedScreenshot.height <= 1080)
			{
				return (texture: fullStashedScreenshot, isTemporary: false);
			}
			float a = (float)fullStashedScreenshot.width / 1920f;
			float b = (float)fullStashedScreenshot.height / 1080f;
			float num = Mathf.Max(a, b);
			int num2 = Mathf.Min(1920, Mathf.RoundToInt((float)fullStashedScreenshot.width / num));
			int num3 = Mathf.Min(1080, Mathf.RoundToInt((float)fullStashedScreenshot.height / num));
			RenderTexture temporary = RenderTexture.GetTemporary(num2, num3, 0);
			Graphics.Blit(fullStashedScreenshot, temporary);
			Debug.Log($"NOTE: Downscaled screenshot from {fullStashedScreenshot.width} x {fullStashedScreenshot.height} to {num2} x {num3}");
			return (texture: temporary, isTemporary: true);
		}
		return (texture: null, isTemporary: false);
	}

	public override bool ShouldFlipScreenshotPreview()
	{
		return true;
	}

	public override bool ShouldFlipScreenshotWhenSaving()
	{
		return false;
	}

	public override async UniTask PackScreenshot(List<PackingPath> fileList)
	{
		(Texture, bool) screenshotForPacking = GetScreenshotForPacking();
		Texture screenshot = screenshotForPacking.Item1;
		bool isTemporary = screenshotForPacking.Item2;
		AsyncGPUReadbackRequest request = AsyncGPUReadback.Request(screenshot);
		while (!request.done)
		{
			await UniTask.Yield();
		}
		if (request.hasError)
		{
			throw new Exception("Couldn't capture a screnshot");
		}
		NativeArray<byte> rawData = request.GetData<byte>();
		if (isTemporary)
		{
			RenderTexture.ReleaseTemporary(screenshot as RenderTexture);
		}
		string screenshotPath = Path.Combine(Application.persistentDataPath, "REPORT", "Screenshot.jpg");
		bool shouldFlip = ShouldFlipScreenshotWhenSaving();
		GraphicsFormat graphicsFormat = screenshot.graphicsFormat;
		int width = screenshot.width;
		int height = screenshot.height;
		await UniTask.SwitchToThreadPool();
		if (shouldFlip)
		{
			NativeArray<byte> nativeArray = new NativeArray<byte>(rawData.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			int num = rawData.Length / (width * height) * width;
			for (int i = 0; i < height; i++)
			{
				NativeArray<byte>.Copy(rawData, (height - i - 1) * num, nativeArray, i * num, num);
			}
			rawData = nativeArray;
		}
		NativeArray<byte> jpgBytes = ImageConversion.EncodeNativeArrayToJPG(rawData, graphicsFormat, (uint)width, (uint)height, 0u, 90);
		await UniTask.SwitchToMainThread();
		byte[] jpgArray = jpgBytes.ToArray();
		await UniTask.SwitchToThreadPool();
		File.WriteAllBytes(screenshotPath, jpgArray);
		await UniTask.SwitchToMainThread();
		jpgBytes.Dispose();
		if (shouldFlip)
		{
			rawData.Dispose();
		}
		fileList.Add(new PackingPath(screenshotPath));
	}

	public override void CleanupScreenshot()
	{
		File.Delete(Path.Combine(Application.persistentDataPath, "REPORT", "Screenshot.jpg"));
	}

	public override bool CheckTelemetry()
	{
		if ((bool)SingletonBehaviour<TelemetryCentral>.Instance)
		{
			return SingletonBehaviour<TelemetryCentral>.Instance.enabled;
		}
		return false;
	}

	public override async UniTask PackTelemetry(List<PackingPath> fileList)
	{
		string baseDir = Path.Combine(Application.persistentDataPath, "Telemetry", "REPORT");
		if (Directory.Exists(baseDir))
		{
			Directory.Delete(baseDir, recursive: true);
		}
		Directory.CreateDirectory(baseDir);
		SingletonBehaviour<TelemetryCentral>.Instance.SaveAll("REPORT" + Path.DirectorySeparatorChar + "BUG_REPORT_");
		while (TelemetrySavingTracker.AnyPendingSaves)
		{
			await UniTask.Yield();
		}
		string[] files = Directory.GetFiles(baseDir, "*.csv");
		foreach (string path in files)
		{
			fileList.Add(new PackingPath(path));
		}
	}

	public override void CleanupTelemetry()
	{
		string path = Path.Combine(Application.persistentDataPath, "Telemetry", "REPORT");
		if (Directory.Exists(path))
		{
			Directory.Delete(path, recursive: true);
		}
	}

	public override bool CheckGFXBenchmark()
	{
		return !string.IsNullOrEmpty(FindLatest(Path.Combine(Application.persistentDataPath, "Telemetry"), "BENCHMARK_TRAINRUN_[Y]_[HB]_[G-01-S]_", ".csv"));
	}

	public override async UniTask PackGFXBenchmark(List<PackingPath> fileList)
	{
		fileList.Add(new PackingPath(FindLatest(Path.Combine(Application.persistentDataPath, "Telemetry"), "BENCHMARK_TRAINRUN_[Y]_[HB]_[G-01-S]_", ".csv")));
	}

	public override void CleanupGFXBenchmark()
	{
	}

	public override bool CheckPhysicsBenchmark()
	{
		return !string.IsNullOrEmpty(FindLatest(Path.Combine(Application.persistentDataPath, "Telemetry"), "BENCHMARK_PHYSICS_", ".csv"));
	}

	public override async UniTask PackPhysicsBenchmark(List<PackingPath> fileList)
	{
		fileList.Add(new PackingPath(FindLatest(Path.Combine(Application.persistentDataPath, "Telemetry"), "BENCHMARK_PHYSICS_", ".csv")));
	}

	public override void CleanupPhysicsBenchmark()
	{
	}
}
