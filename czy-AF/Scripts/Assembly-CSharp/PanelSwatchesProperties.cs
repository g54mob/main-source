using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwatchesProperties : MonoBehaviour
{
	private List<string> shaders = new List<string>();

	private Panel panel;

	private void Awake()
	{
		panel = Panel.SetTarget(base.transform);
		Panel.CreateComponent("textureScale", "input", new Hashtable
		{
			{ "label", "Scale" },
			{ "value", "0.5" },
			{ "min", 0.1f },
			{ "max", 2f },
			{ "content", "number" }
		});
		List<string> value = new List<string> { "Triplanar", "UV Map" };
		Panel.CreateComponent("mapping", "dropdown", new Hashtable
		{
			{ "label", "Mapping" },
			{ "list", value },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateDivider();
		shaders = Shaders.GetShaders();
		Panel.CreateComponent("shader", "dropdown", new Hashtable
		{
			{ "label", "Shader" },
			{ "list", shaders },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateComponent("valueA", "input", new Hashtable
		{
			{ "label", "Metallic" },
			{ "value", "0.5" },
			{ "min", 0f },
			{ "max", 1f },
			{ "content", "number" }
		});
		Panel.CreateComponent("valueB", "input", new Hashtable
		{
			{ "label", "Glossiness" },
			{ "value", "0.5" },
			{ "min", 0f },
			{ "max", 1f },
			{ "content", "number" }
		});
		EventManager.StartListening("ChangeSwatch", DisplayUpdate);
	}

	public void SelectedTab()
	{
		DisplayUpdate();
	}

	private void DisplayUpdate()
	{
		if (Swatches.swatch == null)
		{
			return;
		}
		panel.DisableElement("valueA");
		panel.DisableElement("valueB");
		ShaderType shader = Shaders.GetShader(Swatches.swatch.shader.name);
		if (shader.values != null)
		{
			if (shader.values[0] != null)
			{
				panel.EnableElement("valueA");
				panel.SetValue("valueA_label", shader.valueNames[0]);
				panel.SetValue("valueA", Swatches.swatch.GetFloat(shader.values[0]).ToString());
			}
			if (shader.values[1] != null)
			{
				panel.EnableElement("valueB");
				panel.SetValue("valueB_label", shader.valueNames[1]);
				panel.SetValue("valueB", Swatches.swatch.GetFloat(shader.values[1]).ToString());
			}
		}
		for (int i = 0; i < shaders.Count; i++)
		{
			if (shaders[i] == Swatches.swatch.shader.name)
			{
				panel.SetValue("shader", i);
				break;
			}
		}
		panel.SetValue("textureScale", Swatches.swatch.mainTextureScale.x.ToString());
		panel.SetValue("mapping", Swatches.swatch.GetInt("_Overwrite"));
	}

	public void shaderSelect(int i)
	{
		Swatches.swatch.shader = Shader.Find(shaders[i]);
		ShaderType shaderType = Shaders.types[shaders[i]];
		if (shaderType.values != null)
		{
			if (shaderType.values[0] != null)
			{
				Swatches.SetProperty(shaderType.values[0], shaderType.defaultValues[0]);
			}
			if (shaderType.values[1] != null)
			{
				Swatches.SetProperty(shaderType.values[1], shaderType.defaultValues[1]);
			}
		}
		DisplayUpdate();
	}

	private void valueAUpdate(string n)
	{
		if (!(Swatches.swatch == null))
		{
			Swatches.SetProperty(Shaders.GetShader(Swatches.swatch.shader.name).values[0], float.Parse(n));
		}
	}

	private void valueBUpdate(string n)
	{
		if (!(Swatches.swatch == null))
		{
			Swatches.SetProperty(Shaders.GetShader(Swatches.swatch.shader.name).values[1], float.Parse(n));
		}
	}

	private void textureScaleUpdate(string n)
	{
		if (!(Swatches.swatch == null))
		{
			float num = float.Parse(n);
			Swatches.SetScale(num, num);
		}
	}

	private void mappingSelect(int i)
	{
		if (!(Swatches.swatch == null))
		{
			Swatches.SetMapping(i);
		}
	}
}
