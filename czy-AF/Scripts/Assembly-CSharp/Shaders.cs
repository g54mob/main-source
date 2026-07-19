using System.Collections.Generic;
using UnityEngine;

public class Shaders : MonoBehaviour
{
	public static Dictionary<string, ShaderType> types = new Dictionary<string, ShaderType>();

	private void Awake()
	{
		CreateShader(new ShaderType("Default", new string[2] { "_Metallic", "_Glossiness" }, new string[2] { "Metallic", "Glossiness" }, new float[2] { 0.25f, 0.25f }));
		CreateShader(new ShaderType("Gradient", new string[2] { "_Distribution", "_Alpha" }, new string[2] { "Height", "Opacity" }, new float[2] { 1f, 0.25f }));
		CreateShader(new ShaderType("Unlit"));
	}

	private void CreateShader(ShaderType shaderType)
	{
		types.Add(shaderType.name, shaderType);
	}

	public static ShaderType GetShader(string s)
	{
		if (types.ContainsKey(s))
		{
			return types[s];
		}
		return types["Default"];
	}

	public static List<string> GetShaders()
	{
		List<string> list = new List<string>();
		foreach (string key in types.Keys)
		{
			list.Add(key);
		}
		return list;
	}

	public static void ShaderCheck(Transform t)
	{
		Material[] materials = t.GetComponent<Renderer>().materials;
		foreach (Material material in materials)
		{
			ShaderType shader = GetShader(material.shader.name);
			if (shader == null)
			{
				shader = GetShader("Default");
				material.shader = Shader.Find(shader.name);
				material.SetFloat(shader.values[0], shader.defaultValues[0]);
				material.SetFloat(shader.values[1], shader.defaultValues[1]);
			}
		}
	}
}
