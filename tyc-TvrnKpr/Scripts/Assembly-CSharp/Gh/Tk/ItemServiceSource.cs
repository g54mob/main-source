using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class ItemServiceSource : ItemProvider
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass25_0
		{
			public GameItem item;

			internal bool _003CServe_003Eb__0(GameItem x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CServe_003Ed__25 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private FetchItem_Job job;

			public FetchItem_Job _003C_003E3__job;

			public ItemServiceSource _003C_003E4__this;

			private GameItemTemplate template;

			public GameItemTemplate _003C_003E3__template;

			private _003C_003Ec__DisplayClass25_0 _003C_003E8__1;

			private Actor actor;

			public Actor _003C_003E3__actor;

			private bool _003CisNewItem_003E5__2;

			private Job _003CtempJob_003E5__3;

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
			public _003CServe_003Ed__25(int _003C_003E1__state)
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

		public static HashSet<ItemServiceSource> AllItemServiceSources;

		public bool autoReplace;

		protected Inventory _inventory;

		protected Replaceable _replaceable;

		public GameObject SpawnPoint;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public GameItemTemplate Template { get; private set; }

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		private void OnIsDeadChanged(object sender, EventArgs<bool> e)
		{
		}

		private void OnIsBrokenChanged(object sender, EventArgs<bool> e)
		{
		}

		private void OnPostBuilt()
		{
		}

		private void OnInventoryChanged()
		{
		}

		protected virtual bool NeedsReplacing()
		{
			return false;
		}

		public void ChangeItemTemplate(GameItemTemplate template)
		{
		}

		private void RefreshTavernMenuForItem(GameItemTemplate template)
		{
		}

		private void SetItemLogo(GameItemTemplate template)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public bool IsReplacingInProgress(GameItemTemplate template)
		{
			return false;
		}

		protected virtual Job CreateOrGetReplaceJob()
		{
			return null;
		}

		public override bool CanProvide(GameItemTemplate template, long amount, bool restrictToContainer)
		{
			return false;
		}

		public override float GetRating(GameItemTemplate template, int amount, bool includePlaceholderItems = false)
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CServe_003Ed__25))]
		public virtual IEnumerable<Activity> Serve(FetchItem_Job job, GameItemTemplate template, Actor actor)
		{
			return null;
		}

		public override void OnDestroy()
		{
		}
	}
}
