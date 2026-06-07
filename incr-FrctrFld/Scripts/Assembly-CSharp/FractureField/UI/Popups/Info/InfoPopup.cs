using FractureField.UI.Components.Buttons;
using TMPro;
using UnityEngine;

namespace FractureField.UI.Popups.Info
{
	public class InfoPopup : Popup
	{
		[Header("References")]
		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _descriptionText;

		[SerializeField]
		private RButtonComponent _button;

		public void Open(string title, string description, string buttonText = null)
		{
		}

		public void ClickedOkay()
		{
		}
	}
}
