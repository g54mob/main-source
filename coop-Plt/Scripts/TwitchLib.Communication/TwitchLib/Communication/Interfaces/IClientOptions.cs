using System;
using TwitchLib.Communication.Enums;
using TwitchLib.Communication.Models;

namespace TwitchLib.Communication.Interfaces
{
	public interface IClientOptions
	{
		ClientType ClientType { get; set; }

		int DisconnectWait { get; set; }

		int MessagesAllowedInPeriod { get; set; }

		ReconnectionPolicy ReconnectionPolicy { get; set; }

		TimeSpan SendCacheItemTimeout { get; set; }

		ushort SendDelay { get; set; }

		int SendQueueCapacity { get; set; }

		TimeSpan ThrottlingPeriod { get; set; }

		bool UseSsl { get; set; }

		TimeSpan WhisperThrottlingPeriod { get; set; }

		int WhispersAllowedInPeriod { get; set; }

		int WhisperQueueCapacity { get; set; }
	}
}
