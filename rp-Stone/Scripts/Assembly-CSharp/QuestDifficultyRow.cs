public class QuestDifficultyRow : DialogButton
{
	public Data.Quest quest { get; set; }

	public int difficulty { get; set; }

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		QuestRowStarString.Draw(r, offsetX + 4, offsetY + 2, difficulty);
	}
}
