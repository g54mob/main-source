using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WorkerSkillsDetailsView : UIView
	{
		[SerializeField]
		private TMP_Text workerNameLabel;

		[SerializeField]
		private LayoutGroupView skillsGroup;

		public TMP_Text WorkerNameLabel => workerNameLabel;

		public LayoutGroupView SkillsGroup => skillsGroup;
	}
}
