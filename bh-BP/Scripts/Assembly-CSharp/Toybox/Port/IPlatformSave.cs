namespace Toybox.Port
{
	public interface IPlatformSave
	{
		string PathPrefix();

		void SaveToStorage(string path, byte[] bytes);

		bool HaveFilePath(string path);

		bool IsInitialized();

		void AddFilePath(string path);

		byte[] LoadFilePath(string path);

		void DeleteFile(string path);

		void Update();
	}
}
