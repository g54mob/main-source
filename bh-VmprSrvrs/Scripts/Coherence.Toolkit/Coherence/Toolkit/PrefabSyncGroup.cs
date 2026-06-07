using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Log;
using UnityEngine;

namespace Coherence.Toolkit
{
	[AddComponentMenu("coherence/Prefab Sync Group")]
	[DefaultExecutionOrder(-955)]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(CoherenceSync))]
	public class PrefabSyncGroup : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CEnableChildrenRoutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PrefabSyncGroup _003C_003E4__this;

			private bool _003ChasDisabled_003E5__2;

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
			public _003CEnableChildrenRoutine_003Ed__11(int _003C_003E1__state)
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

		[Sync]
		[OnValueSynced("OnReceivedIds")]
		public byte[] ids;

		private List<CoherenceSync> childCoherenceSyncs;

		private int numberOfChildren;

		private CoherenceSync sync;

		private Coherence.Log.Logger logger;

		private Coherence.Log.Logger lastSyncLogger;

		private const int idByteLen = 4;

		private PrefabSyncGroup()
		{
		}

		private Coherence.Log.Logger Logger()
		{
			return null;
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CEnableChildrenRoutine_003Ed__11))]
		private IEnumerator EnableChildrenRoutine()
		{
			return null;
		}

		private void OnReceivedIds(byte[] old, byte[] newIds)
		{
		}

		private void GetChildCoherenceSyncs()
		{
		}

		private void OnValidate()
		{
		}
	}
}
