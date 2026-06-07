using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OrbCreationExtensions;
using UnityEngine;

public class ObjImporter
{
	public static GameObject Import(string objString)
	{
		return Import(objString, Quaternion.identity, new Vector3(1f, 1f, 1f), Vector3.zero);
	}

	public static GameObject Import(string objString, Quaternion rotate, Vector3 scale, Vector3 translate)
	{
		return Import(objString, null, null, rotate, scale, translate);
	}

	public static GameObject Import(string objString, string mtlString, Hashtable textures)
	{
		return Import(objString, mtlString, textures, Quaternion.identity, Vector3.one, Vector3.zero);
	}

	public static GameObject Import(string objString, string mtlString, Hashtable textures, Quaternion rotate, Vector3 scale, Vector3 translate, bool gameObjectPerGroup = false, bool subMeshPerGroup = false, bool usesRightHandedCoordinates = false)
	{
		List<Hashtable> geometries = ImportGeometry(objString, gameObjectPerGroup, subMeshPerGroup);
		Hashtable[] matSpecs = ImportMaterialSpecs(mtlString);
		PutTexturesInMaterialSpecs(matSpecs, textures);
		return MakeGameObject(geometries, matSpecs, rotate, scale, translate, usesRightHandedCoordinates);
	}

	public static List<Mesh> ImportMeshes(string objString, bool usesRightHandedCoordinates = false, bool mergeSubmeshes = true)
	{
		return MakeMesh(ImportGeometry(objString, false, false), usesRightHandedCoordinates, mergeSubmeshes);
	}

	public static GameObject Import(string objString, string mtlString, Texture2D[] textures)
	{
		return Import(objString, Quaternion.identity, Vector3.one, Vector3.zero, mtlString, textures);
	}

	public static GameObject Import(string objString, Quaternion rotate, Vector3 scale, Vector3 translate, string mtlString, Texture2D[] textures, bool gameObjectPerGroup = false, bool subMeshPerGroup = false, bool usesRightHandedCoordinates = false)
	{
		List<Hashtable> geometries = ImportGeometry(objString, gameObjectPerGroup, subMeshPerGroup);
		Hashtable[] matSpecs = ImportMaterialSpecs(mtlString);
		PutTexturesInMaterialSpecs(matSpecs, textures);
		return MakeGameObject(geometries, matSpecs, rotate, scale, translate, usesRightHandedCoordinates);
	}

	public static IEnumerator ImportInBackground(string objString, string mtlString, Hashtable textures, Action<GameObject> result, bool gameObjectPerGroup = false, bool subMeshPerGroup = false, bool usesRightHandedCoordinates = false)
	{
		yield return null;
		Hashtable info = new Hashtable();
		info["objString"] = objString;
		info["gameObjectPerGroup"] = gameObjectPerGroup;
		info["subMeshPerGroup"] = subMeshPerGroup;
		info["usesRightHandedCoordinates"] = usesRightHandedCoordinates;
		new Thread(ImportGeometryInBackground).Start(info);
		while (!info.ContainsKey("ready"))
		{
			yield return new WaitForSeconds(0.1f);
		}
		Hashtable[] matSpecs = ImportMaterialSpecs(mtlString);
		yield return null;
		PutTexturesInMaterialSpecs(matSpecs, textures);
		yield return null;
		GameObject obj = MakeGameObject((List<Hashtable>)info["geometries"], matSpecs, Quaternion.identity, Vector3.one, Vector3.zero, usesRightHandedCoordinates);
		result(obj);
	}

	public static IEnumerator ImportInBackground(string objString, string mtlString, Hashtable textures, Quaternion rotate, Vector3 scale, Vector3 translate, Action<GameObject> result, bool gameObjectPerGroup = false, bool subMeshPerGroup = false, bool usesRightHandedCoordinates = false)
	{
		yield return null;
		Hashtable info = new Hashtable();
		info["objString"] = objString;
		info["gameObjectPerGroup"] = gameObjectPerGroup;
		info["subMeshPerGroup"] = subMeshPerGroup;
		new Thread(ImportGeometryInBackground).Start(info);
		while (!info.ContainsKey("ready"))
		{
			yield return new WaitForSeconds(0.1f);
		}
		Hashtable[] matSpecs = ImportMaterialSpecs(mtlString);
		yield return null;
		PutTexturesInMaterialSpecs(matSpecs, textures);
		yield return null;
		GameObject obj = MakeGameObject((List<Hashtable>)info["geometries"], matSpecs, rotate, scale, translate, usesRightHandedCoordinates);
		result(obj);
	}

	private static void ImportGeometryInBackground(object data)
	{
		string objString = (string)((Hashtable)data)["objString"];
		bool gameObjectPerGroup = (bool)((Hashtable)data)["gameObjectPerGroup"];
		bool subMeshPerGroup = (bool)((Hashtable)data)["subMeshPerGroup"];
		((Hashtable)data)["geometries"] = ImportGeometry(objString, gameObjectPerGroup, subMeshPerGroup);
		((Hashtable)data)["ready"] = true;
	}

	private static List<Hashtable> ImportGeometry(string objString, bool gameObjectPerGroup, bool subMeshPerGroup)
	{
		objString += "\n";
		List<Hashtable> list = new List<Hashtable>();
		List<Vector3> list2 = new List<Vector3>();
		List<Vector3> list3 = new List<Vector3>();
		List<Vector2> list4 = new List<Vector2>();
		List<Vector3> list5 = new List<Vector3>();
		List<Vector3> list6 = new List<Vector3>();
		List<Vector2> list7 = new List<Vector2>();
		List<Hashtable> list8 = new List<Hashtable>();
		Hashtable hashtable = new Hashtable();
		List<int> triangles = (List<int>)(hashtable["triangles"] = new List<int>());
		string text = "";
		string text2 = "";
		string text3 = "";
		string value = "";
		hashtable["name"] = value;
		list8.Add(hashtable);
		Hashtable hashtable2 = new Hashtable();
		hashtable2["topLevelName"] = text;
		hashtable2["name"] = text2;
		hashtable2["rawVs"] = list2;
		hashtable2["rawNs"] = list3;
		hashtable2["rawUs"] = list4;
		hashtable2["vertices"] = list5;
		hashtable2["normals"] = list6;
		hashtable2["uvs"] = list7;
		hashtable2["subMeshes"] = list8;
		int[] array = null;
		bool flag = true;
		for (int i = 0; i < objString.Length; i++)
		{
			char c = objString[i];
			if (c == '\n')
			{
				flag = true;
			}
			else if (flag && c == 'o' && i < objString.Length - 2 && objString[i + 1] == ' ')
			{
				int num = objString.IndexOfEndOfLine(i + 2);
				if (num > i + 2)
				{
					text2 = objString.Substring(i + 2, num - i - 2).Trim();
					if (text.Length <= 0)
					{
						text = text2;
					}
					hashtable2["topLevelName"] = text;
					if (list2.Count > 0)
					{
						list.Add(hashtable2);
						hashtable2 = new Hashtable();
						hashtable2["topLevelName"] = text;
						hashtable2["name"] = text2;
						hashtable2["rawVs"] = list2;
						hashtable2["rawNs"] = list3;
						hashtable2["rawUs"] = list4;
						hashtable2["vertices"] = list5;
						hashtable2["normals"] = list6;
						hashtable2["uvs"] = list7;
						list8 = (List<Hashtable>)(hashtable2["subMeshes"] = new List<Hashtable>());
						hashtable = new Hashtable();
						triangles = (List<int>)(hashtable["triangles"] = new List<int>());
						list8.Add(hashtable);
					}
					else
					{
						hashtable2["name"] = text2;
					}
					i = num - 1;
				}
			}
			else if (flag && c == 'g' && i < objString.Length - 2 && objString[i + 1] == ' ')
			{
				int num2 = objString.IndexOfEndOfLine(i + 2);
				if (num2 > i + 2)
				{
					if (gameObjectPerGroup)
					{
						if (triangles.Count > 0 && list2.Count > 0)
						{
							list.Add(hashtable2);
							hashtable2 = new Hashtable();
							hashtable2["topLevelName"] = text;
							hashtable2["rawVs"] = list2;
							hashtable2["rawNs"] = list3;
							hashtable2["rawUs"] = list4;
							hashtable2["vertices"] = list5;
							hashtable2["normals"] = list6;
							hashtable2["uvs"] = list7;
							list8 = (List<Hashtable>)(hashtable2["subMeshes"] = new List<Hashtable>());
							hashtable = new Hashtable();
							triangles = (List<int>)(hashtable["triangles"] = new List<int>());
							list8.Add(hashtable);
							text2 = "";
						}
					}
					else if (triangles.Count > 0 && subMeshPerGroup)
					{
						hashtable = new Hashtable();
						triangles = (List<int>)(hashtable["triangles"] = new List<int>());
						list8.Add(hashtable);
					}
					text3 = objString.Substring(i + 2, num2 - i - 2).Trim();
					if (text2.Length <= 0)
					{
						text2 = text3;
					}
					hashtable2["name"] = text2;
					i = num2 - 1;
				}
			}
			else if (flag && c == 'u' && i < objString.Length - 7 && objString.Substring(i, 7) == "usemtl ")
			{
				int num3 = objString.IndexOfEndOfLine(i + 7);
				if (num3 > i + 7)
				{
					string text4 = objString.Substring(i + 7, num3 - i - 7).Trim();
					int j;
					for (j = 0; j < list8.Count; j++)
					{
						Hashtable hashtable3 = list8[j];
						if ((string)hashtable3["name"] == text4)
						{
							hashtable = hashtable3;
							triangles = (List<int>)hashtable3["triangles"];
							break;
						}
					}
					if (triangles.Count > 0 && j >= list8.Count)
					{
						hashtable = new Hashtable();
						triangles = (List<int>)(hashtable["triangles"] = new List<int>());
						list8.Add(hashtable);
					}
					value = text4;
					hashtable["name"] = value;
					i = num3 - 1;
				}
			}
			else if (flag && c == 'v' && i < objString.Length - 2 && objString[i + 1] == ' ')
			{
				i++;
				int num4 = objString.IndexOfEndOfLine(i);
				if (num4 > i)
				{
					Vector3 vector3FromObjString = GetVector3FromObjString(objString.Substring(i, num4 - i).Trim());
					list2.Add(vector3FromObjString);
					i = num4 - 1;
				}
			}
			else if (flag && c == 'v' && i < objString.Length - 2 && objString[i + 1] == 'n' && objString[i + 2] == ' ')
			{
				i += 2;
				int num5 = objString.IndexOfEndOfLine(i);
				if (num5 > i)
				{
					Vector3 vector3FromObjString2 = GetVector3FromObjString(objString.Substring(i, num5 - i).Trim());
					list3.Add(vector3FromObjString2);
					i = num5 - 1;
				}
			}
			else if (flag && c == 'v' && i < objString.Length - 2 && objString[i + 1] == 't' && objString[i + 2] == ' ')
			{
				i += 2;
				int num6 = objString.IndexOfEndOfLine(i);
				if (num6 > i)
				{
					Vector2 vector2FromObjString = GetVector2FromObjString(objString.Substring(i, num6 - i).Trim());
					list4.Add(vector2FromObjString);
					i = num6 - 1;
				}
			}
			else if (flag && c == 'f' && i < objString.Length - 2 && objString[i + 1] == ' ')
			{
				i++;
				int num7 = objString.IndexOfEndOfLine(i);
				if (num7 > i)
				{
					if (array == null)
					{
						array = new int[list2.Count];
						for (int k = 0; k < array.Length; k++)
						{
							array[k] = -1;
						}
					}
					if (array.Length < list2.Count)
					{
						int num8 = array.Length;
						Array.Resize(ref array, list2.Count);
						for (int l = num8; l < array.Length; l++)
						{
							array[l] = -1;
						}
					}
					List<int[]> faceIndexesFromObjString = GetFaceIndexesFromObjString(objString.Substring(i, num7 - i).Trim());
					Vector3 vector = new Vector3(0f, 0f, 0f);
					Vector3 vector2 = new Vector3(0f, 0f, -1f);
					Vector2 vector3 = new Vector2(0f, 0f);
					List<int> list16 = new List<int>();
					for (int m = 0; m < faceIndexesFromObjString.Count; m++)
					{
						int[] array2 = faceIndexesFromObjString[m];
						if (array2.Length == 0)
						{
							continue;
						}
						int num9 = array2[0];
						if (num9 < 0)
						{
							num9 += list2.Count;
						}
						if (num9 >= 0 && num9 < list2.Count)
						{
							vector = list2[num9];
							if (array2[1] < 0)
							{
								array2[1] += list4.Count;
							}
							if (array2[1] >= 0 && array2[1] < list4.Count)
							{
								vector3 = list4[array2[1]];
							}
							if (array2[2] < 0)
							{
								array2[2] += list3.Count;
							}
							if (array2[2] >= 0 && array2[2] < list3.Count)
							{
								vector2 = list3[array2[2]];
							}
							int num10 = array[num9];
							if (num10 >= 0)
							{
								Vector3 vector4 = vector;
								Vector3 n = vector2;
								Vector3 vector5 = vector3;
								if (list6.Count > num10)
								{
									n = list6[num10];
								}
								if (list7.Count > num10)
								{
									vector5 = list7[num10];
								}
								if (list5.Count > num10)
								{
									vector4 = list5[num10];
									if (!IsSameVertex(vector, vector2, vector3, vector4, n, vector5))
									{
										num10 = list5.Count;
									}
								}
							}
							else
							{
								num10 = list5.Count;
							}
							if (num10 >= list5.Count)
							{
								list5.Add(vector);
								if (list3.Count > 0)
								{
									list6.Add(vector2);
								}
								list7.Add(vector3);
								array[num9] = num10;
							}
							list16.Add(num10);
						}
						else
						{
							Log("Bad vertex index:" + num9 + " at:" + m);
						}
					}
					if (list16.Count > 2)
					{
						PolygonIntoTriangle(list16.ToArray(), ref triangles);
					}
					i = num7 - 1;
				}
			}
			if (c != ' ' && c != '\r' && c != '\n' && c != '\t')
			{
				flag = false;
			}
		}
		if (list5.Count > 0)
		{
			list.Add(hashtable2);
		}
		return list;
	}

	public static Hashtable[] ImportMaterialSpecs(string mtlString)
	{
		List<Hashtable> list = new List<Hashtable>();
		Hashtable hashtable = new Hashtable();
		bool flag = true;
		if (mtlString == null)
		{
			mtlString = "";
		}
		mtlString += "\n";
		for (int i = 0; i < mtlString.Length; i++)
		{
			char c = mtlString[i];
			if (c == '\n')
			{
				flag = true;
			}
			else if (flag && c == 'n' && i < mtlString.Length - 7 && mtlString.Substring(i, 7) == "newmtl ")
			{
				i += 7;
				int num = mtlString.IndexOfEndOfLine(i);
				if (num > i)
				{
					if (hashtable.ContainsKey("name"))
					{
						list.Add(hashtable);
						hashtable = new Hashtable();
						hashtable["diffuse"] = Color.white;
					}
					hashtable["name"] = mtlString.Substring(i, num - i).Trim();
					i = num - 1;
				}
			}
			else if (flag && c == 'K' && i < mtlString.Length - 3 && mtlString.Substring(i, 3) == "Kd ")
			{
				i += 2;
				int num2 = mtlString.IndexOfEndOfLine(i);
				if (num2 > i)
				{
					Vector4 vector = GetVector3FromObjString(mtlString.Substring(i, num2 - i).Trim());
					vector.w = 1f;
					hashtable["diffuse"] = (Color)vector;
					i = num2 - 1;
				}
			}
			else if (flag && c == 'K' && i < mtlString.Length - 3 && mtlString.Substring(i, 3) == "Ks ")
			{
				i += 2;
				int num3 = mtlString.IndexOfEndOfLine(i);
				if (num3 > i)
				{
					Vector4 vector2 = GetVector3FromObjString(mtlString.Substring(i, num3 - i).Trim());
					vector2.w = 1f;
					hashtable["specular"] = (Color)vector2;
					i = num3 - 1;
				}
			}
			else if (flag && c == 'd' && i < mtlString.Length - 2 && mtlString[i + 1] == ' ')
			{
				i += 2;
				int num4 = mtlString.IndexOfEndOfLine(i);
				if (num4 > i)
				{
					float a = mtlString.Substring(i, num4 - i).Trim().MakeFloat();
					Color color = Color.white;
					if (hashtable.ContainsKey("diffuse"))
					{
						color = (Color)hashtable["diffuse"];
					}
					color.a = a;
					hashtable["diffuse"] = color;
					i = num4 - 1;
				}
			}
			else if (flag && c == 'T' && i < mtlString.Length - 3 && mtlString.Substring(i, 3) == "Tr ")
			{
				i += 3;
				int num5 = mtlString.IndexOfEndOfLine(i);
				if (num5 > i)
				{
					float a2 = mtlString.Substring(i, num5 - i).Trim().MakeFloat();
					Color color2 = Color.white;
					if (hashtable.ContainsKey("diffuse"))
					{
						color2 = (Color)hashtable["diffuse"];
					}
					color2.a = a2;
					hashtable["diffuse"] = color2;
					i = num5 - 1;
				}
			}
			else if (flag && c == 'N' && i < mtlString.Length - 3 && mtlString.Substring(i, 3) == "Ns ")
			{
				i += 3;
				int num6 = mtlString.IndexOfEndOfLine(i);
				if (num6 > i)
				{
					float num7 = mtlString.Substring(i, num6 - i).Trim().MakeFloat();
					if (num7 > 0f)
					{
						hashtable["specularity"] = 1f / num7;
					}
					i = num6 - 1;
				}
			}
			else if (flag && c == 'm' && i < mtlString.Length - 7 && mtlString.Substring(i, 7) == "map_Kd ")
			{
				i += 7;
				int num8 = mtlString.IndexOfEndOfLine(i);
				if (num8 > i)
				{
					hashtable["mainTexName"] = mtlString.Substring(i, num8 - i).Trim();
					i = num8 - 1;
				}
			}
			else if (flag && c == 'm' && i < mtlString.Length - 6 && mtlString.Substring(i, 7) == "map_d ")
			{
				i += 6;
				int num9 = mtlString.IndexOfEndOfLine(i);
				if (num9 > i)
				{
					hashtable["alphaTexName"] = mtlString.Substring(i, num9 - i).Trim();
					i = num9 - 1;
				}
			}
			if (c != ' ' && c != '\r' && c != '\n' && c != '\t')
			{
				flag = false;
			}
		}
		if (hashtable.ContainsKey("name"))
		{
			list.Add(hashtable);
		}
		return list.ToArray();
	}

	public static void PutTexturesInMaterialSpecs(Hashtable[] matSpecs, Hashtable textures)
	{
		int num = 0;
		while (textures != null && num < matSpecs.Length)
		{
			if (matSpecs[num].ContainsKey("mainTexName"))
			{
				string key = (string)matSpecs[num]["mainTexName"];
				if (textures.ContainsKey(key))
				{
					matSpecs[num]["mainTex"] = (Texture2D)textures[key];
				}
			}
			num++;
		}
	}

	public static void PutTexturesInMaterialSpecs(Hashtable[] matSpecs, Texture2D[] textures)
	{
		int num = 0;
		int num2 = 0;
		while (textures != null && num2 < matSpecs.Length)
		{
			if (matSpecs[num2].ContainsKey("mainTexName") && textures.Length > num)
			{
				matSpecs[num2]["mainTex"] = textures[num++];
			}
			num2++;
		}
	}

	public static void PutMaterialSpecsInMaterial(Material mat, Hashtable[] matSpecs)
	{
		for (int i = 0; i < matSpecs.Length; i++)
		{
			if ((string)matSpecs[i]["name"] == mat.name)
			{
				string text = "Diffuse";
				if (matSpecs[i].ContainsKey("specular") || matSpecs[i].ContainsKey("specularity"))
				{
					text = "Specular";
				}
				if (matSpecs[i].ContainsKey("diffuse") && ((Color)matSpecs[i]["diffuse"]).a < 1f)
				{
					text = "Transparent/" + text;
				}
				else if (matSpecs[i].ContainsKey("mainTex") && ((Texture2D)matSpecs[i]["mainTex"]).HasTransparency())
				{
					text = "Transparent/" + text;
				}
				mat.shader = Shader.Find(text);
				if (matSpecs[i].ContainsKey("mainTex") && mat.HasProperty("_MainTex"))
				{
					mat.SetTexture("_MainTex", (Texture2D)matSpecs[i]["mainTex"]);
				}
				if (matSpecs[i].ContainsKey("diffuse") && mat.HasProperty("_Color"))
				{
					mat.SetColor("_Color", (Color)matSpecs[i]["diffuse"]);
				}
				if (matSpecs[i].ContainsKey("specular") && mat.HasProperty("_SpecColor"))
				{
					mat.SetColor("_SpecColor", (Color)matSpecs[i]["specular"]);
				}
				if (matSpecs[i].ContainsKey("specularity") && mat.HasProperty("_Shininess"))
				{
					mat.SetFloat("_Shininess", (float)matSpecs[i]["specularity"]);
				}
			}
		}
	}

	private static List<Mesh> MakeMesh(List<Hashtable> geometries, bool usesRightHandedCoordinates, bool mergeSubmeshes)
	{
		int num = 65534;
		List<Mesh> list = new List<Mesh>();
		for (int i = 0; i < geometries.Count; i++)
		{
			Hashtable hashtable = geometries[i];
			if (hashtable.GetString("name").Length <= 0)
			{
				string text = "obj" + i;
			}
			List<Vector3> list2 = (List<Vector3>)hashtable["vertices"];
			list2 = list2.GetRange(0, list2.Count);
			List<Vector3> vs = (List<Vector3>)hashtable["normals"];
			List<Vector2> list3 = (List<Vector2>)hashtable["uvs"];
			List<Hashtable> list4 = (List<Hashtable>)hashtable["subMeshes"];
			if (usesRightHandedCoordinates)
			{
				FlipXAxis(ref list2);
				if (vs != null)
				{
					FlipXAxis(ref vs);
				}
			}
			int j = 0;
			int k = 0;
			bool flag;
			do
			{
				flag = false;
				int[] array = new int[list2.Count];
				for (int l = 0; l < array.Length; l++)
				{
					array[l] = -1;
				}
				List<int> list5 = new List<int>();
				List<List<int>> list6 = new List<List<int>>();
				for (; j < list4.Count; j++)
				{
					if (flag)
					{
						break;
					}
					List<int> list7 = (List<int>)list4[j]["triangles"];
					List<int> list8 = new List<int>();
					for (; k < list7.Count; k += 3)
					{
						int num2 = list7[k];
						int num3 = list7[k + 1];
						int num4 = list7[k + 2];
						if (usesRightHandedCoordinates)
						{
							num3 = num2;
							num2 = list7[k + 1];
						}
						if (array[num2] < 0)
						{
							if (list5.Count > num - 3)
							{
								flag = true;
								break;
							}
							array[num2] = list5.Count;
							list5.Add(num2);
						}
						if (array[num3] < 0)
						{
							if (list5.Count > num - 2)
							{
								flag = true;
								break;
							}
							array[num3] = list5.Count;
							list5.Add(num3);
						}
						if (array[num4] < 0)
						{
							if (list5.Count > num - 1)
							{
								flag = true;
								break;
							}
							array[num4] = list5.Count;
							list5.Add(num4);
						}
						list8.Add(array[num2]);
						list8.Add(array[num3]);
						list8.Add(array[num4]);
					}
					if (list8.Count > 0)
					{
						list6.Add(list8);
					}
					k += 3;
					if (k < list7.Count)
					{
						break;
					}
					k = 0;
				}
				if (list5.Count <= 0)
				{
					continue;
				}
				Mesh mesh = new Mesh();
				Vector3[] array2 = new Vector3[list5.Count];
				for (int m = 0; m < list5.Count; m++)
				{
					array2[m] = list2[list5[m]];
				}
				mesh.vertices = array2;
				if (vs.Count > 0)
				{
					Vector3[] array3 = new Vector3[list5.Count];
					for (int n = 0; n < list5.Count; n++)
					{
						array3[n] = vs[list5[n]];
					}
					mesh.normals = array3;
				}
				if (list3.Count > 0)
				{
					Vector2[] array4 = new Vector2[list5.Count];
					for (int num5 = 0; num5 < list5.Count; num5++)
					{
						array4[num5] = list3[list5[num5]];
					}
					mesh.uv = array4;
				}
				if (mergeSubmeshes)
				{
					mesh.subMeshCount = 1;
					mesh.triangles = list6.SelectMany((List<int> x) => x).ToArray();
				}
				else
				{
					mesh.subMeshCount = list6.Count;
					for (int num6 = 0; num6 < list6.Count; num6++)
					{
						mesh.SetTriangles(list6[num6].ToArray(), num6);
					}
				}
				if (vs.Count <= 0)
				{
					mesh.RecalculateNormals();
				}
				mesh.RecalculateTangents();
				mesh.RecalculateBounds();
				list.Add(mesh);
			}
			while (flag);
		}
		return list;
	}

	private static GameObject MakeGameObject(List<Hashtable> geometries, Hashtable[] matSpecs, Quaternion rotate, Vector3 scale, Vector3 translate, bool usesRightHandedCoordinates)
	{
		GameObject gameObject = null;
		int num = 65534;
		string text = "";
		if (geometries.Count > 0)
		{
			text = geometries[0].GetString("topLevelName");
			if (text.Length <= 0)
			{
				text = "Imported OBJ file";
			}
		}
		if (geometries.Count > 1)
		{
			gameObject = new GameObject(text);
		}
		for (int i = 0; i < geometries.Count; i++)
		{
			Hashtable hashtable = geometries[i];
			string text2 = hashtable.GetString("name");
			if (text2.Length <= 0)
			{
				text2 = "obj" + i;
			}
			List<Vector3> list = (List<Vector3>)hashtable["vertices"];
			list = list.GetRange(0, list.Count);
			List<Vector3> vs = (List<Vector3>)hashtable["normals"];
			List<Vector2> list2 = (List<Vector2>)hashtable["uvs"];
			List<Hashtable> list3 = (List<Hashtable>)hashtable["subMeshes"];
			if (usesRightHandedCoordinates)
			{
				FlipXAxis(ref list);
				if (vs != null)
				{
					FlipXAxis(ref vs);
				}
			}
			if (rotate != Quaternion.identity)
			{
				RotateVertices(ref list, rotate);
			}
			if (scale != Vector3.zero)
			{
				ScaleVertices(ref list, scale);
			}
			if (translate != Vector3.zero)
			{
				TranslateVertices(ref list, translate);
			}
			int j = 0;
			int k = 0;
			int num2 = 0;
			bool flag = false;
			while (true)
			{
				bool flag2 = false;
				int[] array = new int[list.Count];
				for (int l = 0; l < array.Length; l++)
				{
					array[l] = -1;
				}
				List<int> list4 = new List<int>();
				List<List<int>> list5 = new List<List<int>>();
				List<Material> list6 = new List<Material>();
				for (; j < list3.Count; j++)
				{
					if (flag2)
					{
						break;
					}
					Hashtable hashtable2 = list3[j];
					List<int> list7 = (List<int>)hashtable2["triangles"];
					List<int> list8 = new List<int>();
					int num3 = 0;
					for (; k < list7.Count; k += 3)
					{
						int num4 = list7[k];
						int num5 = list7[k + 1];
						int num6 = list7[k + 2];
						if (usesRightHandedCoordinates)
						{
							num5 = num4;
							num4 = list7[k + 1];
						}
						if (array[num4] < 0)
						{
							if (list4.Count > num - 3)
							{
								flag2 = true;
								break;
							}
							array[num4] = list4.Count;
							list4.Add(num4);
						}
						if (array[num5] < 0)
						{
							if (list4.Count > num - 2)
							{
								flag2 = true;
								break;
							}
							array[num5] = list4.Count;
							list4.Add(num5);
						}
						if (array[num6] < 0)
						{
							if (list4.Count > num - 1)
							{
								flag2 = true;
								break;
							}
							array[num6] = list4.Count;
							list4.Add(num6);
						}
						list8.Add(array[num4]);
						list8.Add(array[num5]);
						list8.Add(array[num6]);
						num3 += 3;
					}
					if (list8.Count > 0)
					{
						Material material = new Material(Shader.Find("Diffuse"));
						material.SetColor("_Color", Color.white);
						material.name = (string)hashtable2["name"];
						if (material.name.Length <= 0)
						{
							material.name = "mat" + list6.Count;
						}
						list6.Add(material);
						PutMaterialSpecsInMaterial(material, matSpecs);
						list5.Add(list8);
					}
					k += 3;
					if (k < list7.Count)
					{
						break;
					}
					k = 0;
				}
				if (flag2)
				{
					flag = flag2;
				}
				if (list4.Count > 0)
				{
					string text3 = text;
					if (geometries.Count > 1)
					{
						text3 = text2;
					}
					if (flag && gameObject == null)
					{
						gameObject = new GameObject(text3);
					}
					Mesh mesh = new Mesh();
					Vector3[] array2 = new Vector3[list4.Count];
					for (int m = 0; m < list4.Count; m++)
					{
						array2[m] = list[list4[m]];
					}
					mesh.vertices = array2;
					if (vs.Count > 0)
					{
						Vector3[] array3 = new Vector3[list4.Count];
						for (int n = 0; n < list4.Count; n++)
						{
							array3[n] = vs[list4[n]];
						}
						mesh.normals = array3;
					}
					if (list2.Count > 0)
					{
						Vector2[] array4 = new Vector2[list4.Count];
						for (int num7 = 0; num7 < list4.Count; num7++)
						{
							array4[num7] = list2[list4[num7]];
						}
						mesh.uv = array4;
					}
					mesh.subMeshCount = list5.Count;
					for (int num8 = 0; num8 < list5.Count; num8++)
					{
						mesh.SetTriangles(list5[num8].ToArray(), num8);
					}
					if (vs.Count <= 0)
					{
						mesh.RecalculateNormals();
					}
					mesh.RecalculateTangents();
					mesh.RecalculateBounds();
					if (flag && gameObject != null)
					{
						text3 = text3 + "_part" + num2;
					}
					mesh.name = text3;
					GameObject gameObject2 = new GameObject(text3);
					MeshRenderer meshRenderer = gameObject2.AddComponent<MeshRenderer>();
					gameObject2.AddComponent<MeshFilter>().sharedMesh = mesh;
					meshRenderer.sharedMaterials = list6.ToArray();
					if (gameObject == null)
					{
						gameObject = gameObject2;
					}
					else
					{
						gameObject2.transform.SetParent(gameObject.transform);
					}
				}
				if (!flag2)
				{
					break;
				}
				num2++;
			}
		}
		return gameObject;
	}

	private static void FlipXAxis(ref List<Vector3> vs)
	{
		for (int i = 0; i < vs.Count; i++)
		{
			Vector3 value = vs[i];
			value.x *= -1f;
			vs[i] = value;
		}
	}

	private static Vector3 GetVector3FromObjString(string str)
	{
		Vector3 result = new Vector3(0f, 0f, 0f);
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			int num2 = str.IndexOf(' ', num);
			if (num2 < 0)
			{
				num2 = str.Length;
			}
			result[i] = str.Substring(num, num2 - num).MakeFloat();
			num = str.EndOfCharRepetition(num2);
		}
		return result;
	}

	private static Vector2 GetVector2FromObjString(string str)
	{
		Vector2 result = new Vector2(0f, 0f);
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			int num2 = str.IndexOf(' ', num);
			if (num2 < 0)
			{
				num2 = str.Length;
			}
			result[i] = str.Substring(num, num2 - num).MakeFloat();
			num = str.EndOfCharRepetition(num2);
		}
		return result;
	}

	private static List<int[]> GetFaceIndexesFromObjString(string str)
	{
		List<int[]> list = new List<int[]>();
		int num = 0;
		while (num < str.Length)
		{
			int num2 = str.IndexOf(' ', num);
			if (num2 < 0)
			{
				num2 = str.Length;
			}
			list.Add(GetFaceCornerIndexesFromObjString(str.Substring(num, num2 - num).Trim()));
			num = str.EndOfCharRepetition(num2);
		}
		return list;
	}

	private static int[] GetFaceCornerIndexesFromObjString(string str)
	{
		int[] array = new int[3];
		int num = 0;
		int from = 0;
		for (num = 0; num < 3; num++)
		{
			array[num] = -1;
		}
		num = 0;
		while (from < str.Length)
		{
			array[num] = GetIntFromString(str, ref from);
			from++;
			if (array[num] > 0)
			{
				array[num]--;
			}
			num++;
		}
		return array;
	}

	private static int GetIntFromString(string s, ref int from)
	{
		int num = 0;
		while (from < s.Length && char.IsDigit(s[from]))
		{
			num = num * 10 + s[from] - 48;
			from++;
		}
		return num;
	}

	private static void TranslateVertices(ref List<Vector3> vertices, Vector3 translate)
	{
		for (int i = 0; i < vertices.Count; i++)
		{
			vertices[i] += translate;
		}
	}

	private static void ScaleVertices(ref List<Vector3> vertices, Vector3 scale)
	{
		for (int i = 0; i < vertices.Count; i++)
		{
			Vector3 value = vertices[i];
			value.x *= scale.x;
			value.y *= scale.y;
			value.z *= scale.z;
			vertices[i] = value;
		}
	}

	private static void RotateVertices(ref List<Vector3> vertices, Quaternion rotate)
	{
		for (int i = 0; i < vertices.Count; i++)
		{
			vertices[i] = rotate * vertices[i];
		}
	}

	private static bool IsSameVertex(Vector3 v1, Vector3 n1, Vector2 u1, Vector3 v2, Vector3 n2, Vector2 u2)
	{
		if (v1 == v2 && n1 == n2)
		{
			return u1 == u2;
		}
		return false;
	}

	private static void PolygonIntoTriangle(int[] polygon, ref List<int> triangles)
	{
		if (polygon.Length < 3)
		{
			return;
		}
		if (polygon.Length == 3)
		{
			for (int i = 0; i < 3; i++)
			{
				triangles.Add(polygon[i]);
			}
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = polygon.Length / 2;
		int[] array = new int[num3 + 1];
		int[] array2 = new int[polygon.Length - num3 + 1];
		for (num = 0; num < array.Length; num++)
		{
			array[num] = polygon[num2++];
		}
		array2[0] = polygon[num2 - 1];
		for (num = 1; num < array2.Length - 1; num++)
		{
			array2[num] = polygon[num2++];
		}
		array2[num] = polygon[0];
		PolygonIntoTriangle(array, ref triangles);
		PolygonIntoTriangle(array2, ref triangles);
	}

	private static void Log(int[] vs)
	{
		string text = "";
		for (int i = 0; i < vs.Length; i++)
		{
			text = text + vs[i] + "\n";
		}
		Debug.Log(text + DateTime.Now.ToString("yyy/MM/dd hh:mm:ss.fff"));
	}

	private static void Log(Vector3[] vs)
	{
		string text = "";
		for (int i = 0; i < vs.Length; i++)
		{
			text = string.Concat(text, vs[i], "\n");
		}
		Debug.Log(text + DateTime.Now.ToString("yyy/MM/dd hh:mm:ss.fff"));
	}

	private static void Log(string str)
	{
		Debug.Log(str + "\n" + DateTime.Now.ToString("yyy/MM/dd hh:mm:ss.fff"));
	}
}
