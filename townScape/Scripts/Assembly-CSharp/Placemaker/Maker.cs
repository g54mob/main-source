using System;
using System.Collections.Generic;
using Placemaker.Graphs;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker
{
	public class Maker : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		public List<Placemaker.Graphs.Action> actions;

		[SerializeField]
		public int actionIndex;

		[SerializeField]
		private int actionCount;

		[SerializeField]
		private int actionRedoMax;

		private const int maxActionCount = 999;

		[SerializeField]
		public int actionId;

		public Action<int, int> onQueueChange;

		[SerializeField]
		public Voxel lastAddedVoxel;

		[SerializeField]
		public Vector3 lastActionPos;

		public RapidButton rapidButton;

		[SerializeField]
		private AudioClip undoClip;

		[SerializeField]
		private AudioClip redoClip;

		private GridGenerator grid => null;

		private Graph graph => null;

		public void ActionQueueChanged()
		{
		}

		public void OnEnable()
		{
		}

		public void PaintClick(HoverData hover, VoxelType voxelType)
		{
		}

		public Voxel AddClick(HoverData hover, VoxelType voxelType)
		{
			return null;
		}

		public Voxel RemoveClick(HoverData hover)
		{
			return null;
		}

		public void ClearUndoQueue()
		{
		}

		public void TrimActionList()
		{
		}

		public Placemaker.Graphs.Action AddAction(int2 hexPos, byte height, VoxelType inType, VoxelType outType)
		{
			return default(Placemaker.Graphs.Action);
		}

		public void BeginNewAction()
		{
		}

		public void EndAction()
		{
		}

		public bool CanUndo()
		{
			return false;
		}

		public bool CanRedo()
		{
			return false;
		}

		public bool CanClear()
		{
			return false;
		}

		public bool RedoCommand()
		{
			return false;
		}

		public bool UndoCommand()
		{
			return false;
		}

		public void ClearCommand()
		{
		}

		public bool HoldUndo()
		{
			return false;
		}

		public bool HoldRedo()
		{
			return false;
		}

		public bool Undo()
		{
			return false;
		}

		public bool Redo()
		{
			return false;
		}

		public bool Clear()
		{
			return false;
		}
	}
}
