using System;
using System.IO;
using Assets.Scripts.Design;
using Assets.Scripts.Ui.Sharing.Download;
using Assets.Scripts.Ui.Sharing.Download.Sandbox;
using ModApi;
using ModApi.CelestialData;
using ModApi.Core;
using ModApi.Scenes.Events;
using ModApi.Services.Purchasing;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Startup
{
	public class UrlHandlerScript : MonoBehaviour
	{
		private const string CelestialBodyUrlScheme = "simplerockets2://celestialbody/";

		private const string CraftUrlScheme = "simplerockets2://craft/";

		private const string PlanetarySystemUrlScheme = "simplerockets2://planetarysystem/";

		private const string SandboxUrlScheme = "simplerockets2://sandbox/";

		public string PendingUrl { get; private set; }

		public void HandleUrl(string url)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(url))
				{
					Debug.LogFormat("HandleUrl: {0}", url);
					if (!File.Exists(url))
					{
						if (Game.InFlightScene)
						{
							string downloadTypeFriendlyName = GetDownloadTypeFriendlyName(url);
							MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
							messageDialogScript.MessageText = $"Click Okay to begin downloading the {downloadTypeFriendlyName}.";
							messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
							{
								d.Close();
								ProcessUrl(url);
							};
						}
						else
						{
							ProcessUrl(url);
						}
						return;
					}
					ProcessFile(url);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			Game.Instance.SceneManager.LoadMenu();
		}

		public void Update()
		{
			if (Game.Instance.Inputs.LoadContentFromClipboardUrl.GetButtonDownIfEnabled() && !Game.Instance.UserInterface.AnyDialogsOpen && !Game.Instance.UserInterface.IsTextInputFocused && string.IsNullOrEmpty(PendingUrl))
			{
				string urlFromClipboard = GetUrlFromClipboard();
				if (urlFromClipboard != null)
				{
					Debug.LogFormat("Process Clipboard Url: {0}", urlFromClipboard);
					HandleUrl(urlFromClipboard);
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Could not find valid craft or sandbox URL in your clipboard text. Please, ensure you have the entire URL in your clipboard.";
				}
			}
		}

		protected virtual void Start()
		{
			Game.Instance.SceneManager.SceneLoaded += OnSceneLoaded;
		}

		private static bool CheckCustomPlanetarySystemsFeature()
		{
			IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
			return features.IsFeatureUnlocked(features.PlanetarySystemsCustom, "unlock support for downloading community planets and planetary systems.");
		}

		private static string GetDownloadTypeFriendlyName(string url)
		{
			if (IsCraft(url))
			{
				return "craft";
			}
			if (IsSandbox(url))
			{
				return "sandbox";
			}
			if (IsPlanetarySystem(url))
			{
				return "planetary system";
			}
			if (IsCelestialBody(url))
			{
				return "celestial body";
			}
			return "resource";
		}

		private static string GetUrlIdFromWebUrl(string route, string webUrl)
		{
			int num = webUrl.IndexOf(route);
			if (num > 0)
			{
				int num2 = num + route.Length;
				if (webUrl.Length >= num2 + 6)
				{
					return webUrl.Substring(num2, 6);
				}
			}
			return null;
		}

		private static bool IsCelestialBody(string url)
		{
			return url.StartsWith("simplerockets2://celestialbody/");
		}

		private static bool IsCraft(string url)
		{
			return url.StartsWith("simplerockets2://craft/");
		}

		private static bool IsPlanetarySystem(string url)
		{
			return url.StartsWith("simplerockets2://planetarysystem/");
		}

		private static bool IsSandbox(string url)
		{
			return url.StartsWith("simplerockets2://sandbox/");
		}

		private string GetUrlFromClipboard()
		{
			string systemCopyBuffer = GUIUtility.systemCopyBuffer;
			if (systemCopyBuffer != null)
			{
				string urlIdFromWebUrl = GetUrlIdFromWebUrl("/c/", systemCopyBuffer);
				if (urlIdFromWebUrl != null)
				{
					return "simplerockets2://craft/" + urlIdFromWebUrl;
				}
				string urlIdFromWebUrl2 = GetUrlIdFromWebUrl("/s/", systemCopyBuffer);
				if (urlIdFromWebUrl2 != null)
				{
					return "simplerockets2://sandbox/" + urlIdFromWebUrl2;
				}
				string urlIdFromWebUrl3 = GetUrlIdFromWebUrl("/PlanetarySystems/View/", systemCopyBuffer);
				if (urlIdFromWebUrl3 != null)
				{
					return "simplerockets2://planetarysystem/" + urlIdFromWebUrl3;
				}
				string urlIdFromWebUrl4 = GetUrlIdFromWebUrl("/CelestialBodies/View/", systemCopyBuffer);
				if (urlIdFromWebUrl4 != null)
				{
					return "simplerockets2://celestialbody/" + urlIdFromWebUrl4;
				}
			}
			return null;
		}

		private void OnSceneLoaded(object sender, SceneEventArgs e)
		{
			if (!string.IsNullOrEmpty(PendingUrl))
			{
				string pendingUrl = PendingUrl;
				Debug.Log("Processing Pending Url: " + pendingUrl);
				PendingUrl = null;
				ProcessUrl(pendingUrl);
			}
		}

		private void ProcessFile(string path)
		{
			if (path.EndsWith(".sr2-mod-android", StringComparison.InvariantCultureIgnoreCase))
			{
				string text = Path.Combine(GameData.ModsPath, path);
				if (path.Contains("%20"))
				{
					FileInfo fileInfo = new FileInfo(text);
					text = text.Replace("%20", " ");
					fileInfo.CopyTo(text, overwrite: true);
					fileInfo.Delete();
				}
				ModManager.DecompressMod(text);
				ModManager.Instance.ScanForMods(GameData.ModsPath, recursive: true, createIfNotFound: true);
			}
			else if (path.EndsWith(".sr2-mod", StringComparison.InvariantCultureIgnoreCase))
			{
				Game.Instance.ModManagerScript.LoadExternalModFile(path);
			}
			else
			{
				string text2 = File.ReadAllText(path);
				Debug.Log("UrlHandlerScript: Loaded contents from file: " + text2);
				PendingUrl = text2;
			}
		}

		private void ProcessUrl(string url)
		{
			if (IsCraft(url))
			{
				if (Game.InDesignerScene)
				{
					string urlId = url.Replace("simplerockets2://craft/", string.Empty);
					(Game.Instance.Designer as DesignerScript).DownloadCraft(urlId);
				}
				else
				{
					PendingUrl = url;
					Game.Instance.SceneManager.LoadDesigner();
				}
			}
			else if (IsSandbox(url))
			{
				if (Game.InMenuScene)
				{
					string sandboxId = url.Replace("simplerockets2://sandbox/", string.Empty);
					DownloadContentDialogScript.Create(null, new DownloadSandboxViewModel(sandboxId));
				}
				else
				{
					PendingUrl = url;
					Game.Instance.SceneManager.LoadMenu();
				}
			}
			else if (IsPlanetarySystem(url))
			{
				if (Game.InMenuScene || Game.InPlanetStudioScene || Game.InDesignerScene || Game.InFlightScene)
				{
					if (!CheckCustomPlanetarySystemsFeature())
					{
						return;
					}
					DownloadCelestialContentViewModel viewModel = new DownloadCelestialContentViewModel(url.Replace("simplerockets2://planetarysystem/", string.Empty), CelestialFileType.PlanetarySystem, skipSizeDialog: false, delegate(DownloadCelestialContentViewModel.DownloadCelestialContentSuccessful x)
					{
						if (!Device.IsMobileBuild && Game.Instance.SceneManager.InPlanetStudioScene)
						{
							x.PromptToLoadPlanetStudio();
						}
						else
						{
							x.ShowDownloadSuccessMessage("Download Succeeded!" + Environment.NewLine + Environment.NewLine + "You can start a new game using this system by selecting the 'New Game' option in the main menu. In the new game dialog, select the Planetary System button and then select this system from the list.");
						}
					});
					DownloadContentDialogScript.Create(null, viewModel);
				}
				else
				{
					PendingUrl = url;
					Game.Instance.SceneManager.LoadMenu();
				}
			}
			else if (IsCelestialBody(url))
			{
				if (Game.InMenuScene || Game.InPlanetStudioScene || Game.InDesignerScene || Game.InFlightScene)
				{
					if (!CheckCustomPlanetarySystemsFeature())
					{
						return;
					}
					DownloadCelestialContentViewModel viewModel2 = new DownloadCelestialContentViewModel(url.Replace("simplerockets2://celestialbody/", string.Empty), CelestialFileType.CelestialBody, skipSizeDialog: false, delegate(DownloadCelestialContentViewModel.DownloadCelestialContentSuccessful x)
					{
						if (!Device.IsMobileBuild)
						{
							x.PromptToLoadPlanetStudio();
						}
						else
						{
							x.ShowDownloadSuccessMessage();
						}
					});
					DownloadContentDialogScript.Create(null, viewModel2);
				}
				else
				{
					PendingUrl = url;
					Game.Instance.SceneManager.LoadMenu();
				}
			}
			else
			{
				Game.Instance.SceneManager.LoadMenu();
			}
		}
	}
}
