using System;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

namespace Deform
{
	public class ObjExporter
	{
		public static void SaveMesh(Mesh mesh, Renderer renderer, string fullFolderPath, string name)
		{
			string path = Path.Combine(Application.dataPath, fullFolderPath) + name + ".obj";
			MeshToFile(mesh, renderer, path, name);
		}

		private static void MeshToFile(Mesh mesh, Renderer renderer, string path, string name)
		{
			using StreamWriter streamWriter = new StreamWriter(path);
			streamWriter.Write(MeshToString(mesh, renderer, name));
		}

		private static string MeshToString(Mesh mesh, Renderer renderer, string name)
		{
			if (renderer == null)
			{
				throw new NullReferenceException("Renderer cannot be null to convert mesh to string.");
			}
			Material[] sharedMaterials = renderer.sharedMaterials;
			StringBuilder stringBuilder = new StringBuilder();
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			stringBuilder.Append("g ").Append(name).Append("\n");
			Vector3[] vertices = mesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector = vertices[i];
				stringBuilder.AppendFormat(invariantCulture, "v {0} {1} {2}\n", 0f - vector.x, vector.y, vector.z);
			}
			stringBuilder.Append("\n");
			vertices = mesh.normals;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector2 = vertices[i];
				stringBuilder.AppendFormat(invariantCulture, "vn {0} {1} {2}\n", 0f - vector2.x, vector2.y, vector2.z);
			}
			stringBuilder.Append("\n");
			Vector2[] uv = mesh.uv;
			for (int i = 0; i < uv.Length; i++)
			{
				Vector2 vector3 = uv[i];
				stringBuilder.AppendFormat(invariantCulture, "vt {0} {1}\n", vector3.x, vector3.y);
			}
			for (int j = 0; j < mesh.subMeshCount; j++)
			{
				stringBuilder.Append("\n");
				string value = ((sharedMaterials != null && j < sharedMaterials.Length) ? sharedMaterials[j].name : "Material");
				stringBuilder.Append("usemtl ").Append(value).Append("\n");
				stringBuilder.Append("usemap ").Append(value).Append("\n");
				int[] triangles = mesh.GetTriangles(j);
				for (int k = 0; k < triangles.Length; k += 3)
				{
					stringBuilder.AppendFormat(invariantCulture, "f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n", triangles[k + 2] + 1, triangles[k + 1] + 1, triangles[k] + 1);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
