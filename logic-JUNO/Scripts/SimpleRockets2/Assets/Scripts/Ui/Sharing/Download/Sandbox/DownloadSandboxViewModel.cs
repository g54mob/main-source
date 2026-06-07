using System;
using System.Collections;
using System.Linq;
using System.Text;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Mods;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.CelestialDatabase;
using Assets.Scripts.Sharing.Handlers.Sandbox;
using Assets.Scripts.State;
using ModApi.Mods;
using ModApi.Scenes.Parameters;
using ModApi.Services.Purchasing;
using ModApi.Ui;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Ui.Sharing.Download.Sandbox
{
	public class DownloadSandboxViewModel : DownloadContentViewModel
	{
		public string GameStateId { get; private set; }

		public string SandboxId { get; }

		public DownloadSandboxViewModel(string sandboxId)
		{
			SandboxId = sandboxId;
		}

		public override IEnumerator Download(DownloadProgressedDelegate onProgressed, DownloadCompletedDelegate onCompleted)
		{
			float currentProgress = 0f;
			Action<DownloadContentResult> complete = delegate(DownloadContentResult x)
			{
				OnCompleted(x);
				onCompleted(x);
			};
			Action<WebsiteRequest> completeWithRequest = delegate(WebsiteRequest x)
			{
				complete(new DownloadContentResult(x));
			};
			Action cancel = delegate
			{
				complete(new DownloadContentResult(DownloadContentResultType.Canceled, null));
			};
			Action<string> fail = delegate(string x)
			{
				complete(new DownloadContentResult(DownloadContentResultType.Failure, x));
			};
			onProgressed(currentProgress, (float x) => "Determining files to download...");
			WebsiteRequest requiredResourcesRequest = GetRequiredResourcesForPost.CreateRequest(SandboxId);
			yield return SendWebRequest(requiredResourcesRequest);
			if (requiredResourcesRequest.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!requiredResourcesRequest.Success)
			{
				completeWithRequest(requiredResourcesRequest);
				yield break;
			}
			ResourceInfoResult resourceInfoResult = new ResourceInfoResult(requiredResourcesRequest.Response);
			if (resourceInfoResult.Resources.Count != 0)
			{
				DownloadContentResult downloadResourcesResult = null;
				Action<float> onProgressed2 = delegate(float x)
				{
					onProgressed(x * 0.9f, (float p) => $"Downloading Files... {p * 100f:F1}%");
				};
				yield return DownloadResources(resourceInfoResult.Resources, null, skipSizeDialog: false, onProgressed2, delegate(DownloadContentResult x)
				{
					downloadResourcesResult = x;
				});
				if (downloadResourcesResult.Result != DownloadContentResultType.Success)
				{
					complete(downloadResourcesResult);
					yield break;
				}
			}
			currentProgress = 0.9f;
			Func<float, string> downloadSandboxProgressLabel = (float x) => $"Downloading Sandbox... {x * 100f:F1}%";
			WebsiteRequest.WebsiteRequestEventHandler progressed = delegate(WebsiteRequest x)
			{
				onProgressed(currentProgress + (1f - currentProgress) * x.Progress, downloadSandboxProgressLabel);
			};
			onProgressed(currentProgress, downloadSandboxProgressLabel);
			SandboxDownload sandboxDownloadRequestHandler = new SandboxDownload(SandboxId);
			WebsiteRequest sandboxDownloadRequest = new WebsiteRequest(sandboxDownloadRequestHandler);
			yield return SendWebRequest(sandboxDownloadRequest, progressed);
			if (sandboxDownloadRequest.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!sandboxDownloadRequest.Success)
			{
				completeWithRequest(sandboxDownloadRequest);
				yield break;
			}
			currentProgress = 1f;
			onProgressed(currentProgress, (float x) => "Processing Download...");
			yield return null;
			try
			{
				if (!SaveSandbox(sandboxDownloadRequestHandler, out var saveError))
				{
					fail("Sandbox '" + GameStateId + "' downloaded, but encountered an error saving: " + saveError);
					yield break;
				}
			}
			catch (RequiresPurchaseException ex)
			{
				RequiresPurchaseException ex2 = ex;
				RequiresPurchaseException e = ex2;
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = e.Message;
				messageDialogScript.OkayButtonText = "UPGRADE";
				messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					d.Close();
					Game.Instance.InAppPurchases.CreatePurchaseDialog(e.RequiredFeatures.FirstOrDefault().ProductId ?? null);
				};
				fail(string.Empty);
				yield break;
			}
			GameStateId = sandboxDownloadRequestHandler.GameStateId;
			if (string.IsNullOrWhiteSpace(GameStateId))
			{
				fail("Unable to determine the game state id for the downloaded sandbox.");
				yield break;
			}
			RequiredModsCheck requiredMods = GetRequiredMods(GameStateId);
			if (requiredMods == null)
			{
				fail("An error occurred loading the flight state data after downloading the sandbox");
				yield break;
			}
			if (!requiredMods.AllRequirementsMet)
			{
				RequiredModsDialogScript modsDialog = RequiredModsDialogScript.Create(requiredMods);
				yield return modsDialog.WaitForResult();
				if (modsDialog.Result == MessageDialogResult.Cancel)
				{
					string text = requiredMods.BuildFailedRequirementsReport();
					Debug.LogWarning("The user aborted the loading of sandbox '" + GameStateId + "' which failed to meet mod requirements. " + Environment.NewLine + Environment.NewLine + text);
					cancel();
					yield break;
				}
				LogModRequirementsNotMetError(GameStateId, requiredMods);
			}
			Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.WebsiteDownloadSandbox);
			completeWithRequest(sandboxDownloadRequest);
		}

		public override void OnDownloadSucceeded()
		{
			Game.Instance.LoadGameStateOrDefault(GameStateId);
			Game.Instance.SceneManager.LoadFlight(FlightSceneLoadParameters.ResumeCraft());
		}

		protected void OnCompleted(DownloadContentResult result)
		{
			if (result.Result != DownloadContentResultType.Success)
			{
				Game.Instance.CelestialDatabase.RefreshDatabase();
			}
		}

		private static void LogModRequirementsNotMetError(string sandboxName, RequiredModsCheck requiredMods)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Attempting to load sandbox '" + sandboxName + "', but not all mod requirements have been met. The sandbox or associated craft may fail to load properly.");
			if (requiredMods.ModsMissingCodeExecutionRequirement.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("The sandbox or associated craft requires one or more mods with code execution support, which is not supported by this game version.");
			}
			if (requiredMods.EnabledOutdatedMods.Count > 0 || requiredMods.DisabledOutdatedMods.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("The sandbox or associated craft requires one or more mods that are installed but not up to date.");
			}
			if (requiredMods.DisabledMods.Count > 0 || requiredMods.MissingMods.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("The sandbox or associated craft requires one or more mods that are not currently installed or enabled.");
			}
			stringBuilder.AppendLine();
			stringBuilder.Append(requiredMods.BuildFailedRequirementsReport());
			Debug.LogError(stringBuilder.ToString());
		}

		private RequiredModsCheck GetRequiredMods(string gameStateId)
		{
			try
			{
				return new RequiredModsCheck(new FlightStateData(Game.Instance.GameStateManager.GetFlightStatePath(gameStateId)).FlightStateRequiredMods);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}

		private bool SaveSandbox(SandboxDownload requestHandler, out string saveError)
		{
			bool flag = false;
			try
			{
				string gameStateId;
				return requestHandler.SaveSandbox(overwriteExisting: false, out gameStateId, out saveError);
			}
			catch (SandboxDownload.SandboxAlreadyExistsException)
			{
				Debug.LogWarning("Sandbox already existed...forcing overwrite");
				string gameStateId2;
				return requestHandler.SaveSandbox(overwriteExisting: true, out gameStateId2, out saveError);
			}
		}
	}
}
