using System;
using System.Threading.Tasks;
using TwitchSDK.Interop;

namespace TwitchSDK
{
	public class Prediction : BaseDisposable
	{
		private readonly CoreLibrary Core;

		private TaskCompletionSource<object> NextUpdateSrc;

		private TaskCompletionSource<object> LockedSrc = new TaskCompletionSource<object>();

		public PredictionInfo Info { get; private set; }

		public GameTask PredictionLocked => LockedSrc.Task;

		internal Prediction(PredictionInfo info, CoreLibrary core)
		{
			Info = info;
			Core = core;
			UpdateWorker();
		}

		private async void UpdateWorker()
		{
			try
			{
				while (Info.Status == PredictionStatus.Active || Info.Status == PredictionStatus.Locked)
				{
					if (Info.Status == PredictionStatus.Locked)
					{
						LockedSrc.TrySetResult(null);
					}
					NextUpdateSrc = new TaskCompletionSource<object>();
					Info = await Core.WaitForPredictionUpdate(Info.Id);
					NextUpdateSrc.TrySetResult(null);
				}
			}
			catch (Exception exception)
			{
				NextUpdateSrc.TrySetException(exception);
				LockedSrc.TrySetException(exception);
			}
			Dispose();
		}

		public GameTask WaitForUpdate()
		{
			return NextUpdateSrc.Task;
		}

		private async GameTask EndPrediction(PredictionStatus status, string winningOutcome = "")
		{
			Info = await Core.EndPrediction(new EndPredictionRequest
			{
				PredictionId = Info.Id,
				BroadcasterId = Info.BroadcasterId,
				Status = status,
				WinningOutcomeId = winningOutcome
			});
		}

		public async GameTask Lock()
		{
			await EndPrediction(PredictionStatus.Locked);
		}

		public async GameTask Resolve(PredictionOutcome outcome)
		{
			await EndPrediction(PredictionStatus.Resolved, outcome.Id);
		}

		public async GameTask Cancel()
		{
			await EndPrediction(PredictionStatus.Canceled);
		}

		protected override void DisposeUnmanaged()
		{
			try
			{
				Core.UnsubscribeFromPrediction(Info.Id);
			}
			catch
			{
			}
		}
	}
}
