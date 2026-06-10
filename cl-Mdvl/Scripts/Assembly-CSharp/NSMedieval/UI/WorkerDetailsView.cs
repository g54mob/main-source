using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WorkerDetailsView : UIView
	{
		[SerializeField]
		private TMP_Text workerNameLabel;

		[SerializeField]
		private TMP_Text backstoryTitle;

		[SerializeField]
		private TMP_Text pseudonymTitle;

		[SerializeField]
		private AlignmentLayoutItemView religiousAlignment;

		[SerializeField]
		private TMP_Text ageLabel;

		[SerializeField]
		private TMP_Text heightLabel;

		[SerializeField]
		private TMP_Text weightLabel;

		[SerializeField]
		private LayoutGroupView skillsGroup;

		[SerializeField]
		private JobPreferencesPanelView jobPreferencesPanelView;

		[SerializeField]
		private LayoutGroupView perksGroup;

		public TMP_Text WorkerNameLabel => workerNameLabel;

		public TMP_Text BackstoryTitle => backstoryTitle;

		public TMP_Text PseudonymTitle => pseudonymTitle;

		public AlignmentLayoutItemView ReligiousAlignment => religiousAlignment;

		public TMP_Text AgeLabel => ageLabel;

		public TMP_Text HeightLabel => heightLabel;

		public TMP_Text WeightLabel => weightLabel;

		public LayoutGroupView SkillsGroup => skillsGroup;

		public LayoutGroupView PerksGroup => perksGroup;

		public JobPreferencesPanelView PreferencesPanelView => jobPreferencesPanelView;

		public void SetPseudonymTitle(HumanoidInstance humanoid)
		{
			string pseudonymId = humanoid.Info.PseudonymId;
			PseudonymTitle.transform.parent.gameObject.SetActive(pseudonymId != string.Empty);
			if (!(pseudonymId == string.Empty))
			{
				PseudonymTitle.SetText(HumanoidUtils.GetPseudonymLocalized(humanoid));
			}
		}
	}
}
