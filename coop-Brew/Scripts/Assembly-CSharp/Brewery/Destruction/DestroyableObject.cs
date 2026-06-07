using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Destruction
{
	public class DestroyableObject : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateReset_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DestroyableObject _003C_003E4__this;

			private Vector3 _003CstartPos_003E5__2;

			private Quaternion _003CstartRot_003E5__3;

			private Vector3 _003CstartScale_003E5__4;

			private float _003Celapsed_003E5__5;

			private float _003Cduration_003E5__6;

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
			public _003CAnimateReset_003Ed__22(int _003C_003E1__state)
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
		private sealed class _003CFadeIn_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DestroyableObject _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			private float _003Cduration_003E5__3;

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
			public _003CFadeIn_003Ed__21(int _003C_003E1__state)
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
		private sealed class _003CFadeOut_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DestroyableObject _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			private float _003Cduration_003E5__3;

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
			public _003CFadeOut_003Ed__20(int _003C_003E1__state)
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
		private sealed class _003CResetAfterDelay_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DestroyableObject _003C_003E4__this;

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
			public _003CResetAfterDelay_003Ed__19(int _003C_003E1__state)
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

		[Header("State (Runtime)")]
		[SerializeField]
		private Vector3 savedPosition;

		[SerializeField]
		private Quaternion savedRotation;

		[SerializeField]
		private Vector3 savedScale;

		[SerializeField]
		private Transform savedParent;

		[SerializeField]
		private bool isDestroyed;

		[SerializeField]
		private bool isResetting;

		private Rigidbody addedRigidbody;

		private bool hadRigidbodyBefore;

		private bool wasKinematicBefore;

		private DestroyableSettings settings;

		private int originalLayer;

		private bool wasStatic;

		private Renderer[] renderers;

		private Material[] originalMaterials;

		private Coroutine resetCoroutine;

		public bool IsDestroyed => false;

		public bool IsResetting => false;

		public void Initialize(Vector3 impactForce, Vector3 impactPoint, DestroyableSettings destroyableSettings)
		{
		}

		public void InitializeShakeOnly(Vector3 impactDirection, DestroyableSettings destroyableSettings)
		{
		}

		private void SetupRigidbody()
		{
		}

		private void PlayShakeAnimation(Vector3 impactDirection)
		{
		}

		[IteratorStateMachine(typeof(_003CResetAfterDelay_003Ed__19))]
		private IEnumerator ResetAfterDelay()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFadeOut_003Ed__20))]
		private IEnumerator FadeOut()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFadeIn_003Ed__21))]
		private IEnumerator FadeIn()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateReset_003Ed__22))]
		private IEnumerator AnimateReset()
		{
			return null;
		}

		private void RestoreOriginalState()
		{
		}

		private void CleanUp()
		{
		}

		private void OnDestroy()
		{
		}

		public void ForceReset()
		{
		}
	}
}
