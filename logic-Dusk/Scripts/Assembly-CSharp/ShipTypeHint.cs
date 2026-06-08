public class ShipTypeHint : BaseMessageHint
{
	public ShipTypeHint()
		: base("Different ship types have different tendencies.\r\nFor example, Space Stations tend to have more\r\nfuel than other types...", null, 30f)
	{
		GameSaveFile.Save("HNT_SHPTYP", true);
	}
}
