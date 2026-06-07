namespace ModApi.Core
{
	public struct ModPartInfo
	{
		public string Id { get; private set; }

		public string PrefabPath { get; private set; }

		public string XmlPath { get; private set; }

		public ModPartInfo(string id, string prefabPath, string xmlPath)
		{
			this = default(ModPartInfo);
			Id = id;
			PrefabPath = prefabPath;
			XmlPath = xmlPath;
		}
	}
}
