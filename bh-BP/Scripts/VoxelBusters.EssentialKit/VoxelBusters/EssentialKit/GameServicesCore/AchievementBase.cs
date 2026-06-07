using System;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	public abstract class AchievementBase : NativeObjectBase, IAchievement
	{
		public string Id { get; internal set; }

		public string PlatformId { get; internal set; }

		public double PercentageCompleted
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public bool IsCompleted => false;

		public DateTime LastReportedDate => default(DateTime);

		protected AchievementBase(string id, string platformId)
		{
		}

		protected abstract double GetPercentageCompletedInternal();

		protected abstract void SetPercentageCompletedInternal(double value);

		protected abstract bool GetIsCompletedInternal();

		protected abstract DateTime GetLastReportedDateInternal();

		protected abstract void ReportProgressInternal(ReportAchievementProgressInternalCallback callback);

		public override string ToString()
		{
			return null;
		}

		public void ReportProgress(CompletionCallback callback)
		{
		}
	}
}
