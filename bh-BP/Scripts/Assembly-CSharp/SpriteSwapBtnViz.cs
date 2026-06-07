using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SpriteSwapBtnViz", menuName = "Btn/SpriteSwapBtnViz")]
public class SpriteSwapBtnViz : CoolButtonViz
{
	[NamedArray(typeof(CoolButtonState))]
	public Sprite[] Sprites;

	public override void ApplyViz(CoolButtonState btnState, Graphic img)
	{
	}
}
