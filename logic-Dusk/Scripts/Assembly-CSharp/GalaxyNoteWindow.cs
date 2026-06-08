public class GalaxyNoteWindow : NoteBaseWindow
{
	public GalaxyNoteWindow()
		: base(new char[2] { ':', '=' }, 400f, 400f)
	{
		base.windowTitle = "Galaxy Note";
	}

	public override void Initialize()
	{
		base.Initialize();
		noteEditor.SetText(GalaxySaveFile.Get("NOTE", string.Empty));
	}

	protected override void CloseButtonPressed()
	{
		base.CloseButtonPressed();
		GalaxySaveFile.Save("NOTE", noteEditor.Text);
		GalaxyMapManager.Instance.CloseNoteWindow();
	}

	protected override void UndoButtonPressed()
	{
		base.UndoButtonPressed();
		noteEditor.UndoEditor();
	}

	protected override void CancelButtonPressed()
	{
		base.CancelButtonPressed();
		if (noteEditor.CancelEditor())
		{
			GalaxyMapManager.Instance.CloseNoteWindow();
		}
	}

	protected override void CanceledEditor()
	{
		base.CanceledEditor();
		GalaxyMapManager.Instance.CloseNoteWindow();
	}
}
