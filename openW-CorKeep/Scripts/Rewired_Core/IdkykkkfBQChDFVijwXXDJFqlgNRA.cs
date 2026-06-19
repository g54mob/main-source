using System;
using Rewired;
using Rewired.Platforms.Custom;

internal abstract class IdkykkkfBQChDFVijwXXDJFqlgNRA : IDisposable
{
	protected readonly CustomPlatformUnifiedControllerSource NiewOIuNTsiIPphCjuQbJPWRLKtu;

	private readonly HardwareControllerMap_Game XekAKSOQzXfIEDGYoiHUDXsUmwaWA;

	private bool GSQogVfPUaVbjWOgWKdRowtVDsRR;

	private bool NohDUySffPbEruVsYcaBkqWupAaYA;

	public InputSource inputSource => InputSource.Custom;

	public HardwareControllerMap_Game hardwareMap => XekAKSOQzXfIEDGYoiHUDXsUmwaWA;

	public int axisCount => NiewOIuNTsiIPphCjuQbJPWRLKtu.axisCount;

	public int buttonCount => NiewOIuNTsiIPphCjuQbJPWRLKtu.buttonCount;

	public Controller.Extension controllerExtension => NiewOIuNTsiIPphCjuQbJPWRLKtu.controllerExtension;

	public IdkykkkfBQChDFVijwXXDJFqlgNRA(CustomPlatformUnifiedControllerSource P_0, HardwareControllerMap_Game P_1)
	{
		NiewOIuNTsiIPphCjuQbJPWRLKtu = P_0;
		XekAKSOQzXfIEDGYoiHUDXsUmwaWA = P_1;
	}

	public void Clear()
	{
		NiewOIuNTsiIPphCjuQbJPWRLKtu.lNdLRvibkDoWXDnjqpcNbZoCmnRj();
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		NiewOIuNTsiIPphCjuQbJPWRLKtu.SgttIvWYILdcHjIcNXirfznqodXh(dataUpdater);
	}

	public void oFpVdjVtxBKxUElfpPSLutCFqvFm()
	{
		NiewOIuNTsiIPphCjuQbJPWRLKtu.uTJJzLAfNgFJTuNpbUcoujMYHPFm();
	}

	protected virtual void IpIMRGnfVnjnIQvJynYYwNNnOkHL(bool P_0)
	{
		if (!NohDUySffPbEruVsYcaBkqWupAaYA)
		{
			if (P_0 && NiewOIuNTsiIPphCjuQbJPWRLKtu != null)
			{
				((IDisposable)NiewOIuNTsiIPphCjuQbJPWRLKtu).Dispose();
			}
			NohDUySffPbEruVsYcaBkqWupAaYA = true;
		}
	}

	void IDisposable.Dispose()
	{
		IpIMRGnfVnjnIQvJynYYwNNnOkHL(true);
		GC.SuppressFinalize(this);
	}
}
