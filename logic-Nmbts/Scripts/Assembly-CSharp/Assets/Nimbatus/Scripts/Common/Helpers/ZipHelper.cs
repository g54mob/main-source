using System.IO;
using Ionic.Zip;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class ZipHelper
	{
		public static void CompressFolder(string folderpath, string zipPath)
		{
			using (ZipFile zipFile = new ZipFile())
			{
				zipFile.AddDirectory(folderpath);
				zipFile.Save(zipPath);
			}
		}

		public static void ExtractFile(string folderpath, string zipPath)
		{
			using (ZipFile zipFile = new ZipFile())
			{
				zipFile.AddDirectory(folderpath);
				zipFile.Save(zipPath);
			}
		}

		public static void ExtractZipFile(string zipPath, string outFolder)
		{
			using (ZipFile zipFile = ZipFile.Read(zipPath))
			{
				foreach (ZipEntry item in zipFile)
				{
					string path = Path.Combine(outFolder, item.FileName);
					if (!File.Exists(path) || !(File.GetLastWriteTimeUtc(path) > item.LastModified.ToUniversalTime()))
					{
						item.Extract(outFolder, ExtractExistingFileAction.OverwriteSilently);
					}
				}
			}
		}
	}
}
