using System;
using System.Collections.Generic;
using AFMiniJSON;
using UnityEngine;

namespace AppsFlyerSDK
{
	public class AppsFlyer : MonoBehaviour
	{
		public delegate void unityCallBack(string message);

		public static readonly string kAppsFlyerPluginVersion = "6.12.22";

		public static string CallBackObjectName = null;

		private static EventHandler onRequestResponse;

		private static EventHandler onInAppResponse;

		private static EventHandler onDeepLinkReceived;

		public static IAppsFlyerNativeBridge instance = null;

		public static event EventHandler OnRequestResponse
		{
			add
			{
				onRequestResponse = (EventHandler)Delegate.Combine(onRequestResponse, value);
			}
			remove
			{
				onRequestResponse = (EventHandler)Delegate.Remove(onRequestResponse, value);
			}
		}

		public static event EventHandler OnInAppResponse
		{
			add
			{
				onInAppResponse = (EventHandler)Delegate.Combine(onInAppResponse, value);
			}
			remove
			{
				onInAppResponse = (EventHandler)Delegate.Remove(onInAppResponse, value);
			}
		}

		public static event EventHandler OnDeepLinkReceived
		{
			add
			{
				onDeepLinkReceived = (EventHandler)Delegate.Combine(onDeepLinkReceived, value);
				subscribeForDeepLink();
			}
			remove
			{
				onDeepLinkReceived = (EventHandler)Delegate.Remove(onDeepLinkReceived, value);
			}
		}

		public static void initSDK(string devKey, string appID)
		{
			initSDK(devKey, appID, null);
		}

		public static void initSDK(string devKey, string appID, MonoBehaviour gameObject)
		{
			if (gameObject != null)
			{
				CallBackObjectName = gameObject.name;
			}
		}

		public static void startSDK()
		{
			if (instance != null)
			{
				instance.startSDK(onRequestResponse != null, CallBackObjectName);
			}
		}

		public static void sendEvent(string eventName, Dictionary<string, string> eventValues)
		{
			if (instance != null)
			{
				instance.sendEvent(eventName, eventValues, onInAppResponse != null, CallBackObjectName);
			}
		}

		public static void stopSDK(bool isSDKStopped)
		{
			if (instance != null)
			{
				instance.stopSDK(isSDKStopped);
			}
		}

		public static bool isSDKStopped()
		{
			if (instance != null)
			{
				return instance.isSDKStopped();
			}
			return false;
		}

		public static string getSdkVersion()
		{
			if (instance != null)
			{
				return instance.getSdkVersion();
			}
			return "";
		}

		public static void setIsDebug(bool shouldEnable)
		{
			if (instance != null)
			{
				instance.setIsDebug(shouldEnable);
			}
		}

		public static void setCustomerUserId(string id)
		{
			if (instance != null)
			{
				instance.setCustomerUserId(id);
			}
		}

		public static void setAppInviteOneLinkID(string oneLinkId)
		{
			if (instance != null)
			{
				instance.setAppInviteOneLinkID(oneLinkId);
			}
		}

		public static void setAdditionalData(Dictionary<string, string> customData)
		{
			if (instance != null)
			{
				instance.setAdditionalData(customData);
			}
		}

		public static void setResolveDeepLinkURLs(params string[] urls)
		{
			if (instance != null)
			{
				instance.setResolveDeepLinkURLs(urls);
			}
		}

		public static void setOneLinkCustomDomain(params string[] domains)
		{
			if (instance != null)
			{
				instance.setOneLinkCustomDomain(domains);
			}
		}

		public static void setCurrencyCode(string currencyCode)
		{
			if (instance != null)
			{
				instance.setCurrencyCode(currencyCode);
			}
		}

		public static void recordLocation(double latitude, double longitude)
		{
			if (instance != null)
			{
				instance.recordLocation(latitude, longitude);
			}
		}

		public static void anonymizeUser(bool shouldAnonymizeUser)
		{
			if (instance != null)
			{
				instance.anonymizeUser(shouldAnonymizeUser);
			}
		}

		public static string getAppsFlyerId()
		{
			if (instance != null)
			{
				return instance.getAppsFlyerId();
			}
			return string.Empty;
		}

		public static void setMinTimeBetweenSessions(int seconds)
		{
			if (instance != null)
			{
				instance.setMinTimeBetweenSessions(seconds);
			}
		}

		public static void setHost(string hostPrefixName, string hostName)
		{
			if (instance != null)
			{
				instance.setHost(hostPrefixName, hostName);
			}
		}

		public static void setUserEmails(EmailCryptType cryptType, params string[] userEmails)
		{
			if (instance != null)
			{
				instance.setUserEmails(cryptType, userEmails);
			}
		}

		public static void updateServerUninstallToken(string token)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).updateServerUninstallToken(token);
			}
		}

		public static void setPhoneNumber(string phoneNumber)
		{
			if (instance != null)
			{
				instance.setPhoneNumber(phoneNumber);
			}
		}

		public static void setImeiData(string aImei)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setImeiData(aImei);
			}
		}

		[Obsolete("Please use setSharingFilterForPartners api")]
		public static void setSharingFilterForAllPartners()
		{
			if (instance != null)
			{
				instance.setSharingFilterForAllPartners();
			}
		}

		public static void setAndroidIdData(string aAndroidId)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setAndroidIdData(aAndroidId);
			}
		}

		public static void waitForCustomerUserId(bool wait)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).waitForCustomerUserId(wait);
			}
		}

		[Obsolete("Please use setSharingFilterForPartners api")]
		public static void setSharingFilter(params string[] partners)
		{
			if (instance != null)
			{
				instance.setSharingFilter(partners);
			}
		}

		public static void setCustomerIdAndStartSDK(string id)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setCustomerIdAndStartSDK(id);
			}
		}

		public static void setSharingFilterForPartners(params string[] partners)
		{
		}

		public static string getOutOfStore()
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				return ((IAppsFlyerAndroidBridge)instance).getOutOfStore();
			}
			return string.Empty;
		}

		public static void setOutOfStore(string sourceName)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setOutOfStore(sourceName);
			}
		}

		public static void getConversionData(string objectName)
		{
			if (instance != null)
			{
				instance.getConversionData(objectName);
			}
		}

		public static void setCollectAndroidID(bool isCollect)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setCollectAndroidID(isCollect);
			}
		}

		public static void setIsUpdate(bool isUpdate)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setIsUpdate(isUpdate);
			}
		}

		public static void setCollectIMEI(bool isCollect)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setCollectIMEI(isCollect);
			}
		}

		public static void setDisableCollectAppleAdSupport(bool disable)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).setDisableCollectAppleAdSupport(disable);
			}
		}

		public static void setShouldCollectDeviceName(bool shouldCollectDeviceName)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).setShouldCollectDeviceName(shouldCollectDeviceName);
			}
		}

		public static void attributeAndOpenStore(string appID, string campaign, Dictionary<string, string> userParams, MonoBehaviour gameObject)
		{
			if (instance != null)
			{
				instance.attributeAndOpenStore(appID, campaign, userParams, gameObject);
			}
		}

		public static void setPreinstallAttribution(string mediaSource, string campaign, string siteId)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setPreinstallAttribution(mediaSource, campaign, siteId);
			}
		}

		public static void setDisableCollectIAd(bool disableCollectIAd)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).setDisableCollectIAd(disableCollectIAd);
			}
		}

		public static bool isPreInstalledApp()
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				return ((IAppsFlyerAndroidBridge)instance).isPreInstalledApp();
			}
			return false;
		}

		public static void setUseReceiptValidationSandbox(bool useReceiptValidationSandbox)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).setUseReceiptValidationSandbox(useReceiptValidationSandbox);
			}
		}

		public static void recordCrossPromoteImpression(string appID, string campaign, Dictionary<string, string> parameters)
		{
			if (instance != null)
			{
				instance.recordCrossPromoteImpression(appID, campaign, parameters);
			}
		}

		public static void setUseUninstallSandbox(bool useUninstallSandbox)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).setUseUninstallSandbox(useUninstallSandbox);
			}
		}

		public static string getAttributionId()
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				return ((IAppsFlyerAndroidBridge)instance).getAttributionId();
			}
			return string.Empty;
		}

		public static void handlePushNotifications()
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).handlePushNotifications();
			}
		}

		public static void validateAndSendInAppPurchase(string productIdentifier, string price, string currency, string tranactionId, Dictionary<string, string> additionalParameters, MonoBehaviour gameObject)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).validateAndSendInAppPurchase(productIdentifier, price, currency, tranactionId, additionalParameters, gameObject);
			}
		}

		public static void validateAndSendInAppPurchase(string publicKey, string signature, string purchaseData, string price, string currency, Dictionary<string, string> additionalParameters, MonoBehaviour gameObject)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).validateAndSendInAppPurchase(publicKey, signature, purchaseData, price, currency, additionalParameters, gameObject);
			}
		}

		public static void handleOpenUrl(string url, string sourceApplication, string annotation)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).handleOpenUrl(url, sourceApplication, annotation);
			}
		}

		public static void registerUninstall(byte[] deviceToken)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).registerUninstall(deviceToken);
			}
		}

		public static void waitForATTUserAuthorizationWithTimeoutInterval(int timeoutInterval)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).waitForATTUserAuthorizationWithTimeoutInterval(timeoutInterval);
			}
		}

		public static void setCurrentDeviceLanguage(string language)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).setCurrentDeviceLanguage(language);
			}
		}

		public static void generateUserInviteLink(Dictionary<string, string> parameters, MonoBehaviour gameObject)
		{
			if (instance != null)
			{
				instance.generateUserInviteLink(parameters, gameObject);
			}
		}

		public static void disableSKAdNetwork(bool isDisabled)
		{
			if (instance != null && instance is IAppsFlyerIOSBridge)
			{
				((IAppsFlyerIOSBridge)instance).disableSKAdNetwork(isDisabled);
			}
		}

		public static void setCollectOaid(bool isCollect)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setCollectOaid(isCollect);
			}
		}

		public static void addPushNotificationDeepLinkPath(params string[] paths)
		{
			if (instance != null)
			{
				instance.addPushNotificationDeepLinkPath(paths);
			}
		}

		public static void setDisableAdvertisingIdentifiers(bool disable)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setDisableAdvertisingIdentifiers(disable);
			}
		}

		public static void subscribeForDeepLink()
		{
			if (instance != null)
			{
				instance.subscribeForDeepLink(CallBackObjectName);
			}
		}

		public static void setPartnerData(string partnerId, Dictionary<string, string> partnerInfo)
		{
			if (instance != null)
			{
				instance.setPartnerData(partnerId, partnerInfo);
			}
		}

		public static void setDisableNetworkData(bool disable)
		{
			if (instance != null && instance is IAppsFlyerAndroidBridge)
			{
				((IAppsFlyerAndroidBridge)instance).setDisableNetworkData(disable);
			}
		}

		public static void disableIDFVCollection(bool isDisabled)
		{
		}

		public void inAppResponseReceived(string response)
		{
			if (onInAppResponse != null)
			{
				onInAppResponse(null, parseRequestCallback(response));
			}
		}

		public void requestResponseReceived(string response)
		{
			if (onRequestResponse != null)
			{
				onRequestResponse(null, parseRequestCallback(response));
			}
		}

		public void onDeepLinking(string response)
		{
			DeepLinkEventsArgs e = new DeepLinkEventsArgs(response);
			if (onDeepLinkReceived != null)
			{
				onDeepLinkReceived(null, e);
			}
		}

		private static AppsFlyerRequestEventArgs parseRequestCallback(string response)
		{
			int code = 0;
			string description = "";
			try
			{
				Dictionary<string, object> dictionary = CallbackStringToDictionary(response);
				description = (string)(dictionary.ContainsKey("errorDescription") ? dictionary["errorDescription"] : "");
				code = (int)(long)dictionary["statusCode"];
			}
			catch (Exception arg)
			{
				AFLog("parseRequestCallback", $"{arg} Exception caught.");
			}
			return new AppsFlyerRequestEventArgs(code, description);
		}

		public static Dictionary<string, object> CallbackStringToDictionary(string str)
		{
			return Json.Deserialize(str) as Dictionary<string, object>;
		}

		public static void AFLog(string methodName, string str)
		{
			Debug.Log($"AppsFlyer_Unity_v{kAppsFlyerPluginVersion} {methodName} called with {str}");
		}
	}
}
