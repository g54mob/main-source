using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ConditionalButtonTooltip : MonoBehaviour, ITooltip, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Tooltip tooltipEnabled;

	[SerializeField]
	private Tooltip tooltipDisabled;

	private Button _button;

	public Tooltip Tooltip
	{
		get
		{
			if (!_button.interactable)
			{
				return tooltipDisabled;
			}
			return tooltipEnabled;
		}
	}

	private void Awake()
	{
		_button = GetComponent<Button>();
	}
}
