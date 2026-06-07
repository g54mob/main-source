using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.Simple;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Resurrection
{
	[RequireComponent(typeof(NetworkObject))]
	public class PriestCeremonyController : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCeremonyCoroutine_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PriestCeremonyController _003C_003E4__this;

			public List<string> npcIds;

			private ResurrectionManager _003Cmanager_003E5__2;

			private List<string>.Enumerator _003C_003E7__wrap2;

			private string _003CnpcId_003E5__4;

			private DeadNPCEntry? _003Centry_003E5__5;

			private GraveController _003Cgrave_003E5__6;

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
			public _003CCeremonyCoroutine_003Ed__8(int _003C_003E1__state)
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
		}

		[CompilerGenerated]
		private sealed class _003CWalkToPosition_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PriestCeremonyController _003C_003E4__this;

			public Vector3 targetPosition;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

			private float _003CarrivalDistance_003E5__4;

			private float _003CrepathInterval_003E5__5;

			private float _003ClastRepathTime_003E5__6;

			private int _003CstuckRepathCount_003E5__7;

			private int _003CmaxStuckRepaths_003E5__8;

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
			public _003CWalkToPosition_003Ed__15(int _003C_003E1__state)
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

		[Header("Church Position")]
		[Tooltip("Transform marking the priest's idle position at the church.")]
		[SerializeField]
		private Transform churchIdlePoint;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private AStarNPCMotor motor;

		private SimpleNPCAnimator animator;

		private Coroutine ceremonyCoroutine;

		private bool lastWalkSucceeded;

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CCeremonyCoroutine_003Ed__8))]
		private IEnumerator CeremonyCoroutine(List<string> npcIds)
		{
			return null;
		}

		[ClientRpc]
		private void PlayCeremonySoundClientRpc(Vector3 position)
		{
		}

		[ClientRpc]
		private void PlayGraveDisappearSoundClientRpc(Vector3 position)
		{
		}

		[ClientRpc]
		private void PlayNPCAppearSoundClientRpc(Vector3 position)
		{
		}

		private bool AcquireMotor()
		{
			return false;
		}

		private void StopMotor()
		{
		}

		private void ReleaseMotor()
		{
		}

		[IteratorStateMachine(typeof(_003CWalkToPosition_003Ed__15))]
		private IEnumerator WalkToPosition(Vector3 targetPosition)
		{
			return null;
		}

		private void FaceTarget(Vector3 targetPosition)
		{
		}

		private List<string> SortByGraveDistance(List<string> npcIds, ResurrectionManager manager)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_179431830(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_808160909(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_513276698(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
