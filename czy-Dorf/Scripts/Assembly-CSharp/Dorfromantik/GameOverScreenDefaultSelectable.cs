using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	[RequireComponent(typeof(UiSelectable))]
	public class GameOverScreenDefaultSelectable : MonoBehaviour
	{
		[SerializeField]
		private SaveButton saveButton;

		[SerializeField]
		private Selectable tryAgainButton;

		private UiSelectable uiSelectable;

		private void Awake()
		{
			uiSelectable = GetComponent<UiSelectable>();
		}

		private void OnEnable()
		{
			saveButton.OnStateChanged += UpdateNavigation;
			UpdateNavigation();
		}

		private void UpdateNavigation()
		{
			Navigation navigation = uiSelectable.navigation;
			navigation.selectOnDown = (saveButton.Interactable ? saveButton.Button : tryAgainButton);
			navigation.selectOnLeft = (saveButton.Interactable ? saveButton.Button : tryAgainButton);
			navigation.selectOnRight = (saveButton.Interactable ? saveButton.Button : tryAgainButton);
			navigation.selectOnUp = (saveButton.Interactable ? saveButton.Button : tryAgainButton);
			uiSelectable.navigation = navigation;
		}

		private void OnDisable()
		{
			saveButton.OnStateChanged -= UpdateNavigation;
		}
	}
}
