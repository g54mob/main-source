using System.Collections;
using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary
{
	public class KeyValueDataStore
	{
		private Dictionary<string, object> m_dataCollection;

		private string m_savePath;

		public KeyValueDataStore(string savePath)
		{
		}

		public bool GetBool(string key, bool defaultValue = false)
		{
			return false;
		}

		public long GetLong(string key, long defaultValue = 0L)
		{
			return 0L;
		}

		public double GetDouble(string key, double defaultValue = 0.0)
		{
			return 0.0;
		}

		public string GetString(string key, string defaultValue = null)
		{
			return null;
		}

		public byte[] GetByteArray(string key, byte[] defaultValue = null)
		{
			return null;
		}

		public IDictionary GetSnapshot()
		{
			return null;
		}

		public void SetBool(string key, bool value)
		{
		}

		public void SetLong(string key, long value)
		{
		}

		public void SetDouble(string key, double value)
		{
		}

		public void SetString(string key, string value)
		{
		}

		public void SetByteArray(string key, byte[] value)
		{
		}

		public void Synchronize()
		{
		}

		public void Clear()
		{
		}

		public bool RemoveKey(string key)
		{
			return false;
		}

		private Dictionary<string, object> LoadDataFromPath(string path)
		{
			return null;
		}
	}
}
