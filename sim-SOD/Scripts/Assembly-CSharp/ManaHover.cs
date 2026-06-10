using TMPro;
using UnityEngine;

public class ManaHover : MonoBehaviour
{
	public TextMeshProUGUI ManaText;

	public WizcardPlayer player;

	private ComputerController comp;

	private ComputerOSUIComponent hoverComponent;

	private bool isHovered;

	private RectTransform rectTransform;

	private void Start()
	{
	}

	private bool IsCursorOverBar()
	{
		return false;
	}

	private void FixedUpdate()
	{
	}
}
