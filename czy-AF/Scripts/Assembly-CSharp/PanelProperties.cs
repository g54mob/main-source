using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelProperties : MonoBehaviour
{
	private Panel panel;

	private void Awake()
	{
		panel = GetComponent<Panel>();
		Panel.SetTarget(panel);
		Panel.CreateComponent("name", "input", new Hashtable
		{
			{ "label", "Name" },
			{ "value", "Block" }
		});
		Panel.CreateComponent("block", "label", new Hashtable { { "text", "" } });
		Panel.CreateDivider();
		Panel.CreateComponent("header", "vector3Header", new Hashtable { { "label", "" } });
		Panel.CreateComponent("position", "vector3", new Hashtable { { "label", "Position" } });
		Panel.CreateComponent("rotation", "vector3", new Hashtable { { "label", "Rotation" } });
		Panel.CreateComponent("scale", "vector3", new Hashtable { { "label", "Scale" } });
		Panel.CreateDivider();
		Panel.CreateComponent("locked", "checkbox", new Hashtable
		{
			{ "label", "Locked" },
			{ "value", false }
		});
		Panel.CreateComponent("hidden", "checkbox", new Hashtable
		{
			{ "label", "Hidden" },
			{ "value", false }
		});
	}

	private void OnEnable()
	{
		Update();
	}

	private void Update()
	{
		try
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<InputField>();
		}
		catch
		{
			if (Selection.list.Count == 1)
			{
				BlockComponent component = Selection.list[0].GetComponent<BlockComponent>();
				Block data = component.data;
				panel.SetValue("block", data.collection + " • " + data.type);
				panel.SetValue("name", data.name);
				panel.SetValue("position", component.transform.position);
				panel.SetValue("rotation", component.transform.eulerAngles);
				panel.SetValue("scale", component.transform.localScale);
				panel.SetValue("locked", data.locked);
				panel.SetValue("hidden", data.hidden);
				panel.Enable();
			}
			else
			{
				panel.Disable();
			}
		}
	}

	private void positionUpdate(Vector3 v)
	{
		Selection.list[0].position = v;
		UpdateGizmoPosition();
		UpdateProperty();
	}

	private void rotationUpdate(Vector3 v)
	{
		Selection.list[0].eulerAngles = v;
		UpdateGizmoPosition();
		UpdateProperty();
	}

	private void scaleUpdate(Vector3 v)
	{
		Selection.list[0].localScale = v;
		Control.UpdateScale();
		UpdateGizmoPosition();
		UpdateProperty();
	}

	private void nameUpdate(string n)
	{
		Block data = Selection.list[0].GetComponent<BlockComponent>().data;
		n = Regex.Replace(n, "(?i)[^A-Z0-9\t. _-]", "");
		data.name = n;
		UpdateProperty();
	}

	private void lockedToggle(bool t)
	{
		foreach (Transform item in Selection.list)
		{
			item.GetComponent<BlockComponent>().data.locked = t;
		}
		UpdateProperty();
	}

	private void hiddenToggle(bool t)
	{
		foreach (Transform item in Selection.list)
		{
			item.GetComponent<BlockComponent>().data.hidden = t;
			if (t)
			{
				item.gameObject.layer = 10;
			}
			else
			{
				item.gameObject.layer = 1;
			}
		}
		UpdateProperty();
	}

	private void UpdateProperty()
	{
		Selection.Update();
		Undo.AddState();
	}

	private void UpdateGizmoPosition()
	{
		Global.elements["gizmo"].GetComponent<Gizmo>().SetGizmoPosition();
	}
}
