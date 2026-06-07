using UnityEngine;

public class Scythe : Weapon
{
	public GameObject spiritObj;

	public override void KillTrigger(Monster monster)
	{
		int num = 1;
		if (owner.UPGRADED)
		{
			num = 2;
		}
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = Object.Instantiate(spiritObj);
			if (num == 2)
			{
				gameObject.transform.position = base.transform.position + new Vector3(-0.1f + 0.2f * (float)i, 0f);
			}
			else
			{
				gameObject.transform.position = base.transform.position;
			}
			gameObject.transform.localScale = Vector3.zero;
			gameObject.GetComponent<ScytheSpirit>().source = this;
			gameObject.GetComponent<ScytheSpirit>().forceDamage = base.damage;
			gameObject.GetComponent<ScytheSpirit>().StartCoroutine(gameObject.GetComponent<ScytheSpirit>().Seeker());
		}
	}
}
