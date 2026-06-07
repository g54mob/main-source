using System.ComponentModel;
using DV.Interaction.Inputs;
using DV.RemoteControls;
using DV.UI.LocoHUD;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.HUD
{
	public class CouplerInterfacer : MonoBehaviour
	{
		private HUDManager manager;

		private TrainCar train;

		private ExternalCouplingHandler couplingHandler;

		private int selectedCoupler;

		private GameParams gameParams;

		private UICouplingHelper couplingHelper;

		private bool isPairedToRemote;

		private void Start()
		{
			couplingHelper = new UICouplingHelper();
			couplingHelper.shouldAutoHandbrake = () => !InputManager.NewPlayer.GetButton(InputManager.Actions.Run) && ((gameParams.AutoHandbrakeViaRemoteControlCouplingAllowed && isPairedToRemote) || gameParams.AutoHandbrakeViaUICouplingAllowed);
			manager = SingletonBehaviour<HUDManager>.Instance;
			gameParams = Globals.G.GameParams;
			SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged += OnHUDChanged;
			SetupListeners(on: true);
			CoupleSelectorVisualUpdated();
			UpdateCouplerPanelAvailability();
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void Update()
		{
			if ((bool)train)
			{
				couplingHelper.SetCoupler(GetCouplerUncached(front: false), front: false);
				couplingHelper.SetCoupler(GetCouplerUncached(front: true), front: true);
				couplingHelper.CacheValues();
				UpdateColors();
			}
		}

		private void UpdateColors()
		{
			manager.CouplerMenu.coupleF.SetIndicatorColor(GetCouplerColor(front: true));
			manager.CouplerMenu.coupleR.SetIndicatorColor(GetCouplerColor(front: false));
			manager.CouplerMenu.hoseF.SetIndicatorColor(GetHoseColor(front: true));
			manager.CouplerMenu.hoseR.SetIndicatorColor(GetHoseColor(front: false));
			manager.CouplerMenu.muF.SetIndicatorColor(GetMUColor(front: true));
			manager.CouplerMenu.muR.SetIndicatorColor(GetMUColor(front: false));
			manager.CouplerMenu.chainF.SetIndicatorColor(GetChainColor(front: true));
			manager.CouplerMenu.chainR.SetIndicatorColor(GetChainColor(front: false));
		}

		private Color GetChainColor(bool front)
		{
			if (!GetCoupler(front).IsCoupled())
			{
				return UIColors.CLEAR;
			}
			return UIColors.YELLOW;
		}

		private Color GetMUColor(bool front)
		{
			if (!couplingHelper.IsMUConnected(front))
			{
				return UIColors.CLEAR;
			}
			return UIColors.YELLOW;
		}

		private Color GetHoseColor(bool front)
		{
			Coupler coupler = GetCoupler(front);
			if (couplingHelper.IsAirConnected(front) != coupler.IsCockOpen)
			{
				return UIColors.RED;
			}
			if (!coupler.IsCockOpen)
			{
				return UIColors.CLEAR;
			}
			return UIColors.YELLOW;
		}

		private Color GetCouplerColor(bool front)
		{
			if (!GetCoupler(front).IsCoupled())
			{
				if (!couplingHelper.IsInRange(front))
				{
					return UIColors.CLEAR;
				}
				return UIColors.GREEN;
			}
			if (couplingHelper.IsFullyCoupled(front))
			{
				if (!couplingHelper.IsMUConnected(front))
				{
					return UIColors.YELLOW;
				}
				return UIColors.BLUE;
			}
			return UIColors.RED;
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				manager.CouplerMenu.coupleF.controlModule.ValueChanged += CoupleF;
				manager.CouplerMenu.coupleR.controlModule.ValueChanged += CoupleR;
				manager.CouplerMenu.chainF.controlModule.ValueChanged += ChainF;
				manager.CouplerMenu.chainR.controlModule.ValueChanged += ChainR;
				manager.CouplerMenu.hoseF.controlModule.ValueChanged += HoseF;
				manager.CouplerMenu.hoseR.controlModule.ValueChanged += HoseR;
				manager.CouplerMenu.muF.controlModule.ValueChanged += MUF;
				manager.CouplerMenu.muR.controlModule.ValueChanged += MUR;
				manager.CouplerMenu.coupler.controlModule.ValueChanged += CouplerSelectorValueChanged;
				gameParams.PropertyChanged += OnGameParamsChanged;
				RemoteControllerModule.PairingChangedAny += RefreshRemotePairingStatus;
				Trainset.TrainsetsChanged += OnTrainsetChanged;
			}
			else
			{
				manager.CouplerMenu.coupleF.controlModule.ValueChanged -= CoupleF;
				manager.CouplerMenu.coupleR.controlModule.ValueChanged -= CoupleR;
				manager.CouplerMenu.chainF.controlModule.ValueChanged -= ChainF;
				manager.CouplerMenu.chainR.controlModule.ValueChanged -= ChainR;
				manager.CouplerMenu.hoseF.controlModule.ValueChanged -= HoseF;
				manager.CouplerMenu.hoseR.controlModule.ValueChanged -= HoseR;
				manager.CouplerMenu.muF.controlModule.ValueChanged -= MUF;
				manager.CouplerMenu.muR.controlModule.ValueChanged -= MUR;
				manager.CouplerMenu.coupler.controlModule.ValueChanged -= CouplerSelectorValueChanged;
				gameParams.PropertyChanged -= OnGameParamsChanged;
				RemoteControllerModule.PairingChangedAny -= RefreshRemotePairingStatus;
				Trainset.TrainsetsChanged -= OnTrainsetChanged;
			}
		}

		private void OnTrainsetChanged(bool _)
		{
			RefreshRemotePairingStatus();
			CoupleSelectorVisualUpdated();
		}

		private void CoupleF(float value)
		{
			if ((double)value > 0.5)
			{
				couplingHelper.HandleCoupling(GetCoupler(front: true), advanced: true);
				CoupleSelectorVisualUpdated();
			}
		}

		private void CoupleR(float value)
		{
			if ((double)value > 0.5)
			{
				couplingHelper.HandleCoupling(GetCoupler(front: false), advanced: true);
				CoupleSelectorVisualUpdated();
			}
		}

		private void ChainF(float value)
		{
			if ((double)value > 0.5)
			{
				couplingHelper.HandleCoupling(GetCoupler(front: true), advanced: false);
				CoupleSelectorVisualUpdated();
			}
		}

		private void ChainR(float value)
		{
			if ((double)value > 0.5)
			{
				couplingHelper.HandleCoupling(GetCoupler(front: false), advanced: false);
				CoupleSelectorVisualUpdated();
			}
		}

		private void HoseF(float value)
		{
			if ((double)value > 0.5)
			{
				couplingHelper.HandleBrakeHose(front: true);
			}
		}

		private void HoseR(float value)
		{
			if ((double)value > 0.5)
			{
				couplingHelper.HandleBrakeHose(front: false);
			}
		}

		private void MUF(float value)
		{
			if ((double)value > 0.5)
			{
				couplingHelper.DoMU(GetCoupler(front: true));
			}
		}

		private void MUR(float value)
		{
			if ((double)value > 0.5)
			{
				couplingHelper.DoMU(GetCoupler(front: false));
			}
		}

		private void OnHUDChanged(HUDInterfacer.HUDChangeEvent obj)
		{
			couplingHandler = null;
			train = null;
			if ((bool)obj.newBase)
			{
				train = obj.newBase.car;
				couplingHandler = train.GetComponent<ExternalCouplingHandler>();
				if (!couplingHandler)
				{
					couplingHandler = train.gameObject.AddComponent<ExternalCouplingHandler>();
				}
			}
			couplingHelper.trainCar = train;
			RefreshRemotePairingStatus();
			CoupleSelectorVisualUpdated();
		}

		private void RefreshRemotePairingStatus(bool _ = false, LocomotiveRemoteController __ = null)
		{
			isPairedToRemote = false;
			if ((bool)train)
			{
				foreach (TrainCar car in train.trainset.cars)
				{
					RemoteControllerModule component;
					if (!car)
					{
						Debug.LogError("t should not be null!");
					}
					else if (car.TryGetComponent<RemoteControllerModule>(out component) && component.IsPaired)
					{
						isPairedToRemote = true;
						break;
					}
				}
			}
			UpdateCouplerPanelAvailability();
			manager.CouplerMenu.remote.lightIndicatorModule.SetIndicatorColor(isPairedToRemote ? Color.green : Color.clear);
		}

		private void CouplerSelectorValueChanged(float value)
		{
			if (Mathf.Abs(value) < 2f)
			{
				selectedCoupler += (int)value;
			}
			else if (value > 0f)
			{
				selectedCoupler = couplingHandler.GetNumberOfCarsInFront();
			}
			else
			{
				selectedCoupler = -couplingHandler.GetNumberOfCarsInRear();
			}
			CoupleSelectorVisualUpdated();
		}

		private void CoupleSelectorVisualUpdated()
		{
			if ((bool)couplingHandler)
			{
				selectedCoupler = Mathf.Clamp(selectedCoupler, -couplingHandler.GetNumberOfCarsInRear(), couplingHandler.GetNumberOfCarsInFront());
				manager.CouplerMenu.coupler.textModule.SetTextValue(selectedCoupler.ToString());
				couplingHelper.trainCar = GetCouplerUncached(front: true).train;
			}
		}

		private Coupler GetCoupler(bool front)
		{
			return couplingHelper.GetCoupler(front);
		}

		private Coupler GetCouplerUncached(bool front)
		{
			Coupler nthCouplerFrom = CouplerLogic.GetNthCouplerFrom((selectedCoupler > 0) ? train.frontCoupler : train.rearCoupler, Mathf.Abs(selectedCoupler));
			if (selectedCoupler > 0 != front)
			{
				return nthCouplerFrom.GetOppositeCoupler();
			}
			return nthCouplerFrom;
		}

		private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CouplingViaHUDAllowed" || e.PropertyName == "CouplingViaRemoteControllerAllowed")
			{
				UpdateCouplerPanelAvailability();
			}
		}

		private void UpdateCouplerPanelAvailability()
		{
			bool couplingViaHUDAllowed = gameParams.CouplingViaHUDAllowed;
			bool flag = gameParams.CouplingViaRemoteControllerAllowed && isPairedToRemote;
			bool openable = couplingViaHUDAllowed || flag;
			manager.SetHUDOpenable(HUDManager.HUDPanelType.Coupling, openable);
		}
	}
}
