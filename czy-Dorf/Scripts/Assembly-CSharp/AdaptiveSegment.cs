using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(ElementGroupSegment))]
public class AdaptiveSegment : MonoBehaviour, ITileStateReceiver
{
	[SerializeField]
	private GameObject[] showIfNeighborTileEmpty = new GameObject[6];

	[SerializeField]
	private GameObject[] showIfUnfittingNeighborSegment = new GameObject[6];

	[SerializeField]
	private GameObject[] showIfNeighborSegmentSameType = new GameObject[6];

	[FormerlySerializedAs("showIfNeighborSegmentHybrid")]
	[SerializeField]
	private GameObject[] showIfNeighborSegmentHybridCompatible = new GameObject[6];

	[SerializeField]
	private GameObject[] showIfNeighborSegmentHybridIncompatible = new GameObject[6];

	[SerializeField]
	[FormerlySerializedAs("hybridCorners")]
	private GameObject[] lakeCorners;

	[SerializeField]
	private GameObject[] riverCorners;

	private ElementGroupSegment segment;

	private Dictionary<SegmentNeighborType, GameObject[]> listBySegmentNeighborType;

	private GameObject[] currentlyVisible = new GameObject[6];

	[SerializeField]
	private SegmentNeighborType[] neighborTypes = new SegmentNeighborType[6];

	public event Action<int, SegmentNeighborType> OnNeighborStateChanged;

	private void DebugNeighborSegmentTypes()
	{
		for (int i = 0; i < 6; i++)
		{
			Debug.Log($"world edge {i}: {GetNeighborType(i, Space.World)}");
		}
	}

	private void Awake()
	{
		segment = GetComponent<ElementGroupSegment>();
		listBySegmentNeighborType = new Dictionary<SegmentNeighborType, GameObject[]>
		{
			{
				SegmentNeighborType.NoTile,
				showIfNeighborTileEmpty
			},
			{
				SegmentNeighborType.UnfittingSegment,
				showIfUnfittingNeighborSegment
			},
			{
				SegmentNeighborType.SameTypeSegment,
				showIfNeighborSegmentSameType
			},
			{
				SegmentNeighborType.CompatibleFullHybridSegment,
				showIfNeighborSegmentHybridCompatible
			},
			{
				SegmentNeighborType.IncompatibleHybridSegment,
				showIfNeighborSegmentHybridIncompatible
			}
		};
		ResetVisuals();
		segment.OnSegmentNeighborChanged += UpdateNeighborLogic;
		segment.OnSegmentNeighborVisualChanged += UpdateNeighborVisuals;
		for (int i = 0; i < currentlyVisible.Length; i++)
		{
			currentlyVisible[i] = listBySegmentNeighborType[SegmentNeighborType.NoTile][i];
		}
	}

	private void ResetVisuals()
	{
		GameObject[] value;
		foreach (KeyValuePair<SegmentNeighborType, GameObject[]> item in listBySegmentNeighborType)
		{
			if (item.Value == null)
			{
				continue;
			}
			value = item.Value;
			foreach (GameObject gameObject in value)
			{
				if (!(gameObject == null))
				{
					gameObject.SetActive(value: false);
				}
			}
		}
		value = lakeCorners;
		foreach (GameObject gameObject2 in value)
		{
			if ((bool)gameObject2)
			{
				gameObject2.SetActive(value: false);
			}
		}
		value = riverCorners;
		foreach (GameObject gameObject3 in value)
		{
			if ((bool)gameObject3)
			{
				gameObject3.SetActive(value: false);
			}
		}
		if (listBySegmentNeighborType[SegmentNeighborType.NoTile] == null)
		{
			return;
		}
		value = listBySegmentNeighborType[SegmentNeighborType.NoTile];
		foreach (GameObject gameObject4 in value)
		{
			if (!(gameObject4 == null))
			{
				gameObject4.SetActive(value: true);
			}
		}
	}

	private void UpdateNeighborLogic(int localTileEdgeIndex, int worldEdgeIndex, Tile neighborTile, ElementGroupSegment neighborSegment)
	{
		SegmentNeighborType segmentNeighborType = SegmentNeighborType.NoTile;
		if ((bool)neighborTile)
		{
			List<GroupType> edgeTypes = segment.Tile.GetEdgeTypes(worldEdgeIndex, Space.World, TileEdgeType.Hybrid);
			List<GroupType> edgeTypes2 = neighborTile.GetEdgeTypes((worldEdgeIndex + 3) % 6, Space.World, TileEdgeType.Hybrid);
			if (neighborSegment == null)
			{
				segmentNeighborType = SegmentNeighborType.UnfittingSegment;
			}
			else if (edgeTypes2.Count == 0 && neighborSegment.GroupType == segment.GroupType)
			{
				segmentNeighborType = SegmentNeighborType.SameTypeSegment;
			}
			else if (edgeTypes2.Count == 0 && edgeTypes.Contains(neighborSegment.GroupType))
			{
				segmentNeighborType = SegmentNeighborType.IncompatibleHybridSegment;
			}
			else if (edgeTypes2.Count == 0)
			{
				segmentNeighborType = SegmentNeighborType.UnfittingSegment;
			}
			else if (edgeTypes2.Contains(segment.GroupType))
			{
				List<GroupType> edgeTypes3 = neighborTile.GetEdgeTypes((worldEdgeIndex + 4) % 6, Space.World, TileEdgeType.Hybrid);
				List<GroupType> edgeTypes4 = neighborTile.GetEdgeTypes((worldEdgeIndex + 2) % 6, Space.World, TileEdgeType.Hybrid);
				segmentNeighborType = ((!edgeTypes3.Contains(segment.GroupType)) ? SegmentNeighborType.CompatibleHalfHybridSegment_Right : (edgeTypes4.Contains(segment.GroupType) ? SegmentNeighborType.CompatibleFullHybridSegment : SegmentNeighborType.CompatibleHalfHybridSegment_Left));
			}
			else
			{
				segmentNeighborType = SegmentNeighborType.IncompatibleHybridSegment;
			}
		}
		int num = GridCalculator.RotatedDirection(localTileEdgeIndex, -segment.RotationIndex);
		neighborTypes[num] = segmentNeighborType;
		this.OnNeighborStateChanged?.Invoke(worldEdgeIndex, segmentNeighborType);
	}

	private void SetLayer(int targetLayer)
	{
		GameObject[] array = currentlyVisible;
		foreach (GameObject gameObject in array)
		{
			if ((bool)gameObject)
			{
				gameObject.layer = targetLayer;
			}
		}
	}

	private void UpdateNeighborVisuals()
	{
		for (int i = 0; i < 6; i++)
		{
			ElementGroupSegment neighborSegment = segment.GetNeighborSegment(i);
			int num = (segment.Tile ? GridCalculator.RotatedDirection(i, -segment.RotationIndex - segment.Tile.RotationIndex + 12) : i);
			SegmentNeighborType segmentNeighborType = neighborTypes[num];
			if ((bool)currentlyVisible[num])
			{
				currentlyVisible[num].SetActive(value: false);
			}
			if (segmentNeighborType == SegmentNeighborType.CompatibleHalfHybridSegment_Left || segmentNeighborType == SegmentNeighborType.CompatibleHalfHybridSegment_Right)
			{
				currentlyVisible[num] = listBySegmentNeighborType[SegmentNeighborType.CompatibleFullHybridSegment][num];
			}
			else
			{
				currentlyVisible[num] = listBySegmentNeighborType[segmentNeighborType][num];
			}
			if ((bool)currentlyVisible[num])
			{
				currentlyVisible[num].SetActive(value: true);
			}
			if (lakeCorners.Length != 0)
			{
				UpdateHybridCorners(i, neighborSegment, num);
			}
		}
	}

	private void UpdateHybridCorners(int worldEdgeIndex, ElementGroupSegment worldNeighborSegment, int segmentLocalEdgeIndex)
	{
		bool active = false;
		bool active2 = false;
		if (neighborTypes[segmentLocalEdgeIndex] == SegmentNeighborType.CompatibleFullHybridSegment || neighborTypes[segmentLocalEdgeIndex] == SegmentNeighborType.NoTile || neighborTypes[segmentLocalEdgeIndex] == SegmentNeighborType.CompatibleHalfHybridSegment_Left || neighborTypes[segmentLocalEdgeIndex] == SegmentNeighborType.CompatibleHalfHybridSegment_Right)
		{
			if ((neighborTypes[segmentLocalEdgeIndex] != SegmentNeighborType.CompatibleHalfHybridSegment_Right && neighborTypes[(segmentLocalEdgeIndex + 5) % 6] == SegmentNeighborType.UnfittingSegment) || neighborTypes[(segmentLocalEdgeIndex + 5) % 6] == SegmentNeighborType.SameTypeSegment || neighborTypes[(segmentLocalEdgeIndex + 5) % 6] == SegmentNeighborType.IncompatibleHybridSegment || neighborTypes[(segmentLocalEdgeIndex + 5) % 6] == SegmentNeighborType.CompatibleHalfHybridSegment_Left)
			{
				active = true;
			}
			if ((neighborTypes[segmentLocalEdgeIndex] != SegmentNeighborType.CompatibleHalfHybridSegment_Left && neighborTypes[(segmentLocalEdgeIndex + 1) % 6] == SegmentNeighborType.UnfittingSegment) || neighborTypes[(segmentLocalEdgeIndex + 1) % 6] == SegmentNeighborType.SameTypeSegment || neighborTypes[(segmentLocalEdgeIndex + 1) % 6] == SegmentNeighborType.IncompatibleHybridSegment || neighborTypes[(segmentLocalEdgeIndex + 1) % 6] == SegmentNeighborType.CompatibleHalfHybridSegment_Right)
			{
				active2 = true;
			}
		}
		if (riverCorners.Length != 0 && (bool)riverCorners[segmentLocalEdgeIndex * 2])
		{
			bool flag = neighborTypes[segmentLocalEdgeIndex] == SegmentNeighborType.CompatibleHalfHybridSegment_Right;
			riverCorners[segmentLocalEdgeIndex * 2].SetActive(flag);
			if (flag)
			{
				active = false;
			}
		}
		if (riverCorners.Length != 0 && (bool)riverCorners[segmentLocalEdgeIndex * 2 + 1])
		{
			bool flag2 = neighborTypes[segmentLocalEdgeIndex] == SegmentNeighborType.CompatibleHalfHybridSegment_Left;
			riverCorners[segmentLocalEdgeIndex * 2 + 1].SetActive(flag2);
			if (flag2)
			{
				active2 = false;
			}
		}
		if ((bool)lakeCorners[segmentLocalEdgeIndex * 2])
		{
			lakeCorners[segmentLocalEdgeIndex * 2].SetActive(active);
		}
		if ((bool)lakeCorners[segmentLocalEdgeIndex * 2 + 1])
		{
			lakeCorners[segmentLocalEdgeIndex * 2 + 1].SetActive(active2);
		}
	}

	public SegmentNeighborType GetNeighborType(int edgeIndex, Space space)
	{
		if (space == Space.Self)
		{
			return neighborTypes[edgeIndex];
		}
		int num = GridCalculator.RotatedDirection(edgeIndex, -segment.RotationIndex - segment.Tile.RotationIndex + 12);
		return neighborTypes[num];
	}

	public void ChangeTileState(TileState targetState)
	{
		switch (targetState)
		{
		case TileState.stacked:
		{
			GameObject[] array = currentlyVisible;
			foreach (GameObject gameObject2 in array)
			{
				if ((bool)gameObject2)
				{
					gameObject2.SetActive(value: false);
				}
			}
			break;
		}
		case TileState.stackPreview:
		{
			GameObject[] array = currentlyVisible;
			foreach (GameObject gameObject in array)
			{
				if ((bool)gameObject)
				{
					gameObject.SetActive(value: true);
				}
			}
			break;
		}
		}
	}

	public void SetRendererLayer(int targetLayer)
	{
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
	}

	public void SetTileReference(Tile tile)
	{
	}
}
