namespace Brewery.Minigames
{
	public struct CandidateStates
	{
		public bool Dirty;

		public bool Soapy;

		public bool Unsanitized;

		public bool Wet;

		public bool IsSanitized => false;

		public CandidateStates(bool dirty, bool soapy, bool unsanitized, bool wet)
		{
			Dirty = false;
			Soapy = false;
			Unsanitized = false;
			Wet = false;
		}

		public bool ApplyBrush()
		{
			return false;
		}

		public bool ApplyRinse()
		{
			return false;
		}

		public bool ApplySanitize()
		{
			return false;
		}

		public bool ApplyDry()
		{
			return false;
		}
	}
}
