using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Services.Save.ActiveItems
{
	public class ActiveItemsSaveRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private Dictionary<string, bool> _items = new Dictionary<string, bool>();

		public string SaveKey => "ActiveItems";

		public int Priority => 5;

		internal event Action OnSaveStarted;

		internal event Action OnLoadCompleted;

		public ActiveItemsSaveRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Save(string id, bool isActive)
		{
			_items[id] = isActive;
		}

		public bool TryGet(string id, out bool isActive)
		{
			return _items.TryGetValue(id, out isActive);
		}

		public void OnSave()
		{
			this.OnSaveStarted?.Invoke();
			_saveService.Write(SaveKey, _items);
		}

		public async UniTask OnLoad()
		{
			if (_saveService.TryRead<Dictionary<string, bool>>(SaveKey, out var data))
			{
				_items = data;
			}
			this.OnLoadCompleted?.Invoke();
			await UniTask.CompletedTask;
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
