using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.EntitySystem;
using Timberborn.WaterSystem;
using UnityEngine;

namespace Timberborn.WaterBuildings
{
	public class WaterOutput : BaseComponent, IAwakableComponent, IInitializableEntity
	{
		private static readonly float WaterUpperSafetySpace = 0.1f;

		private readonly IWaterService _waterService;

		private readonly IThreadSafeWaterMap _threadSafeWaterMap;

		private BlockObject _blockObject;

		private Vector3Int _waterCoordinatesTransformed;

		public bool HasSpaceForWater => AvailableSpace > 0f;

		public float AvailableSpace => (float)_waterCoordinatesTransformed.z - WaterUpperSafetySpace - _threadSafeWaterMap.WaterHeightOrFloor(_waterCoordinatesTransformed);

		public event EventHandler<WaterAddition> WaterAdded;

		public WaterOutput(IWaterService waterService, IThreadSafeWaterMap threadSafeWaterMap)
		{
			_waterService = waterService;
			_threadSafeWaterMap = threadSafeWaterMap;
		}

		public void Awake()
		{
			_blockObject = GetComponent<BlockObject>();
		}

		public void InitializeEntity()
		{
			Vector3Int waterCoordinates = GetComponent<WaterOutputSpec>().WaterCoordinates;
			_waterCoordinatesTransformed = _blockObject.TransformCoordinates(waterCoordinates);
		}

		public void AddCleanWater(float cleanWater)
		{
			AddWater(cleanWater, 0f);
		}

		public void AddContaminatedWater(float contaminatedWater)
		{
			AddWater(0f, contaminatedWater);
		}

		public void AddWater(float cleanWater, float contaminatedWater)
		{
			if (cleanWater > 0f)
			{
				_waterService.AddCleanWater(_waterCoordinatesTransformed, cleanWater);
			}
			if (contaminatedWater > 0f)
			{
				_waterService.AddContaminatedWater(_waterCoordinatesTransformed, contaminatedWater);
			}
			if (cleanWater > 0f || contaminatedWater > 0f)
			{
				this.WaterAdded?.Invoke(this, new WaterAddition(cleanWater, contaminatedWater));
			}
		}
	}
}
