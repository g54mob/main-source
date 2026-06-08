using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int vnEdenUwZllTYBycKwkNdiMcIIS;

		private ControllerType fkEwyowpQQKzBaGTBxLUNmLjHtN;

		private Guid WhXaNimcOuXdrXZrlSbhrrJNttC;

		private string EtZEzXBEhDpEDIEXlPJaGlvBfAuA;

		private Guid RYyJvVjOsatUBPtIuOiQkSmWpUT;

		public int controllerId
		{
			get
			{
				return vnEdenUwZllTYBycKwkNdiMcIIS;
			}
			set
			{
				vnEdenUwZllTYBycKwkNdiMcIIS = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return fkEwyowpQQKzBaGTBxLUNmLjHtN;
			}
			set
			{
				fkEwyowpQQKzBaGTBxLUNmLjHtN = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return WhXaNimcOuXdrXZrlSbhrrJNttC;
			}
			set
			{
				WhXaNimcOuXdrXZrlSbhrrJNttC = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return EtZEzXBEhDpEDIEXlPJaGlvBfAuA;
			}
			set
			{
				EtZEzXBEhDpEDIEXlPJaGlvBfAuA = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return RYyJvVjOsatUBPtIuOiQkSmWpUT;
			}
			set
			{
				RYyJvVjOsatUBPtIuOiQkSmWpUT = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			vnEdenUwZllTYBycKwkNdiMcIIS = -1
		};

		internal ControllerIdentifier(Controller controller)
		{
			vnEdenUwZllTYBycKwkNdiMcIIS = controller.id;
			fkEwyowpQQKzBaGTBxLUNmLjHtN = controller.type;
			WhXaNimcOuXdrXZrlSbhrrJNttC = controller.WhXaNimcOuXdrXZrlSbhrrJNttC;
			EtZEzXBEhDpEDIEXlPJaGlvBfAuA = controller.hardwareIdentifier;
			RYyJvVjOsatUBPtIuOiQkSmWpUT = controller.deviceInstanceGuid;
		}
	}
}
