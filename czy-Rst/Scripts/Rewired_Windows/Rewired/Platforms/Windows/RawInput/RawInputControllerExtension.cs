using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class HnJFygoSxuxdRfoBoibKbGbxagai : IControllerExtensionSource
		{
			private HzHFRaRJGaRjHeexYdLIzRlkbNlr aLkuHEMzVJCqTcEofqGJMYAWZJJI;

			public HzHFRaRJGaRjHeexYdLIzRlkbNlr TeWaxwcLpKspldPXtDzPFUUTZRQBA => aLkuHEMzVJCqTcEofqGJMYAWZJJI;

			public HnJFygoSxuxdRfoBoibKbGbxagai(HzHFRaRJGaRjHeexYdLIzRlkbNlr P_0)
			{
				aLkuHEMzVJCqTcEofqGJMYAWZJJI = P_0;
			}
		}

		private HnJFygoSxuxdRfoBoibKbGbxagai arYTOANMNSzQhYBDXfqyIxqZgabu;

		private bool LZJOnwpWkkXLZnesyCCUVXxgJnGw;

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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return IntPtr.Zero;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.GSYOMXwajUclmofoclzymnMTvQAB.OqPFeMkTIORdolSCLFAqhyTaAPGRb;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return IntPtr.Zero;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.ZiVOixjMkcdIJHXZAGWIQvyLkEG;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return string.Empty;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return string.Empty;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.GSYOMXwajUclmofoclzymnMTvQAB.MjLYTnwAPlIwFiWNTuksLZkCChjz;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return string.Empty;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return string.Empty;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.RABxiAVVwipZGmKaoXbehHJfgqrt;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return string.Empty;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return string.Empty;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.WatlMKpDvpCxlvgefasnKzjhuGCp;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return 0;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return 0;
				}
				return (ushort)arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.RFTMYXVFWYcEOWJetBxadGkAgDfQ;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return 0;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return 0;
				}
				return (ushort)arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.LYBimHvVYSopcHwXwMVKTeVfskNi;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return Guid.Empty;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return Guid.Empty;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.lSsIgVJkZJTNmYjmcPooWFWpvBlw;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return false;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return false;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.HMNLVHyHJVIKpOWqwNsiKWPBghCm;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return string.Empty;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return string.Empty;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.QFdbXlQHBRejChBEMExhCsHLvAJyA;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return -1;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return -1;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.SBeGCcqGAZVFEgWbUnadrRXCxCix;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return -1;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return -1;
				}
				return arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.DzcfEBrwYLfgDiokxnWwGucSapwN;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return 0;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return 0;
				}
				return (ushort)arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.GSYOMXwajUclmofoclzymnMTvQAB.TmyJIorHUClZHEznESojNORVgHYIA.DjUbnGzodlsdrJNKZcjJtQeHzThB;
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
				if (!LZJOnwpWkkXLZnesyCCUVXxgJnGw || !base.enabled)
				{
					return 0;
				}
				if (arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA == null)
				{
					return 0;
				}
				return (ushort)arYTOANMNSzQhYBDXfqyIxqZgabu.TeWaxwcLpKspldPXtDzPFUUTZRQBA.GSYOMXwajUclmofoclzymnMTvQAB.TmyJIorHUClZHEznESojNORVgHYIA.IViteghYbatdPALqZmtWcdKhWbit;
			}
		}

		internal RawInputControllerExtension(HzHFRaRJGaRjHeexYdLIzRlkbNlr P_0)
			: base(new HnJFygoSxuxdRfoBoibKbGbxagai(P_0))
		{
		}

		private RawInputControllerExtension(RawInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (LZJOnwpWkkXLZnesyCCUVXxgJnGw)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			arYTOANMNSzQhYBDXfqyIxqZgabu = source as HnJFygoSxuxdRfoBoibKbGbxagai;
			LZJOnwpWkkXLZnesyCCUVXxgJnGw = arYTOANMNSzQhYBDXfqyIxqZgabu != null;
		}

		internal override Controller.Extension Clone()
		{
			return new RawInputControllerExtension(this);
		}
	}
}
