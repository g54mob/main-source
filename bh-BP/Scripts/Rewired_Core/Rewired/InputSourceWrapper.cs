using System;
using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class InputSourceWrapper<T> : IInputSource, IDisposable
	{
		private T UAsTYeKbiHamJpWOPfevkgnEnAzeb;

		private bool mgvPSxuIaCjGFJdjPcFraEEgQGctA;

		public T source => default(T);

		public event Action DeviceChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public InputSourceWrapper(T P_0)
		{
		}

		public void SystemDeviceConnected()
		{
		}

		public void SystemDeviceDisconnected()
		{
		}

		public void Update()
		{
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
		}

		public void UpdateFinished()
		{
		}

		public IList<TJoy> GetJoysticks<TJoy>() where TJoy : class
		{
			return null;
		}

		public void Dispose()
		{
		}

		~InputSourceWrapper()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
