public class FileInfoBackButton : FileSelectButtonBase
{
	public FileInfoLoader fileInfoRef;

	protected override void OnClick()
	{
		if (!locked && selected)
		{
			fileInfoRef.HideFileInfo();
		}
	}
}
