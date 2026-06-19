using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Services.Save.Plane
{
	public class PlaneSaveRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private PlaneSaveData _planeSaveData = new PlaneSaveData();

		public string SaveKey => "Plane";

		public int Priority => 25;

		internal event Action OnSaveStarted;

		internal event Action OnLoadCompleted;

		public PlaneSaveRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Save(PlaneSaveData data)
		{
			_planeSaveData = data;
		}

		public bool TryGet(out PlaneSaveData data)
		{
			data = _planeSaveData;
			return data != null;
		}

		public void OnSave()
		{
			this.OnSaveStarted?.Invoke();
			_saveService.Write(SaveKey, _planeSaveData);
		}

		public async UniTask OnLoad()
		{
			if (_saveService.TryRead<PlaneSaveData>(SaveKey, out var data))
			{
				_planeSaveData = data;
			}
			for (int i = 0; i < 5; i++)
			{
				await UniTask.WaitForEndOfFrame();
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
