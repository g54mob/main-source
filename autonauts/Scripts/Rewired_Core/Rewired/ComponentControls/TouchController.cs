using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public sealed class TouchController : CustomController
	{
		[Tooltip("If true, disables mouse input when the Touch Controller script is enabled or GameObject is activated and re-enables mouse input when the script is disabled or GameObject is deactivated. This is useful for disabling Mouse Look controls when using touch controls in an FPS for example.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _disableMouseInputWhenEnabled = true;

		[Tooltip("If true, a Custom Controller will be populated with the data from this controller.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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
					return;
				}
				while (true)
				{
					_useCustomController = value;
					OnSetProperty();
					int num = 841996948;
					while (true)
					{
						switch (num ^ 0x322FDA95)
						{
						case 0:
							num = 841996951;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							if (value)
							{
								CheckIsRewiredReady();
								num = 841996950;
								continue;
							}
							return;
						case 3:
							return;
						}
						break;
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
			while (true)
			{
				int num = -2020048046;
				while (true)
				{
					switch (num ^ -2020048042)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						if (!base.initialized)
						{
							return;
						}
						goto case 1;
					case 3:
						SetMouseState(true);
						num = -2020048044;
						continue;
					case 1:
					{
						int num2;
						if (ReInput.isReady)
						{
							num = -2020048043;
							num2 = num;
						}
						else
						{
							num = -2020048044;
							num2 = num;
						}
						continue;
					}
					case 2:
						return;
					}
					break;
				}
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
				SetMouseState(false);
				num = 871566514;
				goto IL_000d;
			}
			goto IL_003d;
			IL_000d:
			switch (num ^ 0x33F30CB0)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				goto IL_003d;
			}
			goto IL_0008;
			IL_003d:
			return true;
			IL_0008:
			num = 871566513;
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

		private void SetMouseState(bool state)
		{
			if (!_disableMouseInputWhenEnabled)
			{
				return;
			}
			while (!state)
			{
				while (true)
				{
					IL_0046:
					ReInput.controllers.Mouse.enabled = false;
					int num = -1488313;
					while (true)
					{
						switch (num ^ -1488313)
						{
						case 2:
							num = -1488314;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							goto IL_0046;
						case 0:
							return;
						}
						break;
					}
					break;
				}
			}
			ReInput.controllers.Mouse.enabled = true;
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
			int num = -219673266;
			goto IL_000c;
			IL_000c:
			switch (num ^ -219673266)
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
			num = -219673265;
			goto IL_000c;
		}
	}
}
