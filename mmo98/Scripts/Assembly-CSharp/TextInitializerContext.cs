using TMPro;

public class TextInitializerContext : InitializerContext<TMP_Text>
{
	public TextInitializerContext SetText(string text)
	{
		Target.text = text;
		return this;
	}
}
