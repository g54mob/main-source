using System;
using Cysharp.Threading.Tasks;

namespace Services.Save
{
	public interface ISaveService
	{
		event Action OnSaveStarted;

		event Action OnSaveCompleted;

		event Action OnLoadStarted;

		event Action OnLoadCompleted;

		void Register(ISaveable saveable);

		void Unregister(ISaveable saveable);

		void SaveAll();

		void LoadAll();

		UniTask LoadAllAsync();

		void Save(string key);

		void Load(string key);

		void Write<T>(string key, T data);

		bool TryRead<T>(string key, out T data);

		void DeleteKey(string key);

		void DeleteAll();
	}
}
