using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using UnityEngine;

namespace ModIO.Implementation.Platform
{
	internal static class SystemIOWrapper
	{
		private static HashSet<string> currentlyOpenFiles = new HashSet<string>();

		public static ModIOFileStream OpenReadStream(string filePath, out Result result)
		{
			ModIOFileStream result2 = null;
			result = ResultBuilder.Unknown;
			if (IsPathValid(filePath, out result) && FileExists(filePath, out result))
			{
				FileStream fileStream = null;
				try
				{
					fileStream = File.Open(filePath, FileMode.Open);
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to create read FileStream.\n.path=" + filePath + "\n.Exception:" + ex.Message);
					fileStream = null;
					result = ResultBuilder.Create(20405u);
				}
				result2 = new FileStreamWrapper(fileStream);
			}
			Logger.Log(LogLevel.Verbose, $"Create read FileStream: {filePath} - Result: [{result.code}]");
			return result2;
		}

		public static ModIOFileStream OpenWriteStream(string filePath, out Result result)
		{
			ModIOFileStream result2 = null;
			result = ResultBuilder.Unknown;
			if (IsPathValid(filePath, out result) && TryCreateParentDirectory(filePath, out result))
			{
				FileStream fileStream = null;
				try
				{
					fileStream = File.Open(filePath, FileMode.Create);
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to create write FileStream.\n.path=" + filePath + "\n.Exception:" + ex.Message);
					fileStream = null;
					result = ResultBuilder.Create(20403u);
				}
				result2 = new FileStreamWrapper(fileStream);
			}
			Logger.Log(LogLevel.Verbose, $"Create write FileStream: {filePath} - Result: [{result.code}]");
			return result2;
		}

		public static async Task<ResultAnd<byte[]>> ReadFileAsync(string filePath)
		{
			byte[] data = null;
			if (currentlyOpenFiles.Contains(filePath))
			{
				return ResultAnd.Create(ResultBuilder.Create(20440u), data);
			}
			currentlyOpenFiles.Add(filePath);
			if (IsPathValid(filePath, out var result) && DoesFileExist(filePath, out result))
			{
				try
				{
					using (FileStream sourceStream = File.Open(filePath, FileMode.Open))
					{
						data = new byte[sourceStream.Length];
						await sourceStream.ReadAsync(data, 0, (int)sourceStream.Length);
					}
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to read the file.\n.path=" + filePath + "\n.Exception:" + ex.Message);
					result = ResultBuilder.Create(20405u);
				}
			}
			Logger.Log(LogLevel.Verbose, string.Format("Read file: {0} - Result: [{1}] - Data: {2}", filePath, result.code, (data == null) ? "NULL" : (data.Length + "B")));
			currentlyOpenFiles.Remove(filePath);
			return ResultAnd.Create(result, data);
		}

		public static ResultAnd<byte[]> ReadFile(string filePath)
		{
			byte[] array = null;
			if (currentlyOpenFiles.Contains(filePath))
			{
				return ResultAnd.Create(ResultBuilder.Create(20440u), array);
			}
			currentlyOpenFiles.Add(filePath);
			if (IsPathValid(filePath, out var result) && DoesFileExist(filePath, out result))
			{
				try
				{
					using (FileStream fileStream = File.Open(filePath, FileMode.Open))
					{
						array = new byte[fileStream.Length];
						fileStream.Read(array, 0, (int)fileStream.Length);
					}
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to read the file.\n.path=" + filePath + "\n.Exception:" + ex.Message);
					result = ResultBuilder.Create(20405u);
				}
			}
			Logger.Log(LogLevel.Verbose, string.Format("Read file: {0} - Result: [{1}] - Data: {2}", filePath, result.code, (array == null) ? "NULL" : (array.Length + "B")));
			currentlyOpenFiles.Remove(filePath);
			return ResultAnd.Create(result, array);
		}

		public static async Task<Result> WriteFileAsync(string filePath, byte[] data)
		{
			Result result = ResultBuilder.Success;
			if (data == null)
			{
				Logger.Log(LogLevel.Verbose, "Was not given any data to write. Cancelling write operation.\n.path=" + filePath);
				return result;
			}
			if (currentlyOpenFiles.Contains(filePath))
			{
				return ResultBuilder.Create(20440u);
			}
			currentlyOpenFiles.Add(filePath);
			if (IsPathValid(filePath, out result) && TryCreateParentDirectory(filePath, out result))
			{
				try
				{
					using (FileStream fileStream = File.Open(filePath, FileMode.Create))
					{
						fileStream.Position = 0L;
						await fileStream.WriteAsync(data, 0, data.Length);
					}
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Error, "Unhandled error when attempting to write the file.\n.path=" + filePath + "\n.Exception:" + ex.Message);
					result = ResultBuilder.Create(20406u);
				}
			}
			Logger.Log(LogLevel.Verbose, $"Write file: {filePath} - Result: [{result.code}]");
			currentlyOpenFiles.Remove(filePath);
			return result;
		}

		public static Result WriteFile(string filePath, byte[] data)
		{
			Result result = ResultBuilder.Success;
			if (data == null)
			{
				Logger.Log(LogLevel.Verbose, "Was not given any data to write. Cancelling write operation.\n.path=" + filePath);
				return result;
			}
			if (currentlyOpenFiles.Contains(filePath))
			{
				return ResultBuilder.Create(20440u);
			}
			currentlyOpenFiles.Add(filePath);
			if (IsPathValid(filePath, out result) && TryCreateParentDirectory(filePath, out result))
			{
				try
				{
					using (FileStream fileStream = File.Open(filePath, FileMode.Create))
					{
						fileStream.Position = 0L;
						fileStream.Write(data, 0, data.Length);
					}
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Error, "Unhandled error when attempting to write the file.\n.path=" + filePath + "\n.Exception:" + ex.Message);
					result = ResultBuilder.Create(20406u);
				}
			}
			Logger.Log(LogLevel.Verbose, $"Write file: {filePath} - Result: [{result.code}]");
			currentlyOpenFiles.Remove(filePath);
			return result;
		}

		public static Result CreateDirectory(string directoryPath)
		{
			if (IsPathValid(directoryPath, out var result) && !DirectoryExists(directoryPath))
			{
				try
				{
					Directory.CreateDirectory(directoryPath);
					return ResultBuilder.Success;
				}
				catch (UnauthorizedAccessException ex)
				{
					Logger.Log(LogLevel.Verbose, "UnauthorizedAccessException when attempting to create directory.\n.path=" + directoryPath + "\n.Exception:" + ex.Message);
					return ResultBuilder.Create(20440u);
				}
				catch (Exception ex2)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to create the directory.\n.path=" + directoryPath + "\n.Exception:" + ex2.Message);
					return ResultBuilder.Create(20421u);
				}
			}
			return result;
		}

		public static Result DeleteDirectory(string path)
		{
			if (IsPathValid(path, out var result))
			{
				try
				{
					if (Directory.Exists(path))
					{
						Directory.Delete(path, recursive: true);
					}
					return ResultBuilder.Success;
				}
				catch (IOException ex)
				{
					Logger.Log(LogLevel.Verbose, "IOException when attempting to delete directory.\n.path=" + path + "\n.Exception:" + ex.Message);
					return ResultBuilder.Create(20440u);
				}
				catch (UnauthorizedAccessException ex2)
				{
					Logger.Log(LogLevel.Verbose, "UnauthorizedAccessException when attempting to delete directory.\n.path=" + path + "\n.Exception:" + ex2.Message);
					return ResultBuilder.Create(20440u);
				}
				catch (Exception ex3)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to create the directory.\n.path=" + path + "\n.Exception:" + ex3.Message);
					return ResultBuilder.Create(20422u);
				}
			}
			return result;
		}

		public static Result MoveDirectory(string directoryPath, string newDirectoryPath)
		{
			Result result = default(Result);
			try
			{
				Directory.Move(directoryPath, newDirectoryPath);
			}
			catch (IOException ex)
			{
				Logger.Log(LogLevel.Verbose, "IOException when attempting to move directory.\n.path=" + directoryPath + "\n.Exception:" + ex.Message);
				return ResultBuilder.Create(20440u);
			}
			catch (UnauthorizedAccessException ex2)
			{
				Logger.Log(LogLevel.Verbose, "UnauthorizedAccessException when attempting to move directory.\n.path=" + directoryPath + "\n.Exception:" + ex2.Message);
				return ResultBuilder.Create(20440u);
			}
			catch (Exception ex3)
			{
				Logger.Log(LogLevel.Warning, "Unhandled error when attempting to move directory.\n.path=" + directoryPath + "\n.Exception:" + ex3.Message);
				return ResultBuilder.Create(20422u);
			}
			return result;
		}

		public static bool IsPathValid(string filePath, out Result result)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				result = ResultBuilder.Create(20400u);
				return false;
			}
			result = ResultBuilder.Success;
			return true;
		}

		public static bool FileExists(string path, out Result result)
		{
			if (File.Exists(path))
			{
				result = ResultBuilder.Success;
				return true;
			}
			result = ResultBuilder.Create(20401u);
			return false;
		}

		public static Result GetFileSizeAndHash(string filePath, out long fileSize, out string fileHash)
		{
			if (!IsPathValid(filePath, out var result) || !DoesFileExist(filePath, out result))
			{
				fileSize = -1L;
				fileHash = null;
				return result;
			}
			try
			{
				fileSize = new FileInfo(filePath).Length;
			}
			catch (UnauthorizedAccessException ex)
			{
				Logger.Log(LogLevel.Verbose, "UnauthorizedAccessException when attempting to read file size.\n.path=" + filePath + "\n.Exception:" + ex.Message);
				result = ResultBuilder.Create(20440u);
				fileSize = -1L;
				fileHash = null;
				return result;
			}
			catch (Exception ex2)
			{
				Logger.Log(LogLevel.Warning, "Unhandled error when attempting to get file size.\n.path=" + filePath + "\n.Exception:" + ex2.Message);
				fileSize = -1L;
				fileHash = null;
				return ResultBuilder.Create(1u);
			}
			try
			{
				using FileStream data = File.OpenRead(filePath);
				string text = IOUtil.GenerateMD5(data);
				fileHash = text;
			}
			catch (UnauthorizedAccessException ex3)
			{
				Logger.Log(LogLevel.Verbose, "UnauthorizedAccessException when attempting to generate MD5 Hash.\n.path=" + filePath + "\n.Exception:" + ex3.Message);
				fileSize = -1L;
				fileHash = null;
				return ResultBuilder.Create(20440u);
			}
			catch (IOException ex4)
			{
				Logger.Log(LogLevel.Verbose, "IOException when attempting to generate MD5 Hash.\n.path=" + filePath + "\n.Exception:" + ex4.Message);
				fileSize = -1L;
				fileHash = null;
				return ResultBuilder.Create(20405u);
			}
			catch (Exception ex5)
			{
				Logger.Log(LogLevel.Warning, "Unhandled error when attempting to get file hash.\n.path=" + filePath + "\n.Exception:" + ex5.Message);
				fileSize = -1L;
				fileHash = null;
				return ResultBuilder.Create(1u);
			}
			return ResultBuilder.Create(0u);
		}

		public static bool DirectoryExists(string path)
		{
			return Directory.Exists(path);
		}

		public static bool DoesFileExist(string filePath, out Result result)
		{
			if (!File.Exists(filePath))
			{
				result = ResultBuilder.Create(20401u);
				return false;
			}
			result = ResultBuilder.Success;
			return true;
		}

		public static bool TryCreateParentDirectory(string filePath, out Result result)
		{
			string directoryName = Path.GetDirectoryName(filePath);
			if (Directory.Exists(directoryName))
			{
				result = ResultBuilder.Success;
				return true;
			}
			try
			{
				Directory.CreateDirectory(directoryName);
				result = ResultBuilder.Success;
				return true;
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "Unhandled directory creation exception was thrown.\n.dirToCreate=" + directoryName + "\n.exception=" + ex.Message);
				result = ResultBuilder.Create(20421u);
				return false;
			}
		}

		public static ResultAnd<List<string>> ListAllFiles(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
			{
				return ResultAnd.Create<List<string>>(20420u, null);
			}
			try
			{
				List<string> list = new List<string>();
				foreach (string item in Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories))
				{
					list.Add(item);
				}
				return ResultAnd.Create(0u, list);
			}
			catch (PathTooLongException ex)
			{
				Logger.Log(LogLevel.Error, "PathTooLongException when attempting to list directory contents.\n.directoryPath=" + directoryPath + "\n.Exception:" + ex.Message);
				return ResultAnd.Create<List<string>>(20400u, null);
			}
			catch (SecurityException ex2)
			{
				Logger.Log(LogLevel.Error, "SecurityException when attempting to list directory contents.\n.directoryPath=" + directoryPath + "\n.Exception:" + ex2.Message);
				return ResultAnd.Create<List<string>>(20440u, null);
			}
			catch (UnauthorizedAccessException ex3)
			{
				Logger.Log(LogLevel.Error, "UnauthorizedAccessException when attempting to list directory contents.\n.directoryPath=" + directoryPath + "\n.Exception:" + ex3.Message);
				return ResultAnd.Create<List<string>>(20440u, null);
			}
			catch (Exception ex4)
			{
				Logger.Log(LogLevel.Error, "Unhandled Exception when attempting to list directory contents.\n.directoryPath=" + directoryPath + "\n.Exception:" + ex4.Message);
				return ResultAnd.Create<List<string>>(20440u, null);
			}
		}

		public static Result DeleteFileGetResult(string path)
		{
			if (!DeleteFile(path))
			{
				return new Result
				{
					code = 20404u
				};
			}
			return ResultBuilder.Success;
		}

		public static bool DeleteFile(string path)
		{
			try
			{
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				return true;
			}
			catch (Exception arg)
			{
				_ = "[mod.io] Failed to delete file.\nFile: " + path + "\n\n" + $"Exception: {arg}\n\n";
				return false;
			}
		}

		public static bool MoveFile(string source, string destination)
		{
			if (string.IsNullOrEmpty(source))
			{
				Debug.Log("[mod.io] Failed to move file. source is NullOrEmpty.");
				return false;
			}
			if (string.IsNullOrEmpty(destination))
			{
				Debug.Log("[mod.io] Failed to move file. destination is NullOrEmpty.");
				return false;
			}
			if (!DeleteFile(destination))
			{
				return false;
			}
			try
			{
				File.Move(source, destination);
				return true;
			}
			catch (Exception arg)
			{
				_ = "Failed to move file.\nSource File: {source}\nDestination: " + destination + "\n\n" + $"Exception: {arg}\n\n";
				return false;
			}
		}

		public static long GetFileSize(string path)
		{
			if (!File.Exists(path))
			{
				return -1L;
			}
			try
			{
				return new FileInfo(path).Length;
			}
			catch (Exception arg)
			{
				_ = $"[mod.io] Failed to get file size.\nFile: {path}\n\nException {arg}\n\n";
				return -1L;
			}
		}

		public static IList<string> GetFiles(string path, string nameFilter, bool recurseSubdirectories)
		{
			if (!Directory.Exists(path))
			{
				return null;
			}
			SearchOption searchOption = (recurseSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			if (nameFilter == null)
			{
				nameFilter = "*";
			}
			return Directory.GetFiles(path, nameFilter, searchOption);
		}

		public static IList<string> GetDirectories(string path)
		{
			if (!Directory.Exists(path))
			{
				return null;
			}
			try
			{
				return Directory.GetDirectories(path);
			}
			catch (Exception arg)
			{
				_ = "[mod.io] Failed to get directories.\nDirectory: " + path + "\n\n" + $"Exception: {arg}\n\n";
				return null;
			}
		}
	}
}
