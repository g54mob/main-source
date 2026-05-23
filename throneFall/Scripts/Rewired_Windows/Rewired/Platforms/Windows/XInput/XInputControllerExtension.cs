using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XInputControllerExtension : Controller.Extension
	{
		private class YWhjSdjepjdPAyEXWYAGqaoGCesG : IControllerExtensionSource
		{
			private YeDLvUUmeuKtQrgSaWuhUANSLKCe.RxhEziXVhDGFUrIhpfyWqJviVifY wNAJAJLKDcSRWEJPpGOfOLrTmCgC;

			public YeDLvUUmeuKtQrgSaWuhUANSLKCe.RxhEziXVhDGFUrIhpfyWqJviVifY jKhEHpcbloJYfyxoSmeigsyRusuSA => wNAJAJLKDcSRWEJPpGOfOLrTmCgC;

			public YWhjSdjepjdPAyEXWYAGqaoGCesG(YeDLvUUmeuKtQrgSaWuhUANSLKCe.RxhEziXVhDGFUrIhpfyWqJviVifY P_0)
			{
				wNAJAJLKDcSRWEJPpGOfOLrTmCgC = P_0;
			}
		}

		private YWhjSdjepjdPAyEXWYAGqaoGCesG LqqkKOSDSQmeXrscVBeWIOJuFJMv;

		private bool fGbUfMAIzrGzaucMxkYhQErIclcCA;

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
				if (!fGbUfMAIzrGzaucMxkYhQErIclcCA || !base.enabled)
				{
					return 0;
				}
				if (LqqkKOSDSQmeXrscVBeWIOJuFJMv.jKhEHpcbloJYfyxoSmeigsyRusuSA == null)
				{
					return 0;
				}
				return (int)LqqkKOSDSQmeXrscVBeWIOJuFJMv.jKhEHpcbloJYfyxoSmeigsyRusuSA.hKUlDKLcVZeLUBLOxAsWsgYYIgsab.ICLivXqZjTcEOtKLUTCQvIuGeaaJ;
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
				if (!fGbUfMAIzrGzaucMxkYhQErIclcCA || !base.enabled)
				{
					return CapabilityFlags.None;
				}
				if (LqqkKOSDSQmeXrscVBeWIOJuFJMv.jKhEHpcbloJYfyxoSmeigsyRusuSA == null)
				{
					return CapabilityFlags.None;
				}
				LqqkKOSDSQmeXrscVBeWIOJuFJMv.jKhEHpcbloJYfyxoSmeigsyRusuSA.hKUlDKLcVZeLUBLOxAsWsgYYIgsab.ArSbRwiRPYkwQXRjHYLMEdmwQpnVA(WOPJEgIDdQArVapyKhtYfhoFkxGBb.Any, out var fuoOEptqBeePsHoFyhrBbbubKTYKA2);
				return (CapabilityFlags)fuoOEptqBeePsHoFyhrBbbubKTYKA2.spDYOlORxbAPLKtgJmoCLLSGPrTb;
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
				if (!fGbUfMAIzrGzaucMxkYhQErIclcCA || !base.enabled)
				{
					return (DeviceType)0;
				}
				if (LqqkKOSDSQmeXrscVBeWIOJuFJMv.jKhEHpcbloJYfyxoSmeigsyRusuSA == null)
				{
					return (DeviceType)0;
				}
				LqqkKOSDSQmeXrscVBeWIOJuFJMv.jKhEHpcbloJYfyxoSmeigsyRusuSA.hKUlDKLcVZeLUBLOxAsWsgYYIgsab.ArSbRwiRPYkwQXRjHYLMEdmwQpnVA(WOPJEgIDdQArVapyKhtYfhoFkxGBb.Any, out var fuoOEptqBeePsHoFyhrBbbubKTYKA2);
				return (DeviceType)fuoOEptqBeePsHoFyhrBbbubKTYKA2.CNliDePjFozkbvaebGtSjVPspbmN;
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
				if (!fGbUfMAIzrGzaucMxkYhQErIclcCA || !base.enabled)
				{
					return (DeviceSubType)0;
				}
				if (LqqkKOSDSQmeXrscVBeWIOJuFJMv.jKhEHpcbloJYfyxoSmeigsyRusuSA == null)
				{
					return (DeviceSubType)0;
				}
				LqqkKOSDSQmeXrscVBeWIOJuFJMv.jKhEHpcbloJYfyxoSmeigsyRusuSA.hKUlDKLcVZeLUBLOxAsWsgYYIgsab.ArSbRwiRPYkwQXRjHYLMEdmwQpnVA(WOPJEgIDdQArVapyKhtYfhoFkxGBb.Any, out var fuoOEptqBeePsHoFyhrBbbubKTYKA2);
				return (DeviceSubType)fuoOEptqBeePsHoFyhrBbbubKTYKA2.jAGxgIdGONyatJVreDZIeDNOphhn;
			}
		}

		internal XInputControllerExtension(YeDLvUUmeuKtQrgSaWuhUANSLKCe.RxhEziXVhDGFUrIhpfyWqJviVifY P_0)
			: base(new YWhjSdjepjdPAyEXWYAGqaoGCesG(P_0))
		{
		}

		private XInputControllerExtension(XInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (fGbUfMAIzrGzaucMxkYhQErIclcCA)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			LqqkKOSDSQmeXrscVBeWIOJuFJMv = source as YWhjSdjepjdPAyEXWYAGqaoGCesG;
			fGbUfMAIzrGzaucMxkYhQErIclcCA = LqqkKOSDSQmeXrscVBeWIOJuFJMv != null;
		}

		internal override Controller.Extension Clone()
		{
			return new XInputControllerExtension(this);
		}
	}
}
