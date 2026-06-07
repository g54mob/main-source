using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_ElementPieChart : MonoBehaviour
{
	[SerializeField]
	private Image image_Normal;

	[SerializeField]
	private Image image_Fire;

	[SerializeField]
	private Image image_Frost;

	[SerializeField]
	private Image image_Electric;

	[SerializeField]
	private Image image_Poison;

	[SerializeField]
	private Image image_Arcane;

	[SerializeField]
	private Image image_Corrupt;

	public void Setup(int normal, int fire, int frost, int electric, int poison, int arcane, int corrupt)
	{
	}
}
