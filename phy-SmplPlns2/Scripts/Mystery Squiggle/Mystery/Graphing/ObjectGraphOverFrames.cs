namespace Mystery.Graphing
{
	public class ObjectGraphOverFrames : ObjectGraphOverFrames<object>
	{
	}
	public class ObjectGraphOverFrames<T> : LineGraphOverFrames<T>
	{
		private static ObjectValueTransformer<T> ValueTransformer;

		public override ValueTransformer<T> ValueTransformerY
		{
			get
			{
				if (ValueTransformer == null)
				{
					ValueTransformer = new ObjectValueTransformer<T>();
				}
				return ValueTransformer;
			}
		}

		public override ValueRange<T> CreateRangeY()
		{
			return new ObjectRange<T>();
		}
	}
}
