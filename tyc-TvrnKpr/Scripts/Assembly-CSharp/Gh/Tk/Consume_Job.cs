using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class Consume_Job : PatronJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			public Ingredient item;

			public Transform targetTransform;

			internal void _003CGetActivities_003Eb__5()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass15_1
		{
			public IEnumerable<Animator> animators;

			public int j;

			public Action<Animator> _003C_003E9__2;

			public Action<Animator> _003C_003E9__4;

			public Action _003C_003E9__3;

			internal void _003CGetActivities_003Eb__2(Animator x)
			{
			}

			internal void _003CGetActivities_003Eb__3()
			{
			}

			internal void _003CGetActivities_003Eb__4(Animator x)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__15 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Consume_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

			private _003C_003Ec__DisplayClass15_1 _003C_003E8__2;

			private IDisposable _003C_003E7__wrap1;

			private int _003Ci_003E5__3;

			private string _003CcurrentIdleAnimationParam_003E5__4;

			private string _003CcurrentConsumeAnimationParam_003E5__5;

			private string _003CcurrentSub_003E5__6;

			private int _003Crepeat_003E5__7;

			Activity IEnumerator<Activity>.Current
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
			public _003CGetActivities_003Ed__15(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Activity> IEnumerable<Activity>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Ingredient _item;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Ingredient _sideItem;

		[PersistenceOptIn]
		private string _mainItemIdleAnimationParam;

		[PersistenceOptIn]
		private string _mainItemConsumeAnimationParam;

		[PersistenceOptIn]
		private string _sideItemIdleAnimationParam;

		[PersistenceOptIn]
		private string _sideItemConsumeAnimationParam;

		[PersistenceOptIn]
		private bool _sideItemFirst;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _plate;

		private GameItem _currentItem;

		private Consume_Job()
		{
		}

		public Consume_Job(GameObjectX source, Patron owner, Ingredient mainItem, Ingredient sideItem, ActorBehaviour behaviour, string usageKeyOverride, GameItem plate)
		{
		}

		public override bool IsValid()
		{
			return false;
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		public override void Start()
		{
		}

		private void OwnerOnSpawnedItemAdded(object sender, EventArgs<GameObjectX.SpawnedItem> e)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__15))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnAbortedInternal()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		public void DestroyConsumables()
		{
		}

		internal override void ForceCompleteReset(bool removeOwner = true, bool forceDestroy = false)
		{
		}

		public override void ForceDestroy(bool destroyParentToo = false)
		{
		}
	}
}
