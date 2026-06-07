using System;
using Rewired.Platforms.Custom;

internal static class xfQMULbDolNOSljfhItZwOwIzFQO
{
	private static CustomPlatformInitOptions BTRQpUgGaOmyqnYvHEXtYXvdezIe;

	public static int KoWxltGMrPwtBkQrjsSOinWhIuLE
	{
		get
		{
			if (BTRQpUgGaOmyqnYvHEXtYXvdezIe == null)
			{
				return -1;
			}
			return BTRQpUgGaOmyqnYvHEXtYXvdezIe.platformId;
		}
	}

	public static bool SYETLKcbFhUFoZVjYnuOpkJSSgOW => KoWxltGMrPwtBkQrjsSOinWhIuLE != -1;

	public static void TlzckGoQDITHcUYaslQXPQBOhTwq(CustomPlatformInitOptions P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (SYETLKcbFhUFoZVjYnuOpkJSSgOW)
		{
			throw new Exception("Already initialized");
		}
		oMKaCjkHAOZcaTzJNvPJIBlouISJ(P_0);
		BTRQpUgGaOmyqnYvHEXtYXvdezIe = P_0;
	}

	public static void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		BTRQpUgGaOmyqnYvHEXtYXvdezIe = null;
	}

	internal static int imRrgdAyYJuHLTvsMecejwmCYKcB()
	{
		if (BTRQpUgGaOmyqnYvHEXtYXvdezIe == null)
		{
			return -1;
		}
		return BTRQpUgGaOmyqnYvHEXtYXvdezIe.platformId;
	}

	internal static string EbPnojGmSIdVpxOuBCKNjblcKeje()
	{
		if (BTRQpUgGaOmyqnYvHEXtYXvdezIe == null)
		{
			return null;
		}
		return BTRQpUgGaOmyqnYvHEXtYXvdezIe.platformIdentifierString;
	}

	internal static IHardwareJoystickMapCustomPlatformMapProvider yfaoAUnZOzlFDDNOaSMvsBPbstKq()
	{
		if (BTRQpUgGaOmyqnYvHEXtYXvdezIe == null)
		{
			return null;
		}
		return BTRQpUgGaOmyqnYvHEXtYXvdezIe.hardwareJoystickMapCustomPlatformMapProvider;
	}

	internal static CustomInputSource MvFScWscrxeEtNjKiqsXvDnglmgC()
	{
		if (BTRQpUgGaOmyqnYvHEXtYXvdezIe == null)
		{
			return null;
		}
		return BTRQpUgGaOmyqnYvHEXtYXvdezIe.inputSource;
	}

	internal static CustomPlatformConfigVars uhvilvmvTTcLTABDCbwhEqTsDJNb()
	{
		if (BTRQpUgGaOmyqnYvHEXtYXvdezIe == null)
		{
			return null;
		}
		return BTRQpUgGaOmyqnYvHEXtYXvdezIe.configVars;
	}

	private static void oMKaCjkHAOZcaTzJNvPJIBlouISJ(CustomPlatformInitOptions P_0)
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
