using System;
using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class InputSourceWrapper<T> : IDisposable, IInputSource
	{
		private T PESlCqcuFEdCgwfIyyIoKbUwani;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public T source
		{
			get
			{
				return PESlCqcuFEdCgwfIyyIoKbUwani;
			}
		}

		public event Action DeviceChangedEvent
		{
			add
			{
				throw new NotImplementedException();
			}
			remove
			{
				throw new NotImplementedException();
			}
		}

		public InputSourceWrapper(T source)
		{
			PESlCqcuFEdCgwfIyyIoKbUwani = source;
		}

		public void SystemDeviceConnected()
		{
		}

		public void SystemDeviceDisconnected()
		{
		}

		public void Update()
		{
			throw new NotImplementedException();
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			throw new NotImplementedException();
		}

		public void UpdateFinished()
		{
			throw new NotImplementedException();
		}

		public IList<TJoy> GetJoysticks<TJoy>() where TJoy : class
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~InputSourceWrapper()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
			}
		}
	}
}
