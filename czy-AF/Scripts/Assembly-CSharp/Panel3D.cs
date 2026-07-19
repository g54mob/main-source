using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel3D : MonoBehaviour
{
	private Panel panel;

	public List<Preset> presets = new List<Preset>();

	private void Start()
	{
		presets = Presets.GetPresets("3d");
		panel = Panel.SetTarget(GetComponent<Panel>());
		List<string> list = new List<string>();
		foreach (Preset preset in presets)
		{
			list.Add(preset.data["title"]);
		}
		Panel.CreateComponent("preset", "dropdown", new Hashtable
		{
			{ "label", "Preset" },
			{ "list", list },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateDivider();
		List<string> value = new List<string> { "OBJ", "FBX", "DAE", "GLTF", "STL" };
		Panel.CreateComponent("format", "dropdown", new Hashtable
		{
			{ "label", "Format" },
			{ "list", value },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateComponent("selection", "checkbox", new Hashtable
		{
			{ "label", "Export selection only" },
			{ "value", false }
		});
		Panel.CreateComponent("merge", "checkbox", new Hashtable
		{
			{ "label", "Merge blocks" },
			{ "value", false }
		});
		Panel.CreateComponent("colormap", "checkbox", new Hashtable
		{
			{ "label", "Generate color map" },
			{ "value", false }
		});
		Panel.CreateDivider();
		List<string> value2 = new List<string> { "Y is up", "X is up", "Z is up" };
		Panel.CreateComponent("orientation", "dropdown", new Hashtable
		{
			{ "label", "Orientation" },
			{ "list", value2 },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateComponent("scale", "input", new Hashtable
		{
			{ "label", "Scale" },
			{ "value", "100" },
			{ "min", 0f },
			{ "max", 10000f },
			{ "content", "number" }
		});
		Panel.CreateDivider();
		Panel.CreateComponent("export", "button", new Hashtable { { "text", "Export" } });
		presetSelect(0);
	}

	public void presetSelect(int i)
	{
		foreach (string key in presets[i].data.Keys)
		{
			panel.SetValue(key, presets[i].data[key]);
		}
		UpdateDisplay();
	}

	public void formatSelect(int i)
	{
		UpdateDisplay(i);
	}

	private void UpdateDisplay(int index = -1)
	{
		int num = (int)panel.GetValue("format");
		if (index != -1)
		{
			num = index;
		}
		if (num == 4)
		{
			panel.SetValue("merge", true);
			panel.SetValue("textures", false);
			panel.DisableElement("merge");
			panel.DisableElement("textures");
			panel.DisableElement("colormap");
		}
		else
		{
			panel.EnableElement("merge");
			panel.EnableElement("textures");
			panel.EnableElement("colormap");
		}
	}

	private void exportCallback(Transform t)
	{
		int filetype = (int)panel.GetValue("format");
		bool merge = (bool)panel.GetValue("merge");
		bool selection = (bool)panel.GetValue("selection");
		bool textures = true;
		bool colormap = (bool)panel.GetValue("colormap");
		int orientation = (int)panel.GetValue("orientation");
		float scale = float.Parse(panel.GetValue("scale") as string);
		Export.ExportModel(filetype, merge, textures, colormap, orientation, scale, 0f, selection);
	}
}
