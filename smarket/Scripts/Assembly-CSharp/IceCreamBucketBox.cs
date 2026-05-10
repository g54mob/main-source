using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;

public class IceCreamBucketBox : Box, IRestockerPlacingIntervalMultiplier
{
	[CompilerGenerated]
	private sealed class _003CBeginInteractionDelayed_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IceCreamBucketBox _003C_003E4__this;

		public PlayerInstance player;

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
		public _003CBeginInteractionDelayed_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003CBeginInteractionDelayed_Local_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IceCreamBucketBox _003C_003E4__this;

		public PlayerInstance player;

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
		public _003CBeginInteractionDelayed_Local_003Ed__28(int _003C_003E1__state)
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

	private NetworkIceCreamBox m_NetworkIceCreamBox;

	private IceCreamFlavourData m_FlavourData;

	private IceCreamBucket m_Bucket;

	private Tween m_BoxToggleAnimation;

	private NetworkIceCreamBox NetworkIceCreamBox => null;

	public IceCreamBucket Bucket => null;

	float IRestockerPlacingIntervalMultiplier.Multiplier => 0f;

	public int LastConsumed { get; private set; }

	public override bool HasProducts => false;

	public override bool Full => false;

	protected override void Initialize()
	{
	}

	public void SetData(IceCreamFlavourData value)
	{
	}

	public void SetDataNetwork(IceCreamFlavourData value)
	{
	}

	private void SetDataInternal(IceCreamFlavourData value)
	{
	}

	public override void NetworkInitialize()
	{
	}

	public override void SpawnProducts(bool loadFromData = false)
	{
	}

	public void BeginBucketInteraction(PlayerInstance player = null)
	{
	}

	public override Product GetProductFromBox(bool fromPlayer)
	{
		return null;
	}

	public override void OpenBox(PlayerInstance pickedPlayer)
	{
	}

	public override void OpenBox()
	{
	}

	[IteratorStateMachine(typeof(_003CBeginInteractionDelayed_Local_003Ed__28))]
	private IEnumerator BeginInteractionDelayed_Local(PlayerInstance player = null)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CBeginInteractionDelayed_003Ed__29))]
	private IEnumerator BeginInteractionDelayed(PlayerInstance player = null)
	{
		return null;
	}

	public void PurgeBucket()
	{
	}

	public void ToggleBox(bool value)
	{
	}

	public void AssignBucketNetwork(IceCreamBucket bucket)
	{
	}
}
