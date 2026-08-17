namespace Rewired.Glyphs.UnityUI;

public class UnityUIDefaultControllerElementGlyphSettings : DefaultControllerElementGlyphSettingsBase
{
	protected override void SetDefaultGlyphOrTextPrefab()
	{
		UnityUIControllerElementGlyphBase.s_defaultGlyphOrTextPrefab = base._glyphOrTextPrefab;
	}
}
