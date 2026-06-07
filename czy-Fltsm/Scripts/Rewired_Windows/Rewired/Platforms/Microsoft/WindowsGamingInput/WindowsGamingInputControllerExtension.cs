using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class oVyWIKXaucAevIWSxsUVbNiLAeKjA : IControllerExtensionSource
		{
			private ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB HiQRtYkjiPmUdSmboichWVQzYWwM;

			public ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB kNURWmActrJcygJevZJGJhrkkJhS => HiQRtYkjiPmUdSmboichWVQzYWwM;

			public oVyWIKXaucAevIWSxsUVbNiLAeKjA(ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB P_0)
			{
				HiQRtYkjiPmUdSmboichWVQzYWwM = P_0;
			}
		}

		private oVyWIKXaucAevIWSxsUVbNiLAeKjA wimmiOygxnIGxbxSVELFwKmOgehl;

		private bool sgrSifQfzbmmTCgCQgYELFSlchabA;

		private Joystick joystick => GetController<Joystick>();

		public DeviceType deviceType => (DeviceType)wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.kcmwoUABetcuUVVgqCNjvfFLGUwy;

		public IntPtr nativePointer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!sgrSifQfzbmmTCgCQgYELFSlchabA || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS == null)
				{
					return IntPtr.Zero;
				}
				return wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.yWhiKQpeHmgCJKnGONQXdbgDudSPc;
			}
		}

		public string nonRoamableId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!sgrSifQfzbmmTCgCQgYELFSlchabA || !base.enabled)
				{
					return string.Empty;
				}
				if (wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS == null)
				{
					return string.Empty;
				}
				return wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.tskuEtGFWJpFFeMCUaGUVkzFhfFn;
			}
		}

		public bool isWireless
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!sgrSifQfzbmmTCgCQgYELFSlchabA || !base.enabled)
				{
					return false;
				}
				if (wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS == null)
				{
					return false;
				}
				return wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.JwUBmnKxSnpjUSFrJxFWqZQeHIPH;
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
				if (!sgrSifQfzbmmTCgCQgYELFSlchabA || !base.enabled)
				{
					return string.Empty;
				}
				if (wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS == null)
				{
					return string.Empty;
				}
				return wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.uJKQzlBwXskoNbvczHyrFuXXhNEm;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!sgrSifQfzbmmTCgCQgYELFSlchabA || !base.enabled)
				{
					return 0;
				}
				if (wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS == null)
				{
					return 0;
				}
				return wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.KvbuNFFMxjNezLIJrEANFEvNotff.vendorId;
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
				if (!sgrSifQfzbmmTCgCQgYELFSlchabA || !base.enabled)
				{
					return 0;
				}
				if (wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS == null)
				{
					return 0;
				}
				return wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.KvbuNFFMxjNezLIJrEANFEvNotff.productId;
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
				if (!sgrSifQfzbmmTCgCQgYELFSlchabA || !base.enabled)
				{
					return 0;
				}
				if (wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS == null)
				{
					return 0;
				}
				return wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.TqsUHChsnaHpCCQHlWgEzQYeRBQv;
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
				if (!sgrSifQfzbmmTCgCQgYELFSlchabA || !base.enabled)
				{
					return 0;
				}
				if (wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS == null)
				{
					return 0;
				}
				return wimmiOygxnIGxbxSVELFwKmOgehl.kNURWmActrJcygJevZJGJhrkkJhS.uaxuSlSklwXeIcPviGEAVqzZNopw;
			}
		}

		internal WindowsGamingInputControllerExtension(ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB P_0)
			: base(new oVyWIKXaucAevIWSxsUVbNiLAeKjA(P_0))
		{
		}

		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (sgrSifQfzbmmTCgCQgYELFSlchabA)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			wimmiOygxnIGxbxSVELFwKmOgehl = source as oVyWIKXaucAevIWSxsUVbNiLAeKjA;
			sgrSifQfzbmmTCgCQgYELFSlchabA = wimmiOygxnIGxbxSVELFwKmOgehl != null;
		}

		internal override Controller.Extension Clone()
		{
			return new WindowsGamingInputControllerExtension(this);
		}
	}
}
