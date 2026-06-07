namespace Mystery.Graphing
{
	public class ObjectRange<T> : ValueRange<T>
	{
		public override T Min
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public override T Max
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public override void UpdateMin(T value)
		{
		}

		public override void UpdateMax(T value)
		{
		}

		public override void Reset()
		{
		}
	}
}
