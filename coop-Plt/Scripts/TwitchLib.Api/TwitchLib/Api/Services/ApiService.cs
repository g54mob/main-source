using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Interfaces;
using TwitchLib.Api.Services.Core;
using TwitchLib.Api.Services.Events;

namespace TwitchLib.Api.Services
{
	public class ApiService
	{
		protected readonly ITwitchAPI _api;

		private readonly ServiceTimer _serviceTimer;

		public List<string> ChannelsToMonitor { get; private set; }

		public int IntervalInSeconds => _serviceTimer.IntervalInSeconds;

		public bool Enabled => _serviceTimer.Enabled;

		public event EventHandler<OnServiceStartedArgs> OnServiceStarted;

		public event EventHandler<OnServiceStoppedArgs> OnServiceStopped;

		public event EventHandler<OnServiceTickArgs> OnServiceTick;

		public event EventHandler<OnChannelsSetArgs> OnChannelsSet;

		protected ApiService(ITwitchAPI api, int checkIntervalInSeconds)
		{
			if (api == null)
			{
				throw new ArgumentNullException("api");
			}
			if (checkIntervalInSeconds < 1)
			{
				throw new ArgumentException("The interval must be 1 second or more.", "checkIntervalInSeconds");
			}
			_api = api;
			_serviceTimer = new ServiceTimer(OnServiceTimerTick, checkIntervalInSeconds);
		}

		public virtual void Start()
		{
			if (ChannelsToMonitor == null)
			{
				throw new InvalidOperationException("You must atleast add 1 channel to service before starting it.");
			}
			if (_serviceTimer.Enabled)
			{
				throw new InvalidOperationException("The service has already been started.");
			}
			_serviceTimer.Start();
			this.OnServiceStarted?.Invoke(this, new OnServiceStartedArgs());
		}

		public virtual void Stop()
		{
			if (!_serviceTimer.Enabled)
			{
				throw new InvalidOperationException("The service hasn't started yet, or has already been stopped.");
			}
			_serviceTimer.Stop();
			this.OnServiceStopped?.Invoke(this, new OnServiceStoppedArgs());
		}

		protected virtual void SetChannels(List<string> channelsToMonitor)
		{
			if (channelsToMonitor == null)
			{
				throw new ArgumentNullException("channelsToMonitor");
			}
			if (channelsToMonitor.Count == 0)
			{
				throw new ArgumentException("The provided list is empty.", "channelsToMonitor");
			}
			ChannelsToMonitor = channelsToMonitor;
			this.OnChannelsSet?.Invoke(this, new OnChannelsSetArgs
			{
				Channels = channelsToMonitor
			});
		}

		protected virtual Task OnServiceTimerTick()
		{
			this.OnServiceTick?.Invoke(this, new OnServiceTickArgs());
			return Task.CompletedTask;
		}
	}
}
