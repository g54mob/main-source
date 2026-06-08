namespace Amazon.S3.Model
{
	public class OwnershipControlsRule
	{
		private ObjectOwnership objectOwnership;

		public ObjectOwnership ObjectOwnership
		{
			get
			{
				return objectOwnership;
			}
			set
			{
				objectOwnership = value;
			}
		}

		internal bool IsSetObjectOwnership()
		{
			return objectOwnership != null;
		}
	}
}
