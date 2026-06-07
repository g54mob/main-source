using System;

namespace Jundroo.SocialPlatforms
{
	public interface IAchievement
	{
		bool completed { get; }

		bool hidden { get; }

		string id { get; set; }

		DateTime lastReportedDate { get; }

		double percentCompleted { get; set; }

		void ReportProgress(Action<bool> callback);
	}
}
