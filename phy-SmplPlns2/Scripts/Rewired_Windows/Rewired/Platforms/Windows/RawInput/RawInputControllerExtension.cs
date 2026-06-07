using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class GuCpXtqHsziqJiusXQILznlnzeAo : IControllerExtensionSource
		{
			private GiUlVpRQiheCBrrzlKxTvfhsMJTr rYtgkZKUfWBDFklkCpEEeGIUKRjEA;

			public GiUlVpRQiheCBrrzlKxTvfhsMJTr KhFfndjkHPUmpFgDKPZWGKCjXTgaB => rYtgkZKUfWBDFklkCpEEeGIUKRjEA;

			public GuCpXtqHsziqJiusXQILznlnzeAo(GiUlVpRQiheCBrrzlKxTvfhsMJTr P_0)
			{
				rYtgkZKUfWBDFklkCpEEeGIUKRjEA = P_0;
			}
		}

		private GuCpXtqHsziqJiusXQILznlnzeAo lRBIvZZIfZkzzFCJsOrlGbqFstVj;

		private bool CKOEUlGfApbOHbcagBmHpFrHmxheC;

		private Joystick joystick => GetController<Joystick>();

		public IntPtr hidDeviceHandle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return IntPtr.Zero;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.FiVGKBmKOVdvpvOrTaJecSpXJneT.DuAwRNRjcThyaFXSoEynwhRGWHwX;
			}
		}

		public IntPtr rawInputDeviceHandle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return IntPtr.Zero;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.CadnRndNVbxrGEQRcIsFAtvqcZiP;
			}
		}

		public string devicePath
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return string.Empty;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return string.Empty;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.FiVGKBmKOVdvpvOrTaJecSpXJneT.ZzYDvecKzkjrFFWXyGedLrsYvcPL;
			}
		}

		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return string.Empty;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return string.Empty;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.OeGYfNLnWbjgMjPkTgdrilHpguDCb;
			}
		}

		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return string.Empty;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return string.Empty;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.TiuSzRhGLsbJfcSwAbKghUftGUiPA;
			}
		}

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return 0;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return 0;
				}
				return (ushort)lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.MXYCKUZFcJBUCZiuMtejjGoCRoFK;
			}
		}

		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return 0;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return 0;
				}
				return (ushort)lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.MlUWuQbZqNWzsYRXZioNJpBxWurv;
			}
		}

		public Guid productGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return Guid.Empty;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return Guid.Empty;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.ibSeINshSGScITkFjKtcOMvvNXjb;
			}
		}

		public bool isBluetoothDevice
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return false;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return false;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.OVAmXCmTjKlJhFrwXPxhSgJZucaM;
			}
		}

		public string bluetoothDeviceName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return string.Empty;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return string.Empty;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.FZebZwAYjUaXGKBUheDcqiDVcAzcA;
			}
		}

		public int hubId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return -1;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return -1;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.TYjAfYamMKQGrrtDhWgQnFjSISUb;
			}
		}

		public int portId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return -1;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return -1;
				}
				return lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.YCfAWTdcBSbgLlaSEildIeRAjDQd;
			}
		}

		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return 0;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return 0;
				}
				return (ushort)lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.FiVGKBmKOVdvpvOrTaJecSpXJneT.IzyGpjUiLACVGTplnMoRJZHyRkuA.MBsItkfZIcrhjWVNkqWyhTIXazln;
			}
		}

		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!CKOEUlGfApbOHbcagBmHpFrHmxheC || !base.enabled)
				{
					return 0;
				}
				if (lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB == null)
				{
					return 0;
				}
				return (ushort)lRBIvZZIfZkzzFCJsOrlGbqFstVj.KhFfndjkHPUmpFgDKPZWGKCjXTgaB.FiVGKBmKOVdvpvOrTaJecSpXJneT.IzyGpjUiLACVGTplnMoRJZHyRkuA.XjnkDjjzVhcUJRNkyFbHmtMnhSWH;
			}
		}

		internal RawInputControllerExtension(GiUlVpRQiheCBrrzlKxTvfhsMJTr P_0)
			: base(new GuCpXtqHsziqJiusXQILznlnzeAo(P_0))
		{
		}

		private RawInputControllerExtension(RawInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (CKOEUlGfApbOHbcagBmHpFrHmxheC)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			lRBIvZZIfZkzzFCJsOrlGbqFstVj = source as GuCpXtqHsziqJiusXQILznlnzeAo;
			CKOEUlGfApbOHbcagBmHpFrHmxheC = lRBIvZZIfZkzzFCJsOrlGbqFstVj != null;
		}

		internal override Controller.Extension Clone()
		{
			return new RawInputControllerExtension(this);
		}
	}
}
