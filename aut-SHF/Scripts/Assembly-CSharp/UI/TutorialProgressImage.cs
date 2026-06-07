using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class TutorialProgressImage : MonoBehaviour
	{
		public RectTransform rectTf;

		[SerializeField]
		private MagicCircleImage circle;

		[SerializeField]
		private Image checkMark;

		[SerializeField]
		private Image baseMark;

		[SerializeField]
		private ChoiceArrow choiceArrow;

		public bool IsNowPosition => false;

		public void Init(MagicCircleImage.CircleColor color, bool check, bool playTutorial)
		{
		}
	}
}
