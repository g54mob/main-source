using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.CelestialDatabase;
using Assets.Scripts.State;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Ui.Sharing.Upload
{
	public abstract class UploadContentViewModel
	{
		public delegate void UploadCompletedDelegate(UploadContentResult result);

		public delegate void UploadProgressedDelegate(float progress, Func<float, string> progressLabel = null);

		public bool Canceled { get; private set; }

		public string DefaultDescription { get; set; }

		public string DefaultName { get; set; }

		public string DescriptionLabel { get; internal set; }

		public int MaxOptionalScreenshots { get; set; }

		public int MinDescriptionLength { get; set; }

		public string NameLabel { get; internal set; }

		public bool PreventTakeScreenshot { get; protected set; }

		public string Title { get; internal set; }

		public bool VerifyPlanetarySystemExistsOnServer { get; internal set; }

		protected WebsiteRequest CurrentWebRequest { get; private set; }

		public UploadContentViewModel()
		{
			MaxOptionalScreenshots = 5;
			MinDescriptionLength = 0;
		}

		public virtual void Cancel()
		{
			Canceled = true;
			CurrentWebRequest?.Cancel();
		}

		public virtual IEnumerator DialogCreated(Action closeDialog, UploadProgressedDelegate onProgressed)
		{
			if (VerifyPlanetarySystemExistsOnServer)
			{
				yield return VerifyPlanetarySystemExistsOnDialogCreated(closeDialog, onProgressed);
			}
		}

		public virtual void OnDialogClosed()
		{
		}

		public virtual IEnumerator PrepareToSend()
		{
			yield return null;
			Canceled = false;
			CurrentWebRequest = null;
		}

		public abstract IEnumerator Upload(UploadContentModel model, UploadProgressedDelegate onUploadProgressed, UploadCompletedDelegate onUploadCompleted);

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
				UploadContentViewModel uploadContentViewModel = this;
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
				uploadContentViewModel.CurrentWebRequest = null;
			}
		}

		protected IEnumerator VerifyPlanetarySystemExistsOnDialogCreated(Action closeDialog, UploadProgressedDelegate onProgressed)
		{
			FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
			if (flightStateData.PlanetarySystem == null)
			{
				closeDialog();
				string errorMessage = "Unable to determine the current planetary.";
				yield return Game.Instance.UserInterface.CreateErrorDialog(errorMessage).WaitForResult();
				yield break;
			}
			Guid hashBasedFileId = flightStateData.PlanetarySystem.GetHashBasedFileId();
			onProgressed(0f, (float x) => "Contacting Server...");
			WebsiteRequest checkResourcesExistRequest = CheckResourcesExist.CreateRequest(new List<Guid> { hashBasedFileId });
			yield return SendWebRequest(checkResourcesExistRequest);
			if (checkResourcesExistRequest.IsCanceled)
			{
				closeDialog();
				yield break;
			}
			if (!checkResourcesExistRequest.Success)
			{
				closeDialog();
				UploadContentResult uploadContentResult = new UploadContentResult(checkResourcesExistRequest);
				yield return Game.Instance.UserInterface.CreateErrorDialog(uploadContentResult.Message).WaitForResult();
				yield break;
			}
			ResourceInfoResult resourceInfoResult = new ResourceInfoResult(checkResourcesExistRequest.Response);
			if (resourceInfoResult.Resources.Count == 0)
			{
				closeDialog();
				string errorMessage2 = "Unable to determine if the planetary system exists on the server. Check resources returned zero results.";
				yield return Game.Instance.UserInterface.CreateErrorDialog(errorMessage2).WaitForResult();
			}
			else if (resourceInfoResult.Resources.Count > 1)
			{
				closeDialog();
				string errorMessage3 = "Unable to determine if the planetary system exists on the server. Check resources returned more than one result.";
				yield return Game.Instance.UserInterface.CreateErrorDialog(errorMessage3).WaitForResult();
			}
			else if (!resourceInfoResult.Resources[0].Exists)
			{
				closeDialog();
				string errorMessage4 = "Unable to proceed. The current planetary system and its celestial bodies must be uploaded to the website first.";
				yield return Game.Instance.UserInterface.CreateErrorDialog(errorMessage4).WaitForResult();
			}
		}
	}
}
