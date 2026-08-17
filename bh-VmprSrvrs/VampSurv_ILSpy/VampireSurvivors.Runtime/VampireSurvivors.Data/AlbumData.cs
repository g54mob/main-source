using System.Collections.Generic;

namespace VampireSurvivors.Data;

public class AlbumData
{
	private bool _003CisUnlocked_003Ek__BackingField;

	private string _003Ctitle_003Ek__BackingField;

	private string _003Cicon_003Ek__BackingField;

	private List<BgmType> _003CtrackList_003Ek__BackingField;

	private ContentGroupType _003CcontentGroupType_003Ek__BackingField;

	public bool isUnlocked
	{
		get
		{
			return _003CisUnlocked_003Ek__BackingField;
		}
		set
		{
			_003CisUnlocked_003Ek__BackingField = value;
		}
	}

	public string title
	{
		get
		{
			return _003Ctitle_003Ek__BackingField;
		}
		set
		{
			_003Ctitle_003Ek__BackingField = value;
		}
	}

	public string icon
	{
		get
		{
			return _003Cicon_003Ek__BackingField;
		}
		set
		{
			_003Cicon_003Ek__BackingField = value;
		}
	}

	public List<BgmType> trackList
	{
		get
		{
			return _003CtrackList_003Ek__BackingField;
		}
		set
		{
			_003CtrackList_003Ek__BackingField = value;
		}
	}

	public ContentGroupType contentGroupType
	{
		get
		{
			return _003CcontentGroupType_003Ek__BackingField;
		}
		set
		{
			_003CcontentGroupType_003Ek__BackingField = value;
		}
	}
}
