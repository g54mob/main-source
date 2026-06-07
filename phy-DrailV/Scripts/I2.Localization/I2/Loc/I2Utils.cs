using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace I2.Loc
{
	public static class I2Utils
	{
		public const string ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

		public const string NumberChars = "0123456789";

		public const string ValidNameSymbols = ".-_$#@*()[]{}+:?!&',^=<>~`";

		private static readonly Regex removeTagsRegex = new Regex("\\{\\[(.*?)]}|\\[(.*?)]|\\<(.*?)>");

		public unsafe static string ReverseText(string source)
		{
			int length = source.Length;
			char* ptr = stackalloc char[length];
			for (int i = 0; i < length; i++)
			{
				ptr[length - 1 - i] = source[i];
			}
			return new string(ptr);
		}

		public unsafe static string RemoveNonASCII(string text, bool allowCategory = false)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			string text2 = text.Trim();
			int num = 0;
			char* ptr = stackalloc char[text2.Length];
			bool flag = false;
			string text3 = text2;
			foreach (char c in text3)
			{
				char c2 = ' ';
				if ((allowCategory && (c == '\\' || c == '"' || c == '/')) || char.IsLetterOrDigit(c) || ".-_$#@*()[]{}+:?!&',^=<>~`".IndexOf(c) >= 0)
				{
					c2 = c;
				}
				if (char.IsWhiteSpace(c2))
				{
					if (!flag)
					{
						if (num > 0)
						{
							ptr[num++] = ' ';
						}
						flag = true;
					}
				}
				else
				{
					flag = false;
					ptr[num++] = c2;
				}
			}
			return new string(ptr, 0, num);
		}

		public static string GetValidTermName(string text, bool allowCategory = false)
		{
			if (text == null)
			{
				return null;
			}
			text = RemoveTags(text);
			return RemoveNonASCII(text, allowCategory);
		}

		public static string SplitLine(string line, int maxCharacters)
		{
			if (maxCharacters <= 0 || line.Length < maxCharacters)
			{
				return line;
			}
			char[] array = line.ToCharArray();
			bool flag = true;
			bool flag2 = false;
			int i = 0;
			int num = 0;
			for (; i < array.Length; i++)
			{
				if (flag)
				{
					num++;
					if (array[i] == '\n')
					{
						num = 0;
					}
					if (num >= maxCharacters && char.IsWhiteSpace(array[i]))
					{
						array[i] = '\n';
						flag = false;
						flag2 = false;
					}
				}
				else if (!char.IsWhiteSpace(array[i]))
				{
					flag = true;
					num = 0;
				}
				else if (array[i] != '\n')
				{
					array[i] = '\0';
				}
				else
				{
					if (!flag2)
					{
						array[i] = '\0';
					}
					flag2 = true;
				}
			}
			return new string(array.Where((char c) => c != '\0').ToArray());
		}

		public static bool FindNextTag(string line, int iStart, out int tagStart, out int tagEnd)
		{
			tagStart = -1;
			tagEnd = -1;
			int length = line.Length;
			tagStart = iStart;
			while (tagStart < length && line[tagStart] != '[' && line[tagStart] != '(' && line[tagStart] != '{' && line[tagStart] != '<')
			{
				tagStart++;
			}
			if (tagStart == length)
			{
				return false;
			}
			bool flag = false;
			for (tagEnd = tagStart + 1; tagEnd < length; tagEnd++)
			{
				char c = line[tagEnd];
				if (c == ']' || c == ')' || c == '}' || c == '>')
				{
					if (flag)
					{
						return FindNextTag(line, tagEnd + 1, out tagStart, out tagEnd);
					}
					return true;
				}
				if (c > 'ÿ')
				{
					flag = true;
				}
			}
			return false;
		}

		public static string RemoveTags(string text)
		{
			return removeTagsRegex.Replace(text, "");
		}

		public static bool RemoveResourcesPath(ref string sPath)
		{
			int a = sPath.IndexOf("\\Resources\\", StringComparison.Ordinal);
			int a2 = sPath.IndexOf("\\Resources/", StringComparison.Ordinal);
			int a3 = sPath.IndexOf("/Resources\\", StringComparison.Ordinal);
			int b = sPath.IndexOf("/Resources/", StringComparison.Ordinal);
			int num = Mathf.Max(a, Mathf.Max(a2, Mathf.Max(a3, b)));
			bool result = false;
			if (num >= 0)
			{
				sPath = sPath.Substring(num + 11);
				result = true;
			}
			else
			{
				num = sPath.LastIndexOfAny(LanguageSourceData.CategorySeparators);
				if (num > 0)
				{
					sPath = sPath.Substring(num + 1);
				}
			}
			string extension = Path.GetExtension(sPath);
			if (!string.IsNullOrEmpty(extension))
			{
				sPath = sPath.Substring(0, sPath.Length - extension.Length);
			}
			return result;
		}

		public static bool IsPlaying()
		{
			if (Application.isPlaying)
			{
				return true;
			}
			return false;
		}

		public static string GetPath(this Transform tr)
		{
			Transform parent = tr.parent;
			if (parent == null)
			{
				return tr.name;
			}
			return parent.GetPath() + "/" + tr.name;
		}

		public static Transform FindObject(string objectPath)
		{
			return FindObject(SceneManager.GetActiveScene(), objectPath);
		}

		public static Transform FindObject(Scene scene, string objectPath)
		{
			GameObject[] rootGameObjects = scene.GetRootGameObjects();
			for (int i = 0; i < rootGameObjects.Length; i++)
			{
				Transform transform = rootGameObjects[i].transform;
				if (transform.name == objectPath)
				{
					return transform;
				}
				if (objectPath.StartsWith(transform.name + "/", StringComparison.Ordinal))
				{
					return FindObject(transform, objectPath.Substring(transform.name.Length + 1));
				}
			}
			return null;
		}

		public static Transform FindObject(Transform root, string objectPath)
		{
			for (int i = 0; i < root.childCount; i++)
			{
				Transform child = root.GetChild(i);
				if (child.name == objectPath)
				{
					return child;
				}
				if (objectPath.StartsWith(child.name + "/", StringComparison.Ordinal))
				{
					return FindObject(child, objectPath.Substring(child.name.Length + 1));
				}
			}
			return null;
		}

		public static H FindInParents<H>(Transform tr) where H : Component
		{
			if (!tr)
			{
				return null;
			}
			H component = tr.GetComponent<H>();
			while (!component && (bool)tr)
			{
				component = tr.GetComponent<H>();
				tr = tr.parent;
			}
			return component;
		}

		public static string GetCaptureMatch(Match match)
		{
			for (int num = match.Groups.Count - 1; num >= 0; num--)
			{
				if (match.Groups[num].Success)
				{
					return match.Groups[num].ToString();
				}
			}
			return match.ToString();
		}

		public static void SendWebRequest(UnityWebRequest www)
		{
			www.SendWebRequest();
		}

		public static string UppercaseFirst(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}
			char[] array = s.ToLower().ToCharArray();
			array[0] = char.ToUpper(array[0]);
			return new string(array);
		}

		public static string TitleCase(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
		}
	}
}
