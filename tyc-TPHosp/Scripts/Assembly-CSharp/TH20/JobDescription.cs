using System;
using UnityEngine;

namespace TH20
{
	public abstract class JobDescription : IEquatable<JobDescription>
	{
		public abstract Sprite GetIcon();

		public abstract bool IsSuitable(Staff staff);

		public abstract bool MatchesJob(Job job);

		public abstract string ToLocalisedString();

		public virtual Sprite GetJobAssignmentIcon()
		{
			return GetIcon();
		}

		public virtual bool Equals(JobDescription other)
		{
			return true;
		}

		public virtual string GetJobAssignmentTooltipString()
		{
			return ToLocalisedString();
		}

		public virtual string RequiredQualificationString()
		{
			return string.Empty;
		}
	}
}
