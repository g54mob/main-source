using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.Area
{
	public class AreaSlot : MonoBehaviour, IOutlineable
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<AreaSlot, bool> _003C_003E9__51_0;

			public static Func<AreaSlot, bool> _003C_003E9__51_1;

			internal bool _003CCheckIfIsEdgeAreaSlot_003Eb__51_0(AreaSlot neighborGlobalArea)
			{
				return neighborGlobalArea == null;
			}

			internal bool _003CCheckIfIsEdgeAreaSlot_003Eb__51_1(AreaSlot neighborLocalArea)
			{
				return neighborLocalArea == null;
			}
		}

		public string didCheckit;

		public List<AreaSlot> passedNeighbors;

		[SerializeField]
		private Vector2Int gridPos;

		[SerializeField]
		private AreaSlot[] _003CAllNeighbors_003Ek__BackingField;

		[SerializeField]
		private AreaSlot[] _003CNeighborsInLocalArea_003Ek__BackingField;

		[SerializeField]
		private AreaSlot[] _003CNeighborsInGlobalArea_003Ek__BackingField;

		[SerializeField]
		private bool isLocalEdgeAreaSlot;

		[SerializeField]
		private bool isGlobalEdgeAreaSlot;

		[SerializeField]
		internal Tile placedTile;

		[SerializeField]
		internal Area globalArea;

		private Area _003CLocalArea_003Ek__BackingField;

		private bool _003CIsTilePlacable_003Ek__BackingField;

		private AreaType _003CType_003Ek__BackingField;

		internal AreaSlot[] AllNeighbors
		{
			get
			{
				return _003CAllNeighbors_003Ek__BackingField;
			}
			private set
			{
				_003CAllNeighbors_003Ek__BackingField = value;
			}
		}

		public AreaSlot[] NeighborsInLocalArea
		{
			get
			{
				return _003CNeighborsInLocalArea_003Ek__BackingField;
			}
			private set
			{
				_003CNeighborsInLocalArea_003Ek__BackingField = value;
			}
		}

		internal AreaSlot[] NeighborsInGlobalArea
		{
			get
			{
				return _003CNeighborsInGlobalArea_003Ek__BackingField;
			}
			private set
			{
				_003CNeighborsInGlobalArea_003Ek__BackingField = value;
			}
		}

		internal Area LocalArea
		{
			get
			{
				return _003CLocalArea_003Ek__BackingField;
			}
			set
			{
				_003CLocalArea_003Ek__BackingField = value;
			}
		}

		internal bool IsTilePlacable
		{
			get
			{
				return _003CIsTilePlacable_003Ek__BackingField;
			}
			set
			{
				_003CIsTilePlacable_003Ek__BackingField = value;
			}
		}

		internal Vector2Int GridPos
		{
			get
			{
				return gridPos;
			}
			private set
			{
				gridPos = value;
				base.transform.position = GridCalculator.GridToWorldPos(value);
			}
		}

		internal bool IsLocalEdgeAreaSlot
		{
			get
			{
				return isLocalEdgeAreaSlot;
			}
			private set
			{
				isLocalEdgeAreaSlot = value;
				if (value)
				{
					LocalArea.AddEdgeAreaSlot(this);
				}
				else
				{
					LocalArea.RemoveEdgeAreaSlot(this);
				}
			}
		}

		internal bool IsGlobalEdgeAreaSlot
		{
			get
			{
				return isGlobalEdgeAreaSlot;
			}
			private set
			{
				isGlobalEdgeAreaSlot = value;
				if (value)
				{
					globalArea.AddEdgeAreaSlot(this);
				}
				else
				{
					globalArea.RemoveEdgeAreaSlot(this);
				}
			}
		}

		internal AreaType Type
		{
			get
			{
				return _003CType_003Ek__BackingField;
			}
			set
			{
				_003CType_003Ek__BackingField = value;
			}
		}

		public IOutlineable[] Neighbors => GetNeighborsBasedOnLocalAreaType();

		public Vector3 WorldPosition => base.transform.position;

		IOutlineable IOutlineable.GetNeighbor(int edgeIndex, Space space)
		{
			return GetNeighborsBasedOnLocalAreaType()[edgeIndex];
		}

		private void Awake()
		{
			AllNeighbors = new AreaSlot[6];
			NeighborsInLocalArea = new AreaSlot[6];
			NeighborsInGlobalArea = new AreaSlot[6];
			GridPos = GridCalculator.WorldToGridPos(base.transform.position);
		}

		private void OnDestroy()
		{
			UpdateAreaSlotNeighborsNeighborList();
		}

		internal void InitializeAreaSlot(Area areaLocal, AreaSlot[] areaSlotNeighbors, Area areaGlobal, bool isTilePlaced = false)
		{
			LocalArea = areaLocal;
			LocalArea.AddAreaSlot(this);
			globalArea = areaGlobal;
			Type = areaLocal.Type;
			IsTilePlacable = isTilePlaced;
			UpdateNeighborList(areaSlotNeighbors);
			if (areaLocal.Type == AreaType.Playable)
			{
				IsTilePlacable = true;
			}
		}

		internal void UpdateNeighborList(AreaSlot[] areaSlotNeighbors)
		{
			for (int i = 0; i < areaSlotNeighbors.Length; i++)
			{
				AddNeighbor(areaSlotNeighbors[i], i);
			}
			UpdateAreaSlotNeighborsNeighborList();
		}

		internal void UpdateAreaSlotNeighborsNeighborList(bool shouldRemoveItself = false)
		{
			AreaSlot[] allNeighbors = AllNeighbors;
			foreach (AreaSlot areaSlot in allNeighbors)
			{
				if (!(areaSlot == null))
				{
					int? neighborIndexFromGridPos = GridCalculator.GetNeighborIndexFromGridPos(areaSlot.GridPos, GridPos);
					if (neighborIndexFromGridPos.HasValue)
					{
						areaSlot.AddNeighbor(shouldRemoveItself ? null : this, neighborIndexFromGridPos.Value);
					}
				}
			}
		}

		private void AddNeighbor(AreaSlot neighbor, int neighborIndex)
		{
			if (neighborIndex < 0 || neighborIndex > 5)
			{
				Debug.LogError($"Passed neighbor index ({neighborIndex}) is not a valid neighbor index (should be [0...5]! {neighbor} was not added as neighbor to {this}");
				return;
			}
			try
			{
				AllNeighbors[neighborIndex] = neighbor;
				if (neighbor == null)
				{
					NeighborsInGlobalArea[neighborIndex] = neighbor;
					NeighborsInLocalArea[neighborIndex] = neighbor;
				}
				else if (neighbor.LocalArea.Type == LocalArea.Type)
				{
					NeighborsInGlobalArea[neighborIndex] = neighbor;
					if (!(neighbor.LocalArea != LocalArea))
					{
						NeighborsInLocalArea[neighborIndex] = neighbor;
					}
				}
			}
			finally
			{
				CheckIfIsEdgeAreaSlot();
			}
		}

		internal void CheckIfIsEdgeAreaSlot()
		{
			IsGlobalEdgeAreaSlot = Enumerable.Any(NeighborsInGlobalArea, (AreaSlot neighborGlobalArea) => neighborGlobalArea == null);
			IsLocalEdgeAreaSlot = Enumerable.Any(NeighborsInLocalArea, (AreaSlot neighborLocalArea) => neighborLocalArea == null);
		}

		internal void UpdateLocalAndGlobalNeighborsFromAllNeighbors()
		{
			NeighborsInGlobalArea = AllNeighbors;
			for (int i = 0; i < NeighborsInGlobalArea.Length; i++)
			{
				if (!(NeighborsInGlobalArea[i] == null) && NeighborsInGlobalArea[i].LocalArea.Type != LocalArea.Type)
				{
					NeighborsInGlobalArea[i] = null;
				}
			}
			NeighborsInLocalArea = NeighborsInGlobalArea;
			for (int j = 0; j < NeighborsInLocalArea.Length; j++)
			{
				if (!(NeighborsInLocalArea[j] == null) && NeighborsInLocalArea[j].LocalArea != LocalArea)
				{
					NeighborsInLocalArea[j] = null;
				}
			}
		}

		private AreaSlot[] GetNeighborsBasedOnLocalAreaType()
		{
			return LocalArea.Type switch
			{
				AreaType.Playable => NeighborsInGlobalArea, 
				AreaType.Preview => NeighborsInLocalArea, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
