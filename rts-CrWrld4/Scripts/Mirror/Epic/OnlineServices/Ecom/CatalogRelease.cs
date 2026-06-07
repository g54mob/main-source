namespace Epic.OnlineServices.Ecom
{
	public class CatalogRelease : ISettable
	{
		public string[] CompatibleAppIds { get; set; }

		public string[] CompatiblePlatforms { get; set; }

		public string ReleaseNote { get; set; }

		internal void Set(CatalogReleaseInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
