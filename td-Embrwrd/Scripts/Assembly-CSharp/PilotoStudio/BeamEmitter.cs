using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PilotoStudio
{
	[ExecuteAlways]
	public class BeamEmitter : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CBeamPlayComplete_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BeamEmitter _003C_003E4__this;

			private float _003CelapsedTime_003E5__2;

			private float _003CdissipationTime_003E5__3;

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
			public _003CBeamPlayComplete_003Ed__19(int _003C_003E1__state)
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
		private sealed class _003CBeamStart_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BeamEmitter _003C_003E4__this;

			private float _003CelapsedTime_003E5__2;

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
			public _003CBeamStart_003Ed__13(int _003C_003E1__state)
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

		[SerializeField]
		[Space]
		private List<LineRenderer> beams;

		[SerializeField]
		[Space]
		private List<ParticleSystem> beamSystems;

		[SerializeField]
		[Space]
		private float beamLifetime;

		[SerializeField]
		private float beamFormationTime;

		[SerializeField]
		private Transform beamTarget;

		[SerializeField]
		private GameObject beamTargetHitFX;

		[SerializeField]
		private List<float> desiredWidth;

		[SerializeField]
		private List<ParticleSystem.MinMaxCurve> defaultDensity;

		private void AssignChildBeamsToArray()
		{
		}

		private void GetChildLineRenderers()
		{
		}

		private void GetChildBeamEmitters()
		{
		}

		private void AssignBeamThickness()
		{
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CBeamStart_003Ed__13))]
		private IEnumerator BeamStart()
		{
			return null;
		}

		private void CacheParticleDensity()
		{
		}

		private void UpdateParticleDensity()
		{
		}

		private void UpdateImpactFX()
		{
		}

		private void PreviewBeam()
		{
		}

		public void PlayBeam()
		{
		}

		[IteratorStateMachine(typeof(_003CBeamPlayComplete_003Ed__19))]
		private IEnumerator BeamPlayComplete()
		{
			return null;
		}

		private void StartLineRenderers()
		{
		}

		private void PlayLineRenderers()
		{
		}

		private void PlayEdgeSystems()
		{
		}

		private void Update()
		{
		}
	}
}
