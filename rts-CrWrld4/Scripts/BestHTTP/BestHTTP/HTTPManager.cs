using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using BestHTTP.Connections.HTTP2;
using BestHTTP.Extensions;
using BestHTTP.Logger;
using BestHTTP.PlatformSupport.FileSystem;
using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls;
using UnityEngine;

namespace BestHTTP
{
	[Il2CppEagerStaticClassConstruction]
	public static class HTTPManager
	{
		public static HTTP2PluginSettings HTTP2Settings;

		private static byte maxConnectionPerServer;

		private static HeartbeatManager heartbeats;

		private static BestHTTP.Logger.ILogger logger;

		public static TlsClientFactoryDelegate TlsClientFactory;

		public static int? SendBufferSize;

		public static int? ReceiveBufferSize;

		public static IIOService IOService;

		public static string UserAgent;

		private static bool IsSetupCalled;

		public static byte MaxConnectionPerServer
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static bool KeepAliveDefaultValue { get; set; }

		public static bool IsCachingDisabled { get; set; }

		public static TimeSpan MaxConnectionIdleTime { get; set; }

		public static bool IsCookiesEnabled { get; set; }

		public static uint CookieJarSize { get; set; }

		public static bool EnablePrivateBrowsing { get; set; }

		public static TimeSpan ConnectTimeout { get; set; }

		public static TimeSpan RequestTimeout { get; set; }

		public static Func<string> RootCacheFolderProvider { get; set; }

		public static Proxy Proxy { get; set; }

		public static HeartbeatManager Heartbeats => null;

		public static BestHTTP.Logger.ILogger Logger
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static ICertificateVerifyer DefaultCertificateVerifyer { get; set; }

		public static IClientCredentialsProvider DefaultClientCredentialsProvider { get; set; }

		public static bool UseAlternateSSLDefaultValue { get; set; }

		public static Func<HTTPRequest, X509Certificate, X509Chain, bool> DefaultCertificationValidator { get; set; }

		internal static int MaxPathLength { get; set; }

		public static bool IsQuitting { get; private set; }

		static HTTPManager()
		{
		}

		public static AbstractTlsClient DefaultTlsClientFactory(HTTPRequest request, List<string> protocols)
		{
			return null;
		}

		public static void Setup()
		{
		}

		public static HTTPRequest SendRequest(string url, OnRequestFinishedDelegate callback)
		{
			return null;
		}

		public static HTTPRequest SendRequest(string url, HTTPMethods methodType, OnRequestFinishedDelegate callback)
		{
			return null;
		}

		public static HTTPRequest SendRequest(string url, HTTPMethods methodType, bool isKeepAlive, OnRequestFinishedDelegate callback)
		{
			return null;
		}

		public static HTTPRequest SendRequest(string url, HTTPMethods methodType, bool isKeepAlive, bool disableCache, OnRequestFinishedDelegate callback)
		{
			return null;
		}

		public static HTTPRequest SendRequest(HTTPRequest request)
		{
			return null;
		}

		public static string GetRootCacheFolder()
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod]
		public static void ResetSetup()
		{
		}

		public static void OnUpdate()
		{
		}

		public static void OnQuit()
		{
		}

		public static void AbortAll()
		{
		}
	}
}
