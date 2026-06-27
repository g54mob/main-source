using System;
using System.Collections.Generic;
using Restory.Gameplay.EmailSystems;
using Restory.Utils;
using UnityEngine;

namespace Restory.UI.Presenters
{
	public sealed class GUI_MailClientFoldersPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_MailClientFolderButton[] folderButtons = new GUI_MailClientFolderButton[0];

		private EmailFolders currentlySelectedFolder;

		public EmailFolders CurrentlySelectedFolder => currentlySelectedFolder;

		public event Action OnFolderSelectionChanged;

		private void OnDisable()
		{
			GUI_MailClientFolderButton[] array = folderButtons;
			foreach (GUI_MailClientFolderButton gUI_MailClientFolderButton in array)
			{
				if (gUI_MailClientFolderButton.MonoShellExists())
				{
					gUI_MailClientFolderButton.OnButtonClicked -= ResolveFolderButtonClicked;
				}
			}
		}

		public void Activate()
		{
			GUI_MailClientFolderButton[] array = folderButtons;
			foreach (GUI_MailClientFolderButton gUI_MailClientFolderButton in array)
			{
				if ((bool)gUI_MailClientFolderButton)
				{
					gUI_MailClientFolderButton.Activate();
					gUI_MailClientFolderButton.OnButtonClicked += ResolveFolderButtonClicked;
				}
			}
		}

		public void Deactivate()
		{
			GUI_MailClientFolderButton[] array = folderButtons;
			foreach (GUI_MailClientFolderButton gUI_MailClientFolderButton in array)
			{
				if ((bool)gUI_MailClientFolderButton)
				{
					gUI_MailClientFolderButton.Deactivate();
					gUI_MailClientFolderButton.OnButtonClicked -= ResolveFolderButtonClicked;
				}
			}
		}

		public void UpdateUnreadMessagesInFolders(IDictionary<EmailFolders, int> unreadEmailsInFolders)
		{
			GUI_MailClientFolderButton[] array = folderButtons;
			foreach (GUI_MailClientFolderButton gUI_MailClientFolderButton in array)
			{
				if ((bool)gUI_MailClientFolderButton && gUI_MailClientFolderButton.EmailFolder != EmailFolders.OrdersTaken && unreadEmailsInFolders.TryGetValue(gUI_MailClientFolderButton.EmailFolder, out var value))
				{
					gUI_MailClientFolderButton.UpdateFolderContents(value);
				}
			}
		}

		public void UpdateOrdersInProgressCountInTakenOrdersFolder(int ordersInProgressCount)
		{
			GUI_MailClientFolderButton[] array = folderButtons;
			foreach (GUI_MailClientFolderButton gUI_MailClientFolderButton in array)
			{
				if ((bool)gUI_MailClientFolderButton && gUI_MailClientFolderButton.EmailFolder == EmailFolders.OrdersTaken)
				{
					gUI_MailClientFolderButton.UpdateFolderContents(ordersInProgressCount);
				}
			}
		}

		public void SetInitialState()
		{
			GUI_MailClientFolderButton[] array = folderButtons;
			foreach (GUI_MailClientFolderButton obj in array)
			{
				obj.ChangeSelection(obj.EmailFolder == EmailFolders.OrdersInbox);
			}
			currentlySelectedFolder = EmailFolders.OrdersInbox;
		}

		private void ResolveFolderButtonClicked(GUI_MailClientFolderButton clickedFolderButton)
		{
			if (clickedFolderButton.EmailFolder == currentlySelectedFolder)
			{
				return;
			}
			clickedFolderButton.ChangeSelection(shouldBeSelected: true);
			GUI_MailClientFolderButton[] array = folderButtons;
			foreach (GUI_MailClientFolderButton gUI_MailClientFolderButton in array)
			{
				if (gUI_MailClientFolderButton.EmailFolder == currentlySelectedFolder)
				{
					gUI_MailClientFolderButton.ChangeSelection(shouldBeSelected: false);
				}
			}
			currentlySelectedFolder = clickedFolderButton.EmailFolder;
			this.OnFolderSelectionChanged?.Invoke();
		}
	}
}
