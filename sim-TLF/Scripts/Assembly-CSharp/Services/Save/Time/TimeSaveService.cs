using Cysharp.Threading.Tasks;
using Services.Time;
using Zenject;

namespace Services.Save.Time
{
	public class TimeSaveService : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private readonly ITimeService _timeService;

		public string SaveKey => "TimeService";

		public int Priority => 0;

		public TimeSaveService(ISaveService saveService, ITimeService timeService)
		{
			_saveService = saveService;
			_timeService = timeService;
			_saveService.Register(this);
			_timeService.SetAutoTimeIncrement(auto: true);
		}

		public void OnSave()
		{
			_saveService.Write(SaveKey, new TimeSaveData
			{
				CurrentTime = _timeService.CurrentTime,
				TimeIncrement = _timeService.TimeIncrement,
				AutoTimeIncrement = _timeService.AutoTimeIncrement
			});
		}

		public async UniTask OnLoad()
		{
			if (_saveService.TryRead<TimeSaveData>(SaveKey, out var data))
			{
				_timeService.SetTime(data.CurrentTime);
				_timeService.SetTimeIncrement(data.TimeIncrement);
				_timeService.SetAutoTimeIncrement(data.AutoTimeIncrement);
				await UniTask.CompletedTask;
			}
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
