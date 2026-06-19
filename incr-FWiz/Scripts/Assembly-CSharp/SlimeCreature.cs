using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SlimeCreature : CreatureBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoKill_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SlimeCreature _003C_003E4__this;

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
		public _003CDoKill_003Ed__13(int _003C_003E1__state)
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
	private DamageableCreature damageable;

	[SerializeField]
	private ItemType _dropItemType;

	[SerializeField]
	private float _dropRadius;

	[SerializeField]
	private float _itemDropDuration;

	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private List<Behaviour> _disableOnDeath;

	public int DropCount;

	protected override void OnInitiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnHit(bool finished)
	{
	}

	public void Kill()
	{
	}

	public void CreateItem()
	{
	}

	public void AddDropCount(int count)
	{
	}

	[IteratorStateMachine(typeof(_003CDoKill_003Ed__13))]
	private IEnumerator DoKill()
	{
		return null;
	}
}
