using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swatches : MonoBehaviour
{
	public static List<Material> data = new List<Material>();

	public static Material swatch;

	public static ComponentList swatchList;

	public static void AddMaterial(Material _material)
	{
		string text = (_material.name = _material.name.Replace(" (Instance)", ""));
		_material.enableInstancing = true;
		foreach (Material datum in data)
		{
			if (datum.name == text)
			{
				return;
			}
		}
		Material material = Object.Instantiate(_material);
		material.name = text;
		if (material.shader.name == "Standard")
		{
			material.shader = Shader.Find("Default");
		}
		data.Add(material);
		swatchList.AddElement(new Hashtable
		{
			{ "name", text },
			{ "selected", false }
		});
	}

	public static void CreateMaterial()
	{
		Material material = new Material(Shader.Find("Default"));
		if (swatch != null)
		{
			material = new Material(swatch);
		}
		int num = data.Count;
		string text = $"custom{data.Count}";
		while (ContainsMaterial(text))
		{
			num++;
			text = $"custom{num}";
		}
		material.name = text;
		AddMaterial(material);
		UpdateMaterials();
		Undo.AddState();
	}

	public static void RemoveMaterial(Material _material)
	{
		if (!MaterialUsed(_material))
		{
			Global.ShowMessage("Material (" + _material.name + ") removed");
			swatchList.RemoveElement(_material.name);
			data.Remove(_material);
		}
		else
		{
			Global.ShowMessage("Material (" + _material.name + ") is currently in use");
		}
		ResetSwatch();
		Undo.AddState();
	}

	public static void RemoveUnusedMaterials()
	{
		int num = 0;
		List<Material> list = new List<Material>();
		foreach (Material datum in data)
		{
			list.Add(datum);
		}
		foreach (Material item in list)
		{
			if (!MaterialUsed(item))
			{
				swatchList.RemoveElement(item.name);
				data.Remove(item);
				num++;
			}
		}
		ResetSwatch();
		Undo.AddState();
		Global.ShowMessage("Removed " + num + " unused materials");
	}

	public static bool MaterialUsed(Material _material)
	{
		bool result = false;
		foreach (Transform item in Global.SceneBlocks())
		{
			Renderer component = item.GetComponent<Renderer>();
			if (!(component != null))
			{
				continue;
			}
			Material[] sharedMaterials = component.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				if (sharedMaterials[i] == _material)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	public static void UpdateMaterials()
	{
		foreach (Transform item in Global.SceneBlocks())
		{
			Renderer component = item.GetComponent<Renderer>();
			if (!(component != null))
			{
				continue;
			}
			Material[] sharedMaterials = component.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				if (ContainsMaterial(sharedMaterials[i].name))
				{
					sharedMaterials[i] = GetMaterial(sharedMaterials[i].name);
				}
			}
			component.materials = sharedMaterials;
		}
		swatchList.UpdateElements();
	}

	public static void SetSwatch(string selectedSwatch)
	{
		if (swatch != null)
		{
			swatchList.SetElement(swatch.name, "selected", false);
		}
		foreach (Material datum in data)
		{
			if (datum.name == selectedSwatch)
			{
				swatch = datum;
				break;
			}
		}
		swatchList.SetElement(selectedSwatch, "selected", true);
		EventManager.TriggerEvent("ChangeSwatch");
	}

	public static bool ContainsMaterial(string name)
	{
		foreach (Material datum in data)
		{
			if (datum.name == name)
			{
				return true;
			}
		}
		return false;
	}

	public static Material GetMaterial(string name)
	{
		foreach (Material datum in data)
		{
			if (datum.name == name)
			{
				return datum;
			}
		}
		return null;
	}

	public static List<Material> GetMaterials(Transform parent)
	{
		List<Material> list = new List<Material>();
		Renderer[] componentsInChildren = parent.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Material[] sharedMaterials = componentsInChildren[i].sharedMaterials;
			foreach (Material item in sharedMaterials)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public static void ReplaceRaycastMaterial(RaycastHit hit)
	{
		MeshCollider meshCollider = hit.collider as MeshCollider;
		if (meshCollider == null || meshCollider.sharedMesh == null || !hit.transform.GetComponent<BlockComponent>())
		{
			return;
		}
		Mesh sharedMesh = meshCollider.sharedMesh;
		int[] triangles = sharedMesh.triangles;
		int num = triangles[hit.triangleIndex * 3];
		int num2 = triangles[hit.triangleIndex * 3 + 1];
		int num3 = triangles[hit.triangleIndex * 3 + 2];
		Renderer component = hit.transform.GetComponent<Renderer>();
		for (int i = 0; i < component.sharedMaterials.Length; i++)
		{
			int[] triangles2 = sharedMesh.GetTriangles(i);
			for (int j = 0; j < triangles2.Length; j += 3)
			{
				if (triangles2[j] == num && triangles2[j + 1] == num2 && triangles2[j + 2] == num3)
				{
					Material[] sharedMaterials = component.sharedMaterials;
					sharedMaterials[i] = swatch;
					component.materials = sharedMaterials;
				}
			}
		}
	}

	public static string GetRaycastMaterial(RaycastHit hit)
	{
		string result = "";
		MeshCollider meshCollider = hit.collider as MeshCollider;
		if (meshCollider == null || meshCollider.sharedMesh == null)
		{
			return result;
		}
		if ((bool)hit.transform.GetComponent<BlockComponent>())
		{
			Mesh sharedMesh = meshCollider.sharedMesh;
			int[] triangles = sharedMesh.triangles;
			int num = triangles[hit.triangleIndex * 3];
			int num2 = triangles[hit.triangleIndex * 3 + 1];
			int num3 = triangles[hit.triangleIndex * 3 + 2];
			Renderer component = hit.transform.GetComponent<Renderer>();
			for (int i = 0; i < component.sharedMaterials.Length; i++)
			{
				int[] triangles2 = sharedMesh.GetTriangles(i);
				for (int j = 0; j < triangles2.Length; j += 3)
				{
					if (triangles2[j] == num && triangles2[j + 1] == num2 && triangles2[j + 2] == num3)
					{
						result = component.sharedMaterials[i].name;
						break;
					}
				}
			}
		}
		return result;
	}

	public static void ResetSwatch()
	{
		swatch = null;
		EventManager.TriggerEvent("ChangeSwatch");
	}

	public static void ResetData()
	{
		data.Clear();
		swatchList.Clear();
		swatch = null;
		swatchList.transform.parent.GetComponent<PanelSwatches>().DisplayUpdate();
	}

	public static int CountMaterials()
	{
		Dictionary<Material, string> dictionary = new Dictionary<Material, string>();
		foreach (Transform item in Global.SceneBlocks())
		{
			Renderer component = item.GetComponent<Renderer>();
			if (!(component != null))
			{
				continue;
			}
			Material[] sharedMaterials = component.sharedMaterials;
			foreach (Material material in sharedMaterials)
			{
				if (!dictionary.ContainsKey(material))
				{
					dictionary.Add(material, material.name);
				}
			}
		}
		return dictionary.Count;
	}

	public static void SetColor(Color _color)
	{
		swatch.color = _color;
		SwatchUpdate();
	}

	public static void SetTexture(Texture2D _texture)
	{
		swatch.SetTexture("_MainTex", _texture);
		SwatchUpdate();
	}

	public static void SetScale(float _scaleX, float _scaleY)
	{
		swatch.mainTextureScale = new Vector2(_scaleX, _scaleY);
		SwatchUpdate();
	}

	public static void SetMapping(int _value)
	{
		swatch.SetInt("_Overwrite", _value);
		SwatchUpdate();
	}

	public static void SetProperty(string _name, float _value)
	{
		swatch.SetFloat(_name, _value);
		SwatchUpdate();
	}

	public static void SwatchUpdate()
	{
		Undo.AddState();
	}
}
