using System;
using System.Collections.Generic;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIPopupDatabase : ScriptableObject
	{
		public List<string> PopupNames;

		public List<UIPopupLink> Popups;

		private static UILanguagePack UILabels => null;

		public bool IsEmpty => false;

		public bool Add(UIPopupLink popupLink, bool performUndo, bool saveAssets)
		{
			return false;
		}

		public bool Contains(string popupName)
		{
			return false;
		}

		public bool Contains(UIPopup prefab)
		{
			return false;
		}

		public bool CreateUIPopupLink(string popupName, GameObject prefab, bool performUndo, bool saveAssets)
		{
			return false;
		}

		public bool DeletePopupLink(UIPopupLink reference)
		{
			return false;
		}

		public GameObject GetPrefab(string popupName)
		{
			return null;
		}

		public string GetPopupName(UIPopup prefab)
		{
			return null;
		}

		public int IndexOf(string popupName)
		{
			return 0;
		}

		public int IndexOf(UIPopup prefab)
		{
			return 0;
		}

		public void RefreshDatabase(bool performUndo, bool saveAssets)
		{
		}

		public void RemoveLink(string popupName, bool showDialog, bool saveAssets)
		{
		}

		public void RemoveUnreferencedData(bool saveAssets = false)
		{
		}

		public bool ResetDatabase()
		{
			return false;
		}

		public void SearchForUnregisteredLinks(bool saveAssets)
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

		public void UpdateListOfPopupNames()
		{
		}
	}
}
