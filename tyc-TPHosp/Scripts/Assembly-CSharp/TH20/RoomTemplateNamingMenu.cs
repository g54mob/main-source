using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class RoomTemplateNamingMenu : AnimatedMenuBase
	{
		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private InputField _templateNameInput;

		[SerializeField]
		private DynamicButton _acceptButton;

		private Level _level;

		private RoomTemplate _roomTemplate;

		private InspectorSubItemRoomTemplatesList _templatesListMenu;

		public void Setup(Level level, RoomTemplate template, InspectorSubItemRoomTemplatesList templatesListMenu)
		{
			_level = level;
			_roomTemplate = template;
			_templatesListMenu = templatesListMenu;
			_acceptButton.onPrimaryDown.AddListener(AcceptButtonClicked);
			if (template != null)
			{
				_titleText.text = LocalizationManager.GetTranslation("Notification/RenameTemplate_Title_CS");
				_templateNameInput.text = _roomTemplate.UserDefinedName;
				Text text = _templateNameInput.placeholder as Text;
				if (text != null)
				{
					text.text = _roomTemplate.UserDefinedName;
				}
				return;
			}
			_titleText.text = LocalizationManager.GetTranslation("Notification/NameTemplate_Title_CS");
			string translation = LocalizationManager.GetTranslation("Notification/DefaultTemplateName_CS");
			_templateNameInput.text = translation;
			Text text2 = _templateNameInput.placeholder as Text;
			if (text2 != null)
			{
				text2.text = translation;
			}
		}

		private void AcceptButtonClicked()
		{
			ApplyNameAndClose();
		}

		private void ApplyNameAndClose()
		{
			if (IsClosing())
			{
				return;
			}
			string text = _templateNameInput.text.Trim();
			if (NameIsValid(text))
			{
				if (_roomTemplate != null)
				{
					_level.App.RoomTemplatesManager.RenameRoomTemplate(_roomTemplate, text);
				}
				else
				{
					_templatesListMenu.AddNewRoomTemplate(text);
				}
			}
			CloseMenu();
		}

		private static bool NameIsValid(string newName)
		{
			return newName.Length > 0;
		}
	}
}
