using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Infrastructure.Scenes.Sandbox.Services.Creatures;
using UnityEngine;
using Zenject;

namespace LVA.Limbs
{
	public class LimbPhysics : MonoBehaviour
	{
		private sealed class xi : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int saf;

			private object sag;

			public Collision sah;

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
			public xi(int a)
			{
			}

			[DebuggerHidden]
			private void hjr()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in hjr
				this.hjr();
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
			private void hjt()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in hjt
				this.hjt();
			}
		}

		[SerializeField]
		private BoxCollider[] m_colliders;

		[SerializeField]
		private ConfigurableJoint m_joint;

		[SerializeField]
		private bef m_filterLegacy;

		[SerializeField]
		private CollisionFilter m_filter;

		[SerializeField]
		private Rigidbody m_rb;

		private bem sal;

		public xf sam
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public xh san
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public IReadOnlyCollection<xe> sao
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Transform xhl => null;

		public Vector3 xhm => default(Vector3);

		public Quaternion xhn => default(Quaternion);

		public Vector3 xho => default(Vector3);

		public Quaternion xhp => default(Quaternion);

		public event Action<float> sai
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Collision> saj
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Collision> sak
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void hjv(bem a)
		{
		}

		public void hkn(AbstractLimb a, out LimbPhysicsInternalReferences b)
		{
			b = default(LimbPhysicsInternalReferences);
		}

		private void OnJointBreak(float breakForce)
		{
		}

		private void OnCollisionEnter(Collision other)
		{
		}

		private void hko(Collision a)
		{
		}

		[IteratorStateMachine(typeof(xi))]
		private IEnumerator hkp(Collision a)
		{
			return null;
		}

		private void hkq()
		{
		}

		private void hkr(float a)
		{
		}

		private void hks(out List<xg> a, out List<xe> b)
		{
			a = null;
			b = null;
		}
	}
}
