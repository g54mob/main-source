using System.Collections.Generic;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class MissingLicensesPageTemplatePaperData : TemplatePaperData
	{
		public class LicensePrintData
		{
			public string licenseName;

			public Sprite licenseIcon;

			public bool isAcquired;

			public LicensePrintData(string licenseName, Sprite licenseIcon, bool isAcquired)
			{
				this.licenseName = licenseName;
				this.licenseIcon = licenseIcon;
				this.isAcquired = isAcquired;
			}
		}

		public string jobType;

		public string jobSubtype;

		public string jobId;

		public Color jobTypeColor;

		public List<LicensePrintData> licensesData;

		public MissingLicensesPageTemplatePaperData(string jobType, string jobSubtype, string jobId, Color jobTypeColor, List<LicensePrintData> licensesData)
		{
			this.jobType = jobType;
			this.jobSubtype = jobSubtype;
			this.jobId = jobId;
			this.jobTypeColor = jobTypeColor;
			this.licensesData = licensesData;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.MissingLicense;
		}
	}
}
