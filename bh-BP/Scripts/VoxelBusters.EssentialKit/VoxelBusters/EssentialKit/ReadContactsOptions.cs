namespace VoxelBusters.EssentialKit
{
	public class ReadContactsOptions
	{
		public class Builder
		{
			private ReadContactsOptions m_options;

			public Builder WithLimit(int limit)
			{
				return null;
			}

			public Builder WithOffset(int offset)
			{
				return null;
			}

			public Builder WithConstraints(ReadContactsConstraint constraints)
			{
				return null;
			}

			public ReadContactsOptions Build()
			{
				return null;
			}
		}

		public int Limit { get; private set; }

		public int Offset { get; private set; }

		public ReadContactsConstraint Constraints { get; private set; }

		private ReadContactsOptions()
		{
		}
	}
}
