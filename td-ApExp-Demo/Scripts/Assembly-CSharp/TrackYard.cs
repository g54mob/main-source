using System.Collections.Generic;
using UnityEngine;

public class TrackYard : Track
{
	[Header("World 1 Yard Stuff")]
	[SerializeField]
	private List<SpriteRenderer> w1Statics;

	[Header("World 2 Yard Stuff")]
	[SerializeField]
	private List<SpriteRenderer> type1Moveables;

	[SerializeField]
	private List<SpriteRenderer> type2Moveables;

	[SerializeField]
	private List<SpriteRenderer> type3Moveables;

	[SerializeField]
	private List<SpriteRenderer> w2Statics;

	[SerializeField]
	private List<Sprite> type1Sprites;

	[SerializeField]
	private List<Sprite> type2Sprites;

	[SerializeField]
	private List<Sprite> type3Sprites;

	[Header("World 3 Yard Stuff")]
	[SerializeField]
	private GameObject w3YardShadow;

	[SerializeField]
	private List<SpriteRenderer> w3Statics;

	public void SetupYard()
	{
		if (ZoneManager.Instance.CurrentZone != null)
		{
			if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z2_City")
			{
				ActivateW1YardObjects(activate: false);
				ActivateW2YardObjects(activate: true);
				ActivateW3YardObjects(activate: false);
				SetupMoveables();
			}
			else if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z1_Wasteland")
			{
				ActivateW1YardObjects(activate: true);
				ActivateW2YardObjects(activate: false);
				ActivateW3YardObjects(activate: false);
			}
			else if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z3_Viaduct")
			{
				ActivateW1YardObjects(activate: false);
				ActivateW2YardObjects(activate: false);
				ActivateW3YardObjects(activate: true);
			}
			else if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial")
			{
				ActivateW1YardObjects(activate: false);
				ActivateW2YardObjects(activate: false);
				ActivateW3YardObjects(activate: false);
			}
			else if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z4_Snow")
			{
				ActivateW1YardObjects(activate: false);
				ActivateW2YardObjects(activate: false);
				ActivateW3YardObjects(activate: false);
			}
		}
	}

	private void ActivateW2YardObjects(bool activate)
	{
		List<SpriteRenderer> list = new List<SpriteRenderer>();
		list.AddRange(type1Moveables);
		list.AddRange(type2Moveables);
		list.AddRange(type3Moveables);
		list.AddRange(w2Statics);
		foreach (SpriteRenderer item in list)
		{
			item.gameObject.SetActive(activate);
		}
	}

	private void ActivateW3YardObjects(bool activate)
	{
		List<SpriteRenderer> list = new List<SpriteRenderer>();
		list.AddRange(w3Statics);
		foreach (SpriteRenderer item in list)
		{
			item.gameObject.SetActive(activate);
		}
		w3YardShadow.SetActive(activate);
	}

	private void ActivateW1YardObjects(bool activate)
	{
		List<SpriteRenderer> list = new List<SpriteRenderer>();
		list.AddRange(w1Statics);
		foreach (SpriteRenderer item in list)
		{
			item.gameObject.SetActive(activate);
		}
	}

	private void SetupMoveables()
	{
		List<int> randomNumbersWithoutRepeating = ProbUtils.GetRandomNumbersWithoutRepeating(0, type1Sprites.Count - 1, type1Moveables.Count);
		for (int i = 0; i < type1Moveables.Count; i++)
		{
			type1Moveables[i].sprite = type1Sprites[randomNumbersWithoutRepeating[i]];
		}
		List<int> randomNumbersWithoutRepeating2 = ProbUtils.GetRandomNumbersWithoutRepeating(0, type2Sprites.Count - 1, type2Moveables.Count);
		for (int j = 0; j < type2Moveables.Count; j++)
		{
			type2Moveables[j].sprite = type2Sprites[randomNumbersWithoutRepeating2[j]];
		}
		List<int> randomNumbersWithoutRepeating3 = ProbUtils.GetRandomNumbersWithoutRepeating(0, type3Sprites.Count - 1, type3Moveables.Count);
		for (int k = 0; k < type3Moveables.Count; k++)
		{
			type3Moveables[k].sprite = type3Sprites[randomNumbersWithoutRepeating3[k]];
		}
	}
}
