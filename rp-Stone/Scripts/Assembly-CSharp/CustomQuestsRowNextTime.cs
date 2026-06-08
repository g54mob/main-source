public class CustomQuestsRowNextTime : DialogButton
{
	private const string NEXT_QUEST_TEXT = "Next quest in {0}";

	private string localizedLabel;

	private int lastSpriteFrameIndex = -1;

	public void Setup()
	{
		base.HasFocus = false;
		localizedLabel = Te.xt("Next quest in {0}");
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (lastSpriteFrameIndex != mySprite.GetFrameIndex())
		{
			lastSpriteFrameIndex = mySprite.GetFrameIndex();
			string nextSpawnTimeRemainingString = CustomQuestsController.Singleton.GetNextSpawnTimeRemainingString();
			string value = string.Format(localizedLabel, nextSpawnTimeRemainingString);
			label.SetValue(value);
		}
		mySprite.pivotX = -(label.Length / 2);
	}
}
