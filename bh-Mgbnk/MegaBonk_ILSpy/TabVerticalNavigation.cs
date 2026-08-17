using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabVerticalNavigation : MonoBehaviour
{
	public GameObject buttonsParent;

	public unsafe void Set(Button tabButton)
	{
		//IL_0221: Expected O, but got I4
		//IL_01ac: Expected O, but got Ref
		//IL_01c3: Expected O, but got I4
		List<Button> list = new List<Button>();
		GameObject gameObject = buttonsParent;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			Transform transform = gameObject.transform;
			int childCount = transform.childCount;
			if (num >= childCount)
			{
				break;
			}
			Transform transform2 = buttonsParent.transform;
			Transform child = transform2.GetChild(num2);
			Button component = child.GetComponent<Button>();
			if (component != null)
			{
				GameObject gameObject2 = component.gameObject;
				if (gameObject2.activeSelf)
				{
					list.Add(component);
				}
			}
			gameObject = buttonsParent;
			num2++;
			num = num2;
		}
		int num3 = 0;
		object obj2 = default(object);
		for (int num4 = 0; num4 < list._size; num4 = num3)
		{
			if (num3 > 0)
			{
				int index = num3 - 1;
				Button button = list.get_Item(index);
			}
			object obj = list._size - 1;
			if (num3 < (nint)obj)
			{
				int index2 = num3 + 1;
				Button button2 = list.get_Item(index2);
			}
			Button button3 = list.get_Item(num3);
			button3.navigation = (Navigation)(&obj2);
			num3++;
			obj2 = 4;
		}
	}
}
