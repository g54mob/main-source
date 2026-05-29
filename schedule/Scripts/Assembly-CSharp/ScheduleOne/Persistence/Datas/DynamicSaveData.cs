using System;
using System.Collections.Generic;

namespace ScheduleOne.Persistence.Datas
{
	[Serializable]
	public class DynamicSaveData : SaveData
	{
		[Serializable]
		public class AdditionalData
		{
			public string Name;

			public string Contents;
		}

		public string BaseData;

		public List<AdditionalData> AdditionalDatas;

		public DynamicSaveData(SaveData baseData)
		{
		}

		public void AddData(string name, string contents)
		{
		}

		public void AddData(string name, SaveData data)
		{
		}

		public string GetData(string name)
		{
			return null;
		}

		public bool TryGetData(string name, out string data)
		{
			data = null;
			return false;
		}

		public T GetData<T>(string name, bool warn = true) where T : SaveData
		{
			return null;
		}

		public bool TryGetData<T>(string name, out T data) where T : SaveData
		{
			data = null;
			return false;
		}

		public T ExtractBaseData<T>() where T : SaveData
		{
			return null;
		}

		public bool TryExtractBaseData<T>(out T data) where T : SaveData
		{
			data = null;
			return false;
		}
	}
}
