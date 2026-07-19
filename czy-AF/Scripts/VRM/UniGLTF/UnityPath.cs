using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UniGLTF
{
	public struct UnityPath
	{
		private static readonly char[] EscapeChars = new char[9] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

		private static string s_basePath;

		public string Value { get; private set; }

		public bool IsNull => Value == null;

		public bool IsUnderAssetsFolder
		{
			get
			{
				if (IsNull)
				{
					return false;
				}
				if (!(Value == "Assets"))
				{
					return Value.StartsWith("Assets/");
				}
				return true;
			}
		}

		public bool IsStreamingAsset
		{
			get
			{
				if (IsNull)
				{
					return false;
				}
				return FullPath.StartsWith(Application.streamingAssetsPath + "/");
			}
		}

		public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(Value);

		public string Extension => Path.GetExtension(Value);

		public UnityPath Parent
		{
			get
			{
				if (IsNull)
				{
					return default(UnityPath);
				}
				return new UnityPath(Path.GetDirectoryName(Value));
			}
		}

		public bool HasParent => !string.IsNullOrEmpty(Value);

		private static string BaseFullPath
		{
			get
			{
				if (string.IsNullOrEmpty(s_basePath))
				{
					s_basePath = Path.GetFullPath(Application.dataPath + "/..").Replace("\\", "/");
				}
				return s_basePath;
			}
		}

		private static string AssetFullPath => BaseFullPath + "/Assets";

		public string FullPath
		{
			get
			{
				if (IsNull)
				{
					throw new NotImplementedException();
				}
				return Path.Combine(BaseFullPath, Value).Replace("\\", "/");
			}
		}

		public bool IsFileExists => File.Exists(FullPath);

		public bool IsDirectoryExists => Directory.Exists(FullPath);

		public IEnumerable<UnityPath> ChildDirs
		{
			get
			{
				string[] directories = Directory.GetDirectories(FullPath);
				foreach (string fullPath in directories)
				{
					yield return FromFullpath(fullPath);
				}
			}
		}

		public IEnumerable<UnityPath> ChildFiles
		{
			get
			{
				string[] files = Directory.GetFiles(FullPath);
				foreach (string fullPath in files)
				{
					yield return FromFullpath(fullPath);
				}
			}
		}

		public override string ToString()
		{
			return $"unity://{Value}";
		}

		private static string EscapeFilePath(string path)
		{
			char[] escapeChars = EscapeChars;
			foreach (char oldChar in escapeChars)
			{
				path = path.Replace(oldChar, '+');
			}
			return path;
		}

		public UnityPath Child(string name)
		{
			if (IsNull)
			{
				throw new NotImplementedException();
			}
			if (Value == "")
			{
				return new UnityPath(name);
			}
			return new UnityPath(Value + "/" + name);
		}

		public override int GetHashCode()
		{
			if (IsNull)
			{
				return 0;
			}
			return Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is UnityPath unityPath)
			{
				if (Value == null && unityPath.Value == null)
				{
					return true;
				}
				if (Value == null)
				{
					return false;
				}
				if (unityPath.Value == null)
				{
					return false;
				}
				return Value == unityPath.Value;
			}
			return false;
		}

		public UnityPath GetAssetFolder(string suffix)
		{
			if (!IsUnderAssetsFolder)
			{
				throw new NotImplementedException();
			}
			return new UnityPath($"{Parent.Value}/{FileNameWithoutExtension}{suffix}");
		}

		private UnityPath(string value)
		{
			this = default(UnityPath);
			Value = value.Replace("\\", "/");
		}

		public static UnityPath FromUnityPath(string unityPath)
		{
			if (string.IsNullOrEmpty(unityPath))
			{
				return new UnityPath
				{
					Value = ""
				};
			}
			return FromFullpath(Path.GetFullPath(unityPath));
		}

		public static UnityPath FromFullpath(string fullPath)
		{
			if (fullPath == null)
			{
				fullPath = "";
			}
			fullPath = fullPath.Replace("\\", "/");
			if (fullPath == BaseFullPath)
			{
				return new UnityPath
				{
					Value = ""
				};
			}
			if (fullPath.StartsWith(BaseFullPath + "/"))
			{
				return new UnityPath(fullPath.Substring(BaseFullPath.Length + 1));
			}
			return default(UnityPath);
		}

		public static bool IsUnderAssetFolder(string fullPath)
		{
			return fullPath.Replace("\\", "/").StartsWith(AssetFullPath);
		}

		[Obsolete("Use TraverseDir()")]
		public IEnumerable<UnityPath> TravserseDir()
		{
			return TraverseDir();
		}

		public IEnumerable<UnityPath> TraverseDir()
		{
			if (!IsDirectoryExists)
			{
				yield break;
			}
			yield return this;
			foreach (UnityPath childDir in ChildDirs)
			{
				foreach (UnityPath item in childDir.TraverseDir())
				{
					yield return item;
				}
			}
		}
	}
}
