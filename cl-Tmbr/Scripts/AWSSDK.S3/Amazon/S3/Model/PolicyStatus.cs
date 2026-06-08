namespace Amazon.S3.Model
{
	public class PolicyStatus
	{
		private bool? isPublic;

		public bool? IsPublic
		{
			get
			{
				return isPublic;
			}
			set
			{
				isPublic = value;
			}
		}

		internal bool IsSetIsPublic()
		{
			return isPublic.HasValue;
		}
	}
}
