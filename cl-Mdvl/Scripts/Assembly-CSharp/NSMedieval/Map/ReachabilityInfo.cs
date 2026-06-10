using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Model;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Map
{
	[Serializable]
	[FVSerializableKey("ReachabilityInfo", "")]
	public class ReachabilityInfo : IFVSerializable
	{
		[SerializeField]
		private IntRange yRange;

		[SerializeField]
		private WorldDirection[] direction;

		public IntRange YRange => yRange;

		public ReachabilityInfo(IntRange yRange, WorldDirection defaultDirections)
		{
			this.yRange = null;
			direction = null;
			InitReachability(yRange);
			SetReachabilityAll(defaultDirections);
		}

		public ReachabilityInfo(IntRange yRange)
		{
			this.yRange = null;
			direction = null;
			InitReachability(yRange);
		}

		public WorldDirection GetReachability(int yPos = 0)
		{
			int num = ConvertOffsetYPosToDataIndex(yPos);
			if (num < 0)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Reachability\\ReachabilityInfo.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Direction for Y ");
					messageBuilder.AppendFormatted(yPos);
					messageBuilder.AppendLiteral(" not found! 1");
				}
				Log.Error(messageBuilder);
				return WorldDirection.None;
			}
			return direction[num];
		}

		public void SetReachability(WorldDirection direction, int yPos)
		{
			int num = ConvertOffsetYPosToDataIndex(yPos);
			if (num < 0)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Reachability\\ReachabilityInfo.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Direction for Y ");
					messageBuilder.AppendFormatted(yPos);
					messageBuilder.AppendLiteral(" not found! 2");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				this.direction[num] = direction;
			}
		}

		public void SetReachabilityAll(WorldDirection direction)
		{
			for (int i = 0; i < this.direction.Length; i++)
			{
				this.direction[i] = direction;
			}
		}

		public void ForEachYAccess(Action<int, WorldDirection> callback)
		{
			if (direction != null && direction.Length != 0)
			{
				for (int i = 0; i < direction.Length; i++)
				{
					callback(ConvartDataIndexToOffsetYPos(i), direction[i]);
				}
			}
		}

		private int ConvertOffsetYPosToDataIndex(int yPos)
		{
			return yPos + Math.Abs(yRange.Min);
		}

		private int ConvartDataIndexToOffsetYPos(int index)
		{
			return index - Math.Abs(yRange.Min);
		}

		private void InitReachability(IntRange yRange)
		{
			if (yRange == null)
			{
				this.yRange = new IntRange(0, 0);
			}
			else
			{
				this.yRange = yRange;
			}
			if (this.yRange.Min > 0)
			{
				Log.Error("Range.Min > 0", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Reachability\\ReachabilityInfo.cs");
			}
			int num = Math.Abs(this.yRange.Min) + this.yRange.Max + 1;
			direction = new WorldDirection[num];
			for (int i = this.yRange.Min; i <= this.yRange.Max; i++)
			{
				int num2 = ConvertOffsetYPosToDataIndex(i);
				direction[num2] = WorldDirection.AllHorizontal;
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("yRange", yRange);
			serializer.WriteEnum("direction", direction);
		}

		public ReachabilityInfo(FVDeserializer deserializer)
		{
			yRange = deserializer.ReadObject<IntRange>("yRange");
			direction = deserializer.ReadEnumArray<WorldDirection>("direction");
		}
	}
}
