using System;
using System.IO;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;

namespace NSMedieval.Tools
{
	public static class FileUtils
	{
		public delegate T SafeReadDataFromFile<T>(string path);

		public delegate void SafeWriteDataToFile<T>(string path, T data);

		private const int MaxTries = 5;

		private const int WaitFixed = 25;

		private const int WaitAdd = 20;

		public static byte[] SafeReadAllBytes(string path)
		{
			return SafeFileOperation(path, File.ReadAllBytes);
		}

		public static string SafeReadAllText(string path)
		{
			return SafeFileOperation(path, File.ReadAllText);
		}

		public static string[] SafeReadAllLines(string path)
		{
			return SafeFileOperation(path, File.ReadAllLines);
		}

		public static void SafeWriteAllBytes(string path, byte[] data)
		{
			SafeWriteFileOperation(path, File.WriteAllBytes, data);
		}

		public static void SafeWriteAllText(string path, string data)
		{
			SafeWriteFileOperation(path, File.WriteAllText, data);
		}

		public static void SafeWriteAllLines(string path, string[] data)
		{
			SafeWriteFileOperation(path, File.WriteAllLines, data);
		}

		public static void SafeWriteMemoryStream(string zipFilename, MemoryStream ms)
		{
			SafeWriteFileOperation(zipFilename, WriteMemStreamToFile, ms);
		}

		public static void SafeFileOperation(Action action)
		{
			int num = 5;
			int num2 = 25;
			while (num-- >= 0)
			{
				bool isEnabled;
				try
				{
					action();
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("SafeFileOperation<");
						messageBuilder.AppendFormatted(action.Method.Name);
						messageBuilder.AppendLiteral(">: success!");
					}
					Log.Trace(messageBuilder);
					break;
				}
				catch (IOException ex)
				{
					if (ex.Message.StartsWith("Sharing violation"))
					{
						FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(36, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("SafeFileOperation<");
							messageBuilder2.AppendFormatted(action.Method.Name);
							messageBuilder2.AppendLiteral(">: Retrying in ");
							messageBuilder2.AppendFormatted(num2);
							messageBuilder2.AppendLiteral(" ms");
						}
						Log.Debug(messageBuilder2);
						Thread.Sleep(num2);
						num2 += 20;
						if (num == 0)
						{
							messageBuilder2 = new FVLogDebugInterpolationHandler(63, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
							if (isEnabled)
							{
								messageBuilder2.AppendLiteral("SafeFileOperation<");
								messageBuilder2.AppendFormatted(action.Method.Name);
								messageBuilder2.AppendLiteral(">: Failed after ");
								messageBuilder2.AppendFormatted(5);
								messageBuilder2.AppendLiteral(" retries. Throwing exception.");
							}
							Log.Debug(messageBuilder2);
							throw;
						}
						continue;
					}
					throw;
				}
			}
		}

		public static void CopyDirectory(string sourceDir, string destinationDir)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(sourceDir);
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException("Source directory not found: " + directoryInfo.FullName);
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			Directory.CreateDirectory(destinationDir);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string destFileName = Path.Combine(destinationDir, fileInfo.Name);
				fileInfo.CopyTo(destFileName, overwrite: true);
			}
			DirectoryInfo[] array = directories;
			foreach (DirectoryInfo directoryInfo2 in array)
			{
				string destinationDir2 = Path.Combine(destinationDir, directoryInfo2.Name);
				CopyDirectory(directoryInfo2.FullName, destinationDir2);
			}
		}

		private static T SafeFileOperation<T>(string path, SafeReadDataFromFile<T> reader)
		{
			string fileName = Path.GetFileName(path);
			int num = 5;
			int num2 = 25;
			while (num-- > 0)
			{
				bool isEnabled;
				try
				{
					T result = reader(path);
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(37, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("SafeFileOperation<");
						messageBuilder.AppendFormatted(typeof(T));
						messageBuilder.AppendLiteral(">: success reading ");
						messageBuilder.AppendFormatted(fileName);
					}
					Log.Trace(messageBuilder);
					return result;
				}
				catch (Exception ex)
				{
					if (ex is IOException || ex is UnauthorizedAccessException || ex.Message.StartsWith("Sharing violation"))
					{
						FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(50, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("SafeFileOperation<");
							messageBuilder2.AppendFormatted(typeof(T));
							messageBuilder2.AppendLiteral(">: Retrying reading file ");
							messageBuilder2.AppendFormatted(fileName);
							messageBuilder2.AppendLiteral(" in ");
							messageBuilder2.AppendFormatted(num2);
							messageBuilder2.AppendLiteral(" ms");
						}
						Log.Debug(messageBuilder2);
						Thread.Sleep(num2);
						num2 += 20;
					}
					else
					{
						Thread.Sleep(num2);
					}
					if (num == 0)
					{
						FVLogInfoInterpolationHandler messageBuilder3 = new FVLogInfoInterpolationHandler(75, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("SafeFileOperation<");
							messageBuilder3.AppendFormatted(typeof(T));
							messageBuilder3.AppendLiteral(">: Cannot read file ");
							messageBuilder3.AppendFormatted(fileName);
							messageBuilder3.AppendLiteral("  after ");
							messageBuilder3.AppendFormatted(5);
							messageBuilder3.AppendLiteral(" retries. Throwing exception.");
						}
						Log.Info(messageBuilder3);
						throw;
					}
				}
			}
			return default(T);
		}

		private static void SafeWriteFileOperation<T>(string path, SafeWriteDataToFile<T> writer, T data)
		{
			string fileName = Path.GetFileName(path);
			int num = 5;
			int num2 = 25;
			while (num-- > 0)
			{
				bool isEnabled;
				try
				{
					writer(path, data);
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(42, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("SafeWriteFileOperation<");
						messageBuilder.AppendFormatted(typeof(T));
						messageBuilder.AppendLiteral(">: success writing ");
						messageBuilder.AppendFormatted(fileName);
					}
					Log.Trace(messageBuilder);
					break;
				}
				catch (IOException ex)
				{
					if (ex.Message.StartsWith("Sharing violation"))
					{
						FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(55, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("SafeWriteFileOperation<");
							messageBuilder2.AppendFormatted(typeof(T));
							messageBuilder2.AppendLiteral(">: Retrying writing file ");
							messageBuilder2.AppendFormatted(fileName);
							messageBuilder2.AppendLiteral(" in ");
							messageBuilder2.AppendFormatted(num2);
							messageBuilder2.AppendLiteral(" ms");
						}
						Log.Debug(messageBuilder2);
						Thread.Sleep(num2);
						num2 += 20;
						if (num == 0)
						{
							messageBuilder2 = new FVLogDebugInterpolationHandler(81, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
							if (isEnabled)
							{
								messageBuilder2.AppendLiteral("SafeWriteFileOperation<");
								messageBuilder2.AppendFormatted(typeof(T));
								messageBuilder2.AppendLiteral(">: Cannot write file ");
								messageBuilder2.AppendFormatted(fileName);
								messageBuilder2.AppendLiteral("  after ");
								messageBuilder2.AppendFormatted(5);
								messageBuilder2.AppendLiteral(" retries. Throwing exception.");
							}
							Log.Debug(messageBuilder2);
							throw;
						}
						continue;
					}
					throw;
				}
				catch (UnauthorizedAccessException)
				{
					FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(78, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("SafeWriteFileOperation<");
						messageBuilder2.AppendFormatted(typeof(T));
						messageBuilder2.AppendLiteral(">: UnAuthorizedAccessException: Unable to access file ");
						messageBuilder2.AppendFormatted(fileName);
						messageBuilder2.AppendLiteral(".");
					}
					Log.Debug(messageBuilder2);
					Thread.Sleep(num2);
					num2 += 20;
					if (num != 0)
					{
						continue;
					}
					if ((new FileInfo(path).Attributes & FileAttributes.ReadOnly) > (FileAttributes)0)
					{
						messageBuilder2 = new FVLogDebugInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("The file ");
							messageBuilder2.AppendFormatted(fileName);
							messageBuilder2.AppendLiteral(" is read-only.");
						}
						Log.Debug(messageBuilder2);
					}
					messageBuilder2 = new FVLogDebugInterpolationHandler(80, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\FileUtils.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("SafeWriteFileOperation<");
						messageBuilder2.AppendFormatted(typeof(T));
						messageBuilder2.AppendLiteral(">: Cannot write file ");
						messageBuilder2.AppendFormatted(fileName);
						messageBuilder2.AppendLiteral(" after ");
						messageBuilder2.AppendFormatted(5);
						messageBuilder2.AppendLiteral(" retries. Throwing exception.");
					}
					Log.Debug(messageBuilder2);
					throw;
				}
			}
		}

		private static void WriteMemStreamToFile(string path, MemoryStream memoryStream)
		{
			using FileStream destination = File.Create(path);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			memoryStream.CopyTo(destination);
		}
	}
}
