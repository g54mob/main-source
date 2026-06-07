using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
	public enum Type
	{
		Heal = 0,
		Hurt = 1,
		Damage = 2,
		Cash = 3
	}

	public List<SpriteRenderer> singleDigit;

	public List<SpriteRenderer> doubleDigit;

	public List<SpriteRenderer> cashSprites;

	public Sprite[] sprites;

	public Sprite[] signSprites;

	public Color[] colors;

	private void Awake()
	{
		Dungeon.Instance.animationManager.numberCount++;
	}

	private void OnDestroy()
	{
		Dungeon.Instance.animationManager.numberCount--;
	}

	public void Set(int num, Type type, Vector3 pos, string customColor = "")
	{
		bool flag = false;
		if (num > 99)
		{
			num = 99;
			flag = true;
		}
		SpriteRenderer spriteRenderer;
		if (num >= 10)
		{
			foreach (SpriteRenderer item in doubleDigit)
			{
				item.enabled = true;
				item.color = ((customColor != "") ? Utils.GetColor(customColor) : colors[(int)type]);
			}
			doubleDigit[1].sprite = sprites[num / 10];
			doubleDigit[2].sprite = sprites[num % 10];
			spriteRenderer = doubleDigit[0];
			if (flag)
			{
				spriteRenderer.transform.localPosition = new Vector3(0.375f, spriteRenderer.transform.localPosition.y);
				spriteRenderer.sprite = signSprites[0];
			}
		}
		else if (type == Type.Cash)
		{
			foreach (SpriteRenderer cashSprite in cashSprites)
			{
				cashSprite.enabled = true;
				cashSprite.color = ((customColor != "") ? Utils.GetColor(customColor) : colors[(int)type]);
			}
			cashSprites[2].sprite = sprites[num];
			spriteRenderer = cashSprites[0];
		}
		else
		{
			foreach (SpriteRenderer item2 in singleDigit)
			{
				item2.enabled = true;
				item2.color = ((customColor != "") ? Utils.GetColor(customColor) : colors[(int)type]);
			}
			singleDigit[1].sprite = sprites[num];
			spriteRenderer = singleDigit[0];
		}
		switch (type)
		{
		case Type.Heal:
		case Type.Cash:
			spriteRenderer.sprite = signSprites[0];
			break;
		case Type.Hurt:
			spriteRenderer.sprite = signSprites[1];
			break;
		case Type.Damage:
			spriteRenderer.enabled = flag;
			break;
		}
		StartCoroutine(Anim());
	}

	private IEnumerator Anim()
	{
		Dungeon.Instance.animationManager.MoveDir(base.gameObject, new Vector3(0f, 1f), 1f / 32f);
		yield return Dungeon.Wait(35);
		yield return Dungeon.Instance.animationManager.LerpZoom(base.gameObject, Vector3.zero, 7f);
		Object.Destroy(base.gameObject);
	}
}
