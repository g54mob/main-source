using System.Collections.Generic;
using UnityEngine;

public class Groups : MonoBehaviour
{
	public static List<Group> data = new List<Group>();

	public static int groupIndex = 0;

	public static void CreateGroup(List<Transform> content, string name = null)
	{
		string text = "Group_" + groupIndex;
		if (name != null)
		{
			text = name;
		}
		data.Add(new Group(text));
		foreach (Transform item in content)
		{
			BlockComponent component = item.GetComponent<BlockComponent>();
			if (component != null)
			{
				component.data.group = text;
			}
			Selection.UpdateLayer(item);
		}
		groupIndex++;
		Global.ShowMessage("Group of " + content.Count + " items created (" + text + ")");
	}

	public static void SelectGroup(Transform t)
	{
		string text = GetGroup(t);
		if (!(text != ""))
		{
			return;
		}
		foreach (Transform item in Global.SceneBlocks())
		{
			string text2 = GetGroup(item);
			if (text2 != "" && text2 == text)
			{
				Selection.Add(item, checkGroup: false);
			}
		}
	}

	public static string GetGroup(Transform t)
	{
		string result = "";
		BlockComponent component = t.GetComponent<BlockComponent>();
		if (component != null && component.data.group != "")
		{
			result = component.data.group;
		}
		return result;
	}
}
