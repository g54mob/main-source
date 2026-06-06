using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Ezereal
{
	public class EzerealLightController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CHazardLightsController_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EzerealLightController _003C_003E4__this;

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
			public _003CHazardLightsController_003Ed__24(int _003C_003E1__state)
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
		private sealed class _003CTurnSignalController_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EzerealLightController _003C_003E4__this;

			public GameObject[] turnLights;

			public bool isActive;

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
			public _003CTurnSignalController_003Ed__23(int _003C_003E1__state)
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

		[Header("Beam Lights")]
		[SerializeField]
		private LightBeam currentBeam;

		[SerializeField]
		private GameObject[] lowBeamHeadlights;

		[SerializeField]
		private GameObject[] highBeamHeadlights;

		[SerializeField]
		private GameObject[] lowBeamSpotlights;

		[SerializeField]
		private GameObject[] highBeamSpotlights;

		[SerializeField]
		private GameObject[] rearLights;

		[Header("Brake Lights")]
		[SerializeField]
		private GameObject[] brakeLights;

		[Header("Handbrake Light")]
		[SerializeField]
		private GameObject[] handbrakeLight;

		[Header("Reverse Lights")]
		[SerializeField]
		private GameObject[] reverseLights;

		[Header("Turn Lights")]
		[SerializeField]
		private GameObject[] leftTurnLights;

		[SerializeField]
		private GameObject[] rightTurnLights;

		[Header("Misc Lights")]
		[Tooltip("Any additional lights. Interior lights.")]
		[SerializeField]
		private GameObject[] miscLights;

		[Header("Settings")]
		[SerializeField]
		private float lightBlinkDelay;

		[Header("Debug")]
		[SerializeField]
		private bool leftTurnActive;

		[SerializeField]
		private bool rightTurnActive;

		[SerializeField]
		private bool hazardLightsActive;

		private void Start()
		{
		}

		public void AllLightsOff()
		{
		}

		private void OnLowBeamLight()
		{
		}

		private void OnHighBeamLight()
		{
		}

		private void OnLeftTurnSignal()
		{
		}

		private void OnRightTurnSignal()
		{
		}

		private void OnHazardLights()
		{
		}

		[IteratorStateMachine(typeof(_003CTurnSignalController_003Ed__23))]
		private IEnumerator TurnSignalController(GameObject[] turnLights, bool isActive)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHazardLightsController_003Ed__24))]
		private IEnumerator HazardLightsController()
		{
			return null;
		}

		private void SetLight(GameObject[] lights, bool isActive)
		{
		}

		private void AllBeamsOff()
		{
		}

		private void LowBeamOn()
		{
		}

		private void HighBeamOn()
		{
		}

		private void TurnLightsOff()
		{
		}

		private void TurnLightsOn()
		{
		}

		private void SetHazardLightsOn()
		{
		}

		public void BrakeLightsOff()
		{
		}

		public void BrakeLightsOn()
		{
		}

		public void HandbrakeLightOff()
		{
		}

		public void HandbrakeLightOn()
		{
		}

		public void ReverseLightsOff()
		{
		}

		public void ReverseLightsOn()
		{
		}

		public void MiscLightsOff()
		{
		}

		public void MiscLightsOn()
		{
		}
	}
}
