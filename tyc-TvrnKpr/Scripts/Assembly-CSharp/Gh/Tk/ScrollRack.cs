using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Gh.Tk
{
	public class ScrollRack : Prop
	{
		public class PaperConfig
		{
			public string key;

			public string nameKey;

			public int price;

			public int stars;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass35_0
		{
			public ScrollRack _003C_003E4__this;

			public Action onSelectCallback;
		}

		[CompilerGenerated]
		private sealed class _003CGetPaperSelectionMenuItems_003Ed__35 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ScrollRack _003C_003E4__this;

			private Action onSelectCallback;

			public Action _003C_003E3__onSelectCallback;

			private _003C_003Ec__DisplayClass35_0 _003C_003E8__1;

			private PaperConfig[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
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
			public _003CGetPaperSelectionMenuItems_003Ed__35(int _003C_003E1__state)
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
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private Transform[] _paperScrolls;

		private Transform[] _paperHeaders;

		private const int maxScrolls = 15;

		public static readonly PaperConfig[] PaperConfigs;

		[PersistenceOptIn]
		public string SelectedPaperKey { get; private set; }

		[PersistenceOptIn]
		public int ScrollsRemaining { get; private set; }

		[PersistenceOptIn]
		public string CurrentPaperKey { get; private set; }

		public PaperConfig SelectedPaperConfig => null;

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		private void TimeController_HourChanged(object sender, EventArgs e)
		{
		}

		public void RestockPapers(float priceFactor = 1f)
		{
		}

		private void InvalidateVisual()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public int GetRestockPrice()
		{
			return 0;
		}

		public IEnumerable<PaperConfig> GetAvailablePapers()
		{
			return null;
		}

		public override bool CanUse(Actor actor, bool ignoreMaintenanceState = false, bool ignoreWhenBroken = false)
		{
			return false;
		}

		public void SelectPaper(PaperConfig paper)
		{
		}

		public override float GetEffectiveQuality(string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public override void BeginUse(string usageKey, Actor actor)
		{
		}

		public override void EndUse(string usageKey, Actor actor)
		{
		}

		private void OnSpawnedItem(object sender, SpawnItemEventArgs e)
		{
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}

		protected override void Dying()
		{
		}

		[IteratorStateMachine(typeof(_003CGetPaperSelectionMenuItems_003Ed__35))]
		public IEnumerable<ContextMenuItem> GetPaperSelectionMenuItems(Action onSelectCallback)
		{
			return null;
		}
	}
}
