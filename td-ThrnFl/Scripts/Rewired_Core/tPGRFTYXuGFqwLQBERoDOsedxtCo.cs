using System;
using Rewired;
using Rewired.Platforms.Custom;

internal abstract class tPGRFTYXuGFqwLQBERoDOsedxtCo : IDisposable
{
	protected readonly CustomPlatformUnifiedControllerSource akMLpjOlowLRkzJlEVxjILjMsNqM;

	private readonly HardwareControllerMap_Game uTGplbsVYTMDlCKzDIsOCLBLnbfV;

	private bool lAaBHedJbuvwEfCRliMVzlIExzSz;

	private bool aeLenRbmQNmBOHaXClJBdpxCpVarE;

	public InputSource inputSource => InputSource.Custom;

	public HardwareControllerMap_Game hardwareMap => uTGplbsVYTMDlCKzDIsOCLBLnbfV;

	public int axisCount => akMLpjOlowLRkzJlEVxjILjMsNqM.axisCount;

	public int buttonCount => akMLpjOlowLRkzJlEVxjILjMsNqM.buttonCount;

	public Controller.Extension controllerExtension => akMLpjOlowLRkzJlEVxjILjMsNqM.controllerExtension;

	public tPGRFTYXuGFqwLQBERoDOsedxtCo(CustomPlatformUnifiedControllerSource P_0, HardwareControllerMap_Game P_1)
	{
		akMLpjOlowLRkzJlEVxjILjMsNqM = P_0;
		uTGplbsVYTMDlCKzDIsOCLBLnbfV = P_1;
	}

	public void Clear()
	{
		akMLpjOlowLRkzJlEVxjILjMsNqM.AbLqzOKOPDndaRMMTQhJwiXDtUGL();
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		akMLpjOlowLRkzJlEVxjILjMsNqM.xmVbKGcRxTkaqdrLifmxudGjifGhA(dataUpdater);
	}

	public void VrJMCCroCPHwrBSAEKbVbvzKcbSOA()
	{
		akMLpjOlowLRkzJlEVxjILjMsNqM.FUhmfiizGwEZuqiuEbTshvrJIaUg();
	}

	protected virtual void tZafKdTNeneizGSmRWFYbdkgdTGV(bool P_0)
	{
		if (!aeLenRbmQNmBOHaXClJBdpxCpVarE)
		{
			if (P_0 && akMLpjOlowLRkzJlEVxjILjMsNqM != null)
			{
				((IDisposable)akMLpjOlowLRkzJlEVxjILjMsNqM).Dispose();
			}
			aeLenRbmQNmBOHaXClJBdpxCpVarE = true;
		}
	}

	void IDisposable.Dispose()
	{
		tZafKdTNeneizGSmRWFYbdkgdTGV(true);
		GC.SuppressFinalize(this);
	}
}
