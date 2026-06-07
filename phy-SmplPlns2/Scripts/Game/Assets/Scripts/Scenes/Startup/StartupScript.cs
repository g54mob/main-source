using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Assets.Scripts.Achievements;
using Assets.Scripts.Analysis.Analytics;
using Assets.Scripts.Analytics.Logging;
using Assets.Scripts.Net;
using Assets.Scripts.XR;
using Jundroo.Common.Localization;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using Jundroo.SocialPlatforms;
using Microsoft.Win32;
using Steamworks;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Assets.Scripts.Scenes.Startup
{
	public class StartupScript : MonoBehaviour
	{
		protected virtual void Awake()
		{
			Culture.Original.ToString();
			UnityEngine.Debug.Log("Current Culture: " + CultureInfo.CurrentCulture.Name + ", Original Culture: " + Culture.Original.Name);
			if (Device.IsDemoBuild)
			{
				UnityEngine.Debug.Log("SimplePlanes 2 DEMO");
			}
			SocialExt.Initialize(AchievementManager.Instance.Achievements);
			if (Application.platform == RuntimePlatform.WindowsPlayer && !Game.Instance.Device.IsVRExclusiveBuild)
			{
				SingleInstanceTcpServer.ConnectOrStart();
			}
		}

		protected virtual void OnDestroy()
		{
			if (Game.Instance.Device.IsVRBuild && !Game.Instance.Device.IsAndroidVRBuild)
			{
				Game.Instance.XRDeviceManager.HmdActiveChanged -= OnHmdActiveChanged;
				Game.Instance.XRDeviceManager.HmdFailedToActivate -= OnHmdFailedToActivate;
			}
		}

		protected virtual void Start()
		{
			if (Game.Instance.Device.IsVRBuild && !Game.Instance.Device.IsAndroidVRBuild)
			{
				XRDeviceManager xRDeviceManager = Game.Instance.XRDeviceManager;
				xRDeviceManager.HmdActiveChanged += OnHmdActiveChanged;
				xRDeviceManager.HmdFailedToActivate += OnHmdFailedToActivate;
				if ((Application.isEditor && Game.Instance.Device.IsVRBuild) || Game.Instance.Device.IsPCVRExclusiveBuild)
				{
					xRDeviceManager.AutoSwitchSceneOnXRStateChanged = false;
					xRDeviceManager.SetXrActive(active: true);
					Game.Instance.DevConsole.gameObject.SetActive(value: false);
				}
				else
				{
					PerformStartupTasks();
				}
			}
			else
			{
				PerformStartupTasks();
			}
		}

		private static void AutoSplitAndroidLog(string logMessage)
		{
			StackTraceLogType stackTraceLogType = Application.GetStackTraceLogType(LogType.Log);
			Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
			string[] array = logMessage.Split(new string[1] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string text in array)
			{
				int num = 1000;
				int num2 = 0;
				int num3 = num2 + num;
				int num4 = text.Length - 1;
				while (num2 < num4)
				{
					if (num3 >= num4)
					{
						UnityEngine.Debug.Log(text.Substring(num2));
						break;
					}
					int num5 = text.LastIndexOf('\n', num3, num3 - num2);
					if (num5 < 0)
					{
						UnityEngine.Debug.Log(text.Substring(num2, num3 - num2));
						break;
					}
					UnityEngine.Debug.Log(text.Substring(num2, num5 - num2));
					num2 = num5 + 1;
					num3 = num2 + num;
				}
			}
			Application.SetStackTraceLogType(LogType.Log, stackTraceLogType);
		}

		private static string GetDownloadedAirplaneId()
		{
			string[] commandLineArgs = System.Environment.GetCommandLineArgs();
			if (commandLineArgs != null && commandLineArgs.Length >= 2)
			{
				for (int i = 0; i < commandLineArgs.Length; i++)
				{
					try
					{
						string text = commandLineArgs[i];
						if (text.EndsWith(".splane", StringComparison.InvariantCultureIgnoreCase) && File.Exists(text))
						{
							string text2 = File.ReadAllText(text);
							if (Utilities.IsValidCraftUrlId(text2))
							{
								return text2;
							}
						}
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogErrorFormat("Error reading/validating downloaded plane file: {0}\n{1}", commandLineArgs[i], ex.Message);
					}
				}
			}
			else if (SocialExt.IsSteam)
			{
				try
				{
					string launchQueryParam = SocialExt.Steam.GetLaunchQueryParam("plane");
					if (!string.IsNullOrEmpty(launchQueryParam) && File.Exists(launchQueryParam))
					{
						string text3 = File.ReadAllText(launchQueryParam);
						if (Utilities.IsValidCraftUrlId(text3))
						{
							return text3;
						}
					}
				}
				catch (Exception ex2)
				{
					UnityEngine.Debug.LogErrorFormat("Error obtaining or loading plane file from Steam:{0}\n{1}", ex2.Message, ex2.StackTrace);
				}
			}
			return null;
		}

		private static string GetSystemInfo()
		{
			return string.Format("Device Caps:\ndeviceModel: " + SystemInfo.deviceModel + "\n" + $"deviceType: {SystemInfo.deviceType}\n" + "operatingSystem: " + SystemInfo.operatingSystem + "\n" + $"operatingSystem: {SystemInfo.operatingSystemFamily}\n" + $"processorCount: {SystemInfo.processorCount}\n" + "processorType: " + SystemInfo.processorType + "\n" + $"processorFrequency: {SystemInfo.processorFrequency}\n" + $"systemMemorySize: {SystemInfo.systemMemorySize}\n" + $"graphicsDeviceID: {SystemInfo.graphicsDeviceID}\n" + "graphicsDeviceName: " + SystemInfo.graphicsDeviceName + "\n" + $"graphicsDeviceType: {SystemInfo.graphicsDeviceType}\n" + "graphicsDeviceVendor: " + SystemInfo.graphicsDeviceVendor + "\n" + $"graphicsDeviceVendorID: {SystemInfo.graphicsDeviceVendorID}\n" + "graphicsDeviceVersion: " + SystemInfo.graphicsDeviceVersion + "\n" + $"graphicsMemorySize: {SystemInfo.graphicsMemorySize}\n" + $"graphicsMultiThreaded: {SystemInfo.graphicsMultiThreaded}\n" + $"graphicsShaderLevel: {SystemInfo.graphicsShaderLevel}\n" + $"copyTextureSupport: {SystemInfo.copyTextureSupport}\n" + $"hasDynamicUniformArrayIndexingInFragmentShaders: {SystemInfo.hasDynamicUniformArrayIndexingInFragmentShaders}\n" + $"hasHiddenSurfaceRemovalOnGPU: {SystemInfo.hasHiddenSurfaceRemovalOnGPU}\n" + $"hasMipMaxLevel: {SystemInfo.hasMipMaxLevel}\n" + $"hdrDisplaySupportFlags: {SystemInfo.hdrDisplaySupportFlags}\n" + $"maxComputeBufferInputsCompute: {SystemInfo.maxComputeBufferInputsCompute}\n" + $"maxComputeBufferInputsDomain: {SystemInfo.maxComputeBufferInputsDomain}\n" + $"maxComputeBufferInputsFragment: {SystemInfo.maxComputeBufferInputsFragment}\n" + $"maxComputeBufferInputsGeometry: {SystemInfo.maxComputeBufferInputsGeometry}\n" + $"maxComputeBufferInputsHull: {SystemInfo.maxComputeBufferInputsHull}\n" + $"maxComputeBufferInputsVertex: {SystemInfo.maxComputeBufferInputsVertex}\n" + $"maxComputeWorkGroupSize: {SystemInfo.maxComputeWorkGroupSize}\n" + $"maxComputeWorkGroupSizeX: {SystemInfo.maxComputeWorkGroupSizeX}\n" + $"maxComputeWorkGroupSizeY: {SystemInfo.maxComputeWorkGroupSizeY}\n" + $"maxComputeWorkGroupSizeZ: {SystemInfo.maxComputeWorkGroupSizeZ}\n" + $"maxCubemapSize: {SystemInfo.maxCubemapSize}\n" + $"maxTextureSize: {SystemInfo.maxTextureSize}\n" + $"npotSupport: {SystemInfo.npotSupport}\n" + $"renderingThreadingMode: {SystemInfo.renderingThreadingMode}\n" + $"supportedRandomWriteTargetCount: {SystemInfo.supportedRandomWriteTargetCount}\n" + $"supportedRenderTargetCount: {SystemInfo.supportedRenderTargetCount}\n" + $"supports2DArrayTextures: {SystemInfo.supports2DArrayTextures}\n" + $"supports3DRenderTextures: {SystemInfo.supports3DRenderTextures}\n" + $"supports3DTextures: {SystemInfo.supports3DTextures}\n" + $"supports32bitsIndexBuffer: {SystemInfo.supports32bitsIndexBuffer}\n" + $"supportsAccelerometer: {SystemInfo.supportsAccelerometer}\n" + $"supportsAsyncCompute: {SystemInfo.supportsAsyncCompute}\n" + $"supportsAsyncGPUReadback: {SystemInfo.supportsAsyncGPUReadback}\n" + $"supportsAudio: {SystemInfo.supportsAudio}\n" + $"supportsCompressed3DTextures: {SystemInfo.supportsCompressed3DTextures}\n" + $"supportsComputeShaders: {SystemInfo.supportsComputeShaders}\n" + $"supportsConservativeRaster: {SystemInfo.supportsConservativeRaster}\n" + $"supportsCubemapArrayTextures: {SystemInfo.supportsCubemapArrayTextures}\n" + $"supportsGeometryShaders: {SystemInfo.supportsGeometryShaders}\n" + $"supportsGpuRecorder: {SystemInfo.supportsGpuRecorder}\n" + $"supportsGraphicsFence: {SystemInfo.supportsGraphicsFence}\n" + $"supportsGyroscope: {SystemInfo.supportsGyroscope}\n" + $"supportsHardwareQuadTopology: {SystemInfo.supportsHardwareQuadTopology}\n" + $"supportsInstancing: {SystemInfo.supportsInstancing}\n" + $"supportsLocationService: {SystemInfo.supportsLocationService}\n" + $"supportsMipStreaming: {SystemInfo.supportsMipStreaming}\n" + $"supportsMotionVectors: {SystemInfo.supportsMotionVectors}\n" + $"supportsMultisampleAutoResolve: {SystemInfo.supportsMultisampleAutoResolve}\n" + $"supportsMultisampled2DArrayTextures: {SystemInfo.supportsMultisampled2DArrayTextures}\n" + $"supportsMultisampledTextures: {SystemInfo.supportsMultisampledTextures}\n" + $"supportsMultiview: {SystemInfo.supportsMultiview}\n" + $"supportsRawShadowDepthSampling: {SystemInfo.supportsRawShadowDepthSampling}\n" + $"supportsRayTracing: {SystemInfo.supportsRayTracing}\n" + $"supportsRenderTargetArrayIndexFromVertexShader: {SystemInfo.supportsRenderTargetArrayIndexFromVertexShader}\n" + $"supportsSeparatedRenderTargetsBlend: {SystemInfo.supportsSeparatedRenderTargetsBlend}\n" + $"supportsSetConstantBuffer: {SystemInfo.supportsSetConstantBuffer}\n" + $"supportsShadows: {SystemInfo.supportsShadows}\n" + $"supportsSparseTextures: {SystemInfo.supportsSparseTextures}\n" + $"supportsStoreAndResolveAction: {SystemInfo.supportsStoreAndResolveAction}\n" + $"supportsTessellationShaders: {SystemInfo.supportsTessellationShaders}\n" + $"supportsTextureWrapMirrorOnce: {SystemInfo.supportsTextureWrapMirrorOnce}\n" + $"supportsVibration: {SystemInfo.supportsVibration}\n" + $"usesLoadStoreActions: {SystemInfo.usesLoadStoreActions}\n" + $"usesReversedZBuffer: {SystemInfo.usesReversedZBuffer}");
		}

		private static string GetTextureSupportInfo()
		{
			string text = "Texture Support\n" + $"Default LDR Format: {SystemInfo.GetGraphicsFormat(DefaultFormat.LDR)}\n" + $"Default HDR Format: {SystemInfo.GetGraphicsFormat(DefaultFormat.HDR)}\n";
			text += "SupportsTextureFormat: \n";
			TextureFormat[] array = (from x in Enum.GetNames(typeof(TextureFormat))
				where !Attribute.IsDefined(typeof(TextureFormat).GetField(x), typeof(ObsoleteAttribute))
				select (TextureFormat)Enum.Parse(typeof(TextureFormat), x) into x
				where x >= (TextureFormat)0
				select x).ToArray();
			foreach (TextureFormat textureFormat in array)
			{
				if (textureFormat >= (TextureFormat)0 && SystemInfo.SupportsTextureFormat(textureFormat))
				{
					text += $"  {textureFormat}\n";
				}
			}
			text += "SupportsRenderTextureFormat: \n";
			RenderTextureFormat[] array2 = (from x in Enum.GetNames(typeof(RenderTextureFormat))
				where !Attribute.IsDefined(typeof(RenderTextureFormat).GetField(x), typeof(ObsoleteAttribute))
				select (RenderTextureFormat)Enum.Parse(typeof(RenderTextureFormat), x) into x
				where x >= RenderTextureFormat.ARGB32
				select x).ToArray();
			foreach (RenderTextureFormat renderTextureFormat in array2)
			{
				if (renderTextureFormat >= RenderTextureFormat.ARGB32 && SystemInfo.SupportsRenderTextureFormat(renderTextureFormat))
				{
					text = ((!SystemInfo.SupportsBlendingOnRenderTextureFormat(renderTextureFormat)) ? (text + $"  {renderTextureFormat} (No Blend)\n") : (text + $"  {renderTextureFormat}\n"));
				}
			}
			text += "IsFormatSupported: \n";
			GraphicsFormatUsage[] array3 = (from x in Enum.GetNames(typeof(GraphicsFormatUsage))
				select (GraphicsFormatUsage)Enum.Parse(typeof(GraphicsFormatUsage), x)).ToArray();
			string text2 = string.Join(", ", array3.Select((GraphicsFormatUsage x) => x.ToString()));
			foreach (GraphicsFormat item in from x in Enum.GetNames(typeof(GraphicsFormat))
				select Enum.Parse(typeof(GraphicsFormat), x))
			{
				string text3 = string.Empty;
				GraphicsFormatUsage[] array4 = array3;
				for (int num = 0; num < array4.Length; num++)
				{
					GraphicsFormatUsage usage = array4[num];
					SystemInfo.IsFormatSupported(item, usage);
					text3 = ((text3 == string.Empty) ? usage.ToString() : (text3 + ", " + usage));
				}
				if (text3 != string.Empty)
				{
					text += string.Format("  {0}: {1}\n", item, (text3 == text2) ? "All" : text3);
				}
			}
			return text;
		}

		private static void VerifyOwnershipOnSteam()
		{
			if (Application.isEditor || Device.IsDebugBuild || Device.IsMobileRuntime)
			{
				return;
			}
			bool flag = true;
			try
			{
				SteamAPI.RestartAppIfNecessary(new AppId_t(uint.Parse("2840470")));
				if (!SteamAPI.Init())
				{
					UnityEngine.Debug.Log("SteamAPI.Init failed. Exiting game.");
					flag = false;
				}
				if (!SteamApps.BIsSubscribed())
				{
					UnityEngine.Debug.Log("User does not own the game. Exiting game.");
					flag = false;
				}
			}
			catch (Exception arg)
			{
				UnityEngine.Debug.Log($"Error encountered while verifying ownership. Exiting game. Error: \n{arg}");
				flag = false;
			}
			if (flag)
			{
				UnityEngine.Debug.Log("Steam initialized and ownership confirmed.");
			}
			else
			{
				Application.Quit();
			}
		}

		private void CleanFileAssociation(string extension)
		{
			RegistryKey currentUser = Registry.CurrentUser;
			string subkey = "Software\\Classes\\Jundroo.SimplePlanes2." + extension + ".1";
			string subkey2 = "Software\\Classes\\." + extension;
			RegistryKey registryKey = currentUser.OpenSubKey(subkey);
			if (registryKey != null)
			{
				registryKey.Close();
				currentUser.DeleteSubKeyTree(subkey);
			}
			registryKey = currentUser.OpenSubKey(subkey2);
			if (registryKey != null)
			{
				registryKey.Close();
				currentUser.DeleteSubKeyTree(subkey2);
			}
		}

		private void HMDActivationComplete()
		{
			Game.Instance.XRDeviceManager.AutoSwitchSceneOnXRStateChanged = true;
			Game.Instance.DevConsole.gameObject.SetActive(value: true);
			PerformStartupTasks();
		}

		private void JoinSteamLobbyIfNecessary()
		{
			ulong? num = Game.Instance.NetworkGameManager.SteamLobbyManager?.GetCommandLineLobbyId();
			if (num.HasValue)
			{
				Game.Instance.NetworkGameManager.SteamLobbyManager.JoinLobby(num.Value, autoLoadScene: true, null);
			}
		}

		private void LoadStartingScene(string downloadedAircraftId, Action callback)
		{
			Game.Instance.Settings.App.NumberOfApplicationRuns++;
			Game.Instance.Settings.App.Save();
			if (downloadedAircraftId != null)
			{
				Game.Instance.DownloadedAircraftId = downloadedAircraftId;
				Game.Instance.SceneManager.LoadDesigner(callback);
			}
			else if (Game.Instance.ClonedEditorArgs.Contains("autoload"))
			{
				Game.Instance.SceneManager.LoadScene("Terrain", callback);
			}
			else
			{
				Game.Instance.SceneManager.LoadMenu(callback);
			}
		}

		private void OnHmdActiveChanged(bool active)
		{
			Game.Instance.DevConsole.gameObject.SetActive(value: true);
			HMDActivationComplete();
		}

		private void OnHmdFailedToActivate()
		{
			Game.Instance.DevConsole.gameObject.SetActive(value: true);
			UnityEngine.Debug.LogWarning("HMD did not initialize in time...switching back to flat camera rig");
			HMDActivationComplete();
		}

		private void PerformStartupTasks()
		{
			bool isDesktopBuild = Game.Instance.Device.IsDesktopBuild;
			try
			{
				MobileLogger.Initialize();
				string text = Game.Version.ToString();
				text += "f";
				string text2 = (isDesktopBuild ? $"Launch Command: {System.Environment.CommandLine}" : "N/A");
				string text3 = (isDesktopBuild ? $"Executable: {Process.GetCurrentProcess().MainModule.FileName}" : "N/A");
				string text4 = $"Aircraft Designs Folder: {Game.Instance.CraftDatabase.CraftFilesRootPath}";
				Stopwatch stopwatch = Stopwatch.StartNew();
				string systemInfo = GetSystemInfo();
				long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
				stopwatch.Restart();
				string textureSupportInfo = GetTextureSupportInfo();
				long elapsedMilliseconds2 = stopwatch.ElapsedMilliseconds;
				string text5 = string.Format(text + "\n\n" + text2 + "\n" + text3 + "\n" + text4 + "\n\n" + systemInfo + "\n\n" + textureSupportInfo + "\n\n" + $"System info capture time: {elapsedMilliseconds}ms\n" + $"Texture info capture time: {elapsedMilliseconds2}ms\n");
				if (Game.Instance.Device.IsAndroidRuntime)
				{
					AutoSplitAndroidLog(text5);
				}
				else
				{
					UnityEngine.Debug.Log(text5);
				}
				Game.Instance.OnStartup();
				if (isDesktopBuild)
				{
					Resolution value = Game.Instance.Settings.Quality.Display.Resolution.Value;
					int num = value.width;
					int num2 = value.height;
					if (num <= 0 || num2 <= 0)
					{
						num = 1024;
						num2 = 768;
					}
					Screen.SetResolution(num, num2, Game.Instance.Settings.Quality.Display.Fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed, value.refreshRateRatio);
					UnityEngine.Debug.LogFormat("Screen Size: {0}x{1}, Requested: {2}x{3}\nResolution: {4}x{5}@{6}hz, Full Screen: {7}", Screen.width, Screen.height, num, num2, Screen.currentResolution.width, Screen.currentResolution.height, Screen.currentResolution.refreshRateRatio.value, Screen.fullScreen);
				}
				else
				{
					Screen.autorotateToLandscapeLeft = true;
					Screen.autorotateToLandscapeRight = true;
					Screen.orientation = ScreenOrientation.AutoRotation;
					UnityEngine.Input.simulateMouseWithTouches = false;
				}
				string downloadedAircraftId = null;
				if (Application.platform == RuntimePlatform.WindowsPlayer)
				{
					downloadedAircraftId = GetDownloadedAirplaneId();
				}
				try
				{
					if (!Game.Instance.Device.IsUnityEditor && Game.Instance.Device.IsWindowsBuild)
					{
						UpdateFileAssociation("splane");
						UpdateFileAssociation("spmod");
					}
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogErrorFormat(this, "Something happened when adjusting file associations: {0}", ex.Message);
				}
				VerifyOwnershipOnSteam();
				LoadStartingScene(downloadedAircraftId, delegate
				{
					UnityAnalytics.Initialize();
					string message;
					try
					{
						message = (SocialExt.IsSteam ? SocialExt.Active.LoggedOn.ToString() : "none");
					}
					catch (Exception)
					{
						message = "ex";
					}
					Game.Instance.DevConsole.gameObject.SetActive(value: true);
					UnityEngine.Debug.Log(message);
					JoinSteamLobbyIfNecessary();
				});
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}

		private void UpdateFileAssociation(string extension)
		{
			CleanFileAssociation(extension);
		}
	}
}
