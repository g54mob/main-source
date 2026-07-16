using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hintbox Library", menuName = "Libraries/Hintbox Library", order = 1)]
public class HintBoxLibrary : ScriptableObject
{
	public List<HintBox> hintBoxes = new List<HintBox>();

	public HintBox GetHintBoxByTag(string tag)
	{
		return hintBoxes.Find((HintBox x) => x.hintBoxTag.ToLower() == tag.ToLower());
	}

	public List<HintBox> GetCopy()
	{
		List<HintBox> list = new List<HintBox>();
		for (int i = 0; i < hintBoxes.Count; i++)
		{
			HintBox hintBox = new HintBox();
			hintBox.hintBoxTag = hintBoxes[i].hintBoxTag;
			hintBox.prefab = hintBoxes[i].prefab;
			hintBox.shown = false;
			list.Add(hintBox);
		}
		return list;
	}
}
