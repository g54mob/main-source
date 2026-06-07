using UnityEngine;

public class MagicStringsAttribute : PropertyAttribute
{
	public string _strCategory;

	public MagicStringsAttribute(string strCategory)
	{
		_strCategory = strCategory;
	}
}
