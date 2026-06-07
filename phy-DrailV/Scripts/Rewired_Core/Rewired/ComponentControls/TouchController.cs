using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("Rewired/Touch Controls/Touch Controller")]
	public sealed class TouchController : CustomController
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, disables mouse input when the Touch Controller script is enabled or GameObject is activated and re-enables mouse input when the script is disabled or GameObject is deactivated. This is useful for disabling Mouse Look controls when using touch controls in an FPS for example.")]
		private bool _disableMouseInputWhenEnabled = true;

		[Tooltip("If true, a Custom Controller will be populated with the data from this controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useCustomController = true;

		[NonSerialized]
		private bool lloUkeydBVRdUDqswCABWSPgAmyiA;

		public bool disableMouseInputWhenEnabled
		{
			get
			{
				return _disableMouseInputWhenEnabled;
			}
			set
			{
				if (_disableMouseInputWhenEnabled != value)
				{
					_disableMouseInputWhenEnabled = value;
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public bool useCustomController
		{
			get
			{
				return _useCustomController;
			}
			set
			{
				if (_useCustomController != value)
				{
					_useCustomController = value;
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
					if (value)
					{
						MqWEGAfVINuauMCDaSCdKgUxLEpIA();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && ReInput.isReady)
			{
				EIVQAPfgYoFpANhexSNLMYfERkdD(true);
			}
		}

		internal override bool BUnNPMFoanNJCVAmWibAzWafnjUk()
		{
			if (!OnInitialize())
			{
				return false;
			}
			if (ReInput.isReady)
			{
				lloUkeydBVRdUDqswCABWSPgAmyiA = ReInput.controllers.Mouse.enabled;
				EIVQAPfgYoFpANhexSNLMYfERkdD(false);
			}
			return true;
		}

		[CustomObfuscation(rename = false)]
		internal override bool GetUseCustomController()
		{
			return _useCustomController;
		}

		[CustomObfuscation(rename = false)]
		internal override void SetUseCustomController(bool value)
		{
			_useCustomController = value;
		}

		private void EIVQAPfgYoFpANhexSNLMYfERkdD(bool P_0)
		{
			if (_disableMouseInputWhenEnabled)
			{
				if (P_0)
				{
					ReInput.controllers.Mouse.enabled = lloUkeydBVRdUDqswCABWSPgAmyiA;
				}
				else
				{
					ReInput.controllers.Mouse.enabled = false;
				}
			}
		}

		private void jebsoqOBGHhJxfFgdjbRaKVujtZwA()
		{
		}

		private bool MqWEGAfVINuauMCDaSCdKgUxLEpIA()
		{
			if (ReInput.isReady)
			{
				return true;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Touch Controller. Custom Controller support will be disabled on this Touch Controller.");
			SetUseCustomController(value: false);
			return false;
		}
	}
}
