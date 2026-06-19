using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.Effects;
using UnityEngine;

public class AmalgamationAltar : BuildingBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCompleteCinematic_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AmalgamationAltar _003C_003E4__this;

		private float _003Ctimer_003E5__2;

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
		public _003CCompleteCinematic_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003CIncrement_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AmalgamationAltar _003C_003E4__this;

		private float _003Ctimer_003E5__2;

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
		public _003CIncrement_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003CIncrementSecond_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AmalgamationAltar _003C_003E4__this;

		private float _003Ctimer_003E5__2;

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
		public _003CIncrementSecond_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003CStartLevel_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AmalgamationAltar _003C_003E4__this;

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
		public _003CStartLevel_003Ed__28(int _003C_003E1__state)
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

	public List<AmalgamationAltarLevel> Levels;

	public List<AmalgamationUrn> Urns;

	public int Level;

	private int _urnsCompleted;

	public SimpleFillBar FillBar;

	public SimpleFillBar SecondaryFillBar;

	public ShakeReceiver ShakeReceiver;

	public float DestructionShake;

	public float DestructionShakeTime;

	public float IncrementShake;

	public float IncrementShakeTime;

	public float RevealUrnTime;

	public Building DestroyBuilding;

	public Transform ItemSpawnPosition;

	public ItemType MainItem;

	public float PanDuration;

	public float ZoomModifier;

	public GameObject ItemSpawnShakeSoundEmitter;

	public EventReference ItemSpawnSound;

	public DropCollector DropCollector;

	public CanvasGroup CanvasAlpha;

	public EventReference ItemInsertedSound;

	public EventReference UrnCompletedSound;

	public EventReference UrnsRefreshedSound;

	public override void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void IncrementLevel()
	{
	}

	public void OnFuller()
	{
	}

	[IteratorStateMachine(typeof(_003CStartLevel_003Ed__28))]
	public IEnumerator StartLevel()
	{
		return null;
	}

	public void CreateItem()
	{
	}

	public void OnCompleteUrn()
	{
	}

	[IteratorStateMachine(typeof(_003CIncrement_003Ed__31))]
	public IEnumerator Increment()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CIncrementSecond_003Ed__32))]
	public IEnumerator IncrementSecond()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCompleteCinematic_003Ed__33))]
	public IEnumerator CompleteCinematic()
	{
		return null;
	}

	public bool CanTake(ItemType type)
	{
		return false;
	}

	public void TakeItem(ItemType type)
	{
	}
}
