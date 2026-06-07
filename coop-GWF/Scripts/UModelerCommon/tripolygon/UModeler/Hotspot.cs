using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class Hotspot
	{
		public List<Vector2> uvs = new List<Vector2>();

		public bool yUpLock;

		public bool yLeftLock;

		public bool yRightLock;

		public bool yDownLock;

		public bool IsYLock => yUpLock | yLeftLock | yRightLock | yDownLock;

		public void SetRectangle(Vector2 newUV0, Vector2 newUV1)
		{
			uvs.Clear();
			uvs.Add(newUV0);
			uvs.Add(new Vector2(newUV1.x, newUV0.y));
			uvs.Add(newUV1);
			uvs.Add(new Vector2(newUV0.x, newUV1.y));
		}

		public Hotspot Clone()
		{
			List<Vector2> list = new List<Vector2>(uvs);
			return new Hotspot
			{
				uvs = list,
				yUpLock = yUpLock,
				yLeftLock = yLeftLock,
				yRightLock = yRightLock,
				yDownLock = yDownLock
			};
		}

		public void Sort()
		{
			if (uvs.Count != 4)
			{
				return;
			}
			AABB aABB = new AABB();
			aABB.Reset();
			foreach (Vector2 uv in uvs)
			{
				aABB.Add(uv);
			}
			uvs[0] = new Vector2(aABB.min.x, aABB.min.y);
			uvs[1] = new Vector2(aABB.min.x, aABB.max.y);
			uvs[2] = new Vector2(aABB.max.x, aABB.max.y);
			uvs[3] = new Vector2(aABB.max.x, aABB.min.y);
		}

		public void SetPadding(Vector2 padding)
		{
			Vector2 zero = Vector2.zero;
			foreach (Vector2 uv in uvs)
			{
				zero += uv;
			}
			zero /= (float)uvs.Count;
			for (int i = 0; i < uvs.Count; i++)
			{
				Vector2 vector = uvs[i] - zero;
				if (vector.x > 0f)
				{
					vector.x -= padding.x;
					if (vector.x < 0f)
					{
						vector.x = 0f;
					}
				}
				if (vector.x < 0f)
				{
					vector.x += padding.x;
					if (vector.x > 0f)
					{
						vector.x = 0f;
					}
				}
				if (vector.y > 0f)
				{
					vector.y -= padding.y;
					if (vector.y < 0f)
					{
						vector.y = 0f;
					}
				}
				if (vector.y < 0f)
				{
					vector.y += padding.y;
					if (vector.y > 0f)
					{
						vector.y = 0f;
					}
				}
				uvs[i] = vector + zero;
			}
		}

		public void Rotation()
		{
			if (uvs.Count > 0)
			{
				Vector2 item = uvs[0];
				uvs.RemoveAt(0);
				uvs.Add(item);
				bool flag = yUpLock;
				yUpLock = yRightLock;
				yRightLock = yDownLock;
				yDownLock = yLeftLock;
				yLeftLock = flag;
			}
		}

		public void Trans(float[] transMatrix)
		{
			if (transMatrix.Length == 4)
			{
				Vector2 pivotPos = GetPivotPos();
				for (int i = 0; i < uvs.Count; i++)
				{
					Vector2 vector = uvs[i] - pivotPos;
					Vector2 zero = Vector2.zero;
					zero.x = vector.x * transMatrix[0] + vector.y * transMatrix[1];
					zero.y = vector.x * transMatrix[2] + vector.y * transMatrix[3];
					uvs[i] = zero + pivotPos;
				}
			}
		}

		public void Reverse()
		{
			if (uvs.Count > 0)
			{
				uvs.Reverse();
			}
		}

		public float[] GetAngles()
		{
			float[] array = new float[uvs.Count];
			int index = uvs.Count - 1;
			for (int i = 0; i < uvs.Count; i++)
			{
				int index2 = (i + 1) % uvs.Count;
				array[i] = Vector2.Angle(uvs[index] - uvs[i], uvs[index2] - uvs[i]);
				index = i;
			}
			return array;
		}

		public AABB GetAABB()
		{
			AABB aABB = new AABB();
			aABB.Reset();
			foreach (Vector2 uv in uvs)
			{
				aABB.Add(uv);
			}
			return aABB;
		}

		public Vector2 GetPivotPos()
		{
			return GetAABB().GetCenter();
		}

		public float[] GetLengths()
		{
			float[] array = new float[uvs.Count];
			for (int i = 0; i < uvs.Count; i++)
			{
				int index = (i + 1) % uvs.Count;
				array[i] = Vector2.Distance(uvs[index], uvs[i]);
			}
			return array;
		}

		public bool Raycast(Vector2 rayOrigin)
		{
			float dist = 0f;
			if (uvs.Count == 3)
			{
				if (MathUtil.Raycast(new Ray(rayOrigin, Vector3.forward), uvs[0], uvs[1], uvs[2], out dist))
				{
					return true;
				}
			}
			else if (uvs.Count == 4 && MathUtil.Raycast(new Ray(rayOrigin, Vector3.forward), new Vector3[4]
			{
				uvs[0],
				uvs[1],
				uvs[2],
				uvs[3]
			}, out dist))
			{
				return true;
			}
			return false;
		}
	}
}
