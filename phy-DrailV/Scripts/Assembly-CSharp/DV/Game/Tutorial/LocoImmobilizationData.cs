using System;
using System.Collections.Generic;
using DV.CabControls;
using DV.HUD;
using DV.Simulation.Controllers;
using UnityEngine;

namespace DV.Game.Tutorial
{
	internal class LocoImmobilizationData : IDisposable
	{
		private TrainCar Car { get; set; }

		private InteriorControlsManager InteriorControls { get; set; }

		private List<ControlImplBase> Controls { get; set; } = new List<ControlImplBase>();

		private bool ControlsHooked { get; set; }

		private InteractablePortFeedersController PortFeeder { get; set; }

		public event Action<TrainCar, ValueChangedEventArgs> OnInteriorControlValueChanged;

		public LocoImmobilizationData(TrainCar car)
		{
			Car = car;
			if (car.loadedInterior != null)
			{
				HookControls();
			}
			car.InteriorLoaded += OnInteriorLoaded;
			car.InteriorAboutToBeUnloaded += OnInteriorUnloaded;
		}

		private void OnInteriorUnloaded(GameObject interior)
		{
			if (!ControlsHooked)
			{
				return;
			}
			foreach (ControlImplBase control in Controls)
			{
				if ((bool)control)
				{
					control.ValueChanged -= OnLocoValueChanged;
				}
			}
			Controls.Clear();
			ControlsHooked = false;
		}

		private void OnInteriorLoaded(GameObject interior)
		{
			if (ControlsHooked)
			{
				return;
			}
			InteriorControls = Car?.interior?.GetComponentInChildren<InteriorControlsManager>();
			if ((bool)InteriorControls)
			{
				if (InteriorControls.Initialized)
				{
					HookControls();
					return;
				}
				InteriorControls.OnInitialized -= OnInteriorControlsInitialized;
				InteriorControls.OnInitialized += OnInteriorControlsInitialized;
			}
		}

		private void OnInteriorControlsInitialized(InteriorControlsManager manager)
		{
			manager.OnInitialized -= OnInteriorControlsInitialized;
			HookControls();
		}

		private void HookControls()
		{
			InteriorControls = Car?.interior?.GetComponentInChildren<InteriorControlsManager>();
			PortFeeder = Car?.loadedInterior?.GetComponentInChildren<InteractablePortFeedersController>();
			if ((bool)InteriorControls)
			{
				if (InteriorControls.TryGetControl(InteriorControlsManager.ControlType.Throttle, out var reference))
				{
					HookImmobilizedLocoControl(reference.controlImplBase);
				}
				if (InteriorControls.TryGetControl(InteriorControlsManager.ControlType.Reverser, out var reference2))
				{
					HookImmobilizedLocoControl(reference2.controlImplBase);
				}
				ControlsHooked = true;
			}
		}

		private void HookImmobilizedLocoControl(ControlImplBase control)
		{
			if ((bool)control)
			{
				control.ValueChanged += OnLocoValueChanged;
				Controls.Add(control);
			}
		}

		private void OnLocoValueChanged(ValueChangedEventArgs eventArgs)
		{
			if (PortFeeder != null && !PortFeeder.IsCurrentlySettingInitialValues)
			{
				this.OnInteriorControlValueChanged?.Invoke(Car, eventArgs);
			}
		}

		public void Dispose()
		{
			Car.InteriorLoaded -= OnInteriorLoaded;
			Car.InteriorAboutToBeUnloaded -= OnInteriorUnloaded;
			if ((bool)InteriorControls)
			{
				InteriorControls.OnInitialized -= OnInteriorControlsInitialized;
			}
			if (!ControlsHooked)
			{
				return;
			}
			foreach (ControlImplBase control in Controls)
			{
				if ((bool)control)
				{
					control.ValueChanged -= OnLocoValueChanged;
				}
			}
			Controls.Clear();
			ControlsHooked = false;
		}
	}
}
