using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace ModIO.Implementation
{
	internal class CompressOperationDirectory : CompressOperationBase
	{
		private string directory;

		public CompressOperationDirectory(string directory, ProgressHandle progressHandle = null)
			: base(progressHandle)
		{
			this.directory = directory;
		}

		public override async Task<ResultAnd<MemoryStream>> Compress()
		{
			Logger.Log(LogLevel.Verbose, "COMPRESS STARTED [" + directory + "]");
			ResultAnd<MemoryStream> resultAnd = new ResultAnd<MemoryStream>
			{
				value = new MemoryStream()
			};
			using (ZipOutputStream zipStream = new ZipOutputStream(resultAnd.value))
			{
				zipStream.SetLevel(3);
				int folderOffset = directory.TrimEnd('/', '\\').Length;
				IEnumerable<ResultAnd<ModIOFileStream>> enumerable = DataStorage.IterateFilesInDirectory(directory);
				foreach (ResultAnd<ModIOFileStream> item in enumerable)
				{
					if (item.result.Succeeded() && !cancel && !ModIOUnityImplementation.shuttingDown)
					{
						using (item.value)
						{
							string entryName = GetEntryName(folderOffset, item);
							await CompressStream(entryName, item.value, zipStream);
						}
						continue;
					}
					Logger.Log(LogLevel.Error, cancel ? "Cancelled compress operation" : ("Failed to compress files at directory: " + $"{directory}\nResult[{item.result.code}])"));
					return Abort(resultAnd, directory);
				}
				if (cancel || ModIOUnityImplementation.shuttingDown)
				{
					return Abort(resultAnd, directory);
				}
				resultAnd.result = ResultBuilder.Success;
				zipStream.IsStreamOwner = false;
			}
			Logger.Log(LogLevel.Verbose, $"COMPRESSED [{resultAnd.result.code}] {directory}");
			resultAnd.result = ResultBuilder.Success;
			return resultAnd;
		}

		private static string GetEntryName(int folderOffset, ResultAnd<ModIOFileStream> dir)
		{
			return dir.value.FilePath.Substring(folderOffset).Trim('/', '\\');
		}
	}
}
