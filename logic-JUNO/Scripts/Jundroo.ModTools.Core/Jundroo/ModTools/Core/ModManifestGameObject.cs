namespace Jundroo.ModTools.Core
{
	public struct ModManifestGameObject
	{
		public string Name { get; private set; }

		public string Path { get; private set; }

		public ModManifestGameObject(string name, string path)
		{
			this = default(ModManifestGameObject);
			Name = name;
			Path = path;
		}
	}
}
