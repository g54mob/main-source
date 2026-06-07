namespace SwissCode.Steam
{
	public struct SteamFile
	{
		public readonly string Name;

		public readonly byte[] Data;

		public readonly int Size;

		public SteamFile(string name, byte[] data)
		{
			Name = name;
			Data = data;
			Size = data.Length;
		}
	}
}
