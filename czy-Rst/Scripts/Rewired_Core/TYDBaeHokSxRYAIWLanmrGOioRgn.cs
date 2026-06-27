using System;
using Rewired;
using Rewired.Platforms.Custom;

internal abstract class TYDBaeHokSxRYAIWLanmrGOioRgn : IDisposable
{
	protected readonly CustomPlatformUnifiedControllerSource AtPWoOFFssfqKkRgJGuGhnZFLhSo;

	private readonly HardwareControllerMap_Game UCJBOGjqIRDcDTocWZznjnhEtHDu;

	private bool PMxmAHMbjwZIoPUVkVDgIwKBFBge;

	private bool WJMCBgzHGFeumbiKqWOkOsLgxnDk;

	public InputSource inputSource => InputSource.Custom;

	public HardwareControllerMap_Game hardwareMap => UCJBOGjqIRDcDTocWZznjnhEtHDu;

	public int axisCount => AtPWoOFFssfqKkRgJGuGhnZFLhSo.axisCount;

	public int buttonCount => AtPWoOFFssfqKkRgJGuGhnZFLhSo.buttonCount;

	public Controller.Extension controllerExtension => AtPWoOFFssfqKkRgJGuGhnZFLhSo.controllerExtension;

	public TYDBaeHokSxRYAIWLanmrGOioRgn(CustomPlatformUnifiedControllerSource P_0, HardwareControllerMap_Game P_1)
	{
		AtPWoOFFssfqKkRgJGuGhnZFLhSo = P_0;
		UCJBOGjqIRDcDTocWZznjnhEtHDu = P_1;
	}

	public void Clear()
	{
		AtPWoOFFssfqKkRgJGuGhnZFLhSo.asIiBfHTHRVEEKEBYfXgRSlCDJsGA();
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		AtPWoOFFssfqKkRgJGuGhnZFLhSo.TyYrjtrolJgHCgWOfulWXTkspBgv(dataUpdater);
	}

	public void lGMbHviaOFCRZPbJVAugACVZhJmcA()
	{
		AtPWoOFFssfqKkRgJGuGhnZFLhSo.fLeJRZzlMmItIttvHcwPIpFQjamcA();
	}

	protected virtual void BrxhYCSFqtuNLRXfAgDdUxGpVveu(bool P_0)
	{
		if (!WJMCBgzHGFeumbiKqWOkOsLgxnDk)
		{
			if (P_0 && AtPWoOFFssfqKkRgJGuGhnZFLhSo != null)
			{
				((IDisposable)AtPWoOFFssfqKkRgJGuGhnZFLhSo).Dispose();
			}
			WJMCBgzHGFeumbiKqWOkOsLgxnDk = true;
		}
	}

	void IDisposable.Dispose()
	{
		BrxhYCSFqtuNLRXfAgDdUxGpVveu(true);
		GC.SuppressFinalize(this);
	}
}
