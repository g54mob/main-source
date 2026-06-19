using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenBLive.Runtime
{
	public class InteractivePlayHeartBeat : IDisposable
	{
		private readonly CancellationTokenSource m_Cancellation;

		private readonly string[] m_GameIds;

		private readonly int m_Time;

		public event HeartBeatSucceed HeartBeatSucceed;

		public event HeartBeatError HeartBeatError;

		public InteractivePlayHeartBeat(string gameId, int time = 20000, CancellationTokenSource cancellation = null)
		{
			m_GameIds = new string[1] { gameId };
			m_Time = time;
			m_Cancellation = cancellation ?? new CancellationTokenSource();
		}

		public InteractivePlayHeartBeat(string[] gameIds, int time = 20000, CancellationTokenSource cancellation = null)
		{
			m_GameIds = gameIds;
			m_Time = time;
			m_Cancellation = cancellation ?? new CancellationTokenSource();
		}

		private async Task HeartBeatTask()
		{
			while (true)
			{
				await Task.Delay(m_Time);
				CancellationTokenSource cancellation = m_Cancellation;
				if (cancellation == null || cancellation.IsCancellationRequested)
				{
					break;
				}
				try
				{
					string json = ((m_GameIds.Length != 1) ? (await BApi.BatchHeartBeatInteractivePlay(m_GameIds)) : (await BApi.HeartBeatInteractivePlay(m_GameIds[0])));
					if (JObject.Parse(json)["code"].ToObject<int>() == 0)
					{
						this.HeartBeatSucceed?.Invoke();
						continue;
					}
					this.HeartBeatError?.Invoke(json);
					break;
				}
				catch (Exception ex)
				{
					this.HeartBeatError?.Invoke(ex.Message);
					break;
				}
			}
		}

		public void Start()
		{
			Task task = HeartBeatTask();
			if (task.Status == TaskStatus.Created)
			{
				task.Start();
			}
		}

		public void Stop()
		{
			m_Cancellation.Cancel();
		}

		public void Dispose()
		{
			Stop();
			m_Cancellation.Dispose();
		}
	}
}
