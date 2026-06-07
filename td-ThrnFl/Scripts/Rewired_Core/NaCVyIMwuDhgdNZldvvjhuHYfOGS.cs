using System;
using Rewired;
using Rewired.Platforms.Custom;

internal static class NaCVyIMwuDhgdNZldvvjhuHYfOGS
{
	private static CustomPlatformInitOptions OShSOEQwkSaplZIaHfPKcrWzXFPtA;

	public static int cikgKJFkhBbVZIMcnSHCOMqAqcggb
	{
		get
		{
			if (OShSOEQwkSaplZIaHfPKcrWzXFPtA == null)
			{
				return -1;
			}
			return OShSOEQwkSaplZIaHfPKcrWzXFPtA.platformId;
		}
	}

	public static bool gWMFbUBERbzpcApqKNWTmCSqQImmA => cikgKJFkhBbVZIMcnSHCOMqAqcggb != -1;

	public static void SfQSLorWxgpuGqWHHrSXKyQlHXeE(CustomPlatformInitOptions P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (gWMFbUBERbzpcApqKNWTmCSqQImmA)
		{
			throw new Exception("Already initialized");
		}
		gCFFhANnuxteczhpYwJBbFrZLkep();
		CjymBVYAVdFnPbFpPJpfBhIEqStMA(P_0);
		OShSOEQwkSaplZIaHfPKcrWzXFPtA = P_0;
	}

	public static void XPlvqLUQYNcpUqjFjekMhKyLBQWU()
	{
		gCFFhANnuxteczhpYwJBbFrZLkep();
		OShSOEQwkSaplZIaHfPKcrWzXFPtA = null;
	}

	internal static int vIiQfjcmuuUGYvEOUihSgEvEnnyWA()
	{
		if (OShSOEQwkSaplZIaHfPKcrWzXFPtA == null)
		{
			return -1;
		}
		return OShSOEQwkSaplZIaHfPKcrWzXFPtA.platformId;
	}

	internal static string bfUYAJLLcdCnQKqrtJljgsAhkoOuB()
	{
		if (OShSOEQwkSaplZIaHfPKcrWzXFPtA == null)
		{
			return null;
		}
		return OShSOEQwkSaplZIaHfPKcrWzXFPtA.platformIdentifierString;
	}

	internal static IHardwareJoystickMapCustomPlatformMapProvider IPCvKUvFdjaxbdlDxXOcwjtCTek()
	{
		if (OShSOEQwkSaplZIaHfPKcrWzXFPtA == null)
		{
			return null;
		}
		return OShSOEQwkSaplZIaHfPKcrWzXFPtA.hardwareJoystickMapCustomPlatformMapProvider;
	}

	internal static CustomInputSource wFianIaqXxOUiTKvbzZlHnJJMgwUA()
	{
		if (OShSOEQwkSaplZIaHfPKcrWzXFPtA == null)
		{
			return null;
		}
		return OShSOEQwkSaplZIaHfPKcrWzXFPtA.inputSource;
	}

	internal static CustomPlatformConfigVars HJsKmaqdYjlHXDInJwuQuCHoYyED()
	{
		if (OShSOEQwkSaplZIaHfPKcrWzXFPtA == null)
		{
			return null;
		}
		return OShSOEQwkSaplZIaHfPKcrWzXFPtA.configVars;
	}

	private static void gCFFhANnuxteczhpYwJBbFrZLkep()
	{
		if (ReInput.isReady)
		{
			throw new Exception("Custom platform be changed while Rewired is initialized.");
		}
	}

	private static void CjymBVYAVdFnPbFpPJpfBhIEqStMA(CustomPlatformInitOptions P_0)
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
