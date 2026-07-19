using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Crosstales.FB;
using Parabox.STL;
using UniGLTF;
using UnityEngine;
using UnityEngine.UI;
using UnityFBXExporter;

public class Export : MonoBehaviour
{
	public static Dictionary<Color, Vector2> colors = new Dictionary<Color, Vector2>();

	public static List<Material> generatedMaterials = new List<Material>();

	public static void ExportModel(int _filetype = 0, bool _merge = false, bool _textures = true, bool _colormap = false, int _orientation = 0, float _scale = 100f, float _compression = 0f, bool _selection = false)
	{
		string[] array = new string[5] { "obj", "fbx", "dae", "glb", "stl" };
		string text = FileBrowser.SaveFile(Project.title, array[_filetype]);
		if (!(text != ""))
		{
			return;
		}
		string directoryName = Path.GetDirectoryName(text);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
		GameObject original = Global.elements["workbench"].gameObject;
		if (_selection)
		{
			original = Global.elements["selection"].gameObject;
		}
		else
		{
			Selection.Clear();
		}
		original = UnityEngine.Object.Instantiate(original, Vector3.zero, Quaternion.identity);
		foreach (Transform item in original.transform)
		{
			if ((bool)item.GetComponent<BlockComponent>())
			{
				UVMapping.BoxUV(item.GetComponent<MeshFilter>().sharedMesh, item);
			}
		}
		DefaultMaterials(original.transform);
		GameObject gameObject;
		if (_merge)
		{
			gameObject = MeshCombiner.Combine(original);
			gameObject.name = "mergedBlocks";
		}
		else
		{
			gameObject = original;
			gameObject.name = "workbenchCopy";
			foreach (Transform item2 in gameObject.transform)
			{
				if ((bool)item2.GetComponent<BlockComponent>())
				{
					Block data = item2.GetComponent<BlockComponent>().data;
					if (data.name != "")
					{
						item2.name = data.name;
					}
				}
			}
		}
		if (_colormap)
		{
			GenerateColorPalette(gameObject.transform, Resources.Load<Material>("Materials/Internal/Replacement"), fileNameWithoutExtension);
		}
		float num = _scale / 100f;
		gameObject.transform.localScale = new Vector3(num, num, num);
		switch (_orientation)
		{
		case 1:
			gameObject.transform.up = gameObject.transform.right;
			break;
		case 2:
			gameObject.transform.up = gameObject.transform.forward;
			break;
		}
		switch (array[_filetype])
		{
		case "obj":
			OBJExporter.Export(gameObject.transform, group: true, _textures, directoryName, fileNameWithoutExtension);
			break;
		case "fbx":
			FBXExporter.ExportGameObjToFBX(gameObject, directoryName + "/" + fileNameWithoutExtension + ".fbx");
			if (_textures)
			{
				ExportTextures(gameObject.transform, directoryName);
			}
			break;
		case "dae":
		{
			gameObject.transform.position = new Vector3(0f - gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
			ExportToCollada exportToCollada = new ExportToCollada(directoryName);
			MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
			foreach (MeshFilter meshFilter in componentsInChildren)
			{
				Material[] sharedMaterials = meshFilter.GetComponent<MeshRenderer>().sharedMaterials;
				exportToCollada.AddMeshWithMaterials(meshFilter.sharedMesh, sharedMaterials, meshFilter.transform.localToWorldMatrix, meshFilter.name);
			}
			exportToCollada.Save($"{directoryName}/{fileNameWithoutExtension}.dae");
			break;
		}
		case "glb":
		{
			glTF glTF2 = new glTF();
			using (gltfExporter gltfExporter2 = new gltfExporter(glTF2))
			{
				gltfExporter2.Prepare(gameObject);
				gltfExporter2.Export();
			}
			byte[] bytes = glTF2.ToGlbBytes();
			File.WriteAllBytes($"{directoryName}/{fileNameWithoutExtension}.glb", bytes);
			break;
		}
		case "stl":
			pb_Stl_Exporter.Export(directoryName + "/" + fileNameWithoutExtension + ".stl", new GameObject[1] { gameObject }, FileType.Binary);
			break;
		}
		UnityEngine.Object.Destroy(original);
		UnityEngine.Object.Destroy(gameObject);
		RemoveDefaultMaterials();
		GC.Collect();
		if (_colormap)
		{
			bool flag = false;
			foreach (Material datum in Swatches.data)
			{
				if ((bool)datum.mainTexture)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				Global.ShowMessage("Please note: Color maps only support material colors, not textures.", 5f);
			}
		}
		Global.ShowMessage($"Succesfully exported {fileNameWithoutExtension}.{array[_filetype]}", 5f);
	}

	public static void ExportTextures(Transform parent, string path)
	{
		MeshFilter[] componentsInChildren = parent.GetComponentsInChildren<MeshFilter>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Material[] sharedMaterials = componentsInChildren[i].GetComponent<MeshRenderer>().sharedMaterials;
			foreach (Material material in sharedMaterials)
			{
				if (!(material.mainTexture == null))
				{
					Directory.CreateDirectory(path + "/Textures");
					Texture2D texture2D = material.mainTexture as Texture2D;
					Texture2D texture2D2 = new Texture2D(texture2D.width, texture2D.height, TextureFormat.ARGB32, mipChain: false);
					texture2D2.SetPixels(0, 0, texture2D.width, texture2D.height, texture2D.GetPixels());
					texture2D2.Apply();
					File.WriteAllBytes(bytes: texture2D2.EncodeToPNG(), path: path + "/Textures/" + material.name + ".png");
					UnityEngine.Object.DestroyImmediate(texture2D2);
				}
			}
		}
	}

	public static void DefaultMaterials(Transform parent)
	{
		MeshFilter[] componentsInChildren = parent.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			Material[] sharedMaterials = meshFilter.GetComponent<MeshRenderer>().sharedMaterials;
			Material[] array = new Material[sharedMaterials.Length];
			for (int j = 0; j < sharedMaterials.Length; j++)
			{
				array[j] = UnityEngine.Object.Instantiate(sharedMaterials[j]);
				array[j].shader = Shader.Find("Standard");
				generatedMaterials.Add(array[j]);
			}
			meshFilter.GetComponent<MeshRenderer>().sharedMaterials = array;
		}
	}

	public static void RemoveDefaultMaterials()
	{
		for (int i = 0; i < generatedMaterials.Count; i++)
		{
			UnityEngine.Object.DestroyImmediate(generatedMaterials[i]);
		}
		generatedMaterials.Clear();
	}

	public static void GeneratePreview()
	{
		Texture2D texture = RenderSprite(256, 256, 1);
		RawImage component = GameObject.Find("previewRender").GetComponent<RawImage>();
		component.color = Color.white;
		component.texture = texture;
		component.SetNativeSize();
	}

	public static void ExportSprite(int size)
	{
		Selection.Clear();
		string text = FileBrowser.SaveFile(Project.title, "png");
		if (text != "")
		{
			string directoryName = Path.GetDirectoryName(text);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
			byte[] bytes = RenderSprite(size, size, 1).EncodeToPNG();
			File.WriteAllBytes($"{directoryName}/{fileNameWithoutExtension}.png", bytes);
			Global.ShowMessage($"Succesfully exported {fileNameWithoutExtension}.png", 5f);
		}
	}

	public static void ExportSprite(int size, string directory)
	{
		Selection.Clear();
		byte[] bytes = RenderSprite(size, size, 1).EncodeToPNG();
		File.WriteAllBytes($"{directory}.png", bytes);
	}

	public static void ExportSprite(int size, string directory, string file)
	{
		Selection.Clear();
		byte[] bytes = RenderSprite(size, size, 1).EncodeToPNG();
		File.WriteAllBytes($"{directory}/{file}.png", bytes);
	}

	public static IEnumerator ExportSprites(int size, int batch)
	{
		Interface.ProcessingDisplay();
		string text = FileBrowser.SaveFile(Project.title, "png");
		if (text != "")
		{
			string directory = Path.GetDirectoryName(text);
			string file = Path.GetFileNameWithoutExtension(text);
			int index = 0;
			for (int i = 0; i < batch; i++)
			{
				yield return new WaitForEndOfFrame();
				ExportSprite(size, directory, string.Format("{0}_{1}", file, index.ToString("00")));
				Global.elements["workbench"].Rotate(0f, 360f / (float)batch, 0f);
				index++;
				string arg = (i * 100 / batch).ToString("F0");
				Interface.ProcessingSet($"Rendering ({arg}%)...");
			}
			Global.elements["workbench"].eulerAngles = Vector3.zero;
		}
		Interface.ProcessingHide();
		Global.ShowMessage($"Succesfully exported {batch} files", 5f);
	}

	public static Texture2D RenderSprite(int resolutionX, int resolutionY, int multiplier)
	{
		Preferences.HighQuality();
		Camera component = Global.elements["cameraRender"].GetComponent<Camera>();
		int width = resolutionX * multiplier;
		int height = resolutionY * multiplier;
		Material material = Resources.Load<Material>("Materials/Internal/Downsample");
		material.SetInt("_Resolution", resolutionX * (multiplier * 2));
		RenderTexture renderTexture = new RenderTexture(width, height, 32);
		renderTexture.antiAliasing = 8;
		renderTexture.autoGenerateMips = false;
		component.targetTexture = renderTexture;
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = component.targetTexture;
		component.Render();
		RenderTexture renderTexture2 = new RenderTexture(component.targetTexture.width / multiplier, component.targetTexture.height / multiplier, 32, RenderTextureFormat.ARGB32);
		Graphics.Blit(component.targetTexture, renderTexture2, material);
		Texture2D texture2D = new Texture2D(renderTexture2.width, renderTexture2.height, TextureFormat.ARGB32, mipChain: false);
		RenderTexture.active = renderTexture2;
		texture2D.ReadPixels(new Rect(0f, 0f, renderTexture2.width, renderTexture2.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		component.targetTexture = null;
		UnityEngine.Object.Destroy(renderTexture2);
		UnityEngine.Object.Destroy(renderTexture);
		Preferences.ApplyPreferences();
		return texture2D;
	}

	public static void GenerateColorPalette(Transform _container, Material _replacementMaterial, string _name)
	{
		colors.Clear();
		int num = 8;
		Texture2D texture2D = new Texture2D(num, num);
		texture2D.name = _name;
		texture2D.filterMode = FilterMode.Point;
		int num2 = 0;
		int num3 = 0;
		List<Color> list = new List<Color>();
		foreach (Material datum in Swatches.data)
		{
			Color color = datum.color;
			if (!list.Contains(color))
			{
				list.Add(color);
				texture2D.SetPixel(num2, num3, color);
				colors.Add(color, new Vector2(num2, num3));
				num2++;
				if (num2 == num)
				{
					num2 = 0;
					num3++;
				}
			}
		}
		texture2D.Apply();
		_replacementMaterial.name = _name;
		_replacementMaterial.color = Color.white;
		_replacementMaterial.SetTexture("_MainTex", texture2D);
		MeshRenderer[] componentsInChildren = _container.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			Mesh mesh = meshRenderer.GetComponent<MeshFilter>().mesh;
			Vector2[] array = new Vector2[mesh.uv.Length];
			for (int j = 0; j < mesh.subMeshCount; j++)
			{
				Vector2 vector = colors[meshRenderer.materials[j].color];
				int[] indices = mesh.GetIndices(j, applyBaseVertex: true);
				foreach (int num4 in indices)
				{
					array[num4] = new Vector2(vector.x * 0.125f + 0.0625f, vector.y * 0.125f + 0.0625f);
				}
			}
			mesh.uv = array;
			Material[] materials = meshRenderer.materials;
			for (int l = 0; l < materials.Length; l++)
			{
				materials[l] = _replacementMaterial;
			}
			meshRenderer.materials = materials;
		}
	}
}
