using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace KevinIglesias
{
	public class HumanSoldierController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CChangingWeapons_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HumanSoldierController _003C_003E4__this;

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
			public _003CChangingWeapons_003Ed__9(int _003C_003E1__state)
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

		public Animator animator;

		public SoldierWeapons equippedWeapon;

		public SoldierPosition position;

		public SoldierAction action;

		public SoldierMovement movement;

		public GameObject[] weapons;

		private IEnumerator changingWeaponsCoroutine;

		private int currentWeapon;

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CChangingWeapons_003Ed__9))]
		private IEnumerator ChangingWeapons()
		{
			return null;
		}

		public void ChangeWeapon(SoldierWeapons newWeapon)
		{
		}
	}
}
