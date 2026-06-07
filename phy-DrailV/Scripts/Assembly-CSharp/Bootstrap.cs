#define UNITY_STANDALONE
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Cysharp.Threading.Tasks;
using DV;
using DV.Mods;
using DV.Platform;
using DV.Platform.GeForceNOW;
using DV.Platform.Steam;
using DV.Utils;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.XR;

public class Bootstrap : MonoBehaviour
{
	public static bool bootstrapped;

	public static string[] commandLineArgs;

	public GameObject entitlementFloatiePrefab;

	public GameObject nonVrNoticeFloatiePrefab;

	private static string[] startupInfo;

	private bool benchmarkMode;

	private Type benchmarkRunner;

	public static string[] StartupInfo
	{
		get
		{
			if (startupInfo == null)
			{
				startupInfo = new string[20]
				{
					"Build version: " + BuildInfo.BUILD_VERSION_STR,
					"Mod managers: " + ModManagerInfo.BootstrapQuickCheck(),
					"Build destination: " + BuildInfo.BUILD_DESTINATION,
					"Build timestamp: " + BuildInfo.TIMESTAMP,
					"Build number: " + BuildInfo.BUILDBOT_INFO,
					"Build type: " + (Debug.isDebugBuild ? "debug" : "release"),
					"Build GUID: " + Application.buildGUID,
					"App version: " + Application.version,
					"App identifier: " + Application.identifier,
					"Build tags: " + string.Join(", ", Application.GetBuildTags()),
					"OS: " + SystemInfo.operatingSystem,
					"CPU: " + SystemInfo.processorType,
					$"CPU freq: {SystemInfo.processorFrequency}",
					$"RAM: {SystemInfo.systemMemorySize}",
					"GPU: " + SystemInfo.graphicsDeviceName,
					"GPU vendor: " + SystemInfo.graphicsDeviceVendor,
					$"GPU memory: {SystemInfo.graphicsMemorySize}",
					"GeForce NOW: " + (DVGeForceNOW.IsRunningInCloud ? "Yes" : "No"),
					"Steam Deck: " + (DVSteamworks.IsSteamDeck ? "Yes" : "No"),
					"Log timestamp: " + DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture).Replace('T', ' ') + " UTC"
				};
			}
			return startupInfo;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		bootstrapped = false;
		commandLineArgs = Environment.GetCommandLineArgs();
	}

	private IEnumerator Start()
	{
		_ = SingletonBehaviour<DVSteamworks>.Instance;
		_ = SingletonBehaviour<DVGeForceNOW>.Instance;
		commandLineArgs = Environment.GetCommandLineArgs();
		Debug.Log(string.Join("\n", StartupInfo));
		Debug.Log("Command line args:\n" + string.Join("\n", commandLineArgs));
		DVWindow.SetWindowTitle("Derail Valley - " + BuildInfo.BUILD_VERSION_STR + " - " + BuildInfo.BUILD_DESTINATION);
		bool flag = false;
		if (commandLineArgs.Contains("-train-benchmark"))
		{
			benchmarkMode = true;
			benchmarkRunner = typeof(TrainRideBenchmark);
			flag = true;
		}
		if (commandLineArgs.Contains("-vrmode") && !flag)
		{
			yield return null;
			if (string.IsNullOrEmpty(XRSettings.loadedDeviceName))
			{
				Log("Got -vrmode but failed to load VR device, game will start in non-VR mode");
				VRManager.ForceVREnabled(on: false);
				GameObject floatie = UnityEngine.Object.Instantiate(nonVrNoticeFloatiePrefab);
				yield return WaitFor.Seconds(4.5f);
				UnityEngine.Object.Destroy(floatie);
			}
			else
			{
				Log("VR device '" + XRSettings.loadedDeviceName + "' loaded via -vrmode");
			}
		}
		else if (VRManager.HasNonVrArg() || flag)
		{
			Log("Non-VR mode requested");
			VRManager.ForceVREnabled(on: false);
		}
		else
		{
			string text = XRSettings.supportedDevices[1];
			if (string.Compare(XRSettings.loadedDeviceName, text, ignoreCase: true) != 0)
			{
				Log("Switching VR device from \"" + XRSettings.loadedDeviceName + "\" to \"" + text + "\"");
				XRSettings.LoadDeviceByName(text);
				yield return null;
				if (string.IsNullOrEmpty(XRSettings.loadedDeviceName))
				{
					Log("Couldn't automatically load VR device, game will start in non-VR mode");
					VRManager.ForceVREnabled(on: false);
					GameObject floatie = UnityEngine.Object.Instantiate(nonVrNoticeFloatiePrefab);
					yield return WaitFor.Seconds(4.5f);
					UnityEngine.Object.Destroy(floatie);
				}
				else
				{
					XRSettings.enabled = true;
					Log("VR device '" + XRSettings.loadedDeviceName + "' loaded via automatic selection");
				}
			}
			else
			{
				Log("VR device \"" + XRSettings.loadedDeviceName + "\" was already loaded, nothing was done");
			}
		}
		EntitlementCheck entitlement = UnityEngine.Object.FindObjectOfType<EntitlementCheck>();
		if (entitlement == null)
		{
			Log("Skipping entitlement check, switching to next scene");
			SwitchToNextScene();
		}
		else
		{
			Log($"Waiting for entitlement check: '{entitlement.GetType()}'");
			while (!entitlement.GetResult().HasValue)
			{
				yield return null;
			}
			if (entitlement.GetResult().Value)
			{
				Log("Entitlement check passed, switching to next scene");
				SwitchToNextScene();
			}
			else
			{
				Log("Entitlement check FAILED");
				UnityEngine.Object.Instantiate(entitlementFloatiePrefab);
				StartCoroutine(QuitGame());
			}
		}
		Application.targetFrameRate = Screen.currentResolution.refreshRate;
		if (!PlayerLoopHelper.IsInjectedUniTaskPlayerLoop())
		{
			Debug.Log("UniTaskPlayerLoop wasn't injected, injecting now");
			PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
			PlayerLoopHelper.Initialize(ref playerLoop, InjectPlayerLoopTimings.Minimum);
		}
		bootstrapped = true;
	}

	private void SwitchToNextScene()
	{
		if (benchmarkMode)
		{
			BenchmarkSetup.benchmarkRunner = benchmarkRunner;
			SceneSwitcher.SwitchToScene(DVScenes.Benchmark);
		}
		else
		{
			SceneSwitcher.BootstrapToNextScene();
		}
	}

	private IEnumerator QuitGame()
	{
		yield return WaitFor.SecondsRealtime(4f);
		SceneSwitcher.QuitGame();
	}

	private static void Log(object msg)
	{
		Debug.Log($"[bootstrap] {msg}");
	}
}
