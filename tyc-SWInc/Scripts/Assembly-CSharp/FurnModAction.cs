using System;

[AttributeUsage(AttributeTargets.Method)]
public class FurnModAction : Attribute
{
	public string Tip;

	public FurnModAttr.ItemType ValidFor = FurnModAttr.ItemType.Everything;
}
