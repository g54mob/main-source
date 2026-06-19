using System;
using System.IO;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace ModIO.Implementation
{
	internal class ExtractOperation : IModIOZipOperation, IDisposable
	{
		public bool cancel;

		public long modId;

		public long fileId;

		public ProgressHandle progressHandle;

		Task IModIOZipOperation.GetOperation()
		{
			return null;
		}

		public ExtractOperation(long modId, long fileId, ProgressHandle progressHandle = null)
		{
			this.modId = modId;
			this.fileId = fileId;
			this.progressHandle = progressHandle;
		}

		public async Task<Result> Extract()
		{
			return await DataStorage.taskRunner.AddTask(TaskPriority.HIGH, 1, async () => await ExtractAll(), useSeparateThread: true);
		}

		private async Task<Result> ExtractAll()
		{
			Logger.Log(LogLevel.Verbose, $"EXTRACTING [{modId}_{fileId}]");
			Result result = await IsThereEnoughSpaceForExtracting();
			if (!result.Succeeded())
			{
				return result;
			}
			using (Stream fileStream = DataStorage.OpenArchiveReadStream(modId, fileId, out result))
			{
				if (result.Succeeded())
				{
					try
					{
						long max = fileStream.Length;
						using ZipInputStream stream = new ZipInputStream(fileStream);
						stream.IsStreamOwner = false;
						ZipEntry nextEntry;
						while ((nextEntry = stream.GetNextEntry()) != null)
						{
							if (string.IsNullOrEmpty(nextEntry.Name) || nextEntry.Name.Contains("__MACOSX") || nextEntry.IsDirectory)
							{
								continue;
							}
							using (Stream streamWriter = DataStorage.OpenArchiveEntryOutputStream(nextEntry.Name, out result))
							{
								if (result.Succeeded())
								{
									byte[] data = new byte[1048760];
									while (true)
									{
										if (cancel || ModIOUnityImplementation.shuttingDown)
										{
											cancel = true;
											break;
										}
										int num = await stream.ReadAsync(data, 0, data.Length);
										if (num <= 0)
										{
											break;
										}
										await streamWriter.WriteAsync(data, 0, num);
										if (progressHandle != null)
										{
											progressHandle.Progress = (float)stream.Position / (float)max;
										}
									}
									continue;
								}
								cancel = true;
							}
							break;
						}
					}
					catch (Exception ex)
					{
						Logger.Log(LogLevel.Error, $"Unhandled exception extracting file. MODFILE [{modId}_{fileId}. Exception: {ex.Message}");
						cancel = true;
					}
				}
			}
			if (!cancel)
			{
				try
				{
					result = DataStorage.MakeInstallationFromExtractionDirectory(modId, fileId);
					if (!result.Succeeded())
					{
						cancel = true;
					}
				}
				catch (Exception ex2)
				{
					Logger.Log(LogLevel.Error, $"Unhandled exception extracting file. MODFILE [{modId}_{fileId}. Exception: {ex2.Message}");
					cancel = true;
				}
			}
			if (cancel)
			{
				return CancelAndCleanup(result);
			}
			Logger.Log(LogLevel.Verbose, $"EXTRACTED RESULT [{result.code}] MODFILE [{modId}_{fileId}]");
			return result;
		}

		private Result CancelAndCleanup(Result result)
		{
			Logger.Log(LogLevel.Verbose, $"FAILED EXTRACTION [{result.code}] MODFILE [{modId}_{fileId}]");
			DataStorage.TryDeleteInstalledMod(modId, fileId, out result);
			if (result.code == 1 || result.code == 0)
			{
				result = ResultBuilder.Create(20506u);
			}
			return result;
		}

		private async Task<Result> IsThereEnoughSpaceForExtracting()
		{
			Result result;
			using Stream fileStream = DataStorage.OpenArchiveReadStream(modId, fileId, out result);
			if (result.Succeeded())
			{
				try
				{
					using ZipInputStream stream = new ZipInputStream(fileStream);
					long uncompressedSize = 0L;
					ZipEntry nextEntry;
					while ((nextEntry = stream.GetNextEntry()) != null)
					{
						if (nextEntry.Size == -1)
						{
							Logger.Log(LogLevel.Verbose, "Size Unknown for file in zip (" + nextEntry.Name + ").");
						}
						else
						{
							uncompressedSize += nextEntry.Size;
						}
					}
					bool flag = !(await DataStorage.persistent.IsThereEnoughDiskSpaceFor(uncompressedSize));
					if (!flag)
					{
						flag = !(await DataStorage.temp.IsThereEnoughDiskSpaceFor(uncompressedSize));
					}
					if (flag)
					{
						return ResultBuilder.Create(20442u);
					}
					return ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Error, $"Unhandled exception trying to read archive's extract size. MODFILE [{modId}_{fileId}. Exception: {ex.Message}");
					return ResultBuilder.Create(20405u);
				}
			}
			Logger.Log(LogLevel.Error, $"Unable to read archive file. MODFILE [{modId}_{fileId}. Result: [{result.code}]{ResultCode.GetErrorCodeMeaning(result.code)}");
			return ResultBuilder.Create(20405u);
		}

		void IModIOZipOperation.Cancel()
		{
			cancel = true;
		}

		public void Dispose()
		{
		}
	}
}
