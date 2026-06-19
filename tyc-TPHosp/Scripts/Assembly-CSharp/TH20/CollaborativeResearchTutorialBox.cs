using I2.Loc;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchTutorialBox : MonoBehaviour
	{
		[SerializeField]
		private Localize _titleText;

		[SerializeField]
		private Localize _bodyText;

		[SerializeField]
		private DynamicButton _button;

		private CollaborativeMetagameData _metagameData;

		private CollaborativeProjectList _projectList;

		private void OnEnable()
		{
			_button.onPrimaryDown.AddListener(OnButtonPressed);
		}

		private void OnDisable()
		{
			_button.onPrimaryDown.RemoveListener(OnButtonPressed);
		}

		public void Initialise(App app)
		{
			_metagameData = app.Metagame.CollaborativeMetagameData;
			_projectList = app.CollaborativeProjectList;
		}

		public void Show(CollaborativeMetagameData.TutorialType tutorialType)
		{
			if (_projectList.TutorialData.TryGetValue(tutorialType, out var value))
			{
				_metagameData.OnSeenTutorial(tutorialType);
				_titleText.SetTerm(value.Title.Term);
				_bodyText.SetTerm(value.Body.Term);
				GameObjectUtils.SetActive(base.gameObject, isActive: true);
			}
		}

		private void OnButtonPressed()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}
	}
}
