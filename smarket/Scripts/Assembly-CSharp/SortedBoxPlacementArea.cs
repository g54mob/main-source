using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SortedBoxPlacementArea : MonoBehaviour, IPlacementArea, ILoader<Box>, ILoader<OrderPaperBag>
{
	private List<SortableBox> m_SortableBoxes;

	[SerializeField]
	private float m_MaxY;

	[SerializeField]
	private float m_MaxVolume;

	[SerializeField]
	private int m_MaxCount;

	[SerializeField]
	private PlacementLimit m_Limit;

	[SerializeField]
	private Vector3Int m_SortAreaLimit;

	[SerializeField]
	private float m_CellSize;

	[SerializeField]
	private float m_ScaleFactor;

	private Collider[] m_RigidbodyColliders;

	private Rigidbody m_AttachedRigidbody;

	private const float MovementDuration = 0.3f;

	private PlacementAreaBehaviour m_Behaviour;

	private NetworkVehicle m_NetworkVehicle;

	public List<SortableBox> SortableBoxes => null;

	public NetworkVehicle NetworkVehicle => null;

	public event Action<SortableBox> BoxAdded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<SortableBox> BoxRemoved
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	public bool CanBeAdded(SortableBox box)
	{
		return false;
	}

	private float CalculateTotalVolume()
	{
		return 0f;
	}

	public void AddBox(SortableBox sortableBox)
	{
	}

	public void AddBox_Network(SortableBox sortableBox)
	{
	}

	public void Sort()
	{
	}

	private void ApplyPositions(SortState state)
	{
	}

	public void RemoveBox(SortableBox box)
	{
	}

	public void RemoveBox_Network(SortableBox box)
	{
	}

	public IEnumerable<SortableBox> GetBoxes()
	{
		return null;
	}

	void ILoader<Box>.Load(Box instance)
	{
	}

	void ILoader<OrderPaperBag>.Load(OrderPaperBag instance)
	{
	}
}
