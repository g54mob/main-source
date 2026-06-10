using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Construction;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class ReservablePositionsComponentInstance
	{
		private object reservedUsePositionLock = new object();

		private List<ReservablePosition> reservablePositions = new List<ReservablePosition>();

		public bool HasMultiPositions
		{
			get
			{
				lock (reservedUsePositionLock)
				{
					return reservablePositions.Count > 0;
				}
			}
		}

		public int FreeSpace
		{
			get
			{
				lock (reservedUsePositionLock)
				{
					return reservablePositions.Count;
				}
			}
		}

		public List<ReservablePosition> ReservablePositions
		{
			get
			{
				lock (reservedUsePositionLock)
				{
					return reservablePositions;
				}
			}
		}

		public void SetupReservablePositions(List<Transform> usePositionGameObjects)
		{
			if (usePositionGameObjects == null)
			{
				return;
			}
			if (reservedUsePositionLock == null)
			{
				reservedUsePositionLock = new object();
			}
			lock (reservedUsePositionLock)
			{
				if (reservablePositions == null)
				{
					reservablePositions = new List<ReservablePosition>();
				}
				else
				{
					reservablePositions.Clear();
				}
				foreach (Transform usePositionGameObject in usePositionGameObjects)
				{
					Vec3Int gridPosition = GridUtils.GetGridPosition(usePositionGameObject.position);
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\ComponentMisc\\ReservablePositionsComponentInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Set Reservable position: ");
						messageBuilder.AppendFormatted(gridPosition);
					}
					Log.Debug(messageBuilder);
					reservablePositions.Add(new ReservablePosition(gridPosition));
				}
			}
		}
	}
}
