using System;
using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class InputSourceWrapper<T> : IDisposable, IInputSource
	{
		private T FzAfZmFeJSmPEcrqFTJfQfeHdrSY;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public T source => FzAfZmFeJSmPEcrqFTJfQfeHdrSY;

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
			FzAfZmFeJSmPEcrqFTJfQfeHdrSY = source;
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
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~InputSourceWrapper()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 614827164;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x24A5849E)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				return;
			case 1:
				goto IL_0032;
			case 0:
				return;
			}
			goto IL_0008;
			IL_0032:
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
			num = 614827166;
			goto IL_000d;
		}
	}
}
