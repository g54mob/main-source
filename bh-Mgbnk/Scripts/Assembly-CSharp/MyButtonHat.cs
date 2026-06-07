using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButtonHat : MyButton, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HatSelectionPopupWindow hatSelectionPopupWindow;

	public RawImage background;

	public Color defaultColor;

	public Color selectedColor;

	public RawImage i_hatIcon;

	public Texture noHatTexture;

	public HatData hatData;

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}

	public void Set(HatData hatData)
	{
	}

	public void SetSelected(bool selected)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
