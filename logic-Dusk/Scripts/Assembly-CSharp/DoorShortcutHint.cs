public class DoorShortcutHint : BaseMessageHint
{
	public DoorShortcutHint(string typeString, string doorValue)
		: base("You can use the toggle command '{0}' instead of\r\n'" + typeString + " {0}'", doorValue.Trim(), 30f)
	{
	}
}
