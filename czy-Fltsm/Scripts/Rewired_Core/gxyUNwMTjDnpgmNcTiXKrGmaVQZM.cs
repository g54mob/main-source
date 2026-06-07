using System;
using Rewired.Platforms.Custom;

internal static class gxyUNwMTjDnpgmNcTiXKrGmaVQZM
{
	private static CustomPlatformInitOptions ldJAlkDGjUBcqecvFfrbFnjhJNIIe;

	public static int JlQentdyeDYMGsjxDqznOlTsakrz
	{
		get
		{
			if (ldJAlkDGjUBcqecvFfrbFnjhJNIIe == null)
			{
				return -1;
			}
			return ldJAlkDGjUBcqecvFfrbFnjhJNIIe.platformId;
		}
	}

	public static bool FWiaKwjEYfoyrcIdbeowyEloYCbFb => JlQentdyeDYMGsjxDqznOlTsakrz != -1;

	public static void dFknvQbtiyoWVPOTjDbaCBHNJAxJ(CustomPlatformInitOptions P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (FWiaKwjEYfoyrcIdbeowyEloYCbFb)
		{
			throw new Exception("Already initialized");
		}
		pMCsczIlWzkcGiPsbcFKlTzczYaR(P_0);
		ldJAlkDGjUBcqecvFfrbFnjhJNIIe = P_0;
	}

	public static void iGNyRlGMJDGeBiHCPJInNjZhfWLoA()
	{
		ldJAlkDGjUBcqecvFfrbFnjhJNIIe = null;
	}

	internal static int ImCNEZmqzqHBHITZoQTfAHKaYrnp()
	{
		if (ldJAlkDGjUBcqecvFfrbFnjhJNIIe == null)
		{
			return -1;
		}
		return ldJAlkDGjUBcqecvFfrbFnjhJNIIe.platformId;
	}

	internal static string YQaxbzZPfzhiJHjkDMPSupdMvcNu()
	{
		if (ldJAlkDGjUBcqecvFfrbFnjhJNIIe == null)
		{
			return null;
		}
		return ldJAlkDGjUBcqecvFfrbFnjhJNIIe.platformIdentifierString;
	}

	internal static IHardwareJoystickMapCustomPlatformMapProvider zipUKuWWUnfReUmmxvIdkMxTAHxe()
	{
		if (ldJAlkDGjUBcqecvFfrbFnjhJNIIe == null)
		{
			return null;
		}
		return ldJAlkDGjUBcqecvFfrbFnjhJNIIe.hardwareJoystickMapCustomPlatformMapProvider;
	}

	internal static CustomInputSource FTMFMsJgMfnRvBfeRitWDnminwnXb()
	{
		if (ldJAlkDGjUBcqecvFfrbFnjhJNIIe == null)
		{
			return null;
		}
		return ldJAlkDGjUBcqecvFfrbFnjhJNIIe.inputSource;
	}

	internal static CustomPlatformConfigVars yKWrMAwAuneSAgNNdMZteJdOGmVl()
	{
		if (ldJAlkDGjUBcqecvFfrbFnjhJNIIe == null)
		{
			return null;
		}
		return ldJAlkDGjUBcqecvFfrbFnjhJNIIe.configVars;
	}

	private static void pMCsczIlWzkcGiPsbcFKlTzczYaR(CustomPlatformInitOptions P_0)
	{
		if (P_0.platformId == -1)
		{
			throw new Exception("customPlatformId is invalid.");
		}
		if (string.IsNullOrEmpty(P_0.platformIdentifierString))
		{
			throw new Exception("platformIdentifierString is invalid.");
		}
		if (P_0.inputSource == null)
		{
			throw new Exception("inputSource cannot be null.");
		}
		if (P_0.hardwareJoystickMapCustomPlatformMapProvider == null)
		{
			throw new Exception("hardwareJoystickMapCustomPlatformMapProvider cannot be null.");
		}
	}
}
