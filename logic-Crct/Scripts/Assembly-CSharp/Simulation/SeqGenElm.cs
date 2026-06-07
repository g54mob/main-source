namespace Simulation
{
	public class SeqGenElm : Chip
	{
		private short data;

		private byte position;

		private bool oneshot;

		private double lastchangetime;

		private bool clockstate;

		public bool Bit0Set
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Bit1set
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Bit2Set
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Bit3Set
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Bit4Set
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Bit5Set
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Bit6Set
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Bit7Set
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool OneShot
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool hasReset()
		{
			return false;
		}

		public override string GetName()
		{
			return null;
		}

		public override void SetupPins()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		private void GetNextBit()
		{
		}

		public override void execute()
		{
		}
	}
}
