using UnityEngine;

public class Sectioner : MonoBehaviour
{
	private static uint globalMeshId = 1u;

	private static Vector2 HashNorm(Vector3 norm, uint meshId)
	{
		int num = 2048;
		uint num2 = (uint)((double)num * (double)Util.LerpScale(norm.x, -1f, 1f, 0f, 1f));
		uint num3 = (uint)((double)num * (double)Util.LerpScale(norm.y, -1f, 1f, 0f, 1f));
		uint num4 = (uint)((double)num * (double)Util.LerpScale(norm.z, -1f, 1f, 0f, 1f));
		uint num5 = (num2 * 73856093) ^ (num3 * 19349663) ^ (num4 * 71371371) ^ (meshId * 83492791);
		float x = (float)((double)(num5 & 0xFFFF) / 65535.0);
		float y = (float)((double)((num5 >> 16) & 0xFFFF) / 65535.0);
		return new Vector2(x, y);
	}

	public static void SectionMesh(Mesh mesh, int forceMeshId = 0)
	{
		Vector3[] normals = mesh.normals;
		Color[] array = mesh.colors;
		if (array == null || array.Length != normals.Length)
		{
			array = new Color[normals.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Color(1f, 1f, 1f, 1f);
			}
		}
		uint num = 0u;
		if (forceMeshId != 0)
		{
			num = (uint)forceMeshId;
		}
		else
		{
			ulong num2 = (ulong)mesh.GetInstanceID() * 13uL;
			num2 += (ulong)(1775983L * (long)globalMeshId++);
			num = (uint)(num2 & 0xFFFFFFFFu);
		}
		for (int j = 0; j < normals.Length; j++)
		{
			Color color = array[j];
			Vector2 vector;
			if (Mathf.Abs(color.r - color.g) < 0.001f && Mathf.Abs(color.r - color.b) < 0.001f)
			{
				uint num3 = (uint)(color.r * 4.2949673E+09f);
				vector = HashNorm(normals[j], num ^ num3);
			}
			else
			{
				vector = HashNorm(new Vector3(color.r * 2f - 1f, color.g * 2f - 1f, color.b * 2f - 1f), num);
			}
			array[j].r = vector.x;
			array[j].b = vector.y;
		}
		mesh.colors = array;
	}
}
