namespace ModApi.Core
{
	public struct PersistentObjectInfo
	{
		public string Path { get; set; }

		public PersistentObjectInfo(string path)
		{
			this = default(PersistentObjectInfo);
			Path = path;
		}
	}
}
