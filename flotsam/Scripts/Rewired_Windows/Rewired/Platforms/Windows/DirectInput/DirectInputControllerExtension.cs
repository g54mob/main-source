using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class gUPRIuXCwOZHHlKSJRDCgYQiUigg : IControllerExtensionSource
		{
			private JwOsKFPjPBIlckyhencRQGSXVgXH ACIoitgIQddwvJdICCoIIegjNgKtA;

			private eikpKKcQyXxlEKPVshSBmEPUuUVo dcmNTdiceDzlcHiyCmCtRZxuszim;

			public JwOsKFPjPBIlckyhencRQGSXVgXH cWImMZfpcuWbfkThizaGbRAAaIJH => ACIoitgIQddwvJdICCoIIegjNgKtA;

			public eikpKKcQyXxlEKPVshSBmEPUuUVo fRRBdFCNKyXsrbbwXekuoEVNeDfab => dcmNTdiceDzlcHiyCmCtRZxuszim;

			public gUPRIuXCwOZHHlKSJRDCgYQiUigg(JwOsKFPjPBIlckyhencRQGSXVgXH P_0, eikpKKcQyXxlEKPVshSBmEPUuUVo P_1)
			{
				ACIoitgIQddwvJdICCoIIegjNgKtA = P_0;
				dcmNTdiceDzlcHiyCmCtRZxuszim = P_1;
			}
		}

		private gUPRIuXCwOZHHlKSJRDCgYQiUigg YWKEEMEXAyIDAXaSqAZdFzuljxvn;

		private bool cIZqmUHFnpEUVZuXhGJaIUmuPwaK;

		private Joystick joystick => GetController<Joystick>();

		public Guid instanceGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return Guid.Empty;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return Guid.Empty;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.pyDhcNgRqogBXYMltfkVKgTlhbSI;
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
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return Guid.Empty;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return Guid.Empty;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.HySZBGMwhUkvgQxYHLwubwCwnhMF;
			}
		}

		public string instanceName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return string.Empty;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.JwnXWHYbgIjVKGVTKMZcepxfJjiab;
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
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return string.Empty;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.yZVeagLLfLwQfvkUWvzUkRcMoGkx;
			}
		}

		public Guid forceFeedbackDriverGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return Guid.Empty;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return Guid.Empty;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.ymzCuOEVmeRpvZFBwpqTyGiWeIaS;
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
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return 0;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.FxtczQJNHhOaYLZkwsZWOkdVWtFP;
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
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return 0;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.zyMqfdMgYfclRqhxxhKlVFDcghgZ;
			}
		}

		public DirectInputDeviceType deviceType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DirectInputDeviceType.Device;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return DirectInputDeviceType.Device;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return DirectInputDeviceType.Device;
				}
				return (DirectInputDeviceType)YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.pmVwzDGTuzpjQPIJGbNYWRspjRaD;
			}
		}

		public int deviceSubtype
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return 0;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.uPQdfZGCbrTbUwygmSZXlHPHYCCS;
			}
		}

		public int rawType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return 0;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.tfmiXsHzWEVmccHWhAKEEytWbXjFA;
			}
		}

		public bool isHumanInterfaceDevice
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return false;
				}
				if (YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab == null)
				{
					return false;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.cWImMZfpcuWbfkThizaGbRAAaIJH.kuKCNoZcYNNeknkqvbgGTnjAAGSz;
			}
		}

		public DirectInputDeviceAxisMode axisMode
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DirectInputDeviceAxisMode.Absolute;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return DirectInputDeviceAxisMode.Absolute;
				}
				return (DirectInputDeviceAxisMode)YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.ndAVriIpItBqWiphabIWfSQpOjVQ;
			}
		}

		public int bufferSize
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.vhgSwtMrkylsOFkfQbBnEnYNHVdh;
			}
		}

		public Guid classGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return Guid.Empty;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.BhxebjOajUeKMxhFKDTWEHnuhqAkA;
			}
		}

		public int forceFeedbackGain
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.TIVZCONNOORTUrIQHrbXSDUcKOX;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (cIZqmUHFnpEUVZuXhGJaIUmuPwaK && base.enabled)
				{
					YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.TIVZCONNOORTUrIQHrbXSDUcKOX = value;
				}
			}
		}

		public string interfacePath
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return string.Empty;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.OAtCEANRPGFAaESPehmUTJhoTWyD;
			}
		}

		public int joystickId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				return YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.ZjgbmngcrMRzblAhlvbNjhNImtRwA;
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
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				return (ushort)YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.mYVplrejAZAiyBMuwTOaigakCoZNA;
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
				if (!cIZqmUHFnpEUVZuXhGJaIUmuPwaK || !base.enabled)
				{
					return 0;
				}
				return (ushort)YWKEEMEXAyIDAXaSqAZdFzuljxvn.fRRBdFCNKyXsrbbwXekuoEVNeDfab.CElaehVUMlHqGjcbRjWuKvIezImN.hGynDoBRoLVKugHBJNdiomgppFaj;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		internal DirectInputControllerExtension(JwOsKFPjPBIlckyhencRQGSXVgXH P_0, eikpKKcQyXxlEKPVshSBmEPUuUVo P_1)
			: base(new gUPRIuXCwOZHHlKSJRDCgYQiUigg(P_0, P_1))
		{
		}

		private DirectInputControllerExtension(DirectInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (cIZqmUHFnpEUVZuXhGJaIUmuPwaK)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			YWKEEMEXAyIDAXaSqAZdFzuljxvn = source as gUPRIuXCwOZHHlKSJRDCgYQiUigg;
			cIZqmUHFnpEUVZuXhGJaIUmuPwaK = YWKEEMEXAyIDAXaSqAZdFzuljxvn != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DirectInputControllerExtension(this);
		}
	}
}
