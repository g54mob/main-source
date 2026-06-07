using System;
using UnityEngine;

namespace AutoTiling
{
	[Serializable]
	public class FaceData
	{
		public Vector2 uvScale = Vector2.one;

		public Vector2 uvOffset = Vector2.zero;

		public float rotation;

		public bool flipUVx;

		public bool flipUVy;

		public int materialIndex;

		[HideInInspector]
		[SerializeField]
		private int[] triangles;

		[HideInInspector]
		[SerializeField]
		public Vector3[] normals;

		[HideInInspector]
		[SerializeField]
		private Vector3 averageNormal;

		[HideInInspector]
		[SerializeField]
		private bool initialized;

		public Vector3 AverageNormal => averageNormal;

		public bool Initialized => initialized;

		public int[] Triangles => triangles;

		public FaceData()
		{
			triangles = new int[0];
			normals = new Vector3[0];
		}

		public void Initialize()
		{
			initialized = true;
		}

		public void Initialize(FaceData dataForCopyingSettings)
		{
			CopySettingsFrom(dataForCopyingSettings);
			initialized = true;
		}

		public void CopySettingsFrom(FaceData dataForCopyingSettings)
		{
			uvScale = dataForCopyingSettings.uvScale;
			uvOffset = dataForCopyingSettings.uvOffset;
			rotation = dataForCopyingSettings.rotation;
			flipUVx = dataForCopyingSettings.flipUVx;
			flipUVy = dataForCopyingSettings.flipUVy;
			materialIndex = dataForCopyingSettings.materialIndex;
		}

		public void AddTriangle(int[] triangleVertexIndices, Vector3 normal)
		{
			if (triangleVertexIndices == null)
			{
				Debug.LogError(string.Concat(GetType(), ".AddTriangle: triangleVertexIndices was null."));
				return;
			}
			if (triangleVertexIndices.Length != 3)
			{
				Debug.LogError(string.Concat(GetType(), ".AddTriangle: triangle vertex index array has to have exactly 3 entries."));
				return;
			}
			for (int i = 0; i < triangles.Length; i += 3)
			{
				int num = 0;
				for (int j = 0; j < 3; j++)
				{
					if (triangles[i + j] == triangleVertexIndices[j])
					{
						num++;
					}
				}
				if (num == 3)
				{
					Debug.LogWarning(string.Concat(GetType(), ".AddTriangle: triangle ", triangleVertexIndices[0], "|", triangleVertexIndices[1], "|", triangleVertexIndices[2], " already existed. Check your meshData."));
					return;
				}
			}
			int[] array = new int[triangles.Length + triangleVertexIndices.Length];
			for (int k = 0; k < triangles.Length; k++)
			{
				array[k] = triangles[k];
			}
			for (int l = 0; l < triangleVertexIndices.Length; l++)
			{
				array[triangles.Length + l] = triangleVertexIndices[l];
			}
			triangles = array;
			Vector3[] array2 = new Vector3[normals.Length + 1];
			averageNormal = Vector3.zero;
			for (int m = 0; m < normals.Length; m++)
			{
				array2[m] = normals[m];
				averageNormal += normals[m];
			}
			array2[normals.Length] = normal;
			averageNormal += normal;
			averageNormal /= (float)array2.Length;
			normals = array2;
		}

		public bool IsWithinNormalAngleRange(Vector3 triangleNormal, float faceUnwrappingNormalTolerance)
		{
			return Vector3.Angle(triangleNormal, averageNormal) <= faceUnwrappingNormalTolerance;
		}

		public void SetTriangles(int[] newFaceTriangleIndices)
		{
			if (newFaceTriangleIndices == null)
			{
				Debug.LogError(string.Concat(GetType(), ".SetTriangles: triangle index array can't be null."));
			}
			else if (newFaceTriangleIndices.Length % 3 != 0)
			{
				Debug.LogError(string.Concat(GetType(), ".SetTriangles: triangle index array has to have a length devisable by 3. Array length: ", newFaceTriangleIndices.Length));
			}
			else
			{
				triangles = newFaceTriangleIndices;
			}
		}

		public string TrianglesToString()
		{
			string text = "";
			for (int i = 0; i < triangles.Length; i++)
			{
				text += triangles[i];
				if (i < triangles.Length - 1)
				{
					text += ", ";
				}
			}
			return text;
		}
	}
}
