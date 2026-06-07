public class WeigthTooltip : Tooltip
{
	public override string ParsedText()
	{
		return Community.PlayerCommunity.ReturnWeightOverCapacityString();
	}
}
