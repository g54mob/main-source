using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LiveSplit;

namespace Kitchen
{
	public class LiveSplitIntegration : GenericSystemBase
	{
		public Stopwatch Stopwatch = new Stopwatch();

		public long AuthoritativeTimestamp;

		public long AuthoritativeFinishTimestamp;

		protected override void OnUpdate()
		{
			bool flag = Preferences.Get<bool>(Pref.LiveSplitEnabled);
			if (!Require<SDay>(out var comp))
			{
				return;
			}
			if (Require<SLiveSplitStartTime>(out var _))
			{
				if (AuthoritativeTimestamp > 0)
				{
					Set(new SLiveSplitStartTime
					{
						StartTime = AuthoritativeTimestamp,
						FinishTime = AuthoritativeFinishTimestamp
					});
				}
			}
			else
			{
				if (comp.Day != 0)
				{
					return;
				}
				Stopwatch.Reset();
				AuthoritativeTimestamp = -1L;
				Set(new SLiveSplitStartTime
				{
					StartTime = -1L,
					FinishTime = -1L
				});
			}
			if (Has<SIsDayFirstUpdate>() && comp.Day == 1)
			{
				if (flag)
				{
					global::LiveSplit.LiveSplit.SendStart();
				}
				StartTimer();
				AuthoritativeTimestamp = -1L;
			}
			if (Has<SIsNightFirstUpdate>())
			{
				if (comp.Day == 15)
				{
					StopTimer();
					Task.Run(async delegate
					{
						await global::LiveSplit.LiveSplit.SendPause();
						long? num = await global::LiveSplit.LiveSplit.GetFinalTime();
						if (num.HasValue)
						{
							AuthoritativeFinishTimestamp = DateTime.UtcNow.Ticks;
							AuthoritativeTimestamp = AuthoritativeFinishTimestamp - num.Value * 10000;
						}
					});
				}
				if (flag)
				{
					global::LiveSplit.LiveSplit.SendSplit();
				}
			}
			if (Has<SGameOver>())
			{
				StopTimer();
				AuthoritativeTimestamp = -1L;
				if (flag)
				{
					global::LiveSplit.LiveSplit.SendPause();
				}
			}
		}

		private void StopTimer()
		{
			long startTime = GetOrDefault<SLiveSplitStartTime>().StartTime;
			Set(new SLiveSplitStartTime
			{
				StartTime = startTime,
				FinishTime = DateTime.UtcNow.Ticks
			});
		}

		private void StartTimer()
		{
			Set(new SLiveSplitStartTime
			{
				StartTime = DateTime.UtcNow.Ticks,
				FinishTime = -1L
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
