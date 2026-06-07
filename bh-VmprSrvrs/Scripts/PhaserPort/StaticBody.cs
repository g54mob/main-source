public class StaticBody : BaseBody
{
	public StaticBody(World world, PhaserGameObject gameObject)
	{
	}

	public override void drawDebug()
	{
	}

	public override bool willDrawDebug()
	{
		return false;
	}

	public override BaseBody setOffset(float x, float? y = null)
	{
		return null;
	}
}
