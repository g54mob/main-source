using Dorfromantik.UI.Components;
using UnityEngine;

namespace Dorfromantik
{
	public class ChallengeInfoSection : MonoBehaviour
	{
		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private GameObject hideableContent;

		[SerializeField]
		private UiIconButtonSimple expandButton;

		[SerializeField]
		private UiIconButtonSimple collapseButton;

		private void Start()
		{
			UpdateVisibilityState();
		}

		public void SetVisibilityState(bool expand)
		{
			settingsRouter.SetChallengeInfoSectionExpanded(expand);
			UpdateVisibilityState();
		}

		private void UpdateVisibilityState()
		{
			hideableContent.SetActive(settingsRouter.IsChallengeInfoSectionExpanded);
			expandButton.gameObject.SetActive(!settingsRouter.IsChallengeInfoSectionExpanded);
			collapseButton.gameObject.SetActive(settingsRouter.IsChallengeInfoSectionExpanded);
		}
	}
}
