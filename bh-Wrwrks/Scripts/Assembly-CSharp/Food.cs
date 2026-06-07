using UnityEngine;

public class Food : MonoBehaviour
{
	public Module foodMod;

	public Sprite charged;

	public Sprite uncharged;

	public SpriteRenderer obj;

	private void Update()
	{
		if (foodMod.counter > 0)
		{
			obj.sprite = charged;
		}
		else
		{
			obj.sprite = uncharged;
		}
	}
}
