using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.CelestialDatabase;
using Assets.Scripts.Sharing.Handlers.Common;
using Assets.Scripts.Sharing.Handlers.PlanetarySystem;
using ModApi;
using ModApi.CelestialData;
using ModApi.Common.Events;
using ModApi.Planet;
using ModApi.PlanetStudio;
using ModApi.Ui;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Ui.Sharing.Upload.PlanetarySystem
{
	public class UploadPlanetarySystemViewModel : UploadCelestialContentViewModel
	{
		private class CelestialBodyInfo
		{
			public string FilePath { get; set; }

			public Guid Id { get; set; }

			public string Name { get; set; }

			public CelestialFile OriginalFile { get; }

			public CelestialBodyInfo(CelestialFile originalFile, string filePath, Guid id, string name)
			{
				OriginalFile = originalFile;
				FilePath = filePath;
				Id = id;
				Name = name;
			}
		}

		private class PlanetarySystemInfo
		{
			public List<CelestialBodyInfo> CelestialBodies { get; private set; }

			public string FilePath { get; set; }

			public Guid Id { get; set; }

			public PlanetarySystemInfo(string filePath, Guid id, IEnumerable<CelestialBodyInfo> celestialBodies)
			{
				FilePath = filePath;
				Id = id;
				CelestialBodies = new List<CelestialBodyInfo>(celestialBodies);
			}
		}

		public UploadPlanetarySystemViewModel()
		{
			base.Title = "Upload Planetary System";
			base.NameLabel = "Planetary System Name";
			base.DescriptionLabel = "Planetary System Description";
			base.PreventTakeScreenshot = true;
			SolarSystemDataScript solarSystemDataScript = PlanetStudioScript.Instance?.PlanetarySystemDesigner?.CurrentPlanetarySystem;
			if (solarSystemDataScript != null)
			{
				base.DefaultName = solarSystemDataScript.Name;
				base.DefaultDescription = solarSystemDataScript.Description;
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
			PlanetarySystemDesignerScript designer = PlanetStudioScript.Instance.PlanetarySystemDesignerScript;
			SolarSystemDataScript planetarySystem = designer?.CurrentPlanetarySystem;
			SolarSystemDataScript loadedPlanetarySystem = designer?.PlanetarySystemViewer?.PlanetarySystemData;
			if (planetarySystem == null || loadedPlanetarySystem == null)
			{
				fail("No planetary system is loaded.");
				yield break;
			}
			List<CelestialFile> supportFiles = new List<CelestialFile>();
			foreach (CelestialFileReference value in loadedPlanetarySystem.FileData.SupportFileReferences.Values)
			{
				CelestialFile file = db.GetFile(value);
				if (file == null)
				{
					fail("Unable to find the support file for the planetary system: " + value.ToString());
					yield break;
				}
				if (!supportFiles.Contains(file))
				{
					supportFiles.Add(file);
				}
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
			onUploadProgressed(currentProgress, (float x) => "Saving planetary system...");
			yield return designer.SavePlanetarySystemInteractive("The planetary system must be saved before uploading. Please enter a file name to save it.", updateSystemNameToMatchFile: false, delegate(OperationResult x)
			{
				result = x;
			});
			CelestialFilePath userSavePath = designer.LastSaveFilePath;
			if (result.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!result.IsSuccess)
			{
				fail("An error occurred saving the planetary system: " + result.ErrorMessage);
				yield break;
			}
			CelestialFilePath tempFilePath = SetupTempCelestialFile("__PlanetarySystemUpload.xml");
			PlanetarySystemInfo planetarySystemInfo = UpdatePlanetarySystemAndCelestialBodiesWithHashBasedReferences(tempFilePath, userSavePath.FullPath);
			onUploadProgressed(currentProgress, (float x) => "Determining files to upload...");
			List<Guid> requiredIds = planetarySystemInfo.CelestialBodies.Select((CelestialBodyInfo x) => x.Id).Distinct().ToList();
			requiredIds.AddRange(supportFiles.Select((CelestialFile x) => x.Id));
			requiredIds.Add(planetarySystemInfo.Id);
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
			if (serverFileIds.Contains(planetarySystemInfo.Id))
			{
				fail("The planetary system has already been uploaded.");
				yield break;
			}
			List<CelestialBodyInfo> celestialBodiesToUpload = new List<CelestialBodyInfo>();
			foreach (CelestialBodyInfo celestialBody in planetarySystemInfo.CelestialBodies)
			{
				if (!serverFileIds.Contains(celestialBody.Id))
				{
					celestialBodiesToUpload.Add(celestialBody);
				}
			}
			if (celestialBodiesToUpload.Count > 0)
			{
				ModApi.Ui.MessageDialogScript d = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				d.MessageText = $"Unable to upload the planetary system because {celestialBodiesToUpload.Count} of the celestial bodies have not yet been uploaded. " + "Would you like to load the next celestial body now so that it can be uploaded?";
				yield return d.WaitForResult();
				if (d.Result.Value == MessageDialogResult.Okay)
				{
					UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
					{
						PlanetStudioScript.AutoLoadedCelestialBody = db.GetFile(celestialBodiesToUpload[0].OriginalFile.Id);
						Game.Instance.SceneManager.LoadPlanetStudio();
					});
				}
				cancel();
				yield break;
			}
			onUploadProgressed(currentProgress, (float x) => "Preparing planetary system...");
			string previousAuthor = planetarySystem.Author;
			string previousAncestryId = planetarySystem.ParentAncestryId;
			SolarSystemDataScript solarSystemDataScript = planetarySystem;
			string author = (loadedPlanetarySystem.Author = Game.Instance.Settings.UserName);
			solarSystemDataScript.Author = author;
			SolarSystemDataScript solarSystemDataScript2 = planetarySystem;
			author = (loadedPlanetarySystem.ParentAncestryId = Guid.NewGuid().ToString());
			solarSystemDataScript2.ParentAncestryId = author;
			base.RollbackActions.Add(delegate
			{
				SolarSystemDataScript solarSystemDataScript3 = planetarySystem;
				string author2 = (loadedPlanetarySystem.Author = previousAuthor);
				solarSystemDataScript3.Author = author2;
				SolarSystemDataScript solarSystemDataScript4 = planetarySystem;
				author2 = (loadedPlanetarySystem.ParentAncestryId = previousAncestryId);
				solarSystemDataScript4.ParentAncestryId = author2;
			});
			UpdatePlanetarySystemInformation(planetarySystemInfo, planetarySystem.Author, planetarySystem.ParentAncestryId);
			Game.Instance.CelestialDatabase.AddOrUpdateFile(CelestialFilePath.FromFullPath(planetarySystemInfo.FilePath), refreshDatabase: true);
			CelestialFile file2 = db.GetFile(tempFilePath);
			if (file2 == null)
			{
				fail("An error occurred trying to upload the planetary system. The celestial file could not be found.");
				yield break;
			}
			onUploadProgressed(currentProgress, (float x) => "Preparing files to upload...");
			List<FileToUpload> filesToUpload = new List<FileToUpload>(from x in supportFiles
				where !serverFileIds.Contains(x.Id)
				select new FileToUpload(x, CelestialFileNameUtility.ToFriendlyFileName(x.Path, includeExtension: true)));
			string fileName = CelestialFileNameUtility.ToFriendlyFileName(userSavePath, includeExtension: true);
			FileToUpload uploadFile = new FileToUpload(file2, fileName);
			filesToUpload.Add(uploadFile);
			long totalFileSize = 0L;
			foreach (FileToUpload item in filesToUpload)
			{
				item.Prepare();
				totalFileSize += item.PreparedFileSize;
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
				ModApi.Ui.MessageDialogScript d = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				d.MessageText = "Total estimated upload size is " + Utilities.FormatMemorySize(uploadFile.PreparedFileSize);
				d.OkayButtonText = "Continue";
				yield return d.WaitForResult();
				if (d.Result.Value == MessageDialogResult.Cancel)
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
			WebsiteRequest.WebsiteRequestEventHandler progressed2 = delegate(WebsiteRequest x)
			{
				float num3 = x.Progress * (1f - currentProgress);
				onUploadProgressed(Mathf.Clamp01(currentProgress + num3), uploadFilesProgressLabel);
			};
			CreateResourceFileModel createResourceFileModel = new CreateResourceFileModel
			{
				FileHash = uploadFile.CelestialFile.Id,
				IsCompressed = uploadFile.IsCompressed,
				ResourceType = (byte)uploadFile.CelestialFile.Type,
				UncompressedFileSizeInBytes = (int)uploadFile.OriginalFileSile
			};
			createResourceFileModel.RequirementHashes.AddRange(from x in requiredIds.Take(requiredIds.Count - 1)
				select x.ToString());
			Dictionary<string, Guid> celestialBodyIds = planetarySystemInfo.CelestialBodies.ToDictionary((CelestialBodyInfo x) => x.Name, (CelestialBodyInfo x) => x.Id);
			WebsiteRequest uploadRequest = PlanetarySystemUpload.CreateRequest(model, previousAncestryId, loadedPlanetarySystem, celestialBodyIds, createResourceFileModel, uploadFile.PreparedFilePath, uploadFile.FileName);
			yield return SendWebRequest(uploadRequest, progressed2);
			if (uploadRequest.IsCanceled)
			{
				cancel();
				yield break;
			}
			if (!uploadRequest.Success)
			{
				completeWithRequest(uploadRequest);
				yield break;
			}
			result = designer.SavePlanetarySystem(userSavePath.FullPath, useFilePaths: true);
			if (!result.IsSuccess)
			{
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateErrorDialog("The upload succeeded but re-saving the planetary system failed. Successor information may be incorrect if you continue to make changes and upload again.");
				yield return messageDialogScript.WaitForResult();
			}
			completeWithRequest(uploadRequest);
		}

		private PlanetarySystemInfo UpdatePlanetarySystemAndCelestialBodiesWithHashBasedReferences(CelestialFilePath tempFilePath, string originalFilePath)
		{
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			List<CelestialBodyInfo> list = new List<CelestialBodyInfo>();
			XDocument xDocument = XDocument.Load(originalFilePath);
			XElement xElement = xDocument.Root.Element("FileReferences");
			if (xElement != null)
			{
				List<CelestialFileReference> list2 = (from x in xElement.Elements("File")
					select CelestialFileReference.LoadFromXml(x)).ToList();
				List<CelestialFileReference> list3 = new List<CelestialFileReference>(list2.Count);
				foreach (CelestialFileReference item in list2)
				{
					CelestialFile file = celestialDatabase.GetFile(item);
					if (file == null)
					{
						throw new Exception("Unable to find file referenced by the planetary system: " + item.ToString());
					}
					if (file.Type == CelestialFileType.CelestialBody)
					{
						XDocument xDocument2 = XDocument.Load(item.FilePath.FullPath);
						XElement xElement2 = xDocument2.Root.Element("FileReferences");
						if (xElement2 != null)
						{
							List<CelestialFileReference> list4 = (from x in xElement2.Elements("File")
								select CelestialFileReference.LoadFromXml(x)).ToList();
							List<CelestialFileReference> list5 = new List<CelestialFileReference>(list4.Count);
							foreach (CelestialFileReference item2 in list4)
							{
								CelestialFile file2 = celestialDatabase.GetFile(item2);
								list5.Add(CelestialFileReference.CreateWithFileId(item2.LocalId, file2.Id));
							}
							xElement2.RemoveAll();
							xElement2.Add(list5.Select((CelestialFileReference x) => x.SaveToXml("File")));
						}
						string text = Path.Combine(base.TempDirectoryPath, Guid.NewGuid().ToString() + ".xml");
						xDocument2.Save(text);
						Guid guid = CelestialFileIdGenerator.GenerateId(CelestialFilePath.FromFullPath(text), CelestialFileType.CelestialBody);
						list3.Add(CelestialFileReference.CreateWithFileId(item.LocalId, guid));
						CelestialBodyFileData celestialBody = celestialDatabase.GetCelestialBody(file.Id);
						if (celestialBody == null)
						{
							throw new Exception($"Unable to find the celestial body with id '{file.Id}'.");
						}
						list.Add(new CelestialBodyInfo(file, text, guid, celestialBody.Name));
					}
					else
					{
						list3.Add(CelestialFileReference.CreateWithFileId(item.LocalId, file.Id));
					}
				}
				xElement.RemoveAll();
				xElement.Add(list3.Select((CelestialFileReference x) => x.SaveToXml("File")));
			}
			string fullPath = tempFilePath.FullPath;
			xDocument.Save(fullPath);
			Guid id = CelestialFileIdGenerator.GenerateId(tempFilePath, CelestialFileType.PlanetarySystem);
			return new PlanetarySystemInfo(fullPath, id, list);
		}

		private void UpdatePlanetarySystemInformation(PlanetarySystemInfo planetarySystem, string author, string parentAncestryId)
		{
			XDocument xDocument = XDocument.Load(planetarySystem.FilePath);
			xDocument.Root.SetAttributeValue("author", author);
			xDocument.Root.SetAttributeValue("parentAncestryId", parentAncestryId);
			xDocument.Save(planetarySystem.FilePath);
			planetarySystem.Id = CelestialFileIdGenerator.GenerateId(CelestialFilePath.FromFullPath(planetarySystem.FilePath), CelestialFileType.PlanetarySystem);
		}
	}
}
