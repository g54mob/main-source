using System;
using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class InputSourceWrapper<T> : IDisposable, IInputSource
	{
		private T imwgydyWOVgGruTMVBaQZGRbcjmk;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

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
