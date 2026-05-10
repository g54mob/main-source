using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.Persistence.Loaders
{
	public class DynamicLoader
	{
		public void Load(string serializedDynamicSaveData)
		{
		}

		public virtual void Load(DynamicSaveData saveData)
		{
		}

		public static T ExtractBaseData<T>(DynamicSaveData saveData) where T : SaveData
		{
			return null;
		}

		public static bool TryExtractBaseData<T>(DynamicSaveData saveData, out T baseData) where T : SaveData
		{
			baseData = null;
			return false;
		}
	}
}
