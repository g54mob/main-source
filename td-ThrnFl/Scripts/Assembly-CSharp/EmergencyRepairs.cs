using System.Collections.Generic;
using UnityEngine;

public class EmergencyRepairs : MonoBehaviour
{
	private float nextTickIn = 1.72f;

	private List<TaggedObject> walls = new List<TaggedObject>();

	[SerializeField]
	private Equippable requiredEquippable;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float healthTransfer = 0.2f;

	private List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	private TagManager tagManager;

	private void Start()
	{
		if (!PerkManager.IsEquipped(requiredEquippable))
		{
			Object.Destroy(this);
		}
		tagManager = TagManager.instance;
		mustHaveTags.Add(TagManager.ETag.Wall);
		mustHaveTags.Add(TagManager.ETag.AUTO_Alive);
	}

	private void Update()
	{
		nextTickIn -= Time.deltaTime;
		if (!(nextTickIn <= 0f))
		{
			return;
		}
		nextTickIn = 2f;
		tagManager.FindAllTaggedObjectsWithTags(walls, mustHaveTags, mayNotHaveTags);
		if (walls.Count <= 0)
		{
			return;
		}
		float num = 0f;
		foreach (TaggedObject wall in walls)
		{
			num += wall.Hp.maxHp - wall.Hp.HpValue;
		}
		num /= (float)walls.Count;
		foreach (TaggedObject wall2 in walls)
		{
			float num2 = (wall2.Hp.maxHp - wall2.Hp.HpValue - num) * healthTransfer;
			wall2.Hp.TakeDamage(0f - num2);
		}
	}
}
