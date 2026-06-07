using NaughtyAttributes;
using UnityEngine;

namespace Data.SaveData
{
	public abstract class AbstractPersistentSO : ScriptableObject
	{
		[SerializeField]
		[Required(null)]
		private PersistentSOLibrary _persistentSOLibrary;

		private void OnValidate()
		{
			_persistentSOLibrary.Add(this);
		}

		protected abstract void ApplyLoadedSaveData(AbstractSaveData saveData);

		protected virtual void ApplyNoSaveData()
		{
		}

		public abstract void ResetToDefaults();

		public abstract AbstractSaveData GetSaveData();

		public abstract bool TryLoadSaveData(string fullPath);

		protected bool TryLoadSaveDataInternal<T>(string fullPath) where T : AbstractSaveData
		{
			T data;
			bool num = SaveSystem.TryLoadData<T>(fullPath, out data);
			if (num)
			{
				ApplyLoadedSaveData(data);
				return num;
			}
			ApplyNoSaveData();
			return num;
		}
	}
}
