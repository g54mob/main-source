using System;
using System.Collections.Generic;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class PreloadData
{
	private List<CharacterType> _003Ccharacters_003Ek__BackingField;

	private List<string> _003Ctextures_003Ek__BackingField;

	private List<string> _003Cvideos_003Ek__BackingField;

	private List<BgmType> _003Cbgm_003Ek__BackingField;

	public List<CharacterType> characters
	{
		get
		{
			return _003Ccharacters_003Ek__BackingField;
		}
		set
		{
			_003Ccharacters_003Ek__BackingField = value;
		}
	}

	public List<string> textures
	{
		get
		{
			return _003Ctextures_003Ek__BackingField;
		}
		set
		{
			_003Ctextures_003Ek__BackingField = value;
		}
	}

	public List<string> videos
	{
		get
		{
			return _003Cvideos_003Ek__BackingField;
		}
		set
		{
			_003Cvideos_003Ek__BackingField = value;
		}
	}

	public List<BgmType> bgm
	{
		get
		{
			return _003Cbgm_003Ek__BackingField;
		}
		set
		{
			_003Cbgm_003Ek__BackingField = value;
		}
	}

	public PreloadData()
	{
		List<CharacterType> list = new List<CharacterType>();
		_003Ccharacters_003Ek__BackingField = list;
		List<string> list2 = new List<string>();
		_003Ctextures_003Ek__BackingField = list2;
		List<string> list3 = new List<string>();
		_003Cvideos_003Ek__BackingField = list3;
		List<BgmType> list4 = new List<BgmType>();
		_003Cbgm_003Ek__BackingField = list4;
	}
}
