using UnityEngine;

namespace UI
{
	public class TutorialSelectDialog : BaseDialog
	{
		[SerializeField]
		private RectTransform tutorialContent;

		[SerializeField]
		private ChoiceTutorialRow tutorialRowPrefab;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		public void CreateTutorialRow()
		{
		}

		public override void Back()
		{
		}

		public override void SetInFront()
		{
		}
	}
}
