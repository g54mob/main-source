using UnityEngine;

public class GradientIDDropdownAttribute : PropertyAttribute
{
	public string Category { get; }

	public GradientIDDropdownAttribute(string category = null)
	{
		Category = category;
	}
}
