using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public sealed class TouchController : CustomController
	{
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, disables mouse input when the Touch Controller script is enabled or GameObject is activated and re-enables mouse input when the script is disabled or GameObject is deactivated. This is useful for disabling Mouse Look controls when using touch controls in an FPS for example.")]
		[SerializeField]
		private bool _disableMouseInputWhenEnabled = true;

		[SerializeField]
		[Tooltip("If true, a Custom Controller will be populated with the data from this controller.")]
		[CustomObfuscation(rename = false)]
		private bool _useCustomController = true;

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
					OnSetProperty();
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
				if (_useCustomController == value)
				{
					goto IL_0009;
				}
				goto IL_0037;
				IL_0009:
				int num = -1633088957;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -1633088958)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						return;
					case 0:
						goto IL_0037;
					case 2:
						if (value)
						{
							CheckIsRewiredReady();
							num = -1633088954;
							continue;
						}
						return;
					case 4:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0037:
				_useCustomController = value;
				OnSetProperty();
				num = -1633088960;
				goto IL_000e;
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
			goto IL_004a;
			IL_000e:
			int num = -1357311632;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -1357311631)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 4:
					SetMouseState(true);
					num = -1357311629;
					continue;
				case 3:
					goto IL_004a;
				case 2:
					return;
				}
				break;
			}
			goto IL_000e;
			IL_004a:
			int num2;
			if (!ReInput.isReady)
			{
				num = -1357311629;
				num2 = num;
			}
			else
			{
				num = -1357311627;
				num2 = num;
			}
			goto IL_0013;
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			if (ReInput.isReady)
			{
				SetMouseState(false);
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

		private void SetMouseState(bool state)
		{
			if (!_disableMouseInputWhenEnabled)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = 1633496042;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x615D2BE9)
			{
			case 2:
				break;
			case 3:
				return;
			case 0:
				goto IL_0036;
			case 1:
				return;
			default:
				goto IL_0058;
			}
			goto IL_0008;
			IL_0036:
			if (state)
			{
				ReInput.controllers.Mouse.enabled = true;
				num = 1633496040;
				goto IL_000d;
			}
			goto IL_0058;
			IL_0058:
			ReInput.controllers.Mouse.enabled = false;
		}

		private void OnSetProperty()
		{
		}

		private bool CheckIsRewiredReady()
		{
			if (ReInput.isReady)
			{
				goto IL_0007;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Touch Controller. Custom Controller support will be disabled on this Touch Controller.");
			SetUseCustomController(false);
			int num = -1594739560;
			goto IL_000c;
			IL_000c:
			switch (num ^ -1594739560)
			{
			case 2:
				break;
			case 1:
				return true;
			default:
				return false;
			}
			goto IL_0007;
			IL_0007:
			num = -1594739559;
			goto IL_000c;
		}
	}
}
