using System;
using System.Collections.Generic;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Base
{
	[Serializable]
	public class NamesDatabase : ScriptableObject
	{
		public const string BACK = "Back";

		public const string CUSTOM = "Custom";

		public const string DOWN = "Down";

		public const string GENERAL = "General";

		public const string LEFT = "Left";

		public const string MASTER_CANVAS = "MasterCanvas";

		public const string RIGHT = "Right";

		public const string UNNAMED = "Unnamed";

		public const string UP = "Up";

		public NamesDatabaseType DatabaseType;

		public List<string> CategoryNames;

		public List<ListOfNames> Categories;

		private static UILanguagePack UILabels => null;

		public bool IsEmpty => false;

		public bool Add(ListOfNames category, bool performUndo, bool saveAssets)
		{
			return false;
		}

		public void AddDefaultCategories(bool saveAssets)
		{
		}

		public bool Contains(string categoryName)
		{
			return false;
		}

		public bool CreateCategory(string categoryName, List<string> names, bool showDialog = false, bool saveAssets = false)
		{
			return false;
		}

		public bool CreateCategory(string relativePath, string categoryName, List<string> names, bool showDialog = false, bool saveAssets = false)
		{
			return false;
		}

		public bool DeleteCategory(ListOfNames category)
		{
			return false;
		}

		public ListOfNames GetCategory(string categoryName)
		{
			return null;
		}

		public List<string> GetNamesList(string categoryName, bool getDirectReference = false)
		{
			return null;
		}

		public void RefreshDatabase(bool performUndo, bool saveAssets)
		{
		}

		public void RemoveCategory(string categoryName, bool showDialog, bool saveAssets)
		{
		}

		public bool Rename(string oldCategoryName, string newCategoryName, bool performUndo = true, bool saveAssets = false)
		{
			return false;
		}

		public void RemoveDuplicateNamesFromCategories(bool performUndo, bool saveAssets = false)
		{
		}

		public void RemoveNullDatabases(bool saveAssets = false)
		{
		}

		public void RemoveEmptyNames(bool performUndo, bool saveAssets = false)
		{
		}

		public void RemoveUnreferencedData(bool saveAssets = false)
		{
		}

		public bool ResetDatabase()
		{
			return false;
		}

		public void SearchForUnregisteredDatabases(bool saveAssets)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void Sort(bool performUndo, bool saveAssets = false)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}

		public void UpdateListOfCategoryNames()
		{
		}

		public static bool CanDeleteItem(NamesDatabase database, string itemName)
		{
			return false;
		}

		public static NamesDatabase GetDatabase(string fileName, string resourcesPath)
		{
			return null;
		}

		public static string GetPath(NamesDatabaseType databaseType)
		{
			return null;
		}

		public static DoozyPath.ComponentName GetComponentName(NamesDatabaseType databaseType)
		{
			return default(DoozyPath.ComponentName);
		}

		private static string GetDatabaseFileName(NamesDatabaseType databaseType, string categoryName)
		{
			return null;
		}
	}
}
