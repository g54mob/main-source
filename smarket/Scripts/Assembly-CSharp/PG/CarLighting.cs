using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class CarLighting : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoTurnsEnable_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CarLighting _003C_003E4__this;

			public TurnsStates state;

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
			public _003CDoTurnsEnable_003Ed__33(int _003C_003E1__state)
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
		private float TurnsSwitchHalfRepeatTime;

		private List<LightObject> MainLights;

		private List<LightObject> LeftTurnLights;

		private List<LightObject> RightTurnLights;

		private List<LightObject> BrakeLights;

		private List<LightObject> ReverseLights;

		private CarController _Car;

		private bool InBrake;

		private bool MainLightsIsOn;

		private Coroutine TurnsCotoutine;

		private List<LightObject> ActiveTurns;

		private TurnsStates CurrentTurnsState;

		public CarController Car
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CarLighting AdditionalLighting { get; set; }

		public event Action<CarLightType, bool> OnSetActiveLight
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

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void OnChangeGear(int gear)
		{
		}

		public void SwithOffAllLights()
		{
		}

		public void SetLights(CarLightType type, bool value)
		{
		}

		public void SwitchMainLights()
		{
		}

		public void SetActiveMainLights(bool value)
		{
		}

		public void SetActiveBrake(bool value)
		{
		}

		public void SetActiveReverse(bool value)
		{
		}

		public void TurnsEnable(TurnsStates state)
		{
		}

		private void TurnsDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CDoTurnsEnable_003Ed__33))]
		private IEnumerator DoTurnsEnable(TurnsStates state)
		{
			return null;
		}
	}
}
