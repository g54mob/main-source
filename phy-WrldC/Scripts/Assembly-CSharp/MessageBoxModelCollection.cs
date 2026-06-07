public static class MessageBoxModelCollection
{
	private static MessageBoxModel returnToMainMenu;

	private static MessageBoxModel returnToMainMenuFromLevelTest;

	private static MessageBoxModel returnToMainMenuFromLevelEditor;

	private static MessageBoxModel returnToLevelEditorFromConstructionMode;

	public static MessageBoxModel ReturnToMainMenu
	{
		get
		{
			string text = LanguagesManager.Instance.GetText("message.header.menu.return", "Return to Main Menu");
			string text2 = LanguagesManager.Instance.GetText("message.info.menu.return", "Exit to Main Menu?");
			if (returnToMainMenu == null)
			{
				returnToMainMenu = new MessageBoxModel
				{
					HeaderText = text,
					InfoText = text2,
					ConfirmAction = delegate
					{
						GameManager.Instance.CameraManager.SaveMainCameraStatus(GameManager.Instance.MainCreationController.model);
						GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
						{
							GameManager.Instance.ClearAllCreations();
							GameManager.Instance.UnloadCurrentLevel();
							GameManager.Instance.ChangeState(MenuState.Instance);
						});
					}
				};
			}
			returnToMainMenu.HeaderText = text;
			returnToMainMenu.InfoText = text2;
			return returnToMainMenu;
		}
	}

	public static MessageBoxModel ReturnToMainMenuFromLevelTest
	{
		get
		{
			var (headerText, infoText) = GetTextsForReturnToMainMenuFromLevelEditor();
			if (returnToMainMenuFromLevelTest == null)
			{
				returnToMainMenuFromLevelTest = new MessageBoxModel
				{
					HeaderText = headerText,
					InfoText = infoText,
					ConfirmAction = delegate
					{
						GameManager.Instance.CameraManager.SaveMainCameraStatus(GameManager.Instance.MainCreationController.model);
						GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
						{
							GameManager.Instance.CameraManager.RestoresMainCamera();
							GameManager.Instance.ClearAllCreations();
							GameManager.Instance.UnloadCurrentLevel();
							GameManager.Instance.ChangeState(MenuState.Instance);
						});
					}
				};
			}
			returnToMainMenuFromLevelTest.HeaderText = headerText;
			returnToMainMenuFromLevelTest.InfoText = infoText;
			return returnToMainMenuFromLevelTest;
		}
	}

	public static MessageBoxModel ReturnToMainMenuFromLevelEditor
	{
		get
		{
			var (headerText, infoText) = GetTextsForReturnToMainMenuFromLevelEditor();
			if (returnToMainMenuFromLevelEditor == null)
			{
				returnToMainMenuFromLevelEditor = new MessageBoxModel
				{
					HeaderText = headerText,
					InfoText = infoText,
					ConfirmAction = delegate
					{
						GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
						{
							GameManager.Instance.ChangeState(MenuState.Instance);
						});
					}
				};
			}
			returnToMainMenuFromLevelEditor.HeaderText = headerText;
			returnToMainMenuFromLevelEditor.InfoText = infoText;
			return returnToMainMenuFromLevelEditor;
		}
	}

	public static MessageBoxModel ReturnToLevelEditorFromConstructionMode
	{
		get
		{
			string text = LanguagesManager.Instance.GetText("message.header.leveleditor.return", "Return to Level Editor");
			string text2 = LanguagesManager.Instance.GetText("message.info.leveleditor.return", "Exit to Level Editor?");
			if (returnToLevelEditorFromConstructionMode == null)
			{
				returnToLevelEditorFromConstructionMode = new MessageBoxModel
				{
					HeaderText = text,
					InfoText = text2,
					ConfirmAction = delegate
					{
						GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
						{
							GameManager.Instance.ClearAllCreations();
							GameManager.Instance.UnloadCurrentLevel();
							GameManager.Instance.LoadLevelEditorAndChangeState(LevelEditorState.Instance);
						});
					}
				};
			}
			returnToLevelEditorFromConstructionMode.HeaderText = text;
			returnToLevelEditorFromConstructionMode.InfoText = text2;
			return returnToLevelEditorFromConstructionMode;
		}
	}

	private static (string, string) GetTextsForReturnToMainMenuFromLevelEditor()
	{
		string text = LanguagesManager.Instance.GetText("message.header.leveleditor.return_menu", "Return to Main Menu");
		string text2 = LanguagesManager.Instance.GetText("message.info.leveleditor.return_menu", "Exit to Main Menu?\nUnsaved changes will be lost!");
		return (text, text2);
	}
}
