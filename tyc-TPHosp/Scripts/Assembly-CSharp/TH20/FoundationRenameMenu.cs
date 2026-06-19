using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class FoundationRenameMenu : AnimatedMenuBase
	{
		[SerializeField]
		private InputField _foundationNameInput;

		[SerializeField]
		private DynamicButton _acceptButton;

		private Metagame _metagame;

		public void Setup(Metagame metagame)
		{
			_metagame = metagame;
			_acceptButton.onPrimaryDown.AddListener(AcceptButtonClicked);
			_foundationNameInput.text = _metagame.OrganisationName;
			Text text = _foundationNameInput.placeholder as Text;
			if (text != null)
			{
				text.text = _metagame.OrganisationName;
			}
		}

		private void AcceptButtonClicked()
		{
			ApplyNameAndClose();
		}

		private void ApplyNameAndClose()
		{
			if (!IsClosing())
			{
				if (NameIsValid(_foundationNameInput.text.Trim()))
				{
					_metagame.OrganisationName = _foundationNameInput.text.Trim();
				}
				CloseMenu();
			}
		}

		private static bool NameIsValid(string newName)
		{
			return !string.IsNullOrWhiteSpace(newName);
		}
	}
}
