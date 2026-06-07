using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogWindow : MonoBehaviour
{
	public SlidingPanel Panel;

	public RectTransform ButtonRow;

	public Image Img;

	public TextMeshProUGUI LabelTitle;

	public Localize LocTitle;

	public LocalizationParamsManager ParamsTitle;

	public TextMeshProUGUI LabelDesc;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsDesc;

	private void Awake()
	{
	}
}
