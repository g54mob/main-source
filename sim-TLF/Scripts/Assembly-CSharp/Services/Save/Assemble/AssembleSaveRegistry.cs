using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Services.Save.Assemble
{
	public class AssembleSaveRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private Dictionary<string, AssembleObjectSaveData> _objects = new Dictionary<string, AssembleObjectSaveData>();

		public string SaveKey => "AssembleObjects";

		public int Priority => 5;

		internal event Action OnSaveStarted;

		internal event Action OnLoadCompleted;

		public AssembleSaveRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Save(string id, AssembleObjectSaveData data)
		{
			_objects[id] = data;
		}

		public bool TryGet(string id, out AssembleObjectSaveData data)
		{
			return _objects.TryGetValue(id, out data);
		}

		public void OnSave()
		{
			this.OnSaveStarted?.Invoke();
			_saveService.Write(SaveKey, _objects);
		}

		public async UniTask OnLoad()
		{
			if (_saveService.TryRead<Dictionary<string, AssembleObjectSaveData>>(SaveKey, out var data))
			{
				_objects = data;
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
