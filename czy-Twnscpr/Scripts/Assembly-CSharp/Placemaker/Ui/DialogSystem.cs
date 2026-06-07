using System;
using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Ui
{
	public class DialogSystem : MonoBehaviour, UiMaster.IUiSetup
	{
		private UiMaster master;

		[SerializeField]
		private DialogWindow srcDialogWindow;

		[SerializeField]
		private Dim dialogDim;

		[SerializeField]
		private Transform dialogsContainer;

		[SerializeField]
		private List<DialogWindow> dialogPool;

		[SerializeField]
		private List<DialogWindow> activeDialogs;

		public void OnSetup(UiMaster master)
		{
		}

		public void OnStart(UiMaster master)
		{
		}

		private DialogWindow GetDialogFromPool()
		{
			return null;
		}

		private DialogWindow CreateNewDialog()
		{
			return null;
		}

		private void AddNewActiveDialog(DialogWindow dialog)
		{
		}

		public void DisableActiveDialog(DialogWindow dialog)
		{
		}

		public void ShowGameCoreDialog()
		{
		}

		public void ShowGamepadDisconnectedDialog()
		{
		}

		public void CloseGamepadDisconnectedDialog()
		{
		}

		public void GameSuspendedDialog(Action callback)
		{
		}

		public void UserLoggedOutDialog()
		{
		}
	}
}
