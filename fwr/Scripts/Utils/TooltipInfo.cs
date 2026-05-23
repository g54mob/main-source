using UnityEngine;

public class TooltipInfo
{
	public enum Anchor
	{
		Auto = 0,
		TopLeft = 1,
		BottomLeft = 2,
		TopRight = 3,
		BottomRight = 4
	}

	public string text;

	public string docs;

	public float delay;

	public Vector3 fixedPosition;

	public Anchor anchor;

	public ItemBlock itemBlock;

	public TooltipInfo(string text, float delay = 0f, Vector3 fixedPosition = default(Vector3), Anchor anchor = Anchor.Auto, string docs = "")
	{
		this.text = text;
		this.docs = docs;
		this.delay = delay;
		this.fixedPosition = fixedPosition;
		this.anchor = anchor;
	}
}
