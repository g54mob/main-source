using System;
using System.Collections.Generic;

[Serializable]
public class Wishes
{
	public List<Wish> wishes;

	public bool wishesOn;

	public bool filterDiff;

	public bool filterAfford;

	public bool filterMaxxed;

	public orderWish orderType;

	public int wishSize()
	{
		return 231;
	}

	public Wishes()
	{
		wishes = new List<Wish>();
		wishesOn = false;
		for (int i = 0; i < wishSize(); i++)
		{
			wishes.Add(new Wish());
		}
		filterDiff = false;
		filterAfford = false;
		filterMaxxed = false;
		orderType = orderWish.Default;
	}

	public void updateWishes()
	{
		if (wishes == null)
		{
			wishes = new List<Wish>();
		}
		while (wishes.Count < wishSize())
		{
			wishes.Add(new Wish());
		}
	}
}
