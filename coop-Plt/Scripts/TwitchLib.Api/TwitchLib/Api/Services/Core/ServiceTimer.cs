using System.Threading.Tasks;
using System.Timers;

namespace TwitchLib.Api.Services.Core
{
	internal class ServiceTimer : Timer
	{
		public delegate Task ServiceTimerTick();

		private readonly ServiceTimerTick _serviceTimerTickAsyncCallback;

		public int IntervalInSeconds { get; }

		public ServiceTimer(ServiceTimerTick serviceTimerTickAsyncCallback, int intervalInSeconds = 60)
		{
			_serviceTimerTickAsyncCallback = serviceTimerTickAsyncCallback;
			base.Interval = intervalInSeconds * 1000;
			IntervalInSeconds = intervalInSeconds;
			base.Elapsed += async delegate(object sender, ElapsedEventArgs e)
			{
				await TimerElapsedAsync(sender, e);
			};
		}

		private async Task TimerElapsedAsync(object sender, ElapsedEventArgs e)
		{
			await _serviceTimerTickAsyncCallback();
		}
	}
}
