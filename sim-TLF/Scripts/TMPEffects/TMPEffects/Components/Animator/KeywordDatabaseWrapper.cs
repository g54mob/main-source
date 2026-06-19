using System;
using TMPEffects.Databases;
using TMPEffects.ObjectChanged;

namespace TMPEffects.Components.Animator
{
	internal class KeywordDatabaseWrapper : INotifyObjectChanged, IDisposable
	{
		private ITMPKeywordDatabase[] databases;

		private bool disposed;

		private CompositeTMPKeywordDatabase compDatabase;

		public ITMPKeywordDatabase Database => compDatabase;

		public event ObjectChangedEventHandler ObjectChanged;

		public KeywordDatabaseWrapper(params ITMPKeywordDatabase[] databases)
		{
			this.databases = databases;
			for (int i = 0; i < this.databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = this.databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase is INotifyObjectChanged notifyObjectChanged)
				{
					notifyObjectChanged.ObjectChanged += RaiseObjectChanged;
				}
			}
			compDatabase = new CompositeTMPKeywordDatabase(databases);
		}

		private void RaiseObjectChanged(object sender)
		{
			this.ObjectChanged?.Invoke(this);
		}

		public void Dispose()
		{
			if (disposed)
			{
				return;
			}
			disposed = true;
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase is INotifyObjectChanged notifyObjectChanged)
				{
					notifyObjectChanged.ObjectChanged -= RaiseObjectChanged;
				}
			}
			databases = null;
			this.ObjectChanged = null;
		}
	}
}
