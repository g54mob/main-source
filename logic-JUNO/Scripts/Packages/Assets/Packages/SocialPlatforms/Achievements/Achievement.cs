using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Packages.SocialPlatforms.Achievements
{
	public class Achievement : IAchievement
	{
		public virtual bool completed => percentCompleted >= 100.0;

		public virtual bool hidden { get; set; }

		public virtual string id { get; set; }

		public virtual DateTime lastReportedDate { get; set; }

		public virtual double percentCompleted { get; set; }

		public virtual void ReportProgress(Action<bool> callback)
		{
			Social.ReportProgress(id, percentCompleted, callback);
		}

		public override string ToString()
		{
			return string.Format("Achievement '{0}'{1} - {2}% ({3})", string.IsNullOrEmpty(id) ? "(null)" : id, hidden ? " (hidden)" : string.Empty, percentCompleted.ToString("F2"), lastReportedDate.ToString("yyyy/MM/dd HH:mm:ss"));
		}
	}
}
