using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GRP
{
	public class RattleContact
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDestroy_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public RattleKey key;

		public Collider colliderA;

		public Collider colliderB;

		public Rigidbody rigidbodyA;

		public Rigidbody rigidbodyB;

		public int id;

		public Vector3 point;

		public int lifeTime;

		public Vector3 velocity;

		public Vector3 impactVelocity;

		public Vector3 impactNormal;

		public int rollLifeTime;

		public int rollTimer;

		public Vector3 rollVelocity;

		public Vector3 lastImpactVelocity;

		public RattleScene scene;

		public RattleContactConfig config;

		public float slideIntensity;

		public float rollIntensity;

		public bool hasImpact;

		public float impactIntensity;

		public void Setup(RattleContactConfig config, RattleScene scene)
		{
		}

		public void SetImpactVelocity(RattleTouch touch)
		{
		}

		public void Update(float dt)
		{
		}

		public AudioSource NewSource()
		{
			return null;
		}

		public float Lerp(float v, float target)
		{
			return 0f;
		}

		[AsyncStateMachine(typeof(_003CDestroy_003Ed__26))]
		public void Destroy(bool force = false)
		{
		}

		public Vector3 GetVelocity()
		{
			return default(Vector3);
		}
	}
}
