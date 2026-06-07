using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MirrorWep : Weapon
{
	private Module target;

	public SpriteRenderer mainWep;

	public SpriteRenderer bgWep;

	public Collider2D hitbox;

	private List<GameObject> specialSprites = new List<GameObject>();

	private List<Coroutine> specialCoroutines = new List<Coroutine>();

	public GameObject ghostObj;

	private int t;

	public void CheckWeapon()
	{
		Module left = owner.GetLeft();
		if (left == target)
		{
			return;
		}
		if (left == null && target != null)
		{
			Collider2D[] components = GetComponents<Collider2D>();
			for (int i = 0; i < components.Length; i++)
			{
				Object.Destroy(components[i]);
			}
			hitbox = null;
			target = null;
			SpriteRenderer spriteRenderer = mainWep;
			Sprite sprite = (bgWep.sprite = null);
			spriteRenderer.sprite = sprite;
			SetSpecialEffects();
		}
		else
		{
			if (!left.WEAPON || left.name == Module.Name.Mirror)
			{
				return;
			}
			target = left;
			if (target != null)
			{
				SpriteRenderer spriteRenderer2 = mainWep;
				Sprite sprite = (bgWep.sprite = target.weapon.GetComponent<SpriteRenderer>().sprite);
				spriteRenderer2.sprite = sprite;
				SetSpecialEffects();
				Collider2D[] components = GetComponents<Collider2D>();
				for (int i = 0; i < components.Length; i++)
				{
					Object.Destroy(components[i]);
				}
				hitbox = null;
				Collider2D component = target.weapon.GetComponent<Collider2D>();
				component.GetType();
				if (component is BoxCollider2D)
				{
					BoxCollider2D boxCollider2D = this.AddComponent<BoxCollider2D>();
					BoxCollider2D component2 = component.GetComponent<BoxCollider2D>();
					hitbox = boxCollider2D;
					boxCollider2D.isTrigger = true;
					boxCollider2D.size = component2.size;
					boxCollider2D.offset = component.offset;
				}
				else if (component is CapsuleCollider2D)
				{
					CapsuleCollider2D capsuleCollider2D = this.AddComponent<CapsuleCollider2D>();
					CapsuleCollider2D component3 = component.GetComponent<CapsuleCollider2D>();
					hitbox = capsuleCollider2D;
					capsuleCollider2D.isTrigger = true;
					capsuleCollider2D.size = component3.size;
					capsuleCollider2D.direction = component3.direction;
					capsuleCollider2D.offset = component3.offset;
				}
				else if (component is CircleCollider2D)
				{
					CircleCollider2D circleCollider2D = this.AddComponent<CircleCollider2D>();
					CircleCollider2D component4 = component.GetComponent<CircleCollider2D>();
					hitbox = circleCollider2D;
					circleCollider2D.isTrigger = true;
					circleCollider2D.radius = component4.radius;
					circleCollider2D.offset = component4.offset;
				}
				else if (component is PolygonCollider2D)
				{
					PolygonCollider2D polygonCollider2D = this.AddComponent<PolygonCollider2D>();
					PolygonCollider2D component5 = component.GetComponent<PolygonCollider2D>();
					hitbox = polygonCollider2D;
					polygonCollider2D.isTrigger = true;
					polygonCollider2D.pathCount = component5.pathCount;
					polygonCollider2D.points = component5.points;
					polygonCollider2D.offset = component5.offset;
				}
				else
				{
					Debug.LogError("UNKNOWN COLLIDER TYPE FOR MIRROR");
				}
			}
		}
	}

	private void SetSpecialEffects()
	{
		if (target == null)
		{
			foreach (GameObject specialSprite in specialSprites)
			{
				Object.Destroy(specialSprite.gameObject);
			}
			foreach (Coroutine specialCoroutine in specialCoroutines)
			{
				StopCoroutine(specialCoroutine);
			}
			specialSprites.Clear();
			specialCoroutines.Clear();
			return;
		}
		Module.Name name = target.name;
		if (name <= Module.Name.Shuriken)
		{
			switch (name)
			{
			default:
				_ = 24;
				break;
			case Module.Name.Laser:
				CreateSpriteGhost(target.weapon.GetComponentsInChildren<SpriteRenderer>()[1]);
				break;
			case Module.Name.Bow:
				break;
			}
		}
		else if (name <= Module.Name.Flame)
		{
			if (name != Module.Name.Imp)
			{
				_ = 51;
			}
		}
		else if (name != Module.Name.Beehive)
		{
			_ = 82;
		}
	}

	public GameObject CreateSpriteGhost(SpriteRenderer spriteRenderer)
	{
		GameObject gameObject = Object.Instantiate(ghostObj);
		gameObject.transform.parent = base.transform;
		SpriteRenderer[] components = gameObject.GetComponents<SpriteRenderer>();
		foreach (SpriteRenderer obj in components)
		{
			obj.sprite = spriteRenderer.sprite;
			obj.size = spriteRenderer.size;
		}
		components = gameObject.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer obj2 in components)
		{
			obj2.sprite = spriteRenderer.sprite;
			obj2.size = spriteRenderer.size;
		}
		gameObject.transform.localEulerAngles = spriteRenderer.transform.localEulerAngles;
		gameObject.transform.localScale = spriteRenderer.transform.localScale;
		gameObject.transform.localPosition = spriteRenderer.transform.localPosition;
		specialSprites.Add(gameObject);
		return gameObject;
	}

	public void TurnToGhost(SpriteRenderer spriteRenderer)
	{
	}

	public override void HitTrigger(Monster monster)
	{
		if (target != null)
		{
			target.weapon.Hit(monster);
		}
		base.HitTrigger(monster);
	}

	public override void ProcessFrame()
	{
		if (!(target == null))
		{
			base.transform.localPosition = -target.weapon.transform.localPosition;
			base.transform.localScale = target.weapon.transform.localScale;
			SpriteRenderer spriteRenderer = mainWep;
			Sprite sprite = (bgWep.sprite = target.weapon.GetComponent<SpriteRenderer>().sprite);
			spriteRenderer.sprite = sprite;
			t = (t + 1) % 100;
		}
	}

	public override IEnumerator Spin()
	{
		while (true)
		{
			if (target == null)
			{
				yield return null;
				continue;
			}
			base.transform.localEulerAngles = target.weapon.transform.localEulerAngles + new Vector3(0f, 0f, 180f);
			yield return null;
		}
	}
}
