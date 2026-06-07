using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MatSwapViz", menuName = "Btn/MatSwapViz")]
public class MatSwapViz : CoolButtonViz
{
	[NamedArray(typeof(CoolButtonState))]
	public Material[] Mats;

	public override void ApplyViz(CoolButtonState btnState, Graphic img)
	{
	}
}
