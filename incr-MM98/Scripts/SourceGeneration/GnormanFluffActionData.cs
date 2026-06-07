using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Gnorman Fluff Action", fileName = "GnormanAction")]
public class GnormanFluffActionData : GnormanActionData
{
	public enum Type
	{
		Fluff = 0,
		Upgrade = 1,
		Research = 2,
		Operation = 3,
		Custom = 4
	}

	public Type type;

	public float cooldown = 60f;

	public List<GnormanFluffActionLine> lines = new List<GnormanFluffActionLine>();

	public override int MaxLines => lines.Count;

	public override GnormanFluffActionLine Line(int index)
	{
		return lines[index];
	}

	public static implicit operator GnormanAction(GnormanFluffActionData data)
	{
		return data.ID;
	}

	public static implicit operator GnormanFluffActionData(GnormanAction node)
	{
		return node.Data() as GnormanFluffActionData;
	}
}
