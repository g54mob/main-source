using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

public class STL
{
	private const string logPrepend = "<b>[STL]</b> ";

	public static bool Export(GameObject gameObject, string filePath, bool asASCII = false)
	{
		return Export(new GameObject[1] { gameObject }, filePath, asASCII);
	}

	public static bool Export(GameObject[] gameObjects, string filePath, bool asASCII = false)
	{
		GetMeshesAndMatrixes(gameObjects, out var meshes, out var matrices);
		return Export(meshes, matrices, filePath, asASCII);
	}

	public static bool Export(MeshFilter filter, string filePath, bool asASCII = false)
	{
		if (!filter.sharedMesh)
		{
			Debug.LogError("<b>[STL]</b> Export failed. Meshfilter has no mesh.\n");
			return false;
		}
		return Export(new MeshFilter[1] { filter }, filePath, asASCII);
	}

	public static bool Export(MeshFilter[] filters, string filePath, bool asASCII = false)
	{
		GetMeshesAndMatrixes(filters, out var meshes, out var matrices);
		return Export(meshes, matrices, filePath, asASCII);
	}

	public static bool Export(SkinnedMeshRenderer skin, string filePath, bool asASCII = false)
	{
		if (!skin.sharedMesh)
		{
			Debug.LogError("<b>[STL]</b> Export failed. SkinnedMeshRenderer has no mesh.\n");
			return false;
		}
		return Export(new SkinnedMeshRenderer[1] { skin }, filePath, asASCII);
	}

	public static bool Export(SkinnedMeshRenderer[] skins, string filePath, bool asASCII = false)
	{
		GetMeshesAndMatrixes(skins, out var meshes, out var matrices);
		return Export(meshes, matrices, filePath, asASCII);
	}

	public static bool Export(Mesh mesh, string filePath, bool asASCII = false)
	{
		return Export(new Mesh[1] { mesh }, new Matrix4x4[1] { Matrix4x4.identity }, filePath, asASCII);
	}

	public static bool Export(Mesh[] meshes, string filePath, bool asASCII = false)
	{
		Matrix4x4[] array = new Matrix4x4[meshes.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Matrix4x4.identity;
		}
		return Export(meshes, array, filePath, asASCII);
	}

	public static bool Export(Mesh mesh, Matrix4x4 matrix, string filePath, bool asASCII = false)
	{
		return Export(new Mesh[1] { mesh }, new Matrix4x4[1] { matrix }, filePath, asASCII);
	}

	public static bool Export(Mesh[] meshes, Matrix4x4[] matrices, string filePath, bool asASCII = false)
	{
		if (!asASCII)
		{
			return ExportSTLAsBinary(meshes, matrices, filePath);
		}
		return ExportSTLAsASCII(meshes, matrices, filePath);
	}

	private static bool ExportSTLAsBinary(Mesh[] meshes, Matrix4x4[] matrices, string filePath)
	{
		if (meshes.Length != matrices.Length)
		{
			Debug.LogError("<b>[STL]</b> Mesh array length and matrix array length must match.\n");
			return false;
		}
		try
		{
			using BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.Create));
			binaryWriter.Write(new char[80]);
			int num = 0;
			foreach (Mesh mesh in meshes)
			{
				for (int j = 0; j < mesh.subMeshCount; j++)
				{
					num += mesh.GetTriangles(j).Length;
				}
			}
			uint value = (uint)(num / 3);
			binaryWriter.Write(value);
			short value2 = 0;
			Vector3 zero = Vector3.zero;
			for (int k = 0; k < meshes.Length; k++)
			{
				Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(-1f, 1f, 1f)) * matrices[k];
				Vector3[] vertices = meshes[k].vertices;
				for (int l = 0; l < vertices.Length; l++)
				{
					vertices[l] = matrix4x.MultiplyPoint(vertices[l]);
				}
				for (int m = 0; m < meshes[k].subMeshCount; m++)
				{
					int[] triangles = meshes[k].GetTriangles(m);
					for (int n = 0; n < triangles.Length; n += 3)
					{
						Vector3 vector = vertices[triangles[n + 1]] - vertices[triangles[n]];
						Vector3 vector2 = vertices[triangles[n + 2]] - vertices[triangles[n]];
						zero.Set(vector.y * vector2.z - vector.z * vector2.y, vector.z * vector2.x - vector.x * vector2.z, vector.x * vector2.y - vector.y * vector2.x);
						zero.Normalize();
						for (int num2 = 0; num2 < 3; num2++)
						{
							binaryWriter.Write(zero[num2]);
						}
						Vector3 vector3 = vertices[triangles[n + 2]];
						for (int num2 = 0; num2 < 3; num2++)
						{
							binaryWriter.Write(vector3[num2]);
						}
						vector3 = vertices[triangles[n + 1]];
						for (int num2 = 0; num2 < 3; num2++)
						{
							binaryWriter.Write(vector3[num2]);
						}
						vector3 = vertices[triangles[n]];
						for (int num2 = 0; num2 < 3; num2++)
						{
							binaryWriter.Write(vector3[num2]);
						}
						binaryWriter.Write(value2);
					}
				}
			}
			binaryWriter.Close();
		}
		catch (Exception ex)
		{
			Debug.LogWarning("<b>[STL]</b> Failed exporting binary STL file at: " + filePath + "\n" + ex);
			return false;
		}
		return true;
	}

	private static bool ExportSTLAsASCII(Mesh[] meshes, Matrix4x4[] matrices, string filePath)
	{
		if (meshes.Length != matrices.Length)
		{
			Debug.LogError("<b>[STL]</b> Mesh array length and matrix array length must match.\n");
			return false;
		}
		List<Vector3[]> list = TransformAndTranslateVerticesIntoPositiveSpace(meshes, matrices);
		try
		{
			bool append = false;
			using StreamWriter streamWriter = new StreamWriter(filePath, append);
			streamWriter.WriteLine("solid Unity Mesh");
			Vector3 zero = Vector3.zero;
			CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
			for (int i = 0; i < meshes.Length; i++)
			{
				StringBuilder stringBuilder = new StringBuilder();
				Vector3[] array = list[i];
				for (int j = 0; j < meshes[i].subMeshCount; j++)
				{
					int[] triangles = meshes[i].GetTriangles(j);
					for (int k = 0; k < triangles.Length; k += 3)
					{
						Vector3 vector = array[triangles[k + 1]] - array[triangles[k]];
						Vector3 vector2 = array[triangles[k + 2]] - array[triangles[k]];
						zero.Set(vector.y * vector2.z - vector.z * vector2.y, vector.z * vector2.x - vector.x * vector2.z, vector.x * vector2.y - vector.y * vector2.x);
						zero.Normalize();
						stringBuilder.AppendLine("facet normal " + zero.x.ToString("e", cultureInfo) + " " + zero.y.ToString("e", cultureInfo) + " " + zero.z.ToString("e", cultureInfo));
						stringBuilder.AppendLine("outer loop");
						stringBuilder.AppendLine("vertex " + array[triangles[k + 2]].x.ToString("e", cultureInfo) + " " + array[triangles[k + 2]].y.ToString("e", cultureInfo) + " " + array[triangles[k + 2]].z.ToString("e", cultureInfo));
						stringBuilder.AppendLine("vertex " + array[triangles[k + 1]].x.ToString("e", cultureInfo) + " " + array[triangles[k + 1]].y.ToString("e", cultureInfo) + " " + array[triangles[k + 1]].z.ToString("e", cultureInfo));
						stringBuilder.AppendLine("vertex " + array[triangles[k]].x.ToString("e", cultureInfo) + " " + array[triangles[k]].y.ToString("e", cultureInfo) + " " + array[triangles[k]].z.ToString("e", cultureInfo));
						stringBuilder.AppendLine("endloop");
						stringBuilder.AppendLine("endfacet");
					}
				}
				streamWriter.Write(stringBuilder.ToString());
			}
			streamWriter.WriteLine("endsolid Unity Mesh");
			streamWriter.Close();
		}
		catch (Exception ex)
		{
			Debug.LogWarning("<b>[STL]</b> Failed exporting ASCII STL file at: " + filePath + "\n" + ex);
			return false;
		}
		return true;
	}

	public static bool Convert(GameObject gameObject, out byte[] stlAsBinary)
	{
		return Convert(new GameObject[1] { gameObject }, out stlAsBinary);
	}

	public static bool Convert(GameObject[] gameObjects, out byte[] stlAsBinary)
	{
		GetMeshesAndMatrixes(gameObjects, out var meshes, out var matrices);
		return Convert(meshes, matrices, out stlAsBinary);
	}

	public static bool Convert(MeshFilter filter, out byte[] stlAsBinary)
	{
		stlAsBinary = new byte[0];
		if (!filter.sharedMesh)
		{
			Debug.LogError("<b>[STL]</b> Export failed. Meshfilter has no mesh.\n");
			return false;
		}
		return Convert(new MeshFilter[1] { filter }, out stlAsBinary);
	}

	public static bool Convert(MeshFilter[] filters, out byte[] stlAsBinary)
	{
		GetMeshesAndMatrixes(filters, out var meshes, out var matrices);
		return Convert(meshes, matrices, out stlAsBinary);
	}

	public static bool Convert(SkinnedMeshRenderer skin, out byte[] stlAsBinary)
	{
		stlAsBinary = new byte[0];
		if (!skin.sharedMesh)
		{
			Debug.LogError("<b>[STL]</b> Export failed. SkinnedMeshRenderer has no mesh.\n");
			return false;
		}
		return Convert(new SkinnedMeshRenderer[1] { skin }, out stlAsBinary);
	}

	public static bool Convert(SkinnedMeshRenderer[] skins, out byte[] stlAsBinary)
	{
		GetMeshesAndMatrixes(skins, out var meshes, out var matrices);
		return Convert(meshes, matrices, out stlAsBinary);
	}

	public static bool Convert(Mesh mesh, out byte[] stlAsBinary)
	{
		return Convert(new Mesh[1] { mesh }, new Matrix4x4[1] { Matrix4x4.identity }, out stlAsBinary);
	}

	public static bool Convert(Mesh[] meshes, out byte[] stlAsBinary)
	{
		Matrix4x4[] array = new Matrix4x4[meshes.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Matrix4x4.identity;
		}
		return Convert(meshes, array, out stlAsBinary);
	}

	public static bool Convert(Mesh mesh, Matrix4x4 matrix, out byte[] stlAsBinary)
	{
		return Convert(new Mesh[1] { mesh }, new Matrix4x4[1] { matrix }, out stlAsBinary);
	}

	public static bool Convert(GameObject gameObject, out string stlAsASCII)
	{
		return Convert(new GameObject[1] { gameObject }, out stlAsASCII);
	}

	public static bool Convert(GameObject[] gameObjects, out string stlAsASCII)
	{
		GetMeshesAndMatrixes(gameObjects, out var meshes, out var matrices);
		return Convert(meshes, matrices, out stlAsASCII);
	}

	public static bool Convert(MeshFilter filter, out string stlAsASCII)
	{
		stlAsASCII = string.Empty;
		if (!filter.sharedMesh)
		{
			Debug.LogError("<b>[STL]</b> Export failed. Meshfilter has no mesh.\n");
			return false;
		}
		return Convert(new MeshFilter[1] { filter }, out stlAsASCII);
	}

	public static bool Convert(MeshFilter[] filters, out string stlAsASCII)
	{
		GetMeshesAndMatrixes(filters, out var meshes, out var matrices);
		return Convert(meshes, matrices, out stlAsASCII);
	}

	public static bool Convert(SkinnedMeshRenderer skin, out string stlAsASCII)
	{
		stlAsASCII = string.Empty;
		if (!skin.sharedMesh)
		{
			Debug.LogError("<b>[STL]</b> Export failed. SkinnedMeshRenderer has no mesh.\n");
			return false;
		}
		return Convert(new SkinnedMeshRenderer[1] { skin }, out stlAsASCII);
	}

	public static bool Convert(SkinnedMeshRenderer[] skins, out string stlAsASCII)
	{
		GetMeshesAndMatrixes(skins, out var meshes, out var matrices);
		return Convert(meshes, matrices, out stlAsASCII);
	}

	public static bool Convert(Mesh mesh, out string stlAsASCII)
	{
		return Convert(new Mesh[1] { mesh }, new Matrix4x4[1] { Matrix4x4.identity }, out stlAsASCII);
	}

	public static bool Convert(Mesh[] meshes, out string stlAsASCII)
	{
		Matrix4x4[] array = new Matrix4x4[meshes.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Matrix4x4.identity;
		}
		return Convert(meshes, array, out stlAsASCII);
	}

	public static bool Convert(Mesh mesh, Matrix4x4 matrix, out string stlAsASCII)
	{
		return Convert(new Mesh[1] { mesh }, new Matrix4x4[1] { matrix }, out stlAsASCII);
	}

	public static bool Convert(Mesh[] meshes, Matrix4x4[] matrices, out byte[] stlAsBinary)
	{
		stlAsBinary = new byte[0];
		if (meshes.Length != matrices.Length)
		{
			Debug.LogError("<b>[STL]</b> Mesh array length and matrix array length must match.\n");
			return false;
		}
		List<byte> list = new List<byte>();
		try
		{
			list.AddRange(Encoding.GetEncoding("ascii").GetBytes(new char[80]));
			int num = 0;
			foreach (Mesh mesh in meshes)
			{
				for (int j = 0; j < mesh.subMeshCount; j++)
				{
					num += mesh.GetTriangles(j).Length;
				}
			}
			byte[] bytes = BitConverter.GetBytes((uint)(num / 3));
			list.AddRange(bytes);
			short value = 0;
			Vector3 zero = Vector3.zero;
			for (int k = 0; k < meshes.Length; k++)
			{
				Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(-1f, 1f, 1f)) * matrices[k];
				Vector3[] vertices = meshes[k].vertices;
				for (int l = 0; l < vertices.Length; l++)
				{
					vertices[l] = matrix4x.MultiplyPoint(vertices[l]);
				}
				for (int m = 0; m < meshes[k].subMeshCount; m++)
				{
					int[] triangles = meshes[k].GetTriangles(m);
					for (int n = 0; n < triangles.Length; n += 3)
					{
						Vector3 vector = vertices[triangles[n + 1]] - vertices[triangles[n]];
						Vector3 vector2 = vertices[triangles[n + 2]] - vertices[triangles[n]];
						zero.Set(vector.y * vector2.z - vector.z * vector2.y, vector.z * vector2.x - vector.x * vector2.z, vector.x * vector2.y - vector.y * vector2.x);
						zero.Normalize();
						for (int num2 = 0; num2 < 3; num2++)
						{
							bytes = BitConverter.GetBytes(zero[num2]);
							list.AddRange(bytes);
						}
						Vector3 vector3 = vertices[triangles[n + 2]];
						for (int num2 = 0; num2 < 3; num2++)
						{
							bytes = BitConverter.GetBytes(vector3[num2]);
							list.AddRange(bytes);
						}
						vector3 = vertices[triangles[n + 1]];
						for (int num2 = 0; num2 < 3; num2++)
						{
							bytes = BitConverter.GetBytes(vector3[num2]);
							list.AddRange(bytes);
						}
						vector3 = vertices[triangles[n]];
						for (int num2 = 0; num2 < 3; num2++)
						{
							bytes = BitConverter.GetBytes(vector3[num2]);
							list.AddRange(bytes);
						}
						bytes = BitConverter.GetBytes(value);
						list.AddRange(bytes);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("<b>[STL]</b> Failed converting to binary STL data.\n" + ex);
			return false;
		}
		stlAsBinary = list.ToArray();
		return true;
	}

	public static bool Convert(Mesh[] meshes, Matrix4x4[] matrices, out string stlAsASCII)
	{
		stlAsASCII = string.Empty;
		if (meshes.Length != matrices.Length)
		{
			Debug.LogError("<b>[STL]</b> Mesh array length and matrix array length must match.\n");
			return false;
		}
		List<Vector3[]> list = TransformAndTranslateVerticesIntoPositiveSpace(meshes, matrices);
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			stringBuilder.AppendLine("solid Unity Mesh");
			Vector3 zero = Vector3.zero;
			CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
			for (int i = 0; i < meshes.Length; i++)
			{
				Vector3[] array = list[i];
				for (int j = 0; j < meshes[i].subMeshCount; j++)
				{
					int[] triangles = meshes[i].GetTriangles(j);
					for (int k = 0; k < triangles.Length; k += 3)
					{
						Vector3 vector = array[triangles[k + 1]] - array[triangles[k]];
						Vector3 vector2 = array[triangles[k + 2]] - array[triangles[k]];
						zero.Set(vector.y * vector2.z - vector.z * vector2.y, vector.z * vector2.x - vector.x * vector2.z, vector.x * vector2.y - vector.y * vector2.x);
						zero.Normalize();
						stringBuilder.AppendLine("facet normal " + zero.x.ToString("e", cultureInfo) + " " + zero.y.ToString("e", cultureInfo) + " " + zero.z.ToString("e", cultureInfo));
						stringBuilder.AppendLine("outer loop");
						stringBuilder.AppendLine("vertex " + array[triangles[k + 2]].x.ToString("e", cultureInfo) + " " + array[triangles[k + 2]].y.ToString("e", cultureInfo) + " " + array[triangles[k + 2]].z.ToString("e", cultureInfo));
						stringBuilder.AppendLine("vertex " + array[triangles[k + 1]].x.ToString("e", cultureInfo) + " " + array[triangles[k + 1]].y.ToString("e", cultureInfo) + " " + array[triangles[k + 1]].z.ToString("e", cultureInfo));
						stringBuilder.AppendLine("vertex " + array[triangles[k]].x.ToString("e", cultureInfo) + " " + array[triangles[k]].y.ToString("e", cultureInfo) + " " + array[triangles[k]].z.ToString("e", cultureInfo));
						stringBuilder.AppendLine("endloop");
						stringBuilder.AppendLine("endfacet");
					}
				}
			}
			stringBuilder.AppendLine("endsolid Unity Mesh");
		}
		catch (Exception ex)
		{
			Debug.LogWarning("<b>[STL]</b> Failed converting meshes to STL ASCII text.\n" + ex);
			return false;
		}
		stlAsASCII = stringBuilder.ToString();
		return true;
	}

	private static List<Vector3[]> TransformAndTranslateVerticesIntoPositiveSpace(Mesh[] meshes, Matrix4x4[] matrices)
	{
		Bounds bounds = default(Bounds);
		List<Vector3[]> list = new List<Vector3[]>();
		for (int i = 0; i < meshes.Length; i++)
		{
			Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(-1f, 1f, 1f)) * matrices[i];
			Vector3[] vertices = meshes[i].vertices;
			for (int j = 0; j < vertices.Length; j++)
			{
				vertices[j] = matrix4x.MultiplyPoint(vertices[j]);
				if (i == 0 && j == 0)
				{
					bounds.SetMinMax(vertices[j], vertices[j]);
				}
				else
				{
					bounds.Encapsulate(vertices[j]);
				}
			}
			list.Add(vertices);
		}
		if (bounds.min.x < 0f || bounds.min.y < 0f || bounds.min.z < 0f)
		{
			Vector3 vector = -new Vector3(Mathf.Min(bounds.min.x, 0f), Mathf.Min(bounds.min.y, 0f), Mathf.Min(bounds.min.z, 0f));
			for (int k = 0; k < meshes.Length; k++)
			{
				Vector3[] array = list[k];
				for (int l = 0; l < array.Length; l++)
				{
					array[l] += vector;
				}
			}
		}
		return list;
	}

	public static void GetMeshesAndMatrixes(GameObject[] objects, out Mesh[] meshes, out Matrix4x4[] matrices)
	{
		List<Mesh> list = new List<Mesh>();
		List<Matrix4x4> list2 = new List<Matrix4x4>();
		List<Transform> list3 = new List<Transform>();
		for (int i = 0; i < objects.Length; i++)
		{
			Transform[] componentsInChildren = objects[i].GetComponentsInChildren<Transform>();
			foreach (Transform item in componentsInChildren)
			{
				if (!list3.Contains(item))
				{
					list3.Add(item);
				}
			}
		}
		foreach (Transform item2 in list3)
		{
			MeshFilter component = item2.GetComponent<MeshFilter>();
			if ((bool)component)
			{
				list.Add(component.sharedMesh);
				list2.Add(item2.localToWorldMatrix);
			}
			SkinnedMeshRenderer component2 = item2.GetComponent<SkinnedMeshRenderer>();
			if ((bool)component2)
			{
				Mesh mesh = new Mesh();
				mesh.name = component2.sharedMesh.name;
				component2.BakeMesh(mesh);
				list.Add(mesh);
				list2.Add(Matrix4x4.identity);
			}
		}
		meshes = list.ToArray();
		matrices = list2.ToArray();
	}

	public static void GetMeshesAndMatrixes(MeshFilter[] filters, out Mesh[] meshes, out Matrix4x4[] matrices)
	{
		List<Mesh> list = new List<Mesh>();
		List<Matrix4x4> list2 = new List<Matrix4x4>();
		for (int i = 0; i < filters.Length; i++)
		{
			if ((bool)filters[i] && (bool)filters[i].sharedMesh)
			{
				list.Add(filters[i].sharedMesh);
				list2.Add(filters[i].transform.localToWorldMatrix);
			}
		}
		meshes = list.ToArray();
		matrices = list2.ToArray();
	}

	public static void GetMeshesAndMatrixes(SkinnedMeshRenderer[] skins, out Mesh[] meshes, out Matrix4x4[] matrices)
	{
		List<Mesh> list = new List<Mesh>();
		List<Matrix4x4> list2 = new List<Matrix4x4>();
		for (int i = 0; i < skins.Length; i++)
		{
			if ((bool)skins[i] && (bool)skins[i].sharedMesh)
			{
				Mesh mesh = new Mesh();
				mesh.name = skins[i].sharedMesh.name;
				skins[i].BakeMesh(mesh);
				list.Add(mesh);
				list2.Add(Matrix4x4.identity);
			}
		}
		meshes = list.ToArray();
		matrices = list2.ToArray();
	}

	private static void Reverse4Bytes(byte[] data)
	{
		byte b = data[0];
		data[0] = data[3];
		data[3] = b;
		b = data[1];
		data[1] = data[2];
		data[2] = b;
	}

	[Obsolete("Deprecated. Use the Export method instead.")]
	public static void ExportBinary(GameObject[] gameObjects, string filePath)
	{
		Export(gameObjects, filePath);
	}

	[Obsolete("Deprecated. Use the Export method instead.")]
	public static void ExportBinary(MeshFilter[] filters, string filePath)
	{
		Export(filters, filePath);
	}

	[Obsolete("Deprecated. Use the Export method instead.")]
	public static void ExportBinary(SkinnedMeshRenderer[] skins, string filePath)
	{
		Export(skins, filePath);
	}

	[Obsolete("Deprecated. Use the Export method instead.")]
	public static void ExportBinary(Mesh mesh, Matrix4x4 matrix, string filePath)
	{
		Export(mesh, filePath);
	}

	[Obsolete("Deprecated. Use the Export method instead.")]
	public static void ExportBinary(Mesh[] meshes, Matrix4x4[] matrices, string filePath)
	{
		Export(meshes, matrices, filePath);
	}

	[Obsolete("Deprecated. Use the Export method instead.")]
	public static void ExportText(GameObject[] gameObjects, string filePath)
	{
		bool asASCII = true;
		Export(gameObjects, filePath, asASCII);
	}

	[Obsolete("Deprecated. Use the Export method instead.")]
	public static void ExportText(Mesh mesh, Matrix4x4 matrix, string filePath)
	{
		bool asASCII = true;
		Export(mesh, filePath, asASCII);
	}

	[Obsolete("Deprecated. Use the Export method instead.")]
	public static void ExportText(Mesh[] meshes, Matrix4x4[] matrices, string filePath)
	{
		bool asASCII = true;
		Export(meshes, filePath, asASCII);
	}
}
