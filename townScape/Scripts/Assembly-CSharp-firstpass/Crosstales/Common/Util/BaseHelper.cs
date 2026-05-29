using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Crosstales.Common.Model.Enum;
using UnityEngine;

namespace Crosstales.Common.Util
{
	public abstract class BaseHelper
	{
		public static readonly CultureInfo BaseCulture;

		protected static readonly Regex cleanSpacesRegex;

		protected static readonly Regex cleanTagsRegex;

		protected static readonly System.Random rnd;

		protected const string file_prefix = "file://";

		public static bool ApplicationIsPlaying;

		private static string applicationDataPath;

		public static bool isInternetAvailable => false;

		public static bool isWindowsPlatform => false;

		public static bool isMacOSPlatform => false;

		public static bool isLinuxPlatform => false;

		public static bool isStandalonePlatform => false;

		public static bool isAndroidPlatform => false;

		public static bool isIOSPlatform => false;

		public static bool isTvOSPlatform => false;

		public static bool isWSAPlatform => false;

		public static bool isXboxOnePlatform => false;

		public static bool isPS4Platform => false;

		public static bool isWebGLPlatform => false;

		public static bool isWebPlatform => false;

		public static bool isWindowsBasedPlatform => false;

		public static bool isWSABasedPlatform => false;

		public static bool isAppleBasedPlatform => false;

		public static bool isIOSBasedPlatform => false;

		public static bool isMobilePlatform => false;

		public static bool isEditor => false;

		public static bool isWindowsEditor => false;

		public static bool isMacOSEditor => false;

		public static bool isLinuxEditor => false;

		public static bool isEditorMode => false;

		public static bool isIL2CPP => false;

		public static Platform CurrentPlatform => default(Platform);

		public static string StreamingAssetsPath => null;

		static BaseHelper()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void initialize()
		{
		}

		public static bool OpenURL(string url)
		{
			return false;
		}

		public static string CreateString(string replaceChars, int stringLength)
		{
			return null;
		}

		public static bool hasActiveClip(AudioSource source)
		{
			return false;
		}

		public static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return false;
		}

		public static string ValidatePath(string path, bool addEndDelimiter = true)
		{
			return null;
		}

		public static string ValidateFile(string path)
		{
			return null;
		}

		public static bool PathHasInvalidChars(string path)
		{
			return false;
		}

		public static bool FileHasInvalidChars(string file)
		{
			return false;
		}

		public static string[] GetFiles(string path, bool isRecursive = false, params string[] extensions)
		{
			return null;
		}

		public static string[] GetDirectories(string path, bool isRecursive = false)
		{
			return null;
		}

		public static string[] GetDrives()
		{
			return null;
		}

		public static string ValidURLFromFilePath(string path)
		{
			return null;
		}

		public static string CleanUrl(string url, bool removeProtocol = true, bool removeWWW = true, bool removeSlash = true)
		{
			return null;
		}

		public static string ClearTags(string text)
		{
			return null;
		}

		public static string ClearSpaces(string text)
		{
			return null;
		}

		public static string ClearLineEndings(string text)
		{
			return null;
		}

		public static List<string> SplitStringToLines(string text, bool ignoreCommentedLines = true, int skipHeaderLines = 0, int skipFooterLines = 0)
		{
			return null;
		}

		public static string FormatBytesToHRF(long bytes, bool useSI = true)
		{
			return null;
		}

		public static string FormatSecondsToHourMinSec(double seconds)
		{
			return null;
		}

		public static string FormatSecondsToHRF(double seconds)
		{
			return null;
		}

		public static Color HSVToRGB(float h, float s, float v, float a = 1f)
		{
			return default(Color);
		}

		public static bool isValidURL(string url)
		{
			return false;
		}

		public static void CopyPath(string sourcePath, string destPath, bool move = false)
		{
		}

		public static void CopyFile(string sourceFile, string destFile, bool move = false)
		{
		}

		public static void ShowPath(string path)
		{
		}

		public static void ShowFile(string file)
		{
		}

		public static void OpenFile(string file)
		{
		}

		public static string getIP(string host)
		{
			return null;
		}

		public static string GenerateLoremIpsum(int length, int minSentences = 1, int maxSentences = int.MaxValue, int minWords = 1, int maxWords = 15)
		{
			return null;
		}

		public static string LanguageToISO639(SystemLanguage language)
		{
			return null;
		}

		public static SystemLanguage ISO639ToLanguage(string isoCode)
		{
			return default(SystemLanguage);
		}

		private static string addLeadingZero(int value)
		{
			return null;
		}

		private static void copyAll(DirectoryInfo source, DirectoryInfo target)
		{
		}

		private static void openURL(string url)
		{
		}
	}
}
