public class FileInfoTrashButton : FileSelectButtonBase
{
	public FileInfoLoader fileInfoRef;

	protected override void OnClick()
	{
		if (!locked && selected)
		{
			fileInfoRef.LoadTrashPane();
		}
	}
}
