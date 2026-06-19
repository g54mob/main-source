public class DropdownEntryData
{
	public int id;

	public string textStringToShow;

	public string subtextStringToShow;

	public string[] subStringFormatFields;

	public string string0;

	public DropdownEntryData(int id, string textStringToShow, string subtextStringToShow, string[] subStringFormatFields, string string0)
	{
		this.id = id;
		this.textStringToShow = textStringToShow;
		this.subtextStringToShow = subtextStringToShow;
		this.subStringFormatFields = subStringFormatFields;
		this.string0 = string0;
	}
}
