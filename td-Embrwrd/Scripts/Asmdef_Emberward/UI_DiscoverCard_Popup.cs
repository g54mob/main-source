using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_DiscoverCard_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_CloseUI_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UI_DiscoverCard_Popup _003C_003E4__this;

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
		public _003CCR_CloseUI_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CCR_GiveCardAnim_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_DiscoverCard_Popup _003C_003E4__this;

		public DiscoverRewardPack cardPackData;

		public UI_Obj_DiscoverRewardPack ui_Obj_DiscoverRewardPack;

		public List<Vector3> list_CardAnchors;

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
		public _003CCR_GiveCardAnim_003Ed__21(int _003C_003E1__state)
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
	private sealed class _003CCR_ShowDiscoverProc_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_DiscoverCard_Popup _003C_003E4__this;

		public List<DiscoverRewardPack> list_Data;

		private int _003Ci_003E5__2;

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
		public _003CCR_ShowDiscoverProc_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003CCR_WickedKeyAnim_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool isSelected;

		public UI_Obj_DiscoverRewardPack cardPack;

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
		public _003CCR_WickedKeyAnim_003Ed__20(int _003C_003E1__state)
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

	[Header("ItemSlot的連結, 飛卡片效果用")]
	[SerializeField]
	private UI_ItemSlot ui_ItemSlot;

	[Header("標題文字")]
	[SerializeField]
	private TMP_Text text_Title;

	[Header("標題文字")]
	[SerializeField]
	private TMP_Text text_Desc;

	[Header("卡片產生的Parent node")]
	[SerializeField]
	private Transform node_Cards;

	[SerializeField]
	[Header("卡片顯示動畫的interval")]
	private float showCardInterval;

	[SerializeField]
	private UI_MapScene_PlayerRerollCount ui_PlayerRerollCount;

	[SerializeField]
	private ParticleSystem particle_CoinRain_100;

	[SerializeField]
	private ParticleSystem particle_CoinRain_10;

	[SerializeField]
	private ParticleSystem particle_CoinRain_1;

	[SerializeField]
	private List<UI_Obj_DiscoverRewardPack> list_DiscoverRewardPacks;

	private bool isSelected;

	private bool isHaveWickedKey;

	private int wickedKeyMainPriceIndex;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	public void SetupContent(List<DiscoverRewardPack> list_Data)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowDiscoverProc_003Ed__18))]
	private IEnumerator CR_ShowDiscoverProc(List<DiscoverRewardPack> list_Data)
	{
		return null;
	}

	private void OnCardClickedCallback(UI_Obj_DiscoverRewardPack ui_Obj_DiscoverRewardPack, DiscoverRewardPack cardPack, List<Vector3> list_CardAnchors)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_WickedKeyAnim_003Ed__20))]
	private IEnumerator CR_WickedKeyAnim(UI_Obj_DiscoverRewardPack cardPack, bool isSelected)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GiveCardAnim_003Ed__21))]
	private IEnumerator CR_GiveCardAnim(UI_Obj_DiscoverRewardPack ui_Obj_DiscoverRewardPack, DiscoverRewardPack cardPackData, List<Vector3> list_CardAnchors)
	{
		return null;
	}

	private void CloseUI(float delay)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CloseUI_003Ed__23))]
	private IEnumerator CR_CloseUI(float delay)
	{
		return null;
	}

	public void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnWindowRegainFocus()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void RebuildNavigationAndSelect()
	{
	}
}
