using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.BlockingSystem;
using Timberborn.TickSystem;
using Timberborn.WaterSystem;
using UnityEngine;

namespace Timberborn.WaterBuildings
{
	public class TickableWaterBuilding : TickableComponent, IAwakableComponent, IFinishedStateListener, IWaterNeedingBuilding
	{
		private readonly IThreadSafeWaterMap _threadSafeWaterMap;

		private BlockObject _blockObject;

		private BlockableObject _blockableObject;

		private TickableWaterBuildingSpec _tickableWaterBuildingSpec;

		private bool _hasWater = true;

		public Vector3Int WaterCoordinatesTransformed { get; private set; }

		private float WaterHeight => _threadSafeWaterMap.WaterHeightOrFloor(WaterCoordinatesTransformed) - (float)WaterCoordinatesTransformed.z;

		public event EventHandler StartedNeedingWater;

		public event EventHandler StoppedNeedingWater;

		public TickableWaterBuilding(IThreadSafeWaterMap threadSafeWaterMap)
		{
			_threadSafeWaterMap = threadSafeWaterMap;
		}

		public void Awake()
		{
			_blockObject = GetComponent<BlockObject>();
			_blockableObject = GetComponent<BlockableObject>();
			_tickableWaterBuildingSpec = GetComponent<TickableWaterBuildingSpec>();
			DisableComponent();
		}

		public void OnEnterFinishedState()
		{
			EnableComponent();
		}

		public void OnExitFinishedState()
		{
			DisableComponent();
		}

		public override void StartTickable()
		{
			WaterCoordinatesTransformed = _blockObject.TransformCoordinates(_tickableWaterBuildingSpec.WaterCoordinates);
			CheckWaterHeight();
		}

		public override void Tick()
		{
			CheckWaterHeight();
		}

		private void CheckWaterHeight()
		{
			float minWaterHeight = _tickableWaterBuildingSpec.MinWaterHeight;
			float changeRange = _tickableWaterBuildingSpec.ChangeRange;
			if (WaterHeight <= minWaterHeight - changeRange && _hasWater)
			{
				_hasWater = false;
				_blockableObject.Block(this);
				this.StartedNeedingWater?.Invoke(this, EventArgs.Empty);
			}
			else if (WaterHeight > minWaterHeight + changeRange && !_hasWater)
			{
				_hasWater = true;
				_blockableObject.Unblock(this);
				this.StoppedNeedingWater?.Invoke(this, EventArgs.Empty);
			}
		}
	}
}
