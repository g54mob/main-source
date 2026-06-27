using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XInputControllerExtension : Controller.Extension
	{
		private class MULsorMgesdoSMIKvSPEHSSteHxX : IControllerExtensionSource
		{
			private GPtQVYpGsbJZEFsgHCDbdnqvIWNV.BuZsqkobnKmKKBwfCtzQJcPDbpshA yakGzNgxCfHDAqIZYFHjlBfmfpjs;

			public GPtQVYpGsbJZEFsgHCDbdnqvIWNV.BuZsqkobnKmKKBwfCtzQJcPDbpshA zNPQGfORpdwThLkybBhwNkCiqlvW => yakGzNgxCfHDAqIZYFHjlBfmfpjs;

			public MULsorMgesdoSMIKvSPEHSSteHxX(GPtQVYpGsbJZEFsgHCDbdnqvIWNV.BuZsqkobnKmKKBwfCtzQJcPDbpshA P_0)
			{
				yakGzNgxCfHDAqIZYFHjlBfmfpjs = P_0;
			}
		}

		private MULsorMgesdoSMIKvSPEHSSteHxX ZBOYJOrLYPqxTZCeoodYnodXhSDFA;

		private bool tkRJeGvvbgoVyUEcQDgdfVWvwtlE;

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
				if (!tkRJeGvvbgoVyUEcQDgdfVWvwtlE || !base.enabled)
				{
					return 0;
				}
				if (ZBOYJOrLYPqxTZCeoodYnodXhSDFA.zNPQGfORpdwThLkybBhwNkCiqlvW == null)
				{
					return 0;
				}
				return (int)ZBOYJOrLYPqxTZCeoodYnodXhSDFA.zNPQGfORpdwThLkybBhwNkCiqlvW.lKwCSEEkROkYChTOUcjWBVqnXfnR.EMbalJDpZYbzIDeAnaYOCNWpJzvS;
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
				if (!tkRJeGvvbgoVyUEcQDgdfVWvwtlE || !base.enabled)
				{
					return CapabilityFlags.None;
				}
				if (ZBOYJOrLYPqxTZCeoodYnodXhSDFA.zNPQGfORpdwThLkybBhwNkCiqlvW == null)
				{
					return CapabilityFlags.None;
				}
				ZBOYJOrLYPqxTZCeoodYnodXhSDFA.zNPQGfORpdwThLkybBhwNkCiqlvW.lKwCSEEkROkYChTOUcjWBVqnXfnR.QespQokIBJHnMBvhumKWbAYLNayUA(CKzzXstLbLWeHDegzKeIKdCmmoDQ.Any, out var zeUjBxbSTxpQeenLFPmXUASDQAJKb2);
				return (CapabilityFlags)zeUjBxbSTxpQeenLFPmXUASDQAJKb2.gzzJbStZZaNQPqRvwpkmefllGboi;
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
				if (!tkRJeGvvbgoVyUEcQDgdfVWvwtlE || !base.enabled)
				{
					return (DeviceType)0;
				}
				if (ZBOYJOrLYPqxTZCeoodYnodXhSDFA.zNPQGfORpdwThLkybBhwNkCiqlvW == null)
				{
					return (DeviceType)0;
				}
				ZBOYJOrLYPqxTZCeoodYnodXhSDFA.zNPQGfORpdwThLkybBhwNkCiqlvW.lKwCSEEkROkYChTOUcjWBVqnXfnR.QespQokIBJHnMBvhumKWbAYLNayUA(CKzzXstLbLWeHDegzKeIKdCmmoDQ.Any, out var zeUjBxbSTxpQeenLFPmXUASDQAJKb2);
				return (DeviceType)zeUjBxbSTxpQeenLFPmXUASDQAJKb2.CGXrPmkAHbdknThwMCeUCRvBXobO;
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
				if (!tkRJeGvvbgoVyUEcQDgdfVWvwtlE || !base.enabled)
				{
					return (DeviceSubType)0;
				}
				if (ZBOYJOrLYPqxTZCeoodYnodXhSDFA.zNPQGfORpdwThLkybBhwNkCiqlvW == null)
				{
					return (DeviceSubType)0;
				}
				ZBOYJOrLYPqxTZCeoodYnodXhSDFA.zNPQGfORpdwThLkybBhwNkCiqlvW.lKwCSEEkROkYChTOUcjWBVqnXfnR.QespQokIBJHnMBvhumKWbAYLNayUA(CKzzXstLbLWeHDegzKeIKdCmmoDQ.Any, out var zeUjBxbSTxpQeenLFPmXUASDQAJKb2);
				return (DeviceSubType)zeUjBxbSTxpQeenLFPmXUASDQAJKb2.ltyEzAUDGIGljcxlLnKQTBtdwwyY;
			}
		}

		internal XInputControllerExtension(GPtQVYpGsbJZEFsgHCDbdnqvIWNV.BuZsqkobnKmKKBwfCtzQJcPDbpshA P_0)
			: base(new MULsorMgesdoSMIKvSPEHSSteHxX(P_0))
		{
		}

		private XInputControllerExtension(XInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (tkRJeGvvbgoVyUEcQDgdfVWvwtlE)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			ZBOYJOrLYPqxTZCeoodYnodXhSDFA = source as MULsorMgesdoSMIKvSPEHSSteHxX;
			tkRJeGvvbgoVyUEcQDgdfVWvwtlE = ZBOYJOrLYPqxTZCeoodYnodXhSDFA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new XInputControllerExtension(this);
		}
	}
}
