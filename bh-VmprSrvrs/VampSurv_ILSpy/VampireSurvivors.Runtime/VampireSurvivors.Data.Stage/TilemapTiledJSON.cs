using System;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class TilemapTiledJSON
{
	private string _003Cname_003Ek__BackingField;

	private string _003Cpath_003Ek__BackingField;

	public string name
	{
		get
		{
			return _003Cname_003Ek__BackingField;
		}
		set
		{
			_003Cname_003Ek__BackingField = value;
		}
	}

	public string path
	{
		get
		{
			return _003Cpath_003Ek__BackingField;
		}
		set
		{
			_003Cpath_003Ek__BackingField = value;
		}
	}
}
