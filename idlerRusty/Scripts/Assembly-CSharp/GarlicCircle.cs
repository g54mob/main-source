using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GarlicCircle : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer attackSpriteRenderer;

	[SerializeField]
	private SpriteRenderer baseSpriteRenderer;

	[SerializeField]
	private Color color;

	[SerializeField]
	private Color offWhite;

	[SerializeField]
	private float range;

	[SerializeField]
	private float speed = 0.5f;

	private float timeOffset;

	private void Start()
	{
		attackSpriteRenderer.color = Color.clear;
		timeOffset = Random.Range(0f, 1f / speed);
		InvokeRepeating("DamageBats", Random.Range(0f, 1f), 1f);
	}

	private void Update()
	{
		float t = Mathf.PingPong(timeOffset + Time.time * speed, 1f);
		baseSpriteRenderer.color = Color.Lerp(color, offWhite, t);
	}

	private IEnumerator FlashRed()
	{
		Color previousColor = attackSpriteRenderer.color;
		attackSpriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.08f);
		attackSpriteRenderer.color = previousColor;
	}

	private void DamageBats()
	{
		for (int i = 0; i < GameManager.ins.vampireBats.Count; i++)
		{
			VampireBat vampireBat = GameManager.ins.vampireBats[i];
			if (!(vampireBat.transform.position.x > base.transform.position.x + range) && !(vampireBat.transform.position.x < base.transform.position.x - range) && !(vampireBat.transform.position.y > base.transform.position.y + range) && !(vampireBat.transform.position.y < base.transform.position.y - range) && Vector2.Distance(vampireBat.transform.position, base.transform.position) < range)
			{
				Flash();
				GameManager.ins.vampireBats[i].TakeDamage();
			}
		}
	}

	private void Flash()
	{
		if (!(attackSpriteRenderer.color == offWhite))
		{
			attackSpriteRenderer.DOKill();
			attackSpriteRenderer.color = offWhite;
			attackSpriteRenderer.DOFade(0f, 2f).SetDelay(1f);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, range);
	}
}
