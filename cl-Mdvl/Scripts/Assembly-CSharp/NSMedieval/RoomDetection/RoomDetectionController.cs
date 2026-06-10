using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;

namespace NSMedieval.RoomDetection
{
	public class RoomDetectionController : MonoSingleton<RoomDetectionController>
	{
		public event Action<Room, RoomType> RoomTypeChangedEvent;

		public event Action<Room, bool> RoomTypeRecalculatedEvent;

		public event Action<Room, RoomType> RoomAddedEvent;

		public event Action<Room> RoomRemovedEvent;

		public event Action<Room> RoomThermalParametersUpdatedEvent;

		public event Action<Room, int> RoomImpressivenessScoreChangedEvent;

		public event Action<Room, RoomImpressivenessSettings.Setting> RoomImpressivenessChangedEvent;

		public event Action SingleOwnerRoomsChangedEvent;

		public event Action<RoomType> RoomTypeUnlockedEvent;

		public void RoomAdded(Room room, RoomType previousType)
		{
			Log.Info("RoomAdded", "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetectionController.cs");
			this.RoomAddedEvent?.Invoke(room, previousType);
		}

		public void RoomRemoved(Room room)
		{
			Log.Info("RoomRemoved", "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetectionController.cs");
			this.RoomRemovedEvent?.Invoke(room);
		}

		public void RoomTypeChanged(Room room, RoomType previousType)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetectionController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("RoomTypeChanged ");
				messageBuilder.AppendFormatted(previousType);
				messageBuilder.AppendLiteral(" => ");
				messageBuilder.AppendFormatted(room.RoomType);
			}
			Log.Info(messageBuilder);
			this.RoomTypeChangedEvent?.Invoke(room, previousType);
		}

		public void RoomTypeRecalculated(Room room, bool wasRoomTypeChanged)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetectionController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("RoomTypeRecalculated ");
				messageBuilder.AppendFormatted(room);
			}
			Log.Info(messageBuilder);
			this.RoomTypeRecalculatedEvent?.Invoke(room, wasRoomTypeChanged);
		}

		public void RoomThermalParametersUpdated(Room room)
		{
			this.RoomThermalParametersUpdatedEvent?.Invoke(room);
		}

		public void RoomImpressivenessScoreChanged(Room room, int prevImpressivenessScore)
		{
			this.RoomImpressivenessScoreChangedEvent?.Invoke(room, prevImpressivenessScore);
		}

		public void RoomImpressivenessChanged(Room room, RoomImpressivenessSettings.Setting prevImpressiveness)
		{
			this.RoomImpressivenessChangedEvent?.Invoke(room, prevImpressiveness);
		}

		public void SingleOwnerRoomsChanged()
		{
			this.SingleOwnerRoomsChangedEvent?.Invoke();
		}

		public void RoomTypeUnlocked(RoomType roomTypeUnlocked)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetectionController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("RoomTypeUnlocked ");
				messageBuilder.AppendFormatted(roomTypeUnlocked);
			}
			Log.Info(messageBuilder);
			this.RoomTypeUnlockedEvent?.Invoke(roomTypeUnlocked);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.SingleOwnerRoomsChangedEvent = null;
			this.RoomTypeUnlockedEvent = null;
			this.RoomRemovedEvent = null;
			this.RoomThermalParametersUpdatedEvent = null;
			this.RoomTypeChangedEvent = null;
			this.RoomTypeRecalculatedEvent = null;
			this.RoomAddedEvent = null;
			this.RoomImpressivenessScoreChangedEvent = null;
			this.RoomImpressivenessChangedEvent = null;
		}
	}
}
