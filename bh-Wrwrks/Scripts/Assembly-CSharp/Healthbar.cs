using UnityEngine;

public class Healthbar : MonoBehaviour
{
	public Monster monster;

	public Player player;

	public SpriteRenderer bar;

	public SpriteRenderer barBG;

	private float hp;

	private float maxHP;

	private const float min = 0.0625f;

	private void Start()
	{
	}

	private void Update()
	{
		if (monster != null)
		{
			hp = monster.health;
			maxHP = monster.maxHealth;
		}
		else
		{
			if (!(player != null))
			{
				return;
			}
			hp = player.health;
			maxHP = player.maxHealth;
		}
		if (hp == maxHP || hp <= 0f)
		{
			bar.enabled = false;
			barBG.enabled = false;
			return;
		}
		bar.enabled = true;
		barBG.enabled = true;
		bar.transform.localScale = new Vector3(Mathf.Max(0.0625f, hp / maxHP), 1f);
		if (monster != null)
		{
			base.transform.localEulerAngles = -monster.transform.localEulerAngles;
		}
	}
}
