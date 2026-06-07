using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[AddComponentMenu("Rewired/Touch Controls/Touch Controller")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	public sealed class TouchController : CustomController
	{
		[Tooltip("If true, disables mouse input when the Touch Controller script is enabled or GameObject is activated and re-enables mouse input when the script is disabled or GameObject is deactivated. This is useful for disabling Mouse Look controls when using touch controls in an FPS for example.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _disableMouseInputWhenEnabled;

		[Tooltip("If true, a Custom Controller will be populated with the data from this controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useCustomController;

		[NonSerialized]
		private bool nQpuMIugrognPlJhwjWUtgSMTmrT;

		public bool disableMouseInputWhenEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useCustomController
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
		}

		internal override bool uMJLSufFPDHRLbQQdnOsEiBJrFsM()
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal override bool GetUseCustomController()
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal override void SetUseCustomController(bool value)
		{
		}

		private void iHZAEcEhmVJAdoTolMkmnbnUQzji(bool P_0)
		{
		}

		private void wsGinTJUKbgeLgbploYDqMrVqgwl()
		{
		}

		private bool KFguyGvVypztricXuyfgwhJCDpnl()
		{
			return false;
		}
	}
}
