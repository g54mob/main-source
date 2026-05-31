using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMove : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COnOffSwitchButtonCoroutine_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public Action<bool> setter;

		public Image bgDotAirplaneMode;

		public SettingsMove _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

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
		public _003COnOffSwitchButtonCoroutine_003Ed__57(int _003C_003E1__state)
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
	private sealed class _003COnOffSwitchButtonCoroutineShow_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public Image bgDotAirplaneMode;

		public SettingsMove _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

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
		public _003COnOffSwitchButtonCoroutineShow_003Ed__58(int _003C_003E1__state)
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

	public GameObject settingsView;

	public ComputerVariables computerVariables;

	public AppBrowser appBrowser;

	public bool isCoroutineEnded;

	public Coroutine turnonofButtonCoroutine;

	[Header("Category")]
	public GameObject[] blueLine;

	public GameObject[] viewObject;

	public int categoryID;

	[Header("Profil")]
	public Image mainAvatar;

	public TextMeshProUGUI mail;

	[Header("Avatar")]
	public int avatarID;

	public Sprite[] avatarList;

	public GameObject[] blueAvatarChoice;

	public GameObject ChoseAvatarView;

	[Header("Prywatność")]
	public RectTransform dotPrivacySendNoTrack;

	public Image bgDotPrivacySendNoTrack;

	public RectTransform dotPrivacyAllowSites;

	public Image bgDotPrivacyAllowSites;

	public RectTransform dotPrivacyHelpImproveProducts;

	public Image bgDotPrivacyHelpImproveProducts;

	public RectTransform dotPrivacyHelpImproveProductsSecound;

	public Image bgDotPrivacyHelpImproveProductsSecound;

	public bool PrivacySendNoTrack;

	public bool PrivacyAllowSites;

	public bool PrivacyHelpImproveProducts;

	public bool PrivacyHelpImproveProductsSecound;

	public bool PrivacyisClearDataBrowser;

	[Header("History")]
	public Transform historyContainer;

	public Transform historyPrefabs;

	public Transform historyList;

	[Header("Colors Paltete")]
	public string[] darkMainColor;

	public string[] mainColor;

	public string[] lightMainColor;

	public string[] FontColor;

	[Header("Color Def")]
	public string hexColorBlue;

	public string hexColorLightGray;

	public Color newColorBlue;

	public Color newColorLightGray;

	[Header("Language")]
	public RectTransform dotLanguageTransplatePage;

	public Image bgDotLanguageTransplatePage;

	public RectTransform dotLanguageGrammaAssist;

	public Image bgDotLanguageGrammaAssist;

	public RectTransform dotLanguageTextSuggestions;

	public Image bgDotLanguageTextSuggestions;

	public bool LanguageTransplatePage;

	public bool LanguageGrammaAssist;

	public bool LanguageTextSuggestions;

	[Header("MidAds - Information")]
	public RectTransform dotMidAdsMeteredConnections;

	public Image bgDotMidAdsMeteredConnections;

	public bool downloadWithMeteredConnections;

	public void SetPaletteCollor()
	{
	}

	public void OpenSettings()
	{
	}

	public void CloseSettings()
	{
	}

	public void ResetAllBlueLine()
	{
	}

	public void SetBlueLine(int id)
	{
	}

	public void ResetAllView()
	{
	}

	public void OpenView(int id)
	{
	}

	[IteratorStateMachine(typeof(_003COnOffSwitchButtonCoroutine_003Ed__57))]
	public IEnumerator OnOffSwitchButtonCoroutine(RectTransform obj, float fromX, float toX, float time, Action<bool> setter, Image bgDotAirplaneMode, bool closedNow = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003COnOffSwitchButtonCoroutineShow_003Ed__58))]
	public IEnumerator OnOffSwitchButtonCoroutineShow(RectTransform obj, float fromX, float toX, float time, Image bgDotAirplaneMode, bool closedNow = false)
	{
		return null;
	}

	public void ProfilView()
	{
	}

	public void ViewPrivacy()
	{
	}

	public void ClearBrowsingData()
	{
	}

	public void TurnOnOrOffPrivacySendNoTrack()
	{
	}

	public void TurnOnOrOffPrivacyAllowSites()
	{
	}

	public void TurnOnOrOffPrivacyHelpImproveProducts()
	{
	}

	public void TurnOnOrOffPrivacyHelpImproveProductsSecound()
	{
	}

	public void ViewHistory()
	{
	}

	public void RenderHisotryList(List<AppBrowserBrowsingHistory> history)
	{
	}

	public void SetPalette(int id)
	{
	}

	public void EditAvatar()
	{
	}

	public void CloseEditAvatar()
	{
	}

	public void ResetBlueFrameForAvatar()
	{
	}

	public void SetAvatar(int id)
	{
	}

	public void ViewLanguage()
	{
	}

	public void TurnOnOrOffLanguageTransplatePage()
	{
	}

	public void TurnOnOrOffLanguageGrammaAssist()
	{
	}

	public void TurnOnOrOffLanguageTextSuggestions()
	{
	}

	public void ViewMidAdsInformation()
	{
	}

	public void TurnOnOrOffMidAdsMeteredConnections()
	{
	}
}
