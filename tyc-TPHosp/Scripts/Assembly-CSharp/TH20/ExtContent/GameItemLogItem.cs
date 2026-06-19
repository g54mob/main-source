namespace TH20.ExtContent
{
	public class GameItemLogItem
	{
		public GameItemBase _gameItemBase;

		public string _logStr;

		public GameItemLogItem(GameItemBase gameItemBase, string logStr)
		{
			_gameItemBase = gameItemBase;
			_logStr = logStr;
		}
	}
}
