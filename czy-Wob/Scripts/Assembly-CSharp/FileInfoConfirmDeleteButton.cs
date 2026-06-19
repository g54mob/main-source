public class FileInfoConfirmDeleteButton : FileSelectButtonBase
{
	public FileInfoLoader fileInfoRef;

	protected override void OnClick()
	{
		if (!locked && selected)
		{
			fileInfoRef.DeleteSelectedFile();
		}
	}
}
