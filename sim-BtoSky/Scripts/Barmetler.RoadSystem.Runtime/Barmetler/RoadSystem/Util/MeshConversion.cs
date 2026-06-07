using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Barmetler.RoadSystem.Util
{
	public static class MeshConversion
	{
		[Serializable]
		public struct MeshOrientation : IEquatable<MeshOrientation>
		{
			public enum AxisDirection
			{
				X_POSITIVE = 0,
				X_NEGATIVE = 1,
				Y_POSITIVE = 2,
				Y_NEGATIVE = 3,
				Z_POSITIVE = 4,
				Z_NEGATIVE = 5
			}

			[Tooltip("Which axis represents the forward vector?")]
			public AxisDirection forward;

			[Tooltip("Which axis represents the up vector?")]
			public AxisDirection up;

			[Tooltip("False for left-handed (like in Unity), true for right-handed (like in Blender)")]
			public bool isRightHanded;

			public static readonly Dictionary<string, MeshOrientation> Presets = new Dictionary<string, MeshOrientation>
			{
				["BLENDER"] = new MeshOrientation
				{
					forward = AxisDirection.Y_POSITIVE,
					up = AxisDirection.Z_POSITIVE,
					isRightHanded = false
				},
				["UNITY"] = new MeshOrientation
				{
					forward = AxisDirection.Z_POSITIVE,
					up = AxisDirection.Y_POSITIVE,
					isRightHanded = false
				}
			};

			private static readonly Dictionary<MeshOrientation, string> PresetNames = new Dictionary<MeshOrientation, string>();

			public string Preset
			{
				get
				{
					if (PresetNames.TryGetValue(this, out var value))
					{
						return value;
					}
					foreach (KeyValuePair<string, MeshOrientation> preset in Presets)
					{
						if (Equals(preset.Value))
						{
							PresetNames[this] = preset.Key;
							return preset.Key;
						}
					}
					return "CUSTOM";
				}
				set
				{
					if (Presets.TryGetValue(value, out var value2))
					{
						this = value2;
						PresetNames[value2] = value;
					}
				}
			}

			public bool Equals(MeshOrientation other)
			{
				if (forward == other.forward && up == other.up)
				{
					return isRightHanded == other.isRightHanded;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is MeshOrientation other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)(((uint)((int)forward * 397) ^ (uint)up) * 397) ^ isRightHanded.GetHashCode();
			}
		}

		public static Mesh CopyMesh(Mesh m)
		{
			Mesh mesh = new Mesh
			{
				vertices = m.vertices.ToArray(),
				uv = m.uv.ToArray(),
				uv2 = m.uv2.ToArray(),
				tangents = m.tangents.ToArray(),
				normals = m.normals.ToArray(),
				colors32 = m.colors32.ToArray()
			};
			int[][] array = new int[m.subMeshCount][];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = m.GetTriangles(i);
			}
			mesh.name = m.name;
			mesh.subMeshCount = m.subMeshCount;
			for (int j = 0; j < array.Length; j++)
			{
				mesh.SetTriangles(array[j], j);
			}
			return mesh;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ToVector(this MeshOrientation.AxisDirection axis)
		{
			return axis switch
			{
				MeshOrientation.AxisDirection.X_POSITIVE => Vector3.right, 
				MeshOrientation.AxisDirection.X_NEGATIVE => -Vector3.right, 
				MeshOrientation.AxisDirection.Y_POSITIVE => Vector3.up, 
				MeshOrientation.AxisDirection.Y_NEGATIVE => -Vector3.up, 
				MeshOrientation.AxisDirection.Z_POSITIVE => Vector3.forward, 
				MeshOrientation.AxisDirection.Z_NEGATIVE => -Vector3.forward, 
				_ => Vector3.zero, 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ToFloat3(this MeshOrientation.AxisDirection axis)
		{
			return axis switch
			{
				MeshOrientation.AxisDirection.X_POSITIVE => math.float3(1f, 0f, 0f), 
				MeshOrientation.AxisDirection.X_NEGATIVE => math.float3(-1f, 0f, 0f), 
				MeshOrientation.AxisDirection.Y_POSITIVE => math.float3(0f, 1f, 0f), 
				MeshOrientation.AxisDirection.Y_NEGATIVE => math.float3(0f, -1f, 0f), 
				MeshOrientation.AxisDirection.Z_POSITIVE => math.float3(0f, 0f, 1f), 
				MeshOrientation.AxisDirection.Z_NEGATIVE => math.float3(0f, 0f, -1f), 
				_ => float3.zero, 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TransformMesh(Mesh mesh, MeshOrientation from)
		{
			TransformMesh(mesh, from, MeshOrientation.Presets["UNITY"]);
		}

		public static void TransformMesh(Mesh mesh, MeshOrientation from, MeshOrientation to)
		{
			Vector3 vector = from.forward.ToVector();
			Vector3 vector2 = from.up.ToVector();
			Vector3 lhs = (from.isRightHanded ? Vector3.Cross(vector, vector2) : Vector3.Cross(vector2, vector));
			Vector3 vector3 = to.forward.ToVector();
			Vector3 vector4 = to.up.ToVector();
			Vector3 vector5 = (to.isRightHanded ? Vector3.Cross(vector3, vector4) : Vector3.Cross(vector4, vector3));
			Vector3[] array = new Vector3[mesh.vertexCount];
			for (int i = 0; i < mesh.vertexCount; i++)
			{
				Vector3 rhs = mesh.vertices[i];
				array[i] = vector5 * Vector3.Dot(lhs, rhs) + vector3 * Vector3.Dot(vector, rhs) + vector4 * Vector3.Dot(vector2, rhs);
			}
			mesh.SetVertices(array);
			for (int j = 0; j < mesh.subMeshCount; j++)
			{
				int[] triangles = mesh.GetTriangles(j);
				int[] array2 = new int[triangles.Length];
				if (from.isRightHanded != to.isRightHanded)
				{
					for (int k = 0; k + 3 <= array2.Length; k += 3)
					{
						array2[k] = triangles[k];
						array2[k + 1] = triangles[k + 2];
						array2[k + 2] = triangles[k + 1];
					}
				}
				mesh.SetTriangles(array2, j);
			}
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
			mesh.RecalculateBounds();
		}
	}
}
