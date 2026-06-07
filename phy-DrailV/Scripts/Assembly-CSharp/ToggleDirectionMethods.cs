internal static class ToggleDirectionMethods
{
	public static ToggleDirection FromNumber(float number)
	{
		if (!(number > 0f))
		{
			return ToggleDirection.DOWN;
		}
		return ToggleDirection.UP;
	}
}
