using System;
using UnityEngine;

namespace LaundryBear.PlatformServices
{
	public struct DelayShutdownScope_Platform : IDisposable
	{
		private ICanDelayShutdown canDelayShutdown;

		private bool didDelay;

		public DelayShutdownScope_Platform(ICanDelayShutdown canDelayShutdown)
		{
			didDelay = false;
			if (canDelayShutdown == null)
			{
				Debug.LogError("Argument is null");
				this.canDelayShutdown = null;
				return;
			}
			this.canDelayShutdown = canDelayShutdown;
			if (!this.canDelayShutdown.IsUserHandlingShutdownDelay)
			{
				canDelayShutdown.BeginDelayShutdown();
				didDelay = true;
			}
		}

		public void Dispose()
		{
			if (canDelayShutdown == null)
			{
				Debug.LogError("DelayShutdownScope_Platform must have not been initialized properly. This should never be initialized with the default constructor.");
			}
			else if (didDelay)
			{
				canDelayShutdown.BeginDelayShutdown();
			}
		}
	}
}
