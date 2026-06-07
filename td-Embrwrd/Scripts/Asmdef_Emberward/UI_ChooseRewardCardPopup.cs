using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_ChooseRewardCardPopup : APopupWindow
{
	public enum eUpgradeType
	{
		NONE = 0,
		AddTowerSlot = 1,
		HandDrawIncrease = 2,
		AddExp = 3,
		AddGold = 4
	}

	[CompilerGenerated]
	private sealed class _003CCR_DelayedCloseWindow_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ChooseRewardCardPopup _003C_003E4__this;

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
		public _003CCR_DelayedCloseWindow_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003CCR_SelectedAnimProc_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Obj_StageUpgradeItem item;

		public UI_ChooseRewardCardPopup _003C_003E4__this;

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
		public _003CCR_SelectedAnimProc_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003CCR_ShowWindowProc_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ChooseRewardCardPopup _003C_003E4__this;

		public eStageRewardType rewardType;

		public bool isReroll;

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
		public _003CCR_ShowWindowProc_003Ed__27(int _003C_003E1__state)
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

	[SerializeField]
	[FormerlySerializedAs("list_CardNodes")]
	private List<Transform> list_CardNodes_Odd;

	[SerializeField]
	private List<Transform> list_CardNodes_Even;

	private List<UI_Obj_ShopCard> list_Cards;

	private List<UI_Obj_ShopCard> list_PreviewCards;

	[SerializeField]
	private Transform node_Center;

	[SerializeField]
	private ParticleSystem particle_SelectedEffect;

	[SerializeField]
	private GameObject node_ShowDeckButton;

	[SerializeField]
	private GameObject node_TowerLoadoutButton;

	[SerializeField]
	private Button button_Reroll;

	[SerializeField]
	private UI_Button_Reroll ui_Button_Reroll;

	[SerializeField]
	private UI_RelicList ui_RelicList;

	[SerializeField]
	private CanvasGroup canvasGroup_Preview;

	[SerializeField]
	private Transform node_PreviewCardAnchor;

	private eStageRewardType curStageRewardType;

	private List<AItemSettingData> list_CurrentItems;

	private List<AItemSettingData> list_PreviewItems;

	private bool isSelected;

	private bool isCreatedPreview;

	private float timeSinceWindowOpened;

	protected override void ShowWindowProc()
	{
	}

	private void Update()
	{
	}

	private List<AItemSettingData> ReorganizePreviewItemData(List<AItemSettingData> list_PreviewItemData)
	{
		return null;
	}

	public void Setup(eStageRewardType rewardType, List<AItemSettingData> list_ItemData, List<AItemSettingData> list_PreviewItemData = null)
	{
	}

	private void RebuildNavigationAndSelect(bool isReroll)
	{
	}

	public void OnClickButton_Reroll()
	{
	}

	private void Reroll(eStageRewardType rewardType)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__27))]
	private IEnumerator CR_ShowWindowProc(eStageRewardType rewardType, bool isReroll = false)
	{
		return null;
	}

	private List<AItemSettingData> GetSettingData(eCardType cardType)
	{
		return null;
	}

	private void OnCardClickedCallback(UI_Obj_ShopCard targetCard)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedCloseWindow_003Ed__30))]
	private IEnumerator CR_DelayedCloseWindow()
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SelectedAnimProc_003Ed__32))]
	private IEnumerator CR_SelectedAnimProc(UI_Obj_StageUpgradeItem item)
	{
		return null;
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
}
