using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.CelestialDatabase;
using ModApi;
using ModApi.CelestialData;
using ModApi.Services.Purchasing;
using ModApi.Ui;
using Unity.IO.Compression;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Ui.Sharing.Download
{
	public abstract class DownloadContentViewModel
	{
		public delegate void DownloadCompletedDelegate(DownloadContentResult result);

		public delegate void DownloadProgressedDelegate(float progress, Func<float, string> progressLabel = null);

		public bool Canceled { get; private set; }

		protected WebsiteRequest CurrentWebRequest { get; private set; }

		public virtual void Cancel()
		{
			Canceled = true;
			CurrentWebRequest?.Cancel();
		}

		public abstract IEnumerator Download(DownloadProgressedDelegate onProgressed, DownloadCompletedDelegate onCompleted);

		public virtual void OnDialogClosed()
		{
		}

		public abstract void OnDownloadSucceeded();

		protected IEnumerator DownloadResources(List<ResourceInfoResult.ResourceInfo> resources, Guid? primaryResourceId, bool skipSizeDialog, Action<float> onProgressed, DownloadCompletedDelegate onCompleted)
		{
			Action<WebsiteRequest> completeWithRequest = delegate(WebsiteRequest x)
			{
				onCompleted(new DownloadContentResult(x));
			};
			Action success = delegate
			{
				onCompleted(new DownloadContentResult(DownloadContentResultType.Success, null));
			};
			Action cancel = delegate
			{
				onCompleted(new DownloadContentResult(DownloadContentResultType.Canceled, null));
			};
			Action<string> fail = delegate(string x)
			{
				onCompleted(new DownloadContentResult(DownloadContentResultType.Failure, x));
			};
			int totalFileSize = 0;
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			List<(Guid Hash, string FileName, int Size, CelestialFileType Type)> requiredFiles = new List<(Guid, string, int, CelestialFileType)>();
			for (int num = resources.Count - 1; num >= 0; num--)
			{
				ResourceInfoResult.ResourceInfo resourceInfo = resources[num];
				if (!resourceInfo.Exists)
				{
					fail("Unable to find required resource file '" + resourceInfo.Hash + "' on the server.");
					yield break;
				}
				Guid guid = Guid.Parse(resourceInfo.Hash);
				if (db.GetFile(guid) == null)
				{
					requiredFiles.Add((guid, resourceInfo.FileName, resourceInfo.Size, (CelestialFileType)resourceInfo.Type));
					totalFileSize += resourceInfo.Size;
				}
			}
			if (requiredFiles.Count == 0)
			{
				success();
				yield break;
			}
			if (requiredFiles.Any(((Guid Hash, string FileName, int Size, CelestialFileType Type) x) => x.Type == CelestialFileType.CelestialBody || x.Type == CelestialFileType.PlanetarySystem))
			{
				IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
				_ = Game.Instance.InAppPurchases.Features.PlanetarySystemsCustom;
				if (!features.IsFeatureUnlocked(features.PlanetarySystemsCustom, "unlock support for downloading community planets and planetary systems."))
				{
					cancel();
					yield break;
				}
			}
			bool flag = requiredFiles.Count == 1 && requiredFiles[0].Hash == primaryResourceId;
			if (!skipSizeDialog && !flag)
			{
				ModApi.Ui.MessageDialogScript sizeDialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				sizeDialog.MessageText = $"This content requires {requiredFiles.Count} files to be downloaded. " + Environment.NewLine + Environment.NewLine + "Estimated download size: " + Utilities.FormatMemorySize(totalFileSize) + "." + Environment.NewLine + Environment.NewLine;
				sizeDialog.OkayButtonText = "DOWNLOAD";
				sizeDialog.CancelButtonText = "CANCEL";
				yield return sizeDialog.WaitForResult();
				if (sizeDialog.Result == MessageDialogResult.Cancel)
				{
					cancel();
					yield break;
				}
			}
			float currentProgress = 0f;
			onProgressed(currentProgress);
			foreach (var requiredFile in requiredFiles)
			{
				float maxFileProgress = (float)requiredFile.Size / ((float)totalFileSize * 2f);
				WebsiteRequest.WebsiteRequestEventHandler progressed = delegate(WebsiteRequest x)
				{
					float num2 = x.Progress * maxFileProgress;
					onProgressed(Mathf.Clamp01(currentProgress + num2));
				};
				WebsiteRequest downloadResourceRequest = DownloadResource.CreateRequest(requiredFile.Hash);
				yield return SendWebRequest(downloadResourceRequest, progressed);
				if (downloadResourceRequest.IsCanceled)
				{
					cancel();
					yield break;
				}
				if (!downloadResourceRequest.Success)
				{
					completeWithRequest(downloadResourceRequest);
					yield break;
				}
				Guid guid2 = ProcessDownloadedFile(downloadResourceRequest.ResponseBytes, requiredFile.FileName, requiredFile.Type);
				if (guid2 != requiredFile.Hash)
				{
					fail($"The id of the installed resource file '{guid2}' does not match the id of the downloaded resource file '{requiredFile.Hash}'.");
					yield break;
				}
				currentProgress = Mathf.Clamp01(currentProgress + maxFileProgress + maxFileProgress);
				onProgressed(currentProgress);
				yield return null;
			}
			db.RefreshDatabase();
			success();
		}

		protected IEnumerator SendWebRequest(WebsiteRequest request, WebsiteRequest.WebsiteRequestEventHandler progressed = null, WebsiteRequest.WebsiteRequestEventHandler completed = null, WebsiteRequest.WebsiteRequestEventHandler canceled = null)
		{
			try
			{
				CurrentWebRequest = request;
				if (progressed != null)
				{
					request.Progressed += progressed;
				}
				if (completed != null)
				{
					request.Completed += completed;
				}
				if (canceled != null)
				{
					request.Canceled += canceled;
				}
				if (Canceled)
				{
					request.Cancel();
				}
				request.SendRequest();
				yield return new WaitUntil(() => request.IsDone);
			}
			finally
			{
				DownloadContentViewModel downloadContentViewModel = this;
				if (progressed != null)
				{
					request.Progressed -= progressed;
				}
				if (completed != null)
				{
					request.Completed -= completed;
				}
				if (canceled != null)
				{
					request.Canceled -= canceled;
				}
				downloadContentViewModel.CurrentWebRequest = null;
			}
		}

		private Guid ProcessDownloadedFile(byte[] fileContent, string fileName, CelestialFileType fileType)
		{
			if (fileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
			{
				using (MemoryStream stream = new MemoryStream(fileContent))
				{
					using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
					using MemoryStream memoryStream = new MemoryStream();
					gZipStream.CopyTo(memoryStream);
					fileContent = memoryStream.ToArray();
				}
				fileName = fileName.Remove(fileName.Length - 4);
			}
			else if (fileName.EndsWith(".nozip", StringComparison.OrdinalIgnoreCase))
			{
				fileName = fileName.Remove(fileName.Length - 6);
			}
			return Game.Instance.CelestialDatabase.AddFile(fileContent, fileType, isUserData: false, fileName);
		}
	}
}
