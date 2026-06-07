using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	[RequireComponent(typeof(MeshFilter))]
	public class PropellerMeshTwister : MonoBehaviour
	{
		public enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private static readonly List<Vector3> NormalsBuffer = new List<Vector3>(2048);

		private static readonly List<Vector4> TangentsBuffer = new List<Vector4>(2048);

		private static readonly List<int> TrianglesBuffer = new List<int>(2048);

		private static readonly List<Vector3> VerticesBuffer = new List<Vector3>(2048);

		private Mesh _clonedMesh;

		private Mesh _sourceMesh;

		public void ApplyTwist(float startTwist, float endTwist = 0f, Axis bladeLengthAxis = Axis.X, bool flipped = false)
		{
			if (!TryGetComponent<MeshFilter>(out var component))
			{
				return;
			}
			if (_sourceMesh == null)
			{
				if (!(component.sharedMesh != null) || component.sharedMesh.name.StartsWith("TwistedInstance"))
				{
					return;
				}
				_sourceMesh = component.sharedMesh;
			}
			if (_clonedMesh != null)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(_clonedMesh);
				}
				else
				{
					Object.DestroyImmediate(_clonedMesh);
				}
			}
			_clonedMesh = Object.Instantiate(_sourceMesh);
			_clonedMesh.name = "TwistedInstance";
			_clonedMesh.hideFlags = HideFlags.DontSave;
			_sourceMesh.GetVertices(VerticesBuffer);
			_sourceMesh.GetNormals(NormalsBuffer);
			_sourceMesh.GetTangents(TangentsBuffer);
			int count = VerticesBuffer.Count;
			Bounds bounds = _sourceMesh.bounds;
			float num = 0f;
			float num2 = 0f;
			switch (bladeLengthAxis)
			{
			case Axis.X:
				num = bounds.min.x;
				num2 = bounds.max.x;
				break;
			case Axis.Y:
				num = bounds.min.y;
				num2 = bounds.max.y;
				break;
			case Axis.Z:
				num = bounds.min.z;
				num2 = bounds.max.z;
				break;
			}
			float num3 = num2 - num;
			if (num3 <= 0.0001f)
			{
				num3 = 1f;
			}
			float num4 = 1f / num3;
			for (int i = 0; i < count; i++)
			{
				Vector3 vector = VerticesBuffer[i];
				Vector3 vector2 = NormalsBuffer[i];
				Vector4 vector3 = TangentsBuffer[i];
				float num5 = 0f;
				switch (bladeLengthAxis)
				{
				case Axis.X:
					num5 = vector.x;
					break;
				case Axis.Y:
					num5 = vector.y;
					break;
				case Axis.Z:
					num5 = vector.z;
					break;
				}
				float t = Mathf.Clamp01((num5 - num) * num4);
				if (flipped)
				{
					vector.z *= -1f;
					vector2.z *= -1f;
					vector3.z *= -1f;
					vector3.w *= -1f;
				}
				float angle = Mathf.Lerp(startTwist, endTwist, t);
				Quaternion quaternion = bladeLengthAxis switch
				{
					Axis.X => Quaternion.AngleAxis(angle, Vector3.right), 
					Axis.Y => Quaternion.AngleAxis(angle, Vector3.up), 
					_ => Quaternion.AngleAxis(angle, Vector3.forward), 
				};
				VerticesBuffer[i] = quaternion * vector;
				NormalsBuffer[i] = quaternion * vector2;
				Vector3 vector4 = quaternion * new Vector3(vector3.x, vector3.y, vector3.z);
				TangentsBuffer[i] = new Vector4(vector4.x, vector4.y, vector4.z, vector3.w);
			}
			_clonedMesh.SetVertices(VerticesBuffer);
			_clonedMesh.SetNormals(NormalsBuffer);
			_clonedMesh.SetTangents(TangentsBuffer);
			if (flipped)
			{
				int subMeshCount = _clonedMesh.subMeshCount;
				for (int j = 0; j < subMeshCount; j++)
				{
					_clonedMesh.GetTriangles(TrianglesBuffer, j);
					int count2 = TrianglesBuffer.Count;
					for (int k = 0; k < count2; k += 3)
					{
						int value = TrianglesBuffer[k];
						TrianglesBuffer[k] = TrianglesBuffer[k + 1];
						TrianglesBuffer[k + 1] = value;
					}
					_clonedMesh.SetTriangles(TrianglesBuffer, j);
				}
			}
			_clonedMesh.RecalculateBounds();
			_clonedMesh.MarkDynamic();
			component.sharedMesh = _clonedMesh;
		}

		protected void OnDestroy()
		{
			if (_clonedMesh != null)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(_clonedMesh);
				}
				else
				{
					Object.DestroyImmediate(_clonedMesh);
				}
			}
		}
	}
}
