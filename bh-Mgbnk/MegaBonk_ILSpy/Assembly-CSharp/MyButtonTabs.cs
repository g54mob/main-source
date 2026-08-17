using UnityEngine;
using UnityEngine.UI;

public class MyButtonTabs : MyButton
{
	public MaskableGraphic background;

	public MaskableGraphic text;

	public GameObject associatedContent;

	public Color selectedColor;

	public Color defaultColor;

	private bool selected;

	private unsafe void Start()
	{
		//IL_00b2: Expected O, but got Ref
		if (!selected)
		{
			if (associatedContent != null && associatedContent != null)
			{
				associatedContent.SetActive(value: false);
			}
			selected = false;
			object obj = default(object);
			background.color = (Color)(&obj);
			isHovering = false;
		}
	}

	public unsafe void Select()
	{
		//IL_0062: Expected O, but got Ref
		if (associatedContent != null)
		{
			associatedContent.SetActive(value: true);
		}
		selected = true;
		object obj = default(object);
		background.color = (Color)(&obj);
	}

	public unsafe void Deselect(MyButtonTabs newButton)
	{
		//IL_0093: Expected O, but got Ref
		if (associatedContent != null && newButton.associatedContent != null)
		{
			associatedContent.SetActive(value: false);
		}
		selected = false;
		object obj = default(object);
		background.color = (Color)(&obj);
		isHovering = false;
	}

	public unsafe override void StartHover()
	{
		//IL_0031: Expected O, but got Ref
		if (!selected)
		{
			object obj = default(object);
			background.color = (Color)(&obj);
			isHovering = true;
		}
	}

	public unsafe override void StopHover()
	{
		//IL_0031: Expected O, but got Ref
		if (!selected)
		{
			object obj = default(object);
			background.color = (Color)(&obj);
		}
		isHovering = false;
	}

	protected override void OnClick()
	{
	}

	public MyButtonTabs()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
