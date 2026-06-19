public class InputDependentPugText : PugText
{
	public string desktopText;

	public string xboxText;

	public string nxText;

	public string playstationText;

	public string[] desktopFormatFields = new string[0];

	public string[] xboxFormatFields = new string[0];

	public string[] nxFormatFields = new string[0];

	public string[] playstationFormatFields = new string[0];

	protected override void Awake()
	{
		base.Awake();
		SetText(desktopText);
		formatFields = desktopFormatFields;
	}
}
