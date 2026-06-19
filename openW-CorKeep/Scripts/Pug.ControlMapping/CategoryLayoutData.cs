using System;
using Rewired.UI.ControlMapper;
using UnityEngine;

[Serializable]
public class CategoryLayoutData
{
	[SerializeField]
	private bool[] _showActionCategoryName;

	[SerializeField]
	private bool[] _showActionCategoryDescription;

	[field: SerializeField]
	public ControlMapper.MappingSet MappingSet { get; private set; }

	public bool ShowActionCategoryLabel(int index)
	{
		if (ShowActionCategoryName(index))
		{
			return ShowActionCategoryDescription(index);
		}
		return false;
	}

	public bool ShowActionCategoryName(int index)
	{
		if (index >= 0 && index < _showActionCategoryName.Length)
		{
			return _showActionCategoryName[index];
		}
		return false;
	}

	public bool ShowActionCategoryDescription(int index)
	{
		if (index >= 0 && index < _showActionCategoryDescription.Length)
		{
			return _showActionCategoryDescription[index];
		}
		return false;
	}
}
