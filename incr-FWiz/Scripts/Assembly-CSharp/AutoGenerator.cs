using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AutoGenerator : BuildingBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGenerateEnumerator_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AutoGenerator _003C_003E4__this;

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
		public _003CGenerateEnumerator_003Ed__9(int _003C_003E1__state)
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
	private ItemType _itemType;

	public StorageContainer StorageContainer;

	[SerializeField]
	private float _generationTime;

	private float _generationRateModifier;

	private float _generationTimer;

	[SerializeField]
	private CrafterFueler crafterFueler;

	[SerializeField]
	private AutoGeneratorAnimator _animator;

	public override void SetBuilding(Building building)
	{
	}

	public override void Initiate()
	{
	}

	[IteratorStateMachine(typeof(_003CGenerateEnumerator_003Ed__9))]
	public IEnumerator GenerateEnumerator()
	{
		return null;
	}

	public void AddCapacity(int capacity)
	{
	}

	public void AddGenerationSpeed(float speed)
	{
	}
}
