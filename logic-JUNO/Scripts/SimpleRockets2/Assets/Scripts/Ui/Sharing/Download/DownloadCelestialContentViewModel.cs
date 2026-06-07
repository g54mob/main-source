using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Mods;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.CelestialDatabase;
using ModApi.CelestialData;
using ModApi.Mods;
using ModApi.Ui;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Ui.Sharing.Download
{
	public class DownloadCelestialContentViewModel : DownloadContentViewModel
	{
		public class DownloadCelestialContentSuccessful
		{
			private DownloadCelestialContentViewModel _viewModel;

			public Guid? ResourceId { get; }

			public DownloadCelestialContentSuccessful(DownloadCelestialContentViewModel viewModel)
			{
				_viewModel = viewModel;
				ResourceId = viewModel._resourceId;
			}

			public void PromptToLoadPlanetStudio()
			{
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "Download Succeeded. " + Environment.NewLine + Environment.NewLine + "Do you want to load the downloaded item in Planet Studio?";
				messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					d.Close();
					RequiredModsData requiredMods = null;
					Action loadPlanetStudio = delegate
					{
						Game.Instance.SceneManager.LoadPlanetStudio();
					};
					if (ResourceId.HasValue)
					{
						CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
						switch (_viewModel._fileType)
						{
						case CelestialFileType.PlanetarySystem:
						{
							CelestialFile planetarySystem = celestialDatabase.GetFile(ResourceId.Value);
							requiredMods = celestialDatabase.GetPlanetarySystem(planetarySystem.Id).RequiredMods;
							loadPlanetStudio = delegate
							{
								PlanetStudioScript.AutoLoadedPlanetarySystem = planetarySystem;
								Game.Instance.SceneManager.LoadPlanetStudio();
							};
							break;
						}
						case CelestialFileType.CelestialBody:
						{
							CelestialFile celestialBody = Game.Instance.CelestialDatabase.GetFile(ResourceId.Value);
							requiredMods = celestialDatabase.GetCelestialBody(celestialBody.Id).RequiredMods;
							loadPlanetStudio = delegate
							{
								PlanetStudioScript.AutoLoadedCelestialBody = celestialBody;
								Game.Instance.SceneManager.LoadPlanetStudio();
							};
							break;
						}
						}
					}
					else
					{
						Debug.LogError("Unable to determine the resource file ID");
					}
					RequiredModsCheck requiredModsCheck = new RequiredModsCheck(requiredMods);
					if (requiredModsCheck.AllRequirementsMet)
					{
						loadPlanetStudio();
					}
					else
					{
						RequiredModsDialogScript.Create(requiredModsCheck).OkayClicked += delegate
						{
							loadPlanetStudio();
						};
					}
				};
			}

			public void ReloadScene()
			{
				Game.Instance.SceneManager.LoadScene(Game.Instance.SceneManager.CurrentScene);
			}

			public void ShowDownloadSuccessMessage(string message = null)
			{
				Game.Instance.UserInterface.CreateMessageDialog(message ?? "Download Succeeded!");
			}
		}

		private CelestialFileType _fileType;

		private Action<DownloadCelestialContentSuccessful> _onSuccess;

		private string _postId;

		private Guid? _resourceId;

		private bool _skipSizeDialog;

		public DownloadCelestialContentViewModel(string postId, CelestialFileType type, bool skipSizeDialog, Action<DownloadCelestialContentSuccessful> onSuccess)
		{
			_fileType = type;
			_postId = postId;
			_skipSizeDialog = skipSizeDialog;
			_onSuccess = onSuccess;
		}

		public DownloadCelestialContentViewModel(Guid resourceId, CelestialFileType type, bool skipSizeDialog, Action<DownloadCelestialContentSuccessful> onSuccess)
		{
			_fileType = type;
			_resourceId = resourceId;
			_skipSizeDialog = skipSizeDialog;
			_onSuccess = onSuccess;
		}

		public override IEnumerator Download(DownloadProgressedDelegate onProgressed, DownloadCompletedDelegate onCompleted)
		{
			bool downloadFromPost = !_resourceId.HasValue;
			float progress = 0f;
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
			onProgressed(progress, (float x) => "Determining files to download...");
			WebsiteRequest requiredResourcesRequest = (downloadFromPost ? GetRequiredResourcesForPost.CreateRequest(_postId) : GetRequiredResources.CreateRequest(_resourceId.Value));
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
			if (resourceInfoResult.Resources.Count == 0)
			{
				if (downloadFromPost)
				{
					fail("Unable to determine resources required by post '" + _postId + "'");
				}
				else
				{
					fail($"Unable to determine resources required by resource '{_resourceId.Value}'");
				}
				yield break;
			}
			if (downloadFromPost)
			{
				List<ResourceInfoResult.ResourceInfo> list = resourceInfoResult.Resources.Where((ResourceInfoResult.ResourceInfo x) => (CelestialFileType)x.Type == _fileType).ToList();
				_resourceId = ((list.Count == 1) ? new Guid?(Guid.Parse(list[0].Hash)) : ((Guid?)null));
			}
			Action<float> onProgressed2 = delegate(float x)
			{
				onProgressed(x, (float p) => $"Downloading Files... {p * 100f:F1}%");
			};
			yield return DownloadResources(resourceInfoResult.Resources, _resourceId, _skipSizeDialog, onProgressed2, delegate(DownloadContentResult result)
			{
				complete(result);
			});
		}

		public override void OnDownloadSucceeded()
		{
			_onSuccess?.Invoke(new DownloadCelestialContentSuccessful(this));
		}

		protected void OnCompleted(DownloadContentResult result)
		{
			if (result.Result != DownloadContentResultType.Success)
			{
				Game.Instance.CelestialDatabase.RefreshDatabase();
			}
		}
	}
}
