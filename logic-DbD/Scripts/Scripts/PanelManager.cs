using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
	private class PanelData
	{
		public GameObject panel;

		public bool canDelete;

		public bool canRename;

		public PanelData(GameObject panel, bool canDelete, bool canRename)
		{
			this.panel = panel;
			this.canDelete = canDelete;
			this.canRename = canRename;
		}
	}

	private Dictionary<string, PanelData> panels = new Dictionary<string, PanelData>();

	private static int panelsOpen;

	public bool OpenPanel(string tableName)
	{
		bool num = Contains(tableName);
		if (num)
		{
			OpenWindow(panels[tableName].panel);
		}
		return num;
	}

	public bool Contains(string tableName)
	{
		return panels.ContainsKey(tableName);
	}

	public void ManagePanel(string name, GameObject panel, bool canDelete, bool canRename)
	{
		panels.Add(name, new PanelData(panel, canDelete, canRename));
	}

	public void ManagePanel(string name, GameObject panel)
	{
		panels.Add(name, new PanelData(panel, canDelete: false, canRename: false));
	}

	public void ClearNames(ICollection<string> names = null)
	{
		if (names == null)
		{
			names = new List<string>(panels.Keys);
		}
		foreach (string name in names)
		{
			MonoBehaviour.print("destroying " + name);
			DestroyPanel(name);
		}
		panels.Clear();
	}

	public bool DestroyPanel(string tableName)
	{
		if (panels.ContainsKey(tableName))
		{
			GameObject panel = panels[tableName].panel;
			TaskbarManager.RemoveFromTaskbar(panel);
			UnityEngine.Object.Destroy(panel);
			panels.Remove(tableName);
			return true;
		}
		return false;
	}

	public bool IsReadOnly(string tableName)
	{
		if (panels.ContainsKey(tableName) && !panels[tableName].canDelete)
		{
			return !panels[tableName].canRename;
		}
		return false;
	}

	public bool IsDeletable(string tableName)
	{
		if (panels.ContainsKey(tableName))
		{
			return panels[tableName].canDelete;
		}
		return false;
	}

	public bool IsRenamable(string tableName)
	{
		if (panels.ContainsKey(tableName))
		{
			return panels[tableName].canRename;
		}
		return false;
	}

	public GameObject GetPanel(string tableName)
	{
		if (panels.ContainsKey(tableName))
		{
			return panels[tableName].panel;
		}
		throw new ArgumentException(tableName + " not being managed by PanelManager");
	}

	public void RenamePanel(string oldName, string newName)
	{
		if (panels.ContainsKey(oldName) && !panels.ContainsKey(newName))
		{
			GameObject panel = panels[oldName].panel;
			TextMeshProUGUI component = panel.transform.Find("Toolbar/Window Name").GetComponent<TextMeshProUGUI>();
			component.text = newName;
			SetWindowSize(panel.GetComponent<RectTransform>(), component.preferredWidth);
			panels.Add(newName, panels[oldName]);
			panels.Remove(oldName);
		}
	}

	public ICollection<string> GetTableNames()
	{
		return panels.Keys;
	}

	public static void OpenWindow(GameObject window)
	{
		window.SetActive(value: true);
		window.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f);
		UIUtils.SetPenultimateLayer(window);
		Panel component = window.GetComponent<Panel>();
		if (component != null)
		{
			component.OpenPanel();
		}
	}

	private void SetWindowSize(RectTransform windowTransform, float tableNameSize)
	{
		float num = Mathf.Max(25f + tableNameSize + 40f);
		if (windowTransform.rect.width < num)
		{
			windowTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
		}
	}

	public static void AdjustScrollableHeight(RectTransform rt)
	{
		float height = rt.rect.height;
		rt.anchoredPosition = new Vector3(0f, height / 2f);
	}
}
