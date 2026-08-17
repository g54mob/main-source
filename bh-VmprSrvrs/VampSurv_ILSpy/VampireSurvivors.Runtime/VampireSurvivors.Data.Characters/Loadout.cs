using System;
using System.Collections.Generic;

namespace VampireSurvivors.Data.Characters;

[Serializable]
public class Loadout
{
	private List<WeaponType> _003CstartingLoadout_003Ek__BackingField;

	private List<WeaponType> _003Cloadout_003Ek__BackingField;

	private bool _003CautoShuffle_003Ek__BackingField;

	public List<WeaponType> startingLoadout
	{
		get
		{
			return _003CstartingLoadout_003Ek__BackingField;
		}
		set
		{
			_003CstartingLoadout_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> loadout
	{
		get
		{
			return _003Cloadout_003Ek__BackingField;
		}
		set
		{
			_003Cloadout_003Ek__BackingField = value;
		}
	}

	public bool autoShuffle
	{
		get
		{
			return _003CautoShuffle_003Ek__BackingField;
		}
		set
		{
			_003CautoShuffle_003Ek__BackingField = value;
		}
	}
}
