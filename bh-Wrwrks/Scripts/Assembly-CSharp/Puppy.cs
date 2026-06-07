using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Puppy : Weapon
{
	private List<Vector3> points = new List<Vector3>();

	public Weapon target;

	private float speed = 0.15f;

	private Vector3 last = Vector3.zero;

	private bool init;

	private int idleCounter;

	public List<Sprite> idleAnim;

	public List<Sprite> runAnim;

	public void FindTarget()
	{
		Weapon weapon = null;
		if (owner.GetLeft() != null && owner.GetLeft().WEAPON)
		{
			weapon = owner.GetLeft().weapon;
		}
		if (target != weapon)
		{
			target = weapon;
			points.Clear();
		}
	}

	public override void ProcessFrame()
	{
		if (!init)
		{
			init = true;
			last = Dungeon.Instance.player.transform.position + new Vector3(-1.5f, 1.5f);
		}
		if (target != null)
		{
			if (points.Count < 45)
			{
				points.Add(target.transform.position);
			}
			else if (Vector3.Distance(points.Last(), base.transform.position) < 0.5f)
			{
				if (GetComponent<Animator>().frames[0] == runAnim[0])
				{
					if (idleCounter == 0)
					{
						GetComponent<Animator>().CustomAnim(idleAnim, 4f);
					}
					else
					{
						idleCounter--;
					}
				}
				points.RemoveAt(0);
				points.Add(target.transform.position);
			}
			else
			{
				if (GetComponent<Animator>().frames[0] == idleAnim[0])
				{
					idleCounter = 30;
					GetComponent<Animator>().CustomAnim(runAnim, 8f);
				}
				Vector3 normalized = (points.Last() - base.transform.position).normalized;
				float num = Mathf.Lerp(1f, 2f, Vector3.Distance(points.Last(), base.transform.position) / 2f);
				last += normalized * speed * num * owner.accelMult;
				points.RemoveAt(0);
				points.Add(target.transform.position);
			}
		}
		else
		{
			Vector3 normalized2 = (Dungeon.Instance.player.transform.position - base.transform.position).normalized;
			if (Vector3.Distance(Dungeon.Instance.player.transform.position, base.transform.position) > 1.5f)
			{
				last += normalized2 * speed;
			}
			else if (GetComponent<Animator>().frames[0] == runAnim[0])
			{
				GetComponent<Animator>().CustomAnim(idleAnim, 4f);
			}
		}
		base.transform.position = last;
	}

	public override IEnumerator Spin()
	{
		Vector3 last = pos;
		while (true)
		{
			float x = base.transform.position.x;
			float x2 = last.x;
			if (x2 != x)
			{
				GetComponent<SpriteRenderer>().flipX = x2 < x;
			}
			float z = (0f - Mathf.Clamp(x - x2, -2f, 2f)) * 90f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, z);
			last = base.transform.position;
			yield return null;
		}
	}
}
