using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class MerchantJob : ActorJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__7 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public MerchantJob _003C_003E4__this;

			private Merchant _003Cmerchant_003E5__2;

			private float _003CwaitTimeInDaysf_003E5__3;

			private Transform _003CmerchantAnimationSocket_003E5__4;

			private GameObject _003CentryWps_003E5__5;

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
			public _003CGetActivities_003Ed__7(int _003C_003E1__state)
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
		private int _currentWaypoint;

		[PersistenceOptIn]
		private float _currentPathProgress;

		public float PathProgress
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private MerchantJob()
		{
		}

		public MerchantJob(GameObjectX source)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__7))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}
	}
}
