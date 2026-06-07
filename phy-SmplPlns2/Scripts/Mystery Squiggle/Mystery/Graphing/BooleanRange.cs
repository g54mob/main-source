namespace Mystery.Graphing
{
	public class BooleanRange : ValueRange<bool>
	{
		public override bool Min
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override bool Max
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		public override void UpdateMin(bool value)
		{
		}

		public override void UpdateMax(bool value)
		{
		}

		public override void Reset()
		{
		}
	}
}
