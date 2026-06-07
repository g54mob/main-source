using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobExpiredTemplatePaperData : TemplatePaperData
	{
		public string jobType;

		public string jobSubtype;

		public string jobId;

		public Color jobTypeColor;

		public JobExpiredTemplatePaperData(string jobType, string jobSubtype, string jobId, Color jobTypeColor)
		{
			this.jobType = jobType;
			this.jobSubtype = jobSubtype;
			this.jobId = jobId;
			this.jobTypeColor = jobTypeColor;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.JobExpired;
		}
	}
}
