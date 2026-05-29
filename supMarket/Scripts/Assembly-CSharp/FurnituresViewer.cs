using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.Computer;
using __Project__.Scripts.ControllerInputModule;

public class FurnituresViewer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedGamepadCheck_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FurnituresViewer _003C_003E4__this;

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
		public _003CDelayedGamepadCheck_003Ed__13(int _003C_003E1__state)
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

	[Header("UI")]
	[SerializeField]
	private Transform m_ProductsContent;

	[SerializeField]
	private FurnitureSalesItem m_FurnitureSalesItemPrefab;

	[Header("Components")]
	[SerializeField]
	private MarketShoppingCart m_ShoppingCart;

	[SerializeField]
	private WindowTab m_tab;

	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	private List<FurnitureSalesItem> m_ShelvesSalesItems;

	private Computer m_computerRef;

	public MarketShoppingCart ShoppingCart => null;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void SpawnFurnitures()
	{
	}

	private void GamepadCheck()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedGamepadCheck_003Ed__13))]
	private IEnumerator DelayedGamepadCheck()
	{
		return null;
	}

	private void InstantGamepadCheck()
	{
	}
}
