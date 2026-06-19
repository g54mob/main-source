using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Data.Save;
using Zenject;

namespace Services.Save.Boxes
{
	public class BoxesSaveRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private Dictionary<string, BoxSaveData> _boxes = new Dictionary<string, BoxSaveData>();

		public string SaveKey => "Boxes";

		public int Priority => 5;

		internal event Action OnSaveStarted;

		internal event Action OnLoadCompleted;

		public BoxesSaveRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Save(string id, BoxSaveData data)
		{
			_boxes[id] = data;
		}

		public bool TryGet(string id, out BoxSaveData data)
		{
			return _boxes.TryGetValue(id, out data);
		}

		public void OnSave()
		{
			this.OnSaveStarted?.Invoke();
			_saveService.Write(SaveKey, _boxes);
		}

		public async UniTask OnLoad()
		{
			if (_saveService.TryRead<Dictionary<string, BoxSaveData>>(SaveKey, out var data))
			{
				_boxes = data;
			}
			await UniTask.CompletedTask;
			this.OnLoadCompleted?.Invoke();
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
