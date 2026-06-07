using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ColorSwapBtnViz", menuName = "Btn/ColorSwapBtnViz")]
public class ColorSwapBtnViz : CoolButtonViz
{
	[NamedArray(typeof(CoolButtonState))]
	public Color[] Colors;

	public override void ApplyViz(CoolButtonState btnState, Graphic img)
	{
	}
}
