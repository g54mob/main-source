namespace NSMedieval.Structs
{
	public struct Support
	{
		private bool x;

		private bool z;

		public bool X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public bool Z
		{
			get
			{
				return z;
			}
			set
			{
				z = value;
			}
		}

		public bool ToBool
		{
			get
			{
				if (x || z)
				{
					return true;
				}
				return false;
			}
		}

		public Support(bool x, bool z)
		{
			this.x = x;
			this.z = z;
		}
	}
}
