namespace Amazon.RuntimeDependencies
{
	public class S3ClientContext
	{
		public enum ActionContext
		{
			DynamoBDS3Link = 0
		}

		public ActionContext Action { get; set; }

		public RegionEndpoint Region { get; set; }
	}
}
