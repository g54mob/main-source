using UnityEngine;

public class Notification
{
	public readonly string message;

	public readonly Sprite leftImage;

	public readonly Sprite rightImage;

	public readonly string rightValue;

	public readonly bool useImages;

	public readonly bool isPermanent;

	public Notification(string s)
	{
		message = s;
		leftImage = null;
		rightImage = null;
		rightValue = null;
		useImages = false;
		isPermanent = false;
	}

	public Notification(string s, Sprite left, Sprite right, string value, bool permanent = false)
	{
		message = s;
		leftImage = left;
		rightImage = right;
		rightValue = value;
		useImages = true;
		isPermanent = permanent;
	}
}
