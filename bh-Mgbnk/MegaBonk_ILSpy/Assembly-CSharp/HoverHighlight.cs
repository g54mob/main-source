using UnityEngine;
using UnityEngine.UI;

public class HoverHighlight : MonoBehaviour
{
	public Color defaultColor;

	public Color highlightColor;

	private MaskableGraphic graphic;

	private RectTransform rectTransform;

	private bool mouseOver;

	private void Awake()
	{
		MaskableGraphic component = GetComponent<MaskableGraphic>();
		graphic = component;
		RectTransform component2 = graphic.GetComponent<RectTransform>();
		rectTransform = component2;
	}

	private unsafe void Update()
	{
		//IL_002c: Expected O, but got Ref
		//IL_01d1: Expected O, but got Ref
		//IL_010c: Invalid comparison between F4 and I4
		//IL_0135: Expected O, but got I4
		Rect rect = rectTransform.rect;
		Vector3 mousePosition = Input.mousePosition;
		object obj = default(object);
		Vector3 vector = rectTransform.InverseTransformPoint((Vector3)(&obj));
		bool flag;
		MaskableGraphic maskableGraphic;
		if (!(vector.x < rect.m_XMin))
		{
			float num = rect.m_Width + rect.m_XMin;
			if (num > vector.x && !(vector.y < rect.m_YMin))
			{
				flag = mouseOver;
				float num2 = rect.m_Height + rect.m_YMin;
				bool flag2 = num2 < vector.y;
				float num3 = num2 - vector.y;
				bool flag3 = num3 == 0f;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				object obj2 = flag5 & flag4;
				if (obj2 == null)
				{
					goto IL_01aa;
				}
				if (!mouseOver)
				{
					maskableGraphic = graphic;
					mouseOver = true;
					goto IL_01c4;
				}
				return;
			}
		}
		flag = mouseOver;
		goto IL_01aa;
		IL_01c4:
		object obj3 = default(object);
		maskableGraphic.color = (Color)(&obj3);
		return;
		IL_01aa:
		if (flag)
		{
			maskableGraphic = graphic;
			mouseOver = false;
			goto IL_01c4;
		}
	}

	private unsafe void CustomPointerHandler()
	{
		//IL_002c: Expected O, but got Ref
		//IL_01d1: Expected O, but got Ref
		//IL_010c: Invalid comparison between F4 and I4
		//IL_0135: Expected O, but got I4
		Rect rect = rectTransform.rect;
		Vector3 mousePosition = Input.mousePosition;
		object obj = default(object);
		Vector3 vector = rectTransform.InverseTransformPoint((Vector3)(&obj));
		bool flag;
		MaskableGraphic maskableGraphic;
		if (!(vector.x < rect.m_XMin))
		{
			float num = rect.m_Width + rect.m_XMin;
			if (num > vector.x && !(vector.y < rect.m_YMin))
			{
				flag = mouseOver;
				float num2 = rect.m_Height + rect.m_YMin;
				bool flag2 = num2 < vector.y;
				float num3 = num2 - vector.y;
				bool flag3 = num3 == 0f;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				object obj2 = flag5 & flag4;
				if (obj2 == null)
				{
					goto IL_01aa;
				}
				if (!mouseOver)
				{
					maskableGraphic = graphic;
					mouseOver = true;
					goto IL_01c4;
				}
				return;
			}
		}
		flag = mouseOver;
		goto IL_01aa;
		IL_01c4:
		object obj3 = default(object);
		maskableGraphic.color = (Color)(&obj3);
		return;
		IL_01aa:
		if (flag)
		{
			maskableGraphic = graphic;
			mouseOver = false;
			goto IL_01c4;
		}
	}

	private unsafe void OnPointerEnter()
	{
		//IL_001f: Expected O, but got Ref
		mouseOver = true;
		object obj = default(object);
		graphic.color = (Color)(&obj);
	}

	private unsafe void OnPointerExit()
	{
		//IL_001f: Expected O, but got Ref
		mouseOver = false;
		object obj = default(object);
		graphic.color = (Color)(&obj);
	}
}
