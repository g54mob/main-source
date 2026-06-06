using System;
using Rewired;
using Rewired.Platforms.Custom;

internal abstract class YFsnstQgfUozxyzUkSNqQIBNvLRi : IDisposable
{
	protected readonly CustomPlatformUnifiedControllerSource RLaqQDUapsWYfAHcqHZKMXAgmJtV;

	private readonly HardwareControllerMap_Game TGkPWXaTLHJUujpgtBAxjQcpBbelA;

	private bool SqKUwUTQusLhZlMKRywelizeDvLS;

	private bool VUdDKxDcXXLWPOHIPahmdfEiBVqsB;

	public InputSource inputSource => InputSource.Custom;

	public HardwareControllerMap_Game hardwareMap => TGkPWXaTLHJUujpgtBAxjQcpBbelA;

	public int axisCount => RLaqQDUapsWYfAHcqHZKMXAgmJtV.axisCount;

	public int buttonCount => RLaqQDUapsWYfAHcqHZKMXAgmJtV.buttonCount;

	public Controller.Extension controllerExtension => RLaqQDUapsWYfAHcqHZKMXAgmJtV.controllerExtension;

	public YFsnstQgfUozxyzUkSNqQIBNvLRi(CustomPlatformUnifiedControllerSource P_0, HardwareControllerMap_Game P_1)
	{
		RLaqQDUapsWYfAHcqHZKMXAgmJtV = P_0;
		TGkPWXaTLHJUujpgtBAxjQcpBbelA = P_1;
	}

	public void Clear()
	{
		RLaqQDUapsWYfAHcqHZKMXAgmJtV.bKjDIwENMRchxgtLnyamqImhHjTn();
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		RLaqQDUapsWYfAHcqHZKMXAgmJtV.SLhbkkqHyHhprKhAUvOQgPrDcxLX(dataUpdater);
	}

	public void cdhUdinUXBbjeznFyADwDrQawlLjA()
	{
		RLaqQDUapsWYfAHcqHZKMXAgmJtV.qqDXECmLViHPfTLfoTgNzlCjIPFK();
	}

	protected virtual void ILEClBBRdvbAszwlfygvfdBMjZDp(bool P_0)
	{
		if (!VUdDKxDcXXLWPOHIPahmdfEiBVqsB)
		{
			if (P_0 && RLaqQDUapsWYfAHcqHZKMXAgmJtV != null)
			{
				((IDisposable)RLaqQDUapsWYfAHcqHZKMXAgmJtV).Dispose();
			}
			VUdDKxDcXXLWPOHIPahmdfEiBVqsB = true;
		}
	}

	void IDisposable.Dispose()
	{
		ILEClBBRdvbAszwlfygvfdBMjZDp(true);
		GC.SuppressFinalize(this);
	}
}
