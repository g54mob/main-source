using System;
using System.IO;
using Factory;
using Factory.Pools;

namespace DevTools.OnScreenDebugTools
{
	public class OnScreenDebugStorage : IReusable
	{
		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("StartupScreen");

		[Dependency]
		private IHardwareCapabilities _hardwareCapabilities;

		private const string DataStorageDirectory = "OnScreenDebugData";

		private string StoragePath => Path.Combine(_hardwareCapabilities.PersistentStoragePath, "OnScreenDebugData");

		public string[] LoadAll()
		{
			if (Directory.Exists(StoragePath))
			{
				return Directory.GetFiles(StoragePath);
			}
			return null;
		}

		public bool Exists(string filename)
		{
			return Directory.Exists(Path.Combine(StoragePath, filename));
		}

		public bool Store(string filename, byte[] data)
		{
			if (!Exists(StoragePath))
			{
				Directory.CreateDirectory(StoragePath);
			}
			return Write(Path.Combine(StoragePath, filename), data);
		}

		public bool Store(string filename, string[] data)
		{
			if (!Exists(StoragePath))
			{
				Directory.CreateDirectory(StoragePath);
			}
			return WriteLines(Path.Combine(StoragePath, filename), data);
		}

		public void Delete(string filename)
		{
			File.Delete(filename);
		}

		public static bool LoadBytesFromFile(string filePath, out byte[] bytes)
		{
			try
			{
				bytes = File.ReadAllBytes(filePath);
				return true;
			}
			catch (Exception ex)
			{
				Log.Warn("Unable to read from {0}.\n{1}", filePath, ex);
				bytes = null;
				return false;
			}
		}

		private static bool Write(string filepath, byte[] data)
		{
			try
			{
				File.WriteAllBytes(filepath, data);
				return true;
			}
			catch (Exception ex)
			{
				Log.Warn("Unable to write to {0}.\n{1}", filepath, ex);
				return false;
			}
		}

		private static bool WriteLines(string filepath, string[] lines)
		{
			try
			{
				File.WriteAllLines(filepath, lines);
				return true;
			}
			catch (Exception ex)
			{
				Log.Warn("Unable to write to {0}.\n{1}", filepath, ex);
				return false;
			}
		}

		public void Reset()
		{
		}
	}
}
