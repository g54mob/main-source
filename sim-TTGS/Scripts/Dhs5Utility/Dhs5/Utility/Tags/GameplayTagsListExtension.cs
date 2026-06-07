namespace Dhs5.Utility.Tags
{
	public static class GameplayTagsListExtension
	{
		public static bool IsValid(this GameplayTagsList gameplayTagsList)
		{
			if (gameplayTagsList != null)
			{
				return gameplayTagsList.Count > 0;
			}
			return false;
		}
	}
}
