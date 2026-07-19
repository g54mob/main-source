using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniGLTF
{
	public static class UnityExtensions
	{
		public static Vector4 ReverseZ(this Vector4 v)
		{
			return new Vector4(v.x, v.y, 0f - v.z, v.w);
		}

		public static Vector3 ReverseZ(this Vector3 v)
		{
			return new Vector3(v.x, v.y, 0f - v.z);
		}

		[Obsolete]
		public static Vector2 ReverseY(this Vector2 v)
		{
			return new Vector2(v.x, 0f - v.y);
		}

		public static Vector2 ReverseUV(this Vector2 v)
		{
			return new Vector2(v.x, 1f - v.y);
		}

		public static Quaternion ReverseZ(this Quaternion q)
		{
			q.ToAngleAxis(out var angle, out var axis);
			return Quaternion.AngleAxis(0f - angle, axis.ReverseZ());
		}

		public static Matrix4x4 Matrix4x4FromColumns(Vector4 c0, Vector4 c1, Vector4 c2, Vector4 c3)
		{
			return new Matrix4x4(c0, c1, c2, c3);
		}

		public static Matrix4x4 Matrix4x4FromRotation(Quaternion q)
		{
			return Matrix4x4.Rotate(q);
		}

		public static Matrix4x4 ReverseZ(this Matrix4x4 m)
		{
			m.SetTRS(m.ExtractPosition().ReverseZ(), m.ExtractRotation().ReverseZ(), m.ExtractScale());
			return m;
		}

		public static Matrix4x4 MatrixFromArray(float[] values)
		{
			return new Matrix4x4
			{
				m00 = values[0],
				m10 = values[1],
				m20 = values[2],
				m30 = values[3],
				m01 = values[4],
				m11 = values[5],
				m21 = values[6],
				m31 = values[7],
				m02 = values[8],
				m12 = values[9],
				m22 = values[10],
				m32 = values[11],
				m03 = values[12],
				m13 = values[13],
				m23 = values[14],
				m33 = values[15]
			};
		}

		public static Quaternion ExtractRotation(this Matrix4x4 matrix)
		{
			Vector3 forward = default(Vector3);
			forward.x = matrix.m02;
			forward.y = matrix.m12;
			forward.z = matrix.m22;
			Vector3 upwards = default(Vector3);
			upwards.x = matrix.m01;
			upwards.y = matrix.m11;
			upwards.z = matrix.m21;
			return Quaternion.LookRotation(forward, upwards);
		}

		public static Vector3 ExtractPosition(this Matrix4x4 matrix)
		{
			Vector3 result = default(Vector3);
			result.x = matrix.m03;
			result.y = matrix.m13;
			result.z = matrix.m23;
			return result;
		}

		public static Vector3 ExtractScale(this Matrix4x4 matrix)
		{
			Vector3 result = default(Vector3);
			result.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
			result.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
			result.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
			return result;
		}

		public static string RelativePathFrom(this Transform self, Transform root)
		{
			List<string> list = new List<string>();
			Transform transform = self;
			while (transform != null)
			{
				if (transform == root)
				{
					return string.Join("/", list.ToArray());
				}
				list.Insert(0, transform.name);
				transform = transform.parent;
			}
			throw new Exception("no RelativePath");
		}

		public static Transform GetChildByName(this Transform self, string childName)
		{
			foreach (Transform item in self)
			{
				if (item.name == childName)
				{
					return item;
				}
			}
			throw new KeyNotFoundException();
		}

		public static Transform GetFromPath(this Transform self, string path)
		{
			Transform transform = self;
			string[] array = path.Split('/');
			foreach (string childName in array)
			{
				transform = transform.GetChildByName(childName);
			}
			return transform;
		}

		public static IEnumerable<Transform> GetChildren(this Transform self)
		{
			foreach (Transform item in self)
			{
				yield return item;
			}
		}

		public static IEnumerable<Transform> Traverse(this Transform t)
		{
			yield return t;
			foreach (Transform item in t)
			{
				foreach (Transform item2 in item.Traverse())
				{
					yield return item2;
				}
			}
		}

		[Obsolete("Use FindDescendant(name)")]
		public static Transform FindDescenedant(this Transform t, string name)
		{
			return t.FindDescendant(name);
		}

		public static Transform FindDescendant(this Transform t, string name)
		{
			return t.Traverse().First((Transform x) => x.name == name);
		}

		public static IEnumerable<Transform> Ancestors(this Transform t)
		{
			yield return t;
			if (!(t.parent != null))
			{
				yield break;
			}
			foreach (Transform item in t.parent.Ancestors())
			{
				yield return item;
			}
		}

		public static float[] ToArray(this Quaternion q)
		{
			return new float[4] { q.x, q.y, q.z, q.w };
		}

		public static float[] ToArray(this Vector3 v)
		{
			return new float[3] { v.x, v.y, v.z };
		}

		public static float[] ToArray(this Vector4 v)
		{
			return new float[4] { v.x, v.y, v.z, v.w };
		}

		public static float[] ToArray(this Color c)
		{
			return new float[4] { c.r, c.g, c.b, c.a };
		}

		public static void ReverseZRecursive(this Transform root)
		{
			Dictionary<Transform, PosRot> dictionary = root.Traverse().ToDictionary((Transform x) => x, (Transform x) => PosRot.FromGlobalTransform(x));
			foreach (Transform item in root.Traverse())
			{
				item.position = dictionary[item].Position.ReverseZ();
				item.rotation = dictionary[item].Rotation.ReverseZ();
			}
		}

		public static Mesh GetSharedMesh(this Transform t)
		{
			MeshFilter component = t.GetComponent<MeshFilter>();
			if (component != null)
			{
				return component.sharedMesh;
			}
			SkinnedMeshRenderer component2 = t.GetComponent<SkinnedMeshRenderer>();
			if (component2 != null)
			{
				return component2.sharedMesh;
			}
			return null;
		}

		public static Material[] GetSharedMaterials(this Transform t)
		{
			Renderer component = t.GetComponent<Renderer>();
			if (component != null)
			{
				return component.sharedMaterials;
			}
			return new Material[0];
		}

		public static bool Has<T>(this Transform transform, T t) where T : Component
		{
			return transform.GetComponent<T>() == t;
		}

		public static T GetOrAddComponent<T>(this GameObject go) where T : Component
		{
			T component = go.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			return go.AddComponent<T>();
		}
	}
}
