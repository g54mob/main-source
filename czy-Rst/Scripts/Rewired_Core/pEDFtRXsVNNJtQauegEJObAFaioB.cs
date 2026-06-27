using System;
using Rewired.Platforms.Custom;

internal static class pEDFtRXsVNNJtQauegEJObAFaioB
{
	private static CustomPlatformInitOptions osxOlBqaGOXTUsnAEHhODygApzU;

	public static int OupvxepflTwTrLhYoAopbWNFIRID
	{
		get
		{
			if (osxOlBqaGOXTUsnAEHhODygApzU == null)
			{
				return -1;
			}
			return osxOlBqaGOXTUsnAEHhODygApzU.platformId;
		}
	}

	public static bool SINAvtVjZlMAWkyjXPhqxZwrawWF => OupvxepflTwTrLhYoAopbWNFIRID != -1;

	public static void eXXFjFsopcMTgpXMWkContYkxnYH(CustomPlatformInitOptions P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (SINAvtVjZlMAWkyjXPhqxZwrawWF)
		{
			throw new Exception("Already initialized");
		}
		uRdoheBYZbIFdWWcQaGOYscBiNPH(P_0);
		osxOlBqaGOXTUsnAEHhODygApzU = P_0;
	}

	public static void bccVwZBOWHAqBvQvmzbVIIAUgepc()
	{
		osxOlBqaGOXTUsnAEHhODygApzU = null;
	}

	internal static int DynAIOvVkeijqmfLPTonhcDDzTKw()
	{
		if (osxOlBqaGOXTUsnAEHhODygApzU == null)
		{
			return -1;
		}
		return osxOlBqaGOXTUsnAEHhODygApzU.platformId;
	}

	internal static string TPRxckMyavAmjfoXmmAeXsRdSkhb()
	{
		if (osxOlBqaGOXTUsnAEHhODygApzU == null)
		{
			return null;
		}
		return osxOlBqaGOXTUsnAEHhODygApzU.platformIdentifierString;
	}

	internal static IHardwareJoystickMapCustomPlatformMapProvider wtSSMzPWPhPTFiKeMUYjXeXiscIr()
	{
		if (osxOlBqaGOXTUsnAEHhODygApzU == null)
		{
			return null;
		}
		return osxOlBqaGOXTUsnAEHhODygApzU.hardwareJoystickMapCustomPlatformMapProvider;
	}

	internal static CustomInputSource KLjCudzFOhpKWViCoIdECpHUEPOE()
	{
		if (osxOlBqaGOXTUsnAEHhODygApzU == null)
		{
			return null;
		}
		return osxOlBqaGOXTUsnAEHhODygApzU.inputSource;
	}

	internal static CustomPlatformConfigVars hYzbfBaltlBGzLWZYxxdgRcpUoyEA()
	{
		if (osxOlBqaGOXTUsnAEHhODygApzU == null)
		{
			return null;
		}
		return osxOlBqaGOXTUsnAEHhODygApzU.configVars;
	}

	private static void uRdoheBYZbIFdWWcQaGOYscBiNPH(CustomPlatformInitOptions P_0)
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
