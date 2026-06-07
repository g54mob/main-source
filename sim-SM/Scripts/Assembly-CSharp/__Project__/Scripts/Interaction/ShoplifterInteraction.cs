using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace __Project__.Scripts.Interaction
{
	public class ShoplifterInteraction : global::Interaction
	{
		[CompilerGenerated]
		private sealed class _003COnUseLoop_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ShoplifterInteraction _003C_003E4__this;

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
			public _003COnUseLoop_003Ed__29(int _003C_003E1__state)
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
		private BaseballBat m_BaseballBat;

		[SerializeField]
		private float m_MaxRaycastDistance;

		[SerializeField]
		private LayerMask m_CustomerInteractionLayer;

		private Camera m_MainCamera;

		private RaycastHit m_Hit;

		private Ray m_Ray;

		private Customer m_CurrentCustomer;

		private ShoplifterTutorialCustomer m_ShoplifterTutorialCustomer;

		private IEnumerator m_OnUseCoroutine;

		private NetworkShoplifterInteraction _networkShoplifterInteraction;

		private bool m_IsOnUse;

		private PlayerInstance m_PlayerInstance;

		public override bool Enable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BaseballBat BaseballBat => null;

		public override IInteractable Interactable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private PlayerInstance PlayerInstance => null;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void CheckForInteraction()
		{
		}

		private void OnUse(bool down)
		{
		}

		private void OnBack()
		{
		}

		[IteratorStateMachine(typeof(_003COnUseLoop_003Ed__29))]
		private IEnumerator OnUseLoop()
		{
			return null;
		}

		private void HitHint(bool show)
		{
		}

		private void DefaultHints(bool show)
		{
		}

		public void BuyBat()
		{
		}
	}
}
