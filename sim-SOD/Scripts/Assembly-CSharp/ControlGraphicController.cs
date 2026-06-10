using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlGraphicController : MonoBehaviour
{
	public enum ControlGraphicType
	{
		keyboard = 0,
		mouse = 1,
		controller = 2
	}

	public Image img;

	public TextMeshProUGUI controlText;

	public ControlGraphicType controlType;

	public string trackControl;

	public string buttonStr;

	private void OnEnable()
	{
	}
}
