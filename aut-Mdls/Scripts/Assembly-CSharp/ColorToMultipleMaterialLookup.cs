using System.Collections.Generic;
using UnityEngine;

public class ColorToMultipleMaterialLookup
{
	private Dictionary<Color, List<Material>> _dict = new Dictionary<Color, List<Material>>();

	public List<Material> this[Color key]
	{
		get
		{
			return _dict[key];
		}
		set
		{
			_dict[key] = value;
		}
	}

	public bool ContainsKey(Color key)
	{
		return _dict.ContainsKey(key);
	}

	public void Add(Color key, List<Material> materialList)
	{
		_dict.Add(key, materialList);
	}
}
