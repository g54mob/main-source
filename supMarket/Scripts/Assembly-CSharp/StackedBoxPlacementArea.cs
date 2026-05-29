using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StackedBoxPlacementArea : MonoBehaviour, IPlacementArea, ILoader<Box>
{
	[SerializeField]
	private PlacementLimit m_Limit;

	[SerializeField]
	private float m_MaxVolume;

	[SerializeField]
	private float m_MaxCount;

	private List<SortableBox> m_Boxes;

	private PlacementAreaBehaviour m_PlacementAreaBehaviour;

	[SerializeField]
	private BoxCollider m_Collider;

	[SerializeField]
	private bool m_FitToArea;

	[SerializeField]
	private float m_ScaleFactor;

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

	public void Sort()
	{
	}

	private float GetModifiedScale(Bounds placementBounds)
	{
		return 0f;
	}

	void ILoader<Box>.Load(Box instance)
	{
	}
}
