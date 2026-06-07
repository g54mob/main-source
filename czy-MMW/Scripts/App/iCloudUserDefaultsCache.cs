using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using AOT;
using Factory;
using UnityEngine;

public class iCloudUserDefaultsCache : IiCloudCache, ICreatedInScopeHandler
{
	private int _sizeLimit = -1;

	[Dependency]
	private Diagnostics.StorageAuditTrail _auditTrail;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("iCloudUserDefaultsCache");

	private static readonly List<string> Keys = new List<string>();

	private const int NoSizeLimit = -1;

	public bool HasFile(string filepath)
	{
		int dataLength = 0;
		if (!UserDefaultsReadData(filepath, IntPtr.Zero, ref dataLength))
		{
			return false;
		}
		if (dataLength <= 0)
		{
			Log.Error("Key {0} reported data of invalid length {1}.", filepath, dataLength);
			return false;
		}
		return true;
	}

	public byte[] ReadFile(string filepath)
	{
		int dataLength = 0;
		if (!UserDefaultsReadData(filepath, IntPtr.Zero, ref dataLength))
		{
			Log.Error("Unable to find key {0}.", filepath);
			return null;
		}
		if (dataLength <= 0)
		{
			Log.Error("Key {0} reported data of invalid length {1}.", filepath, dataLength);
			return null;
		}
		byte[] array = new byte[dataLength];
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		int dataLength2 = dataLength;
		bool num = UserDefaultsReadData(filepath, gCHandle.AddrOfPinnedObject(), ref dataLength2);
		gCHandle.Free();
		if (!num || dataLength2 != dataLength)
		{
			Log.Error("Read of key {0} failed; expected {1} bytes, but read {2}.", filepath, dataLength, dataLength2);
			return null;
		}
		return array;
	}

	public bool WriteFile(string filepath, byte[] data)
	{
		GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
		bool num = UserDefaultsWriteData(filepath, gCHandle.AddrOfPinnedObject(), data.Length);
		gCHandle.Free();
		if (!num)
		{
			Log.Error("Failed to write data to key {0}.", filepath);
			return false;
		}
		return true;
	}

	public bool HasSpaceToWriteFile(string filepath, int dataLength, out int bytesNeededToDelete)
	{
		bytesNeededToDelete = 0;
		if (_sizeLimit == -1)
		{
			return true;
		}
		int num = filepath.Length + dataLength;
		int num2 = UserDefaultsGetObjectSize(filepath);
		if (num2 >= num)
		{
			return true;
		}
		int num3 = UserDefaultsGetTotalSize();
		int num4 = num - num2;
		int num5 = num3 + num4 - _sizeLimit;
		if (num5 <= 0)
		{
			return true;
		}
		bytesNeededToDelete = num5;
		return false;
	}

	public IEnumerable<string> GetFilenamesInDirectory(string directory)
	{
		Keys.Clear();
		UserDefaultsForEachKey(Marshal.GetFunctionPointerForDelegate<Action<string>>(OnKey));
		List<string> list = new List<string>();
		foreach (string key in Keys)
		{
			if (Path.GetDirectoryName(key) == directory)
			{
				list.Add(Path.GetFileName(key));
			}
		}
		return list;
	}

	public IEnumerable<string> GetDirectoriesInDirectory(string directory)
	{
		Keys.Clear();
		UserDefaultsForEachKey(Marshal.GetFunctionPointerForDelegate<Action<string>>(OnKey));
		List<string> list = new List<string>();
		foreach (string key in Keys)
		{
			string directoryName = Path.GetDirectoryName(key);
			if (directoryName == null || !directoryName.StartsWith(directory))
			{
				continue;
			}
			directoryName = directoryName.Substring(directory.Length);
			string[] array = directoryName.Split(new char[2]
			{
				Path.DirectorySeparatorChar,
				Path.AltDirectorySeparatorChar
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 0)
			{
				string item = array[0];
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public int GetFileSize(string filepath)
	{
		return UserDefaultsGetObjectSize(filepath);
	}

	public bool MoveFile(string filepath, string directory)
	{
		string text = Path.GetFileName(filepath);
		if (!string.IsNullOrEmpty(directory))
		{
			text = Path.Combine(directory, text);
		}
		if (UserDefaultsRenameObject(filepath, text))
		{
			Log.Info("Renamed {0} to {1}.", filepath, text);
			return true;
		}
		Log.Error("Failed to rename {0} to {1}.", filepath, text);
		return false;
	}

	public bool DeleteFile(string filepath)
	{
		if (UserDefaultsDeleteObject(filepath))
		{
			Log.Info("Deleted object {0}.", filepath);
			return true;
		}
		Log.Error("Failed to delete object {0}.", filepath);
		return false;
	}

	public void CopyNewFilesInDirectory(string sourceDirectory, string destinationDirectory)
	{
		foreach (string item in GetFilenamesInDirectory(sourceDirectory))
		{
			string sourceFilepath = item;
			if (!string.IsNullOrEmpty(sourceDirectory))
			{
				sourceFilepath = Path.Combine(sourceDirectory, sourceFilepath);
			}
			string destinationFilepath = Path.Combine(destinationDirectory, item);
			Log.Info("Copying {0} to {1}.", sourceFilepath, destinationFilepath);
			UserDefaultsCopyObject(sourceFilepath, destinationFilepath);
			_auditTrail.RecordEvent("iCloudUserDefaultsCache.CopyFile", delegate(Dictionary<string, string> metadata)
			{
				metadata["fromFilepath"] = sourceFilepath;
				metadata["toFilepath"] = destinationFilepath;
			});
		}
	}

	public DateTime GetFileModifiedTime(string filepath)
	{
		return DateTime.MinValue;
	}

	public void OnCreatedInScope(IScope scope)
	{
		if (Application.platform == RuntimePlatform.tvOS)
		{
			_sizeLimit = 943713;
		}
	}

	[MonoPInvokeCallback(typeof(Action<string>))]
	private static void OnKey(string key)
	{
		Keys.Add(key);
	}

	private static void UserDefaultsForEachKey(IntPtr keyHandler)
	{
	}

	private static bool UserDefaultsReadData(string filename, IntPtr data, ref int dataLength)
	{
		return false;
	}

	private static bool UserDefaultsWriteData(string filename, IntPtr data, int dataLength)
	{
		return false;
	}

	private static bool UserDefaultsCopyObject(string existingKey, string newKey)
	{
		return false;
	}

	private static bool UserDefaultsRenameObject(string oldKey, string newKey)
	{
		return false;
	}

	private static bool UserDefaultsDeleteObject(string key)
	{
		return false;
	}

	private static int UserDefaultsGetObjectSize(string key)
	{
		return 0;
	}

	private static int UserDefaultsGetTotalSize()
	{
		return 0;
	}
}
