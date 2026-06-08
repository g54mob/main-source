using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIModListSimple : MonoBehaviour, IUIList
{
	private const float SPACE_MAX = 365f;

	public bool enableQtyDisplayOnItems;

	public GameObject categoryPrefab;

	public UIModTextLabel executeButton;

	public UIModTextLabel clearButton;

	public bool IsQueueList;

	protected Dictionary<string, UIModCategory> categoryDict;

	private List<string> categoryOrderList;

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public int ItemCount
	{
		get
		{
			if (categoryDict != null)
			{
				return categoryDict.Count;
			}
			return 0;
		}
	}

	public int CurrentHighlightedIndex { get; private set; }

	public object TargetObject { get; set; }

	public int CurrentPageIndex
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	private void OnDestroy()
	{
		categoryPrefab = null;
	}

	public void Clear(bool deleteItems)
	{
		if (categoryDict != null)
		{
			Dictionary<string, UIModCategory>.Enumerator enumerator = categoryDict.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (deleteItems)
				{
					enumerator.Current.Value.DeleteAllItems();
				}
				enumerator.Current.Value.Clear();
				GameObjectPool.Instance.PushObject(enumerator.Current.Value.gameObject);
			}
			categoryDict.Clear();
		}
		if (categoryOrderList != null)
		{
			categoryOrderList.Clear();
		}
		CurrentHighlightedIndex = -1;
		PostChange();
	}

	public virtual bool AddCategory(GameObject parent, string catKey, string catDescription)
	{
		float spaceAvailable = GetSpaceAvailable();
		if (spaceAvailable < 35f)
		{
			return false;
		}
		if (categoryDict == null)
		{
			categoryDict = new Dictionary<string, UIModCategory>();
		}
		if (categoryOrderList == null)
		{
			categoryOrderList = new List<string>();
		}
		if (!categoryDict.ContainsKey(catKey))
		{
			GameObject gameObject = GameObjectPool.Instance.PopObject("ModCategory");
			UIModCategory component = gameObject.GetComponent<UIModCategory>();
			component.ParentList = this;
			component.EnableQtyDisplay = enableQtyDisplayOnItems;
			component.descriptionLabel.text = catDescription;
			if (parent != null)
			{
				gameObject.transform.SetParent(parent.transform);
			}
			else
			{
				Debug.LogWarning("An invalid/null parent provided when trying to add a catetory object (ModListSimple's containing object).  It won't be parented to anything, and won't appear correctly in the scene");
			}
			gameObject.transform.localScale = Vector3.one;
			categoryDict.Add(catKey, component);
			categoryOrderList.Add(catKey);
		}
		PostChange();
		return true;
	}

	public virtual bool AddBackendItem(string catKey, IModification mod, bool isExclusiveItem, IUIItem originalItem)
	{
		bool flag = false;
		float spaceAvailable = GetSpaceAvailable();
		if (spaceAvailable < 0f)
		{
			return false;
		}
		if (categoryDict == null || !categoryDict.ContainsKey(catKey))
		{
			if (!AddCategory(null, catKey, "Unknown Category"))
			{
				return false;
			}
			flag = categoryDict[catKey].AddBackendItem(base.gameObject, mod, isExclusiveItem, originalItem);
		}
		else
		{
			flag = categoryDict[catKey].AddBackendItem(categoryDict[catKey].gameObject, mod, isExclusiveItem, originalItem);
		}
		if (flag)
		{
			PostChange();
		}
		else
		{
			CommonAudioHelper.Instance.PlayErrorSound();
		}
		return flag;
	}

	public virtual void Refresh()
	{
		CurrentHighlightedIndex = -1;
		if (categoryDict != null && categoryDict.Count > 0)
		{
			CurrentHighlightedIndex = 0;
		}
	}

	public void GotFocus()
	{
		throw new NotImplementedException();
	}

	public void LoseFocus()
	{
		if (CurrentHighlightedIndex != -1)
		{
			string key = categoryOrderList[CurrentHighlightedIndex];
			categoryDict[key].LoseFocus();
		}
	}

	public bool MoveDown()
	{
		if (categoryDict != null && categoryDict.Count > 0)
		{
			string key = categoryOrderList[CurrentHighlightedIndex];
			if (categoryDict[key].MoveDown())
			{
				CurrentHighlightedIndex += 1;
				if (CurrentHighlightedIndex >= categoryDict.Count)
				{
					CurrentHighlightedIndex = 0;
				}
				key = categoryOrderList[CurrentHighlightedIndex];
				categoryDict[key].MoveToTop();
			}
		}
		return false;
	}

	public bool MoveUp()
	{
		if (categoryDict != null && categoryDict.Count > 0)
		{
			string key = categoryOrderList[CurrentHighlightedIndex];
			if (categoryDict[key].MoveUp())
			{
				CurrentHighlightedIndex -= 1;
				if (CurrentHighlightedIndex < 0)
				{
					CurrentHighlightedIndex = categoryDict.Count - 1;
				}
				key = categoryOrderList[CurrentHighlightedIndex];
				categoryDict[key].MoveToBottom();
			}
		}
		return false;
	}

	public bool MoveToBottom()
	{
		if (categoryDict != null && categoryDict.Count > 0)
		{
			CurrentHighlightedIndex = categoryOrderList.Count - 1;
			string key = categoryOrderList[CurrentHighlightedIndex];
			return categoryDict[key].MoveToBottom();
		}
		return true;
	}

	public bool MoveToTop()
	{
		if (categoryDict != null && categoryDict.Count > 0)
		{
			CurrentHighlightedIndex = 0;
			string key = categoryOrderList[CurrentHighlightedIndex];
			return categoryDict[key].MoveToTop();
		}
		return true;
	}

	public void MoveToTopOrSelected()
	{
		MoveToTop();
	}

	public bool DeleteHighlightedItem()
	{
		bool flag = true;
		string catKey = string.Empty;
		IUIItem highlightedItem = GetHighlightedItem(out catKey);
		if (!string.IsNullOrEmpty(catKey))
		{
			UIModCategory uIModCategory = categoryDict[catKey];
			flag = uIModCategory.DeleteHighlightedItem();
			if (flag)
			{
				if (uIModCategory.ItemCount == 0)
				{
					UnityEngine.Object.Destroy(uIModCategory.UnderlyingGameObject);
					categoryOrderList.Remove(catKey);
					categoryDict.Remove(catKey);
					if (categoryDict.Count == 0)
					{
						CurrentHighlightedIndex = -1;
					}
					else
					{
						CurrentHighlightedIndex = 0;
						catKey = categoryOrderList[CurrentHighlightedIndex];
						categoryDict[catKey].MoveToTop();
					}
				}
				else
				{
					categoryDict[catKey].MoveToTop();
				}
			}
		}
		PostChange();
		return flag;
	}

	public void DeleteAllItems()
	{
		int count = categoryDict.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			categoryDict.ElementAt(num).Value.DeleteAllItems();
		}
		PostChange();
	}

	public bool RemoveBackendSelectedItem()
	{
		return false;
	}

	public void AddBackendItem(IUIItem item)
	{
	}

	public IUIItem SelectHighlightedItem()
	{
		if (CurrentHighlightedIndex > -1)
		{
			string key = categoryOrderList[CurrentHighlightedIndex];
			UIModCategory uIModCategory = categoryDict[key];
			uIModCategory.Select();
			return uIModCategory.GetSelectedItem();
		}
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		string catKey = string.Empty;
		return GetHighlightedItem(out catKey);
	}

	public IUIItem GetHighlightedItem(out string catKey)
	{
		catKey = string.Empty;
		if (categoryDict == null || categoryDict.Count == 0)
		{
			return null;
		}
		Dictionary<string, UIModCategory>.Enumerator enumerator = categoryDict.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IUIItem highlightedItem = enumerator.Current.Value.GetHighlightedItem();
			if (highlightedItem != null)
			{
				catKey = enumerator.Current.Key;
				return highlightedItem;
			}
		}
		return null;
	}

	public IUIItem GetSelectedItem()
	{
		Dictionary<string, UIModCategory>.Enumerator enumerator = categoryDict.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IUIItem selectedItem = enumerator.Current.Value.GetSelectedItem();
			if (selectedItem != null)
			{
				return selectedItem;
			}
		}
		return null;
	}

	public int GetTotalCost()
	{
		int num = 0;
		if (categoryDict != null)
		{
			Dictionary<string, UIModCategory>.Enumerator enumerator = categoryDict.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num += enumerator.Current.Value.GetCost();
			}
		}
		return num;
	}

	public void RefreshListOnScrap(int totalCost)
	{
		if (categoryDict != null)
		{
			Dictionary<string, UIModCategory>.Enumerator enumerator = categoryDict.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.RefreshListOnScrap(totalCost);
			}
		}
	}

	public bool Execute()
	{
		return Execute(false);
	}

	public bool Execute(bool ignoreMaxScrap)
	{
		if (executeButton.IsActive && !executeButton.IsError)
		{
			bool flag = true;
			if (!ignoreMaxScrap)
			{
				int totalCost = GetTotalCost();
				if (totalCost + GlobalSettings.GameState.ThePlayer.Inventory.Scrap > GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax)
				{
					flag = false;
					DialogUI.Instance.ShowDialog("Warning!", string.Format("The net total of scrap that will be generated ({0}) exceeds the ship's capacity by {1}.\r\n\r\nThat excess scrap will be discarded.  Are you sure you want to continue?", totalCost, totalCost - (GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax - GlobalSettings.GameState.ThePlayer.Inventory.Scrap)), ModalWindowType.YesNo, delegate(ModalWindowResult result, string InputString)
					{
						if (result == ModalWindowResult.Yes)
						{
							Execute(true);
						}
						ModificationUI.Instance.Refresh();
					}, 1);
				}
			}
			if (flag && !GameSaveFile.Get("WS_STALE", false) && categoryDict.Count > 0)
			{
				if (!GameSaveFile.Get("HNT_DISABLE", false) && GameSaveFile.Get("MISSIONS", 0) == 0 && !GameSaveFile.Get("WS_FP_SCRAP", false))
				{
					flag = false;
					DialogUI.Instance.ShowDialog("Warning!", "You are about to scrap equipment before your first mission.\r\n\r\nAre you sure you want to do this?\r\n\r\nThis warning will not appear again...", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
					{
						if (result == ModalWindowResult.Yes && Execute())
						{
							ModificationUI.Instance.Refresh();
						}
					}, 1);
					GameSaveFile.Save("WS_FP_SCRAP", true);
				}
				GameSaveFile.Save("WS_STALE", true);
			}
			if (flag)
			{
				Dictionary<string, UIModCategory>.Enumerator enumerator = categoryDict.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.Value.Execute();
				}
				Clear(false);
				return true;
			}
		}
		return false;
	}

	private float GetSpaceAvailable()
	{
		if (categoryDict == null || categoryDict.Count == 0)
		{
			return 365f;
		}
		float num = 0f;
		Dictionary<string, UIModCategory>.Enumerator enumerator = categoryDict.GetEnumerator();
		while (enumerator.MoveNext())
		{
			num += 25f;
			num += (float)(enumerator.Current.Value.ItemCount * 35);
		}
		return 365f - num;
	}

	private void PostChange()
	{
		ModificationUI.Instance.RefreshScrap();
		if (categoryDict == null || categoryDict.Count == 0)
		{
			if (executeButton != null)
			{
				executeButton.SetInactive();
				ModificationUI.Instance.commandHints.ExecuteCommand.enabled = false;
			}
			if (clearButton != null)
			{
				clearButton.SetInactive();
				ModificationUI.Instance.commandHints.ClearCommand.enabled = false;
			}
			return;
		}
		if (executeButton != null)
		{
			int num = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
			if (ModificationUI.Instance.QueueContainer.modList != null)
			{
				num += ModificationUI.Instance.QueueContainer.modList.GetTotalCost();
			}
			if (num < 0)
			{
				executeButton.SetError();
				ModificationUI.Instance.commandHints.ExecuteCommand.enabled = false;
			}
			else
			{
				executeButton.SetActive();
				ModificationUI.Instance.commandHints.ExecuteCommand.enabled = true;
			}
		}
		if (clearButton != null)
		{
			clearButton.SetActive();
			ModificationUI.Instance.commandHints.ClearCommand.enabled = true;
		}
	}
}
