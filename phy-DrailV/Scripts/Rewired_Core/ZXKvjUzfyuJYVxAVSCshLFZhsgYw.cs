using System;
using Rewired;
using Rewired.Platforms.Custom;

internal abstract class ZXKvjUzfyuJYVxAVSCshLFZhsgYw : IDisposable
{
	protected readonly CustomPlatformUnifiedControllerSource mVGfEDJkBUWwIPTCEuHOmMoilJMqA;

	private readonly HardwareControllerMap_Game tZIuQAjrHYWwCXVWSchyGqJusgzf;

	private bool WJWNBZpPjOCteEdGMEuIvQYhEYWqA;

	private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

	public InputSource inputSource => InputSource.Custom;

	public HardwareControllerMap_Game hardwareMap => tZIuQAjrHYWwCXVWSchyGqJusgzf;

	public int axisCount => mVGfEDJkBUWwIPTCEuHOmMoilJMqA.axisCount;

	public int buttonCount => mVGfEDJkBUWwIPTCEuHOmMoilJMqA.buttonCount;

	public Controller.Extension controllerExtension => mVGfEDJkBUWwIPTCEuHOmMoilJMqA.controllerExtension;

	public ZXKvjUzfyuJYVxAVSCshLFZhsgYw(CustomPlatformUnifiedControllerSource P_0, HardwareControllerMap_Game P_1)
	{
		mVGfEDJkBUWwIPTCEuHOmMoilJMqA = P_0;
		tZIuQAjrHYWwCXVWSchyGqJusgzf = P_1;
	}

	public void Clear()
	{
		mVGfEDJkBUWwIPTCEuHOmMoilJMqA.CqcLWLPcoljiIapBMxavaEZwQtbB();
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		mVGfEDJkBUWwIPTCEuHOmMoilJMqA.uCTfSYfhTsfpmeiPwfdAzCZjMcOMA(dataUpdater);
	}

	public void TlzckGoQDITHcUYaslQXPQBOhTwq()
	{
		mVGfEDJkBUWwIPTCEuHOmMoilJMqA.TlzckGoQDITHcUYaslQXPQBOhTwq();
	}

	protected virtual void IqfGwssNeOuHmhjiKHsCvtuZOnrU(bool P_0)
	{
		if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
		{
			if (P_0 && mVGfEDJkBUWwIPTCEuHOmMoilJMqA != null)
			{
				((IDisposable)mVGfEDJkBUWwIPTCEuHOmMoilJMqA).Dispose();
			}
			wFtxnVROnubhehGUBaPWAtQsiPAD = true;
		}
	}

	void IDisposable.Dispose()
	{
		IqfGwssNeOuHmhjiKHsCvtuZOnrU(true);
		GC.SuppressFinalize(this);
	}
}
