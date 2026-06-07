using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SpriteSwapBtnViz", menuName = "Btn/SpriteSwapBtnViz")]
public class SpriteSwapDepthBtnViz : CoolButtonViz
{
	[NamedArray(typeof(CoolButtonState))]
	public Sprite[] Sprites;

	[NamedArray(typeof(CoolButtonState))]
	public float[] Depth;

	public override void ApplyViz(CoolButtonState btnState, Graphic img)
	{
	}

	public override float GetDepth(CoolButtonState btnState)
	{
		return 0f;
	}
}
