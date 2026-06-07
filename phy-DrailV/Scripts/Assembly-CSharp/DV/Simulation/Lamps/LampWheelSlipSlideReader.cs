using System.Collections;
using DV.Simulation.Cars;
using DV.Wheels;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Lamps
{
	public class LampWheelSlipSlideReader : MonoBehaviour
	{
		public enum WheelslipDetectionMode
		{
			Individual = 0,
			MultipleUnit = 1
		}

		private const float WHEELSLIDE_SPEED_CHECK_CORO_PERIOD = 0.5f;

		public const float WHEELSLIDE_WARNING_SPEED_THRESHOLD = 5f / 9f;

		public WheelslipDetectionMode wheelslipDetectionMode;

		[SerializeField]
		[FuseId]
		private string fuseId;

		private Fuse fuse;

		private LampControl wheelWarningLamp;

		private MultipleUnitStateObserver multipleUnitStateObserver;

		private WheelslipController wheelslipController;

		private WheelSlideTrainsetObserver wheelSlideObserver;

		private Coroutine wheelSlideSpeedCheckCoro;

		private TrainCar car;

		private void Awake()
		{
			wheelWarningLamp = GetComponent<LampControl>();
			if (wheelWarningLamp == null)
			{
				Debug.LogError("Unexpected state: wheelWarningLamp ref is not set. Destroying self!");
				Object.Destroy(this);
				return;
			}
			car = TrainCar.Resolve(base.gameObject);
			if (wheelslipDetectionMode == WheelslipDetectionMode.MultipleUnit)
			{
				multipleUnitStateObserver = car.GetComponent<MultipleUnitStateObserver>();
				if (multipleUnitStateObserver == null)
				{
					Debug.LogError("Unexpected state: multipleUnitStateObserver missing. Wheelslip will not be detected", base.gameObject);
				}
			}
			else if (!car.adhesionController.wheelslipController.IsSome(out wheelslipController))
			{
				Debug.LogError("Unexpected state: wheelslipController missing. Wheelslip will not be detected", base.gameObject);
			}
			wheelSlideObserver = car.GetComponent<WheelSlideTrainsetObserver>();
			if (wheelSlideObserver == null)
			{
				Debug.LogError("Unexpected state: wheelSlideObserver missing. Wheel slide will not be detected", base.gameObject);
			}
		}

		private void Start()
		{
			if (!string.IsNullOrEmpty(fuseId))
			{
				SimulationFlow simulationFlow = car.SimController?.simFlow;
				if (simulationFlow != null)
				{
					if (!simulationFlow.TryGetFuse(fuseId, out fuse))
					{
						Debug.LogError("[" + base.gameObject.GetPath() + "]: LampWheelSlipSlideReader isn't initialized properly, fuse will not be set!");
					}
				}
				else
				{
					Debug.LogError("simFlow not found, fuse will not be set!");
				}
			}
			UpdateLampState();
			if (multipleUnitStateObserver != null)
			{
				multipleUnitStateObserver.MUChainWheelslippingChanged += OnWheelSlideSlipChanged;
			}
			if (wheelslipController != null)
			{
				wheelslipController.WheelslipStateChanged += OnWheelSlideSlipChanged;
			}
			if (wheelSlideObserver != null)
			{
				wheelSlideObserver.TrainsetWheelSlidingChanged += OnWheelSlideSlipChanged;
			}
			if (fuse != null)
			{
				fuse.StateUpdated += OnFuseStateUpdated;
			}
		}

		private void OnDestroy()
		{
			if (multipleUnitStateObserver != null)
			{
				multipleUnitStateObserver.MUChainWheelslippingChanged -= OnWheelSlideSlipChanged;
			}
			if (wheelslipController != null)
			{
				wheelslipController.WheelslipStateChanged -= OnWheelSlideSlipChanged;
			}
			if (wheelSlideObserver != null)
			{
				wheelSlideObserver.TrainsetWheelSlidingChanged -= OnWheelSlideSlipChanged;
			}
			if (fuse != null)
			{
				fuse.StateUpdated -= OnFuseStateUpdated;
			}
			KillWheelSlideSpeedCheckCoroIfAlive();
		}

		private void OnWheelSlideSlipChanged(bool _)
		{
			UpdateLampState();
		}

		private void OnFuseStateUpdated(bool on)
		{
			UpdateLampState();
		}

		private void UpdateLampState()
		{
			if (fuse != null && !fuse.State)
			{
				KillWheelSlideSpeedCheckCoroIfAlive();
				wheelWarningLamp.SetLampState(LampControl.LampState.Off);
				return;
			}
			bool flag = false;
			if (wheelSlideObserver != null)
			{
				flag = wheelSlideObserver.AnyWheelSlidingInTrainset;
			}
			bool flag2 = false;
			if (multipleUnitStateObserver != null)
			{
				flag2 = multipleUnitStateObserver.AnyInChainWheelslipping;
			}
			else if (wheelslipController != null)
			{
				flag2 = wheelslipController.IsWheelslipping;
			}
			LampControl.LampState state = LampControl.LampState.Off;
			if (flag2)
			{
				state = LampControl.LampState.On;
			}
			else if (flag)
			{
				if (car.GetAbsSpeed() > 5f / 9f)
				{
					state = LampControl.LampState.On;
					KillWheelSlideSpeedCheckCoroIfAlive();
				}
				else if (wheelSlideSpeedCheckCoro == null)
				{
					wheelSlideSpeedCheckCoro = StartCoroutine(WheelSlideSpeedCheckCoro());
				}
			}
			else
			{
				KillWheelSlideSpeedCheckCoroIfAlive();
			}
			wheelWarningLamp.SetLampState(state);
		}

		private void KillWheelSlideSpeedCheckCoroIfAlive()
		{
			if (wheelSlideSpeedCheckCoro != null)
			{
				StopCoroutine(wheelSlideSpeedCheckCoro);
				wheelSlideSpeedCheckCoro = null;
			}
		}

		private IEnumerator WheelSlideSpeedCheckCoro()
		{
			do
			{
				yield return WaitFor.Seconds(0.5f);
			}
			while (!(car.GetAbsSpeed() > 5f / 9f));
			if (!wheelSlideObserver.AnyWheelSlidingInTrainset)
			{
				Debug.LogError("Unexpected state: wheelSlideSpeedCheckCoro was not stopped when wheel sliding was stopped.");
			}
			UpdateLampState();
			wheelSlideSpeedCheckCoro = null;
		}
	}
}
