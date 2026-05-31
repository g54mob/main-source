using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PG
{
	public class CarStateUI : InitializePlayer
	{
		private enum RpmState
		{
			Low = 0,
			Medium = 1,
			High = 2
		}

		[CompilerGenerated]
		private sealed class _003CDoSetColor_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CarStateUI _003C_003E4__this;

			public Color targetColor;

			private float _003Ct_003E5__2;

			private Color _003CstartColor_003E5__3;

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
			public _003CDoSetColor_003Ed__49(int _003C_003E1__state)
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

		[Header("Main info settings")]
		[SerializeField]
		private float UpdateSpeedTime;

		[SerializeField]
		private TextMeshProUGUI CurrentSpeedText;

		[SerializeField]
		private TextMeshProUGUI CurrentGearText;

		[SerializeField]
		private TextMeshProUGUI MeasurementUnits;

		[SerializeField]
		private Image GearCircleImage;

		[SerializeField]
		private Image ArrowImage;

		[SerializeField]
		private Transform ArrowRotateTransform;

		[SerializeField]
		private float ZeroRpmArrowAngle;

		[SerializeField]
		private float MaxRpmArrowAnle;

		[SerializeField]
		private Image FillTachometrImage;

		[SerializeField]
		private float ZeroRpmFill;

		[SerializeField]
		private float MaxRpmFill;

		[SerializeField]
		private Color LowRpmColor;

		[SerializeField]
		private Color MediumRpmColor;

		[SerializeField]
		private Color HighRpmColor;

		[SerializeField]
		private float ChangeColorSpeed;

		[Header("Turbo")]
		[SerializeField]
		private GameObject TurboStateGO;

		[SerializeField]
		private Transform TurboArrowTransform;

		[SerializeField]
		private float ZeroTurboAngle;

		[SerializeField]
		private float MaxTurboAngle;

		[Header("Boost")]
		[SerializeField]
		private GameObject BoostStateGO;

		[SerializeField]
		private Image BoostFillImage;

		[SerializeField]
		private float ZeroBoostFillAmount;

		[SerializeField]
		private float MaxBoostFillAmount;

		[Header("DashboardIcons")]
		[SerializeField]
		private Image ABSIcon;

		[SerializeField]
		private Image TCSIcon;

		[SerializeField]
		private Image HandbrakeIcon;

		[SerializeField]
		private Color FullHPPartColor;

		[SerializeField]
		private Color HightHPPartColor;

		[SerializeField]
		private Color LowHPPartColor;

		[SerializeField]
		private Color DeadPartColor;

		[SerializeField]
		private float MaxLocalDistanceBetweenWheels;

		private int CurrentGear;

		private float UpdateSpeedTimer;

		private float RPMPercent;

		private RpmState CurrentRpmState;

		private Coroutine SetColorCoroutine;

		private const string NeutralGear = "N";

		private const string RearGear = "R";

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public override bool Initialize(VehicleController vehicle)
		{
			return false;
		}

		private void UpdateSpeed()
		{
		}

		private void UpdateGear()
		{
		}

		private void UpdateTachometr()
		{
		}

		private void UpdateColors()
		{
		}

		private void UpdateTurbo()
		{
		}

		private void UpdateBoost()
		{
		}

		private void UpdateDashboard()
		{
		}

		[IteratorStateMachine(typeof(_003CDoSetColor_003Ed__49))]
		private IEnumerator DoSetColor(Color targetColor)
		{
			return null;
		}
	}
}
