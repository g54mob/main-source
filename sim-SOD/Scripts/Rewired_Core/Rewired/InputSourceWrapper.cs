using System;
using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class InputSourceWrapper<T> : IDisposable, IInputSource
	{
		private T tfTCEMKNedpBjaNONhTolgkIZhi;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

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

		public InputSourceWrapper(T source)
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
