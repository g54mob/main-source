using System;
using UnityEngine;

public class IronSourceAdQuality : CodeGeneratedSingleton
{
	private static GameObject adQualityGameObject;

	private const string TAG = "IronSource AdQuality";

	private const bool DEBUG = false;

	protected override bool DontDestroySingleton => false;

	protected override void InitAfterRegisteringAsSingleInstance()
	{
	}

	public static void Initialize(string appKey)
	{
	}

	public static void Initialize(string appKey, ISAdQualityConfig adQualityConfig)
	{
	}

	private static void Initialize(string appKey, string userId, bool userIdSet, bool testMode, ISAdQualityLogLevel logLevel, string initializationSource, bool coppa, ISAdQualityDeviceIdType deviceIdType, ISAdQualityInitCallback adQualityInitCallback)
	{
	}

	public static void ChangeUserId(string userId)
	{
	}

	[Obsolete("This method has been deprecated and will be removed soon")]
	public static void SetUserConsent(bool userConsent)
	{
	}

	public static void SendCustomMediationRevenue(ISAdQualityCustomMediationRevenue customMediationRevenue)
	{
	}

	public static void setSegment(ISAdQualitySegment segment)
	{
	}
}
