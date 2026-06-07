using TMPro;
using UI.Apps;
using UnityEngine.UI;

public class MultitoolDocumentationInfoService : MultitoolService
{
	public TextMeshProUGUI text;

	public Image background;

	public Scrollbar scrollbar;

	private const string docPrefix = "@luau/global/";

	public void Show(string documentationSymbol)
	{
	}

	public override void OnMultitoolAppStart(MultiToolAppInfo appInfo)
	{
	}

	private string GetDocumentationText(string documentationSymbol)
	{
		return null;
	}

	private string FormatType(string documentationType)
	{
		return null;
	}

	private string FormatDescription(string description)
	{
		return null;
	}
}
