using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class yVaopJPXddTAwLFWLFskwBVoaisg : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver LvmafjUzQGqiDnMiZfdFizbRjGJh;

			public yVaopJPXddTAwLFWLFskwBVoaisg(IDriver_RailDriver driver)
			{
				LvmafjUzQGqiDnMiZfdFizbRjGJh = driver;
			}
		}

		private yVaopJPXddTAwLFWLFskwBVoaisg ahVlanlbOCBOWeBnfSIFVGtHSeq;

		private Joystick joystick => GetController<Joystick>();

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (ahVlanlbOCBOWeBnfSIFVGtHSeq.LvmafjUzQGqiDnMiZfdFizbRjGJh == null)
				{
					return false;
				}
				return ahVlanlbOCBOWeBnfSIFVGtHSeq.LvmafjUzQGqiDnMiZfdFizbRjGJh.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (ahVlanlbOCBOWeBnfSIFVGtHSeq.LvmafjUzQGqiDnMiZfdFizbRjGJh != null)
				{
					ahVlanlbOCBOWeBnfSIFVGtHSeq.LvmafjUzQGqiDnMiZfdFizbRjGJh.SpeakerEnabled = value;
				}
			}
		}

		internal RailDriverExtension(IDriver_RailDriver driver)
			: base(new yVaopJPXddTAwLFWLFskwBVoaisg(driver))
		{
		}

		private RailDriverExtension(RailDriverExtension source)
			: base(source)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (ahVlanlbOCBOWeBnfSIFVGtHSeq.LvmafjUzQGqiDnMiZfdFizbRjGJh != null && base.enabled)
			{
				ahVlanlbOCBOWeBnfSIFVGtHSeq.LvmafjUzQGqiDnMiZfdFizbRjGJh.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (ahVlanlbOCBOWeBnfSIFVGtHSeq.LvmafjUzQGqiDnMiZfdFizbRjGJh != null && base.enabled)
			{
				ahVlanlbOCBOWeBnfSIFVGtHSeq.LvmafjUzQGqiDnMiZfdFizbRjGJh.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
		}

		internal void FIsQjdAAyWEysCgIuJuNAowHchI(IControllerExtensionSource P_0)
		{
			ahVlanlbOCBOWeBnfSIFVGtHSeq = P_0 as yVaopJPXddTAwLFWLFskwBVoaisg;
		}

		internal Controller.Extension cGSBTlPoJoSUBEuZRjRzMJDgwjh()
		{
			return new RailDriverExtension(this);
		}
	}
}
