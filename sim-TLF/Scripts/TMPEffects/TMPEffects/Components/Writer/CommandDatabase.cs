using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		public TMPCommandDatabase Database => database;

		public IDictionary<string, TMPSceneCommandWrapper> SceneCommands => sceneCommands;

		public event ObjectChangedEventHandler ObjectChanged;

		public CommandDatabase(TMPCommandDatabase database, IDictionary<string, TMPSceneCommandWrapper> sceneCommands)
		{
			this.database = database;
			this.sceneCommands = sceneCommands;
			if (database != null)
			{
				database.ObjectChanged += RaiseObjectChanged;
			}
		}

		private void RaiseObjectChanged(object sender)
		{
			this.ObjectChanged?.Invoke(this);
		}

		private void RaiseObjectChanged(object sender, PropertyChangedEventArgs args)
		{
			this.ObjectChanged?.Invoke(this);
		}

		public bool ContainsEffect(string name)
		{
			if (database != null && database.ContainsEffect(name))
			{
				return true;
			}
			if (sceneCommands != null)
			{
				return sceneCommands.ContainsKey(name);
			}
			return false;
		}

		public ITMPCommand GetEffect(string name)
		{
			if (database != null && database.ContainsEffect(name))
			{
				return database.GetEffect(name);
			}
			if (sceneCommands != null && sceneCommands.ContainsKey(name))
			{
				return sceneCommands[name];
			}
			throw new KeyNotFoundException(name);
		}

		public void Dispose()
		{
			if (!disposed)
			{
				disposed = true;
				if (database != null)
				{
					database.ObjectChanged -= RaiseObjectChanged;
				}
				database = null;
				sceneCommands = null;
			}
		}
	}
}
