using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class DhpOHmJhAlAyBNRkPVlWGDZSkbpM : IControllerExtensionSource
		{
			private TtnAEkqmAdsULAHrlPWIYaTTzEeS iIKtaApiNIXwJCvsApIBvdafaWET;

			public TtnAEkqmAdsULAHrlPWIYaTTzEeS TnauwqFzWFsOhVBDGmFHlhguInBF => iIKtaApiNIXwJCvsApIBvdafaWET;

			public DhpOHmJhAlAyBNRkPVlWGDZSkbpM(TtnAEkqmAdsULAHrlPWIYaTTzEeS P_0)
			{
				iIKtaApiNIXwJCvsApIBvdafaWET = P_0;
			}
		}

		private DhpOHmJhAlAyBNRkPVlWGDZSkbpM mfyHHIyuJFHkjqxHaFruhhWasnas;

		private bool VurLwkYcdhQyZTuaRLFOoZwZiDPg;

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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return IntPtr.Zero;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.QtuBaEHHeVgdvGDbDpofTEXyFoJEA.QKfqzMiTOLoggqmQmwZwVJxdiKLW;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return IntPtr.Zero;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.NLKQJmIOphphQlGRkDLGlSFROUVQ;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return string.Empty;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return string.Empty;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.QtuBaEHHeVgdvGDbDpofTEXyFoJEA.ONtKQxRFTuZnNibZkxrkchEzjuqz;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return string.Empty;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return string.Empty;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.XxyuMkMmhKoIInyRDWsCmtKGdgHA;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return string.Empty;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return string.Empty;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.AQZcUxQxrsDfgRsEQlDzhBVYBcBD;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return 0;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return 0;
				}
				return (ushort)mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.FPpDVFqxOBHVOBsaIxIwdAOjqEkzA;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return 0;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return 0;
				}
				return (ushort)mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.HUvbaPYWVHzaxnHiJXMScbcOrkSC;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return Guid.Empty;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return Guid.Empty;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.reWXjJyHHSNMukjgXBpwrUuUBMeJA;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return false;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return false;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.NifCQRRuHIWBzkmqZsWwxbpaExFX;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return string.Empty;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return string.Empty;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.GnJPWfnpLSjeStgIxhadEXfgmXOY;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return -1;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return -1;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.YpKtFeLMGWCQYUVfznzvEdzjBVvw;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return -1;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return -1;
				}
				return mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.RUMUDRKnUElhHWtqKbJunvUtoavo;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return 0;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return 0;
				}
				return (ushort)mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.QtuBaEHHeVgdvGDbDpofTEXyFoJEA.PiIZLcUfWDRMXwtrbSrhoOdahQTu.LmJmErIocqvObtrJmnIjAbwmacUQ;
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
				if (!VurLwkYcdhQyZTuaRLFOoZwZiDPg || !base.enabled)
				{
					return 0;
				}
				if (mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF == null)
				{
					return 0;
				}
				return (ushort)mfyHHIyuJFHkjqxHaFruhhWasnas.TnauwqFzWFsOhVBDGmFHlhguInBF.QtuBaEHHeVgdvGDbDpofTEXyFoJEA.PiIZLcUfWDRMXwtrbSrhoOdahQTu.KyEexsUQzpnkBwJomaoERuqAqidQ;
			}
		}

		internal RawInputControllerExtension(TtnAEkqmAdsULAHrlPWIYaTTzEeS P_0)
			: base(new DhpOHmJhAlAyBNRkPVlWGDZSkbpM(P_0))
		{
		}

		private RawInputControllerExtension(RawInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (VurLwkYcdhQyZTuaRLFOoZwZiDPg)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			mfyHHIyuJFHkjqxHaFruhhWasnas = source as DhpOHmJhAlAyBNRkPVlWGDZSkbpM;
			VurLwkYcdhQyZTuaRLFOoZwZiDPg = mfyHHIyuJFHkjqxHaFruhhWasnas != null;
		}

		internal override Controller.Extension Clone()
		{
			return new RawInputControllerExtension(this);
		}
	}
}
