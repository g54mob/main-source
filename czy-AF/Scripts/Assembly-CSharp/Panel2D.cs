using System.Collections;
using System.Collections.Generic;
using HorizonBasedAmbientOcclusion;
using UnityEngine;

public class Panel2D : MonoBehaviour
{
	private Panel panel;

	private float shadowIntensity = 0.3f;

	private Vector3 lightRotation = new Vector3(110f, 10f, 0f);

	private int exportCount = 1;

	public List<Preset> presets = new List<Preset>();

	private void Start()
	{
		presets = Presets.GetPresets("2d");
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
		List<string> value = new List<string> { "Default", "Isometric (45°)", "Isometric (30°)", "Isometric (35°)", "Top-down", "Side (left)", "Side (right)", "Front", "Back" };
		Panel.CreateComponent("camera", "dropdown", new Hashtable
		{
			{ "label", "Camera" },
			{ "list", value },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateComponent("header", "vector3Header", new Hashtable { { "label", "" } });
		Panel.CreateComponent("position", "vector3", new Hashtable { { "label", "Position" } });
		Panel.CreateComponent("rotation", "vector3", new Hashtable { { "label", "Rotation" } });
		Panel.CreateComponent("zoom", "input", new Hashtable
		{
			{ "label", "Distance" },
			{ "value", "3.5" },
			{ "min", 0.1f },
			{ "max", 20f },
			{ "content", "number" }
		});
		Panel.CreateDivider();
		Panel.CreateComponent("light", "vector3", new Hashtable { { "label", "Light" } });
		Panel.CreateComponent("shadows", "input", new Hashtable
		{
			{ "label", "Shadows" },
			{ "value", "30" },
			{ "min", 0f },
			{ "max", 100f },
			{ "content", "number" },
			{ "horizontal", 0.6f }
		});
		Panel.CreateComponent("ambientOcclusion", "input", new Hashtable
		{
			{ "label", "Ambient occlusion" },
			{ "value", "100" },
			{ "min", 0f },
			{ "max", 100f },
			{ "content", "number" },
			{ "horizontal", 0.6f }
		});
		Panel.CreateDivider();
		List<string> value2 = new List<string> { "None", "4 Directions", "8 Directions", "16 Directions", "32 Directions", "64 Directions", "128 Directions" };
		Panel.CreateComponent("batch", "dropdown", new Hashtable
		{
			{ "label", "Batch angles" },
			{ "list", value2 },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateComponent("size", "input", new Hashtable
		{
			{ "label", "Size" },
			{ "value", "512" },
			{ "min", 16f },
			{ "max", 2048f },
			{ "content", "integer" }
		});
		Panel.CreateDivider();
		Panel.CreateComponent("export", "button", new Hashtable { { "text", "Export 1 file..." } });
		PreparePanel();
	}

	public void presetSelect(int i)
	{
		foreach (string key in presets[i].data.Keys)
		{
			panel.SetValue(key, presets[i].data[key]);
		}
		UpdatePreview();
	}

	private void PreparePanel()
	{
		Vector3 position = Global.elements["cameraRender"].parent.position;
		Vector3 vector = Global.elements["cameraRender"].parent.eulerAngles - new Vector3(0f, 180f, 0f);
		panel.SetValue("position", position);
		panel.SetValue("rotation", vector);
		panel.SetValue("light", lightRotation);
	}

	private void positionChange(Vector3 v)
	{
		positionUpdate(v);
	}

	private void positionUpdate(Vector3 v)
	{
		Global.elements["cameraRender"].parent.position = v;
		UpdatePreview();
	}

	private void rotationChange(Vector3 v)
	{
		rotationUpdate(v);
	}

	private void rotationUpdate(Vector3 v)
	{
		Global.elements["cameraRender"].parent.eulerAngles = v + new Vector3(0f, 180f, 0f);
		UpdatePreview();
	}

	private void lightChange(Vector3 v)
	{
		lightUpdate(v);
	}

	private void lightUpdate(Vector3 v)
	{
		Global.elements["light"].rotation = Quaternion.Euler(v);
		UpdatePreview();
	}

	private void zoomChange(string n)
	{
		zoomUpdate(n);
	}

	private void zoomUpdate(string n)
	{
		Global.elements["cameraRender"].GetComponent<Camera>().orthographicSize = float.Parse(n);
		UpdatePreview();
	}

	private void shadowsChange(string n)
	{
		shadowsUpdate(n);
	}

	private void shadowsUpdate(string n)
	{
		shadowIntensity = float.Parse(n) / 100f;
		Object.FindObjectOfType<Light>().shadowStrength = shadowIntensity;
		UpdatePreview();
	}

	private void ambientOcclusionChange(string n)
	{
		ambientOcclusionUpdate(n);
	}

	private void ambientOcclusionUpdate(string n)
	{
		HBAO component = Global.elements["cameraRender"].GetComponent<HBAO>();
		HBAO.AOSettings aoSettings = component.aoSettings;
		aoSettings.intensity = float.Parse(n) / 100f;
		component.aoSettings = aoSettings;
		UpdatePreview();
	}

	private void cameraSelect(int i)
	{
		Vector3 vector = Vector3.zero;
		switch (i)
		{
		case 0:
			vector = new Vector3(35f, 45f, 0f);
			break;
		case 1:
			vector = new Vector3(45f, 45f, 0f);
			break;
		case 2:
			vector = new Vector3(30f, 30f, 0f);
			break;
		case 3:
			vector = new Vector3(45f, 35.264f, 0f);
			break;
		case 4:
			vector = new Vector3(90f, 0f, 0f);
			break;
		case 5:
			vector = new Vector3(0f, 90f, 0f);
			break;
		case 6:
			vector = new Vector3(0f, -90f, 0f);
			break;
		case 7:
			vector = new Vector3(0f, 0f, 0f);
			break;
		case 8:
			vector = new Vector3(0f, 180f, 0f);
			break;
		}
		panel.SetValue("rotation", vector);
		rotationUpdate(vector);
	}

	private void batchSelect(int i)
	{
		exportCount = 1;
		switch (i)
		{
		case 1:
			exportCount = 4;
			break;
		case 2:
			exportCount = 8;
			break;
		case 3:
			exportCount = 16;
			break;
		case 4:
			exportCount = 32;
			break;
		case 5:
			exportCount = 64;
			break;
		case 6:
			exportCount = 128;
			break;
		}
		panel.SetValue("export", $"Export {exportCount} file(s)...");
	}

	private void Open()
	{
		if (panel != null)
		{
			panel.SetValue("shadows", (shadowIntensity * 100f).ToString());
		}
		Global.elements["preview"].gameObject.SetActive(value: true);
		Export.GeneratePreview();
	}

	private void Close()
	{
		Global.elements["preview"].gameObject.SetActive(value: false);
		Object.FindObjectOfType<Light>().shadowStrength = 0.3f;
	}

	private void OnDisable()
	{
		try
		{
			Close();
		}
		catch
		{
		}
	}

	private void UpdatePreview()
	{
		Export.GeneratePreview();
	}

	private void exportCallback(Transform t)
	{
		int size = int.Parse(panel.GetValue("size") as string);
		if (exportCount == 1)
		{
			Export.ExportSprite(size);
		}
		else
		{
			StartCoroutine(Export.ExportSprites(size, exportCount));
		}
	}
}
