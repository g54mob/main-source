public class LevelUpDialogParam : BaseDialogParam
{
	public int choiceCount;

	public bool rareReward;

	public LevelUpDialogParam(int choiceCount = 1, bool rareReward = false)
		: base(enableCloseButton: false, enableEscape: false)
	{
	}
}
