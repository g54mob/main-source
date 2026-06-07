namespace Toybox.Port
{
	public class PCSave : IPlatformSave
	{
		public string PathPrefix()
		{
			return null;
		}

		public void DeleteFile(string path)
		{
		}

		public bool HaveFilePath(string path)
		{
			return false;
		}

		public bool IsInitialized()
		{
			return false;
		}

		public byte[] LoadFilePath(string path)
		{
			return null;
		}

		public void SaveToStorage(string path, byte[] bytes)
		{
		}

		public void AddFilePath(string path)
		{
		}

		public void Update()
		{
		}
	}
}
