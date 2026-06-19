using UnityEngine;

public class HumanoidSkinIDDropdownAttribute : PropertyAttribute
{
	public string Category { get; }

	public HumanoidSkinIDDropdownAttribute(string category = null)
	{
		Category = category;
	}
}
