using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XInputControllerExtension : Controller.Extension
	{
		private class xNFQRrKdXgPaoTBAVEaCSGqlDpMe : IControllerExtensionSource
		{
			private dthckWzdCvyytSjahUhAscVvCaQb.iUVRQWivcUcvaWpmaoyYGuTThrFS ZWcaUduZmroTmxAFmIPzcdReluUd;

			public dthckWzdCvyytSjahUhAscVvCaQb.iUVRQWivcUcvaWpmaoyYGuTThrFS OPVTgVGjujrcLGOlTDqwIYUgSdWu => ZWcaUduZmroTmxAFmIPzcdReluUd;

			public xNFQRrKdXgPaoTBAVEaCSGqlDpMe(dthckWzdCvyytSjahUhAscVvCaQb.iUVRQWivcUcvaWpmaoyYGuTThrFS P_0)
			{
				ZWcaUduZmroTmxAFmIPzcdReluUd = P_0;
			}
		}

		private xNFQRrKdXgPaoTBAVEaCSGqlDpMe oBSojytRNHSGzEvzQeuQqWjXbCiy;

		private bool QoZvhkzEoqAJYRbDsMOneXLvpaAr;

		private Joystick joystick => GetController<Joystick>();

		public int userIndex
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!QoZvhkzEoqAJYRbDsMOneXLvpaAr || !base.enabled)
				{
					return 0;
				}
				if (oBSojytRNHSGzEvzQeuQqWjXbCiy.OPVTgVGjujrcLGOlTDqwIYUgSdWu == null)
				{
					return 0;
				}
				return (int)oBSojytRNHSGzEvzQeuQqWjXbCiy.OPVTgVGjujrcLGOlTDqwIYUgSdWu.CtwhuyyQIAolqaPHmDaKOAqjCzGz.tUpBxVHEgQGekQLFDDYvPCppnKrB;
			}
		}

		public CapabilityFlags capabilityFlags
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return CapabilityFlags.None;
				}
				if (!QoZvhkzEoqAJYRbDsMOneXLvpaAr || !base.enabled)
				{
					return CapabilityFlags.None;
				}
				if (oBSojytRNHSGzEvzQeuQqWjXbCiy.OPVTgVGjujrcLGOlTDqwIYUgSdWu == null)
				{
					return CapabilityFlags.None;
				}
				oBSojytRNHSGzEvzQeuQqWjXbCiy.OPVTgVGjujrcLGOlTDqwIYUgSdWu.CtwhuyyQIAolqaPHmDaKOAqjCzGz.tkqxqCqOGHCCuFgcUPHCxZGTXsXr(ddrNxChsiLuVtQynDItAHKGwFiuaA.Any, out var kkCedRUBGjrnSczYvIhPFYMUDQuP);
				return (CapabilityFlags)kkCedRUBGjrnSczYvIhPFYMUDQuP.JifhRmjEoeaFnfasWqWatpjfKMNK;
			}
		}

		public DeviceType deviceType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return (DeviceType)0;
				}
				if (!QoZvhkzEoqAJYRbDsMOneXLvpaAr || !base.enabled)
				{
					return (DeviceType)0;
				}
				if (oBSojytRNHSGzEvzQeuQqWjXbCiy.OPVTgVGjujrcLGOlTDqwIYUgSdWu == null)
				{
					return (DeviceType)0;
				}
				oBSojytRNHSGzEvzQeuQqWjXbCiy.OPVTgVGjujrcLGOlTDqwIYUgSdWu.CtwhuyyQIAolqaPHmDaKOAqjCzGz.tkqxqCqOGHCCuFgcUPHCxZGTXsXr(ddrNxChsiLuVtQynDItAHKGwFiuaA.Any, out var kkCedRUBGjrnSczYvIhPFYMUDQuP);
				return (DeviceType)kkCedRUBGjrnSczYvIhPFYMUDQuP.drRPaCsEOnDGPCElmzxYHgtBkjEJ;
			}
		}

		public DeviceSubType deviceSubType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return (DeviceSubType)0;
				}
				if (!QoZvhkzEoqAJYRbDsMOneXLvpaAr || !base.enabled)
				{
					return (DeviceSubType)0;
				}
				if (oBSojytRNHSGzEvzQeuQqWjXbCiy.OPVTgVGjujrcLGOlTDqwIYUgSdWu == null)
				{
					return (DeviceSubType)0;
				}
				oBSojytRNHSGzEvzQeuQqWjXbCiy.OPVTgVGjujrcLGOlTDqwIYUgSdWu.CtwhuyyQIAolqaPHmDaKOAqjCzGz.tkqxqCqOGHCCuFgcUPHCxZGTXsXr(ddrNxChsiLuVtQynDItAHKGwFiuaA.Any, out var kkCedRUBGjrnSczYvIhPFYMUDQuP);
				return (DeviceSubType)kkCedRUBGjrnSczYvIhPFYMUDQuP.UuufXcGQVQfYNpwoxWXOjOlzAcLqA;
			}
		}

		internal XInputControllerExtension(dthckWzdCvyytSjahUhAscVvCaQb.iUVRQWivcUcvaWpmaoyYGuTThrFS P_0)
			: base(new xNFQRrKdXgPaoTBAVEaCSGqlDpMe(P_0))
		{
		}

		private XInputControllerExtension(XInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (QoZvhkzEoqAJYRbDsMOneXLvpaAr)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			oBSojytRNHSGzEvzQeuQqWjXbCiy = source as xNFQRrKdXgPaoTBAVEaCSGqlDpMe;
			QoZvhkzEoqAJYRbDsMOneXLvpaAr = oBSojytRNHSGzEvzQeuQqWjXbCiy != null;
		}

		internal override Controller.Extension Clone()
		{
			return new XInputControllerExtension(this);
		}
	}
}
