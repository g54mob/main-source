using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface IAchievement
	{
		string Id { get; }

		string PlatformId { get; }

		double PercentageCompleted { get; set; }

		bool IsCompleted { get; }

		DateTime LastReportedDate { get; }

		void ReportProgress(CompletionCallback callback);
	}
}
