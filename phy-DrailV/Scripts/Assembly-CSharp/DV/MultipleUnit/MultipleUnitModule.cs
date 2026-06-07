using System;
using System.Collections;
using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

namespace DV.MultipleUnit
{
	public class MultipleUnitModule : MonoBehaviour
	{
		private enum Control
		{
			THROTTLE = 0,
			BRAKE = 1,
			IND_BRAKE = 2,
			DYNAMIC_BRAKE = 3,
			REVERSER = 4,
			SANDERS = 5,
			HEADLIGHTS_FRONT = 6,
			HEADLIGHTS_REAR = 7
		}

		public delegate void RemoteChannelChangedEvent(MultipleUnitRemoteChannel oldChannel, MultipleUnitRemoteChannel newChannel);

		public CouplingHoseMultipleUnitAdapter frontCableAdapter;

		public CouplingHoseMultipleUnitAdapter rearCableAdapter;

		private bool remoteOrientationReversed;

		private MultipleUnitCable frontCable;

		private MultipleUnitCable rearCable;

		[NonSerialized]
		public TrainCar train;

		[NonSerialized]
		public BaseControlsOverrider controlsOverrider;

		[NonSerialized]
		public MUControlBlockPropagator controlBlockPropagator;

		private bool isInUpdate;

		public MultipleUnitRemoteChannel RemoteChannel { get; private set; }

		public bool RemoteOrientationReversed
		{
			get
			{
				return remoteOrientationReversed;
			}
			set
			{
				if (remoteOrientationReversed != value)
				{
					remoteOrientationReversed = value;
					if (RemoteChannel?.Transmitter == this)
					{
						RemoteChannel.RaiseTransmitterChangedEvent();
					}
					else
					{
						SyncFromRadio();
					}
				}
			}
		}

		public bool IsTransmitter => RemoteChannel?.Transmitter == this;

		public MultipleUnitCable FrontCable => frontCable;

		public MultipleUnitCable RearCable => rearCable;

		public bool ConnectedFront
		{
			get
			{
				if (frontCable != null)
				{
					return frontCable.connectedTo != null;
				}
				return false;
			}
		}

		public bool ConnectedRear
		{
			get
			{
				if (rearCable != null)
				{
					return rearCable.connectedTo != null;
				}
				return false;
			}
		}

		public bool UseCable => true;

		public bool UseWireless => RemoteChannel != null;

		public event RemoteChannelChangedEvent RemoteChannelChanged;

		public static void SetupAutoCoupling()
		{
			Coupler.AutoCoupledGlobal += OnAutoCouple;
			UnloadWatcher.UnloadRequested -= AutoCoupleCleanup;
			UnloadWatcher.UnloadRequested += AutoCoupleCleanup;
		}

		private static void AutoCoupleCleanup()
		{
			Coupler.AutoCoupledGlobal -= OnAutoCouple;
			UnloadWatcher.UnloadRequested -= AutoCoupleCleanup;
		}

		private static void OnAutoCouple(Coupler c1, Coupler c2)
		{
			ConnectCablesOfConnectedCouplersIfMultipleUnitSupported(c1, c2);
		}

		public static void DisconnectCablesIfMultipleUnitSupported(TrainCar car, bool disconnectFront = true, bool disconnectRear = true)
		{
			if (!car.IsMultipleUnit)
			{
				return;
			}
			MultipleUnitModule muModule = car.muModule;
			if (disconnectFront)
			{
				MultipleUnitCable multipleUnitCable = muModule.frontCable;
				if (multipleUnitCable.IsConnected)
				{
					multipleUnitCable.Disconnect();
				}
			}
			if (disconnectRear)
			{
				MultipleUnitCable multipleUnitCable2 = muModule.rearCable;
				if (multipleUnitCable2.IsConnected)
				{
					multipleUnitCable2.Disconnect();
				}
			}
		}

		public static bool IsMultipleUnitCableConnected(TrainCar car, bool front)
		{
			if (car.IsMultipleUnit)
			{
				MultipleUnitModule muModule = car.muModule;
				if (!front)
				{
					return muModule.rearCable.IsConnected;
				}
				return muModule.frontCable.IsConnected;
			}
			return false;
		}

		public static void ConnectCablesOfConnectedCouplersIfMultipleUnitSupported(Coupler coupler1, Coupler coupler2)
		{
			if (coupler1.coupledTo != coupler2)
			{
				Debug.LogError("Unexpected state: couplers need to be connected in order to use ConnectCablesOfConnectedCouplersIfMultipleUnitSupported");
				return;
			}
			TrainCar trainCar = coupler1.train;
			TrainCar trainCar2 = coupler2.train;
			if (SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(GeneralLicenseType.MultipleUnit.ToV2()) && trainCar.IsMultipleUnit && trainCar2.IsMultipleUnit)
			{
				MultipleUnitModule muModule = trainCar.muModule;
				MultipleUnitModule muModule2 = trainCar2.muModule;
				MultipleUnitCable multipleUnitCable = (coupler1.isFrontCoupler ? muModule.frontCable : muModule.rearCable);
				MultipleUnitCable multipleUnitCable2 = (coupler2.isFrontCoupler ? muModule2.frontCable : muModule2.rearCable);
				if (!multipleUnitCable.IsConnected && !multipleUnitCable2.IsConnected)
				{
					multipleUnitCable.Connect(multipleUnitCable2);
				}
			}
		}

		public void Initialize(TrainCar trainCar)
		{
			train = trainCar;
			controlsOverrider = train.SimController?.controlsOverrider;
			frontCable = new MultipleUnitCable(this, isFront: true);
			frontCableAdapter.muCable = frontCable;
			rearCable = new MultipleUnitCable(this, isFront: false);
			rearCableAdapter.muCable = rearCable;
			controlBlockPropagator = new MUControlBlockPropagator(this);
			SetupListeners(set: true);
		}

		public void MultipleUnitStateRestoreOnGameLoad(bool frontConnected, bool rearConnected)
		{
			if (frontConnected || rearConnected)
			{
				if (!SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(GeneralLicenseType.MultipleUnit.ToV2()))
				{
					Debug.LogError($"MU cables connected, but player doesn't poses license {GeneralLicenseType.MultipleUnit}. Ignoring request");
				}
				else
				{
					StartCoroutine(RestoreMultipleUnitStateAfterAutoCoupleCoro(frontConnected, rearConnected));
				}
			}
		}

		private IEnumerator RestoreMultipleUnitStateAfterAutoCoupleCoro(bool frontConnected, bool rearConnected)
		{
			yield return WaitFor.Seconds(0.7f);
			if (frontConnected && !frontCable.IsConnected)
			{
				Coupler frontCoupler = train.frontCoupler;
				Coupler otherCoupler = (frontCoupler.IsCoupled() ? frontCoupler.coupledTo : frontCoupler.GetFirstCouplerInRange());
				ConnectMUCableToCorrespondingCoupler(isFrontCable: true, otherCoupler);
			}
			if (rearConnected && !rearCable.IsConnected)
			{
				Coupler rearCoupler = train.rearCoupler;
				Coupler otherCoupler2 = (rearCoupler.IsCoupled() ? rearCoupler.coupledTo : rearCoupler.GetFirstCouplerInRange());
				ConnectMUCableToCorrespondingCoupler(isFrontCable: false, otherCoupler2);
			}
			void ConnectMUCableToCorrespondingCoupler(bool isFrontCable, Coupler coupler)
			{
				if (coupler != null)
				{
					if (coupler.train.IsMultipleUnit)
					{
						MultipleUnitModule muModule = coupler.train.muModule;
						MultipleUnitCable other = (coupler.isFrontCoupler ? muModule.frontCable : muModule.rearCable);
						if (isFrontCable)
						{
							frontCable.Connect(other);
						}
						else
						{
							rearCable.Connect(other);
						}
					}
					else
					{
						Debug.LogError(string.Format("Unexpected state: coupled car {0} doesn't support MU! Ignoring MU {1} cable state restore on game load!", coupler.train.carType, isFrontCable ? "front" : "rear"));
					}
				}
				else
				{
					Debug.LogError("Unexpected state: Couldn't find otherCoupler! Ignoring MU " + (isFrontCable ? "front" : "rear") + " cable state restore on game load!");
				}
			}
		}

		public void SetupListeners(bool set)
		{
			if (set)
			{
				if ((bool)controlsOverrider.Throttle)
				{
					controlsOverrider.Throttle.ControlUpdated += OnThrottleUpdated;
				}
				if ((bool)controlsOverrider.Brake)
				{
					controlsOverrider.Brake.ControlUpdated += OnBrakeUpdated;
				}
				if ((bool)controlsOverrider.IndependentBrake)
				{
					controlsOverrider.IndependentBrake.ControlUpdated += OnIndependentBrakeUpdated;
				}
				if ((bool)controlsOverrider.DynamicBrake)
				{
					controlsOverrider.DynamicBrake.ControlUpdated += OnDynamicBrakeUpdated;
				}
				if ((bool)controlsOverrider.Reverser)
				{
					controlsOverrider.Reverser.ControlUpdated += OnReverserUpdated;
				}
				if ((bool)controlsOverrider.Sander)
				{
					controlsOverrider.Sander.ControlUpdated += OnSandersUpdated;
				}
				if ((bool)controlsOverrider.HeadlightsFront)
				{
					controlsOverrider.HeadlightsFront.ControlUpdated += OnHeadlightsUpdatedFront;
				}
				if ((bool)controlsOverrider.HeadlightsRear)
				{
					controlsOverrider.HeadlightsRear.ControlUpdated += OnHeadlightsUpdatedRear;
				}
			}
			else
			{
				if ((bool)controlsOverrider.Throttle)
				{
					controlsOverrider.Throttle.ControlUpdated -= OnThrottleUpdated;
				}
				if ((bool)controlsOverrider.Brake)
				{
					controlsOverrider.Brake.ControlUpdated -= OnBrakeUpdated;
				}
				if ((bool)controlsOverrider.IndependentBrake)
				{
					controlsOverrider.IndependentBrake.ControlUpdated -= OnIndependentBrakeUpdated;
				}
				if ((bool)controlsOverrider.DynamicBrake)
				{
					controlsOverrider.DynamicBrake.ControlUpdated -= OnDynamicBrakeUpdated;
				}
				if ((bool)controlsOverrider.Reverser)
				{
					controlsOverrider.Reverser.ControlUpdated -= OnReverserUpdated;
				}
				if ((bool)controlsOverrider.Sander)
				{
					controlsOverrider.Sander.ControlUpdated -= OnSandersUpdated;
				}
				if ((bool)controlsOverrider.HeadlightsFront)
				{
					controlsOverrider.HeadlightsFront.ControlUpdated -= OnHeadlightsUpdatedFront;
				}
				if ((bool)controlsOverrider.HeadlightsRear)
				{
					controlsOverrider.HeadlightsRear.ControlUpdated -= OnHeadlightsUpdatedRear;
				}
			}
		}

		private void OnHeadlightsUpdatedFront(float value)
		{
			UpdateHeadlights(value, front: true);
		}

		private void OnHeadlightsUpdatedRear(float value)
		{
			UpdateHeadlights(value, front: false);
		}

		private void PropagateValueViaCable(MultipleUnitModule propagatorModule, float value, Control controlToUpdate, bool toRear)
		{
			MultipleUnitModule multipleUnitModule = (toRear ? propagatorModule.rearCable : propagatorModule.frontCable).connectedTo?.muModule;
			while (multipleUnitModule != null && !multipleUnitModule.isInUpdate)
			{
				bool flag = (toRear ? multipleUnitModule.rearCable : multipleUnitModule.frontCable).connectedTo?.muModule == propagatorModule;
				bool isTransmitter = multipleUnitModule.IsTransmitter;
				if (UseCable)
				{
					MUOverrideControl(controlToUpdate, multipleUnitModule, flag, value, isTransmitter);
				}
				propagatorModule = multipleUnitModule;
				multipleUnitModule = ((flag == toRear) ? multipleUnitModule.frontCable.connectedTo?.muModule : multipleUnitModule.rearCable.connectedTo?.muModule);
			}
		}

		private void MUOverrideControl(Control controlToOverride, MultipleUnitModule moduleToOverride, bool reversedConnection, float value, bool forceFurtherMuPropagation = false)
		{
			switch (controlToOverride)
			{
			case Control.THROTTLE:
				moduleToOverride.controlsOverrider.Throttle?.MUOverride(value, forceFurtherMuPropagation);
				break;
			case Control.BRAKE:
				moduleToOverride.controlsOverrider.Brake?.MUOverride(value, forceFurtherMuPropagation);
				break;
			case Control.IND_BRAKE:
				moduleToOverride.controlsOverrider.IndependentBrake?.MUOverride(value, forceFurtherMuPropagation);
				break;
			case Control.DYNAMIC_BRAKE:
				moduleToOverride.controlsOverrider.DynamicBrake?.MUOverride(value, forceFurtherMuPropagation);
				break;
			case Control.REVERSER:
				moduleToOverride.controlsOverrider.Reverser?.MUOverride(reversedConnection ? (1f - value) : value, forceFurtherMuPropagation);
				break;
			case Control.SANDERS:
				moduleToOverride.controlsOverrider.Sander?.MUOverride(value, forceFurtherMuPropagation);
				break;
			case Control.HEADLIGHTS_FRONT:
				if (reversedConnection)
				{
					moduleToOverride.controlsOverrider.HeadlightsRear?.MUOverride(value, forceFurtherMuPropagation);
				}
				else
				{
					moduleToOverride.controlsOverrider.HeadlightsFront?.MUOverride(value, forceFurtherMuPropagation);
				}
				break;
			case Control.HEADLIGHTS_REAR:
				if (reversedConnection)
				{
					moduleToOverride.controlsOverrider.HeadlightsFront?.MUOverride(value, forceFurtherMuPropagation);
				}
				else
				{
					moduleToOverride.controlsOverrider.HeadlightsRear?.MUOverride(value, forceFurtherMuPropagation);
				}
				break;
			default:
				Debug.LogError($"Unexpected state: Unhandled control type: {controlToOverride}", this);
				break;
			}
		}

		private void UpdateControl(Control control, float value)
		{
			if (isInUpdate)
			{
				return;
			}
			isInUpdate = true;
			try
			{
				if (UseCable)
				{
					if (frontCable.IsConnected)
					{
						PropagateValueViaCable(this, value, control, toRear: false);
					}
					if (rearCable.IsConnected)
					{
						PropagateValueViaCable(this, value, control, toRear: true);
					}
				}
				if (!UseWireless || !(RemoteChannel.Transmitter == this))
				{
					return;
				}
				foreach (MultipleUnitModule device in RemoteChannel.devices)
				{
					if (device != this)
					{
						MUOverrideControl(control, device, remoteOrientationReversed != device.remoteOrientationReversed, value, forceFurtherMuPropagation: true);
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				isInUpdate = false;
			}
		}

		private void OnThrottleUpdated(float value)
		{
			UpdateControl(Control.THROTTLE, value);
		}

		private void OnBrakeUpdated(float value)
		{
			UpdateControl(Control.BRAKE, value);
		}

		private void OnIndependentBrakeUpdated(float value)
		{
			UpdateControl(Control.IND_BRAKE, value);
		}

		private void OnDynamicBrakeUpdated(float value)
		{
			UpdateControl(Control.DYNAMIC_BRAKE, value);
		}

		private void OnReverserUpdated(float value)
		{
			UpdateControl(Control.REVERSER, value);
		}

		private void OnSandersUpdated(float value)
		{
			UpdateControl(Control.SANDERS, value);
		}

		private void UpdateHeadlights(float value, bool front)
		{
			UpdateControl(front ? Control.HEADLIGHTS_FRONT : Control.HEADLIGHTS_REAR, value);
		}

		public void SetRadioChannel(MultipleUnitRemoteChannel channel, bool registerAsTransmitter)
		{
			if (RemoteChannel != channel)
			{
				if (RemoteChannel != null)
				{
					RemoteChannel.SetTransmitterState(this, isTransmitter: false);
					RemoteChannel.Remove(this);
					RemoteChannel.OnTransmitterChanged -= TransmitterChanged;
				}
				MultipleUnitRemoteChannel remoteChannel = RemoteChannel;
				RemoteChannel = channel;
				if (RemoteChannel != null)
				{
					RemoteChannel.Add(this);
					RemoteChannel.OnTransmitterChanged += TransmitterChanged;
				}
				this.RemoteChannelChanged?.Invoke(remoteChannel, channel);
			}
			RemoteChannel?.SetTransmitterState(this, registerAsTransmitter);
			SyncFromRadio();
		}

		private void TransmitterChanged(MultipleUnitRemoteChannel channel)
		{
			SyncFromRadio();
		}

		private void SyncFromRadio()
		{
			MultipleUnitModule multipleUnitModule = RemoteChannel?.Transmitter;
			if (multipleUnitModule == null || multipleUnitModule == this)
			{
				train?.SimController?.controlsBlocker?.MUSlaveBlockAllControls(block: false);
				return;
			}
			train?.SimController?.controlsBlocker?.MUSlaveBlockAllControls(block: true);
			BaseControlsOverrider baseControlsOverrider = multipleUnitModule.controlsOverrider;
			bool reversedConnection = remoteOrientationReversed != multipleUnitModule.remoteOrientationReversed;
			if (baseControlsOverrider.Throttle != null)
			{
				controlsOverrider.Throttle?.MUOverride(baseControlsOverrider.Throttle.Value, forceFurtherPropagationOfMuOverride: true);
			}
			if (baseControlsOverrider.Brake != null)
			{
				controlsOverrider.Brake?.MUOverride(baseControlsOverrider.Brake.Value, forceFurtherPropagationOfMuOverride: true);
			}
			if (baseControlsOverrider.IndependentBrake != null)
			{
				controlsOverrider.IndependentBrake?.MUOverride(baseControlsOverrider.IndependentBrake.Value, forceFurtherPropagationOfMuOverride: true);
			}
			controlsOverrider.DynamicBrake?.MUOverride((baseControlsOverrider.DynamicBrake != null) ? baseControlsOverrider.DynamicBrake.Value : 0f, forceFurtherPropagationOfMuOverride: true);
			if (baseControlsOverrider.Sander != null)
			{
				controlsOverrider.Sander?.MUOverride(baseControlsOverrider.Sander.Value, forceFurtherPropagationOfMuOverride: true);
			}
			if (baseControlsOverrider.HeadlightsFront != null)
			{
				multipleUnitModule.MUOverrideControl(Control.HEADLIGHTS_FRONT, this, reversedConnection, baseControlsOverrider.HeadlightsFront.Value, forceFurtherMuPropagation: true);
			}
			if (baseControlsOverrider.HeadlightsRear != null)
			{
				multipleUnitModule.MUOverrideControl(Control.HEADLIGHTS_REAR, this, reversedConnection, baseControlsOverrider.HeadlightsRear.Value, forceFurtherMuPropagation: true);
			}
			if (baseControlsOverrider.Reverser != null)
			{
				multipleUnitModule.MUOverrideControl(Control.REVERSER, this, reversedConnection, baseControlsOverrider.Reverser.Value, forceFurtherMuPropagation: true);
			}
		}

		private void OnDestroy()
		{
			SetRadioChannel(null, registerAsTransmitter: false);
			if (controlBlockPropagator != null)
			{
				controlBlockPropagator.Deinitialize();
				controlBlockPropagator = null;
			}
		}
	}
}
