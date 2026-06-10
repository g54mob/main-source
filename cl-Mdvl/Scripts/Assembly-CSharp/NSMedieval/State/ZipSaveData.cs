using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Ionic.Zip;
using NSMedieval.Serialization;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.State
{
	public class ZipSaveData
	{
		protected string ZipFileName;

		private ZipFile zip;

		private string customZipFolder = string.Empty;

		private string rootFolderName = string.Empty;

		private Dictionary<string, byte[]> cachedSaveData;

		private bool isCacheOpen;

		private static readonly Type[] TypeArray = new Type[1] { typeof(FVDeserializer) };

		public Dictionary<string, byte[]> CachedSaveData => cachedSaveData;

		protected ZipSaveData(string fileName, string folderName, string rootFolderName)
		{
			if (string.IsNullOrEmpty(rootFolderName))
			{
				rootFolderName = GlobalSaveController.GetDefaultSaveFolder();
			}
			SetZipFileName(fileName, folderName, rootFolderName);
		}

		protected ZipSaveData(Dictionary<string, byte[]> cachedSaveData)
		{
			this.cachedSaveData = cachedSaveData;
		}

		protected bool SavFileExists()
		{
			if (string.IsNullOrEmpty(ZipFileName))
			{
				return false;
			}
			return File.Exists(ZipFileName);
		}

		protected void SetZipFileName(string fileName, string folderName, string rootFolderName)
		{
			if (string.IsNullOrEmpty(rootFolderName))
			{
				Log.Error("SetZipFilename: rootDirectory is null or empty, this should never happen.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				rootFolderName = Application.persistentDataPath;
			}
			if (!this.rootFolderName.Equals(rootFolderName))
			{
				this.rootFolderName = rootFolderName;
			}
			if (!fileName.EndsWith(".sav"))
			{
				fileName += ".sav";
			}
			ZipFileName = Path.Combine(rootFolderName, folderName ?? string.Empty, fileName).Replace('\\', '/');
		}

		protected void ZipChangeFileName(string fileName, string folderName)
		{
			SetZipFileName(fileName, folderName, rootFolderName);
			if (zip != null)
			{
				ZipClose();
			}
		}

		public void SetCustomZipFolder(string customZipFolder)
		{
			if (!string.IsNullOrEmpty(customZipFolder))
			{
				this.customZipFolder = customZipFolder;
				if (!this.customZipFolder.EndsWith("/"))
				{
					this.customZipFolder += "/";
				}
			}
		}

		public void ResetCustomZipFolder()
		{
			customZipFolder = string.Empty;
		}

		public void ZipOpen()
		{
			if (zip != null)
			{
				return;
			}
			bool isEnabled;
			if (File.Exists(ZipFileName) && ZipFile.IsZipFile(ZipFileName))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Zip: Opening existing save: ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(ZipFileName));
				}
				Log.Debug(messageBuilder);
				zip = ZipFile.Read(ZipFileName);
				zip.ParallelDeflateThreshold = -1L;
				SetTempFolder();
			}
			else
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Zip: Creating new save: ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(ZipFileName));
				}
				Log.Debug(messageBuilder);
				zip = new ZipFile();
				zip.ParallelDeflateThreshold = -1L;
				SetTempFolder();
			}
		}

		private void SetTempFolder()
		{
			try
			{
				zip.TempFileFolder = Application.temporaryCachePath;
			}
			catch (Exception)
			{
				zip.TempFileFolder = null;
			}
		}

		public bool IsZipOpen()
		{
			return zip != null;
		}

		public void ZipClose()
		{
			if (zip != null)
			{
				zip.Dispose();
				zip = null;
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipClose: closed file successfully: ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(ZipFileName));
				}
				Log.Debug(messageBuilder);
			}
		}

		public bool ZipSave()
		{
			DebugTimer.StartTimer("ZipSave");
			bool result = true;
			bool isEnabled;
			try
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipSave: writing file: ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(ZipFileName));
				}
				Log.Debug(messageBuilder);
				bool flag = File.Exists(ZipFileName);
				string outFilename = (flag ? (ZipFileName + ".tmp") : ZipFileName);
				FileUtils.SafeFileOperation(delegate
				{
					WriteSave(outFilename);
				});
				try
				{
					if (flag)
					{
						File.Delete(ZipFileName);
						new FileInfo(outFilename).MoveTo(ZipFileName);
					}
				}
				catch (Exception ex)
				{
					FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Error during deleting old save or renaming new. Error: ");
						messageBuilder2.AppendFormatted(ex.Message);
					}
					Log.Info(messageBuilder2);
				}
			}
			catch (Exception ex2)
			{
				result = false;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipSave: error writing file\n");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(ex2.ToString()));
				}
				Log.Debug(messageBuilder);
				FVLogWarningInterpolationHandler messageBuilder3 = new FVLogWarningInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder3.AppendLiteral("Cannot save file. Exception: ");
					messageBuilder3.AppendFormatted(ex2.Message);
				}
				Log.Warning(messageBuilder3);
				ZipClose();
			}
			DebugTimer.EndTimer("ZipSave");
			return result;
			void WriteSave(string filename)
			{
				using FileStream fileStream = File.Open(filename, FileMode.OpenOrCreate);
				try
				{
					zip.Save(fileStream);
					ZipClose();
					fileStream.Dispose();
				}
				catch (Exception)
				{
					ZipClose();
					fileStream.Dispose();
					throw;
				}
			}
		}

		public bool ZipContains(string filenameInZip)
		{
			if (zip != null)
			{
				return zip.ContainsEntry(filenameInZip);
			}
			return false;
		}

		public MemoryStream ZipReadStream(string filenameInZip)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadStream: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return null;
			}
			string text = customZipFolder + filenameInZip;
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!zip.ContainsEntry(text))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipReadStream: file ");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral(" not found in zip.");
				}
				Log.Debug(messageBuilder);
				return null;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadStream: reading file ");
				messageBuilder.AppendFormatted(text);
				messageBuilder.AppendLiteral(" from zip");
			}
			Log.Debug(messageBuilder);
			MemoryStream memoryStream = new MemoryStream();
			zip[text].Extract(memoryStream);
			return memoryStream;
		}

		public byte[] ZipReadBytes(string filenameInZip)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadBytes: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return null;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!zip.ContainsEntry(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipReadBytes: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in zip.");
				}
				Log.Debug(messageBuilder);
				return null;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadBytes: reading file ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(" .");
			}
			Log.Debug(messageBuilder);
			using MemoryStream memoryStream = ZipReadStream(filenameInZip);
			return memoryStream.ToArray();
		}

		public string ZipReadText(string filenameInZip)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadText: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return null;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!zip.ContainsEntry(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipReadText: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in zip.");
				}
				Log.Debug(messageBuilder);
				return null;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadText: reading file ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(" .");
			}
			Log.Debug(messageBuilder);
			using MemoryStream memoryStream = ZipReadStream(filenameInZip);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			using StreamReader streamReader = new StreamReader(memoryStream);
			return streamReader.ReadToEnd();
		}

		public T ZipReadCustomBin<T>(string filenameInZip, string objectReferences)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadCustomBin: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return default(T);
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!zip.ContainsEntry(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipReadCustomBin: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in zip.");
				}
				Log.Debug(messageBuilder);
				return default(T);
			}
			messageBuilder = new FVLogDebugInterpolationHandler(48, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadCustomBin: Reading object of type ");
				messageBuilder.AppendFormatted(typeof(T).Name);
				messageBuilder.AppendLiteral(" from ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
			byte[] data = ZipReadBytes(filenameInZip);
			FVDeserializer fVDeserializer = new FVDeserializer(filenameInZip, data);
			fVDeserializer.ReadReferences(ZipReadBytes(objectReferences));
			ConstructorInfo constructor = typeof(T).GetConstructor(TypeArray);
			if (constructor == null)
			{
				throw new InvalidOperationException("Type " + typeof(T).Name + " does not have a constructor that takes an FVDeserializer.");
			}
			return (T)constructor.Invoke(new object[1] { fVDeserializer });
		}

		public T ZipReadCustomBinMultiFile<T>(string filenameInZip, string objectReferences, string[] additionalFiles, bool isSecondSave, bool isTutorial = false)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadCustomBinMultiFile: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return default(T);
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!zip.ContainsEntry(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipReadCustomBinMultiFile: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in zip.");
				}
				Log.Debug(messageBuilder);
				return default(T);
			}
			messageBuilder = new FVLogDebugInterpolationHandler(57, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadCustomBinMultiFile: Reading object of type ");
				messageBuilder.AppendFormatted(typeof(T).Name);
				messageBuilder.AppendLiteral(" from ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
			byte[] data = ZipReadBytes(filenameInZip);
			FVDeserializer fVDeserializer = new FVDeserializer(filenameInZip, data);
			fVDeserializer.AddTempData("isSecondSaveLoading", isSecondSave);
			fVDeserializer.AddTempData("isTutorial", isTutorial);
			fVDeserializer.ReadReferences(ZipReadBytes(objectReferences));
			if (additionalFiles != null && additionalFiles.Length != 0)
			{
				foreach (string text in additionalFiles)
				{
					if (!zip.ContainsEntry(text))
					{
						messageBuilder = new FVLogDebugInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("ZipReadCustomBinMultiFile: file ");
							messageBuilder.AppendFormatted(text);
							messageBuilder.AppendLiteral(" not found in zip.");
						}
						Log.Debug(messageBuilder);
						continue;
					}
					byte[] array = ZipReadBytes(text);
					if (array == null)
					{
						messageBuilder = new FVLogDebugInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("ZipReadCustomBinMultiFile: Error reading ");
							messageBuilder.AppendFormatted(text);
							messageBuilder.AppendLiteral(" inside zip.");
						}
						Log.Debug(messageBuilder);
					}
					else
					{
						fVDeserializer.AddReader(text, array);
					}
				}
			}
			ConstructorInfo constructor = typeof(T).GetConstructor(new Type[1] { typeof(FVDeserializer) });
			if (constructor == null)
			{
				throw new InvalidOperationException("Type " + typeof(T).Name + " does not have a constructor that takes an FVDeserializer.");
			}
			return (T)constructor.Invoke(new object[1] { fVDeserializer });
		}

		public void ZipWriteBytes(string filenameInZip, byte[] data)
		{
			if (zip == null)
			{
				Log.Debug("ZipWriteBytes: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			string text = Path.Combine(customZipFolder, filenameInZip).Replace('\\', '/');
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (zip.ContainsEntry(text))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipWriteBytes: Replacing entry ");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral(" in Zip.");
				}
				Log.Debug(messageBuilder);
				zip.RemoveEntry(text);
			}
			messageBuilder = new FVLogDebugInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipWriteBytes: Adding entry ");
				messageBuilder.AppendFormatted(text);
				messageBuilder.AppendLiteral(" in Zip.");
			}
			Log.Debug(messageBuilder);
			zip.AddEntry(text, data);
		}

		public void ZipWriteText(string filenameInZip, string text)
		{
			if (zip == null)
			{
				Log.Debug("ZipWriteText: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			string text2 = Path.Combine(customZipFolder, filenameInZip).Replace('\\', '/');
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (zip.ContainsEntry(text2))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipWriteText: Replacing entry ");
					messageBuilder.AppendFormatted(text2);
					messageBuilder.AppendLiteral(" in Zip.");
				}
				Log.Debug(messageBuilder);
				zip.RemoveEntry(text2);
			}
			messageBuilder = new FVLogDebugInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipWriteText: Adding entry ");
				messageBuilder.AppendFormatted(text2);
				messageBuilder.AppendLiteral(" in Zip.");
			}
			Log.Debug(messageBuilder);
			zip.AddEntry(text2, text);
		}

		public void ZipWriteCustomBin<T>(string filenameInZip, string objectReferences, T objectToSerialize) where T : IFVSerializable
		{
			if (zip == null)
			{
				Log.Debug("ZipWriteCustomBin: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			FVSerializer fVSerializer = new FVSerializer(filenameInZip);
			objectToSerialize.Serialize(fVSerializer);
			fVSerializer.WriteReferences();
			ZipWriteBytes(objectReferences, fVSerializer.GetReferenceBytes());
			ZipWriteBytes(filenameInZip, fVSerializer.GetBytes());
		}

		public void ZipWriteCustomBinMultiFile<T>(string filenameInZip, string objectReferences, string[] additionalFiles, T objectToSerialize) where T : IFVSerializable
		{
			if (zip == null)
			{
				Log.Debug("ZipWriteCustomBinMultiFile: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			FVSerializer fVSerializer = new FVSerializer(filenameInZip, additionalFiles);
			objectToSerialize.Serialize(fVSerializer);
			fVSerializer.WriteReferences();
			ZipWriteBytes(objectReferences, fVSerializer.GetReferenceBytes());
			ZipWriteBytes(filenameInZip, fVSerializer.GetBytes());
			if (additionalFiles == null)
			{
				return;
			}
			foreach (string text in additionalFiles)
			{
				byte[] bytes = fVSerializer.GetBytes(text);
				if (bytes == null)
				{
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(59, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("ZipWriteCustomBinMultiFile: Error writing ");
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral(" file inside zip.");
					}
					Log.Debug(messageBuilder);
				}
				else
				{
					ZipWriteBytes(text, bytes);
				}
			}
		}

		public void CacheOpen()
		{
			if (cachedSaveData == null)
			{
				cachedSaveData = new Dictionary<string, byte[]>();
			}
			isCacheOpen = true;
		}

		public void CacheClose()
		{
			isCacheOpen = false;
		}

		public bool CacheSave()
		{
			isCacheOpen = false;
			return true;
		}

		public bool HasCache()
		{
			if (cachedSaveData != null)
			{
				return cachedSaveData.Count > 0;
			}
			return false;
		}

		public void CacheWriteCustomBinMultiFile<T>(string filenameInZip, string objectReferences, string[] additionalFiles, T objectToSerialize) where T : IFVSerializable
		{
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheWriteCustomBinMultiFile: cache file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			FVSerializer fVSerializer = new FVSerializer(filenameInZip, additionalFiles);
			objectToSerialize.Serialize(fVSerializer);
			fVSerializer.WriteReferences();
			CacheWriteBytes(objectReferences, fVSerializer.GetReferenceBytes());
			CacheWriteBytes(filenameInZip, fVSerializer.GetBytes());
			if (additionalFiles == null)
			{
				return;
			}
			foreach (string text in additionalFiles)
			{
				byte[] bytes = fVSerializer.GetBytes(text);
				if (bytes == null)
				{
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(59, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("CacheWriteCustomBinMultiFile: Error writing ");
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral(" file to cache.");
					}
					Log.Debug(messageBuilder);
				}
				else
				{
					CacheWriteBytes(text, bytes);
				}
			}
		}

		public void CacheWriteCustomBin<T>(string filenameInZip, string objectReferences, T objectToSerialize) where T : IFVSerializable
		{
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheWriteCustomBin: cache file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			FVSerializer fVSerializer = new FVSerializer(filenameInZip);
			objectToSerialize.Serialize(fVSerializer);
			fVSerializer.WriteReferences();
			CacheWriteBytes(objectReferences, fVSerializer.GetReferenceBytes());
			CacheWriteBytes(filenameInZip, fVSerializer.GetBytes());
		}

		public void CacheWriteBytes(string filenameInZip, byte[] data)
		{
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheWriteBytes: cache file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (cachedSaveData.ContainsKey(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CacheWriteBytes: Replacing entry ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" in cache.");
				}
				Log.Debug(messageBuilder);
				cachedSaveData.Remove(filenameInZip);
			}
			messageBuilder = new FVLogDebugInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("CacheWriteBytes: Adding entry ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(" in cache.");
			}
			Log.Debug(messageBuilder);
			cachedSaveData.Add(filenameInZip, data);
		}

		public void AddCachedSaveData(Dictionary<string, byte[]> cachedSaveData)
		{
			this.cachedSaveData = cachedSaveData;
		}

		protected void WriteCachedSaveDataToZip()
		{
			foreach (KeyValuePair<string, byte[]> cachedSaveDatum in cachedSaveData)
			{
				ZipWriteBytes(cachedSaveDatum.Key, cachedSaveDatum.Value);
			}
		}

		public void ZipReadFolderToCache(string folderName)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadFolderToCache: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("ZipReadFolderToCache: cache file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			for (int i = 0; i < zip.Count; i++)
			{
				ZipEntry zipEntry = zip[i];
				if (!zipEntry.IsDirectory && zipEntry.FileName.StartsWith(folderName))
				{
					cachedSaveData.Add(zipEntry.FileName, ZipReadBytes(zipEntry.FileName));
				}
			}
		}

		public void ZipReadBytesToCache(string filenameInZip)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadBytesToCache: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheWriteBytes: cache file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadBytesToCache: reading file ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(" .");
			}
			Log.Debug(messageBuilder);
			cachedSaveData.Add(filenameInZip, ZipReadBytes(filenameInZip));
		}

		public void ZipReadCustomBinToCache(string filenameInZip, string objectReferences)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadCustomBinToCache: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheWriteBytes: cache file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!zip.ContainsEntry(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipReadCustomBinToCache: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in zip.");
				}
				Log.Debug(messageBuilder);
				return;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadCustomBinToCache: Reading file ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
			cachedSaveData.Add(filenameInZip, ZipReadBytes(filenameInZip));
			messageBuilder = new FVLogDebugInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadCustomBinToCache: Reading file ");
				messageBuilder.AppendFormatted(objectReferences);
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
			cachedSaveData.Add(objectReferences, ZipReadBytes(objectReferences));
		}

		public void ZipReadCustomBinMultiFileToCache(string filenameInZip, string objectReferences, string[] additionalFiles)
		{
			if (zip == null)
			{
				Log.Debug("ZipReadCustomBinMultiFileToCache: zip file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheWriteBytes: cache file is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!zip.ContainsEntry(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ZipReadCustomBinMultiFileToCache: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in zip.");
				}
				Log.Debug(messageBuilder);
				return;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadCustomBinMultiFileToCache: Reading file ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
			cachedSaveData.Add(filenameInZip, ZipReadBytes(filenameInZip));
			messageBuilder = new FVLogDebugInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ZipReadCustomBinMultiFileToCache: Reading file ");
				messageBuilder.AppendFormatted(objectReferences);
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
			cachedSaveData.Add(objectReferences, ZipReadBytes(objectReferences));
			if (additionalFiles == null || additionalFiles.Length == 0)
			{
				return;
			}
			foreach (string text in additionalFiles)
			{
				if (!zip.ContainsEntry(text))
				{
					messageBuilder = new FVLogDebugInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("ZipReadCustomBinMultiFileToCache: file ");
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral(" not found in zip.");
					}
					Log.Debug(messageBuilder);
					continue;
				}
				byte[] array = ZipReadBytes(text);
				if (array == null)
				{
					messageBuilder = new FVLogDebugInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("ZipReadCustomBinMultiFileToCache: Error reading ");
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral(" inside zip.");
					}
					Log.Debug(messageBuilder);
				}
				else
				{
					cachedSaveData.Add(text, array);
				}
			}
		}

		public byte[] CacheReadBytes(string filenameInZip)
		{
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheReadBytes: cache is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return null;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!cachedSaveData.ContainsKey(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CacheReadBytes: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in cache.");
				}
				Log.Debug(messageBuilder);
				return null;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("CacheReadBytes: reading file ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(" .");
			}
			Log.Debug(messageBuilder);
			return cachedSaveData[filenameInZip];
		}

		public T CacheReadCustomBin<T>(string filenameInZip, string objectReferences)
		{
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheReadCustomBin: cache is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return default(T);
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!cachedSaveData.ContainsKey(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CacheReadCustomBin: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in cache.");
				}
				Log.Debug(messageBuilder);
				return default(T);
			}
			messageBuilder = new FVLogDebugInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("CacheReadCustomBin: Reading object of type ");
				messageBuilder.AppendFormatted(typeof(T).Name);
				messageBuilder.AppendLiteral(" from ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
			byte[] data = CacheReadBytes(filenameInZip);
			FVDeserializer fVDeserializer = new FVDeserializer(filenameInZip, data);
			fVDeserializer.ReadReferences(CacheReadBytes(objectReferences));
			ConstructorInfo constructor = typeof(T).GetConstructor(new Type[1] { typeof(FVDeserializer) });
			if (constructor == null)
			{
				throw new InvalidOperationException("Type " + typeof(T).Name + " does not have a constructor that takes an FVDeserializer.");
			}
			return (T)constructor.Invoke(new object[1] { fVDeserializer });
		}

		public T CacheReadCustomBinMultiFile<T>(string filenameInZip, string objectReferences, string[] additionalFiles)
		{
			if (!isCacheOpen || cachedSaveData == null)
			{
				Log.Debug("CacheReadCustomBinMultiFile: cache is not open.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				return default(T);
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (!cachedSaveData.ContainsKey(filenameInZip))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CacheReadCustomBinMultiFile: file ");
					messageBuilder.AppendFormatted(filenameInZip);
					messageBuilder.AppendLiteral(" not found in cache.");
				}
				Log.Debug(messageBuilder);
				return default(T);
			}
			messageBuilder = new FVLogDebugInterpolationHandler(59, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("CacheReadCustomBinMultiFile: Reading object of type ");
				messageBuilder.AppendFormatted(typeof(T).Name);
				messageBuilder.AppendLiteral(" from ");
				messageBuilder.AppendFormatted(filenameInZip);
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
			byte[] data = CacheReadBytes(filenameInZip);
			FVDeserializer fVDeserializer = new FVDeserializer(filenameInZip, data);
			fVDeserializer.AddTempData("isSecondSaveLoading", true);
			fVDeserializer.ReadReferences(CacheReadBytes(objectReferences));
			if (additionalFiles != null && additionalFiles.Length != 0)
			{
				foreach (string text in additionalFiles)
				{
					if (!cachedSaveData.ContainsKey(text))
					{
						messageBuilder = new FVLogDebugInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("CacheReadCustomBinMultiFile: file ");
							messageBuilder.AppendFormatted(text);
							messageBuilder.AppendLiteral(" not found in cache.");
						}
						Log.Debug(messageBuilder);
						continue;
					}
					byte[] array = CacheReadBytes(text);
					if (array == null)
					{
						messageBuilder = new FVLogDebugInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\ZipSaveData.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("CacheReadCustomBinMultiFile: Error reading ");
							messageBuilder.AppendFormatted(text);
							messageBuilder.AppendLiteral(" inside cache.");
						}
						Log.Debug(messageBuilder);
					}
					else
					{
						fVDeserializer.AddReader(text, array);
					}
				}
			}
			ConstructorInfo constructor = typeof(T).GetConstructor(new Type[1] { typeof(FVDeserializer) });
			if (constructor == null)
			{
				throw new InvalidOperationException("Type " + typeof(T).Name + " does not have a constructor that takes an FVDeserializer.");
			}
			return (T)constructor.Invoke(new object[1] { fVDeserializer });
		}
	}
}
