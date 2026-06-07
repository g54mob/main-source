using System.ComponentModel;
using DV.Common;
using DV.HUD;
using DV.KeyboardInput;
using DV.Optimizers;
using DV.Simulation.Controllers;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls
{
	public class InteractablesKeyboardControl : ARefreshableChildrenController<AKeyboardInput>, PlayerOnCarScriptsOptimizer.IOptimizable
	{
		private bool optimizeEnabled = true;

		private bool initialized;

		protected void Awake()
		{
			RefreshEnabled();
			Globals.G.GameParams.PropertyChanged += OnGameParamsChanged;
			GameFeatureFlags.RegisterListenerFor(GameFeatureFlags.Flag.KeyboardDriving, OnFeatureFlagChanged);
			if (TryGetComponent<InteriorControlsManager>(out var component))
			{
				if (component.Initialized)
				{
					AKeyboardInput[] array = entries;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].SetupActions(component);
					}
					initialized = true;
					return;
				}
				component.OnInitialized += delegate(InteriorControlsManager manager)
				{
					AKeyboardInput[] array2 = entries;
					for (int j = 0; j < array2.Length; j++)
					{
						array2[j].SetupActions(manager);
					}
					initialized = true;
				};
			}
			else
			{
				AKeyboardInput[] array = entries;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetupActions(null);
				}
				initialized = true;
			}
		}

		private void OnDestroy()
		{
			Globals.G.GameParams.PropertyChanged -= OnGameParamsChanged;
			GameFeatureFlags.UnregisterListenerFor(GameFeatureFlags.Flag.KeyboardDriving, OnFeatureFlagChanged);
		}

		private void OnFeatureFlagChanged(GameFeatureFlags.Flag flag, bool allowed)
		{
			RefreshEnabled();
		}

		public void SetOptimizeState(bool enabled)
		{
			optimizeEnabled = enabled;
			RefreshEnabled();
		}

		private void RefreshEnabled()
		{
			base.enabled = optimizeEnabled && Globals.G.GameParams.KeyboardDrivingAllowed && GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.KeyboardDriving);
		}

		private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "KeyboardDrivingAllowed")
			{
				RefreshEnabled();
			}
		}

		private void Update()
		{
			if (!initialized || !TimeUtil.IsFlowing || SingletonBehaviour<InputFocusManager>.Instance.hasKeyboardFocus)
			{
				return;
			}
			AKeyboardInput[] array = entries;
			foreach (AKeyboardInput aKeyboardInput in array)
			{
				if (!aKeyboardInput.FixedUpdateTick)
				{
					aKeyboardInput.Tick(Time.deltaTime);
				}
			}
		}

		private void FixedUpdate()
		{
			if (!TimeUtil.IsFlowing || SingletonBehaviour<InputFocusManager>.Instance.hasKeyboardFocus)
			{
				return;
			}
			AKeyboardInput[] array = entries;
			foreach (AKeyboardInput aKeyboardInput in array)
			{
				if (aKeyboardInput.FixedUpdateTick)
				{
					aKeyboardInput.Tick(Time.fixedDeltaTime);
				}
			}
		}
	}
}
