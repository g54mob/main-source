using System;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class gjMBNBgPUgnpVrmJwQZQrVmLNmagb : nYVWMTKfnKjTqnJzQqfdswXfeTcY, IDisposable
{
	private Action zLQQTJMvBfURUDnNDkgeXKiJVMyo;

	private Id QFDajnKMWsIlEUWRFUAvODGTDmIj;

	private bool fNCdIcuGdqdfrbZFBVHJsFGKDuIU;

	public gjMBNBgPUgnpVrmJwQZQrVmLNmagb(Action P_0)
	{
		zLQQTJMvBfURUDnNDkgeXKiJVMyo = P_0;
		QFDajnKMWsIlEUWRFUAvODGTDmIj = 0u;
		LocalizationManager.Add(this, ref QFDajnKMWsIlEUWRFUAvODGTDmIj);
	}

	void nYVWMTKfnKjTqnJzQqfdswXfeTcY.Localize()
	{
		zLQQTJMvBfURUDnNDkgeXKiJVMyo();
	}

	private void TAAUmtUFnVEBdAXCgJDKUXxBLux(bool P_0)
	{
		if (!fNCdIcuGdqdfrbZFBVHJsFGKDuIU)
		{
			if (P_0)
			{
				LocalizationManager.Remove(ref QFDajnKMWsIlEUWRFUAvODGTDmIj);
			}
			fNCdIcuGdqdfrbZFBVHJsFGKDuIU = true;
		}
	}

	public void Dispose()
	{
		TAAUmtUFnVEBdAXCgJDKUXxBLux(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
