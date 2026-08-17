using UnityEngine;
using UnityEngine.UI;

public class MyButtonNormal : MyButton
{
	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	private bool colorInited;

	public unsafe override void StartHover()
	{
		//IL_000b: Expected O, but got Ref
		//IL_001f: Expected O, but got Ref
		Color color = default(Color);
		SetColor((Color)(&color));
		background.color = (Color)(&color);
		isHovering = true;
	}

	public unsafe override void StopHover()
	{
		//IL_000b: Expected O, but got Ref
		//IL_001f: Expected O, but got Ref
		Color color = default(Color);
		SetColor((Color)(&color));
		background.color = (Color)(&color);
		isHovering = false;
	}

	private unsafe void SetColor(Color c)
	{
		//IL_013a: Expected O, but got Ref
		//IL_0040: Expected O, but got F4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00bb: Expected O, but got F4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		if (!colorInited)
		{
			Color color = background.color;
			defaultColor = (Color)color.r;
			float num = 0f - color.r;
			colorInited = true;
			object obj2 = default(object);
			object obj = 0 - obj2;
			float num2 = num * 0.2f;
			float num3 = (float)obj * 0.2f;
			float num4 = num2 + color.r;
			float num5 = num3 + (float)obj2;
			hoverColor = (Color)num4;
			object obj3 = 0 - obj2;
			float num6 = (float)obj3 * 0.2f;
			float num7 = num6 + (float)obj2;
			float num8 = 1f - (float)obj2;
			float num9 = num8 * 0.2f;
			float num10 = num9 + (float)obj2;
		}
		object obj4 = default(object);
		background.color = (Color)(&obj4);
	}

	protected override void OnClick()
	{
	}

	public MyButtonNormal()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
