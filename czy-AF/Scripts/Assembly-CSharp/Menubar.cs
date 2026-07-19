using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menubar : MonoBehaviour
{
	private float width;

	private int padding = 24;

	public Transform template;

	public static Dictionary<string, DropdownItem> items = new Dictionary<string, DropdownItem>();

	private void Start()
	{
		template.gameObject.SetActive(value: false);
		List<Transform> list = new List<Transform>();
		foreach (Transform item in base.transform)
		{
			list.Add(item);
		}
		foreach (Transform item2 in list)
		{
			if (item2 == template || !item2.gameObject.activeSelf || (!Application.isEditor && item2.name == "Debug"))
			{
				continue;
			}
			GameObject gameObject = Object.Instantiate(template.gameObject, base.transform);
			gameObject.name = item2.name;
			gameObject.transform.GetChild(0).GetComponent<Text>().text = item2.name;
			gameObject.transform.localPosition = new Vector3(width, 0f, 0f);
			foreach (DropdownItem item3 in item2.GetComponent<DropdownItems>().items)
			{
				gameObject.GetComponent<ComponentDropdown>().advancedItems.Add(item3);
				if (!items.ContainsKey(item2.name + "/" + item3.id))
				{
					items.Add(item2.name + "/" + item3.id, item3);
				}
			}
			float preferredWidth = gameObject.transform.GetChild(0).GetComponent<Text>().preferredWidth;
			gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(preferredWidth + (float)padding, item2.GetComponent<RectTransform>().rect.height);
			width += preferredWidth + (float)padding;
			gameObject.SetActive(value: true);
			item2.gameObject.SetActive(value: false);
		}
		Disable("Script/repeat");
	}

	public void Open()
	{
		Toggle("Edit/undo", Undo.CanUndo());
		Toggle("Edit/redo", Undo.CanRedo());
		bool flag = Selection.list.Count > 0;
		Toggle("Edit/cut", flag);
		Toggle("Edit/copy", flag);
		Toggle("Edit/moveFloor", flag);
		Toggle("Edit/moveCenter", flag);
		Toggle("Edit/hide", flag);
		Toggle("Edit/lock", flag);
		Toggle("Edit/group", flag);
		Toggle("Edit/ungroup", flag);
		Toggle("Edit/paste", Global.elements["clipboard"].childCount > 0);
	}

	public void Select(string item)
	{
		if (!Global.control)
		{
			return;
		}
		switch (item)
		{
		case "File/new":
			Project.New();
			break;
		case "File/open":
			Project.Open();
			break;
		case "File/merge":
			Project.Open(merge: true);
			break;
		case "File/save":
			Project.Save();
			break;
		case "File/saveAs":
			Project.SaveAs();
			break;
		case "File/export2D":
			Global.elements["sidebar"].GetComponent<Sidebar>().Open("panel_2d");
			break;
		case "File/export3D":
			Global.elements["sidebar"].GetComponent<Sidebar>().Open("panel_3d");
			break;
		case "File/exit":
			Application.Quit();
			break;
		case "Edit/undo":
			Undo.UndoState();
			break;
		case "Edit/redo":
			Undo.RedoState();
			break;
		case "Edit/cut":
			Control.Cut();
			break;
		case "Edit/copy":
			Control.Copy();
			break;
		case "Edit/paste":
			Control.Paste();
			break;
		case "Edit/moveFloor":
			Control.MoveFloor();
			break;
		case "Edit/moveCenter":
			Control.MoveCenter();
			break;
		case "Edit/hide":
			Control.Hide();
			break;
		case "Edit/unhide":
			Control.Unhide();
			break;
		case "Edit/group":
			Control.Group();
			break;
		case "Edit/ungroup":
			Control.Ungroup();
			break;
		case "Edit/lock":
			Control.Lock();
			break;
		case "Edit/unlock":
			Control.Unlock();
			break;
		case "Edit/preferences":
			Global.elements["sidebar"].GetComponent<Sidebar>().Open("panel_preferences");
			break;
		case "Materials/new":
			Swatches.CreateMaterial();
			break;
		case "Materials/remove":
			if (Swatches.swatch != null)
			{
				Swatches.RemoveMaterial(Swatches.swatch);
			}
			break;
		case "Materials/purge":
			Swatches.RemoveUnusedMaterials();
			break;
		case "Blocks/loadCollection":
			CollectionBundle.InstallBundleSelect();
			break;
		case "Blocks/openFolder":
			Application.OpenURL("file://" + Global.GetDataFolder("Collections"));
			break;
		case "Script/open":
			Procedural.LoadLua();
			break;
		case "Script/repeat":
			Procedural.RepeatLua();
			break;
		case "Debug/exportHotkeys":
			Hotkey.ExportKeys();
			break;
		case "Debug/exportEvents":
			EventManager.ExportEvents();
			break;
		case "Debug/countMaterials":
			Global.ShowMessage("Materials in scene: " + Swatches.CountMaterials());
			break;
		case "Debug/countBlocks":
			Global.ShowMessage("Blocks in scene: " + Global.SceneBlocks().Count);
			break;
		case "Debug/exportModules":
			Play.ExportModules();
			break;
		case "Debug/countCollections":
			Collections.CountCollections();
			break;
		case "Debug/createBundle":
			CollectionBundle.CreateBundleSelect();
			break;
		case "Debug/loadBundle":
			CollectionBundle.InstallBundleSelect();
			break;
		case "Help/documentation":
			Application.OpenURL("https://kenney.nl/knowledge-base/asset-forge");
			break;
		case "Help/community":
			Application.OpenURL("https://kenney.itch.io/assetforge/community");
			break;
		case "Help/about":
			Application.OpenURL("http://assetforge.io/");
			break;
		}
	}

	public static void Enable(string item)
	{
		items[item].enabled = true;
	}

	public static void Disable(string item)
	{
		items[item].enabled = false;
	}

	public static void Toggle(string item, bool enabled)
	{
		items[item].enabled = enabled;
	}
}
