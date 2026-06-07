using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ColorAndSpriteSwapBtnViz", menuName = "Btn/ColorAndSpriteSwapBtnViz")]
public class ColorAndSpriteSwapBtnViz : CoolButtonViz
{
	[NamedArray(typeof(CoolButtonState))]
	public Color[] Colors;

	[NamedArray(typeof(CoolButtonState))]
	public Sprite[] Sprites;

	public override void ApplyViz(CoolButtonState btnState, Graphic img)
	{
	}
}
