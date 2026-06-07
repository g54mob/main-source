namespace Assets.Scripts.Mods
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
