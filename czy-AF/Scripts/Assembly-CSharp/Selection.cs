using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
	public delegate void SelectionAction();

	public static List<Transform> list = new List<Transform>();

	public static bool allowSelection = true;

	public static event SelectionAction OnSelectionChanged;

	public static void Enable()
	{
		allowSelection = true;
	}

	public static void Disable()
	{
		allowSelection = false;
	}

	public static void SelectAll()
	{
		if (!allowSelection)
		{
			return;
		}
		Clear();
		List<Transform> list = new List<Transform>();
		foreach (Transform item in Global.elements["workbench"])
		{
			list.Add(item);
		}
		foreach (Transform item2 in list)
		{
			Block data = item2.GetComponent<BlockComponent>().data;
			if (!data.hidden && !data.locked)
			{
				Add(item2);
			}
		}
	}

	public static void Clear()
	{
		if (!allowSelection)
		{
			return;
		}
		foreach (Transform item in list)
		{
			item.GetComponent<BlockComponent>().data.select = false;
			UpdateLayer(item);
			item.SetParent(Global.elements["workbench"]);
		}
		list.Clear();
		Global.elements["selection"].eulerAngles = Vector3.zero;
		Global.elements["selection"].localScale = new Vector3(1f, 1f, 1f);
		Update();
	}

	public static void Add(Transform t, bool checkGroup = true)
	{
		if (!allowSelection)
		{
			return;
		}
		Transform transform = Global.elements["selection"];
		Block data = t.GetComponent<BlockComponent>().data;
		if (!data.locked)
		{
			if (transform.childCount == 0)
			{
				transform.position = t.transform.position;
			}
			t.SetParent(transform);
			if (!data.select)
			{
				data.select = true;
				UpdateLayer(t);
				list.Add(t);
			}
			Update();
		}
	}

	public static void Remove(Transform t)
	{
		if (!allowSelection)
		{
			return;
		}
		Block data = t.GetComponent<BlockComponent>().data;
		t.SetParent(Global.elements["workbench"]);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == t)
			{
				data.select = false;
				UpdateLayer(t);
				list.RemoveAt(i);
			}
		}
		Update();
	}

	public static void Toggle(Transform t)
	{
		if (!t.GetComponent<BlockComponent>().data.select)
		{
			Add(t);
		}
		else
		{
			Remove(t);
		}
	}

	public static void Refresh()
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item in Selection.list)
		{
			list.Add(item);
		}
		Clear();
		foreach (Transform item2 in list)
		{
			Add(item2, checkGroup: false);
		}
	}

	public static void Update()
	{
		if (Selection.OnSelectionChanged != null)
		{
			Selection.OnSelectionChanged();
		}
		Transform parent = Global.elements["workbench"];
		Transform transform = Global.elements["selection"];
		Vector3 position = Vector3.zero;
		if (list.Count >= 1)
		{
			position = Global.GetBounds(list).center;
			Gizmo.instance.transform.position = position;
			Global.SetLayerRecursively(Gizmo.instance.transform, 9);
		}
		else
		{
			Global.SetLayerRecursively(Gizmo.instance.transform, 10);
		}
		if (list.Count > 1)
		{
			foreach (Transform item in list)
			{
				item.SetParent(parent);
			}
			transform.position = position;
			foreach (Transform item2 in list)
			{
				item2.SetParent(transform);
			}
			Gizmo.instance.transform.rotation = Quaternion.Euler(Vector3.zero);
			Quaternion rotation = list[0].rotation;
			bool flag = true;
			foreach (Transform item3 in list)
			{
				if (item3.rotation != rotation)
				{
					flag = false;
					break;
				}
			}
			if (flag && Gizmo.instance.local)
			{
				Gizmo.instance.transform.rotation = rotation;
			}
		}
		else if (list.Count == 1)
		{
			if (Gizmo.instance.local)
			{
				Gizmo.instance.transform.rotation = list[0].rotation;
			}
			else
			{
				Gizmo.instance.transform.rotation = Quaternion.Euler(Vector3.zero);
			}
		}
	}

	public static void UpdateLayer(Transform t)
	{
		Block data = t.GetComponent<BlockComponent>().data;
		if (data.select)
		{
			if (data.group == "")
			{
				t.gameObject.layer = LayerMask.NameToLayer("Selected");
			}
			else
			{
				t.gameObject.layer = LayerMask.NameToLayer("Grouped");
			}
		}
		else
		{
			t.gameObject.layer = 0;
		}
		if (data.hidden)
		{
			t.gameObject.layer = LayerMask.NameToLayer("Hidden");
		}
	}
}
