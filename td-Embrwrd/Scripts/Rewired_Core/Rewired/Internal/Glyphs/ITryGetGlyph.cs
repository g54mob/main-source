namespace Rewired.Internal.Glyphs
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal interface ITryGetGlyph
	{
		bool TryGetGlyph(out object value);
	}
}
