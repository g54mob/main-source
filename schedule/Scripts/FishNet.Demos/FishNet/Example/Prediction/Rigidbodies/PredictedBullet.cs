using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using UnityEngine;

namespace FishNet.Example.Prediction.Rigidbodies
{
	public class PredictedBullet : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C__DelayDestroy_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			public PredictedBullet _003C_003E4__this;

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
			public _003C__DelayDestroy_003Ed__9(int _003C_003E1__state)
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

		[HideInInspector]
		[SyncVar(OnChange = "_startingForce_OnChange")]
		public Vector3 _startingForce;

		private uint _stopTick;

		public SyncVar<Vector3> syncVar____startingForce;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002EPrediction_002ERigidbodies_002EPredictedBulletFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002EPrediction_002ERigidbodies_002EPredictedBulletFishNet_002EDemos_002Edll_Excuted;

		public Vector3 SyncAccessor__startingForce
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public void SetStartingForce(Vector3 value)
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartNetwork()
		{
		}

		public override void OnStopNetwork()
		{
		}

		private void TimeManager_OnTick()
		{
		}

		private void _startingForce_OnChange(Vector3 prev, Vector3 next, bool asServer)
		{
		}

		public void SetVelocity(Vector3 value)
		{
		}

		[IteratorStateMachine(typeof(_003C__DelayDestroy_003Ed__9))]
		private IEnumerator __DelayDestroy(float time)
		{
			return null;
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		public virtual bool ReadSyncVar___FishNet_002EExample_002EPrediction_002ERigidbodies_002EPredictedBullet(PooledReader PooledReader0, uint UInt321, bool Boolean2)
		{
			return false;
		}

		public virtual void Awake()
		{
		}
	}
}
