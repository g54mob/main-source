using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Utils;

public class FileUtils
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<string, string> _003C_003E9__9_0;

		public static Func<string, bool> _003C_003E9__9_1;

		public static Func<string, bool> _003C_003E9__9_2;

		public static Func<string, string> _003C_003E9__9_3;

		public static Func<string, bool> _003C_003E9__17_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CGetFilePathsInFolder_003Eb__9_0(string p)
		{
			return p;
		}

		internal bool _003CGetFilePathsInFolder_003Eb__9_1(string path)
		{
			//IL_0062: Expected I4, but got O
			string fileName = Path.GetFileName(path);
			if (fileName != null)
			{
				bool flag = fileName.StartsWith(".");
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CGetFilePathsInFolder_003Eb__9_2(string path)
		{
			//IL_0066: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998061B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (path != null)
			{
				bool flag = path.EndsWith(".meta");
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal string _003CGetFilePathsInFolder_003Eb__9_3(string filePath)
		{
			string text = string.FastAllocateString(1);
			if (text != null)
			{
				text._firstChar = Path.DirectorySeparatorChar;
				string text2 = string.FastAllocateString(1);
				if (text2 != null)
				{
					text2._firstChar = '/';
					if (filePath != null)
					{
						return filePath.Replace(text, text2);
					}
				}
			}
			return (string)(object)new NullReferenceException();
		}

		internal bool _003CContainsHiddenFiles_003Eb__17_0(string path)
		{
			//IL_0058: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980622]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (path != null)
			{
				return path.StartsWith(".");
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public const bool IGNORE_META = true;

	public const string UNITY_METAFILE_EXTENSION = ".meta";

	public const string DOTSTART_HIDDEN_FILE_HEADSTRING = ".";

	public const char UNITY_FOLDER_SEPARATOR = '/';

	public static void RemakeDirectory(string localFolderPath)
	{
		if (Directory.Exists(localFolderPath))
		{
			DeleteDirectory(localFolderPath, isRecursive: true);
		}
		DirectoryInfo directoryInfo = Directory.CreateDirectory(localFolderPath);
	}

	public static void CopyFile(string sourceFilePath, string targetFilePath)
	{
		string directoryName = Path.GetDirectoryName(targetFilePath);
		DirectoryInfo directoryInfo = Directory.CreateDirectory(directoryName);
		File.Copy(sourceFilePath, targetFilePath, overwrite: true);
	}

	public static void CopyTemplateFile(string sourceFilePath, string targetFilePath, string srcName, string dstName)
	{
		string directoryName = Path.GetDirectoryName(targetFilePath);
		DirectoryInfo directoryInfo = Directory.CreateDirectory(directoryName);
		if (sourceFilePath != null)
		{
			int bufferSize = default(int);
			Encoding encoding = default(Encoding);
			StreamReader streamReader = new StreamReader(sourceFilePath, encoding, detectEncodingFromByteOrderMarks: true, bufferSize);
			encoding = Encoding.UTF8;
			string text = streamReader.ReadToEnd();
			string contents = text.Replace(srcName, dstName);
			File.WriteAllText(targetFilePath, contents);
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("path");
		throw ex;
	}

	public static void DeleteFileThenDeleteFolderIfEmpty(string localTargetFilePath)
	{
		File.Delete(localTargetFilePath);
		string path = localTargetFilePath + ".meta";
		File.Delete(path);
		DirectoryInfo parent = Directory.GetParent(localTargetFilePath);
		string fullName = parent.FullName;
		IEnumerable<string> filePathsInFolder = GetFilePathsInFolder(fullName);
		if (!Enumerable.Any(filePathsInFolder))
		{
			DeleteDirectory(fullName, isRecursive: true);
			string path2 = fullName + ".meta";
			File.Delete(path2);
		}
	}

	public static List<string> GetAllFilePathsInFolder(string localFolderPath, bool includeHidden = false, bool includeMeta = false)
	{
		List<string> list = new List<string>();
		if (localFolderPath != null && localFolderPath._stringLength > 0 && Directory.Exists(localFolderPath))
		{
			GetFilePathsRecursively(localFolderPath, list, includeHidden, includeMeta);
		}
		return list;
	}

	public static IEnumerable<string> GetFilePathsInFolder(string folderPath, bool includeHidden = false, bool includeMeta = false)
	{
		string[] files = Directory.GetFiles(folderPath);
		Func<string, string> selector = _003C_003Ec._003C_003E9__9_0;
		if (_003C_003Ec._003C_003E9__9_0 == null)
		{
			selector = (_003C_003Ec._003C_003E9__9_0 = (string p) => p);
		}
		IEnumerable<string> enumerable = Enumerable.Select(files, selector);
		IEnumerable<string> enumerable2 = enumerable;
		if (!includeHidden)
		{
			Func<string, bool> predicate = _003C_003Ec._003C_003E9__9_1;
			if (_003C_003Ec._003C_003E9__9_1 == null)
			{
				predicate = (_003C_003Ec._003C_003E9__9_1 = delegate(string path)
				{
					//IL_0062: Expected I4, but got O
					string fileName = Path.GetFileName(path);
					if (fileName == null)
					{
						NullReferenceException ex2 = new NullReferenceException();
						return (byte)(int)ex2 != 0;
					}
					bool flag = fileName.StartsWith(".");
					return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
				});
			}
			IEnumerable<string> enumerable3 = Enumerable.Where(enumerable, predicate);
			enumerable2 = enumerable3;
		}
		if (!includeMeta)
		{
			Func<string, bool> predicate2 = _003C_003Ec._003C_003E9__9_2;
			if (_003C_003Ec._003C_003E9__9_2 == null)
			{
				predicate2 = (_003C_003Ec._003C_003E9__9_2 = delegate(string path)
				{
					//IL_0066: Expected I4, but got O
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998061B]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (path == null)
					{
						NullReferenceException ex2 = new NullReferenceException();
						return (byte)(int)ex2 != 0;
					}
					bool flag = path.EndsWith(".meta");
					return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
				});
			}
			IEnumerable<string> enumerable4 = Enumerable.Where(enumerable2, predicate2);
			enumerable2 = enumerable4;
		}
		if (Path.DirectorySeparatorChar != '/')
		{
			Func<string, string> selector2 = _003C_003Ec._003C_003E9__9_3;
			if (_003C_003Ec._003C_003E9__9_3 == null)
			{
				selector2 = (_003C_003Ec._003C_003E9__9_3 = delegate(string filePath)
				{
					string text = string.FastAllocateString(1);
					if (text != null)
					{
						text._firstChar = Path.DirectorySeparatorChar;
						string text2 = string.FastAllocateString(1);
						if (text2 != null)
						{
							text2._firstChar = '/';
							if (filePath != null)
							{
								return filePath.Replace(text, text2);
							}
						}
					}
					return (string)(object)new NullReferenceException();
				});
			}
			IEnumerable<string> enumerable5 = Enumerable.Select(enumerable2, selector2);
			enumerable2 = enumerable5;
		}
		if (enumerable2 != null)
		{
			return (IEnumerable<string>)new List<object>(enumerable2);
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private static void GetFilePathsRecursively(string localFolderPath, List<string> filePaths, bool includeHidden = false, bool includeMeta = false)
	{
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		string[] directories = Directory.GetDirectories(localFolderPath);
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < directories.Length)
		{
			GetFilePathsRecursively(directories[obj], filePaths, includeHidden, includeMeta);
			obj++;
			obj2 = obj;
		}
		IEnumerable<string> filePathsInFolder = GetFilePathsInFolder(localFolderPath, includeHidden, includeMeta);
		((List<object>)(object)filePaths).InsertRange(filePaths._size, (IEnumerable<object>)filePathsInFolder);
	}

	public static string PathCombine(string[] paths)
	{
		//IL_0059: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		if (paths.Length >= 2)
		{
			string text = _PathCombine(paths[0], paths[1]);
			object obj = paths.Length - 2;
			string[] array = new string[obj];
			int length = default(int);
			Array.Copy(paths, 2, array, 0, length);
			object obj2 = 0;
			string text2 = text;
			while ((nint)obj2 < array.Length)
			{
				string text3 = _PathCombine(text2, array[obj2]);
				obj2++;
				text2 = text3;
			}
			return text2;
		}
		object obj3 = new ArgumentException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
		throw obj3;
	}

	private static string _PathCombine(string head, string tail)
	{
		//IL_00d8: Expected O, but got I
		string text = string.FastAllocateString(1);
		if (text != null)
		{
			text._firstChar = '/';
			if (head != null)
			{
				bool flag = head.EndsWith(text);
				string text2 = head;
				if (!flag)
				{
					string text3 = head + "/";
					text2 = text3;
				}
				if (tail == null || tail._stringLength <= 0)
				{
					return text2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v8+E4]");
				if ((nint)0 == 0)
				{
				}
				string text4 = string.FastAllocateString(1);
				if (text4 != null)
				{
					text4._firstChar = '/';
					bool flag2 = tail.StartsWith(text4);
					bool flag3 = !flag2;
					string path = tail;
					if (!flag3)
					{
						int length = tail._stringLength - 1;
						string text5 = tail.Substring(1, length);
						path = text5;
					}
					return Path.Combine(text2, path);
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetPathWithProjectPath(string pathUnderProjectFolder)
	{
		string dataPath = Application.dataPath;
		DirectoryInfo parent = Directory.GetParent(dataPath);
		if (parent != null)
		{
			string text = parent.ToString();
			string[] array = new string[2];
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				return PathCombine(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetPathWithAssetsPath(string pathUnderAssetsFolder)
	{
		string dataPath = Application.dataPath;
		string[] array = new string[2];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return PathCombine(array);
		}
		return (string)(object)new NullReferenceException();
	}

	public static string ProjectPathWithSlash()
	{
		string dataPath = Application.dataPath;
		DirectoryInfo parent = Directory.GetParent(dataPath);
		if (parent != null)
		{
			string text = parent.ToString();
			return text + "/";
		}
		return (string)(object)new NullReferenceException();
	}

	public static bool IsMetaFile(string filePath)
	{
		//IL_0058: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998061B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (filePath != null)
		{
			return filePath.EndsWith(".meta");
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static bool ContainsHiddenFiles(string filePath)
	{
		//IL_0033: Expected I4, but got O
		//IL_0067: Expected O, but got Ref
		if (filePath == null)
		{
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		object obj = default(object);
		string[] source = filePath.SplitInternal((ReadOnlySpan<char>)(&obj), 2147483647, StringSplitOptions.None);
		Func<string, bool> predicate = _003C_003Ec._003C_003E9__17_0;
		if (_003C_003Ec._003C_003E9__17_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__17_0 = delegate(string path)
			{
				//IL_0058: Expected I4, but got O
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980622]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (path == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				return path.StartsWith(".");
			});
		}
		return Enumerable.Any(source, predicate);
	}

	public static void DeleteDirectory(string dirPath, bool isRecursive, bool forceDelete = true)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I4
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		if (forceDelete)
		{
			RemoveFileAttributes(dirPath, isRecursive);
		}
		string text = Path.InsecureGetFullPath(dirPath);
		if (isRecursive)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			global::Interop.Kernel32.WIN32_FIND_DATA findData = default(global::Interop.Kernel32.WIN32_FIND_DATA);
			System.IO.FileSystem.GetFindData(text, ref findData);
			object obj = findData & 0x400;
			if (obj != null)
			{
				object obj3 = default(object);
				object obj2 = obj3 & 0x20000000;
				bool flag = obj2 == null;
				bool flag2 = (nint)obj2 < 0;
				bool flag3 = !flag2;
				object obj4 = !flag;
				object obj5 = flag3 & obj4;
				if (obj5 != null)
				{
					goto IL_0119;
				}
			}
			string fullPath = System.IO.PathInternal.EnsureExtendedPrefix(text);
			System.IO.FileSystem.RemoveDirectoryRecursive(fullPath, ref findData, true);
			return;
		}
		goto IL_0119;
		IL_0119:
		System.IO.FileSystem.RemoveDirectoryInternal(text, true, false);
	}

	public static void RemoveFileAttributes(string dirPath, bool isRecursive)
	{
		//IL_0016: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		string[] files = Directory.GetFiles(dirPath);
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < files.Length)
		{
			File.SetAttributes(files[obj], FileAttributes.Normal);
			obj++;
			obj2 = obj;
		}
		if (isRecursive)
		{
			string[] directories = Directory.GetDirectories(dirPath);
			object obj3 = 0;
			object obj4 = 0;
			while ((nint)obj4 < directories.Length)
			{
				RemoveFileAttributes(directories[obj3], isRecursive);
				obj3++;
				obj4 = obj3;
			}
		}
	}

	public static string GetAbsoluteDirectoryPath(string directoryName, bool debug = false)
	{
		string dataPath = Application.dataPath;
		string[] directories = Directory.GetDirectories(dataPath, directoryName, EnumerationOptions._003CCompatibleRecursive_003Ek__BackingField);
		if (directories.Length != 0)
		{
			if (directories.Length > 1)
			{
				if (debug)
				{
					string[] array = new string[5];
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					int num = default(int);
					string text = num.ToString();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string message = string.Concat(array);
					Debug.LogWarning(message);
				}
				if (directories.Length > 0)
				{
					return directories[0];
				}
			}
			else if (directories.Length > 0)
			{
				return directories[0];
			}
			return (string)(object)new IndexOutOfRangeException();
		}
		if (debug)
		{
			string message2 = "You searched for the [" + directoryName + "] folder, but no folder with that name exists in the current project.";
			Debug.LogError(message2);
		}
		return "ERROR";
	}

	public static string GetRelativeDirectoryPath(string directoryName)
	{
		string absoluteDirectoryPath = GetAbsoluteDirectoryPath(directoryName);
		string dataPath = Application.dataPath;
		if (absoluteDirectoryPath != null)
		{
			return absoluteDirectoryPath.Replace(dataPath, "Assets");
		}
		return (string)(object)new NullReferenceException();
	}
}
