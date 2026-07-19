using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Crosstales.FB;
using UnityEngine;

public class Project : MonoBehaviour
{
	public static string title = "";

	public static int projectNumber = 0;

	public static bool saved = false;

	public static string savePath = "";

	public string displayTitle;

	public static Project instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		SetTitle();
		Undo.AddState();
	}

	public static void SetTitle(bool _next = true, string _title = null)
	{
		if (_next)
		{
			projectNumber++;
			title = $"Untitled-{projectNumber}";
		}
		else
		{
			title = _title;
		}
	}

	private void Update()
	{
		displayTitle = title;
	}

	public void SetRecovery(bool recovery)
	{
		CancelInvoke();
		if (recovery)
		{
			InvokeRepeating("SaveRecovery", 0f, 60f);
		}
	}

	public void SaveRecovery()
	{
		if (Global.SceneBlocks().Count > 0)
		{
			SaveFile(Application.persistentDataPath + "/recovery.model");
		}
	}

	public void CallbackSave(string action)
	{
		Save();
		CallbackAction(action);
	}

	public void CallbackDontSave(string action)
	{
		CallbackAction(action);
	}

	public void CallbackAction(string action)
	{
		if (action == "new")
		{
			Undo.ClearStates();
			NewAction();
		}
		if (action == "open")
		{
			Undo.ClearStates();
			OpenAction();
		}
		if (action == "quit")
		{
			Global.forceQuit = true;
			Application.Quit();
		}
	}

	public static void New()
	{
		if (Global.SceneBlocks().Count > 0)
		{
			Global.ShowDialog("save", Global.elements["global"].gameObject, "new");
		}
		else
		{
			NewAction();
		}
	}

	public static void NewAction()
	{
		Reset();
		SetTitle();
		savePath = "";
	}

	public void ClearIEnumerator()
	{
		StartCoroutine(ClearAction());
	}

	public static IEnumerator ClearAction()
	{
		Selection.Clear();
		foreach (Transform item in Global.SceneBlocks())
		{
			Object.DestroyImmediate(item.gameObject);
		}
		Swatches.ResetData();
		SetTitle();
		savePath = "";
		yield return new WaitForEndOfFrame();
	}

	public static void Reset()
	{
		Selection.Clear();
		foreach (Transform item in Global.SceneBlocks())
		{
			Object.Destroy(item.gameObject);
		}
		Swatches.ResetData();
	}

	public static void Open(bool merge = false)
	{
		if (!merge)
		{
			if (Global.SceneBlocks().Count > 0)
			{
				Global.ShowDialog("save", Global.elements["global"].gameObject, "open");
			}
			else
			{
				OpenAction();
			}
		}
		else
		{
			OpenAction(merge);
		}
	}

	public static void OpenAction(bool merge = false)
	{
		Selection.Clear();
		ExtensionFilter extensionFilter = new ExtensionFilter("Asset Forge (.model)", "model");
		string text = FileBrowser.OpenSingleFile(null, null, extensionFilter);
		if (text != "")
		{
			LoadFile(text, merge);
		}
	}

	public static void Save()
	{
		if (savePath == "")
		{
			SaveAs();
			return;
		}
		SaveFile(savePath);
		Global.ShowMessage("Saved file!");
	}

	public static void SaveAs()
	{
		string text = FileBrowser.SaveFile(title, "model");
		if (text != "")
		{
			SaveFile(text);
			savePath = text;
			SetTitle(_next: false, Path.GetFileNameWithoutExtension(text));
			Global.ShowMessage("Saved file!");
		}
	}

	public static string SaveFile(string path, bool save = true)
	{
		string text = $"# Made using Asset Forge ({Application.version})\n\n";
		text += $":materials\n\n";
		foreach (Material datum in Swatches.data)
		{
			string text2 = "[";
			text2 += $"name:{datum.name};";
			text2 += $"color:{datum.color};";
			text2 += $"scale:{datum.mainTextureScale};";
			if ((bool)datum.mainTexture)
			{
				TextureData texture = Textures.GetTexture(datum.mainTexture);
				if (texture != null)
				{
					text2 += string.Format("texture:{0};", texture.folder + "/" + texture.name);
				}
			}
			ShaderType shader = Shaders.GetShader(datum.shader.name);
			text2 += $"shader:{shader.name};";
			text2 += string.Format("mapping:{0};", datum.GetInt("_Overwrite"));
			if (shader.values != null)
			{
				if (shader.values[0] != null)
				{
					text2 += $"valueA:{datum.GetFloat(shader.values[0])};";
				}
				if (shader.values[1] != null)
				{
					text2 += $"valueB:{datum.GetFloat(shader.values[1])};";
				}
			}
			text += $"{text2}]\n";
		}
		text += $"\n:models\n\n";
		foreach (Transform item in Global.SceneBlocks())
		{
			Block data = item.GetComponent<BlockComponent>().data;
			string text3 = "[";
			text3 += $"name:{data.name};";
			text3 += $"collection:{data.collection};";
			text3 += $"type:{data.type};";
			text3 += string.Format("position:{0};", item.position.ToString("F4"));
			text3 += string.Format("rotation:{0};", item.eulerAngles.ToString("F4"));
			text3 += string.Format("scale:{0};", item.lossyScale.ToString("F4"));
			text3 += $"group:{data.group};";
			text3 += $"locked:{data.locked};";
			text3 += $"hidden:{data.hidden};";
			string text4 = "";
			Material[] sharedMaterials = item.GetComponent<Renderer>().sharedMaterials;
			foreach (Material material in sharedMaterials)
			{
				if (!(material == null))
				{
					text4 = text4 + material.name + "+";
				}
			}
			text4 = text4.Substring(0, text4.Length - 1);
			text3 += $"materials:{text4};";
			text += $"{text3}]\n";
		}
		if (!path.EndsWith(".model"))
		{
			path += ".model";
		}
		if (save)
		{
			File.WriteAllText(path, text);
		}
		return text;
	}

	public static void LoadFile(string path, bool merge = false, Transform target = null, string fileData = null)
	{
		if (!merge && fileData == null)
		{
			NewAction();
			projectNumber--;
			SetTitle(_next: false, Path.GetFileNameWithoutExtension(path));
			savePath = path;
		}
		if (fileData != null)
		{
			Reset();
		}
		if (target == null)
		{
			if (merge)
			{
				Global.elements["selector"].position = Vector3.zero;
				target = Global.elements["selector"];
			}
			else
			{
				target = Global.elements["workbench"];
			}
		}
		string text = fileData;
		if (path != "")
		{
			text = new StreamReader(path).ReadToEnd();
		}
		string text2 = "";
		string[] array = text.Split("\n"[0]);
		for (int i = 0; i < array.Length; i++)
		{
			string text3 = array[i].Trim();
			if (text3 == "" || text3.Length == 0 || text3[0] == "#"[0])
			{
				continue;
			}
			if (text2 != "")
			{
				text3 = text3.Replace("[", "").Replace("]", "");
			}
			if (text2 == "materials")
			{
				Dictionary<string, string> dictionary = ReadLine(text3);
				if (dictionary.ContainsKey("name"))
				{
					Material material = new Material(Shader.Find("Default"));
					material.name = dictionary["name"];
					material.color = Global.ParseColor(dictionary["color"]);
					if (dictionary.ContainsKey("scale"))
					{
						material.mainTextureScale = Global.ParseVector2(dictionary["scale"]);
					}
					if (dictionary.ContainsKey("texture"))
					{
						TextureData textureCombination = Textures.GetTextureCombination(dictionary["texture"]);
						if (textureCombination != null)
						{
							material.SetTexture("_MainTex", textureCombination.texture);
						}
					}
					if (dictionary.ContainsKey("mapping"))
					{
						material.SetInt("_Overwrite", Global.ParseInt(dictionary["mapping"]));
					}
					if (dictionary["shader"] == "Standard")
					{
						dictionary["shader"] = "Default";
					}
					material.shader = Shader.Find(dictionary["shader"]);
					ShaderType shader = Shaders.GetShader(dictionary["shader"]);
					if (dictionary.ContainsKey("valueA"))
					{
						material.SetFloat(shader.values[0], float.Parse(dictionary["valueA"]));
					}
					if (dictionary.ContainsKey("valueB"))
					{
						material.SetFloat(shader.values[1], float.Parse(dictionary["valueB"]));
					}
					Swatches.AddMaterial(material);
				}
			}
			if (text2 == "models")
			{
				Dictionary<string, string> dictionary2 = ReadLine(text3);
				if (dictionary2.ContainsKey("type"))
				{
					GameObject gameObject = Collections.CreateBlock(dictionary2["collection"], dictionary2["type"]);
					if (gameObject == null)
					{
						continue;
					}
					gameObject.transform.SetParent(target, worldPositionStays: false);
					gameObject.transform.position = Global.ParseVector3(dictionary2["position"]);
					gameObject.transform.eulerAngles = Global.ParseVector3(dictionary2["rotation"]);
					gameObject.transform.localScale = Global.ParseVector3(dictionary2["scale"]);
					if (!merge && fileData == null && gameObject.transform.localScale != Vector3.one && Global.uvmap)
					{
						UVMapping.BoxUV(gameObject.GetComponent<MeshFilter>().sharedMesh, gameObject.transform);
					}
					Block block = new Block();
					block.collection = dictionary2["collection"];
					block.type = dictionary2["type"];
					block.group = dictionary2["group"];
					string s = Regex.Replace(block.group, "[^0-9]", "");
					int result = -1;
					int.TryParse(s, out result);
					if (result > Groups.groupIndex)
					{
						Groups.groupIndex = result + 1;
					}
					block.name = dictionary2["name"];
					block.locked = dictionary2["locked"] == "True";
					block.hidden = dictionary2["hidden"] == "True";
					gameObject.AddComponent<BlockComponent>().data = block;
					if (merge && fileData == null)
					{
						block.group = Path.GetFileNameWithoutExtension(path);
					}
					string[] array2 = dictionary2["materials"].Split("+"[0]);
					Material[] sharedMaterials = gameObject.GetComponent<Renderer>().sharedMaterials;
					for (int j = 0; j < array2.Length; j++)
					{
						if (j < sharedMaterials.Length)
						{
							sharedMaterials[j] = Swatches.GetMaterial(array2[j]);
						}
					}
					gameObject.GetComponent<Renderer>().sharedMaterials = sharedMaterials;
				}
			}
			if (text3 == ":models")
			{
				text2 = "models";
			}
			if (text3 == ":materials")
			{
				text2 = "materials";
			}
			if (text3 == ":textures")
			{
				text2 = "textures";
			}
			if (text3 == ":extra")
			{
				text2 = "extra";
			}
		}
		if (target == null)
		{
			Swatches.UpdateMaterials();
		}
	}

	public static Dictionary<string, string> ReadLine(string line)
	{
		string[] array = line.Split(";"[0]);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = array2[i].Split(":"[0]);
			if (array3.Length > 1)
			{
				dictionary[array3[0]] = array3[1];
			}
		}
		return dictionary;
	}
}
