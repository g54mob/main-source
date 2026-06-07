using UnityEngine;

public class FontDatabase : MonoBehaviour
{
	[SerializeField]
	private FontDefinition[] _fonts;

	public FontDefinition GetFont(string charset)
	{
		FontDefinition[] fonts = _fonts;
		foreach (FontDefinition fontDefinition in fonts)
		{
			if (fontDefinition.Charset == charset)
			{
				return fontDefinition;
			}
		}
		Diagnostics.FailAssert("Unable to find font for charset '{0}'.", charset);
		return null;
	}
}
