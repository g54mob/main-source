using System;
using System.Collections.Generic;

namespace Doozy.Engine.UI.Animation
{
	[Serializable]
	public class UIAnimationsDatabase
	{
		public List<string> DatabaseNames;

		public AnimationType DatabaseType;

		public List<UIAnimationDatabase> Databases;

		public UIAnimationsDatabase(AnimationType animationType)
		{
		}

		public bool AddUIAnimationDatabase(UIAnimationDatabase database)
		{
			return false;
		}

		public bool Contains(string databaseName)
		{
			return false;
		}

		public bool Contains(UIAnimationDatabase database)
		{
			return false;
		}

		public UIAnimationDatabase Get(string databaseName)
		{
			return null;
		}

		public void Update()
		{
		}

		private void AddTheDefaultUIAnimationDatabase()
		{
		}

		private void AddUnreferencedPresets()
		{
		}

		private void RenameAssetFileNamesToReflectDatabaseNames()
		{
		}

		private void RemoveEmptyDatabases()
		{
		}

		private void Sort()
		{
		}

		private void UpdateDatabaseNames()
		{
		}

		private void UpdateDatabases()
		{
		}
	}
}
