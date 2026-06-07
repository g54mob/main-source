using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Weapon
{
	private int t = 1;

	public GameObject flowerObject;

	public List<Sprite> flowerSprites;

	public List<Sprite> waterSprites;

	public GameObject waterObject;

	private bool spawn;

	public Sprite waterHitSprite;

	public Sprite waterHitSprite2;

	private List<GameObject> flowers => base.animationManager.flowerObjects;

	public override void ProjectileHit(Monster monster)
	{
		Hit(monster);
	}

	public override void ProcessFrame()
	{
		t++;
		if (t % (base.UPGRADED ? 20 : 30) == 0)
		{
			spawn = true;
			t = 1;
		}
		if (t % 5 == 0)
		{
			DropWater();
		}
		base.ProcessFrame();
	}

	private void DropWater()
	{
		int num = 15;
		GameObject gameObject = Object.Instantiate(waterObject);
		gameObject.transform.position = base.transform.position + new Vector3(Random.Range(-0.1875f, 0.1875f) + (GetComponent<SpriteRenderer>().flipX ? 0.4f : (-0.4f)), -0.5f + Random.Range(-0.125f, 0.125f));
		gameObject.GetComponent<SpriteRenderer>().sprite = Utils.RandElem(waterSprites);
		StartCoroutine(waterHit(gameObject, num - 2));
		base.animationManager.Fade(gameObject, 1, num);
	}

	private IEnumerator waterHit(GameObject g, int f)
	{
		base.animationManager.MoveDir(g, new Vector3(0f, -1f), 0.15f, f);
		yield return Dungeon.Wait(f);
		if (spawn)
		{
			SpawnFlower(g.transform.position);
		}
		g.GetComponent<SpriteRenderer>().sprite = Utils.Rand(waterHitSprite, waterHitSprite2);
	}

	private void SpawnFlower(Vector3 pos)
	{
		spawn = false;
		flowers.RemoveAll((GameObject x) => x == null);
		foreach (GameObject flower in flowers)
		{
			if (Vector3.Distance(flower.transform.position, pos) < (base.UPGRADED ? 0.55f : 0.75f))
			{
				return;
			}
		}
		GameObject gameObject = Object.Instantiate(flowerObject);
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Droplets, 0.8f, 1.2f, 1f);
		flowers.Add(gameObject);
		gameObject.transform.position = pos;
		gameObject.transform.localScale = Vector3.zero;
		base.animationManager.LerpZoom(gameObject, base.transform.localScale, 15f, 0.2f);
		Water_Flower component = gameObject.GetComponent<Water_Flower>();
		component.forceDamage = base.damage;
		component.index = Random.Range(0, flowerSprites.Count);
		component.GetComponent<SpriteRenderer>().sprite = flowerSprites[component.index];
		component.GetComponent<SpriteRenderer>().flipX = Utils.RNG(50f);
		int num = 0;
		foreach (Module item in owner.board.GetBoard())
		{
			if (item.name == Module.Name.Water)
			{
				num += owner.counter;
			}
		}
		if (flowers.Count > num)
		{
			Object.Destroy(flowers[0]);
			flowers[0].GetComponent<Water_Flower>().Explode();
			flowers.Remove(flowers[0]);
		}
	}

	public override IEnumerator Spin()
	{
		Vector3 last = pos;
		while (true)
		{
			Vector3 position = base.transform.position;
			float x = position.x;
			float x2 = last.x;
			GetComponent<SpriteRenderer>().flipX = position.x > last.x;
			float z = (0f - Mathf.Clamp(x - x2, -2f, 2f)) * 90f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, z);
			last = base.transform.position;
			yield return null;
		}
	}
}
