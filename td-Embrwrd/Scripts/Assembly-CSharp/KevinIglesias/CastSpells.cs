using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace KevinIglesias
{
	public class CastSpells : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAppearFireball_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform t;

			private Vector3 _003CstartSize_003E5__2;

			private float _003Ci_003E5__3;

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
			public _003CAppearFireball_003Ed__17(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CMoveFireball_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform t;

			private Vector3 _003CinitPosition_003E5__2;

			private float _003Ci_003E5__3;

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
			public _003CMoveFireball_003Ed__18(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSpawnFireball_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CastHand hand;

			public CastSpells _003C_003E4__this;

			public float delay;

			private Transform _003ChandT_003E5__2;

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
			public _003CSpawnFireball_003Ed__12(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSpawnHealing_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CastHand hand;

			public CastSpells _003C_003E4__this;

			public float delay;

			private Transform _003ChandT_003E5__2;

			private Transform _003Ct_003E5__3;

			private Vector3 _003CstartSize_003E5__4;

			private float _003Ci_003E5__5;

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
			public _003CSpawnHealing_003Ed__13(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSpawnNova_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public CastSpells _003C_003E4__this;

			private GameObject _003CnewNova_003E5__2;

			private Transform _003Ct_003E5__3;

			private Vector3 _003CstartSize_003E5__4;

			private float _003Ci_003E5__5;

			private Renderer _003Cr_003E5__6;

			private Color _003CinitColor_003E5__7;

			private Color _003CendColor_003E5__8;

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
			public _003CSpawnNova_003Ed__15(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSpawnShockwave_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CastHand hand;

			public CastSpells _003C_003E4__this;

			public float delay;

			private Transform _003ChandT_003E5__2;

			private GameObject _003CnewShockwave_003E5__3;

			private Transform _003Ct_003E5__4;

			private Renderer _003Cr_003E5__5;

			private Color _003CinitColor_003E5__6;

			private Color _003CendColor_003E5__7;

			private float _003Ci_003E5__8;

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
			public _003CSpawnShockwave_003Ed__16(int _003C_003E1__state)
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

		public Transform rightHand;

		public Transform leftHand;

		public Vector3 handOffset;

		public float spellOffset;

		public GameObject spellPrefab;

		public GameObject castEffectPrefab;

		[HideInInspector]
		public GameObject castEffectR;

		[HideInInspector]
		public GameObject castEffectL;

		public void ThrowFireball(CastHand hand, float delay)
		{
		}

		public void ThrowNova(float delay)
		{
		}

		public void ThrowHealing(CastHand hand, float delay)
		{
		}

		public void ThrowShockwave(CastHand hand, float delay)
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnFireball_003Ed__12))]
		public IEnumerator SpawnFireball(CastHand hand, float delay)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSpawnHealing_003Ed__13))]
		public IEnumerator SpawnHealing(CastHand hand, float delay)
		{
			return null;
		}

		public void SpawnEffect(CastHand hand)
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnNova_003Ed__15))]
		public IEnumerator SpawnNova(float delay)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSpawnShockwave_003Ed__16))]
		public IEnumerator SpawnShockwave(CastHand hand, float delay)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppearFireball_003Ed__17))]
		private IEnumerator AppearFireball(Transform t)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CMoveFireball_003Ed__18))]
		private IEnumerator MoveFireball(Transform t)
		{
			return null;
		}
	}
}
