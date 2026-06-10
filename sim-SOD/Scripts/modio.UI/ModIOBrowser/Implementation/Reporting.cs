using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class Reporting : SelfInstancingMonoSingleton<Reporting>
	{
		[SerializeField]
		public GameObject Panel;

		[SerializeField]
		private TMP_Text ReportPanelHeader;

		[SerializeField]
		private TMP_Text ReportPanelSubHeader;

		[SerializeField]
		private TMP_Text ReportPanelSubSubHeader;

		[SerializeField]
		private TMP_Text ReportPanelText;

		[SerializeField]
		private TMP_Text ReportPanelCaption;

		[SerializeField]
		private GameObject ReportPanelReportOptions;

		[SerializeField]
		private GameObject ReportPanelEmailSection;

		[SerializeField]
		private TMP_InputField ReportPanelEmailField;

		[SerializeField]
		private GameObject ReportPanelDetailsSection;

		[SerializeField]
		private TMP_InputField ReportPanelDetailsField;

		[SerializeField]
		private GameObject ReportPanelSummary;

		[SerializeField]
		private TMP_Text ReportPanelSummaryReason;

		[SerializeField]
		private TMP_Text ReportPanelSummaryEmail;

		[SerializeField]
		private TMP_Text ReportPanelSummaryDetails;

		[SerializeField]
		private GameObject ReportPanelButtons;

		[SerializeField]
		private Button ReportPanelBackButton;

		[SerializeField]
		private Button ReportPanelCancelButton;

		[SerializeField]
		private Button ReportPanelSubmitButton;

		[SerializeField]
		private Button ReportPanelNextButton;

		[SerializeField]
		private Button ReportPanelDoneButton;

		[SerializeField]
		private GameObject ReportPanelLoadingAnimation;

		internal Translation ReportPanelHeaderTranslation;

		internal Translation ReportPanelTextTranslation;

		internal Translation ReportPanelCaptionTranslation;

		private Selectable defaultSelectableOnReportClose;

		private ModProfile modBeingReported;

		private ReportType reportType;

		public void Close()
		{
		}

		public void Open(ModProfile modToReport, Selectable selectableOnClose)
		{
		}

		public void OpenEmail()
		{
		}

		public void OpenDetails()
		{
		}

		public void OpenSummary()
		{
		}

		public void OpenDone()
		{
		}

		public void OpenWaiting()
		{
		}

		public void OpenProblem()
		{
		}

		public void SetReportType(int type)
		{
		}

		public void HideReportPanelObjects()
		{
		}

		public void Send()
		{
		}

		private void Sent(Result result)
		{
		}
	}
}
