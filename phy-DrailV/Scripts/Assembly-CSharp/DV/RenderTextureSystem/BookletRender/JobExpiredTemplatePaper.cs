using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobExpiredTemplatePaper : TemplatePaper
	{
		public JobExpiredTemplatePaperData data;

		public TextMeshProUGUI jobType;

		public TextMeshProUGUI jobSubtype;

		public TextMeshProUGUI jobId;

		public Image jobTypeBgColor;

		public override void CleanUp()
		{
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for expired page, but data was not set!", this);
				return;
			}
			jobType.text = data.jobType;
			jobSubtype.text = data.jobSubtype;
			jobId.text = data.jobId;
			jobTypeBgColor.color = data.jobTypeColor;
		}
	}
}
