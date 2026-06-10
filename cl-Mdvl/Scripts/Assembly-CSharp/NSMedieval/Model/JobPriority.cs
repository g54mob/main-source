using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.State.WorkerJobs;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class JobPriority : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string[] jobTypes;

		[NonSerialized]
		private JobType[] jobsByPriority;

		public JobType[] JobsByPriority
		{
			get
			{
				if (jobsByPriority != null)
				{
					return jobsByPriority;
				}
				jobsByPriority = new JobType[jobTypes.Length];
				for (int i = 0; i < jobTypes.Length; i++)
				{
					try
					{
						JobType jobType = (JobType)Enum.Parse(typeof(JobType), jobTypes[i]);
						jobsByPriority[i] = jobType;
					}
					catch (Exception value)
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Blueprint\\GOAP\\JobPriority.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Failed to parse job type ");
							messageBuilder.AppendFormatted(jobTypes[i]);
						}
						Log.Error(messageBuilder);
						Console.WriteLine(value);
						throw;
					}
				}
				return jobsByPriority;
			}
		}

		public override string GetID()
		{
			return id;
		}
	}
}
