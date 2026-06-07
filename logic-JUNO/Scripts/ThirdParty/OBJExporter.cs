using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class OBJExporter
{
	public static Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle)
	{
		return angle * (point - pivot) + pivot;
	}

	public static Vector3 MultiplyVec3s(Vector3 v1, Vector3 v2)
	{
		return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
	}

	public static void ExportObj(string fullyQualifiedExportLocation, GameObject root, bool generateMaterials, bool exportTextures, bool splitObjects, bool applyScale, bool applyRotation, bool applyPosition)
	{
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		FileInfo fileInfo = new FileInfo(fullyQualifiedExportLocation);
		bool flag = true;
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullyQualifiedExportLocation);
		MeshFilter[] array = null;
		List<MeshFilter> list = new List<MeshFilter>();
		MeshRenderer[] componentsInChildren = root.GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			MeshFilter component = componentsInChildren[i].gameObject.GetComponent<MeshFilter>();
			list.Add(component);
		}
		array = list.ToArray();
		if (Application.isPlaying)
		{
			MeshFilter[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				MeshRenderer component2 = array2[i].gameObject.GetComponent<MeshRenderer>();
				if (component2 != null && component2.isPartOfStaticBatch)
				{
					throw new InvalidOperationException("Static batched object detected. Static batching is not compatible with this exporter. Please disable it before starting the player.");
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		stringBuilder.AppendLine("# Export of " + root.name);
		if (generateMaterials)
		{
			stringBuilder.AppendLine("mtllib " + fileNameWithoutExtension + ".mtl");
		}
		int num = 0;
		for (int j = 0; j < array.Length; j++)
		{
			string name = array[j].gameObject.name;
			MeshFilter meshFilter = array[j];
			MeshRenderer component3 = array[j].gameObject.GetComponent<MeshRenderer>();
			if (splitObjects)
			{
				string text = name;
				if (flag)
				{
					text = text + "_" + j;
				}
				stringBuilder.AppendLine("g " + text);
			}
			if (component3 != null && generateMaterials)
			{
				Material[] sharedMaterials = component3.sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (!dictionary.ContainsKey(material.name))
					{
						dictionary[material.name] = true;
						stringBuilder2.Append(MaterialToString(fullyQualifiedExportLocation, autoMarkTexReadable: true, material, exportTextures));
						stringBuilder2.AppendLine();
					}
				}
			}
			Mesh sharedMesh = meshFilter.sharedMesh;
			int num2 = (int)Mathf.Clamp(meshFilter.gameObject.transform.lossyScale.x * meshFilter.gameObject.transform.lossyScale.z, -1f, 1f);
			Vector3[] vertices = sharedMesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector = vertices[i];
				if (applyScale)
				{
					vector = MultiplyVec3s(vector, meshFilter.gameObject.transform.lossyScale);
				}
				if (applyRotation)
				{
					vector = RotateAroundPoint(vector, Vector3.zero, meshFilter.gameObject.transform.rotation);
				}
				if (applyPosition)
				{
					vector += meshFilter.gameObject.transform.position;
				}
				vector.x *= -1f;
				stringBuilder.AppendLine("v " + vector.x + " " + vector.y + " " + vector.z);
			}
			vertices = sharedMesh.normals;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector2 = vertices[i];
				if (applyScale)
				{
					vector2 = MultiplyVec3s(vector2, meshFilter.gameObject.transform.lossyScale.normalized);
				}
				if (applyRotation)
				{
					vector2 = RotateAroundPoint(vector2, Vector3.zero, meshFilter.gameObject.transform.rotation);
				}
				vector2.x *= -1f;
				stringBuilder.AppendLine("vn " + vector2.x + " " + vector2.y + " " + vector2.z);
			}
			Vector2[] uv = sharedMesh.uv;
			for (int i = 0; i < uv.Length; i++)
			{
				Vector2 vector3 = uv[i];
				float x = vector3.x;
				string text2 = x.ToString();
				x = vector3.y;
				stringBuilder.AppendLine("vt " + text2 + " " + x);
			}
			for (int l = 0; l < sharedMesh.subMeshCount; l++)
			{
				if (component3 != null && l < component3.sharedMaterials.Length)
				{
					string name2 = component3.sharedMaterials[l].name;
					stringBuilder.AppendLine("usemtl " + name2);
				}
				else
				{
					stringBuilder.AppendLine("usemtl " + name + "_sm" + l);
				}
				int[] triangles = sharedMesh.GetTriangles(l);
				for (int m = 0; m < triangles.Length; m += 3)
				{
					int index = triangles[m] + 1 + num;
					int index2 = triangles[m + 1] + 1 + num;
					int index3 = triangles[m + 2] + 1 + num;
					if (num2 < 0)
					{
						stringBuilder.AppendLine("f " + ConstructOBJString(index) + " " + ConstructOBJString(index2) + " " + ConstructOBJString(index3));
					}
					else
					{
						stringBuilder.AppendLine("f " + ConstructOBJString(index3) + " " + ConstructOBJString(index2) + " " + ConstructOBJString(index));
					}
				}
			}
			num += sharedMesh.vertices.Length;
		}
		File.WriteAllText(fullyQualifiedExportLocation, stringBuilder.ToString());
		string path = Path.Combine(fileInfo.Directory.FullName, fileNameWithoutExtension + ".mtl");
		if (generateMaterials)
		{
			File.WriteAllText(path, stringBuilder2.ToString());
		}
	}

	public static string TryExportTexture(string fullyQualifiedExportLocation, bool autoMarkTexReadable, string propertyName, Material m)
	{
		if (m.HasProperty(propertyName))
		{
			Texture texture = m.GetTexture(propertyName);
			if (texture != null)
			{
				return ExportTexture(fullyQualifiedExportLocation, (Texture2D)texture, autoMarkTexReadable);
			}
		}
		return "false";
	}

	public static string ExportTexture(string fullyQualifiedExportLocation, Texture2D t, bool autoMarkTexReadable)
	{
		try
		{
			string.IsNullOrEmpty(t.name);
			string directoryName = Path.GetDirectoryName(fullyQualifiedExportLocation);
			string path = ("texture." + Path.GetFileNameWithoutExtension(fullyQualifiedExportLocation)).Replace(" ", "");
			string text = Path.Combine(directoryName, path) + ".png";
			Texture2D texture2D = new Texture2D(t.width, t.height, TextureFormat.ARGB32, mipChain: false);
			texture2D.SetPixels(t.GetPixels());
			File.WriteAllBytes(text, texture2D.EncodeToPNG());
			return text;
		}
		catch (Exception ex)
		{
			Debug.Log("Could not export texture : " + t.name + ". is it readable?\n" + ex.Message);
			return "null";
		}
	}

	private static string ConstructOBJString(int index)
	{
		string text = index.ToString();
		return text + "/" + text + "/" + text;
	}

	public static string MaterialToString(string fullyQualifiedExportLocation, bool autoMarkTexReadable, Material m, bool exportTextures)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("newmtl " + m.name);
		if (m.HasProperty("_Color"))
		{
			stringBuilder.AppendLine("Kd " + m.color.r + " " + m.color.g + " " + m.color.b);
			if (m.color.a < 1f)
			{
				stringBuilder.AppendLine("Tr " + (1f - m.color.a));
				stringBuilder.AppendLine("d " + m.color.a);
			}
		}
		if (m.HasProperty("_SpecColor"))
		{
			Color color = m.GetColor("_SpecColor");
			stringBuilder.AppendLine("Ks " + color.r + " " + color.g + " " + color.b);
		}
		if (exportTextures)
		{
			string text = TryExportTexture(fullyQualifiedExportLocation, autoMarkTexReadable, "_MainTex", m);
			if (text != "false")
			{
				stringBuilder.AppendLine("map_Kd " + Path.GetFileName(text));
			}
			text = TryExportTexture(fullyQualifiedExportLocation, autoMarkTexReadable, "_SpecMap", m);
			if (text != "false")
			{
				stringBuilder.AppendLine("map_Ks " + Path.GetFileName(text));
			}
			text = TryExportTexture(fullyQualifiedExportLocation, autoMarkTexReadable, "_BumpMap", m);
			if (text != "false")
			{
				stringBuilder.AppendLine("map_Bump " + Path.GetFileName(text));
			}
		}
		stringBuilder.AppendLine("illum 2");
		return stringBuilder.ToString();
	}

	private string MaterialToString(string fullyQualifiedExportLocation, bool autoMarkTexReadable, bool exportTextures, Material m)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("newmtl " + m.name);
		if (m.HasProperty("_Color"))
		{
			stringBuilder.AppendLine("Kd " + m.color.r + " " + m.color.g + " " + m.color.b);
			if (m.color.a < 1f)
			{
				stringBuilder.AppendLine("Tr " + (1f - m.color.a));
				stringBuilder.AppendLine("d " + m.color.a);
			}
		}
		if (m.HasProperty("_SpecColor"))
		{
			Color color = m.GetColor("_SpecColor");
			stringBuilder.AppendLine("Ks " + color.r + " " + color.g + " " + color.b);
		}
		if (exportTextures)
		{
			string text = TryExportTexture(fullyQualifiedExportLocation, autoMarkTexReadable, "_MainTex", m);
			if (text != "false")
			{
				stringBuilder.AppendLine("map_Kd " + text);
			}
			text = TryExportTexture(fullyQualifiedExportLocation, autoMarkTexReadable, "_SpecMap", m);
			if (text != "false")
			{
				stringBuilder.AppendLine("map_Ks " + text);
			}
			text = TryExportTexture(fullyQualifiedExportLocation, autoMarkTexReadable, "_BumpMap", m);
			if (text != "false")
			{
				stringBuilder.AppendLine("map_Bump " + text);
			}
		}
		stringBuilder.AppendLine("illum 2");
		return stringBuilder.ToString();
	}
}
