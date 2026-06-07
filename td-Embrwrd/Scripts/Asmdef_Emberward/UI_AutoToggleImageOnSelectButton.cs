using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_AutoToggleImageOnSelectButton : Button
{
	[SerializeField]
	private Image targetImage;

	protected override void OnEnable()
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}
}
