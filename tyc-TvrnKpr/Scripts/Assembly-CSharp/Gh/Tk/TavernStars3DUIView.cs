using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class TavernStars3DUIView : BaseInteractable3DUIView
	{
		[CompilerGenerated]
		private sealed class _003CGetHalfStarParticleSystems_003Ed__18 : IEnumerable<Transform>, IEnumerable, IEnumerator<Transform>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Transform _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Transform parent;

			public Transform _003C_003E3__parent;

			private IEnumerator<Transform> _003C_003E7__wrap1;

			Transform IEnumerator<Transform>.Current
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
			public _003CGetHalfStarParticleSystems_003Ed__18(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<Transform> IEnumerable<Transform>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[SerializeField]
		private StarVisualSocket[] _starVisualTransforms;

		[SerializeField]
		private Transform _starBoard;

		public Vector3 openRotation;

		public Vector3 closedRotation;

		public override bool IsBlocked => false;

		public static float CurrentStarsOnBoard { get; private set; }

		protected override void Awake()
		{
		}

		protected override void OnUIReset(object sender, EventArgs eventArgs)
		{
		}

		public void UpdateStarBoard(bool withHalfStarParticleAnimation = false)
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		private void UpdateSign()
		{
		}

		private void SetOpen()
		{
		}

		private void SetClosed()
		{
		}

		public override void UpdateStateObjects()
		{
		}

		[IteratorStateMachine(typeof(_003CGetHalfStarParticleSystems_003Ed__18))]
		private IEnumerable<Transform> GetHalfStarParticleSystems(Transform parent)
		{
			return null;
		}

		protected override void OnDisable()
		{
		}
	}
}
