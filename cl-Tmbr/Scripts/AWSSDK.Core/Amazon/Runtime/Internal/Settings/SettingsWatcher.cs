using System;
using System.IO;

namespace Amazon.Runtime.Internal.Settings
{
	public class SettingsWatcher : IDisposable
	{
		private string type;

		public bool Enable { get; set; }

		public event EventHandler SettingsChanged;

		private SettingsWatcher()
		{
			throw new NotSupportedException();
		}

		internal SettingsWatcher(string filePath, string type)
		{
			Path.GetDirectoryName(filePath);
			Path.GetFileName(filePath);
			this.type = type;
		}

		public SettingsCollection GetSettings()
		{
			return PersistenceManager.Instance.GetSettings(type);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
