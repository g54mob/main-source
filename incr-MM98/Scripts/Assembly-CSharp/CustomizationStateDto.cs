using MessagePack;

[MessagePackObject(false)]
public class CustomizationStateDto
{
	[Key(0)]
	public BackgroundSkin Background;

	[Key(1)]
	public bool CustomBackground;

	[Key(2)]
	public CursorSkin Cursor;

	[Key(3)]
	public bool TrailingCursor;

	[Key(4)]
	public GnormanSkin Gnorman;
}
