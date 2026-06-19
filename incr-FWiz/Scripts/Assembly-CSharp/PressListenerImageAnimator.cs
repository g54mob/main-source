using UnityEngine;
using UnityEngine.UI;

public class PressListenerImageAnimator : PressListenerAnimator
{
	public Image Image;

	public Sprite Default;

	public Sprite Hovered;

	public Sprite Pressed;

	public override void AfterStateUpdate()
	{
	}
}
