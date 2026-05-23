internal class IFRqbyNUwbeoLuQrDXlfXbkASFD : yoBcmQfgFIKVVURwqaiPlYRIeyr
{
	public override XqPQWVQCzoiUVqNxOwUOrPFfeBF DeviceType
	{
		get
		{
			return XqPQWVQCzoiUVqNxOwUOrPFfeBF.dNyyENhbShZpwawrFNHGUzXrCYg;
		}
	}

	public IFRqbyNUwbeoLuQrDXlfXbkASFD(gFpppwTpWdVCaaYhbVuNcAuyuRH nativeGameController, XYitobKpIgOpWUmHymAwqjSLOet joystickInfo)
		: base(nativeGameController, joystickInfo, XlOvDxbPTBSXeduTQZBtlQzXSZe.dNyyENhbShZpwawrFNHGUzXrCYg, 15, 6, 0, 0)
	{
	}

	public override bool IsAttached()
	{
		if (DujrGGkUjSQZvwNDHjOWZEXWGTD == null || !DujrGGkUjSQZvwNDHjOWZEXWGTD.IsValid)
		{
			return false;
		}
		return VuTGCVdtQMXPEMCKcnDOxWAgDee.JSVDdeaWNvmglRVjysVRAllNCiVO(DujrGGkUjSQZvwNDHjOWZEXWGTD);
	}

	protected override void InitializeHaptic()
	{
		if (base.IsValid)
		{
			MPIErwTOhperpArWhutZeBNKLzz(new dmKUPPBTIjpWsLWFEmbcbKrKfGk(VuTGCVdtQMXPEMCKcnDOxWAgDee.BsMEkRNGWNcSiMDGIBSVugtyqns(DujrGGkUjSQZvwNDHjOWZEXWGTD)));
		}
	}

	protected override void CloseDevice()
	{
		if (DujrGGkUjSQZvwNDHjOWZEXWGTD == null)
		{
			return;
		}
		if (!DujrGGkUjSQZvwNDHjOWZEXWGTD.IsValid)
		{
			while (true)
			{
				switch (0x49DC4AAC ^ 0x49DC4AAD)
				{
				case 2:
					break;
				case 1:
					return;
				case 3:
					goto end_IL_0015;
				default:
					goto IL_005a;
				}
				continue;
				end_IL_0015:
				break;
			}
		}
		if (!IsAttached())
		{
			DujrGGkUjSQZvwNDHjOWZEXWGTD.Clear();
			return;
		}
		goto IL_005a;
		IL_005a:
		VuTGCVdtQMXPEMCKcnDOxWAgDee.TlitWzmLKtQNVhWMyIqWjBOvC(DujrGGkUjSQZvwNDHjOWZEXWGTD);
		DujrGGkUjSQZvwNDHjOWZEXWGTD.Clear();
	}
}
