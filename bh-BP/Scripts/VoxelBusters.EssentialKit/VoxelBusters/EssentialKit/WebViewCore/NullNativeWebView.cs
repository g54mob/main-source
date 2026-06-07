using System;
using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.WebViewCore
{
	internal sealed class NullNativeWebView : NativeWebViewBase, INativeWebView, INativeFeatureInterface, INativeObject, IDisposable
	{
		private string m_url;

		public NullNativeWebView()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override string GetURL()
		{
			return null;
		}

		public override string GetTitle()
		{
			return null;
		}

		public override void SetFrame(Rect value)
		{
		}

		public override void SetStyle(WebViewStyle style)
		{
		}

		public override void SetScalesPageToFit(bool value)
		{
		}

		public override void SetCanBounce(bool value)
		{
		}

		public override void SetBackgroundColor(Color value)
		{
		}

		public override double GetProgress()
		{
			return 0.0;
		}

		public override bool GetIsLoading()
		{
			return false;
		}

		public override void SetJavaScriptEnabled(bool value)
		{
		}

		public override void Show()
		{
		}

		public override void Hide()
		{
		}

		public override void LoadURL(string url)
		{
		}

		public override void LoadHtmlString(string htmlString, string baseURL)
		{
		}

		public override void LoadData(byte[] data, string mimeType, string textEncodingName, string baseURL)
		{
		}

		public override void Reload()
		{
		}

		public override void StopLoading()
		{
		}

		public override void RunJavaScript(string script, RunJavaScriptInternalCallback callback)
		{
		}

		public override void AddURLScheme(string urlScheme)
		{
		}

		public override void ClearCache()
		{
		}

		private void SendLoadEvents()
		{
		}
	}
}
