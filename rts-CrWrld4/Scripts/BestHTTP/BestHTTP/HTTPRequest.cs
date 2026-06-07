using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BestHTTP.Authentication;
using BestHTTP.Connections;
using BestHTTP.Cookies;
using BestHTTP.Forms;
using BestHTTP.Logger;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls;
using BestHTTP.Timings;

namespace BestHTTP
{
	public sealed class HTTPRequest : IEnumerator, IEnumerator<HTTPRequest>, IDisposable
	{
		internal struct UploadStreamInfo
		{
			public readonly Stream Stream;

			public readonly long Length;

			public UploadStreamInfo(Stream stream, long length)
			{
				Stream = null;
				Length = 0L;
			}
		}

		public static readonly byte[] EOL;

		public static readonly string[] MethodNames;

		public static int UploadChunkSize;

		public OnUploadProgressDelegate OnUploadProgress;

		public OnStreamingDataDelegate OnStreamingData;

		public Action<HTTPRequest, HTTPResponse> OnHeadersReceived;

		public OnDownloadProgressDelegate OnDownloadProgress;

		private List<Cookie> customCookies;

		private HTTPRequestStates _state;

		private OnBeforeRedirectionDelegate onBeforeRedirection;

		private OnBeforeHeaderSendDelegate _onBeforeHeaderSend;

		internal OnRequestFinishedDelegate OnUpgraded;

		internal Action<HTTPRequest> OnCancellationRequested;

		private bool isKeepAlive;

		private bool disableCache;

		private bool cacheOnly;

		private int streamFragmentSize;

		private bool useStreaming;

		private HTTPFormBase FieldCollector;

		private HTTPFormBase FormImpl;

		public Uri Uri { get; set; }

		public HTTPMethods MethodType { get; set; }

		public byte[] RawData { get; set; }

		public Stream UploadStream { get; set; }

		public bool DisposeUploadStream { get; set; }

		public bool UseUploadStreamLength { get; set; }

		public bool IsKeepAlive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DisableCache
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CacheOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int StreamFragmentSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool StreamChunksImmediately { get; set; }

		public int ReadBufferSizeOverride { get; set; }

		public int MaxFragmentQueueLength { get; set; }

		public OnRequestFinishedDelegate Callback { get; set; }

		public DateTime QueuedAt { get; internal set; }

		public bool IsConnectTimedOut => false;

		public DateTime ProcessingStarted { get; internal set; }

		public bool IsTimedOut => false;

		public int Retries { get; internal set; }

		public int MaxRetries { get; set; }

		public bool IsCancellationRequested { get; internal set; }

		public bool IsRedirected { get; internal set; }

		public Uri RedirectUri { get; internal set; }

		public Uri CurrentUri => null;

		public HTTPResponse Response { get; internal set; }

		public HTTPResponse ProxyResponse { get; internal set; }

		public Exception Exception { get; internal set; }

		public object Tag { get; set; }

		public Credentials Credentials { get; set; }

		public bool HasProxy => false;

		public Proxy Proxy { get; set; }

		public int MaxRedirects { get; set; }

		public bool UseAlternateSSL { get; set; }

		public bool IsCookiesEnabled { get; set; }

		public List<Cookie> Cookies
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public HTTPFormUsage FormUsage { get; set; }

		public HTTPRequestStates State
		{
			get
			{
				return default(HTTPRequestStates);
			}
			internal set
			{
			}
		}

		public int RedirectCount { get; internal set; }

		public TimeSpan ConnectTimeout { get; set; }

		public TimeSpan Timeout { get; set; }

		public bool EnableTimoutForStreaming { get; set; }

		public bool EnableSafeReadOnUnknownContentLength { get; set; }

		public ICertificateVerifyer CustomCertificateVerifyer { get; set; }

		public IClientCredentialsProvider CustomClientCredentialsProvider { get; set; }

		public List<string> CustomTLSServerNameList { get; set; }

		public LoggingContext Context { get; private set; }

		public TimingCollector Timing { get; private set; }

		internal SupportedProtocols ProtocolHandler { get; set; }

		internal bool UseStreaming => false;

		internal long UploadStreamLength => 0L;

		private Dictionary<string, List<string>> Headers { get; set; }

		public object Current => null;

		HTTPRequest IEnumerator<HTTPRequest>.Current => null;

		public event Func<HTTPRequest, X509Certificate, X509Chain, bool> CustomCertificationValidator
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnBeforeRedirectionDelegate OnBeforeRedirection
		{
			add
			{
			}
			remove
			{
			}
		}

		public event OnBeforeHeaderSendDelegate OnBeforeHeaderSend
		{
			add
			{
			}
			remove
			{
			}
		}

		public HTTPRequest(Uri uri)
		{
		}

		public HTTPRequest(Uri uri, OnRequestFinishedDelegate callback)
		{
		}

		public HTTPRequest(Uri uri, bool isKeepAlive, OnRequestFinishedDelegate callback)
		{
		}

		public HTTPRequest(Uri uri, bool isKeepAlive, bool disableCache, OnRequestFinishedDelegate callback)
		{
		}

		public HTTPRequest(Uri uri, HTTPMethods methodType)
		{
		}

		public HTTPRequest(Uri uri, HTTPMethods methodType, OnRequestFinishedDelegate callback)
		{
		}

		public HTTPRequest(Uri uri, HTTPMethods methodType, bool isKeepAlive, OnRequestFinishedDelegate callback)
		{
		}

		public HTTPRequest(Uri uri, HTTPMethods methodType, bool isKeepAlive, bool disableCache, OnRequestFinishedDelegate callback)
		{
		}

		public void AddField(string fieldName, string value)
		{
		}

		public void AddField(string fieldName, string value, Encoding e)
		{
		}

		public void AddBinaryData(string fieldName, byte[] content)
		{
		}

		public void AddBinaryData(string fieldName, byte[] content, string fileName)
		{
		}

		public void AddBinaryData(string fieldName, byte[] content, string fileName, string mimeType)
		{
		}

		public void SetForm(HTTPFormBase form)
		{
		}

		public List<HTTPFieldData> GetFormFields()
		{
			return null;
		}

		public void ClearForm()
		{
		}

		private HTTPFormBase SelectFormImplementation()
		{
			return null;
		}

		public void AddHeader(string name, string value)
		{
		}

		public void SetHeader(string name, string value)
		{
		}

		public bool RemoveHeader(string name)
		{
			return false;
		}

		public bool HasHeader(string name)
		{
			return false;
		}

		public string GetFirstHeaderValue(string name)
		{
			return null;
		}

		public List<string> GetHeaderValues(string name)
		{
			return null;
		}

		public void RemoveHeaders()
		{
		}

		public void SetRangeHeader(long firstBytePos)
		{
		}

		public void SetRangeHeader(long firstBytePos, long lastBytePos)
		{
		}

		public void EnumerateHeaders(OnHeaderEnumerationDelegate callback)
		{
		}

		public void EnumerateHeaders(OnHeaderEnumerationDelegate callback, bool callBeforeSendCallback)
		{
		}

		private void SendHeaders(Stream stream)
		{
		}

		public string DumpHeaders()
		{
			return null;
		}

		public byte[] GetEntityBody()
		{
			return null;
		}

		internal UploadStreamInfo GetUpStream()
		{
			return default(UploadStreamInfo);
		}

		internal void SendOutTo(Stream stream)
		{
		}

		internal void UpgradeCallback()
		{
		}

		internal bool CallOnBeforeRedirection(Uri redirectUri)
		{
			return false;
		}

		internal void Prepare()
		{
		}

		internal bool CallCustomCertificationValidator(X509Certificate cert, X509Chain chain)
		{
			return false;
		}

		public HTTPRequest Send()
		{
			return null;
		}

		public void Abort()
		{
		}

		public void Clear()
		{
		}

		private void VerboseLogging(string str)
		{
		}

		public bool MoveNext()
		{
			return false;
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}
	}
}
