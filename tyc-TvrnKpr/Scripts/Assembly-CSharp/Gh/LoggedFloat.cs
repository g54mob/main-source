namespace Gh
{
	public class LoggedFloat : LoggedValue<float>
	{
		public float? Min { get; set; }

		public float? Max { get; set; }

		public override float Value
		{
			get
			{
				return 0f;
			}
			protected set
			{
			}
		}

		public LoggedFloat()
		{
		}

		public LoggedFloat(float value)
		{
		}

		public void Reset(float value)
		{
		}

		protected override float Add(float a, float b)
		{
			return 0f;
		}

		public static implicit operator float(LoggedFloat v)
		{
			return 0f;
		}

		public override string GetTooltipText()
		{
			return null;
		}

		public override int CompareTo(LoggedValue<float> other)
		{
			return 0;
		}
	}
}
