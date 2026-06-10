using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Goap
{
	[Serializable]
	public class ScheduleModel : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<ScheduleData> schedule;

		private Dictionary<HourType, ScheduleData> scheduleDataByHourTypeCache = new Dictionary<HourType, ScheduleData>();

		public List<ScheduleData> Schedule => schedule;

		public override string GetID()
		{
			return id;
		}

		public ScheduleData GetScheduleData(HourType hourType)
		{
			bool isEnabled;
			if (!scheduleDataByHourTypeCache.Any())
			{
				foreach (ScheduleData item in schedule)
				{
					if (scheduleDataByHourTypeCache.ContainsKey(item.HourType))
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(44, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Data\\ScheduleModel.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Hour type ");
							messageBuilder.AppendFormatted(item.HourType);
							messageBuilder.AppendLiteral(" already exists in schedule model ");
							messageBuilder.AppendFormatted(id);
						}
						Log.Error(messageBuilder);
					}
					else
					{
						scheduleDataByHourTypeCache.Add(item.HourType, item);
					}
				}
			}
			if (!scheduleDataByHourTypeCache.ContainsKey(hourType))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(59, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Data\\ScheduleModel.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot find schedule data for hour type ");
					messageBuilder.AppendFormatted(hourType);
					messageBuilder.AppendLiteral(" in schedule model ");
					messageBuilder.AppendFormatted(id);
				}
				Log.Error(messageBuilder);
				return default(ScheduleData);
			}
			return scheduleDataByHourTypeCache[hourType];
		}
	}
}
