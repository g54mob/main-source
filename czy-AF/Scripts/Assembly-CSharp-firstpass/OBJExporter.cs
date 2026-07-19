using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;

public class OBJExporter : MonoBehaviour
{
	public static void Export(Transform root, bool group, bool textures, string path, string file)
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
		Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		Dictionary<Vector3, int> dictionary3 = new Dictionary<Vector3, int>();
		Dictionary<int, int> dictionary4 = new Dictionary<int, int>();
		Dictionary<Vector3, int> dictionary5 = new Dictionary<Vector3, int>();
		Dictionary<int, int> dictionary6 = new Dictionary<int, int>();
		List<Transform> list = new List<Transform>();
		List<string> list2 = new List<string>();
		StringBuilder stringBuilder = new StringBuilder().AppendLine("# Created by Kenney (www.kenney.nl)").AppendLine();
		StringBuilder stringBuilder2 = new StringBuilder().AppendLine("# Created by Kenney (www.kenney.nl)").AppendLine();
		int num = 0;
		if ((bool)root.GetComponent<MeshFilter>() && (bool)root.GetComponent<Renderer>())
		{
			list.Add(root);
		}
		foreach (Transform item in root)
		{
			list.Add(item);
		}
		stringBuilder.AppendFormat("mtllib {0}.mtl", file).AppendLine("\n");
		foreach (Transform item2 in list)
		{
			if (!item2.GetComponent<MeshFilter>())
			{
				continue;
			}
			Vector3 localScale = item2.localScale;
			_ = item2.localRotation;
			Mesh sharedMesh = item2.GetComponent<MeshFilter>().sharedMesh;
			Material[] sharedMaterials = item2.GetComponent<Renderer>().sharedMaterials;
			if (group)
			{
				stringBuilder.AppendFormat("g {0}", item2.name).AppendLine("\n");
			}
			int num2 = 0;
			Vector3[] vertices = sharedMesh.vertices;
			foreach (Vector3 position in vertices)
			{
				Vector3 key = item2.TransformPoint(position);
				num2++;
				if (!dictionary.ContainsKey(key))
				{
					int value = (dictionary[key] = dictionary.Count + 1);
					dictionary2[num2] = value;
					stringBuilder.AppendFormat("v {0} {1} {2}", 0f - key.x, key.y, key.z).AppendLine();
				}
				else
				{
					dictionary2[num2] = dictionary[key];
				}
			}
			stringBuilder.AppendLine();
			int num4 = 0;
			vertices = sharedMesh.normals;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector = vertices[i];
				Vector3 direction = new Vector3(vector.x * localScale.x, vector.y * localScale.y, vector.z * localScale.z);
				direction = item2.TransformDirection(direction);
				num4++;
				if (!dictionary3.ContainsKey(direction))
				{
					int value2 = (dictionary3[direction] = dictionary3.Count + 1);
					dictionary4[num4] = value2;
					stringBuilder.AppendFormat("vn {0} {1} {2}", 0f - direction.x, direction.y, direction.z).AppendLine();
				}
				else
				{
					dictionary4[num4] = dictionary3[direction];
				}
			}
			stringBuilder.AppendLine();
			int num6 = 0;
			Vector2[] uv = sharedMesh.uv;
			for (int i = 0; i < uv.Length; i++)
			{
				Vector3 key2 = uv[i];
				num6++;
				if (!dictionary5.ContainsKey(key2))
				{
					int value3 = (dictionary5[key2] = dictionary5.Count + 1);
					dictionary6[num6] = value3;
					stringBuilder.AppendFormat("vt {0} {1}", key2.x, key2.y).AppendLine();
				}
				else
				{
					dictionary6[num6] = dictionary5[key2];
				}
			}
			stringBuilder.AppendLine();
			for (int j = 0; j < sharedMesh.subMeshCount; j++)
			{
				stringBuilder.AppendFormat("usemtl {0}", sharedMaterials[j].name).AppendLine("\n");
				int[] triangles = sharedMesh.GetTriangles(j);
				for (int k = 0; k < triangles.Length; k += 3)
				{
					int num8 = k + 1;
					int num9 = k;
					int num10 = k + 2;
					if (item2.localScale.x < 0f && item2.localScale.z < 0f && item2.localScale.y < 0f)
					{
						num8 = k + 1;
						num9 = k + 2;
						num10 = k;
					}
					else if ((item2.localScale.x > 0f && item2.localScale.z > 0f && item2.localScale.y > 0f) || (item2.localScale.x < 0f && item2.localScale.y < 0f) || (item2.localScale.z < 0f && item2.localScale.y < 0f) || (item2.localScale.x < 0f && item2.localScale.z < 0f))
					{
						num8 = k + 2;
						num9 = k + 1;
						num10 = k;
					}
					else
					{
						num8 = k;
						num9 = k + 1;
						num10 = k + 2;
					}
					int num11 = dictionary2[triangles[num8] + 1];
					int num12 = dictionary2[triangles[num9] + 1];
					int num13 = dictionary2[triangles[num10] + 1];
					int num14 = dictionary6[triangles[num8] + 1];
					int num15 = dictionary6[triangles[num9] + 1];
					int num16 = dictionary6[triangles[num10] + 1];
					int num17 = dictionary4[triangles[num8] + 1];
					int num18 = dictionary4[triangles[num9] + 1];
					int num19 = dictionary4[triangles[num10] + 1];
					stringBuilder.AppendFormat("f {0}/{1}/{2} {3}/{4}/{5} {6}/{7}/{8}", num11, num14, num17, num12, num15, num18, num13, num16, num19).AppendLine();
				}
				stringBuilder.AppendLine();
				if (!list2.Contains(sharedMaterials[j].name))
				{
					stringBuilder2.AppendFormat("newmtl {0}", sharedMaterials[j].name).AppendLine();
					Color color = sharedMaterials[j].color;
					stringBuilder2.AppendFormat("Kd {0} {1} {2}", color.r, color.g, color.b).AppendLine();
					if (sharedMaterials[j].mainTexture != null && textures)
					{
						Directory.CreateDirectory(path + "/Textures");
						stringBuilder2.AppendFormat("map_Kd Textures/{0}.png", sharedMaterials[j].name).AppendLine();
						Texture2D texture2D = sharedMaterials[j].mainTexture as Texture2D;
						Texture2D texture2D2 = new Texture2D(texture2D.width, texture2D.height, TextureFormat.ARGB32, mipChain: false);
						texture2D2.SetPixels(0, 0, texture2D.width, texture2D.height, texture2D.GetPixels());
						texture2D2.Apply();
						byte[] bytes = texture2D2.EncodeToPNG();
						File.WriteAllBytes(path + "/Textures/" + sharedMaterials[j].name + ".png", bytes);
					}
					stringBuilder2.AppendLine();
					list2.Add(sharedMaterials[j].name);
				}
			}
			num += sharedMesh.vertices.Length;
		}
		StreamWriter streamWriter = new StreamWriter(path + "/" + file + ".obj");
		streamWriter.Write(stringBuilder.ToString());
		streamWriter.Close();
		StreamWriter streamWriter2 = new StreamWriter(path + "/" + file + ".mtl");
		streamWriter2.Write(stringBuilder2.ToString());
		streamWriter2.Close();
	}
}
