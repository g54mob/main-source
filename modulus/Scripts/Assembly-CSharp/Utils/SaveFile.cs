using Data.SaveData.PersistentSOs;

namespace Utils
{
	public struct SaveFile
	{
		public string Name;

		public string Path;

		public SaveInfoPersistentSO Info;

		public SaveFile(string name, string path, SaveInfoPersistentSO info)
		{
			Name = name;
			Path = path;
			Info = info;
		}
	}
}
