using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Restory.Data.SaveLoad.Providers
{
	public class MonoSaveDataProvider : IJsonSaveDataProvider, ISaveDataProvider, IJsonSaveDataProviderAsync, IBinarySaveDataProviderAsync
	{
		private readonly string rootDirectory;

		private readonly List<IFileTypeReadWriteDataService> readWriteDataServices;

		private readonly IFileReadWriteBinaryDataService readWriteBinaryDataService;

		public MonoSaveDataProvider()
		{
			rootDirectory = Application.persistentDataPath;
			CheckDirectory(rootDirectory);
			readWriteDataServices = new List<IFileTypeReadWriteDataService>
			{
				new JsonReadWriteDataService(),
				new BinReadWriteDataService(),
				new GZipReadWriteDataService()
			};
			readWriteBinaryDataService = new BinaryReadWriteDataService();
		}

		public MonoSaveDataProvider(string directory)
		{
			rootDirectory = directory;
			CheckDirectory(rootDirectory);
			readWriteDataServices = new List<IFileTypeReadWriteDataService>
			{
				new JsonReadWriteDataService(),
				new BinReadWriteDataService(),
				new GZipReadWriteDataService()
			};
			readWriteBinaryDataService = new BinaryReadWriteDataService();
		}

		public void Save(string jsonValue, string subFolderFileName)
		{
			string fullPath = Path.Combine(rootDirectory, subFolderFileName);
			CheckDirectory(fullPath);
			IFileTypeReadWriteDataService fileTypeReadWriteDataService = readWriteDataServices.FirstOrDefault((IFileTypeReadWriteDataService x) => x.IsSupported(fullPath));
			if (fileTypeReadWriteDataService != null)
			{
				fileTypeReadWriteDataService.Write(jsonValue, fullPath);
				return;
			}
			throw new NotSupportedException("Can't write unsupported type");
		}

		public string Load(string subFolderFileName)
		{
			string fullPath = Path.Combine(rootDirectory, subFolderFileName);
			if (!File.Exists(fullPath))
			{
				return null;
			}
			IFileTypeReadWriteDataService fileTypeReadWriteDataService = readWriteDataServices.FirstOrDefault((IFileTypeReadWriteDataService x) => x.IsSupported(fullPath));
			if (fileTypeReadWriteDataService != null)
			{
				return fileTypeReadWriteDataService.Read(fullPath);
			}
			throw new NotSupportedException("Can't read unsupported type");
		}

		public async Task SaveAsync(string jsonValue, string subFolderFileName)
		{
			string fullPath = Path.Combine(rootDirectory, subFolderFileName);
			CheckDirectory(fullPath);
			IFileTypeReadWriteDataService fileTypeReadWriteDataService = readWriteDataServices.FirstOrDefault((IFileTypeReadWriteDataService x) => x.IsSupported(fullPath));
			if (fileTypeReadWriteDataService != null)
			{
				await fileTypeReadWriteDataService.WriteAsync(jsonValue, fullPath);
				return;
			}
			throw new NotSupportedException("Can't write unsupported type");
		}

		public async Task<string> LoadAsync(string subFolderFileName)
		{
			string fullPath = Path.Combine(rootDirectory, subFolderFileName);
			if (!File.Exists(fullPath))
			{
				return null;
			}
			IFileTypeReadWriteDataService fileTypeReadWriteDataService = readWriteDataServices.FirstOrDefault((IFileTypeReadWriteDataService x) => x.IsSupported(fullPath));
			if (fileTypeReadWriteDataService != null)
			{
				return await fileTypeReadWriteDataService.ReadAsync(fullPath);
			}
			throw new NotSupportedException("Can't read unsupported type");
		}

		public async Task SaveBinaryAsync(byte[] binaryData, string subFolderFileName)
		{
			string fullPath = Path.Combine(rootDirectory, subFolderFileName);
			CheckDirectory(fullPath);
			if (readWriteBinaryDataService != null)
			{
				await readWriteBinaryDataService.WriteAsync(binaryData, fullPath);
				return;
			}
			throw new NotSupportedException("Can't write unsupported type");
		}

		public async Task<byte[]> LoadBinaryAsync(string subFolderFileName)
		{
			string text = Path.Combine(rootDirectory, subFolderFileName);
			if (!File.Exists(text))
			{
				return null;
			}
			if (readWriteBinaryDataService != null)
			{
				return await readWriteBinaryDataService.ReadAsync(text);
			}
			throw new NotSupportedException("Can't read unsupported type");
		}

		public void CreateDirectory(string directory)
		{
			try
			{
				if (!Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void CheckDirectory(string fullPath)
		{
			try
			{
				string directoryName = Path.GetDirectoryName(fullPath);
				CreateDirectory(directoryName);
			}
			catch (Exception arg)
			{
				Debug.LogError($"[CheckDirectory]'{fullPath}'\n{arg}");
			}
		}

		public void RemoveDirectory(string subDirectory)
		{
			try
			{
				string path = Path.Combine(rootDirectory, subDirectory);
				if (Directory.Exists(path))
				{
					Directory.Delete(path, recursive: true);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public void RemoveFile(string subDirectory)
		{
			try
			{
				string path = Path.Combine(rootDirectory, subDirectory);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public void CopyDirectory(string sourceSubDirectory, string targetSubDirectory)
		{
			string text = Path.Combine(rootDirectory, sourceSubDirectory);
			CreateDirectory(text);
			DirectoryInfo directoryInfo = new DirectoryInfo(text);
			string text2 = Path.Combine(rootDirectory, targetSubDirectory);
			CreateDirectory(text2);
			DirectoryInfo directoryInfo2 = new DirectoryInfo(text2);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				switch (fileInfo.Extension)
				{
				case ".bank":
				case ".meta":
				case ".vdf":
					continue;
				}
				fileInfo.CopyTo(Path.Combine(directoryInfo2.FullName, fileInfo.Name), overwrite: true);
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo3 in directories)
			{
				DirectoryInfo directoryInfo4 = directoryInfo2.CreateSubdirectory(directoryInfo3.Name);
				CopyDirectory(directoryInfo3.FullName, directoryInfo4.FullName);
			}
		}

		public bool FileExists(string subfolderFilename)
		{
			try
			{
				string path = subfolderFilename;
				if (!subfolderFilename.StartsWith(rootDirectory))
				{
					path = Path.Combine(rootDirectory, subfolderFilename);
				}
				return File.Exists(path);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
		}

		public bool DirectoryExits(string subDirectory)
		{
			try
			{
				return Directory.Exists(Path.Combine(rootDirectory, subDirectory));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
		}

		public string[] GetDirectoryContent(string subDirectory)
		{
			try
			{
				if (!DirectoryExits(subDirectory))
				{
					return Array.Empty<string>();
				}
				return Directory.GetFiles(Path.Combine(rootDirectory, subDirectory));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return Array.Empty<string>();
			}
		}

		public void RenameFile(string oldPathToFile, string newPathToFile)
		{
			try
			{
				string text = Path.Combine(rootDirectory, oldPathToFile);
				string text2 = Path.Combine(rootDirectory, newPathToFile);
				if (FileExists(newPathToFile))
				{
					RemoveFile(newPathToFile);
				}
				if (FileExists(oldPathToFile))
				{
					File.Move(text, text2);
					Debug.Log("File renamed from " + text + " to " + text2);
				}
				else
				{
					Debug.LogWarning("File not found: " + text);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
