using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace UnityFBXExporter
{
	public class FBXUnityMeshGetter
	{
		public static long GetMeshToString(GameObject gameObj, Material[] materials, ref StringBuilder objects, ref StringBuilder connections, GameObject parentObject = null, long parentModelId = 0L)
		{
			StringBuilder objects2 = new StringBuilder();
			StringBuilder connections2 = new StringBuilder();
			long randomFBXId = FBXExporter.GetRandomFBXId();
			long randomFBXId2 = FBXExporter.GetRandomFBXId();
			SkinnedMeshRenderer[] componentsInChildren = gameObj.GetComponentsInChildren<SkinnedMeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].GetComponent<MeshFilter>() == null)
				{
					componentsInChildren[i].gameObject.AddComponent<MeshFilter>();
					componentsInChildren[i].GetComponent<MeshFilter>().sharedMesh = Object.Instantiate(componentsInChildren[i].sharedMesh);
				}
			}
			MeshFilter component = gameObj.GetComponent<MeshFilter>();
			string name = gameObj.name;
			string text = "Null";
			if (component != null)
			{
				name = component.sharedMesh.name;
				text = "Mesh";
			}
			if (parentModelId == 0L)
			{
				connections2.AppendLine("\t;Model::" + name + ", Model::RootNode");
			}
			else
			{
				connections2.AppendLine("\t;Model::" + name + ", Model::USING PARENT");
			}
			connections2.AppendLine("\tC: \"OO\"," + randomFBXId2 + "," + parentModelId);
			connections2.AppendLine();
			objects2.AppendLine("\tModel: " + randomFBXId2 + ", \"Model::" + gameObj.name + "\", \"" + text + "\" {");
			objects2.AppendLine("\t\tVersion: 232");
			objects2.AppendLine("\t\tProperties70:  {");
			objects2.AppendLine("\t\t\tP: \"RotationOrder\", \"enum\", \"\", \"\",4");
			objects2.AppendLine("\t\t\tP: \"RotationActive\", \"bool\", \"\", \"\",1");
			objects2.AppendLine("\t\t\tP: \"InheritType\", \"enum\", \"\", \"\",1");
			objects2.AppendLine("\t\t\tP: \"ScalingMax\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			objects2.AppendLine("\t\t\tP: \"DefaultAttributeIndex\", \"int\", \"Integer\", \"\",0");
			Vector3 localPosition = gameObj.transform.localPosition;
			objects2.Append("\t\t\tP: \"Lcl Translation\", \"Lcl Translation\", \"\", \"A+\",");
			objects2.AppendFormat("{0},{1},{2}", localPosition.x * -1f * 10f, localPosition.y * 10f, localPosition.z * 10f);
			objects2.AppendLine();
			Vector3 localEulerAngles = gameObj.transform.localEulerAngles;
			objects2.AppendFormat("\t\t\tP: \"Lcl Rotation\", \"Lcl Rotation\", \"\", \"A+\",{0},{1},{2}", localEulerAngles.x, localEulerAngles.y * -1f, -1f * localEulerAngles.z);
			objects2.AppendLine();
			Vector3 localScale = gameObj.transform.localScale;
			objects2.AppendFormat("\t\t\tP: \"Lcl Scaling\", \"Lcl Scaling\", \"\", \"A\",{0},{1},{2}", localScale.x, localScale.y, localScale.z);
			objects2.AppendLine();
			objects2.AppendLine("\t\t\tP: \"currentUVSet\", \"KString\", \"\", \"U\", \"map1\"");
			objects2.AppendLine("\t\t}");
			objects2.AppendLine("\t\tShading: T");
			objects2.AppendLine("\t\tCulling: \"CullingOff\"");
			objects2.AppendLine("\t}");
			if (component != null)
			{
				Mesh sharedMesh = component.sharedMesh;
				objects2.AppendLine("\tGeometry: " + randomFBXId + ", \"Geometry::\", \"Mesh\" {");
				Vector3[] vertices = sharedMesh.vertices;
				int num = sharedMesh.vertexCount * 3;
				objects2.AppendLine("\t\tVertices: *" + num + " {");
				objects2.Append("\t\t\ta: ");
				for (int j = 0; j < vertices.Length; j++)
				{
					if (j > 0)
					{
						objects2.Append(",");
					}
					objects2.AppendFormat("{0},{1},{2}", vertices[j].x * -1f * 10f, vertices[j].y * 10f, vertices[j].z * 10f);
				}
				objects2.AppendLine();
				objects2.AppendLine("\t\t} ");
				int num2 = sharedMesh.triangles.Length;
				int[] triangles = sharedMesh.triangles;
				objects2.AppendLine("\t\tPolygonVertexIndex: *" + num2 + " {");
				objects2.Append("\t\t\ta: ");
				for (int k = 0; k < num2; k += 3)
				{
					if (k > 0)
					{
						objects2.Append(",");
					}
					objects2.AppendFormat("{0},{1},{2}", triangles[k], triangles[k + 2], triangles[k + 1] * -1 - 1);
				}
				objects2.AppendLine();
				objects2.AppendLine("\t\t} ");
				objects2.AppendLine("\t\tGeometryVersion: 124");
				objects2.AppendLine("\t\tLayerElementNormal: 0 {");
				objects2.AppendLine("\t\t\tVersion: 101");
				objects2.AppendLine("\t\t\tName: \"\"");
				objects2.AppendLine("\t\t\tMappingInformationType: \"ByPolygonVertex\"");
				objects2.AppendLine("\t\t\tReferenceInformationType: \"Direct\"");
				Vector3[] normals = sharedMesh.normals;
				objects2.AppendLine("\t\t\tNormals: *" + num2 * 3 + " {");
				objects2.Append("\t\t\t\ta: ");
				for (int l = 0; l < num2; l += 3)
				{
					if (l > 0)
					{
						objects2.Append(",");
					}
					Vector3 vector = normals[triangles[l]];
					objects2.AppendFormat("{0},{1},{2},", vector.x * -1f, vector.y, vector.z);
					vector = normals[triangles[l + 2]];
					objects2.AppendFormat("{0},{1},{2},", vector.x * -1f, vector.y, vector.z);
					vector = normals[triangles[l + 1]];
					objects2.AppendFormat("{0},{1},{2}", vector.x * -1f, vector.y, vector.z);
				}
				objects2.AppendLine();
				objects2.AppendLine("\t\t\t}");
				objects2.AppendLine("\t\t}");
				bool flag = sharedMesh.colors.Length == vertices.Length;
				if (flag)
				{
					Color[] colors = sharedMesh.colors;
					Dictionary<Color, int> dictionary = new Dictionary<Color, int>();
					int num3 = 0;
					for (int m = 0; m < colors.Length; m++)
					{
						if (!dictionary.ContainsKey(colors[m]))
						{
							dictionary[colors[m]] = num3;
							num3++;
						}
					}
					objects2.AppendLine("\t\tLayerElementColor: 0 {");
					objects2.AppendLine("\t\t\tVersion: 101");
					objects2.AppendLine("\t\t\tName: \"Col\"");
					objects2.AppendLine("\t\t\tMappingInformationType: \"ByPolygonVertex\"");
					objects2.AppendLine("\t\t\tReferenceInformationType: \"IndexToDirect\"");
					objects2.AppendLine("\t\t\tColors: *" + dictionary.Count * 4 + " {");
					objects2.Append("\t\t\t\ta: ");
					bool flag2 = true;
					foreach (KeyValuePair<Color, int> item in dictionary)
					{
						if (!flag2)
						{
							objects2.Append(",");
						}
						objects2.AppendFormat("{0},{1},{2},{3}", item.Key.r, item.Key.g, item.Key.b, item.Key.a);
						flag2 = false;
					}
					objects2.AppendLine();
					objects2.AppendLine("\t\t\t\t}");
					objects2.AppendLine("\t\t\tColorIndex: *" + triangles.Length + " {");
					objects2.Append("\t\t\t\ta: ");
					for (int n = 0; n < triangles.Length; n += 3)
					{
						if (n > 0)
						{
							objects2.Append(",");
						}
						int num4 = triangles[n];
						int num5 = triangles[n + 2];
						int num6 = triangles[n + 1];
						num4 = dictionary[colors[num4]];
						num5 = dictionary[colors[num5]];
						num6 = dictionary[colors[num6]];
						objects2.AppendFormat("{0},{1},{2}", num4, num5, num6);
					}
					objects2.AppendLine();
					objects2.AppendLine("\t\t\t}");
					objects2.AppendLine("\t\t}");
				}
				else
				{
					Debug.LogWarning("Mesh contains " + sharedMesh.vertices.Length + " vertices for " + sharedMesh.colors.Length + " colors. Skip color export");
				}
				int num7 = sharedMesh.uv.Length;
				Vector2[] uv = sharedMesh.uv;
				objects2.AppendLine("\t\tLayerElementUV: 0 {");
				objects2.AppendLine("\t\t\tVersion: 101");
				objects2.AppendLine("\t\t\tName: \"map1\"");
				objects2.AppendLine("\t\t\tMappingInformationType: \"ByPolygonVertex\"");
				objects2.AppendLine("\t\t\tReferenceInformationType: \"IndexToDirect\"");
				objects2.AppendLine("\t\t\tUV: *" + num7 * 2 + " {");
				objects2.Append("\t\t\t\ta: ");
				for (int num8 = 0; num8 < num7; num8++)
				{
					if (num8 > 0)
					{
						objects2.Append(",");
					}
					objects2.AppendFormat("{0},{1}", uv[num8].x, uv[num8].y);
				}
				objects2.AppendLine();
				objects2.AppendLine("\t\t\t\t}");
				objects2.AppendLine("\t\t\tUVIndex: *" + num2 + " {");
				objects2.Append("\t\t\t\ta: ");
				for (int num9 = 0; num9 < num2; num9 += 3)
				{
					if (num9 > 0)
					{
						objects2.Append(",");
					}
					int num10 = triangles[num9];
					int num11 = triangles[num9 + 2];
					int num12 = triangles[num9 + 1];
					objects2.AppendFormat("{0},{1},{2}", num10, num11, num12);
				}
				objects2.AppendLine();
				objects2.AppendLine("\t\t\t}");
				objects2.AppendLine("\t\t}");
				objects2.AppendLine("\t\tLayerElementMaterial: 0 {");
				objects2.AppendLine("\t\t\tVersion: 101");
				objects2.AppendLine("\t\t\tName: \"\"");
				objects2.AppendLine("\t\t\tMappingInformationType: \"ByPolygon\"");
				objects2.AppendLine("\t\t\tReferenceInformationType: \"IndexToDirect\"");
				int num13 = 0;
				int subMeshCount = sharedMesh.subMeshCount;
				StringBuilder stringBuilder = new StringBuilder();
				if (subMeshCount == 1)
				{
					int num14 = triangles.Length / 3;
					for (int num15 = 0; num15 < num14; num15++)
					{
						stringBuilder.Append("0,");
						num13++;
					}
				}
				else
				{
					List<int[]> list = new List<int[]>();
					for (int num16 = 0; num16 < subMeshCount; num16++)
					{
						list.Add(sharedMesh.GetIndices(num16));
					}
					for (int num17 = 0; num17 < triangles.Length; num17 += 3)
					{
						for (int num18 = 0; num18 < list.Count; num18++)
						{
							bool flag3 = false;
							for (int num19 = 0; num19 < list[num18].Length; num19 += 3)
							{
								if (triangles[num17] == list[num18][num19] && triangles[num17 + 1] == list[num18][num19 + 1] && triangles[num17 + 2] == list[num18][num19 + 2])
								{
									stringBuilder.Append(num18.ToString());
									stringBuilder.Append(",");
									num13++;
									break;
								}
								if (flag3)
								{
									break;
								}
							}
						}
					}
				}
				objects2.AppendLine("\t\t\tMaterials: *" + num13 + " {");
				objects2.Append("\t\t\t\ta: ");
				objects2.AppendLine(stringBuilder.ToString());
				objects2.AppendLine("\t\t\t} ");
				objects2.AppendLine("\t\t}");
				objects2.AppendLine("\t\tLayer: 0 {");
				objects2.AppendLine("\t\t\tVersion: 100");
				objects2.AppendLine("\t\t\tLayerElement:  {");
				objects2.AppendLine("\t\t\t\tType: \"LayerElementNormal\"");
				objects2.AppendLine("\t\t\t\tTypedIndex: 0");
				objects2.AppendLine("\t\t\t}");
				objects2.AppendLine("\t\t\tLayerElement:  {");
				objects2.AppendLine("\t\t\t\tType: \"LayerElementMaterial\"");
				objects2.AppendLine("\t\t\t\tTypedIndex: 0");
				objects2.AppendLine("\t\t\t}");
				objects2.AppendLine("\t\t\tLayerElement:  {");
				objects2.AppendLine("\t\t\t\tType: \"LayerElementTexture\"");
				objects2.AppendLine("\t\t\t\tTypedIndex: 0");
				objects2.AppendLine("\t\t\t}");
				if (flag)
				{
					objects2.AppendLine("\t\t\tLayerElement:  {");
					objects2.AppendLine("\t\t\t\tType: \"LayerElementColor\"");
					objects2.AppendLine("\t\t\t\tTypedIndex: 0");
					objects2.AppendLine("\t\t\t}");
				}
				objects2.AppendLine("\t\t\tLayerElement:  {");
				objects2.AppendLine("\t\t\t\tType: \"LayerElementUV\"");
				objects2.AppendLine("\t\t\t\tTypedIndex: 0");
				objects2.AppendLine("\t\t\t}");
				objects2.AppendLine("\t\t}");
				objects2.AppendLine("\t}");
				connections2.AppendLine("\t;Geometry::, Model::" + sharedMesh.name);
				connections2.AppendLine("\tC: \"OO\"," + randomFBXId + "," + randomFBXId2);
				connections2.AppendLine();
				MeshRenderer component2 = gameObj.GetComponent<MeshRenderer>();
				if (component2 != null)
				{
					Material[] sharedMaterials = component2.sharedMaterials;
					foreach (Material material in sharedMaterials)
					{
						int num21 = Mathf.Abs(material.GetInstanceID());
						if (material == null)
						{
							Debug.LogError("ERROR: the game object " + gameObj.name + " has an empty material on it. This will export problematic files. Please fix and reexport");
							continue;
						}
						connections2.AppendLine("\t;Material::" + material.name + ", Model::" + sharedMesh.name);
						connections2.AppendLine("\tC: \"OO\"," + num21 + "," + randomFBXId2);
						connections2.AppendLine();
					}
				}
			}
			for (int num22 = 0; num22 < gameObj.transform.childCount; num22++)
			{
				GetMeshToString(gameObj.transform.GetChild(num22).gameObject, materials, ref objects2, ref connections2, gameObj, randomFBXId2);
			}
			objects.Append(objects2.ToString());
			connections.Append(connections2.ToString());
			return randomFBXId2;
		}
	}
}
