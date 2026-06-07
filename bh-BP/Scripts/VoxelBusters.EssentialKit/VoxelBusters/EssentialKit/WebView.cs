using System.Runtime.CompilerServices;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;
using VoxelBusters.EssentialKit.WebViewCore;

namespace VoxelBusters.EssentialKit
{
	public sealed class WebView : NativeFeatureBehaviour
	{
		[SerializeField]
		private bool m_autoShowOnLoadFinish;

		[SerializeField]
		private bool m_scalesPageToFit;

		[SerializeField]
		private bool m_canBounce;

		[SerializeField]
		private bool m_javascriptEnabled;

		[SerializeField]
		private WebViewStyle m_style;

		[SerializeField]
		private Rect m_frame;

		[SerializeField]
		private Color m_backgroundColor;

		private INativeWebView m_nativeInterface;

		private WebViewUnitySettings m_settings;

		public static WebViewUnitySettings GlobalSettings { get; private set; }

		public WebViewUnitySettings Settings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string URL => null;

		public string Title => null;

		public Rect Frame
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		public WebViewStyle Style
		{
			get
			{
				return default(WebViewStyle);
			}
			set
			{
			}
		}

		public bool AutoShowOnLoadFinish
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ScalesPageToFit
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CanBounce
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public double Progress => 0.0;

		public bool IsLoading => false;

		public bool JavaScriptEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static event Callback<WebView> OnShow
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

		public static event Callback<WebView> OnHide
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

		public static event Callback<WebView> OnLoadStart
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

		public static event EventCallback<WebView> OnLoadFinish
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

		public static event Callback<string> OnURLSchemeMatchFound
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

		public static void Initialize(WebViewUnitySettings globalSettings)
		{
		}

		public static WebView CreateInstance(WebViewUnitySettings settings = null)
		{
			return null;
		}

		protected override void AwakeInternal(object[] args)
		{
		}

		protected override void StartInternal()
		{
		}

		protected override void DestroyInternal()
		{
		}

		public override bool IsAvailable()
		{
			return false;
		}

		protected override string GetFeatureName()
		{
			return null;
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void LoadURL(URLString url)
		{
		}

		public void LoadHtmlString(string htmlString, URLString? baseURL = null)
		{
		}

		public void LoadData(byte[] data, string mimeType, string textEncodingName, URLString? baseURL = null)
		{
		}

		public void Reload()
		{
		}

		public void StopLoading()
		{
		}

		public void RunJavaScript(string script, EventCallback<WebViewRunJavaScriptResult> callback)
		{
		}

		public void AddURLScheme(string urlScheme)
		{
		}

		public void ClearCache()
		{
		}

		private void RegisterForEvents()
		{
		}

		private void UnregisterFromEvents()
		{
		}

		private void HandleOnWebViewShow(Error error)
		{
		}

		private void HandleOnWebViewHide(Error error)
		{
		}

		private void HandleOnWebViewLoadStart(Error error)
		{
		}

		private void HandleOnWebViewLoadFinish(Error error)
		{
		}

		private void HandleOnURLSchemeMatchFound(string url)
		{
		}
	}
}
