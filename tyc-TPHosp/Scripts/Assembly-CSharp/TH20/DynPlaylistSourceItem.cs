using System.Collections.Generic;

namespace TH20
{
	[DontSave]
	public class DynPlaylistSourceItem
	{
		public DynPlaylistSource _type;

		public string _itemId;

		public bool _bContentValid;

		public bool _bEnabled;

		public bool _bExpandedUI;

		public string _sourceName;

		public List<DynPlaylistTrackItem> _trackItems;

		public DynPlaylistSourceItem(DynPlaylistSource type, string sourceItemId, string sourceName)
		{
			_itemId = sourceItemId;
			_sourceName = sourceName;
			_type = type;
			_bContentValid = true;
			_bEnabled = true;
			_bExpandedUI = true;
			_trackItems = new List<DynPlaylistTrackItem>();
		}

		public DynPlaylistTrackItem FindTrackItemById(string trackItemId, int fileContentsId = 0)
		{
			return _trackItems.Find((DynPlaylistTrackItem trackItem) => trackItem._itemId == trackItemId && (fileContentsId == 0 || trackItem._fileContentsId == 0 || trackItem._fileContentsId == fileContentsId));
		}

		public bool IsEnabled()
		{
			if (_bContentValid)
			{
				return _bEnabled;
			}
			return false;
		}

		public int GetNumEnabledTracks()
		{
			int num = 0;
			foreach (DynPlaylistTrackItem trackItem in _trackItems)
			{
				if (trackItem.IsEnabled())
				{
					num++;
				}
			}
			return num;
		}
	}
}
