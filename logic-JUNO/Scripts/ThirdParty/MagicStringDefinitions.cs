using System;
using System.Collections.Generic;
using UnityEngine;

public class MagicStringDefinitions : ScriptableObject
{
	[Serializable]
	public class Category
	{
		public string _strCategoryName;

		[SerializeField]
		public List<string> _strOptions;
	}

	public List<Category> _catOptionCategorys;

	public static MagicStringDefinitions GetMagicStringsDefinition()
	{
		return null;
	}

	public string[] GetOptionsInCategory(string strCategoryName)
	{
		if (string.IsNullOrEmpty(strCategoryName))
		{
			return new string[0];
		}
		if (_catOptionCategorys == null)
		{
			return new string[0];
		}
		foreach (Category catOptionCategory in _catOptionCategorys)
		{
			if (catOptionCategory != null && catOptionCategory._strCategoryName == strCategoryName && catOptionCategory._strOptions != null)
			{
				return catOptionCategory._strOptions.ToArray();
			}
		}
		return new string[0];
	}
}
