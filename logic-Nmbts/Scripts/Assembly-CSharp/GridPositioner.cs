using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class GridPositioner : MonoBehaviour, IPositionable
{
	public enum OrientationType
	{
		None = 0,
		Fixed = 1,
		Incremental = 2
	}

	public enum PositionType
	{
		Grid = 0,
		Distance = 1
	}

	public enum OrderType
	{
		XYZ = 0,
		XZY = 1,
		YXZ = 2,
		YZX = 3,
		ZXY = 4,
		ZYX = 5
	}

	public bool m_UpdateInRealtime;

	[Header("Positioning")]
	public PositionType m_PositionType;

	public Vector3 PositionValue;

	public Vector3 RandomPositionOffset;

	[Header("Orientation")]
	public OrientationType m_OrientationType;

	public Vector3 OrientationValue;

	public Vector3 RandomOrientationOffset;

	[Header("Ordering")]
	public OrderType m_OrderType;

	public bool Reverse;

	public bool CenterPositions;

	public bool IncludeInactive;

	public bool ClampWithinBounds;

	private BoxCollider _boxCollider;

	public bool UpdateInRealtime
	{
		get
		{
			return m_UpdateInRealtime;
		}
	}

	public List<Transform> Children
	{
		get
		{
			return base.transform.GetChildrenTransforms(IncludeInactive);
		}
	}

	public int ChildCount
	{
		get
		{
			return Children.Count;
		}
	}

	public BoxCollider boxCollider
	{
		get
		{
			if (!_boxCollider)
			{
				_boxCollider = GetComponent<Collider>() as BoxCollider;
			}
			return _boxCollider;
		}
	}

	public int TotalCount
	{
		get
		{
			return (int)(Count.x * Count.y * Count.z);
		}
	}

	public Vector3 Count
	{
		get
		{
			Vector3 result = default(Vector3);
			if (m_PositionType == PositionType.Grid)
			{
				result = new Vector3(Mathf.FloorToInt(PositionValue.x), Mathf.FloorToInt(PositionValue.y), Mathf.FloorToInt(PositionValue.z));
			}
			else if (m_PositionType == PositionType.Distance)
			{
				result = new Vector3(Mathf.FloorToInt(boxCollider.size.x / PositionValue.x + 1f), Mathf.FloorToInt(boxCollider.size.y / PositionValue.y + 1f), Mathf.FloorToInt(boxCollider.size.z / PositionValue.z + 1f));
			}
			return result;
		}
	}

	public Vector3 Spacing
	{
		get
		{
			return new Vector3((Count.x <= 1f) ? 0f : (boxCollider.size.x / (Count.x - 1f)), (Count.y <= 1f) ? 0f : (boxCollider.size.y / (Count.y - 1f)), (Count.z <= 1f) ? 0f : (boxCollider.size.z / (Count.z - 1f)));
		}
	}

	public Vector3 GetPosition(int x, int y, int z)
	{
		Vector3 spacing = Spacing;
		Vector3 count = Count;
		Vector3 vector = new Vector3(boxCollider.center.x + boxCollider.size.x / 2f * -1f, boxCollider.center.y + boxCollider.size.y / 2f * -1f, boxCollider.center.z + boxCollider.size.z / 2f * -1f);
		Vector3 vector2 = new Vector3((float)x * spacing.x, (float)y * spacing.y, (float)z * spacing.z);
		Vector3 vector3 = new Vector3(Random.Range(0f - RandomPositionOffset.x, RandomPositionOffset.x), Random.Range(0f - RandomPositionOffset.y, RandomPositionOffset.y), Random.Range(0f - RandomPositionOffset.z, RandomPositionOffset.z));
		return vector + vector2 + vector3;
	}

	public List<Vector3> CreatePositions()
	{
		List<Vector3> list = new List<Vector3>();
		float num = 0f - boxCollider.size.x / 2f + boxCollider.center.x;
		float num2 = 0f - boxCollider.size.y / 2f + boxCollider.center.y;
		float num3 = 0f - boxCollider.size.z / 2f + boxCollider.center.z;
		Vector3 vector = new Vector3(num, num2, num3);
		Vector3 count = Count;
		int num4 = (int)count.x;
		int num5 = (int)count.y;
		int num6 = (int)count.z;
		Vector3 spacing = Spacing;
		float x = spacing.x;
		float y = spacing.y;
		float z = spacing.z;
		Vector3 vector2 = Vector3.zero;
		Vector3 vector3 = boxCollider.size / 2f;
		int num7 = 0;
		float y2 = 0f;
		if (num5 > 1)
		{
			int num8 = num4 * num6;
			int num9 = Mathf.CeilToInt((float)ChildCount / (float)num8);
			y2 = (1f - ((float)num9 - 1f) / ((float)num5 - 1f)) * vector3.y;
		}
		for (int i = 0; i < num5; i++)
		{
			float z2 = 0f;
			if (num6 > 1)
			{
				int num10 = Mathf.Clamp(ChildCount - num7, 0, num6 * num4 - 1);
				z2 = (float)(num6 * num4 - 1 - num10 / (num6 * num4 - 1)) * vector3.z;
				z2 = 0f;
				num10 = Mathf.CeilToInt((float)Mathf.Clamp(ChildCount - num7, 0, num6 * num4) / (float)num6);
				z2 = (1f - ((float)num10 - 1f) / ((float)num6 - 1f)) * vector3.z;
			}
			for (int j = 0; j < num6; j++)
			{
				float x2 = 0f;
				if (num4 > 1)
				{
					float num11 = Mathf.Clamp(ChildCount - num7, 0, num4);
					x2 = (1f - (num11 - 1f) / ((float)num4 - 1f)) * vector3.x;
				}
				for (int k = 0; k < num4; k++)
				{
					Vector3 vector4 = new Vector3((float)k * x, (float)i * y, (float)j * z);
					Vector3 vector5 = new Vector3(Random.Range(0f - RandomPositionOffset.x, RandomPositionOffset.x), Random.Range(0f - RandomPositionOffset.y, RandomPositionOffset.y), Random.Range(0f - RandomPositionOffset.z, RandomPositionOffset.z));
					if (CenterPositions)
					{
						vector2 = new Vector3(x2, y2, z2);
					}
					Vector3 item = vector + vector2 + vector4 + vector5;
					if (ClampWithinBounds)
					{
						item = new Vector3(Mathf.Clamp(item.x, num, num + boxCollider.size.x), Mathf.Clamp(item.y, num2, num2 + boxCollider.size.y), Mathf.Clamp(item.z, num3, num3 + boxCollider.size.z));
					}
					list.Add(item);
					num7++;
				}
			}
		}
		return list;
	}

	public List<Vector3> GetPositions()
	{
		return CreatePositions();
	}

	public Vector3 GetPosition(int i)
	{
		return default(Vector3);
	}

	public Vector3 GetOrientation(int i)
	{
		Vector3 result = Vector3.zero;
		if (m_OrientationType == OrientationType.Fixed)
		{
			result = OrientationValue;
		}
		else if (m_OrientationType == OrientationType.Incremental)
		{
			result = OrientationValue * i;
		}
		else if (m_OrientationType == OrientationType.None)
		{
			result = Children[i].transform.localEulerAngles;
		}
		return result;
	}

	[ContextMenu("Apply")]
	public void ApplyPositioning()
	{
		List<Transform> children = Children;
		List<Vector3> positions = GetPositions();
		for (int i = 0; i < children.Count; i++)
		{
			Transform obj = children[i];
			Vector3 zero = Vector3.zero;
			zero = ((i >= positions.Count) ? positions.Last() : positions[i]);
			obj.localPosition = zero;
			obj.localEulerAngles = GetOrientation(i);
		}
	}

	private void Reset()
	{
		boxCollider.isTrigger = true;
	}

	private void Start()
	{
		if (Application.isPlaying)
		{
			boxCollider.enabled = false;
		}
	}

	private void Update()
	{
		if (UpdateInRealtime)
		{
			ApplyPositioning();
		}
	}
}
