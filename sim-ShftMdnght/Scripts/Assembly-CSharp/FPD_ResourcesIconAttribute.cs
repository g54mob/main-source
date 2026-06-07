using UnityEngine;

public class FPD_ResourcesIconAttribute : PropertyAttribute
{
	public string Path;

	public int Spacing;

	public FPD_ResourcesIconAttribute(string path, int spacing = 0)
	{
		Path = path;
		Spacing = spacing;
	}
}
