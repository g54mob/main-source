using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ModApi.CelestialData;
using Unity.IO.Compression;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.Upload
{
	public abstract class UploadCelestialContentViewModel : UploadContentViewModel
	{
		protected class FileToUpload
		{
			public CelestialFile CelestialFile { get; }

			public string FileName { get; private set; }

			public bool IsCompressed { get; private set; }

			public long OriginalFileSile { get; private set; }

			public string PreparedFilePath { get; private set; }

			public long PreparedFileSize { get; private set; }

			public FileToUpload(CelestialFile file, string fileName)
			{
				CelestialFile = file;
				FileName = fileName;
			}

			public void Prepare()
			{
				PreparedFilePath = CelestialFile.Path.FullPath;
				PreparedFileSize = new FileInfo(PreparedFilePath).Length;
				OriginalFileSile = PreparedFileSize;
				if (ShouldCompress())
				{
					string text = Path.Combine(Game.Instance.CelestialDatabase.Paths.GameData.UploadTemp, CelestialFile.Id.ToString());
					long num = Compress(text);
					if (num < OriginalFileSile)
					{
						PreparedFilePath = text;
						PreparedFileSize = num;
						FileName += ".zip";
						IsCompressed = true;
					}
				}
				else if (FileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
				{
					FileName += ".nozip";
				}
			}

			private long Compress(string filePath)
			{
				using (FileStream fileStream = File.OpenRead(CelestialFile.Path.FullPath))
				{
					using FileStream stream = File.Create(filePath);
					using GZipStream destination = new GZipStream(stream, CompressionMode.Compress);
					fileStream.CopyTo(destination, 8192);
				}
				return new FileInfo(filePath).Length;
			}

			private bool ShouldCompress()
			{
				int num = FileName.LastIndexOf('.') + 1;
				if (num > 0 || num < FileName.Length)
				{
					switch (FileName.Substring(num).ToLower())
					{
					case "png":
					case "jpg":
					case "jpeg":
					case "zip":
						return false;
					}
				}
				return true;
			}
		}

		protected List<Action> RollbackActions { get; private set; }

		protected string TempDirectoryPath { get; private set; }

		protected List<CelestialFilePath> TempFilePaths { get; private set; }

		public override IEnumerator PrepareToSend()
		{
			yield return base.PrepareToSend();
			RollbackActions = new List<Action>();
			TempFilePaths = new List<CelestialFilePath>();
			TempDirectoryPath = Game.Instance.CelestialDatabase.Paths.GameData.UploadTemp;
		}

		protected void CleanupTempDirectory()
		{
			try
			{
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				foreach (CelestialFilePath tempFilePath in TempFilePaths)
				{
					CelestialFile file = celestialDatabase.GetFile(tempFilePath);
					if (file != null)
					{
						celestialDatabase.DeleteFile(file, refreshDatabase: true);
					}
				}
				if (Directory.Exists(TempDirectoryPath))
				{
					string[] files = Directory.GetFiles(TempDirectoryPath);
					for (int i = 0; i < files.Length; i++)
					{
						File.Delete(files[i]);
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred cleaning up the celestial files upload temp directory");
				Debug.LogException(exception);
			}
		}

		protected void OnCompleted(UploadContentResult result)
		{
			CleanupTempDirectory();
			if (result.Result != UploadContentResultType.Success)
			{
				foreach (Action rollbackAction in RollbackActions)
				{
					try
					{
						rollbackAction();
					}
					catch (Exception exception)
					{
						Debug.LogError("An error occurred executing a rollback action after an unsuccessful upload attempt.");
						Debug.LogException(exception);
					}
				}
			}
			RollbackActions.Clear();
		}

		protected CelestialFilePath SetupTempCelestialFile(string fileName)
		{
			CelestialFilePath celestialFilePath = CelestialFilePath.FromFullPath(Path.Combine(TempDirectoryPath, fileName));
			if (!Directory.Exists(TempDirectoryPath))
			{
				Directory.CreateDirectory(TempDirectoryPath);
			}
			TempFilePaths.Add(celestialFilePath);
			return celestialFilePath;
		}
	}
}
