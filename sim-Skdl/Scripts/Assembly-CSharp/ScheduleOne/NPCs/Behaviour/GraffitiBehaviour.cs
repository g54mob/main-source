using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Graffiti;
using ScheduleOne.NPCs.Other;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour
{
	public class GraffitiBehaviour : Behaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoEffectRoutine_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GraffitiBehaviour _003C_003E4__this;

			private int _003CsafetyCounter_003E5__2;

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
			public _003CDoEffectRoutine_003Ed__27(int _003C_003E1__state)
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

		public const int InterruptionXP = 50;

		public const float InterruptionCartelInfluenceChange = -0.1f;

		[SerializeField]
		[Header("Graffiti: Components")]
		private SprayPaint _sprayPaint;

		[Header("Graffiti: Settings")]
		[SerializeField]
		private Vector2Int _graffitiDurationInMinutes;

		[SerializeField]
		private Vector2 _minMaxEffectLoopDuration;

		[SerializeField]
		private Vector2 _minMaxEffectPauseDuration;

		[SerializeField]
		private Gradient _effectColorGradient;

		[SerializeField]
		[Header("Graffiti: Drawings")]
		private List<SerializedGraffitiDrawing> _drawinglist;

		[Header("Graffiti: Interruptions")]
		[SerializeField]
		private List<Behaviour> _interruptingBehaviours;

		[SerializeField]
		[Header("Debugging & Development")]
		private bool _debugMode;

		private int _duration;

		private Coroutine _effectCoroutine;

		private WorldSpraySurface _spraySurface;

		private bool _graffitiCompleted;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EGraffitiBehaviourAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EGraffitiBehaviourAssembly_002DCSharp_002Edll_Excuted;

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public override void Enable()
		{
		}

		public override void Disable()
		{
		}

		public override void Activate()
		{
		}

		public override void Pause()
		{
		}

		public override void Deactivate()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void Complete_Server()
		{
		}

		private void CheckForInterruptions()
		{
		}

		private void SetupEvents()
		{
		}

		private void CleanUp()
		{
		}

		private void OnMinPass()
		{
		}

		private void OnTimePass(int minutes)
		{
		}

		private void StopEffectRoutine()
		{
		}

		[IteratorStateMachine(typeof(_003CDoEffectRoutine_003Ed__27))]
		private IEnumerator DoEffectRoutine()
		{
			return null;
		}

		[ObserversRpc(RunLocally = true)]
		public void SetSpraySurface_Client(NetworkConnection conn, NetworkObject surface)
		{
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Server_Complete_Server_2166136261()
		{
		}

		private void RpcLogic___Complete_Server_2166136261()
		{
		}

		private void RpcReader___Server_Complete_Server_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Observers_SetSpraySurface_Client_1824087381(NetworkConnection conn, NetworkObject surface)
		{
		}

		public void RpcLogic___SetSpraySurface_Client_1824087381(NetworkConnection conn, NetworkObject surface)
		{
		}

		private void RpcReader___Observers_SetSpraySurface_Client_1824087381(PooledReader PooledReader0, Channel channel)
		{
		}

		public override void Awake()
		{
		}
	}
}
