using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controller")]
	public sealed class TouchController : CustomController
	{
		[Tooltip("If true, disables mouse input when the Touch Controller script is enabled or GameObject is activated and re-enables mouse input when the script is disabled or GameObject is deactivated. This is useful for disabling Mouse Look controls when using touch controls in an FPS for example.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _disableMouseInputWhenEnabled = true;

		[Tooltip("If true, a Custom Controller will be populated with the data from this controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useCustomController = true;

		[NonSerialized]
		private bool tkFImGNDzLOBiZsLwRWePrhPaYGI;

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
					gtmdMPckUOKNoUBHlHflhIMUQuVgA();
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
					gtmdMPckUOKNoUBHlHflhIMUQuVgA();
					if (value)
					{
						KEsKYhAskOWImWGOujUIAyANNStc();
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
			if (base.npUXsKbOEynGhJdlZSjtANusWkzh && ReInput.isReady)
			{
				wtvcUsrBsuKkEGJYvnRSVlAXJIOy(true);
			}
		}

		internal bool mpDeSzhhUZICHViAafkjRSOKUOukA()
		{
			if (!OnInitialize())
			{
				return false;
			}
			if (ReInput.isReady)
			{
				tkFImGNDzLOBiZsLwRWePrhPaYGI = ReInput.controllers.Mouse.enabled;
				wtvcUsrBsuKkEGJYvnRSVlAXJIOy(false);
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

		private void wtvcUsrBsuKkEGJYvnRSVlAXJIOy(bool P_0)
		{
			if (_disableMouseInputWhenEnabled)
			{
				if (P_0)
				{
					ReInput.controllers.Mouse.enabled = tkFImGNDzLOBiZsLwRWePrhPaYGI;
				}
				else
				{
					ReInput.controllers.Mouse.enabled = false;
				}
			}
		}

		private void gtmdMPckUOKNoUBHlHflhIMUQuVgA()
		{
		}

		private bool KEsKYhAskOWImWGOujUIAyANNStc()
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
