using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.WebViewCore
{
	public abstract class NativeWebViewBase : NativeFeatureInterfaceBase, INativeWebView, INativeFeatureInterface, INativeObject, IDisposable
	{
		public event WebViewInternalCallback OnShow
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

		public event WebViewInternalCallback OnHide
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

		public event WebViewInternalCallback OnLoadStart
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

		public event WebViewInternalCallback OnLoadFinish
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

		public event URLSchemeMatchFoundInternalCallback OnURLSchemeMatchFound
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

		protected NativeWebViewBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract string GetURL();

		public abstract string GetTitle();

		public abstract void SetFrame(Rect value);

		public abstract void SetStyle(WebViewStyle style);

		public abstract void SetScalesPageToFit(bool value);

		public abstract void SetCanBounce(bool value);

		public abstract void SetBackgroundColor(Color value);

		public abstract double GetProgress();

		public abstract bool GetIsLoading();

		public abstract void SetJavaScriptEnabled(bool value);

		public abstract void Show();

		public abstract void Hide();

		public abstract void LoadURL(string url);

		public abstract void LoadHtmlString(string htmlString, string baseURL);

		public abstract void LoadData(byte[] data, string mimeType, string textEncodingName, string baseURL);

		public abstract void Reload();

		public abstract void StopLoading();

		public abstract void RunJavaScript(string script, RunJavaScriptInternalCallback callback);

		public abstract void AddURLScheme(string urlScheme);

		public abstract void ClearCache();

		protected void SendShowEvent(Error error)
		{
		}

		protected void SendHideEvent(Error error)
		{
		}

		protected void SendLoadStartEvent(Error error)
		{
		}

		protected void SendLoadFinishEvent(Error error)
		{
		}

		protected void SendURLSchemeMatchFoundEvent(string url)
		{
		}
	}
}
