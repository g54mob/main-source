using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

public class ObjExporterScript
{
	private static int StartIndex;

	public static void Start()
	{
		StartIndex = 0;
	}

	public static void End()
	{
		StartIndex = 0;
	}

	public static string ObjectsToString(IList<MeshFilter> meshes, Vector3 offset)
	{
		StringBuilder stringBuilder = new StringBuilder();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (MeshFilter mesh in meshes)
		{
			string text = mesh.name;
			int num = 1;
			while (!hashSet.Add(text))
			{
				text = mesh.name + num;
				num++;
			}
			stringBuilder.Append("g ").Append(text).Append("\n");
			stringBuilder.Append(MeshToString(mesh.sharedMesh, new string[1] { mesh.name }, Matrix4x4.Translate(offset) * mesh.transform.localToWorldMatrix, mesh.transform.rotation));
		}
		return stringBuilder.ToString();
	}

	public static string MeshToString(Mesh m, string[] mats, Matrix4x4 t, Quaternion r)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		int num = 0;
		if (!m)
		{
			return "####Error####";
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < m.vertices.Length; i++)
		{
			Vector3 point = m.vertices[i];
			Vector3 vector = t.MultiplyPoint(point);
			num++;
			stringBuilder.Append(string.Format("v {0} {1} {2} \n", vector.x.ToString(invariantCulture), vector.y.ToString(invariantCulture), vector.z.ToString(invariantCulture)));
		}
		stringBuilder.Append("\n");
		Vector3[] normals = m.normals;
		foreach (Vector3 vector2 in normals)
		{
			Vector3 vector3 = r * vector2;
			stringBuilder.Append(string.Format("vn {0} {1} {2}\n", vector3.x.ToString(invariantCulture), vector3.y.ToString(invariantCulture), vector3.z.ToString(invariantCulture)));
		}
		stringBuilder.Append("\n");
		Vector2[] uv = m.uv;
		for (int j = 0; j < uv.Length; j++)
		{
			Vector2 vector4 = uv[j];
			float x = vector4.x;
			string arg = x.ToString(invariantCulture);
			x = vector4.y;
			stringBuilder.Append(string.Format("vt {0} {1}\n", arg, x.ToString(invariantCulture)));
		}
		for (int k = 0; k < m.subMeshCount; k++)
		{
			stringBuilder.Append("\n");
			if (mats != null)
			{
				stringBuilder.Append("usemtl ").Append(mats[k]).Append("\n");
				stringBuilder.Append("usemap ").Append(mats[k]).Append("\n");
			}
			int[] triangles = m.GetTriangles(k);
			for (int l = 0; l < triangles.Length; l += 3)
			{
				stringBuilder.Append(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n", triangles[l] + 1 + StartIndex, triangles[l + 1] + 1 + StartIndex, triangles[l + 2] + 1 + StartIndex));
			}
		}
		StartIndex += num;
		return stringBuilder.ToString();
	}
}
