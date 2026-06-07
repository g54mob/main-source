using DV.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class ValidateJobTaskTemplatePaper : TemplatePaper
	{
		public ValidateJobTaskTemplatePaperData data;

		public TextMeshProUGUI stepNum;

		public Text pageNumber;

		public override void CleanUp()
		{
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for task page, but data was not set!", this);
				return;
			}
			stepNum.text = LocalizationAPI.L("job/task_step_no", data.stepNum);
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
		}
	}
}
