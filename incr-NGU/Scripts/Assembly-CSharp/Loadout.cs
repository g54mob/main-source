using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Loadout
{
	public int head;

	public int chest;

	public int legs;

	public int boots;

	public int weapon;

	public int weapon2;

	public List<int> accessories = new List<int>();

	public int temp;

	public string loadoutName;

	public int accessoriesSize()
	{
		return 8;
	}

	public Loadout()
	{
		head = -1000;
		chest = -1000;
		legs = -1000;
		boots = -1000;
		weapon = -1000;
		weapon2 = -1000;
		while (accessories.Count < accessoriesSize())
		{
			accessories.Add(-1000);
		}
		temp = -1000;
	}

	public void validateLoadout()
	{
	}

	public int toArrayIndex(int id)
	{
		return id - 10000;
	}

	public int toControllerIndex(int id)
	{
		return id + 10000;
	}

	public void debugLoadout()
	{
		string text = head + " head, " + legs + " legs, " + chest + " chest," + boots + " boots," + weapon + " weapon, ";
		for (int i = 0; i < accessories.Count; i++)
		{
			text = text + accessories[i] + " accesorry " + i + ", ";
		}
		Debug.Log(text);
	}
}
