using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundRoom : MonoBehaviour
{
	public enum WallType
	{
		Solid = 0,
		DirectionalSource = 1,
		DirectionalDestination = 2,
		DirectionalPass = 3,
		DirectionalRoom = 4,
		AmbientSource = 5
	}

	[Serializable]
	public class Wall
	{
		public WallType type;

		public float volume;
	}

	[Serializable]
	public class Filter
	{
		public string soundId;

		[Readonly]
		public int soundIndex;

		public Wall x0;

		public Wall x1;

		public Wall y0;

		public Wall y1;

		public Wall z0;

		public Wall z1;
	}

	public enum WallSide
	{
		X0 = 0,
		X1 = 1,
		Z0 = 2,
		Z1 = 3
	}

	[Serializable]
	public class Door
	{
		public WallSide side;

		public SoundDoor door;
	}

	public class VolPan
	{
		public float vol;

		public float pan;

		public VolPan(float v = 1f, float p = 0f)
		{
			vol = v;
			pan = p;
		}

		public override string ToString()
		{
			return string.Format("{0:0.00}:{1:0.00}", vol, pan);
		}

		public void Zero()
		{
			vol = 0f;
			pan = 0f;
		}
	}

	public class Listener
	{
		public Matrix4x4 matrix;

		public Vector3 pos;

		public Vector2 head;

		public Vector2 earR;

		public void Set(Matrix4x4 matrix_)
		{
			matrix = matrix_;
			pos = matrix.GetColumn(3);
			head = matrix.GetColumn(3).ToVector3().ToVector2XZ();
			earR = matrix.GetColumn(0).ToVector3().ToVector2XZ();
		}
	}

	public bool debugShowInEditor = true;

	public bool deadzone;

	public float volumeScale = 1f;

	public SoundRoom sourceRoom;

	public List<Filter> filters;

	public List<Door> doors;

	[Readonly]
	public Bounds bounds;

	private bool[] doorClosed = new bool[4];

	public static Color normalColor = new Color(1f, 0.5f, 0f, 1f);

	public static Color deadzoneColor = new Color(1f, 0f, 0.5f, 1f);

	public void Apply(Listener listener, List<VolPan> volPans)
	{
		if (deadzone)
		{
			foreach (Filter filter in filters)
			{
				if (filter.soundIndex >= 0 && filter.soundIndex < volPans.Count)
				{
					volPans[filter.soundIndex].Zero();
				}
			}
			return;
		}
		if (doors != null)
		{
			foreach (Door door in doors)
			{
				doorClosed[(int)door.side] = door.door != null && !door.door.IsOpen;
			}
		}
		else
		{
			for (int i = 0; i < doorClosed.Length; i++)
			{
				doorClosed[i] = false;
			}
		}
		foreach (Filter filter2 in filters)
		{
			if (filter2.soundIndex < 0 || filter2.soundIndex >= volPans.Count)
			{
				continue;
			}
			VolPan volPan = volPans[filter2.soundIndex];
			bool flag = filter2.x0.type == WallType.Solid || doorClosed[0];
			bool flag2 = filter2.x1.type == WallType.Solid || doorClosed[1];
			bool flag3 = filter2.z0.type == WallType.Solid || doorClosed[2];
			bool flag4 = filter2.z1.type == WallType.Solid || doorClosed[3];
			float p = 1.5f;
			float num = 1f / Mathf.Pow(Mathf.Max(0.0001f, listener.pos.x - bounds.min.x), p);
			float num2 = 1f / Mathf.Pow(Mathf.Max(0.0001f, bounds.max.x - listener.pos.x), p);
			float num3 = 1f / Mathf.Pow(Mathf.Max(0.0001f, listener.pos.y - bounds.min.y), p);
			float num4 = 1f / Mathf.Pow(Mathf.Max(0.0001f, bounds.max.y - listener.pos.y), p);
			float num5 = 1f / Mathf.Pow(Mathf.Max(0.0001f, listener.pos.z - bounds.min.z), p);
			float num6 = 1f / Mathf.Pow(Mathf.Max(0.0001f, bounds.max.z - listener.pos.z), p);
			float num7 = 0f;
			float num8 = 0f;
			if (!flag)
			{
				num7 += num * filter2.x0.volume;
				num8 += num;
			}
			if (!flag2)
			{
				num7 += num2 * filter2.x1.volume;
				num8 += num2;
			}
			if (filter2.y0.type != WallType.Solid)
			{
				num7 += num3 * filter2.y0.volume;
				num8 += num3;
			}
			if (filter2.y1.type != WallType.Solid)
			{
				num7 += num4 * filter2.y1.volume;
				num8 += num4;
			}
			if (!flag3)
			{
				num7 += num5 * filter2.z0.volume;
				num8 += num5;
			}
			if (!flag4)
			{
				num7 += num6 * filter2.z1.volume;
				num8 += num6;
			}
			float num9 = num7 / num8;
			float num10 = CalcPan(filter2.x0.type, listener.pos, listener.head, listener.earR, Vector2.right);
			float num11 = CalcPan(filter2.x1.type, listener.pos, listener.head, listener.earR, -Vector2.right);
			float num12 = CalcPan(filter2.z0.type, listener.pos, listener.head, listener.earR, Vector2.up);
			float num13 = CalcPan(filter2.z1.type, listener.pos, listener.head, listener.earR, -Vector2.up);
			float num14 = 0f;
			float num15 = 0f;
			if (!flag && filter2.x0.type != WallType.DirectionalPass)
			{
				num14 += num * num10;
				num15 += num;
			}
			if (!flag2 && filter2.x1.type != WallType.DirectionalPass)
			{
				num14 += num2 * num11;
				num15 += num2;
			}
			if (!flag3 && filter2.z0.type != WallType.DirectionalPass)
			{
				num14 += num5 * num12;
				num15 += num5;
			}
			if (!flag4 && filter2.z1.type != WallType.DirectionalPass)
			{
				num14 += num6 * num13;
				num15 += num6;
			}
			float num16 = ((num15 == 0f) ? 0f : (num14 / num15));
			volPan.vol += num9 * volumeScale;
			volPan.pan += num9 * volumeScale * num16 * 0.75f;
			break;
		}
	}

	private float CalcPan(WallType wallType, Vector3 listenerPos, Vector2 head, Vector2 earR, Vector2 sourceDir)
	{
		switch (wallType)
		{
		case WallType.DirectionalSource:
			return Vector2.Dot(-sourceDir, earR);
		case WallType.DirectionalDestination:
			return Vector2.Dot(sourceDir, earR);
		case WallType.DirectionalRoom:
			if (sourceRoom != null)
			{
				Vector2 posOnBoundsXZ = GetPosOnBoundsXZ(sourceRoom.bounds, listenerPos);
				return Vector2.Dot((posOnBoundsXZ - head).normalized, earR);
			}
			break;
		}
		return 0f;
	}

	private Vector2 GetPosOnBoundsXZ(Bounds b, Vector3 p)
	{
		if (p.x < b.min.x)
		{
			if (p.z < b.min.z)
			{
				return b.min.ToVector2XZ();
			}
			if (p.z > b.max.z)
			{
				return new Vector2(b.min.x, b.max.z);
			}
			return new Vector2(b.min.x, p.z);
		}
		if (p.x > b.max.x)
		{
			if (p.z < b.min.z)
			{
				return new Vector2(b.max.x, b.min.z);
			}
			if (p.z > b.max.z)
			{
				return b.max.ToVector2XZ();
			}
			return new Vector2(b.max.x, p.z);
		}
		if (p.z < b.min.z)
		{
			return new Vector2(p.x, b.min.z);
		}
		if (p.z > b.max.z)
		{
			return new Vector2(p.x, b.max.z);
		}
		return p.ToVector2XZ();
	}
}
