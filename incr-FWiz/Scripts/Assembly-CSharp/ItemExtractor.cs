using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class ItemExtractor : BuildingBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPassItemsCoroutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ItemExtractor _003C_003E4__this;

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
		public _003CPassItemsCoroutine_003Ed__10(int _003C_003E1__state)
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

	public int RecieverIndex;

	public RadiusProvider RadiusProvider;

	public DropCollector DropCollector;

	public TransferContainer TransferContainer;

	public float ExtractInterval;

	public float ExtractionSpeedModifier;

	public override void SetBuilding(Building building)
	{
	}

	public override void Initiate()
	{
	}

	public override void ClearForDestroy()
	{
	}

	public override List<BuildingSelectorData> GetSelectorTransforms()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CPassItemsCoroutine_003Ed__10))]
	public IEnumerator PassItemsCoroutine()
	{
		return null;
	}

	public void AddSpeedModifier(float speedModifier)
	{
	}

	public bool SourceInRange(ItemExtractionSource source)
	{
		return false;
	}

	public ItemType ExtractNext(ItemType itemType)
	{
		return null;
	}
}
