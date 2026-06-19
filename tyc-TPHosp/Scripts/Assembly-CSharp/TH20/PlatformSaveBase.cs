using System;

namespace TH20
{
	public abstract class PlatformSaveBase : MustCallDestroy
	{
		protected App _app;

		public bool AllowAsync { get; set; } = true;

		public abstract string CloudDirectory { get; }

		public abstract bool IsAvailable { get; }

		public abstract bool UsesVariableBackupSaveAmount { get; }

		public virtual int MaxSandboxSaves => -1;

		public virtual void Initialise()
		{
		}

		public void AssignApp(App app)
		{
			_app = app;
		}

		public abstract bool Save(string path, byte[] writeData, bool useBackups);

		public abstract byte[] Load(string path);

		public abstract bool FileExists(string fileName);

		public abstract bool DirectoryExists(string path);

		public abstract bool DeleteSave(string path, bool deleteBackups);

		public abstract bool MoveSave(string sourcePath, string destinationPath);

		public abstract void CreateDirectory(string path);

		public abstract bool DeleteDirectory(string path);

		public abstract string[] GetAllFiles(string path);

		public abstract string[] GetDirectories(string path);

		public abstract bool MoveAllBackupSavesUp(string path);

		public abstract bool FixupBackupSaveIndices(string path);

		public abstract void RefreshForUserChanged(Action<bool> onComplete);
	}
}
