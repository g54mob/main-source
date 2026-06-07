using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIStyling : MonoBehaviour
{
	[Header("Heading Text")]
	public int size_Heading;

	public Font font_Heading;

	public Color color_Heading;

	private Text[] texts_Heading;

	private void OnEnable()
	{
	}
}
