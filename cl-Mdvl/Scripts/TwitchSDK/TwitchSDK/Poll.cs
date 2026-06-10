using System;
using System.Threading.Tasks;
using TwitchSDK.Interop;

namespace TwitchSDK
{
	public class Poll : BaseDisposable
	{
		private readonly CoreLibrary Core;

		private TaskCompletionSource<object> NextUpdateSrc;

		public PollInfo Info { get; private set; }

		public GameTask PollEnded { get; private set; }

		internal Poll(PollInfo info, CoreLibrary core)
		{
			Info = info;
			Core = core;
			PollEnded = UpdateWorker();
		}

		private async GameTask UpdateWorker()
		{
			try
			{
				while (Info.Status == PollStatus.Active)
				{
					NextUpdateSrc = new TaskCompletionSource<object>();
					Info = await Core.WaitForPollUpdate(Info.Id);
					NextUpdateSrc.TrySetResult(null);
				}
			}
			catch (Exception exception)
			{
				NextUpdateSrc.TrySetException(exception);
				throw;
			}
			finally
			{
				Dispose();
			}
		}

		public GameTask WaitForUpdate()
		{
			return NextUpdateSrc.Task;
		}

		private async Task EndPoll(bool showResults)
		{
			Info = await Core.EndPoll(new EndPollRequest
			{
				BroadcasterId = Info.BroadcasterId,
				PollId = Info.Id,
				ShowResults = showResults
			});
		}

		public async GameTask FinishPoll()
		{
			await EndPoll(showResults: true);
		}

		public async GameTask DeletePoll()
		{
			await EndPoll(showResults: false);
		}

		protected override void DisposeUnmanaged()
		{
			try
			{
				Core.UnsubscribeFromPoll(Info.Id);
			}
			catch
			{
			}
		}
	}
}
