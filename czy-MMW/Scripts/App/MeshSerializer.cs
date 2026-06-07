using Factory;
using UnityEngine;

public class MeshSerializer : PrimitiveSerializer
{
	public override bool Serialize(object obj, ExportContext context)
	{
		Mesh mesh = obj as Mesh;
		if (mesh == null)
		{
			context.Writer.Write(0);
			context.Writer.Write(0);
			return obj == null;
		}
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		Vector2[] uv = mesh.uv;
		Color[] colors = mesh.colors;
		int value = vertices.Length;
		if (!Diagnostics.Verify(vertices.Length == normals.Length && vertices.Length == uv.Length, "Expected mesh to have the same number of vertices, normals, and uvs."))
		{
			context.Writer.Write(0);
			context.Writer.Write(0);
			return false;
		}
		context.Writer.Write(value);
		Vector3[] array = vertices;
		for (int i = 0; i < array.Length; i++)
		{
			Vector3 vector = array[i];
			context.Writer.Write(vector.x);
			context.Writer.Write(vector.y);
		}
		array = normals;
		for (int i = 0; i < array.Length; i++)
		{
			Vector3 vector2 = array[i];
			context.Writer.Write(vector2.x);
			context.Writer.Write(vector2.y);
		}
		Vector2[] array2 = uv;
		for (int i = 0; i < array2.Length; i++)
		{
			Vector2 vector3 = array2[i];
			context.Writer.Write(vector3.x);
			context.Writer.Write(vector3.y);
		}
		Color[] array3 = colors;
		for (int i = 0; i < array3.Length; i++)
		{
			Color color = array3[i];
			context.Writer.Write(color.a);
		}
		int[] triangles = mesh.triangles;
		int value2 = triangles.Length;
		context.Writer.Write(value2);
		int[] array4 = triangles;
		foreach (int value3 in array4)
		{
			context.Writer.Write(value3);
		}
		return true;
	}

	public override object Deserialize(object existingObj, ImportContext context)
	{
		int num = context.Reader.ReadInt32();
		Vector3[] array = null;
		Vector3[] array2 = null;
		Vector2[] array3 = null;
		Color[] array4 = null;
		if (num > 0)
		{
			array = new Vector3[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new Vector3(context.Reader.ReadSingle(), context.Reader.ReadSingle(), 0f);
			}
			array2 = new Vector3[num];
			for (int j = 0; j < num; j++)
			{
				array2[j] = new Vector3(context.Reader.ReadSingle(), context.Reader.ReadSingle(), 0f);
			}
			array3 = new Vector2[num];
			for (int k = 0; k < num; k++)
			{
				array3[k] = new Vector2(context.Reader.ReadSingle(), context.Reader.ReadSingle());
			}
			array4 = new Color[num];
			for (int l = 0; l < num; l++)
			{
				array4[l] = new Color(1f, 1f, 1f, context.Reader.ReadSingle());
			}
		}
		int num2 = context.Reader.ReadInt32();
		int[] array5 = null;
		if (num2 > 0)
		{
			array5 = new int[num2];
			for (int m = 0; m < num2; m++)
			{
				array5[m] = context.Reader.ReadInt32();
			}
		}
		if (num > 0 && num2 > 0)
		{
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.uv = array3;
			mesh.normals = array2;
			mesh.colors = array4;
			mesh.subMeshCount = 1;
			mesh.SetTriangles(array5, 0);
			return mesh;
		}
		return null;
	}
}
