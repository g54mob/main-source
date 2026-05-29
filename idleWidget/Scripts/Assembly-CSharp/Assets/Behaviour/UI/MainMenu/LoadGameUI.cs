using Assets.Source.Util;

namespace Assets.Behaviour.UI.MainMenu
{
	public class LoadGameUI : SaveGameUI
	{
		private SaveGameFile _selectedFile;

		public override void ShowSaveGame(SaveGameFile file)
		{
			_selectedFile = file;
			foreach (SaveGameRow row in _rows)
			{
				row.SetHighlighted(file);
			}
		}

		public override void DoExecuteAction()
		{
			if (_selectedFile != null)
			{
				if ((bool)MainMenuUI.Instance)
				{
					MainMenuUI.Instance.DoLoadGame(_selectedFile);
				}
				else
				{
					GameUI.Instance.DoLoadGame(_selectedFile);
				}
			}
		}
	}
}
