public class SaveFilesDeleteConfirmationDialog : TwoChoiceDialog
{
	private SaveFilesRow _saveFileRow;

	public string tid;

	public int heroOffsetY;

	public SaveFilesRow saveFileRow
	{
		get
		{
			return _saveFileRow;
		}
		set
		{
			_saveFileRow = value;
			UpdateContents();
		}
	}

	public void UpdateContents()
	{
		string format = Te.xt(tid);
		SaveFiles.SaveFileMeta saveFile = _saveFileRow.saveFile;
		string text = saveFile.playerName;
		if (text == "New Story")
		{
			text = Te.xt(text);
		}
		int playerLevel = saveFile.playerLevel;
		int totalStars = saveFile.totalStars;
		string version = saveFile.version;
		string text2 = Features.VERSION.ToString();
		format = string.Format(format, text, playerLevel, totalStars, version, text2);
		SetMessage(format);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			Hero hero = _saveFileRow.hero;
			int offsetX2 = offsetX - hero.PositionX;
			int num = offsetY - hero.PositionZ + hero.PositionY + heroOffsetY;
			if (_saveFileRow.saveFile.bigHead)
			{
				num++;
			}
			hero.Draw(r, offsetX2, num);
		}
	}
}
