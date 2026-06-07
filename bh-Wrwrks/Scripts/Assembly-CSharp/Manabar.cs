using System.Collections.Generic;
using UnityEngine;

public class Manabar : MonoBehaviour
{
	public float start;

	public float end;

	public List<Sprite> spriteList;

	public SpriteRenderer bar;

	public Module owner;

	private float ratio;

	private int index;

	private void Awake()
	{
		owner = GetComponentInParent<Module>();
	}

	private void Update()
	{
		ratio = owner.mana / owner.manaCost;
		index = Mathf.CeilToInt(Mathf.Lerp(0f, spriteList.Count - 1, ratio));
		bar.sprite = spriteList[index];
	}
}
