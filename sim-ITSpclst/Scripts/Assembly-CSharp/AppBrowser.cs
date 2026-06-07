using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AppBrowser : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDisableAnimatorAfterAnimation_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppBrowser _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDisableAnimatorAfterAnimation_003Ed__48(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadingPage_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppBrowser _003C_003E4__this;

		private float _003Calpha_003E5__2;

		private Color _003Ccolor_003E5__3;

		private Color _003CcolorLogo_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CLoadingPage_003Ed__58(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRunDeflautPage_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppBrowser _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CRunDeflautPage_003Ed__44(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Component")]
	public NetworkManager networkManager;

	public NetworkCard pcNetworkCard;

	public ComputerNetwork computerNetwork;

	public NetworkInfo networkInfo;

	public FaskoManager faskoManager;

	public AppBrowserDownloader appBrowserDownloader;

	public CurrentTimeBIOS currentTimeBIOS;

	[Header("Websites Base")]
	public List<AppBrowserWebsite> webAddres;

	[Header("History")]
	public const int MaxHistoryCount = 30;

	public List<AppBrowserBrowsingHistory> browsingHistory;

	[Header("UI")]
	public TMP_InputField addressText;

	public TextMeshProUGUI webTitle;

	public Image logoLoading;

	public Image bgLoading;

	public GameObject ObjectBgLoading;

	public ScrollRect[] ContentScroll;

	[Header("RefresButtonAnimation")]
	public Animator animator;

	[Header("Additional functions after closing the browser")]
	public UnityEvent AdditionalFunctionsAfterCloseApp;

	[Header("Colors")]
	public string darkMainColor;

	public string mainColor;

	public string lightMainColor;

	public string veryLightMainColor;

	public string colorFont;

	[HideInInspector]
	public Color newDarkMainColor;

	[HideInInspector]
	public Color newMainColor;

	[HideInInspector]
	public Color newLightMainColor;

	[HideInInspector]
	public Color newFontColor;

	public Image buttonSearch;

	public Image inputHttps;

	public Image cardColor;

	public Image upLineColor;

	public Image downLineColor;

	public Image FrameColor;

	public Image bgLightInHome;

	public Image[] homeBgButton;

	public TextMeshProUGUI[] colorFonts;

	public bool isOpen;

	public void OpenApp()
	{
	}

	public void OpenApp(string websiteAdress)
	{
	}

	public void SetPaletteCollor()
	{
	}

	public void SetColorPlatteAfterSetupColor()
	{
	}

	public void CloseApp()
	{
	}

	[IteratorStateMachine(typeof(_003CRunDeflautPage_003Ed__44))]
	private IEnumerator RunDeflautPage()
	{
		return null;
	}

	public void EnterLinkBar()
	{
	}

	public void RefreshWebsite()
	{
	}

	public void TriggerAnimation()
	{
	}

	[IteratorStateMachine(typeof(_003CDisableAnimatorAfterAnimation_003Ed__48))]
	private IEnumerator DisableAnimatorAfterAnimation()
	{
		return null;
	}

	public void OpenDeflautPage()
	{
	}

	public void OpenWebsiteByURL(string website)
	{
	}

	public void AddToBrowsingHistory(string url)
	{
	}

	public void OpenWebsite(string address, bool onlyOne = false)
	{
	}

	public static string FormatAddress(string address)
	{
		return null;
	}

	public void OpenWebsiteButton()
	{
	}

	public void OpenWebsiteButtonForObject(string addres)
	{
	}

	public static bool IsIPAddress(string address)
	{
		return false;
	}

	public static string ExtractIPAddress(string address)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CLoadingPage_003Ed__58))]
	public IEnumerator LoadingPage()
	{
		return null;
	}
}
