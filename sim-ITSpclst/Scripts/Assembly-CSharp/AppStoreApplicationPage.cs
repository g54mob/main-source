using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppStoreApplicationPage : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEnumRefreshUI_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppStoreApplicationPage _003C_003E4__this;

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
		public _003CEnumRefreshUI_003Ed__42(int _003C_003E1__state)
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

	[Header("Components")]
	public AppBase appBase;

	public AppStoreSetupManager appStoreSetupManager;

	public appExplorer appExplorer;

	public ComputerDesktop computerDesktop;

	public AppStoreBase appStoreBase;

	[Header("UI")]
	public ScrollRect ScrollRect;

	public TMP_Text NameApplication;

	public Image IconApplication;

	public TMP_Text TitleDescriptionApplication;

	public TMP_Text IconAppPublisherName;

	public TMP_Text IconAppStarAverageAndCount;

	public RectTransform[] ButtonsSetup;

	public TMP_Text BoxSetupProgressView;

	public Image[] Screenshots;

	public TMP_Text ContentDescriptionApplication;

	public TMP_Text ContentAverageRate;

	public TMP_Text ContentTotalRate;

	public Image[] ContentStarValueBar;

	public TMP_Text ContentOpinionName;

	public Image[] ContentStarOpinion;

	public TMP_Text ContentOpinionDescription;

	public TMP_Text ContentOpinionLike;

	public TMP_Text ContentOpinionDislike;

	public RectTransform[] ApplicationAvailableView;

	public TMP_Text ContentAdditionalInformationPublisher;

	public TMP_Text ContentAdditionalInformationReleaseDate;

	public TMP_Text ContentAdditionalInformationCategory;

	public TMP_Text ContentAdditionalInformationSizeApp;

	[Header("Star Icons")]
	public Sprite starOutlineTexture;

	public Sprite starFilledTexture;

	public Sprite star075Texture;

	public Sprite star050Texture;

	public Sprite star025Texture;

	[HideInInspector]
	public AppStoreBaseData nowOpenApplication;

	private Coroutine taskRefreshUI;

	public static string GetDescription(Enum value)
	{
		return null;
	}

	public void ButtonSetup()
	{
	}

	public void ButtonOpenApp()
	{
	}

	public void ButtonShortcut()
	{
	}

	public void ButtonUninstall()
	{
	}

	public void ButtonOpenDir()
	{
	}

	public void ButtonCancel()
	{
	}

	[IteratorStateMachine(typeof(_003CEnumRefreshUI_003Ed__42))]
	private IEnumerator EnumRefreshUI()
	{
		return null;
	}

	public void OpenApplication(AppStoreBaseData application)
	{
	}

	public float MathProgressBarByRate(AppStoreBaseData application, int idStar)
	{
		return 0f;
	}

	public static string FloatToCustomString(float value)
	{
		return null;
	}
}
