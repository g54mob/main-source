using System;

[Serializable]
public class ControlGuide
{
	public int OrderIndex;

	public string ControlName;

	public string ControlDescription;

	public bool Valid => false;
}
