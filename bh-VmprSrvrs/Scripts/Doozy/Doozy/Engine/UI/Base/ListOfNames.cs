using System;
using System.Collections.Generic;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Base
{
	[Serializable]
	public class ListOfNames : ScriptableObject
	{
		public string CategoryName;

		public NamesDatabaseType DatabaseType;

		public List<string> Names;

		private static UILanguagePack UILabels => null;

		public void AddName(string value, bool performUndo, bool saveAssets = false)
		{
		}

		public void AddNames(List<string> names, bool performUndo, bool saveAssets = false)
		{
		}

		public void Clear(bool performUndo, bool saveAssets = false)
		{
		}

		public bool Contains(string value)
		{
			return false;
		}

		public void RemoveDuplicateNames()
		{
		}

		public void RemoveEmptyNames()
		{
		}

		public void RemoveName(string value, bool performUndo, bool saveAssets = false)
		{
		}

		public void Rename(string newCategoryName, string newAssetName, bool saveAssets)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}
	}
}
