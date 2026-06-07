using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class Utils
	{
		public static string[] WindowsImageSequenceFormatNames;

		public static string[] MacOSImageSequenceFormatNames;

		public static string[] IOSImageSequenceFormatNames;

		public static string[] AndroidImageSequenceFormatNames;

		public static string[] GetNativeImageSequenceFormatNames()
		{
			return null;
		}

		public static bool HasAlphaChannel(RenderTextureFormat format)
		{
			return false;
		}

		public static RenderTextureFormat GetBestRenderTextureFormat(bool supportHDR, bool supportTransparency, bool favourSpeedOverQuality)
		{
			return default(RenderTextureFormat);
		}

		public static Camera GetUltimateRenderCamera()
		{
			return null;
		}

		public static bool HasContributingCameras(Camera parentCamera)
		{
			return false;
		}

		public static Camera[] FindContributingCameras(Camera parentCamera)
		{
			return null;
		}

		private static string URLEscapePathByPercentEncoding(string path)
		{
			return null;
		}

		public static bool ShowInExplorer(string itemPath)
		{
			return false;
		}

		public static bool OpenInDefaultApp(string itemPath)
		{
			return false;
		}

		public static long GetFileSize(string filename)
		{
			return 0L;
		}

		public static bool DriveFreeBytes(string folderName, out ulong freeSpace)
		{
			freeSpace = default(ulong);
			return false;
		}

		public static string GetImageFileExtension(ImageSequenceFormat format)
		{
			return null;
		}
	}
}
