using DV.RemoteControls;
using UnityEngine;

namespace DV.Wheels
{
	public class WheelSlideTrainsetObserver : MonoBehaviour
	{
		public delegate void WheelSlideChanged(bool wheelSliding);

		private bool anyWheelSliding;

		private TrainCar car;

		private RemoteControllerModule remoteModule;

		private bool observerActive;

		public bool AnyWheelSlidingInTrainset => anyWheelSliding;

		public event WheelSlideChanged TrainsetWheelSlidingChanged;

		private void Awake()
		{
			car = TrainCar.Resolve(base.gameObject);
			remoteModule = car.GetComponent<RemoteControllerModule>();
			if (car == null)
			{
				Debug.LogError("Unexpected state: Missing TrainCar on WheelSlideTrainsetObserver. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
		}

		private void Start()
		{
			if (car.adhesionController == null)
			{
				Debug.LogError("Unexpected state: Missing AdhesionController, WheelSlideTrainsetObserver can't function. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				UpdateActiveState();
				SetupListeners(on: true);
			}
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
			if (observerActive)
			{
				AdhesionController.AnyWheelSlideStateChanged -= OnAnyWheelSlideStateChanged;
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (remoteModule != null)
				{
					remoteModule.PairingChanged += OnPairingChanged;
				}
				PlayerManager.CarChanged += OnPlayerCarChanged;
				car.TrainsetChanged += OnTrainsetChanged;
			}
			else
			{
				if (remoteModule != null)
				{
					remoteModule.PairingChanged -= OnPairingChanged;
				}
				PlayerManager.CarChanged -= OnPlayerCarChanged;
				car.TrainsetChanged -= OnTrainsetChanged;
			}
		}

		private void OnAnyWheelSlideStateChanged(TrainCar wheelSlideChangedCar, bool wheelSliding)
		{
			if (anyWheelSliding == wheelSliding || wheelSlideChangedCar.trainset != car.trainset)
			{
				return;
			}
			if (wheelSliding)
			{
				anyWheelSliding = true;
				this.TrainsetWheelSlidingChanged?.Invoke(anyWheelSliding);
				return;
			}
			foreach (TrainCar car in car.trainset.cars)
			{
				AdhesionController adhesionController = car.adhesionController;
				if (adhesionController != null && adhesionController.IsWheelSliding)
				{
					return;
				}
			}
			anyWheelSliding = false;
			this.TrainsetWheelSlidingChanged?.Invoke(anyWheelSliding);
		}

		private void OnTrainsetChanged(Trainset ts)
		{
			if (ts != null)
			{
				ForceAnyWheelSlidingUpdate();
			}
		}

		private void OnPlayerCarChanged(TrainCar _)
		{
			UpdateActiveState();
		}

		private void OnPairingChanged(bool _)
		{
			UpdateActiveState();
		}

		private void UpdateActiveState()
		{
			bool num = PlayerManager.Car == car;
			bool flag = remoteModule != null && remoteModule.IsPaired;
			if (num || flag)
			{
				if (!observerActive)
				{
					ForceAnyWheelSlidingUpdate();
					AdhesionController.AnyWheelSlideStateChanged += OnAnyWheelSlideStateChanged;
					observerActive = true;
				}
			}
			else if (observerActive)
			{
				AdhesionController.AnyWheelSlideStateChanged -= OnAnyWheelSlideStateChanged;
				observerActive = false;
			}
		}

		private void ForceAnyWheelSlidingUpdate()
		{
			foreach (TrainCar car in car.trainset.cars)
			{
				AdhesionController adhesionController = car.adhesionController;
				if (adhesionController != null && adhesionController.IsWheelSliding)
				{
					if (!anyWheelSliding)
					{
						anyWheelSliding = true;
						this.TrainsetWheelSlidingChanged?.Invoke(anyWheelSliding);
					}
					return;
				}
			}
			if (anyWheelSliding)
			{
				anyWheelSliding = false;
				this.TrainsetWheelSlidingChanged?.Invoke(anyWheelSliding);
			}
		}
	}
}
