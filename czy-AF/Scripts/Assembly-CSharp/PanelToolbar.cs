using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToolbar : MonoBehaviour
{
	private Panel panel;

	private void Awake()
	{
		panel = GetComponent<Panel>();
		Panel.SetTarget(panel);
		Panel.CreateComponent("target", "button", new Hashtable
		{
			{ "text", "Local" },
			{ "width", 60 }
		});
		Panel.CreateDivider(visible: false);
		List<string> value = new List<string> { "icon_gridHalf", "icon_grid" };
		Panel.CreateComponent("grid", "iconToggle", new Hashtable
		{
			{ "list", value },
			{ "width", 24 },
			{ "tooltip", "1/10th grid when moving blocks" }
		});
		List<string> value2 = new List<string> { "icon_gridSquare", "icon_gridHexagon" };
		Panel.CreateComponent("shape", "iconToggle", new Hashtable
		{
			{ "list", value2 },
			{ "width", 24 },
			{ "tooltip", "Grid shape" }
		});
		Panel.CreateDivider(visible: false);
		Panel.CreateComponent("icon", "icon", new Hashtable
		{
			{ "icon", "icon_position" },
			{ "width", 24 },
			{ "tooltip", "Grid translation" }
		});
		Panel.CreateComponent("position", "rocker", new Hashtable
		{
			{ "initial", 1f },
			{ "minimum", 0.1f },
			{ "maximum", 10f },
			{ "step", 0.1f },
			{ "width", 90 }
		});
		Panel.CreateDivider(visible: false);
		Panel.CreateComponent("icon", "icon", new Hashtable
		{
			{ "icon", "icon_rotation" },
			{ "width", 24 },
			{ "tooltip", "Grid rotation" }
		});
		Panel.CreateComponent("rotation", "rocker", new Hashtable
		{
			{ "initial", 15f },
			{ "minimum", 5f },
			{ "maximum", 90f },
			{ "step", 5f },
			{ "modifier", "°" },
			{ "width", 90 }
		});
		Panel.CreateDivider(visible: false);
		Panel.CreateComponent("icon", "icon", new Hashtable
		{
			{ "icon", "icon_layers" },
			{ "width", 24 },
			{ "tooltip", "Level" }
		});
		Control.layerInput = Panel.CreateComponent("layer", "rocker", new Hashtable
		{
			{ "initial", 0f },
			{ "minimum", -30f },
			{ "maximum", 30f },
			{ "step", 1f },
			{ "width", 90 }
		});
		Panel.CreateDivider(visible: false);
		List<string> value3 = new List<string> { "icon_axisX", "icon_axisY", "icon_axisZ" };
		Control.axisToggle = Panel.CreateComponent("axis", "iconToggle", new Hashtable
		{
			{ "list", value3 },
			{ "width", 24 },
			{ "tooltip", "Axis" }
		});
		panel.SetValue("axis", 1);
		Panel.CreateComponent("mirror", "button", new Hashtable
		{
			{ "icon", "icon_mirror" },
			{ "width", 24 },
			{ "tooltip", "Mirror" }
		});
		Panel.CreateComponent("rotate", "button", new Hashtable
		{
			{ "icon", "icon_rotate" },
			{ "width", 24 },
			{ "tooltip", "Rotate" }
		});
		Panel.CreateDivider(visible: false);
		Panel.CreateComponent("exportModel", "button", new Hashtable
		{
			{ "width", 64 },
			{ "tooltip", "Export model..." },
			{ "text", "Model" }
		});
		Panel.CreateComponent("exportSprite", "button", new Hashtable
		{
			{ "width", 64 },
			{ "tooltip", "Export sprite..." },
			{ "text", "Sprite" }
		});
	}

	private void targetCallback(Transform t)
	{
		if (Gizmo.instance.local)
		{
			panel.SetValue("target", "Global");
			Gizmo.instance.local = false;
		}
		else
		{
			panel.SetValue("target", "Local");
			Gizmo.instance.local = true;
		}
		Selection.Update();
	}

	private void positionChange(float i)
	{
		Control.grid = i;
	}

	private void rotationChange(float i)
	{
		Control.gridRotate = i;
	}

	private void gridToggle(int index)
	{
		Control.gridDivide = index == 0;
	}

	private void shapeToggle(int index)
	{
		if (index == 0)
		{
			Control.gridShape = 0;
			Grid.instance.SetShape("square");
		}
		else
		{
			Control.gridShape = 1;
			Grid.instance.SetShape("hexagon");
		}
	}

	private void layerChange(float i)
	{
		Global.elements["global"].GetComponent<Control>().SetLayer(i);
	}

	private void axisToggle(int index)
	{
		Control.ToggleAxis();
	}

	private void mirrorCallback(Transform t)
	{
		Global.elements["global"].GetComponent<Control>().ActionMirror();
	}

	private void rotateCallback(Transform t)
	{
		Global.elements["global"].GetComponent<Control>().ActionRotate();
		Tips.Show("rotate");
	}

	private void exportModelCallback()
	{
		Global.elements["sidebar"].GetComponent<Sidebar>().Open("panel_3d");
	}

	private void exportSpriteCallback()
	{
		Global.elements["sidebar"].GetComponent<Sidebar>().Open("panel_2d");
	}
}
