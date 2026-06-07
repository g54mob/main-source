using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class CoverPageTemplatePaper : TemplatePaper
	{
		public CoverPageTemplatePaperData data;

		public TextMeshProUGUI jobId;

		public TextMeshProUGUI jobTypeLine;

		public Text pageNumber;

		public override void CleanUp()
		{
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for cover page, but data was not set!", this);
				return;
			}
			jobTypeLine.text = data.jobType;
			jobId.text = data.jobID;
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
		}
	}
}
