using System.Collections.Generic;

namespace TH20.ExtContent
{
	public class GameItemLog
	{
		public EContentType _contentType;

		public string _logHeader;

		public List<GameItemLogItem> _logItems;

		public GameItemLog(EContentType contentType)
		{
			_contentType = contentType;
			_logItems = new List<GameItemLogItem>();
		}
	}
}
