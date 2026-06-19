using System;
using System.Runtime.CompilerServices;
using TMPEffects.Databases;
using TMPEffects.ObjectChanged;

namespace TMPEffects.Components.Animator
{
	internal class KeywordDatabaseWrapper : INotifyObjectChanged, IDisposable
	{
		private ITMPKeywordDatabase[] databases;

		private bool disposed;

		private CompositeTMPKeywordDatabase compDatabase;

		public ITMPKeywordDatabase Database => null;

		public event ObjectChangedEventHandler ObjectChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public KeywordDatabaseWrapper(params ITMPKeywordDatabase[] databases)
		{
		}

		private void RaiseObjectChanged(object sender)
		{
		}

		public void Dispose()
		{
		}
	}
}
