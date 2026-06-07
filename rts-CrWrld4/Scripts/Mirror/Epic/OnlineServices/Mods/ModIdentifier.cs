namespace Epic.OnlineServices.Mods
{
	public class ModIdentifier : ISettable
	{
		public string NamespaceId { get; set; }

		public string ItemId { get; set; }

		public string ArtifactId { get; set; }

		public string Title { get; set; }

		public string Version { get; set; }

		internal void Set(ModIdentifierInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
