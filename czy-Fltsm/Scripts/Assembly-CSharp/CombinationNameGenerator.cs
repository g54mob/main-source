using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Name/Combination Generator")]
public class CombinationNameGenerator : NameGenerator
{
	[SerializeField]
	private string _joiner = " ";

	[SerializeField]
	private NameList[] _names;

	private StringBuilder _nameBuilder;

	public override string ReturnName()
	{
		string text = "";
		for (int i = 0; i < _names.Length; i++)
		{
			if (i != 0)
			{
				text += _joiner;
			}
			text += _names[i].ReturnRandomName();
		}
		return text;
	}

	public override void AddAllNames(List<string> names)
	{
		string item;
		while (NextName(out item))
		{
			names.Add(item);
		}
	}

	private bool NextName(out string name)
	{
		if (_nameBuilder == null)
		{
			_nameBuilder = new StringBuilder();
		}
		else
		{
			_nameBuilder.Clear();
		}
		for (int i = 0; i < _names.Length; i++)
		{
			if (i != 0)
			{
				_nameBuilder.Append(_joiner);
			}
			_nameBuilder.Append(_names[i].ReturnNameAtIndex());
		}
		name = _nameBuilder.ToString();
		int num = _names.Length;
		while (0 < num--)
		{
			if (_names[num].NextIndex())
			{
				return true;
			}
		}
		return false;
	}
}
