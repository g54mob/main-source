using UnityEngine;
using UnityEngine.Rendering;

public class SpriteLights : MonoBehaviour
{
	public struct LightData
	{
		public Vector3 position;

		public Quaternion rotation;

		public float size;

		public float brightness;

		public Color frontColor;

		public Color backColor;

		public float strobeID;

		public float strobeGroupID;
	}

	private static int maxTriangls32 = 1431655765;

	private static int maxTriangls16 = 21844;

	private float DistanceAndDiameterToPixelSize(float distance, float diameter)
	{
		return diameter * 57.29578f * (float)Screen.height / (distance * Camera.main.fieldOfView);
	}

	private float PixelSizeAndDiameterToDistance(float pixelSize, float diameter)
	{
		return diameter * 57.29578f * (float)Screen.height / (pixelSize * Camera.main.fieldOfView);
	}

	private float PixelSizeAndDistanceToDiameter(float pixelSize, float distance)
	{
		return pixelSize * distance * Camera.main.fieldOfView / (57.29578f * (float)Screen.height);
	}

	public static float GetScaleFactor(float FOV, float screenHeight)
	{
		return FOV / (57.29578f * screenHeight);
	}

	public static void Init(float strobeTimeStep, float globalBrightnessOffset, float FOV, float screenHeight)
	{
		float scaleFactor = GetScaleFactor(FOV, screenHeight);
		Shader.SetGlobalFloat("_StrobeTimeStep", strobeTimeStep);
		Shader.SetGlobalFloat("_ScaleFactor", scaleFactor);
		Shader.SetGlobalFloat("_GlobalBrightnessOffset", globalBrightnessOffset);
	}

	public static GameObject[] CreateLights(string name, Vector3[] positions, float size, Material material, IndexFormat meshIndexFormat, Transform origin)
	{
		return CreateLightsAll(name, null, positions, size, material, meshIndexFormat, origin);
	}

	public static GameObject[] CreateLights(string name, LightData[] lightData, Material material, IndexFormat meshIndexFormat, Transform origin)
	{
		return CreateLightsAll(name, lightData, null, 0f, material, meshIndexFormat, origin);
	}

	private static GameObject[] CreateLightsAll(string name, LightData[] lightData, Vector3[] positions, float simpleShaderLightSize, Material material, IndexFormat meshIndexFormat, Transform origin)
	{
		int num = 0;
		num = ((lightData == null) ? positions.Length : lightData.Length);
		int num2 = ((meshIndexFormat != IndexFormat.UInt32) ? maxTriangls16 : maxTriangls32);
		int num3 = (int)Mathf.Ceil((float)num / (float)num2);
		GameObject[] array = new GameObject[num3];
		int num4 = (int)((float)num % (float)num2);
		for (int i = 0; i < num3; i++)
		{
			int num5 = ((num3 == 1) ? num : ((i != num3 - 1) ? num2 : ((num4 != 0) ? num4 : num2)));
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			int num6 = num5 * 3;
			Matrix4x4 matrix4x = ((origin != null) ? origin.worldToLocalMatrix : Matrix4x4.identity);
			Vector4[] array2 = new Vector4[num6];
			Vector2[] array3 = new Vector2[num6];
			Vector4[] array4 = new Vector4[3];
			Vector2[] array5 = new Vector2[3];
			Vector3[] array6 = null;
			Vector3 one = Vector3.one;
			Vector3 one2 = Vector3.one;
			Vector3 vector = Vector3.one;
			Vector3[] array7 = new Vector3[num6];
			int[] array8 = new int[num6];
			int[] array9 = new int[num6];
			Vector2[] array10 = null;
			Vector2[] array11 = null;
			Vector2[] array12 = null;
			Color[] array13 = null;
			Vector4 vector2 = Vector4.zero;
			Vector4 vector3 = Vector4.zero;
			Vector4 vector4 = Vector4.zero;
			array4[0] = new Vector4(-1.07735f, 0.5f, 0f, 1f);
			array4[1] = new Vector4(1.07735f, 0.5f, 0f, 1f);
			array4[2] = new Vector4(0f, -1.366025f, 0f, 1f);
			array5[0].x = -0.57735f;
			array5[0].y = 0f;
			array5[1].x = 1.57735f;
			array5[1].y = 0f;
			array5[2].x = 0.5f;
			array5[2].y = 1.866025f;
			if (lightData != null)
			{
				array6 = new Vector3[num6];
				array10 = new Vector2[num6];
				array11 = new Vector2[num6];
				array12 = new Vector2[num6];
				array13 = new Color[num6];
				if (material.shader.name.Contains("Directional"))
				{
					flag = true;
				}
				if (material.shader.name.Contains("Omnidirectional"))
				{
					flag2 = true;
				}
				if (material.shader.name.Contains("Strobe"))
				{
					flag3 = true;
				}
				if (material.shader.name.Contains("PAPI"))
				{
					flag4 = true;
				}
			}
			else
			{
				flag5 = true;
				vector2 = new Vector4(array4[0].x, array4[0].y, array4[0].z, simpleShaderLightSize);
				vector3 = new Vector4(array4[1].x, array4[1].y, array4[1].z, simpleShaderLightSize);
				vector4 = new Vector4(array4[2].x, array4[2].y, array4[2].z, simpleShaderLightSize);
			}
			for (int j = 0; j < num5; j++)
			{
				float num7 = 0f;
				int num8 = j * 3;
				int num9 = num8 + 1;
				int num10 = num8 + 2;
				int num11 = i * num2 + j;
				if (lightData != null)
				{
					num7 = lightData[num11].size;
					array7[num10] = (array7[num9] = (array7[num8] = matrix4x.MultiplyPoint(lightData[num11].position)));
					array2[num8] = new Vector4(array4[0].x, array4[0].y, array4[0].z, num7);
					array2[num9] = new Vector4(array4[1].x, array4[1].y, array4[1].z, num7);
					array2[num10] = new Vector4(array4[2].x, array4[2].y, array4[2].z, num7);
				}
				else
				{
					num7 = simpleShaderLightSize;
					array7[num10] = (array7[num9] = (array7[num8] = matrix4x.MultiplyPoint(positions[num11])));
					array2[num8] = vector2;
					array2[num9] = vector3;
					array2[num10] = vector4;
				}
				array3[num8] = array5[0];
				array3[num9] = array5[1];
				array3[num10] = array5[2];
				if (lightData != null)
				{
					if (flag4 || flag2)
					{
						vector = Math3d.GetUpVector(lightData[num11].rotation);
					}
					if (!flag5)
					{
						array6[num10] = (array6[num9] = (array6[num8] = -Math3d.GetForwardVector(lightData[num11].rotation)));
					}
					if (flag4)
					{
						one2 = Math3d.GetRightVector(lightData[num11].rotation);
						array10[num8] = one2;
						array10[num9] = one2;
						array10[num10] = one2;
						array11[num8] = vector;
						array11[num9] = vector;
						array11[num10] = vector;
						array12[num10] = (array12[num9] = (array12[num8] = new Vector2(one2.z, vector.z)));
					}
					if (flag)
					{
						Vector2 vector5 = new Vector2(lightData[num11].backColor.r, lightData[num11].backColor.g);
						Vector2 vector6 = new Vector2(lightData[num11].backColor.b, lightData[num11].backColor.a);
						array10[num8] = vector5;
						array10[num9] = vector5;
						array10[num10] = vector5;
						array11[num8] = vector6;
						array11[num9] = vector6;
						array11[num10] = vector6;
					}
					if (flag2)
					{
						array10[num10] = (array10[num9] = (array10[num8] = new Vector2(lightData[num11].backColor.r, lightData[num11].backColor.g)));
						array11[num8] = vector;
						array11[num9] = vector;
						array11[num10] = vector;
						array12[num10] = (array12[num9] = (array12[num8] = new Vector2(lightData[num11].backColor.b, vector.z)));
					}
					if (flag3)
					{
						array13[num10] = (array13[num9] = (array13[num8] = new Color(lightData[num11].strobeID, lightData[num11].strobeGroupID, 0f, 0f)));
					}
					if (flag || flag2)
					{
						array13[num10] = (array13[num9] = (array13[num8] = new Color(lightData[num11].frontColor.r, lightData[num11].frontColor.g, lightData[num11].frontColor.b, lightData[num11].brightness)));
					}
				}
				array8[num8] = num8;
				array8[num9] = num9;
				array8[num10] = num10;
				array9[num8] = num8;
				array9[num9] = num9;
				array9[num10] = num10;
			}
			GameObject gameObject = (array[i] = new GameObject(name + " " + i));
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshFilter.sharedMesh = new Mesh();
			meshFilter.sharedMesh.name = gameObject.name;
			meshFilter.sharedMesh.indexFormat = meshIndexFormat;
			meshFilter.sharedMesh.vertices = array7;
			meshFilter.sharedMesh.tangents = array2;
			meshFilter.sharedMesh.uv = array3;
			meshFilter.sharedMesh.triangles = array8;
			if (!flag5)
			{
				meshFilter.sharedMesh.normals = array6;
				meshFilter.sharedMesh.colors = array13;
				meshFilter.sharedMesh.uv2 = array10;
				meshFilter.sharedMesh.uv3 = array11;
				meshFilter.sharedMesh.uv4 = array12;
			}
			meshFilter.sharedMesh.SetIndices(array9, MeshTopology.Triangles, 0);
			meshRenderer.sharedMaterial = material;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
			meshRenderer.receiveShadows = false;
			meshRenderer.lightProbeUsage = LightProbeUsage.Off;
			meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		}
		return array;
	}

	private static Vector4[] Vector3ToVector4(Vector3[] input)
	{
		Vector4[] array = new Vector4[input.Length];
		for (int i = 0; i < input.Length; i++)
		{
			array[i] = new Vector4(input[i].x, input[i].y, input[i].z, 1f);
		}
		return array;
	}

	private static void GenerateTriangle(out Vector4[] points, out Vector2[] uvs, float size, Quaternion rotation)
	{
		uvs = new Vector2[3];
		float num = 1.07735f;
		float y = -1.366025f;
		Vector3[] array = new Vector3[3]
		{
			new Vector3(0f - num, 0.5f) * size,
			new Vector3(num, 0.5f) * size,
			new Vector3(0f, y) * size
		};
		for (int i = 0; i < 3; i++)
		{
			float x = Math3d.NormalizeComplex(array[i].x / size, -0.5f, 0.5f);
			float y2 = Math3d.NormalizeComplex(array[i].y / size, -0.5f, 0.5f);
			uvs[i] = new Vector2(x, y2);
		}
		for (int j = 0; j < 3; j++)
		{
			array[j] = rotation * array[j];
		}
		points = Vector3ToVector4(array);
	}

	private static void GenerateTriangle(out Vector4[] points, out Vector2[] uvs)
	{
		uvs = new Vector2[3];
		float num = 1.07735f;
		float y = -1.366025f;
		Vector3[] input = new Vector3[3]
		{
			new Vector3(0f - num, 0.5f),
			new Vector3(num, 0.5f),
			new Vector3(0f, y)
		};
		uvs[0].x = -0.57735f;
		uvs[0].y = 0f;
		uvs[1].x = 1.57735f;
		uvs[1].y = 0f;
		uvs[2].x = 0.5f;
		uvs[2].y = 1.866025f;
		points = Vector3ToVector4(input);
	}
}
