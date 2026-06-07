using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_WaitForTwitchUsernameAndShowSuccess_003Ed__55 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_WaitForTwitchUsernameAndShowSuccess_003Ed__55(int _003C_003E1__state)
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

	public static readonly OptionType[][] OptionsByFilter;

	[NamedArray(typeof(SettingsFilter))]
	public CoolButton[] FilterBtns;

	public OverlayUI Owner;

	public SettingsFilter CurFilter;

	public SerializedObjectPool<SettingsItem> ItemPool;

	public GameObject WrapperLanguages;

	public CoolSelectableWrapper LanguagesSelectable;

	public GridLayoutGroup LanguageGrid;

	public ScrollRect ScrlSettings;

	public CoolButtonGroup SettingsGrp;

	public CoolSelectableWrapper SettingsWrapper;

	private List<Resolution> _resolutionList;

	public List<string> ResolutionStr;

	private int _curResolutionIdx;

	public GameObject WrapperRemap;

	public CoolSelectableWrapper RemapSelectable;

	private SettingsItem _selectedSettingsItem;

	private SettingsRemapItem _selectedRemapItem;

	private int _selectedRemapIdx;

	private float _remapSelectTime;

	public SerializedObjectPool<SettingsRemapItem> RemapItemPool;

	public Transform WrapperRemapHeaderGame;

	public Transform WrapperRemapHeaderBase;

	public Transform WrapperRemapHeaderHarvest;

	public Transform RemapResetSpacer;

	public CoolButton BtnRemapReset;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void Init()
	{
	}

	private void MyUpdate()
	{
	}

	public void CancelCurRemap()
	{
	}

	private void SelectBtnForRemap(ControllerPollingInfo pollInfo)
	{
	}

	private void OnGrpEntered(CoolButton btn)
	{
	}

	private void OnGrpNav(CoolButton prevBtn, CoolButton newBtn)
	{
	}

	public void SetFilter(SettingsFilter filt)
	{
	}

	public SettingsItem GetItem(OptionType opt)
	{
		return null;
	}

	public bool OnCloseClicked()
	{
		return false;
	}

	public void SetLanguagesActive(bool isOn)
	{
	}

	private void InitRemapItem(GameActionType action, Pole axisContrib = Pole.Positive)
	{
	}

	public void SetRemapActive(bool isOn)
	{
	}

	private void OnGeneralClicked()
	{
	}

	private void OnVideoClicked()
	{
	}

	private void OnAudioClicked()
	{
	}

	private void OnTwitchClicked()
	{
	}

	public void SetResolutionIdx(int idx)
	{
	}

	public int GetCurResolutionIdx()
	{
		return 0;
	}

	private void OnFontTypeChanged()
	{
	}

	private void OnLanguageChanged()
	{
	}

	public bool IsRemapping()
	{
		return false;
	}

	public void SelectRemapItem(SettingsRemapItem item, int idx)
	{
	}

	private void OnInputTypeChanged()
	{
	}

	private void OnResetRemapClicked()
	{
	}

	private void OnResolutionChanged()
	{
	}

	public void OnTwitchAuthenticated()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitForTwitchUsernameAndShowSuccess_003Ed__55))]
	private IEnumerator<float> _WaitForTwitchUsernameAndShowSuccess()
	{
		return null;
	}
}
