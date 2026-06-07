using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_MapScene_Shop_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_RerollProc_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Shop_Popup _003C_003E4__this;

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
		public _003CCR_RerollProc_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003CCR_ShowShopProc_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Shop_Popup _003C_003E4__this;

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
		public _003CCR_ShowShopProc_003Ed__31(int _003C_003E1__state)
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
	[Header("卡片產生的Parent node")]
	private Transform node_Cards;

	[SerializeField]
	[Header("卡片顯示動畫的interval")]
	private float showCardInterval;

	[SerializeField]
	private UI_RelicList ui_RelicList;

	[SerializeField]
	private List<Transform> list_CardNodes;

	[SerializeField]
	private List<Transform> list_Tables;

	[SerializeField]
	private List<Obj_UI_ItemPrice> list_ItemPrices;

	[SerializeField]
	private ShopMapNodeData currentMapNodeData;

	[SerializeField]
	private Obj_UI_ItemPrice obj_RerollPrice;

	[SerializeField]
	private Button button_Reroll;

	[SerializeField]
	private UI_Obj_ShopCard card_Heal;

	[FormerlySerializedAs("price_Heal")]
	[SerializeField]
	private Obj_UI_ItemPrice obj_HealPrice;

	[SerializeField]
	private Image image_Cat;

	[Header("已產生的卡片")]
	[SerializeField]
	private List<UI_Obj_ShopCard> list_Cards;

	[SerializeField]
	private Button button_Leave;

	private int rerollCost;

	private int initialRerollCost;

	private int rerollCostIncrease;

	private float rerollCooldown;

	private float rerollCooldownTimer;

	private List<int> list_SoldIndex;

	private const int HP_RECOVER_VALUE = 3;

	private bool isShowWindowProcDone;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void OnGemChanged(int value)
	{
	}

	private void OnClickButton_Reroll()
	{
	}

	private void OnClickButton_Leave()
	{
	}

	public void SetupContent(ShopMapNodeData mapNodeData)
	{
	}

	private int GetOriginalCost(AItemSettingData data)
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CCR_RerollProc_003Ed__29))]
	private IEnumerator CR_RerollProc()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ShowShopProc_003Ed__31))]
	private IEnumerator CR_ShowShopProc()
	{
		return null;
	}

	private int GetCostIncludingDiscount(UI_Obj_ShopCard card)
	{
		return 0;
	}

	private void OnCardClickedCallback(UI_Obj_ShopCard card)
	{
	}

	private void OnHealCardClickedCallback(UI_Obj_ShopCard card)
	{
	}

	private void ClearContent()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void GenerateShopContent(ShopMapNodeData shopNodeData, bool isReroll)
	{
	}

	public override void OnTriggerKeybind(string keyName)
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

	private void RebuildNavigationAndSelect(Selectable prioritizedSelectable = null)
	{
	}
}
