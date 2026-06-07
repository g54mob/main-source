using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.CelestialBody;
using Assets.Scripts.Sharing.Handlers.CelestialDatabase;
using Assets.Scripts.Sharing.Handlers.Common;
using ModApi;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Planet;
using ModApi.PlanetStudio;
using ModApi.Ui;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Ui.Sharing.Upload.CelestialBody
{
	public class UploadCelestialBodyViewModel : UploadCelestialContentViewModel
	{
		public UploadCelestialBodyViewModel()
		{
			base.Title = "Upload Celestial Body";
			base.NameLabel = "Celestial Body Name";
			base.DescriptionLabel = "Celestial Body Description";
			PlanetDataScript planetDataScript = PlanetStudioScript.Instance?.CelestialBodyDesignerScript?.CurrentCelestialBody;
			if (planetDataScript != null)
			{
				base.DefaultName = planetDataScript.Name;
				base.DefaultDescription = planetDataScript.Description;
			}
		}

		public override IEnumerator Upload(UploadContentModel model, UploadProgressedDelegate onUploadProgressed, UploadCompletedDelegate onUploadCompleted)
		{
			OperationResult result = null;
			float currentProgress = 0f;
			Action<UploadContentResult> complete = delegate(UploadContentResult x)
			{
				OnCompleted(x);
				onUploadCompleted(x);
			};
			Action<WebsiteRequest> completeWithRequest = delegate(WebsiteRequest x)
			{
				complete(new UploadContentResult(x));
			};
			Action cancel = delegate
			{
				complete(new UploadContentResult(UploadContentResultType.Canceled, null));
			};
			Action<string> fail = delegate(string x)
			{
				complete(new UploadContentResult(UploadContentResultType.Failure, x));
			};
			Action<UploadContentResultType, string> failWithType = delegate(UploadContentResultType type, string message)
			{
				complete(new UploadContentResult(type, message));
			};
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			CelestialBodyDesignerScript designer = PlanetStudioScript.Instance.CelestialBodyDesignerScript;
			PlanetDataScript body = designer?.CurrentCelestialBody;
			PlanetDataScript loadedBody = designer?.CelestialBodyViewer?.CelestialBodyData;
			if (body == null || loadedBody == null)
			{
				fail("No celestial body is loaded.");
				yield break;
			}
			onUploadProgressed(currentProgress, (float x) => "Saving celestial body...");
			if (designer.LastSaveFilePath == null || !designer.LastSaveFilePath.InUserData)
			{
				yield return designer.SaveCelestialBodyInteractive("The celestial body must be saved before uploading. Please enter a file name to save it.", delegate(OperationResult x)
				{
					result = x;
				});
			}
			else
			{
				result = designer.SaveCelestialBody(designer.LastSaveFilePath.FullPath, useFilePaths: true);
			}
			CelestialFilePath userSavePath = designer.LastSaveFilePath;
			if (result.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!result.IsSuccess)
			{
				fail("An error occurred saving the celestial body: " + result.ErrorMessage);
				yield break;
			}
			CelestialFilePath tempFilePath = SetupTempCelestialFile("__CelestialBodyUpload.xml");
			result = designer.SaveCelestialBody(tempFilePath.FullPath, useFilePaths: false);
			if (!result.IsSuccess)
			{
				fail("An error occurred saving the celestial body: " + result.ErrorMessage);
				yield break;
			}
			onUploadProgressed(currentProgress, (float x) => "Validating credentials...");
			WebsiteRequest validateUserRequest = ValidateClientIdentity.CreateRequest();
			yield return SendWebRequest(validateUserRequest);
			if (validateUserRequest.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!validateUserRequest.Success)
			{
				completeWithRequest(validateUserRequest);
				yield break;
			}
			if (validateUserRequest.Response?.GetValue("Valid") != "true")
			{
				failWithType(UploadContentResultType.ServerFailureForceLogOff, "There was a problem with your login credentials. Please log back in and try again.");
				yield break;
			}
			onUploadProgressed(currentProgress, (float x) => "Generating Images");
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			PlanetCubemapUtility.CreateEquirectangularMap(loadedBody, 1024, 512, 0, loadedBody.EquirectangularMapBrightness * 0.15f, loadedBody.EquirectangularMapLight);
			string fileName = $"Equirectangular_{1024}x{512}.png";
			byte[] array = loadedBody.GeneratedData.LoadFile(fileName);
			if (array == null)
			{
				fail("Unable to generate the equirectangular map for the celestial body.");
				yield break;
			}
			List<BinaryDataUploadContent> additionalBinaryData = new List<BinaryDataUploadContent>
			{
				new BinaryDataUploadContent(array, "PlanetMap_Equirectangular", "PlanetMap_Equirectangular.jpg", BinaryDataUploadContentType.Jpg)
			};
			onUploadProgressed(currentProgress, (float x) => "Determining files to upload...");
			CelestialFile celestialFile = db.GetFile(tempFilePath);
			CelestialBodyFileData celestialBody = db.GetCelestialBody(celestialFile.Id);
			var supportFiles = (from x in celestialBody.SupportFileReferences.Values.Select((CelestialFileReference x) => db.GetFile(x)).DistinctBy((CelestialFile x) => x.Id)
				select new
				{
					Id = (x?.Id ?? Guid.Empty),
					File = x,
					FileName = CelestialFileNameUtility.ToFriendlyFileName(x?.Path, includeExtension: true)
				}).ToList();
			if (supportFiles.Any(x => x.Id == Guid.Empty))
			{
				string text = string.Join(", " + Environment.NewLine, supportFiles.Where(x => x.Id == Guid.Empty));
				fail("Unable to find all support files for the celestial body. " + Environment.NewLine + text);
				yield break;
			}
			List<Guid> requiredIds = supportFiles.Select(x => x.Id).Distinct().ToList();
			requiredIds.Add(celestialFile.Id);
			WebsiteRequest checkResourcesExistRequest = CheckResourcesExist.CreateRequest(requiredIds);
			yield return SendWebRequest(checkResourcesExistRequest);
			if (checkResourcesExistRequest.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!checkResourcesExistRequest.Success)
			{
				completeWithRequest(checkResourcesExistRequest);
				yield break;
			}
			ResourceInfoResult resourceInfoResult = new ResourceInfoResult(checkResourcesExistRequest.Response);
			List<Guid> serverFileIds = (from x in resourceInfoResult.Resources
				where x.Exists
				select Guid.Parse(x.Hash)).ToList();
			if (serverFileIds.Contains(celestialFile.Id))
			{
				fail("The celestial body has already been uploaded.");
				yield break;
			}
			onUploadProgressed(currentProgress, (float x) => "Preparing celestial body...");
			string previousAuthor = body.Author;
			string previousAncestryId = body.ParentAncestryId;
			PlanetDataScript planetDataScript = body;
			string author = (loadedBody.Author = Game.Instance.Settings.UserName);
			planetDataScript.Author = author;
			PlanetDataScript planetDataScript2 = body;
			author = (loadedBody.ParentAncestryId = Guid.NewGuid().ToString());
			planetDataScript2.ParentAncestryId = author;
			base.RollbackActions.Add(delegate
			{
				PlanetDataScript planetDataScript3 = body;
				string author2 = (loadedBody.Author = previousAuthor);
				planetDataScript3.Author = author2;
				PlanetDataScript planetDataScript4 = body;
				author2 = (loadedBody.ParentAncestryId = previousAncestryId);
				planetDataScript4.ParentAncestryId = author2;
			});
			result = designer.SaveCelestialBody(tempFilePath.FullPath, useFilePaths: false);
			if (!result.IsSuccess)
			{
				fail("An error occurred saving the celestial body: " + result.ErrorMessage);
				yield break;
			}
			onUploadProgressed(currentProgress, (float x) => "Querying upload parameters...");
			WebsiteRequest uploadSettingsRequest = GetUploadSettings.CreateRequest();
			yield return SendWebRequest(uploadSettingsRequest);
			if (validateUserRequest.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!validateUserRequest.Success)
			{
				completeWithRequest(validateUserRequest);
				yield break;
			}
			UploadSettingsModel uploadSettingsModel = new UploadSettingsModel(uploadSettingsRequest.Response);
			int uploadMaxIndividualFileSize = uploadSettingsModel.MaxIndividualFileSize;
			int maxTotalFileSize = uploadSettingsModel.MaxTotalFileSize;
			int num = 65536;
			onUploadProgressed(currentProgress, (float x) => "Preparing files to upload...");
			CelestialFile file = db.GetFile(tempFilePath);
			string fileName2 = CelestialFileNameUtility.ToFriendlyFileName(userSavePath, includeExtension: true);
			List<FileToUpload> filesToUpload = (from x in supportFiles
				where !serverFileIds.Contains(x.Id)
				select new FileToUpload(x.File, x.FileName)).ToList();
			filesToUpload.Add(new FileToUpload(file, fileName2));
			long totalFileSize = 0L;
			foreach (FileToUpload item in filesToUpload)
			{
				item.Prepare();
				totalFileSize += item.PreparedFileSize;
			}
			if (filesToUpload.Any((FileToUpload x) => x.PreparedFileSize > uploadMaxIndividualFileSize))
			{
				fail("One or more files are larger than the " + Utilities.FormatMemorySize(uploadMaxIndividualFileSize) + " size limit.");
				yield break;
			}
			if (totalFileSize > maxTotalFileSize)
			{
				fail("The combined upload size is " + Utilities.FormatMemorySize(totalFileSize) + ", which is greater than the  " + Utilities.FormatMemorySize(maxTotalFileSize) + " size limit.");
				yield break;
			}
			if (totalFileSize > num)
			{
				ModApi.Ui.MessageDialogScript uploadSizeDialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				uploadSizeDialog.MessageText = "Total estimated upload size is " + Utilities.FormatMemorySize(totalFileSize);
				uploadSizeDialog.OkayButtonText = "Continue";
				yield return uploadSizeDialog.WaitForResult();
				if (uploadSizeDialog.Result.Value == MessageDialogResult.Cancel)
				{
					cancel();
					yield break;
				}
			}
			Func<float, string> uploadFilesProgressLabel = (float x) => $"Uploading files... {x * 100f:F1}%";
			onUploadProgressed(currentProgress, uploadFilesProgressLabel);
			int i = 0;
			while (i < filesToUpload.Count - 1)
			{
				FileToUpload fileToUpload = filesToUpload[i];
				CreateResourceFileModel model2 = new CreateResourceFileModel
				{
					FileHash = fileToUpload.CelestialFile.Id,
					IsCompressed = fileToUpload.IsCompressed,
					ResourceType = (byte)fileToUpload.CelestialFile.Type,
					UncompressedFileSizeInBytes = (int)fileToUpload.OriginalFileSile
				};
				byte[] data = File.ReadAllBytes(fileToUpload.PreparedFilePath);
				float maxFileProgress = (float)fileToUpload.PreparedFileSize / (float)totalFileSize;
				WebsiteRequest.WebsiteRequestEventHandler progressed = delegate(WebsiteRequest x)
				{
					float num3 = x.Progress * maxFileProgress;
					onUploadProgressed(Mathf.Clamp01(currentProgress + num3), uploadFilesProgressLabel);
				};
				WebsiteRequest uploadResourceRequest = UploadResource.CreateRequest(model2, data, fileToUpload.FileName);
				yield return SendWebRequest(uploadResourceRequest, progressed);
				if (uploadResourceRequest.IsCanceled)
				{
					cancel();
					yield break;
				}
				if (!uploadResourceRequest.Success)
				{
					completeWithRequest(uploadResourceRequest);
					yield break;
				}
				currentProgress = Mathf.Clamp01(currentProgress + maxFileProgress);
				onUploadProgressed(currentProgress, uploadFilesProgressLabel);
				int num2 = i + 1;
				i = num2;
			}
			onUploadProgressed(currentProgress, uploadFilesProgressLabel);
			FileToUpload fileToUpload2 = filesToUpload[filesToUpload.Count - 1];
			WebsiteRequest.WebsiteRequestEventHandler progressed2 = delegate(WebsiteRequest x)
			{
				float num3 = x.Progress * (1f - currentProgress);
				onUploadProgressed(Mathf.Clamp01(currentProgress + num3), uploadFilesProgressLabel);
			};
			CreateResourceFileModel createResourceFileModel = new CreateResourceFileModel
			{
				FileHash = fileToUpload2.CelestialFile.Id,
				IsCompressed = fileToUpload2.IsCompressed,
				ResourceType = (byte)fileToUpload2.CelestialFile.Type,
				UncompressedFileSizeInBytes = (int)fileToUpload2.OriginalFileSile
			};
			createResourceFileModel.RequirementHashes.AddRange(from x in requiredIds.Take(requiredIds.Count - 1)
				select x.ToString());
			WebsiteRequest celestialBodyUploadRequest = CelestialBodyUpload.CreateRequest(model, previousAncestryId, loadedBody, additionalBinaryData, createResourceFileModel, fileToUpload2.PreparedFilePath, fileToUpload2.FileName);
			yield return SendWebRequest(celestialBodyUploadRequest, progressed2);
			if (celestialBodyUploadRequest.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!celestialBodyUploadRequest.Success)
			{
				completeWithRequest(celestialBodyUploadRequest);
				yield break;
			}
			result = designer.SaveCelestialBody(userSavePath.FullPath, useFilePaths: true);
			if (!result.IsSuccess)
			{
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateErrorDialog("The upload succeeded but re-saving the celestial body failed. Successor information may be incorrect if you continue to make changes and upload again.");
				yield return messageDialogScript.WaitForResult();
			}
			completeWithRequest(celestialBodyUploadRequest);
		}
	}
}
