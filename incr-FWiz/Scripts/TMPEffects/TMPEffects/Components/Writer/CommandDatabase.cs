using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPEffects.Databases;
using TMPEffects.Databases.CommandDatabase;
using TMPEffects.ObjectChanged;
using TMPEffects.TMPCommands;

namespace TMPEffects.Components.Writer
{
	internal class CommandDatabase : ITMPEffectDatabase<ITMPCommand>, ITMPEffectDatabase, INotifyObjectChanged, IDisposable
	{
		private TMPCommandDatabase database;

		private IDictionary<string, TMPSceneCommandWrapper> sceneCommands;

		private bool disposed;

		public TMPCommandDatabase Database => null;

		public IDictionary<string, TMPSceneCommandWrapper> SceneCommands => null;

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

		public CommandDatabase(TMPCommandDatabase database, IDictionary<string, TMPSceneCommandWrapper> sceneCommands)
		{
		}

		private void RaiseObjectChanged(object sender)
		{
		}

		private void RaiseObjectChanged(object sender, PropertyChangedEventArgs args)
		{
		}

		public bool ContainsEffect(string name)
		{
			return false;
		}

		public ITMPCommand GetEffect(string name)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
