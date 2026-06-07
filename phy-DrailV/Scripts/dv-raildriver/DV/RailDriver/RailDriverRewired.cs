#define UNITY_EDITOR_WIN
using System;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

namespace DV.RailDriver
{
	public class RailDriverRewired : MonoBehaviour
	{
		public class InputWrapper : IDisposable
		{
			private readonly RailDriver.Wrapper deviceWrapper;

			private readonly CustomController controller;

			public InputWrapper(RailDriver.Wrapper wrapper, CustomController controller)
			{
				deviceWrapper = wrapper;
				deviceWrapper.Disconnected += Dispose;
				this.controller = controller;
				UnityEngine.Object.FindObjectOfType<ControlMapper>()?.ForceRefresh();
				ReInput.InputSourceUpdateEvent += OnInputSource;
			}

			private void OnInputSource()
			{
				controller.SetAxisValueById(0, deviceWrapper.Reverser);
				controller.SetAxisValueById(1, deviceWrapper.Throttle);
				controller.SetAxisValueById(2, deviceWrapper.DynBrake);
				controller.SetAxisValueById(3, deviceWrapper.AutoBrake);
				controller.SetAxisValueById(4, deviceWrapper.IndBrake);
				controller.SetAxisValueById(5, deviceWrapper.BailOff);
				controller.SetAxisValueById(10, deviceWrapper.Wiper);
				controller.SetAxisValueById(11, deviceWrapper.Lights);
				int buttonIndexById = controller.GetButtonIndexById(12);
				for (int i = 0; i < deviceWrapper.ButtonsCurrentState.Length; i++)
				{
					controller.SetButtonValue(i + buttonIndexById, deviceWrapper.ButtonsCurrentState[i]);
				}
			}

			public void Dispose()
			{
				ReInput.InputSourceUpdateEvent -= OnInputSource;
				if (!UnloadWatcher.isQuitting)
				{
					controller.SetAxisValueById(0, 0f);
					controller.SetAxisValueById(1, 0f);
					controller.SetAxisValueById(2, 0f);
					controller.SetAxisValueById(3, 0f);
					controller.SetAxisValueById(4, 0f);
					controller.SetAxisValueById(5, 0f);
					controller.SetAxisValueById(10, 0f);
					controller.SetAxisValueById(11, 0f);
					int buttonIndexById = controller.GetButtonIndexById(12);
					for (int i = 0; i < deviceWrapper.ButtonsCurrentState.Length; i++)
					{
						controller.SetButtonValue(i + buttonIndexById, value: false);
					}
				}
			}
		}

		private RailDriver rd;

		private CustomController controller;

		private void Awake()
		{
			controller = ReInput.controllers.GetCustomControllers()[0];
			rd = GetComponent<RailDriver>();
			rd.WrapperCreated += OnWrapperCreated;
			ReInput.ControllerConnectedEvent += OnConnected;
			ReInput.ControllerDisconnectedEvent += OnDisconnected;
		}

		private void OnConnected(ControllerStatusChangedEventArgs args)
		{
			if (args.name.Equals("RailDriver"))
			{
				rd.SetupDevices();
			}
		}

		private void OnDisconnected(ControllerStatusChangedEventArgs args)
		{
			if (args.name.Equals("RailDriver"))
			{
				rd.SetupDevices();
			}
		}

		private void OnWrapperCreated(RailDriver.Wrapper w)
		{
			new InputWrapper(w, controller);
		}
	}
}
