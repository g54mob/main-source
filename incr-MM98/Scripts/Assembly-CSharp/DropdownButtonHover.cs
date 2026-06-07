using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdownButtonHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private static readonly Color HoverBackground = new Color32(0, 0, 128, byte.MaxValue);

	private static readonly Color HoverForeground = Color.white;

	[SerializeField]
	private Image background;

	[SerializeField]
	private TextMeshProUGUI label;

	[SerializeField]
	private Image checkmark;

	private Color _originalBackground;

	private Color _originalForeground;

	private Color _originalCheckmark;

	private void Awake()
	{
		_originalBackground = background.color;
		_originalForeground = label.color;
		_originalCheckmark = checkmark.color;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		background.color = HoverBackground;
		label.color = HoverForeground;
		checkmark.color = HoverForeground;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		ResetState();
	}

	public void ResetState()
	{
		background.color = _originalBackground;
		label.color = _originalForeground;
		checkmark.color = _originalCheckmark;
	}
}
