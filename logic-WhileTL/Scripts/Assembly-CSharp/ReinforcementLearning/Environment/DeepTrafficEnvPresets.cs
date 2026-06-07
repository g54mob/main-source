using System;
using App.Data;
using DeepTraffic;
using UnityEngine;

namespace ReinforcementLearning.Environment
{
	public class DeepTrafficEnvPresets : BaseKeyData, ICloneable
	{
		public int height;

		public int width;

		public int carHeight;

		public int baseCarSpeed;

		public int carNumber;

		public int changeXThreshold;

		public int changeYThreshold;

		public int changeSpeedThreshold;

		public int carSafetyHeight;

		public int maxCarSpeed;

		public bool sparseCars;

		public bool differentWays;

		public int lanesSide;

		public int patchesAhead;

		public int patchesBehind;

		public bool[] enabledLidarCells;

		public int enabledCount;

		public int maxLanesSide;

		public int maxPatchesAhead;

		public int maxPatchesBehind;

		public LidarData lanesLidar;

		public LidarData aheadLidar;

		public LidarData behindLidar;

		public int LanesSide
		{
			get
			{
				if (lanesSide == -1)
				{
					return Mathf.Min((lanesLidar != null) ? lanesLidar.Side : 0, maxLanesSide);
				}
				return lanesSide;
			}
		}

		public int PatchesAhead
		{
			get
			{
				if (patchesAhead == -1)
				{
					return Mathf.Min((aheadLidar == null) ? 1 : aheadLidar.Front, maxPatchesAhead);
				}
				return patchesAhead;
			}
		}

		public int PatchesBehind
		{
			get
			{
				if (patchesBehind == -1)
				{
					return Mathf.Min((behindLidar == null) ? 5 : behindLidar.Behind, maxPatchesBehind);
				}
				return patchesBehind;
			}
		}

		public DeepTrafficEnvPresets()
		{
		}

		public void SetDefaultLidars()
		{
			enabledCount = DeepTrafficStatic.InputSize(this);
			enabledLidarCells = new bool[enabledCount];
			for (int i = 0; i < enabledCount; i++)
			{
				enabledLidarCells[i] = true;
			}
		}

		public DeepTrafficEnvPresets(int height, int width, int carHeight, int baseCarSpeed, int changeXThreshold, int changeYThreshold, int changeSpeedThreshold, int maxLanesSide, int maxPatchesAhead, int maxPatchesBehind, int carNumber, int carSafetyHeight, int maxCarSpeed, bool sparseCars, bool differentWays, bool[] enabledLidarCells, int enabledCount, LidarData lanesLidar, LidarData aheadLidar, LidarData behindLidar, int lanesSide, int patchesAhead, int patchesBehind)
		{
			this.height = height;
			this.width = width;
			this.carHeight = carHeight;
			this.baseCarSpeed = baseCarSpeed;
			this.changeXThreshold = changeXThreshold;
			this.changeYThreshold = changeYThreshold;
			this.changeSpeedThreshold = changeSpeedThreshold;
			this.maxLanesSide = maxLanesSide;
			this.maxPatchesAhead = maxPatchesAhead;
			this.maxPatchesBehind = maxPatchesBehind;
			this.carNumber = carNumber;
			this.carSafetyHeight = carSafetyHeight;
			this.maxCarSpeed = maxCarSpeed;
			this.sparseCars = sparseCars;
			this.differentWays = differentWays;
			this.enabledLidarCells = enabledLidarCells;
			this.enabledCount = enabledCount;
			this.lanesLidar = lanesLidar;
			this.aheadLidar = aheadLidar;
			this.behindLidar = behindLidar;
			this.lanesSide = lanesSide;
			this.patchesAhead = patchesAhead;
			this.patchesBehind = patchesBehind;
			if (enabledLidarCells == null)
			{
				SetDefaultLidars();
			}
		}

		public object Clone()
		{
			return new DeepTrafficEnvPresets(height, width, carHeight, baseCarSpeed, changeXThreshold, changeYThreshold, changeSpeedThreshold, maxLanesSide, maxPatchesAhead, maxPatchesBehind, carNumber, carSafetyHeight, maxCarSpeed, sparseCars, differentWays, (enabledLidarCells == null) ? null : ((bool[])enabledLidarCells.Clone()), enabledCount, (lanesLidar == null) ? null : ((LidarData)lanesLidar.Clone()), (aheadLidar == null) ? null : ((LidarData)aheadLidar.Clone()), (behindLidar == null) ? null : ((LidarData)behindLidar.Clone()), lanesSide, patchesAhead, patchesBehind)
			{
				KeyName = (string)KeyName.Clone()
			};
		}
	}
}
