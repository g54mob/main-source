using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Gnorman Tutorial Action", fileName = "GnormanAction")]
public class GnormanTutorialActionData : GnormanActionData
{
	public List<GnormanTutorialActionLine> lines = new List<GnormanTutorialActionLine>();

	public override int MaxLines => lines.Count;

	public override GnormanFluffActionLine Line(int index)
	{
		return lines[index].line;
	}

	public static implicit operator GnormanAction(GnormanTutorialActionData data)
	{
		return data.ID;
	}

	public static implicit operator GnormanTutorialActionData(GnormanAction node)
	{
		return node.Data() as GnormanTutorialActionData;
	}
}
