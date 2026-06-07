using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class FetchConcreteItem_Job : ActorJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__9 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public FetchConcreteItem_Job _003C_003E4__this;

			private Inventory _003Cinventory_003E5__2;

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
			public _003CGetActivities_003Ed__9(int _003C_003E1__state)
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
		private int _itemId;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _targetItem;

		[PersistenceOptIn]
		private int _position;

		private FetchConcreteItem_Job()
		{
		}

		public FetchConcreteItem_Job(GameObjectX source)
		{
		}

		public FetchConcreteItem_Job(GameObjectX source, GameItem item, int? position = null)
		{
		}

		public FetchConcreteItem_Job(GameObjectX source, int id)
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

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__9))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		public void ReplaceTargetItem(GameItem newItem)
		{
		}
	}
}
