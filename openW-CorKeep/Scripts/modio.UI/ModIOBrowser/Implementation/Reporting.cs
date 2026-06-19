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
			Panel.SetActive(value: false);
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(defaultSelectableOnReportClose);
		}

		public void Open(ModProfile modToReport, Selectable selectableOnClose)
		{
			defaultSelectableOnReportClose = selectableOnClose;
			Browser.currentFocusedPanel = Panel;
			modBeingReported = modToReport;
			HideReportPanelObjects();
			Panel.SetActive(value: true);
			ReportPanelReportOptions.SetActive(value: true);
			ReportPanelText.gameObject.SetActive(value: true);
			Translation.Get(ReportPanelHeaderTranslation, "Report a problem", ReportPanelHeader);
			ReportPanelSubHeader.text = "'" + modBeingReported.name + "'";
			Translation.Get(ReportPanelTextTranslation, "Report content violating the sites Terms of Use or submit a DMCA complaint using the form below. Make sure you include all relevant information and links. If you’d like to report Copyright Infringement and are the Copyright holder, select ‘DMCA’ below.", ReportPanelText);
			ReportPanelSubHeader.ForceMeshUpdate();
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.Report);
			ReportPanelButtons.SetActive(value: true);
			ReportPanelCancelButton.gameObject.SetActive(value: true);
		}

		public void OpenEmail()
		{
			HideReportPanelObjects();
			Panel.SetActive(value: true);
			ReportPanelText.gameObject.SetActive(value: true);
			Translation.Get(ReportPanelTextTranslation, "Your email may be shared with moderators and the person that posted the allegedly infringing content you are reporting.", ReportPanelText);
			ReportPanelEmailSection.SetActive(value: true);
			ReportPanelButtons.SetActive(value: true);
			ReportPanelBackButton.gameObject.SetActive(value: true);
			ReportPanelBackButton.gameObject.SetActive(value: true);
			ReportPanelBackButton.onClick.RemoveAllListeners();
			ReportPanelBackButton.onClick.AddListener(delegate
			{
				Open(modBeingReported, defaultSelectableOnReportClose);
			});
			ReportPanelNextButton.gameObject.SetActive(value: true);
			ReportPanelCancelButton.gameObject.SetActive(value: true);
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(ReportPanelEmailField);
		}

		public void OpenDetails()
		{
			HideReportPanelObjects();
			Panel.SetActive(value: true);
			ReportPanelCaption.gameObject.SetActive(value: true);
			Translation.Get(ReportPanelCaptionTranslation, "Details of infringement", ReportPanelCaption);
			ReportPanelText.gameObject.SetActive(value: true);
			Translation.Get(ReportPanelTextTranslation, "To help us process your report, please provide as much detail and evidence as possible.", ReportPanelText);
			ReportPanelDetailsSection.SetActive(value: true);
			ReportPanelDetailsField.text = "";
			ReportPanelButtons.SetActive(value: true);
			ReportPanelBackButton.gameObject.SetActive(value: true);
			ReportPanelBackButton.gameObject.SetActive(value: true);
			ReportPanelBackButton.onClick.RemoveAllListeners();
			ReportPanelBackButton.onClick.AddListener(OpenEmail);
			ReportPanelSubmitButton.gameObject.SetActive(value: true);
			ReportPanelSubmitButton.onClick.RemoveAllListeners();
			ReportPanelSubmitButton.onClick.AddListener(OpenSummary);
			ReportPanelCancelButton.gameObject.SetActive(value: true);
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(ReportPanelDetailsField);
		}

		public void OpenSummary()
		{
			HideReportPanelObjects();
			Panel.SetActive(value: true);
			ReportPanelSummary.SetActive(value: true);
			ReportPanelSummaryEmail.gameObject.SetActive(value: true);
			ReportPanelSummaryEmail.text = ReportPanelEmailField.text;
			ReportPanelSummaryReason.gameObject.SetActive(value: true);
			ReportPanelSummaryReason.text = reportType.ToString();
			ReportPanelSummaryDetails.gameObject.SetActive(value: true);
			ReportPanelSummaryDetails.text = ReportPanelDetailsField.text;
			ReportPanelButtons.SetActive(value: true);
			ReportPanelBackButton.gameObject.SetActive(value: true);
			ReportPanelBackButton.onClick.RemoveAllListeners();
			ReportPanelBackButton.onClick.AddListener(OpenDetails);
			ReportPanelSubmitButton.gameObject.SetActive(value: true);
			ReportPanelSubmitButton.onClick.RemoveAllListeners();
			ReportPanelSubmitButton.onClick.AddListener(Send);
			ReportPanelCancelButton.gameObject.SetActive(value: true);
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(ReportPanelSubmitButton);
		}

		public void OpenDone()
		{
			HideReportPanelObjects();
			Panel.SetActive(value: true);
			ReportPanelText.gameObject.SetActive(value: true);
			Translation.Get(ReportPanelTextTranslation, "The mod has been reported. A confirmation email will be sent to you shortly with the details and the moderators of the mod will be notified.", ReportPanelText);
			ReportPanelButtons.SetActive(value: true);
			ReportPanelDoneButton.gameObject.SetActive(value: true);
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(ReportPanelDoneButton);
		}

		public void OpenWaiting()
		{
			HideReportPanelObjects();
			Panel.SetActive(value: true);
			ReportPanelButtons.SetActive(value: true);
			ReportPanelLoadingAnimation.SetActive(value: true);
		}

		public void OpenProblem()
		{
			HideReportPanelObjects();
			Panel.SetActive(value: true);
			ReportPanelText.gameObject.SetActive(value: true);
			TextAlignmentOptions alignment = ReportPanelText.alignment;
			alignment = TextAlignmentOptions.Center;
			ReportPanelText.alignment = alignment;
			Translation.Get(ReportPanelTextTranslation, "Something went wrong when trying to send your report.", ReportPanelText);
			ReportPanelButtons.SetActive(value: true);
			ReportPanelCancelButton.gameObject.SetActive(value: true);
		}

		public void SetReportType(int type)
		{
			reportType = (ReportType)type;
		}

		public void HideReportPanelObjects()
		{
			TextAlignmentOptions alignment = ReportPanelText.alignment;
			alignment = TextAlignmentOptions.Left;
			ReportPanelText.alignment = alignment;
			ReportPanelEmailSection.SetActive(value: false);
			ReportPanelSubSubHeader.gameObject.SetActive(value: false);
			ReportPanelText.gameObject.SetActive(value: false);
			ReportPanelCaption.gameObject.SetActive(value: false);
			ReportPanelReportOptions.SetActive(value: false);
			ReportPanelDetailsSection.SetActive(value: false);
			ReportPanelSummary.SetActive(value: false);
			ReportPanelButtons.SetActive(value: false);
			ReportPanelBackButton.gameObject.SetActive(value: false);
			ReportPanelNextButton.gameObject.SetActive(value: false);
			ReportPanelCancelButton.gameObject.SetActive(value: false);
			ReportPanelDoneButton.gameObject.SetActive(value: false);
			ReportPanelSubmitButton.gameObject.SetActive(value: false);
			ReportPanelLoadingAnimation.SetActive(value: false);
		}

		public void Send()
		{
			OpenWaiting();
			ModIOUnity.Report(new Report(modBeingReported.id, reportType, ReportPanelDetailsField.text, "Unknown", ReportPanelEmailField.text), Sent);
		}

		private void Sent(Result result)
		{
			if (result.Succeeded())
			{
				OpenDone();
			}
			else
			{
				OpenProblem();
			}
		}
	}
}
