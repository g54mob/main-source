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
		isHovering = true;
		hatSelectionPopupWindow.HoverButton(hatData);
	}

	public override void StopHover()
	{
		isHovering = false;
	}

	protected override void OnClick()
	{
		hatSelectionPopupWindow.ClickButton(hatData);
	}

	public void Set(HatData hatData)
	{
		this.hatData = hatData;
		Texture texture;
		if (!(hatData == null))
		{
			Texture icon = hatData.GetIcon();
			texture = icon;
		}
		else
		{
			texture = noHatTexture;
		}
		i_hatIcon.texture = texture;
	}

	public unsafe void SetSelected(bool selected)
	{
		//IL_002d: Expected O, but got Ref
		if (selected)
		{
		}
		object obj = default(object);
		background.color = (Color)(&obj);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		StartHover();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		StopHover();
	}

	public MyButtonHat()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
