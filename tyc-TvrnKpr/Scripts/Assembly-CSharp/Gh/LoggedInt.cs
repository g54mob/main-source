namespace Gh
{
	public class LoggedInt : LoggedValue<int>
	{
		public int? Min { get; set; }

		public int? Max { get; set; }

		public override int Value
		{
			get
			{
				return 0;
			}
			protected set
			{
			}
		}

		protected override int Add(int a, int b)
		{
			return 0;
		}

		public static implicit operator int(LoggedInt v)
		{
			return 0;
		}

		public override int CompareTo(LoggedValue<int> other)
		{
			return 0;
		}
	}
}
