using System;
using DV.UserManagement.Storage;
using Newtonsoft.Json;

namespace DV.UserManagement.Data
{
	public class UserPreferences : IDisposable
	{
		[JsonIgnore]
		private string path;

		[JsonIgnore]
		private IStorageProvider storage;

		public string RawData { get; set; }

		public bool StartedEmpty { get; private set; }

		[JsonIgnore]
		public string Path => path;

		internal UserPreferences(IStorageProvider storage)
		{
			this.storage = storage;
			StartedEmpty = true;
		}

		internal UserPreferences(IStorageProvider storage, string path)
		{
			this.storage = storage;
			this.path = path;
			StartedEmpty = true;
		}

		internal static UserPreferences Load(IStorageProvider storage, string path)
		{
			string text = storage.ReadFileToString(path);
			return new UserPreferences(storage, path)
			{
				path = path,
				RawData = text,
				StartedEmpty = string.IsNullOrWhiteSpace(text)
			};
		}

		public void Reload()
		{
			RawData = storage.ReadFileToString(path);
		}

		public void Save()
		{
			if (StartedEmpty && !string.IsNullOrWhiteSpace(RawData))
			{
				StartedEmpty = false;
			}
			storage.WriteFile(path, RawData);
		}

		public void Dispose()
		{
		}
	}
}
