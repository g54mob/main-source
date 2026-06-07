using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[ExecuteInEditMode]
public class CirclePositioner : MonoBehaviour, IPositionable
{
	public enum OrientationType
	{
		None = 0,
		Dynamic = 1,
		Fixed = 2,
		Incremental = 3
	}

	public enum PositionType
	{
		Dynamic = 0,
		Angle = 1,
		Distance = 2
	}

	public enum OrderType
	{
		Clockwise = 0,
		AntiClockwise = 1
	}

	public bool m_UpdateInRealtime;

	[Header("Positioning")]
	public PositionType m_PositionType;

	public float CirclePositionValue;

	public Vector3 RandomPositionOffset;

	[Range(0f, 1f)]
	public float RandomCirclePositionOffset;

	[Header("Orientation")]
	public OrientationType m_OrientationType;

	public Vector3 OrientationValue;

	public Vector3 RandomOrientationOffset;

	[Header("Ordering")]
	public OrderType m_OrderType;

	public bool Reverse;

	public bool CenterPositions;

	public bool IncludeInactive;

	private SphereCollider _sphereCollider;

	[Tooltip("Offset the rotation by a step.")]
	[Range(0f, 1f)]
	public int RotationOffset;

	private List<Vector3> positions;

	private List<Quaternion> rotations;

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
			return base.transform.childCount;
		}
	}

	public SphereCollider sphereCollider
	{
		get
		{
			if (!_sphereCollider)
			{
				_sphereCollider = GetComponent<Collider>() as SphereCollider;
			}
			return _sphereCollider;
		}
	}

	public int TotalCount
	{
		get
		{
			return Count;
		}
	}

	public float Radius
	{
		get
		{
			return sphereCollider.radius;
		}
	}

	public float DynamicAngle
	{
		get
		{
			if (m_PositionType == PositionType.Dynamic)
			{
				return 1f / (float)ChildCount;
			}
			if (m_PositionType == PositionType.Angle)
			{
				return CirclePositionValue;
			}
			if (m_PositionType == PositionType.Distance)
			{
				return CirclePositionValue / ((float)Math.PI * 2f * Radius);
			}
			return 0.1f;
		}
	}

	public int Count
	{
		get
		{
			return ChildCount;
		}
	}

	public float Spacing
	{
		get
		{
			return DynamicAngle;
		}
	}

	public List<Vector3> CreatePositions()
	{
		positions = new List<Vector3>();
		rotations = new List<Quaternion>();
		Vector3 center = sphereCollider.center;
		int count = Count;
		float num = Spacing * 360f;
		float radius = sphereCollider.radius;
		float num2 = (float)RotationOffset * (num / 2f);
		for (int i = 0; i < count; i++)
		{
			float num3 = UnityEngine.Random.Range((0f - RandomCirclePositionOffset) * num, RandomCirclePositionOffset * num);
			Vector3 vector = new Vector3(UnityEngine.Random.Range(0f - RandomPositionOffset.x, RandomPositionOffset.x), UnityEngine.Random.Range(0f - RandomPositionOffset.y, RandomPositionOffset.y), UnityEngine.Random.Range(0f - RandomPositionOffset.z, RandomPositionOffset.z));
			Vector3 vector2 = new Vector3(UnityEngine.Random.Range(0f - RandomOrientationOffset.x, RandomOrientationOffset.x), UnityEngine.Random.Range(0f - RandomOrientationOffset.y, RandomOrientationOffset.y), UnityEngine.Random.Range(0f - RandomOrientationOffset.z, RandomOrientationOffset.z));
			Quaternion quaternion = Quaternion.Euler(0f, num2 + (num + num3) * (float)i, 0f);
			Vector3 item = sphereCollider.center + quaternion * new Vector3(0f, 0f, radius) + vector;
			if (m_OrientationType == OrientationType.Dynamic)
			{
				quaternion = Quaternion.Euler(quaternion.eulerAngles + vector2);
			}
			if (m_OrientationType == OrientationType.Fixed)
			{
				quaternion = Quaternion.Euler(OrientationValue + vector2);
			}
			else if (m_OrientationType == OrientationType.Incremental)
			{
				quaternion = Quaternion.Euler(OrientationValue * i + vector2);
			}
			else if (m_OrientationType == OrientationType.None)
			{
				quaternion = Quaternion.Euler(Children[i].localEulerAngles);
			}
			positions.Add(item);
			rotations.Add(quaternion);
		}
		return positions;
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
		else if (m_OrientationType == OrientationType.Dynamic)
		{
			result = rotations[i].eulerAngles;
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
		CreatePositions();
		for (int i = 0; i < children.Count; i++)
		{
			Transform obj = children[i];
			obj.localPosition = positions[i];
			obj.localRotation = rotations[i];
		}
	}

	private void Reset()
	{
		sphereCollider.isTrigger = true;
	}

	private void Start()
	{
		if (Application.isPlaying)
		{
			sphereCollider.enabled = false;
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
