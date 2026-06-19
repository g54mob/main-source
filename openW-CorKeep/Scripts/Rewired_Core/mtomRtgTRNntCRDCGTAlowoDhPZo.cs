using System;
using Rewired.Platforms.Custom;

internal static class mtomRtgTRNntCRDCGTAlowoDhPZo
{
	private static CustomPlatformInitOptions hFRPvvagPYhwONGJgIiMCapuwGGlA;

	public static int ZLGJvaSvYTcOiQFBKGoGCRHFLhlnA
	{
		get
		{
			if (hFRPvvagPYhwONGJgIiMCapuwGGlA == null)
			{
				return -1;
			}
			return hFRPvvagPYhwONGJgIiMCapuwGGlA.platformId;
		}
	}

	public static bool BxgHUpymmvRaFbsNhjtTNtpbaJviA => ZLGJvaSvYTcOiQFBKGoGCRHFLhlnA != -1;

	public static void hhclSRBEysiNfguOmMzNJLKeUdfG(CustomPlatformInitOptions P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (BxgHUpymmvRaFbsNhjtTNtpbaJviA)
		{
			throw new Exception("Already initialized");
		}
		fJYVcgqOwdbcaJUWmOKdwFbTrXat(P_0);
		hFRPvvagPYhwONGJgIiMCapuwGGlA = P_0;
	}

	public static void sHNnRsoonDsypoWmYMFIcTXKiZFr()
	{
		hFRPvvagPYhwONGJgIiMCapuwGGlA = null;
	}

	internal static int MPCYEQIOFiwHbvJzrDCGBEARYslq()
	{
		if (hFRPvvagPYhwONGJgIiMCapuwGGlA == null)
		{
			return -1;
		}
		return hFRPvvagPYhwONGJgIiMCapuwGGlA.platformId;
	}

	internal static string IuwQjqroVfRyluGOIAArtKvpEzDfA()
	{
		if (hFRPvvagPYhwONGJgIiMCapuwGGlA == null)
		{
			return null;
		}
		return hFRPvvagPYhwONGJgIiMCapuwGGlA.platformIdentifierString;
	}

	internal static IHardwareJoystickMapCustomPlatformMapProvider nHjQWlufwlhNQzeEihcAhtYesXns()
	{
		if (hFRPvvagPYhwONGJgIiMCapuwGGlA == null)
		{
			return null;
		}
		return hFRPvvagPYhwONGJgIiMCapuwGGlA.hardwareJoystickMapCustomPlatformMapProvider;
	}

	internal static CustomInputSource NnOiOlKnipoPFMRQMAqlgzaSVflP()
	{
		if (hFRPvvagPYhwONGJgIiMCapuwGGlA == null)
		{
			return null;
		}
		return hFRPvvagPYhwONGJgIiMCapuwGGlA.inputSource;
	}

	internal static CustomPlatformConfigVars kHAxsVMKSduhaBgnaBVGvUjfwTTm()
	{
		if (hFRPvvagPYhwONGJgIiMCapuwGGlA == null)
		{
			return null;
		}
		return hFRPvvagPYhwONGJgIiMCapuwGGlA.configVars;
	}

	private static void fJYVcgqOwdbcaJUWmOKdwFbTrXat(CustomPlatformInitOptions P_0)
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
