using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Crosstales.Common.Model.Enum;
using UnityEngine;

namespace Crosstales.Common.Util
{
	public abstract class BaseHelper
	{
		public static readonly CultureInfo BaseCulture = new CultureInfo("en-US");

		protected static readonly Regex lineEndingsRegex = new Regex("\\r\\n|\\r|\\n");

		protected static readonly Regex cleanSpacesRegex = new Regex("\\s+");

		protected static readonly Regex cleanTagsRegex = new Regex("<.*?>");

		protected static readonly System.Random rnd = new System.Random();

		protected const string file_prefix = "file://";

		public static bool isInternetAvailable => Application.internetReachability != NetworkReachability.NotReachable;

		public static bool isWindowsPlatform => true;

		public static bool isMacOSPlatform => false;

		public static bool isLinuxPlatform => false;

		public static bool isStandalonePlatform
		{
			get
			{
				if (!isWindowsPlatform && !isMacOSPlatform)
				{
					return isLinuxPlatform;
				}
				return true;
			}
		}

		public static bool isAndroidPlatform => false;

		public static bool isIOSPlatform => false;

		public static bool isTvOSPlatform => false;

		public static bool isWSAPlatform => false;

		public static bool isXboxOnePlatform => false;

		public static bool isPS4Platform => false;

		public static bool isWebGLPlatform => false;

		public static bool isWebPlatform => isWebGLPlatform;

		public static bool isWindowsBasedPlatform
		{
			get
			{
				if (!isWindowsPlatform && !isWSAPlatform)
				{
					return isXboxOnePlatform;
				}
				return true;
			}
		}

		public static bool isWSABasedPlatform
		{
			get
			{
				if (!isWSAPlatform)
				{
					return isXboxOnePlatform;
				}
				return true;
			}
		}

		public static bool isAppleBasedPlatform
		{
			get
			{
				if (!isMacOSPlatform && !isIOSPlatform)
				{
					return isTvOSPlatform;
				}
				return true;
			}
		}

		public static bool isIOSBasedPlatform
		{
			get
			{
				if (!isIOSPlatform)
				{
					return isTvOSPlatform;
				}
				return true;
			}
		}

		public static bool isEditor
		{
			get
			{
				if (!isWindowsEditor && !isMacOSEditor)
				{
					return isLinuxEditor;
				}
				return true;
			}
		}

		public static bool isWindowsEditor => false;

		public static bool isMacOSEditor => false;

		public static bool isLinuxEditor => false;

		public static bool isEditorMode
		{
			get
			{
				if (isEditor)
				{
					return !Application.isPlaying;
				}
				return false;
			}
		}

		public static bool isIL2CPP => false;

		public static Platform CurrentPlatform
		{
			get
			{
				if (isWindowsPlatform)
				{
					return Platform.Windows;
				}
				if (isMacOSPlatform)
				{
					return Platform.OSX;
				}
				if (isLinuxPlatform)
				{
					return Platform.Linux;
				}
				if (isAndroidPlatform)
				{
					return Platform.Android;
				}
				if (isIOSBasedPlatform)
				{
					return Platform.IOS;
				}
				if (isWSABasedPlatform)
				{
					return Platform.WSA;
				}
				if (!isWebPlatform)
				{
					return Platform.Unsupported;
				}
				return Platform.Web;
			}
		}

		public static string StreamingAssetsPath
		{
			get
			{
				if (isAndroidPlatform && !isEditor)
				{
					return "jar:file://" + Application.dataPath + "!/assets/";
				}
				if (isIOSBasedPlatform && !isEditor)
				{
					return Application.dataPath + "/Raw/";
				}
				return Application.dataPath + "/StreamingAssets/";
			}
		}

		public static bool OpenURL(string url)
		{
			if (isValidURL(url))
			{
				Application.OpenURL(url);
				return true;
			}
			UnityEngine.Debug.LogWarning("URL was invalid: " + url);
			return false;
		}

		public static string CreateString(string replaceChars, int stringLength)
		{
			if (replaceChars.Length > 1)
			{
				char[] array = new char[stringLength];
				for (int i = 0; i < stringLength; i++)
				{
					array[i] = replaceChars[rnd.Next(0, replaceChars.Length)];
				}
				return new string(array);
			}
			if (replaceChars.Length != 1)
			{
				return string.Empty;
			}
			return new string(replaceChars[0], stringLength);
		}

		public static bool hasActiveClip(AudioSource source)
		{
			int timeSamples = source.timeSamples;
			if (source != null && source.clip != null)
			{
				if ((source.loop || timeSamples <= 0 || timeSamples >= source.clip.samples - 256) && !source.loop)
				{
					return source.isPlaying;
				}
				return true;
			}
			return false;
		}

		public static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			bool result = true;
			if (sslPolicyErrors != SslPolicyErrors.None)
			{
				foreach (X509ChainStatus item in chain.ChainStatus.Where((X509ChainStatus t) => t.Status != X509ChainStatusFlags.RevocationStatusUnknown))
				{
					_ = item;
					chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
					chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
					chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
					chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
					result = chain.Build((X509Certificate2)certificate);
				}
			}
			return result;
		}

		public static string ValidatePath(string path, bool addEndDelimiter = true)
		{
			if (!string.IsNullOrEmpty(path))
			{
				string text = path.Trim();
				string text2;
				if ((isWindowsBasedPlatform || isWindowsEditor) && !isMacOSEditor && !isLinuxEditor)
				{
					text2 = text.Replace('/', '\\');
					if (addEndDelimiter && !text2.EndsWith("\\"))
					{
						text2 += "\\";
					}
				}
				else
				{
					text2 = text.Replace('\\', '/');
					if (addEndDelimiter && !text2.EndsWith("/"))
					{
						text2 += "/";
					}
				}
				return string.Join(string.Empty, text2.Split(Path.GetInvalidPathChars()));
			}
			return path;
		}

		public static string ValidateFile(string path)
		{
			if (!string.IsNullOrEmpty(path))
			{
				string text = ValidatePath(path);
				if (text.EndsWith("\\") || text.EndsWith("/"))
				{
					text = text.Substring(0, text.Length - 1);
				}
				string text2 = (((!isWindowsBasedPlatform && !isWindowsEditor) || isMacOSEditor || isLinuxEditor) ? text.Substring(text.LastIndexOf("/") + 1) : text.Substring(text.LastIndexOf("\\") + 1));
				string text3 = string.Join(string.Empty, text2.Split(Path.GetInvalidFileNameChars()));
				return text.Substring(0, text.Length - text2.Length) + text3;
			}
			return path;
		}

		public static string[] GetFiles(string path, bool isRecursive = false, params string[] extensions)
		{
			if (isWebPlatform && !isEditor)
			{
				UnityEngine.Debug.LogWarning("'GetFiles' is not supported for the current platform!");
			}
			else if ((!isWSABasedPlatform || isEditor) && !string.IsNullOrEmpty(path))
			{
				try
				{
					string path2 = ValidatePath(path);
					if (extensions == null || extensions.Length == 0 || extensions.Any((string extension) => extension.Equals("*") || extension.Equals("*.*")))
					{
						return Directory.EnumerateFiles(path2, "*", isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToArray();
					}
					List<string> list = new List<string>();
					foreach (string text in extensions)
					{
						list.AddRange(Directory.EnumerateFiles(path2, "*." + text, isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
					}
					return list.OrderBy((string q) => q).ToArray();
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogWarning("Could not scan the path for files: " + ex);
				}
			}
			return new string[0];
		}

		public static string[] GetDirectories(string path, bool isRecursive = false)
		{
			if (isWebPlatform && !isEditor)
			{
				UnityEngine.Debug.LogWarning("'GetDirectories' is not supported for the current platform!");
			}
			else if ((!isWSABasedPlatform || isEditor) && !string.IsNullOrEmpty(path))
			{
				try
				{
					return Directory.EnumerateDirectories(ValidatePath(path), "*", isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToArray();
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogWarning("Could not scan the path for directories: " + ex);
				}
			}
			return new string[0];
		}

		public static string ValidURLFromFilePath(string path)
		{
			if (!string.IsNullOrEmpty(path))
			{
				if (!isValidURL(path))
				{
					return BaseConstants.PREFIX_FILE + Uri.EscapeUriString(ValidateFile(path).Replace('\\', '/'));
				}
				return Uri.EscapeUriString(ValidateFile(path).Replace('\\', '/'));
			}
			return path;
		}

		public static string CleanUrl(string url, bool removeProtocol = true, bool removeWWW = true, bool removeSlash = true)
		{
			string text = url.Trim();
			if (!string.IsNullOrEmpty(url))
			{
				if (removeProtocol)
				{
					text = text.Substring(text.IndexOf("//") + 2);
				}
				if (removeWWW)
				{
					text = text.CTReplace("www.", string.Empty);
				}
				if (removeSlash && text.EndsWith("/"))
				{
					text = text.Substring(0, text.Length - 1);
				}
			}
			return text;
		}

		public static string ClearTags(string text)
		{
			return cleanTagsRegex.Replace(text, string.Empty).Trim();
		}

		public static string ClearSpaces(string text)
		{
			return cleanSpacesRegex.Replace(text, " ").Trim();
		}

		public static string ClearLineEndings(string text)
		{
			return lineEndingsRegex.Replace(text, string.Empty).Trim();
		}

		public static List<string> SplitStringToLines(string text, bool ignoreCommentedLines = true, int skipHeaderLines = 0, int skipFooterLines = 0)
		{
			List<string> list = new List<string>(100);
			if (string.IsNullOrEmpty(text))
			{
				UnityEngine.Debug.LogWarning("Parameter 'text' is null or empty!" + Environment.NewLine + "=> 'SplitStringToLines()' will return an empty string list.");
			}
			else
			{
				string[] array = lineEndingsRegex.Split(text);
				for (int i = 0; i < array.Length; i++)
				{
					if (i + 1 <= skipHeaderLines || i >= array.Length - skipFooterLines || string.IsNullOrEmpty(array[i]))
					{
						continue;
					}
					if (ignoreCommentedLines)
					{
						if (!array[i].StartsWith("#"))
						{
							list.Add(array[i]);
						}
					}
					else
					{
						list.Add(array[i]);
					}
				}
			}
			return list;
		}

		public static string FormatBytesToHRF(long bytes)
		{
			string[] array = new string[5] { "B", "KB", "MB", "GB", "TB" };
			double num = bytes;
			int num2 = 0;
			while (num >= 1024.0 && num2 < array.Length - 1)
			{
				num2++;
				num /= 1024.0;
			}
			return $"{num:0.##} {array[num2]}";
		}

		public static string FormatSecondsToHourMinSec(double seconds)
		{
			int num = (int)seconds;
			int num2 = num % 60;
			if (seconds >= 86400.0)
			{
				int num3 = num / 86400;
				int num4 = (num -= num3 * 86400) / 3600;
				int num5 = (num - num4 * 3600) / 60;
				return num3 + "d " + num4 + ":" + ((num5 < 10) ? ("0" + num5) : num5.ToString()) + ":" + ((num2 < 10) ? ("0" + num2) : num2.ToString());
			}
			if (seconds >= 3600.0)
			{
				int num6 = num / 3600;
				int num7 = (num - num6 * 3600) / 60;
				return num6 + ":" + ((num7 < 10) ? ("0" + num7) : num7.ToString()) + ":" + ((num2 < 10) ? ("0" + num2) : num2.ToString());
			}
			return num / 60 + ":" + ((num2 < 10) ? ("0" + num2) : num2.ToString());
		}

		public static Color HSVToRGB(float h, float s, float v, float a = 1f)
		{
			if (Mathf.Abs(s) < 0.0001f)
			{
				return new Color(v, v, v, a);
			}
			float num = h / 60f;
			int num2 = Mathf.FloorToInt(num);
			float num3 = num - (float)num2;
			float num4 = v * (1f - s);
			float num5 = v * (1f - s * num3);
			float num6 = v * (1f - s * (1f - num3));
			return num2 switch
			{
				0 => new Color(v, num6, num4, a), 
				1 => new Color(num5, v, num4, a), 
				2 => new Color(num4, v, num6, a), 
				3 => new Color(num4, num5, v, a), 
				4 => new Color(num6, num4, v, a), 
				_ => new Color(v, num4, num5, a), 
			};
		}

		public static bool isValidURL(string url)
		{
			if (!string.IsNullOrEmpty(url))
			{
				if (!url.StartsWith("file://", StringComparison.OrdinalIgnoreCase) && !url.StartsWith(BaseConstants.PREFIX_HTTP, StringComparison.OrdinalIgnoreCase))
				{
					return url.StartsWith(BaseConstants.PREFIX_HTTPS, StringComparison.OrdinalIgnoreCase);
				}
				return true;
			}
			return false;
		}

		public static void FileCopy(string inputFile, string outputFile, bool move = false)
		{
			if ((isWSABasedPlatform || isWebPlatform) && !isEditor)
			{
				UnityEngine.Debug.LogWarning("'FileCopy' is not supported for the current platform!");
			}
			else
			{
				if (string.IsNullOrEmpty(outputFile))
				{
					return;
				}
				try
				{
					if (!File.Exists(inputFile))
					{
						UnityEngine.Debug.LogError("Input file does not exists: " + inputFile);
						return;
					}
					Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
					if (File.Exists(outputFile))
					{
						if (BaseConstants.DEV_DEBUG)
						{
							UnityEngine.Debug.LogWarning("Overwrite output file: " + outputFile);
						}
						File.Delete(outputFile);
					}
					if (move)
					{
						File.Move(inputFile, outputFile);
					}
					else
					{
						File.Copy(inputFile, outputFile);
					}
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogError("Could not copy file!" + Environment.NewLine + ex);
				}
			}
		}

		public static void ShowFileLocation(string file)
		{
			if (isStandalonePlatform || isEditor)
			{
				string text = ((string.IsNullOrEmpty(file) || file.Equals(".")) ? "." : (((!isWindowsPlatform && !isWindowsEditor) || file.Length >= 4) ? ValidatePath(Path.GetDirectoryName(file)) : file));
				try
				{
					if (Directory.Exists(text))
					{
						Process.Start(text);
					}
					else
					{
						UnityEngine.Debug.LogWarning("Path to file doesn't exist: " + text);
					}
					return;
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogError("Could not show file location: " + ex);
					return;
				}
			}
			UnityEngine.Debug.LogWarning("'ShowFileLocation' is not supported on the current platform!");
		}

		public static void OpenFile(string file)
		{
			if (isStandalonePlatform || isEditor)
			{
				try
				{
					if (File.Exists(file))
					{
						using (Process process = new Process())
						{
							if (isMacOSPlatform || isMacOSEditor)
							{
								process.StartInfo.FileName = "open";
								process.StartInfo.WorkingDirectory = Path.GetDirectoryName(file) + "/";
								process.StartInfo.Arguments = "-t " + Path.GetFileName(file);
							}
							else if (isLinuxPlatform || isLinuxEditor)
							{
								process.StartInfo.FileName = "xdg-open";
								process.StartInfo.WorkingDirectory = Path.GetDirectoryName(file) + "/";
								process.StartInfo.Arguments = Path.GetFileName(file);
							}
							else
							{
								process.StartInfo.FileName = file;
							}
							process.Start();
							return;
						}
					}
					UnityEngine.Debug.LogWarning("File doesn't exist: " + file);
					return;
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogError("Could not open file: " + ex);
					return;
				}
			}
			UnityEngine.Debug.LogWarning("'OpenFile' is not supported on the current platform!");
		}

		public static string getIP(string host)
		{
			if (!string.IsNullOrEmpty(host))
			{
				try
				{
					return Dns.GetHostAddresses(host)[0].ToString();
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogWarning("Could not resolve host '" + host + "': " + ex);
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("Host name is null or empty - can't resolve to IP!");
			}
			return host;
		}
	}
}
