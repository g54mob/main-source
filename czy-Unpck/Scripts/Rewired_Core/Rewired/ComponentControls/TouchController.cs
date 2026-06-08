using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("Rewired/Touch Controller")]
	public sealed class TouchController : CustomController
	{
		[Tooltip("If true, disables mouse input when the Touch Controller script is enabled or GameObject is activated and re-enables mouse input when the script is disabled or GameObject is deactivated. This is useful for disabling Mouse Look controls when using touch controls in an FPS for example.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _disableMouseInputWhenEnabled = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, a Custom Controller will be populated with the data from this controller.")]
		[SerializeField]
		private bool _useCustomController = true;

		[NonSerialized]
		private bool _originalMouseState;

		public bool disableMouseInputWhenEnabled
		{
			get
			{
				return _disableMouseInputWhenEnabled;
			}
			set
			{
				if (_disableMouseInputWhenEnabled == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = 1127872738;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x4339F8E0)
				{
				case 0:
					break;
				case 2:
					return;
				case 3:
					goto IL_0033;
				default:
					OnSetProperty();
					return;
				}
				goto IL_0009;
				IL_0033:
				_disableMouseInputWhenEnabled = value;
				num = 1127872737;
				goto IL_000e;
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
				if (_useCustomController == value)
				{
					return;
				}
				while (true)
				{
					_useCustomController = value;
					OnSetProperty();
					if (!value)
					{
						break;
					}
					CheckIsRewiredReady();
					int num = 223656792;
					while (true)
					{
						switch (num ^ 0xD54BB58)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 223656793;
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
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = -214115444;
			goto IL_0013;
			IL_0013:
			switch (num ^ -214115443)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				goto IL_0038;
			case 0:
				return;
			}
			goto IL_000e;
			IL_0038:
			if (ReInput.isReady)
			{
				SetMouseState(restoreOriginal: true);
				num = -214115443;
				goto IL_0013;
			}
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				goto IL_0008;
			}
			int num;
			if (ReInput.isReady)
			{
				_originalMouseState = ReInput.controllers.Mouse.enabled;
				num = -23217544;
				goto IL_000d;
			}
			goto IL_005d;
			IL_000d:
			while (true)
			{
				switch (num ^ -23217542)
				{
				case 0:
					break;
				case 1:
					return false;
				case 2:
					SetMouseState(restoreOriginal: false);
					num = -23217543;
					continue;
				default:
					goto IL_005d;
				}
				break;
			}
			goto IL_0008;
			IL_005d:
			return true;
			IL_0008:
			num = -23217541;
			goto IL_000d;
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

		private void SetMouseState(bool restoreOriginal)
		{
			if (_disableMouseInputWhenEnabled)
			{
				if (restoreOriginal)
				{
					ReInput.controllers.Mouse.enabled = _originalMouseState;
				}
				else
				{
					ReInput.controllers.Mouse.enabled = false;
				}
			}
		}

		private void OnSetProperty()
		{
		}

		private bool CheckIsRewiredReady()
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
