using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class CraftWeapon_Job : Craft_Job
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__11 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CraftWeapon_Job _003C_003E4__this;

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
			public _003CGetActivities_003Ed__11(int _003C_003E1__state)
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
		[PersistenceObjectReference]
		public Weapon TargetWeapon;

		[PersistenceOptIn]
		private List<string> _nextCraftingProps;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isCheckingEnabled;

		protected CraftWeapon_Job()
		{
		}

		public CraftWeapon_Job(GameObjectX source, WeaponTemplate template)
		{
		}

		protected override bool CheckIsValidInternal()
		{
			return false;
		}

		public override IEnumerable<string> GetIssues()
		{
			return null;
		}

		private void CheckStaff(List<string> issues)
		{
		}

		private static void CheckProp(List<string> issues, string uniqueType)
		{
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		public override bool IsCheckingInputsEnabled()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__11))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private Prop GetBestProp(string prefabTypeIdentifier, string reason = null)
		{
			return null;
		}

		public override IEnumerable<Tuple<GameItemTemplate, int>> GetNeededItemAmounts()
		{
			return null;
		}
	}
}
