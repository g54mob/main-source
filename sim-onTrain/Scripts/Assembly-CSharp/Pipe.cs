using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
	private struct ConnectionPointSetup
	{
		public Vector3 worldPosition;

		public Vector3 forwardDirection;
	}

	public PipeType pipeType;

	[Header("Connection Points")]
	[Tooltip("Her acik ucun Transform'u. Forward yonu disa dogru bakmali.")]
	public Transform[] connectionPoints;

	public bool[] occupiedConnections;

	[SerializeField]
	private bool showGizmos = true;

	[SerializeField]
	private float gizmoRadius = 0.08f;

	private void Awake()
	{
		if (connectionPoints != null && connectionPoints.Length != 0)
		{
			occupiedConnections = new bool[connectionPoints.Length];
		}
	}

	public List<Transform> GetOpenConnectionPoints()
	{
		List<Transform> list = new List<Transform>();
		if (connectionPoints == null)
		{
			return list;
		}
		for (int i = 0; i < connectionPoints.Length; i++)
		{
			if (connectionPoints[i] != null && !IsOccupied(i))
			{
				list.Add(connectionPoints[i]);
			}
		}
		return list;
	}

	public bool IsOccupied(int index)
	{
		if (occupiedConnections == null || index < 0 || index >= occupiedConnections.Length)
		{
			return false;
		}
		return occupiedConnections[index];
	}

	public void OccupyConnection(int index)
	{
		if (occupiedConnections != null && index >= 0 && index < occupiedConnections.Length)
		{
			occupiedConnections[index] = true;
		}
	}

	public void FreeConnection(int index)
	{
		if (occupiedConnections != null && index >= 0 && index < occupiedConnections.Length)
		{
			occupiedConnections[index] = false;
		}
	}

	public int GetClosestConnectionIndex(Vector3 worldPosition)
	{
		if (connectionPoints == null || connectionPoints.Length == 0)
		{
			return -1;
		}
		float num = float.MaxValue;
		int result = 0;
		for (int i = 0; i < connectionPoints.Length; i++)
		{
			if (!(connectionPoints[i] == null))
			{
				float num2 = Vector3.Distance(connectionPoints[i].position, worldPosition);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
		}
		return result;
	}

	public int GetClosestOpenConnectionIndex(Vector3 worldPosition)
	{
		if (connectionPoints == null || connectionPoints.Length == 0)
		{
			return -1;
		}
		float num = float.MaxValue;
		int result = -1;
		for (int i = 0; i < connectionPoints.Length; i++)
		{
			if (!(connectionPoints[i] == null) && !IsOccupied(i))
			{
				float num2 = Vector3.Distance(connectionPoints[i].position, worldPosition);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
		}
		return result;
	}

	public void OnPipeRemoved()
	{
		if (connectionPoints == null)
		{
			return;
		}
		float num = 0.15f;
		for (int i = 0; i < connectionPoints.Length; i++)
		{
			if (connectionPoints[i] == null || !IsOccupied(i))
			{
				continue;
			}
			Collider[] array = Physics.OverlapSphere(connectionPoints[i].position, num);
			foreach (Collider obj in array)
			{
				Pipe componentInParent = obj.GetComponentInParent<Pipe>();
				if (componentInParent != null && componentInParent != this)
				{
					int closestConnectionIndex = componentInParent.GetClosestConnectionIndex(connectionPoints[i].position);
					if (closestConnectionIndex >= 0)
					{
						componentInParent.FreeConnection(closestConnectionIndex);
					}
				}
				PipeConnector componentInParent2 = obj.GetComponentInParent<PipeConnector>();
				if (componentInParent2 != null && Vector3.Distance(connectionPoints[i].position, componentInParent2.connectionPoint.position) < num)
				{
					componentInParent2.isOccupied = false;
				}
			}
		}
	}

	public void AutoOrientConnectionPoints()
	{
		if (connectionPoints == null || connectionPoints.Length == 0)
		{
			return;
		}
		Vector3 vector = base.transform.position;
		Renderer componentInChildren = GetComponentInChildren<Renderer>();
		if (componentInChildren != null)
		{
			vector = componentInChildren.bounds.center;
		}
		Transform[] array = connectionPoints;
		foreach (Transform transform in array)
		{
			if (!(transform == null))
			{
				Vector3 normalized = (transform.position - vector).normalized;
				if (!(normalized.sqrMagnitude < 0.001f))
				{
					transform.rotation = Quaternion.LookRotation(normalized, Vector3.up);
				}
			}
		}
		MarkDirty();
	}

	public void GenerateConnectionPoints()
	{
		if (connectionPoints != null)
		{
			Transform[] array = connectionPoints;
			foreach (Transform transform in array)
			{
				if (transform != null)
				{
					Object.Destroy(transform.gameObject);
				}
			}
		}
		Renderer componentInChildren = GetComponentInChildren<Renderer>();
		if (componentInChildren == null)
		{
			Debug.LogWarning("Pipe uzerinde Renderer bulunamadi!");
			return;
		}
		Bounds bounds = componentInChildren.bounds;
		Vector3 center = bounds.center;
		base.transform.InverseTransformPoint(center);
		List<ConnectionPointSetup> connectionPointSetups = GetConnectionPointSetups(bounds, center);
		connectionPoints = new Transform[connectionPointSetups.Count];
		for (int j = 0; j < connectionPointSetups.Count; j++)
		{
			GameObject gameObject = new GameObject($"ConnectionPoint_{j}");
			gameObject.transform.parent = base.transform;
			gameObject.transform.position = connectionPointSetups[j].worldPosition;
			gameObject.transform.rotation = Quaternion.LookRotation(connectionPointSetups[j].forwardDirection, Vector3.up);
			connectionPoints[j] = gameObject.transform;
		}
		occupiedConnections = new bool[connectionPoints.Length];
		Debug.Log($"[Pipe] {pipeType}: {connectionPoints.Length} connection point olusturuldu.");
		MarkDirty();
	}

	private List<ConnectionPointSetup> GetConnectionPointSetups(Bounds bounds, Vector3 center)
	{
		List<ConnectionPointSetup> list = new List<ConnectionPointSetup>();
		Vector3 forward = base.transform.forward;
		Vector3 right = base.transform.right;
		Vector3 up = base.transform.up;
		GetComponentInChildren<Renderer>();
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Bounds bounds2 = ((componentInChildren != null) ? componentInChildren.sharedMesh.bounds : new Bounds(Vector3.zero, bounds.size));
		Vector3 extents = new Vector3(bounds2.extents.x * base.transform.lossyScale.x, bounds2.extents.y * base.transform.lossyScale.y, bounds2.extents.z * base.transform.lossyScale.z);
		switch (pipeType)
		{
		case PipeType.StandartPipe:
			GetStraightPipePoints(list, center, forward, right, up, extents);
			break;
		case PipeType.FoldedPipe:
			GetFoldedPipePoints(list, center, forward, right, up, extents);
			break;
		case PipeType.TriplePipe:
			GetTriplePipePoints(list, center, forward, right, up, extents);
			break;
		case PipeType.QuadriplePipe:
			GetQuadriplePipePoints(list, center, forward, right, up, extents);
			break;
		}
		return list;
	}

	private void GetStraightPipePoints(List<ConnectionPointSetup> setups, Vector3 center, Vector3 forward, Vector3 right, Vector3 up, Vector3 extents)
	{
		FindLongestAxis(forward, right, up, extents, out var longAxis, out var longExtent);
		setups.Add(new ConnectionPointSetup
		{
			worldPosition = center + longAxis * longExtent,
			forwardDirection = longAxis
		});
		setups.Add(new ConnectionPointSetup
		{
			worldPosition = center - longAxis * longExtent,
			forwardDirection = -longAxis
		});
	}

	private void GetFoldedPipePoints(List<ConnectionPointSetup> setups, Vector3 center, Vector3 forward, Vector3 right, Vector3 up, Vector3 extents)
	{
		float[] array = new float[3] { extents.x, extents.y, extents.z };
		Vector3[] array2 = new Vector3[3] { right, up, forward };
		int num = 0;
		float num2 = array[0];
		for (int i = 1; i < 3; i++)
		{
			if (array[i] < num2)
			{
				num2 = array[i];
				num = i;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (j != num)
			{
				setups.Add(new ConnectionPointSetup
				{
					worldPosition = center + array2[j] * array[j],
					forwardDirection = array2[j]
				});
			}
		}
	}

	private void GetTriplePipePoints(List<ConnectionPointSetup> setups, Vector3 center, Vector3 forward, Vector3 right, Vector3 up, Vector3 extents)
	{
		float[] array = new float[3] { extents.x, extents.y, extents.z };
		Vector3[] array2 = new Vector3[3] { right, up, forward };
		int num = 0;
		float num2 = array[0];
		for (int i = 1; i < 3; i++)
		{
			if (array[i] < num2)
			{
				num2 = array[i];
				num = i;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (j != num)
			{
				setups.Add(new ConnectionPointSetup
				{
					worldPosition = center + array2[j] * array[j],
					forwardDirection = array2[j]
				});
				if (setups.Count < 3)
				{
					setups.Add(new ConnectionPointSetup
					{
						worldPosition = center - array2[j] * array[j],
						forwardDirection = -array2[j]
					});
				}
			}
		}
		while (setups.Count > 3)
		{
			setups.RemoveAt(setups.Count - 1);
		}
	}

	private void GetQuadriplePipePoints(List<ConnectionPointSetup> setups, Vector3 center, Vector3 forward, Vector3 right, Vector3 up, Vector3 extents)
	{
		float[] array = new float[3] { extents.x, extents.y, extents.z };
		Vector3[] array2 = new Vector3[3] { right, up, forward };
		int num = 0;
		float num2 = array[0];
		for (int i = 1; i < 3; i++)
		{
			if (array[i] < num2)
			{
				num2 = array[i];
				num = i;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (j != num)
			{
				setups.Add(new ConnectionPointSetup
				{
					worldPosition = center + array2[j] * array[j],
					forwardDirection = array2[j]
				});
				setups.Add(new ConnectionPointSetup
				{
					worldPosition = center - array2[j] * array[j],
					forwardDirection = -array2[j]
				});
			}
		}
	}

	private void FindLongestAxis(Vector3 forward, Vector3 right, Vector3 up, Vector3 extents, out Vector3 longAxis, out float longExtent)
	{
		if (extents.z >= extents.x && extents.z >= extents.y)
		{
			longAxis = forward;
			longExtent = extents.z;
		}
		else if (extents.x >= extents.y)
		{
			longAxis = right;
			longExtent = extents.x;
		}
		else
		{
			longAxis = up;
			longExtent = extents.y;
		}
	}

	private void MarkDirty()
	{
	}

	private void OnDrawGizmos()
	{
		if (!showGizmos || connectionPoints == null)
		{
			return;
		}
		for (int i = 0; i < connectionPoints.Length; i++)
		{
			if (!(connectionPoints[i] == null))
			{
				Gizmos.color = ((occupiedConnections != null && i < occupiedConnections.Length && occupiedConnections[i]) ? Color.red : Color.green);
				Gizmos.DrawWireSphere(connectionPoints[i].position, gizmoRadius);
				Vector3 position = connectionPoints[i].position;
				Vector3 vector = position + connectionPoints[i].forward * 0.3f;
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(position, vector);
				Vector3 vector2 = connectionPoints[i].right * 0.05f;
				Vector3 vector3 = connectionPoints[i].up * 0.05f;
				Gizmos.DrawLine(vector, vector - connectionPoints[i].forward * 0.06f + vector2);
				Gizmos.DrawLine(vector, vector - connectionPoints[i].forward * 0.06f - vector2);
				Gizmos.DrawLine(vector, vector - connectionPoints[i].forward * 0.06f + vector3);
				Gizmos.DrawLine(vector, vector - connectionPoints[i].forward * 0.06f - vector3);
			}
		}
	}
}
